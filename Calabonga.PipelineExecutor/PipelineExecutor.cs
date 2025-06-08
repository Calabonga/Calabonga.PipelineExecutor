using Microsoft.Extensions.Logging;

namespace Calabonga.PipelineExecutor;

/// <summary>
/// Pipeline steps executor
/// </summary>
/// <typeparam name="T"></typeparam>
public sealed class PipelineExecutor<T> where T : class
{
    private readonly List<PipelineEvent> _events = [];
    private readonly IPipelineContext<T> _context;
    private readonly ILogger<PipelineExecutor<T>> _logger;
    private readonly List<IPipelineStep<T>> _steps;

    public PipelineExecutor(
        IEnumerable<IPipelineStep<T>> steps,
        IPipelineContext<T> context,
        ILogger<PipelineExecutor<T>> logger)
    {
        _context = context;
        _logger = logger;
        _steps = steps.ToList();

        _events.Add(new PipelineEvent { Message = $"Total steps added from container {_steps.Count}", LogLevel = LogLevel.Information });
    }

    /// <summary>
    /// Registers a step for current pipeline
    /// </summary>
    /// <param name="step"></param>
    public void AddStep(IPipelineStep<T> step)
    {
        if (step is PipelineStep<T> pipelineStep)
        {
            pipelineStep.IsManual = true;
        }

        _steps.Add(step);

        _events.Add(new PipelineEvent { Message = "Manual step added", LogLevel = LogLevel.Information });
    }

    /// <summary>
    /// Runs execute steps in current pipelines
    /// </summary>
    /// <param name="item"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<PipelineResult<T>> RunAsync(T item, CancellationToken cancellationToken)
    {
        if (!_steps.Any())
        {
            var message = "[PIPELINE] Sorry. No steps provided.";
            if (_logger.IsEnabled(LogLevel.Error))
            {
                _logger.LogError(message);
            }
            return PipelineResult<T>.Failure(message, _events);
        }

        if (_logger.IsEnabled(LogLevel.Information))
        {
            _logger.LogDebug("[PIPELINE] Filtering steps in accordance with strategy {StrategyName}", _context.AdditionalStepStrategy);
        }

        var stepsToExecute = _context.AdditionalStepStrategy switch
        {
            AdditionalStepStrategy.Undefined => _steps,
            AdditionalStepStrategy.Append => _steps,
            AdditionalStepStrategy.ManualOnly => _steps.Where(_strategyFilter),
            _ => throw new ArgumentOutOfRangeException()
        };

        try
        {
            foreach (var step in stepsToExecute.OrderBy(x => x.OrderIndex))
            {
                if (_logger.IsEnabled(LogLevel.Debug))
                {
                    _logger.LogInformation("[PIPELINE] Step {Name} with order {StemIndex} is starting...",
                        step.GetType().Name,
                        step.OrderIndex);
                }

                var stepResult = await step
                    .ExecuteAsync(item, _context, _logger, cancellationToken)
                    .ConfigureAwait(false);

                if (!stepResult.Ok)
                {
                    _logger.LogError(stepResult.ErrorMessage);

                    switch (_context.FailedStepStrategy)
                    {
                        case FailedStepStrategy.StopPipeline:
                            _events.Add(new PipelineEvent
                            {
                                Message = stepResult.ErrorMessage!,
                                LogLevel = LogLevel.Error
                            });
                            return PipelineResult<T>.Failure(stepResult.ErrorMessage!, _events);

                        case FailedStepStrategy.NotStopPipeline:
                            _events.Add(new PipelineEvent
                            {
                                Message = stepResult.ErrorMessage!,
                                LogLevel = LogLevel.Error
                            });
                            break;
                        case FailedStepStrategy.Undefined:
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }

                if (_logger.IsEnabled(LogLevel.Debug))
                {
                    _logger.LogInformation("[PIPELINE] Step {Name} with order {StemIndex} is done...",
                        step.GetType().Name,
                        step.OrderIndex);
                }
            }

            return PipelineResult<T>.Success(item, _events);
        }
        catch (Exception exception)
        {
            return PipelineResult<T>.Failure(exception.Message, _events);
        }
    }

    private readonly Func<IPipelineStep<T>, bool> _strategyFilter = step =>
    {
        if (step is PipelineStep<T> pipelineStep)
        {
            return pipelineStep.IsManual;
        }
        return false;
    };
}
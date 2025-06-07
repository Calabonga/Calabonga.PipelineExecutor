using Microsoft.Extensions.Logging;

namespace Calabonga.PipelineExecutor;

/// <summary>
/// Pipeline steps executor
/// </summary>
/// <typeparam name="T"></typeparam>
public sealed class PipelineExecutor<T> where T : class
{
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
            return PipelineResult<T>.Failure(errorMessage: message);
        }

        var stepsToExecute = _context.Strategy switch
        {
            ExecuteStepStrategy.Undefined => _steps,
            ExecuteStepStrategy.Append => _steps,
            ExecuteStepStrategy.ManualOnly => _steps.Where(_strategyFilter),
            _ => throw new ArgumentOutOfRangeException()
        };

        foreach (var step in stepsToExecute.OrderBy(x => x.OrderIndex))
        {
            if (_logger.IsEnabled(LogLevel.Debug))
            {
                _logger.LogInformation("[PIPELINE] Step {Name} with order {StemIndex} is starting...",
                    step.GetType().Name,
                    step.OrderIndex);
            }

            await step.ExecuteAsync(item, _context, _logger, cancellationToken).ConfigureAwait(false);

            if (_logger.IsEnabled(LogLevel.Debug))
            {
                _logger.LogInformation("[PIPELINE] Step {Name} with order {StemIndex} is done...",
                    step.GetType().Name,
                    step.OrderIndex);
            }
        }

        return PipelineResult<T>.Success(item);
    }

    private readonly Func<IPipelineStep<T>, bool> _strategyFilter = step
    =>
    {
        if (step is PipelineStep<T> pipelineStep)
        {
            return pipelineStep.IsManual;
        }
        return false;
    };
}
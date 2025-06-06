namespace Calabonga.PipelineExecutor;

/// <summary>
/// Pipeline steps executor
/// </summary>
/// <typeparam name="T"></typeparam>
public class PipelineExecutor<T> where T : class
{
    private readonly PipelineContext<T> _context;
    private readonly List<IPipelineStep<T>> _steps = [];

    public PipelineExecutor(PipelineContext<T> context)
    {
        _context = context;
    }

    /// <summary>
    /// Registers a step for current pipelene
    /// </summary>
    /// <param name="step"></param>
    public void AddStep(IPipelineStep<T> step)
    {
        _steps.Add(step);
    }

    /// <summary>
    /// Runs execute steps in current pipelines
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<PipelineResult<T>> RunAsync(CancellationToken cancellationToken)
    {
        if (!_steps.Any())
        {
            return PipelineResult<T>.Failure(errorMessage: "Sorry. No steps provided.");
        }

        foreach (var step in _steps.OrderBy(x => x.OrderIndex))
        {
            await step.ExecuteAsync(_context, cancellationToken).ConfigureAwait(false);
        }

        return PipelineResult<T>.Success(_context.Item);
    }
}
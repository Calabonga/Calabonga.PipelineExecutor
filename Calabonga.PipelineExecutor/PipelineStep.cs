namespace Calabonga.PipelineExecutor;

/// <summary>
/// Default pipeline step class with base functionality
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class PipelineStep<T> : IPipelineStep<T> where T : class
{
    /// <summary>
    /// Sorting index on execution
    /// </summary>
    public virtual int OrderIndex { get; } = 0;

    /// <summary>
    /// Executes pipeline step
    /// </summary>
    /// <param name="context"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public abstract Task ExecuteAsync(PipelineContext<T> context, CancellationToken cancellationToken);
}
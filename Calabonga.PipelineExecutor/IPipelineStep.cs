namespace Calabonga.PipelineExecutor;

/// <summary>
/// Default pipeline step class with base functionality
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IPipelineStep<T> where T : class
{
    /// <summary>
    /// Sorting index on execution
    /// </summary>
    int OrderIndex { get; }

    /// <summary>
    /// Executes pipeline step
    /// </summary>
    /// <param name="context"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task ExecuteAsync(PipelineContext<T> context, CancellationToken cancellationToken);
}
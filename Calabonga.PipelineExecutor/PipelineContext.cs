namespace Calabonga.PipelineExecutor;

/// <summary>
/// Context for pipeline step
/// </summary>
/// <typeparam name="T"></typeparam>
public class PipelineContext<T> where T : class
{
    public PipelineContext(T item)
    {
        Item = item;
    }

    /// <summary>
    /// Processing entity
    /// </summary>
    public T Item { get; }
}

namespace Calabonga.PipelineExecutor;

public class PipelineContext<T> where T : class
{
    public PipelineContext(T item)
    {
        Item = item;
    }

    public T Item { get; }
}

namespace Calabonga.PipelineExecutor;

public abstract class PipelineStep<T> : IPipelineStep<T> where T : class
{
    public virtual int OrderIndex { get; } = 0;

    public abstract Task ExecuteAsync(PipelineContext<T> context, CancellationToken cancellationToken);
}
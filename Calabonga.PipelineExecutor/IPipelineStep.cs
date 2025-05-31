namespace Calabonga.PipelineExecutor;

public interface IPipelineStep<T> where T : class
{
    int OrderIndex { get; }

    Task ExecuteAsync(PipelineContext<T> context, CancellationToken cancellationToken);
}
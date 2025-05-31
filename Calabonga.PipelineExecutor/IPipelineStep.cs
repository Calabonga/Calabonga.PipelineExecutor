namespace Calabonga.PipelineExecutor;

public interface IPipelineStep<T> where T : class
{
    void Execute(PipelineContext<T> context);
}

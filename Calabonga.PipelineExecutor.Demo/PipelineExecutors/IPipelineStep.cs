namespace Calabonga.PipelineExecutor.Demo.PipelineExecutors;

public interface IPipelineStep
{
    void Execute(PipelineContext context);
}

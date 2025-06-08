using Microsoft.Extensions.Logging;

namespace Calabonga.PipelineExecutor.Demo.Steps;

public class ManualStep : PipelineStep<Image>
{
    public override int OrderIndex => -1;

    public override Task ExecuteAsync(
        Image item,
        IPipelineContext<Image> context,
        ILogger<PipelineExecutor<Image>> logger,
        CancellationToken cancellationToken)
    {
        logger.LogInformation("[PIPELINE] Step manual executed");

        return Task.CompletedTask;
    }
}
using Microsoft.Extensions.Logging;

namespace Calabonga.PipelineExecutor.Demo.Steps;

public class ResizeStep : PipelineStep<Image>
{
    public override int OrderIndex => 2;

    public override Task<StepResult> ExecuteAsync(
        Image item,
        IPipelineContext<Image> context,
        ILogger<PipelineExecutor<Image>> logger,
        CancellationToken cancellationToken)
    {
        item.Height = 100;
        item.Width = 100;

        logger.LogInformation("[PIPELINE] Resize done 100 x 100");

        return Task.FromResult(StepResult.Failure("error during resizing"));
    }
}

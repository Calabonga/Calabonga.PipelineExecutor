using Microsoft.Extensions.Logging;

namespace Calabonga.PipelineExecutor.Demo.Steps;

public class UpdateNameStep : PipelineStep<Image>
{
    public override int OrderIndex => 0;

    public override Task<StepResult> ExecuteAsync(
        Image item,
        IPipelineContext<Image> context,
        ILogger<PipelineExecutor<Image>> logger,
        CancellationToken cancellationToken)
    {
        if (context is ImagePipelineContext imagePipelineContext)
        {
            var name = imagePipelineContext.Name;
            item.Name = name;
            if (logger.IsEnabled(LogLevel.Debug))
            {
                logger.LogDebug("[PIPELINE] {ContextName} applied.", nameof(ImagePipelineContext));
            }

            return Task.FromResult(StepResult.Failure("TEST"));
        }

        logger.LogInformation("[PIPELINE] Default name applied.");

        item.Name = "ImageFromPipeline.png";

        return Task.FromResult(StepResult.Success());
    }
}

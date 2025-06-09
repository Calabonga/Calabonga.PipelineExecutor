using Microsoft.Extensions.Logging;

namespace Calabonga.PipelineExecutor.Demo.Steps;

public class UppercaseNameStep : PipelineStep<Image>
{
    public override int OrderIndex => 1;

    public override Task<StepResult> ExecuteAsync(
        Image item,
        IPipelineContext<Image> context,
        ILogger<PipelineExecutor<Image>> logger,
        CancellationToken cancellationToken)
    {
        item.Name = item.Name.ToUpperInvariant();
        logger.LogInformation("[PIPELINE] Uppercase name transformed");

        return Task.FromResult(StepResult.Success());
    }
}
namespace Calabonga.PipelineExecutor.Demo.Steps;

public class UpdateNameStep : PipelineStep<Image>
{
    public override int OrderIndex => 0;

    public override Task ExecuteAsync(PipelineContext<Image> context, CancellationToken cancellationToken)
    {
        context.Item.Name = "ImageFromPipeline.png";

        return Task.CompletedTask;
    }
}

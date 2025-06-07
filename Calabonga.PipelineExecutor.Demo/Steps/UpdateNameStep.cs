namespace Calabonga.PipelineExecutor.Demo.Steps;

public class UpdateNameStep : PipelineStep<Image>
{
    public override int OrderIndex => 0;

    public override Task ExecuteAsync(Image item, PipelineContext<Image> context, CancellationToken cancellationToken)
    {
        item.Name = "ImageFromPipeline.png";

        return Task.CompletedTask;
    }
}

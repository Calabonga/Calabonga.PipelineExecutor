namespace Calabonga.PipelineExecutor.Demo.Steps;

public class UpdateNameStep : PipelineStep<Image>
{
    public override int OrderIndex => 0;

    public override Task ExecuteAsync(Image item, IPipelineContext<Image> context, CancellationToken cancellationToken)
    {
        if (context is ImagePipelineContext imagePipelineContext)
        {
            var name = imagePipelineContext.Name;
            item.Name = name;
            return Task.CompletedTask;
        }

        item.Name = "ImageFromPipeline.png";

        return Task.CompletedTask;
    }
}

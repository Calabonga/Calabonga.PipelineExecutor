namespace Calabonga.PipelineExecutor.Demo.Steps;

public class UpdateNameStep : IPipelineStep<Image>
{
    public void Execute(PipelineContext<Image> context)
    {
        context.Item.Name = "ImageFromPipeline.png";
    }
}

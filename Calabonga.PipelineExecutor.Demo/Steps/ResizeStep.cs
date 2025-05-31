namespace Calabonga.PipelineExecutor.Demo.Steps;

public class ResizeStep : IPipelineStep<Image>
{
    public void Execute(PipelineContext<Image> context)
    {
        context.Item.Height = 100;
        context.Item.Width = 100;
    }
}

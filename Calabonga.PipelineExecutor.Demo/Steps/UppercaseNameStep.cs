namespace Calabonga.PipelineExecutor.Demo.Steps;

public class UppercaseNameStep : IPipelineStep<Image>
{
    public void Execute(PipelineContext<Image> context)
    {
        context.Item.Name = context.Item.Name.ToUpperInvariant();
    }
}

namespace Calabonga.PipelineExecutor.Demo.Steps;

public class UppercaseNameStep : PipelineStep<Image>
{
    public override int OrderIndex => 1;

    public override Task ExecuteAsync(PipelineContext<Image> context, CancellationToken cancellationToken)
    {
        context.Item.Name = context.Item.Name.ToUpperInvariant();

        return Task.CompletedTask;
    }
}

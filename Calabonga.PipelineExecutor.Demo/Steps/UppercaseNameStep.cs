namespace Calabonga.PipelineExecutor.Demo.Steps;

public class UppercaseNameStep : PipelineStep<Image>
{
    public override int OrderIndex => 1;

    public override Task ExecuteAsync(Image item, IPipelineContext<Image> context, CancellationToken cancellationToken)
    {
        item.Name = item.Name.ToUpperInvariant();

        return Task.CompletedTask;
    }
}

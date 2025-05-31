namespace Calabonga.PipelineExecutor.Demo.Steps;

public class ResizeStep : PipelineStep<Image>
{
    public override int OrderIndex => 2;
    public override Task ExecuteAsync(PipelineContext<Image> context, CancellationToken cancellationToken)
    {
        context.Item.Height = 100;
        context.Item.Width = 100;

        return Task.CompletedTask;
    }
}

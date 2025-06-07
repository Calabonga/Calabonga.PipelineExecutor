namespace Calabonga.PipelineExecutor.Demo.Steps;

public class ResizeStep : PipelineStep<Image>
{
    public override int OrderIndex => 2;

    public override Task ExecuteAsync(Image item, PipelineContext<Image> context, CancellationToken cancellationToken)
    {
        item.Height = 100;
        item.Width = 100;

        return Task.CompletedTask;
    }
}

namespace Calabonga.PipelineExecutor.Demo.PipelineExecutors;

public class PipelineContext
{
    public PipelineContext(Image image)
    {
        Image = image;
    }

    public Image Image { get; }
}

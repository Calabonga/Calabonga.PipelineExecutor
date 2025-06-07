using Microsoft.Extensions.Options;

namespace Calabonga.PipelineExecutor.Demo;

/// <summary>
/// 
/// </summary>
public class ImagePipelineContext : IPipelineContext<Image>
{
    public ImagePipelineContext(IOptions<AppSettings> settings)
    {
        Name = settings.Value.Name ?? "ImageFromPipeline.png";
    }

    public string Name { get; }

    public ExecuteStepStrategy Strategy => ExecuteStepStrategy.Append;
}
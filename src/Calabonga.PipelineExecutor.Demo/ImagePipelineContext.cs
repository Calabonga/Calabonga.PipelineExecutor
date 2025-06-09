using Microsoft.Extensions.Options;

namespace Calabonga.PipelineExecutor.Demo;

/// <summary>
/// Custom configuration for <see cref="PipelineExecutor{T}"/>
/// with some additional parameters
/// </summary>
public class ImagePipelineContext : IPipelineContext<Image>
{
    public ImagePipelineContext(IOptions<AppSettings> settings)
    {
        Name = settings.Value.Name ?? "ImageFromPipeline.png";
    }

    public string Name { get; }

    public AdditionalStepStrategy AdditionalStepStrategy => AdditionalStepStrategy.Append;

    public FailedStepStrategy FailedStepStrategy => FailedStepStrategy.NotStopPipeline;
}
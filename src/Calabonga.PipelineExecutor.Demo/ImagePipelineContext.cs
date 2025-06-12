using Calabonga.PipelineExecutor.Demo.Steps;
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
        ImageDefaultName = settings.Value.Name ?? "ImageFromPipeline.png";
    }

    /// <summary>
    /// Will be used in <see cref="UpdateNameStep"/>
    /// </summary>
    public string ImageDefaultName { get; }

    /// <summary>
    /// Strategy for steps executing when manual steps added (<see cref="PipelineExecutor.AdditionalStepStrategy"/>).
    /// </summary>
    public AdditionalStepStrategy AdditionalStepStrategy => AdditionalStepStrategy.Append;

    /// <summary>
    /// Strategy when step operation failed (<see cref="FailedStepStrategy"/>)
    /// </summary>
    public FailedStepStrategy FailedStepStrategy => FailedStepStrategy.NotStopPipeline;
}

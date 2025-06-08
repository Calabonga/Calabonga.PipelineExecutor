namespace Calabonga.PipelineExecutor;

/// <summary>
/// Strategy for steps executing when manual steps added.
/// </summary>
public enum AdditionalStepStrategy
{
    /// <summary>
    /// Not defined strategy is unacceptable
    /// </summary>
    Undefined,

    /// <summary>
    /// Appends manual steps into pipeline in accordance with order index for all steps 
    /// </summary>
    Append,

    /// <summary>
    /// Appends manual steps into pipeline but remove all injected steps 
    /// </summary>
    ManualOnly
}
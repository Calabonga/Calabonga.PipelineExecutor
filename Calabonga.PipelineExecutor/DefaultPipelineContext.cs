namespace Calabonga.PipelineExecutor;

/// <summary>
/// Default Context pipeline
/// </summary>
/// <typeparam name="T"></typeparam>
public sealed class DefaultPipelineContext<T> : IPipelineContext<T> where T : class
{
    /// <summary>
    /// Strategy for steps executing when manual steps added.
    /// </summary>
    public ExecuteStepStrategy Strategy { get; } = ExecuteStepStrategy.Append;
}
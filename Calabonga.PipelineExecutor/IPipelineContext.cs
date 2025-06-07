namespace Calabonga.PipelineExecutor;

/// <summary>
/// Context for pipeline step
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IPipelineContext<T> where T : class
{
    /// <summary>
    /// Strategy for steps executing when manual steps added. <see cref="ExecuteStepStrategy"/>
    /// </summary>
    ExecuteStepStrategy Strategy { get; }
}
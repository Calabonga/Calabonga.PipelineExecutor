namespace Calabonga.PipelineExecutor
{
    public enum FailedStepStrategy
    {
        /// <summary>
        /// Not defined strategy is unacceptable
        /// </summary>
        Undefined,

        /// <summary>
        /// Stop pipeline, do not execute next steps
        /// </summary>
        StopPipeline,

        /// <summary>
        /// Not stop when error occurred, do all next steps
        /// </summary>
        NotStopPipeline
    }
}
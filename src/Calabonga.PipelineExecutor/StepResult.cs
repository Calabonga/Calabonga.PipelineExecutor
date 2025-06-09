namespace Calabonga.PipelineExecutor
{
    /// <summary>
    /// Step operation result
    /// </summary>
    public sealed class StepResult
    {
        private StepResult(string? errorMessage)
        {
            ErrorMessage = errorMessage;
        }

        /// <summary>
        /// Returns result as successfully completed operation
        /// </summary>
        /// <returns></returns>
        public static StepResult Success() => new StepResult(null);

        /// <summary>
        /// Returns an error as additional information about what failed and why
        /// </summary>
        /// <param name="errorMessage"></param>
        /// <returns></returns>
        public static StepResult Failure(string errorMessage) => new StepResult(errorMessage);

        /// <summary>
        /// Error message about why failure occurred
        /// </summary>
        public string? ErrorMessage { get; }

        /// <summary>
        /// Checks error message as validation
        /// </summary>
        public bool Ok => string.IsNullOrWhiteSpace(ErrorMessage);
    }
}
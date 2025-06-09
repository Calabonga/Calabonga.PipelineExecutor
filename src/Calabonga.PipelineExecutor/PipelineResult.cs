using System.Collections.Generic;

namespace Calabonga.PipelineExecutor
{
    /// <summary>
    /// Pipeline result wrapper
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed class PipelineResult<T> where T : class
    {
        #region constructor

        private PipelineResult(IEnumerable<PipelineEvent> logs, T? result, string? errorMessage)
        {
            Events = logs;
            Result = result;
            ErrorMessage = errorMessage;
        }

        /// <summary>
        /// Pipeline event list
        /// </summary>
        public IEnumerable<PipelineEvent> Events { get; }

        #endregion

        /// <summary>
        /// Returns result as successfully completed operation
        /// </summary>
        /// <param name="result"></param>
        /// <param name="logs"></param>
        /// <returns></returns>
        public static PipelineResult<T> Success(T result, IEnumerable<PipelineEvent> logs)
            => new PipelineResult<T>(logs, result, null);

        /// <summary>
        /// Returns an error as additional information about what failed and why
        /// </summary>
        /// <param name="errorMessage"></param>
        /// <param name="logs"></param>
        /// <returns></returns>
        public static PipelineResult<T> Failure(string errorMessage, IEnumerable<PipelineEvent> logs)
            => new PipelineResult<T>(logs, null, errorMessage);

        /// <summary>
        /// Result of the pipeline
        /// </summary>
        public T? Result { get; }

        /// <summary>
        /// Error message about why failure occurred
        /// </summary>
        public string? ErrorMessage { get; }
    }
}
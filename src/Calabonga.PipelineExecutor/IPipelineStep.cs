using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Calabonga.PipelineExecutor
{
    /// <summary>
    /// Default pipeline step class with base functionality
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IPipelineStep<T> where T : class
    {
        /// <summary>
        /// Sorting index on execution
        /// </summary>
        int OrderIndex { get; }

        /// <summary>
        /// Executes pipeline step
        /// </summary>
        /// <param name="item"></param>
        /// <param name="context"></param>
        /// <param name="logger"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<StepResult> ExecuteAsync(
            T item,
            IPipelineContext<T> context,
            ILogger<PipelineExecutor<T>> logger,
            CancellationToken cancellationToken);
    }
}
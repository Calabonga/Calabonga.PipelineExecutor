using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Calabonga.PipelineExecutor
{
    /// <summary>
    /// Pipeline step with base functionality
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class PipelineStep<T> : IPipelineStep<T> where T : class
    {
        /// <summary>
        /// Sorting index for step executing
        /// </summary>
        public virtual int OrderIndex { get; } = 0;

        /// <summary>
        /// Indicate how it's added into executor. When <c>True</c> then added manually.
        /// </summary>
        protected internal bool IsManual { get; set; }

        /// <summary>
        /// Executes pipeline steps in accordance with order index.
        /// </summary>
        /// <param name="item">item to process</param>
        /// <param name="context"></param>
        /// <param name="logger"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public abstract Task<StepResult> ExecuteAsync(
            T item,
            IPipelineContext<T> context,
            ILogger<PipelineExecutor<T>> logger,
            CancellationToken cancellationToken);
    }
}
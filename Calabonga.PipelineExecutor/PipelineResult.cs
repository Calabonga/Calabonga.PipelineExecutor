namespace Calabonga.PipelineExecutor;

/// <summary>
/// Pipeline result wrapper
/// </summary>
/// <typeparam name="T"></typeparam>
public sealed class PipelineResult<T> where T : class
{
    /// <summary>
    /// Returns result as successfully completed operation
    /// </summary>
    /// <param name="result"></param>
    /// <returns></returns>
    public static PipelineResult<T> Success(T result) => new(result, null);

    /// <summary>
    /// Returns an error as additional information about what failed and why
    /// </summary>
    /// <param name="errorMessage"></param>
    /// <returns></returns>
    public static PipelineResult<T> Failure(string errorMessage) => new(null, errorMessage);

    private PipelineResult(T? result, string? errorMessage)
    {
        Result = result;
        ErrorMessage = errorMessage;
    }

    /// <summary>
    /// Result of the pipeline
    /// </summary>
    public T? Result { get; }

    /// <summary>
    /// Error message about why failure occurred
    /// </summary>
    public string? ErrorMessage { get; }
}
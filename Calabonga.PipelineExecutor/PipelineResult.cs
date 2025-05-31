namespace Calabonga.PipelineExecutor;

public class PipelineResult<T> where T : class
{
    public static PipelineResult<T> Success(T result) => new(result, null);

    public static PipelineResult<T> Failure(string errorMessage) => new(null, errorMessage);

    private PipelineResult(T? result, string? errorMessage)
    {
        Result = result;
        ErrorMessage = errorMessage;
    }

    public T? Result { get; }

    public string? ErrorMessage { get; }
}
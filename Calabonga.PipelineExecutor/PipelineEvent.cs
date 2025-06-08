using Microsoft.Extensions.Logging;

namespace Calabonga.PipelineExecutor;

/// <summary>
/// Pipeline event message
/// </summary>
public class PipelineEvent
{
    /// <summary>
    /// Step name where event happened
    /// </summary>
    public string? StepName { get; set; }

    /// <summary>
    /// Log level
    /// </summary>
    public LogLevel LogLevel { get; set; }

    /// <summary>
    /// Message about event
    /// </summary>
    public string Message { get; set; } = null!;
}
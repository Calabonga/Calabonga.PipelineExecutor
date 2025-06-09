using System.Text.Json;
using Microsoft.Extensions.Logging;

namespace Calabonga.PipelineExecutor.Demo;

public static class Printer
{
    public static void Print<T>(T result, ILogger logger)
    {
        var data = JsonSerializer.Serialize(result, new JsonSerializerOptions
        {
            WriteIndented = true
        });

        logger.LogInformation(data);
    }
}
using System.Text.Json;

namespace Calabonga.PipelineExecutor.Demo;

public static class Printer
{
    public static void Print<T>(T result)
    {
        var data = JsonSerializer.Serialize(result, new JsonSerializerOptions
        {
            WriteIndented = true
        });

        Console.WriteLine(data);
    }
}

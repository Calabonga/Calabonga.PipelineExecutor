using System.Text.Json;

namespace Calabonga.PipelineExecutor.Demo;

public static class Printer
{
    public static void Print(Image result)
    {
        var data = JsonSerializer.Serialize(result);

        Console.WriteLine(data);
    }
}

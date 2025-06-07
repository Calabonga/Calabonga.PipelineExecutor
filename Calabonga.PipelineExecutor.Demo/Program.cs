using Calabonga.PipelineExecutor;
using Calabonga.PipelineExecutor.Demo;
using Calabonga.PipelineExecutor.Demo.Steps;
using Microsoft.Extensions.DependencyInjection;

var container = ConsoleApp.CreateContainer(services =>
{
    // services.AddScoped<IPipelineContext<Image>, DefaultPipelineContext<Image>>();
    services.AddScoped<IPipelineContext<Image>, ImagePipelineContext>();
    services.AddScoped<PipelineExecutor<Image>>();
    services.AddScoped<IPipelineStep<Image>, ResizeStep>();
    services.AddScoped<IPipelineStep<Image>, UpdateNameStep>();
    services.AddScoped<IPipelineStep<Image>, UppercaseNameStep>();
});

var image = new Image();

var executor = container.GetRequiredService<PipelineExecutor<Image>>();


#region Old implementation
// var context = new PipelineContext<Image>(image);
// var executor = new PipelineExecutor<Image>(context);

// executor.AddStep(new ResizeStep());
// executor.AddStep(new UpdateNameStep());
// executor.AddStep(new UppercaseNameStep());
#endregion

var result = await executor.RunAsync(image, CancellationToken.None);

Printer.Print(result);

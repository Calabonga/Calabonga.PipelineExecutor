using Calabonga.PipelineExecutor;
using Calabonga.PipelineExecutor.Demo;
using Calabonga.PipelineExecutor.Demo.Steps;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

// initialize Dependency Container
var container = ConsoleApp.CreateContainer(services =>
{
    // Pipeline executor for Image processing
    services.AddScoped<PipelineExecutor<Image>>();

    // Pipeline executor default configuration for Image processing
    //services.AddScoped<IPipelineContext<Image>, DefaultPipelineContext<Image>>();
    services.AddScoped<IPipelineContext<Image>, ImagePipelineContext>();

    // Step 1 for pipeline executor processing 
    services.AddScoped<IPipelineStep<Image>, ResizeStep>();

    // Step 2 for pipeline executor processing 
    services.AddScoped<IPipelineStep<Image>, UpdateNameStep>();

    // Step 3 for pipeline executor processing 
    services.AddScoped<IPipelineStep<Image>, UppercaseNameStep>();

});

// create an entity for pipeline
var image = new Image();

// getting executor
var executor = container.GetRequiredService<PipelineExecutor<Image>>();

//adding manual step into executor
executor.AddStep(new ManualStep());

// execute pipeline 
var result = await executor.RunAsync(image, CancellationToken.None);

// logger 
var logger = container.GetRequiredService<ILogger<Program>>();

// output result
Printer.Print(result, logger);

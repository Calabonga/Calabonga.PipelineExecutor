using Calabonga.PipelineExecutor.Demo;
using Calabonga.PipelineExecutor.Demo.PipelineExecutors;
using Calabonga.PipelineExecutor.Demo.Steps;

var image = new Image();
var context = new PipelineContext(image);
var executor = new PipelineExecutor(context);

executor.AddStep(new ResizeStep());
executor.AddStep(new UpdateNameStep());
executor.AddStep(new UppercaseNameStep());

var result = executor.Run();


Printer.Print(result);

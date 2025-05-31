using Calabonga.PipelineExecutor;
using Calabonga.PipelineExecutor.Demo;

var image = new Image();
var context = new PipelineContext<Image>(image);
var executor = new PipelineExecutor<Image>(context);

// executor.AddStep(new ResizeStep());
// executor.AddStep(new UpdateNameStep());
// executor.AddStep(new UppercaseNameStep());

var result = executor.Run();


Printer.Print(result);

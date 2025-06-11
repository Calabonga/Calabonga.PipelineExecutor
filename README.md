# Calabonga.PipelineExecutor
Pipeline pattern implementation. Simple process executor with step-by-step pipeline execution You can use a [Calabonga.PipelineExecutor](https://www.nuget.org/packages/Calabonga.PipelineExecutor/) as a nuget-package for your application.

```powershell
dotnet add package Calabonga.PipelineExecutor
```

## How to use

1. You should have a object (class) for pipeline processing. Something like this:

```csharp
public class Image
{
    public string Name { get; set; } = null!;

    public double Height { get; set; }

    public double Width { get; set; }
}
```

2. Than you need create a steps for pipeline executor. This is a example for one of them (pay attention to base class of the `ResizeStep`, this is important):

```csharp
public class ResizeStep : PipelineStep<Image>
{
    public override int OrderIndex => 2;

    public override Task<StepResult> ExecuteAsync(
        Image item,
        IPipelineContext<Image> context,
        ILogger<PipelineExecutor<Image>> logger,
        CancellationToken cancellationToken)
    {
        item.Height = 100;
        item.Width = 100;

        logger.LogInformation("[PIPELINE] Resize done 100 x 100");

        return Task.FromResult(StepResult.Success());
    }
}
```

3. Make sure dependencies registered in your Dependency Container;

```csharp
// Pipeline executor for Image processing
services.AddScoped<PipelineExecutor<Image>>();

// Pipeline executor default configuration for Image processing
services.AddScoped<IPipelineContext<Image>, DefaultPipelineContext<Image>>();

// Step 1 for pipeline executor processing 
services.AddScoped<IPipelineStep<Image>, ResizeStep>();

// Step 2 for pipeline executor processing 
services.AddScoped<IPipelineStep<Image>, UpdateNameStep>();

// Step 3 for pipeline executor processing 
services.AddScoped<IPipelineStep<Image>, UppercaseNameStep>();
```

4. Custom configuration can be used:

```csharp
/// <summary>
/// Custom configuration for <see cref="PipelineExecutor{T}"/>
/// with some additional parameters
/// </summary>
public class ImagePipelineContext : IPipelineContext<Image>
{
    public ImagePipelineContext(IOptions<AppSettings> settings)
    {
        Name = settings.Value.Name ?? "ImageFromPipeline.png";
    }

    public string Name { get; }

    public AdditionalStepStrategy AdditionalStepStrategy => AdditionalStepStrategy.Append;

    public FailedStepStrategy FailedStepStrategy => FailedStepStrategy.NotStopPipeline;
}
```

If you want to use custom configuration, then you should replace registration in DI-container. Something like that:
```csharp
// Pipeline executor default configuration for Image processing
//services.AddScoped<IPipelineContext<Image>, DefaultPipelineContext<Image>>();
services.AddScoped<IPipelineContext<Image>, ImagePipelineContext>();
```


## History

### 1.0.0-beta.1

* First release.

## Screenshots

### Console app result shown
![image](https://github.com/user-attachments/assets/28852d02-c425-414c-8e39-112d02a1aed8)

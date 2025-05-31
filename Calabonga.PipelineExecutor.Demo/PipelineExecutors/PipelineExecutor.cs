using Calabonga.PipelineExecutor.Demo;
using Calabonga.PipelineExecutor.Demo.PipelineExecutors;

public class PipelineExecutor
{
    private readonly PipelineContext _context;
    private readonly List<IPipelineStep> _steps = [];

    public PipelineExecutor(PipelineContext context)
    {
        _context = context;
    }

    public void AddStep(IPipelineStep step)
    {
        _steps.Add(step);
    }

    public Image Run()
    {
        if (!_steps.Any())
        {
            throw new NotImplementedException();
        }

        foreach (var step in _steps)
        {
            step.Execute(_context);
        }

        return _context.Image;
    }
}

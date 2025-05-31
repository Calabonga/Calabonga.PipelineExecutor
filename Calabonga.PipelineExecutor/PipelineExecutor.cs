namespace Calabonga.PipelineExecutor;

public class PipelineExecutor<T> where T : class
{
    private readonly PipelineContext<T> _context;
    private readonly List<IPipelineStep<T>> _steps = [];

    public PipelineExecutor(PipelineContext<T> context)
    {
        _context = context;
    }

    public void AddStep(IPipelineStep<T> step)
    {
        _steps.Add(step);
    }

    public PipelineResult<T> Run()
    {
        if (!_steps.Any())
        {
            return PipelineResult<T>.Failure(errorMessage: "Sorry. No steps provided.");
        }

        foreach (var step in _steps)
        {
            step.Execute(_context);
        }

        return PipelineResult<T>.Success(_context.Item);
    }
}
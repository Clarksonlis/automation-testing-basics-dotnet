using ObjectOrientedDesignPrinciples_Task;

public class ExitCommand : ICommand
{

    private readonly CarManager _carManager;

    public ExitCommand(CarManager manager)
    {
        _carManager = manager;
    }

    public void Execute()
    {
        Console.WriteLine("Exiting program...");
        Environment.Exit(0);
    }
}

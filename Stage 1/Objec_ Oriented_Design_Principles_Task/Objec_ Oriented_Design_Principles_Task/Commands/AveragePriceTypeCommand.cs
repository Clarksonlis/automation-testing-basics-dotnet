using ObjectOrientedDesignPrinciples_Task;

public class AveragePriceTypeCommand : ICommand
{
    private readonly CarManager _carManager;

    public AveragePriceTypeCommand(CarManager carManager)
    {
        _carManager = carManager;
    }

    public void Execute()
    {
        Console.Write("Enter the car brand to get the average price: ");
        var brand = Console.ReadLine();
        _carManager.GetAveragePriceType(brand);
    }
}

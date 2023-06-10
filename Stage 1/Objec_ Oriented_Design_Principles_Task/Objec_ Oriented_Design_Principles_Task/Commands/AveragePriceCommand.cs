using System;

namespace ObjectOrientedDesignPrinciples_Task
{
    public class AveragePriceCommand : ICommand
    {
        private readonly CarManager _carManager;

        public AveragePriceCommand(CarManager carManager)
        {
            _carManager = carManager;
        }

        public void Execute()
        {
            _carManager.GetAveragePrice();
        }
    }
}

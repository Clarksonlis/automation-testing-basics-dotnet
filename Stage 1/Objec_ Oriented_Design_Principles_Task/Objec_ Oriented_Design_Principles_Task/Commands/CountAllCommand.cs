using System;

namespace ObjectOrientedDesignPrinciples_Task.Commands
{
    public class CountAllCommand : ICommand
    {

        private readonly CarManager _carManager;

        public CountAllCommand(CarManager carManager)
        {
            _carManager = carManager;
        }

        public void Execute()
        {
            _carManager.CountAll();
        }
    }
}

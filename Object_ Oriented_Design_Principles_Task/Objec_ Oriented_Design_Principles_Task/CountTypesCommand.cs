using System;

namespace ObjectOrientedDesignPrinciples_Task
{
    class CountTypesCommand : ICommand
    {

        private readonly CarManager _carManager;

        public CountTypesCommand(CarManager carManager)
        {
            _carManager = carManager;
        }

        public void Execute()
        {
             _carManager.CountTypes();
        }
    }
}

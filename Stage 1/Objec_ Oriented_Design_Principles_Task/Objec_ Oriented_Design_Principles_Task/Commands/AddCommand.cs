using System;
namespace ObjectOrientedDesignPrinciples_Task.Commands
{

    public class AddCommand : ICommand
	{
        private CarManager _manager;

        public AddCommand(CarManager manager)
		{
            _manager = manager;
		}

        public void Execute()
        {
            Car car = new Car();

            Console.WriteLine("Enter car information: brand, model, quantity, cost");

            Console.WriteLine("Enter brand:");
            car.Brand = Console.ReadLine();

            Console.WriteLine("Enter model:");
            car.Model = Console.ReadLine();

            Console.WriteLine("Enter quantity:");
            string quantityInput = Console.ReadLine();
            car.Quantity = int.Parse(quantityInput);

            Console.WriteLine("Enter cost:");
            string costInput = Console.ReadLine();
            car.Cost = decimal.Parse(costInput);

            _manager.AddCar(car);
        }
    }
}


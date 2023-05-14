using System;
using System.Reflection;

namespace ObjectOrientedDesignPrinciples_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager manager = CarManager.GetInstance();
            while (true)
            {
                Console.WriteLine("Enter car information: brand, model, quantity, cost");
                Console.WriteLine("Or enter command (count types, count all, average price, average price type, exit)");

                string input = Console.ReadLine();
                ICommand commandObject = CommandFactory.CreateCommand(input, manager);
                if (commandObject != null)
                {
                    commandObject.Execute();
                    if (commandObject is ExitCommand)
                    {
                        break;
                    }
                }

                string[] carInfo = input.Split(", ");
                if (carInfo.Length == 4)
                {
                    string brand = carInfo[0];
                    string model = carInfo[1];
                    int quantity = int.Parse(carInfo[2]);
                    decimal cost = decimal.Parse(carInfo[3]);
                    Car car = new Car() { Brand = brand, Model = model, Quantity = quantity, Cost = cost };
                    manager.AddCar(brand, model, quantity, cost);
                }
            }
        }
    }
}

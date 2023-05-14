using System;

namespace ObjectOrientedDesignPrinciples_Task
{
    public class CarManager
    {
        private readonly CarInventory inventory;
        private static  CarManager carManager;
        private CarManager()
        {
            inventory = new CarInventory();
        }

        public static CarManager GetInstance()
        {
            if(carManager == null)
            {
                carManager = new CarManager();
            }
            return carManager;
        }

        public void AddCar(string brand, string model, int quantity, decimal cost)
        {
            for (int i = 0; i < quantity; i++)
            {
                inventory.AddCar(new Car { Brand = brand, Model = model, Cost = cost });
            }
        }

        public void CountAll()
        {
            Console.WriteLine($"Total number of cars: {inventory.CountAll()}");
        }

        public void CountTypes()
        {
            Console.WriteLine($"Number of car brands: {inventory.CountTypes()}");
        }

        public void GetAveragePrice()
        {
            Console.WriteLine($"Average car price: {inventory.GetAveragePrice():C}");
        }

        public void GetAveragePriceType(string brand)
        {
            decimal avgPrice = inventory.GetAveragePriceType(brand);

            if (avgPrice == 0)
            {
                Console.WriteLine($"No cars found for brand '{brand}'");
            }
            else
            {
                Console.WriteLine($"Average price for {brand}: {avgPrice:C}");
            }
        }
    }
}

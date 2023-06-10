using System.Collections.Generic;

namespace ObjectOrientedDesignPrinciples_Task
{
    public class CarInventory
    {
        private readonly Dictionary<string, List<Car>> inventory;

        public CarInventory()
        {
            inventory = new Dictionary<string, List<Car>>();
        }

        public void AddCar(Car car)
        {
            if (inventory.ContainsKey(car.Brand))
            {
                inventory[car.Brand].Add(car);
            }
            else
            {
                inventory.Add(car.Brand, new List<Car> { car });
            }
        }

        public int CountAll()
        {
            int count = 0;

            foreach (var carList in inventory.Values)
            {
                foreach (Car car in carList)
                {
                    count += car.Quantity;
                }
            }

            return count;
        }

        public int CountTypes()
        {
            return inventory.Count;
        }

        public decimal GetAveragePrice()
        {
            if (CountAll() == 0)
            {
                return 0;
            }

            decimal totalCost = 0;

            foreach (var carList in inventory.Values)
            {
                foreach (var car in carList)
                {
                    totalCost += car.Cost;
                }
            }

            return totalCost / CountAll();
        }

        public decimal GetAveragePriceType(string brand)
        {
            if (!inventory.ContainsKey(brand) || inventory[brand].Count == 0)
            {
                return 0;
            }

            decimal totalCost = 0;

            foreach (var car in inventory[brand])
            {
                totalCost += car.Cost;
            }

            return totalCost / inventory[brand].Count;
        }
    }
}

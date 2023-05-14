using System;
namespace OOP_Task
{
	public class Transmission
	{

        public string type;
        public int numberOfGears;
        public string manufacturer;

        public Transmission(string transmissionType, int transmissionNumberOfGears, string transmissionManufacturer)
        {
            type = transmissionType;
            numberOfGears = transmissionNumberOfGears;
            manufacturer = transmissionManufacturer;
        }
    }
}


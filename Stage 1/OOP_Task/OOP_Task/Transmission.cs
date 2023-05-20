using System;

namespace OOP_Task
{
    public class Transmission
    {
        // Type of the transmission
        public string type;
        // Number of gears in the transmission
        public int numberOfGears;
        // Manufacturer of the transmission
        public string manufacturer;

        public Transmission(string transmissionType, int transmissionNumberOfGears, string transmissionManufacturer)
        {
            type = transmissionType;
            numberOfGears = transmissionNumberOfGears;
            manufacturer = transmissionManufacturer;
        }
    }
}
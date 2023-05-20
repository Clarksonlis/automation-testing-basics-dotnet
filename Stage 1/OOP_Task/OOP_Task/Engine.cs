using System;

namespace OOP_Task
{
    public class Engine
    {
        // Power of the engine
        public string power;
        // Volume of the engine
        public double volume;
        // Type of the engine
        public string type;
        // Serial number of the engine
        public string serialNumber;

        public Engine(string entityPower, double entityVolume, string entityType, string entitySerialNumber)
        {
            power = entityPower;
            volume = entityVolume;
            type = entityType;
            serialNumber = entitySerialNumber;
        }
    }
}
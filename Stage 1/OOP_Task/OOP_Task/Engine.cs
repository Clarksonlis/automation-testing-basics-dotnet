using System;

namespace OOP_Task
{
	public class Engine
	{
        public string power;
        public double volume;
        public string type;
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
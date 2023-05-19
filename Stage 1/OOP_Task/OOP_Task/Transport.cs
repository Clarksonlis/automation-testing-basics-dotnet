using System;

namespace OOP_Task
{
	public class Transport
	{
        public Engine engine;
        public Chassis chassis;
        public Transmission transmission;

        public virtual void characteristic()
        {
            Console.WriteLine($"\n" +
               $"Engine: power = {engine.power}, volume = {engine.volume}, type = {engine.type}, serial number = {engine.serialNumber} \n" +
               $"Chassis: wheels number = {chassis.wheelsNumber}, number = {chassis.number} , permissible load = {chassis.permissibleLoad} \n" +
               $"Transmission : type = {transmission.type}, number of gears = {transmission.numberOfGears}, manufacturer = {transmission.manufacturer} \n" +
               $"\n");
        }
    }
}


using System;

namespace OOP_Task
{
    public class Transport
    {
        // Engine instance
        public Engine engine;
        // Chassis instance
        public Chassis chassis;
        // Transmission instance
        public Transmission transmission;

        // Output complete information about the transport
        public virtual void characteristic()
        {
            Console.WriteLine($"\n" +
               $"Engine: power = {engine.power}, volume = {engine.volume}, type = {engine.type}, serial number = {engine.serialNumber} \n" +
               $"Chassis: wheels number = {chassis.wheelsNumber}, number = {chassis.number}, permissible load = {chassis.permissibleLoad} \n" +
               $"Transmission: type = {transmission.type}, number of gears = {transmission.numberOfGears}, manufacturer = {transmission.manufacturer} \n" +
               $"\n");
        }
    }
}
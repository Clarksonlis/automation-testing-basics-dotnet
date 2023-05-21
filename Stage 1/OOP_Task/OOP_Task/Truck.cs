using System;

namespace OOP_Task
{
    public class Truck : Transport
    {
        public Truck()
        {
            // Create an instance of Engine, Chassis, and Transmission with specific values for a truck
            engine = new Engine("600 hp", 6.5, "diesel", "OS51279");
            chassis = new Chassis(18, "4S3BMHB63286050", "1400 kg");
            transmission = new Transmission("MT", 10, "Eaton Corporation plc");
        }

        public override void Characteristic()
        {
            Console.WriteLine("Truck: ");
            base.Characteristic();
        }
    }
}
using System;

namespace OOP_Task
{
    public class Truck : Transport
    {
        public Truck()
        {
            engine = new Engine("600 hp", 6.5, "diesel", "OS51279");
            chassis = new Chassis(18, "4S3BMHB63286050", "1400 kg");
            transmission = new Transmission("MT", 10, "Eaton Corporation plc");
        }

        public override void characteristic()
        {
            Console.WriteLine("Truck: ");
            base.characteristic();
        }
    }
}
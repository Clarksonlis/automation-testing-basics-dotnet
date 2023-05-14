using System;
namespace OOP_Task
{
    public class Scooter : Transport
    {
        public Scooter()
        {
            engine = new Engine("400 W", 0.15, "gasoline", "PK51429");
            chassis = new Chassis(2, "4S3BMHB63286050", "120 kg");
            transmission = new Transmission("CVT", 1, "Tarushi Tech Private Limited");
        }

        public override void characteristic()
        {
            Console.WriteLine("Scooter: ");
            base.characteristic();
        }
    }
}


using System;
namespace OOP_Task
{
    public class Bus : Transport
    {
        public Bus()
        {
            engine = new Engine("450 hp", 10, "diesel", "DM65779");
            chassis = new Chassis(6, "4S3BMHB63286050", "60 people");
            transmission = new Transmission("ATS", 5, "Allison Transmission");
        }

        public override void characteristic()
        {
            Console.WriteLine("Bus: ");
            base.characteristic();
        }
    }
}
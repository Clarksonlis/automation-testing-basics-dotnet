using System;

namespace OOP_Task
{
    public class PassengerCar : Transport
    {
        public PassengerCar()
        {
            // Create an instance of Engine, Chassis, and Transmission with specific values for a passenger car
            engine = new Engine("180 hp", 2.5, "internal combustion", "MN97278");
            chassis = new Chassis(4, "4S3BMHB63286050", "600 kg");
            transmission = new Transmission("AMT", 6, "American Axle & Manufacturing Holdings");
        }

        public override void characteristic()
        {
            Console.WriteLine("Passenger car: ");
            base.characteristic();
        }
    }
}
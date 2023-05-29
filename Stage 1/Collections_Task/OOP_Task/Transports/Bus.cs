public class Bus : Transport
{
    public int PassengerNumber { get; set; }

    public Bus(Engine engine, Chassis chassis, Transmission transmission, int passengerNumber)
         : base(engine, chassis, transmission)
    {
        PassengerNumber = passengerNumber;
    }
}

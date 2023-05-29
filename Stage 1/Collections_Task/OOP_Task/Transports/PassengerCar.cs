public class PassengerCar : Transport
{
    public int Seats { get; set; }

    public PassengerCar(Engine engine, Chassis chassis, Transmission transmission, int seats)
         : base(engine, chassis, transmission)
    {
        Seats = seats;
    }
}

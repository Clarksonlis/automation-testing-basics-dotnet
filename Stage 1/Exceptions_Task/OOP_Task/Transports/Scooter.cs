public class Scooter : Transport
{
    public int DrivingAge { get; set; }

    public Scooter(Engine engine, Chassis chassis, Transmission transmission, int drivingAge)
        : base(engine, chassis, transmission)
    {
        DrivingAge = drivingAge;
    }
}
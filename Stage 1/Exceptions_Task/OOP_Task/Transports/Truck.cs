public class Truck : Transport
{
    public double LoadWeight { get; set; }

    public Truck(Engine engine, Chassis chassis, Transmission transmission, double loadWeight)
        : base(engine, chassis, transmission)
    {
        LoadWeight = loadWeight;
    }
}
public class Transport
{
    public Engine Engine { get; set; }
    public Chassis Chassis { get; set; }
    public Transmission Transmission { get; set; }

    public Transport(Engine engine, Chassis chassis, Transmission transmission)
    {
        Engine = engine;
        Chassis = chassis;
        Transmission = transmission;
    }

    public virtual void Characteristic()
    {
        Console.WriteLine($"Engine: Power - {Engine.Power}, Volume - {Engine.Volume}, Type - {Engine.Type}, Serial Number - {Engine.SerialNumber}");
        Console.WriteLine($"Chassis: Type - {Chassis.Type}, Serial Number - {Chassis.SerialNumber}, Capacity - {Chassis.Capacity}");
        Console.WriteLine($"Transmission: type = {Transmission.Type}, number of gears = {Transmission.NumberOfGears}, manufacturer = {Transmission.Manufacturer}");
    }
}
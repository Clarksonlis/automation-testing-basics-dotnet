using System.Diagnostics.Metrics;

public class Transport
{
    private static int counter = 0;
    public int Id { get; set; } // Добавлено свойство Id

    public Engine Engine { get; set; }
    public Chassis Chassis { get; set; }
    public Transmission Transmission { get; set; }

    public Transport(Engine engine, Chassis chassis, Transmission transmission)
    {
        Id = counter++;
        Engine = engine;
        Chassis = chassis;
        Transmission = transmission;
    }

    public virtual void Characteristic()
    {
        Console.WriteLine($"Engine: Power - {Engine.Power}, Volume - {Engine.Volume}, Type - {Engine.Type}, Serial Number - {Engine.SerialNumber}");
        Console.WriteLine($"Chassis: Type - {Chassis.Type}, Serial Number - {Chassis.SerialNumber}, Capacity - {Chassis.Capacity}");
        Console.WriteLine($"Transmission: Type - {Transmission.Type}, Number of gears - {Transmission.NumberOfGears}, Manufacturer - {Transmission.Manufacturer}");
    }
}
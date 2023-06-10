public class Transmission
{
    public string Type { get; set; }
    public int NumberOfGears { get; set; }
    public string Manufacturer { get; set; }

    public Transmission(string type, int numberOfGears, string manufacturer)
    {
        Type = type;
        NumberOfGears = numberOfGears;
        Manufacturer = manufacturer;
    }
}
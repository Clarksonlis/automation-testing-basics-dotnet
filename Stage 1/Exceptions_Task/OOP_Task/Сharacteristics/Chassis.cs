public class Chassis
{
    public string Type { get; set; }
    public string SerialNumber { get; set; }
    public double Capacity { get; set; }

    public Chassis(string type, string serialNumber, double capacity)
    {
        Type = type;
        SerialNumber = serialNumber;
        Capacity = capacity;
    }
}
using OOP_Task;

class Program
{
    static void Main(string[] args)
    {
        // Create instances of different types of vehicles
        Transport myPassengerCar = new PassengerCar();
        Transport myTruck = new Truck();
        Transport myBus = new Bus();
        Transport myScooter = new Scooter();

        // Output complete information about the objects
        myPassengerCar.characteristic();
        myTruck.characteristic();
        myBus.characteristic();
        myScooter.characteristic();
    }
}
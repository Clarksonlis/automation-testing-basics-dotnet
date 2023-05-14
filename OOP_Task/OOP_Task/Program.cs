using OOP_Task;

class Program
{
    
    static void Main(string[] args)
    {

        //принцип абстракции
      
        Transport myPassengerCar = new PassengerCar();
        Transport myTruck = new Truck();
        Transport myBus = new Bus();
        Transport myScooter = new Scooter();

        myPassengerCar.characteristic();
        myTruck.characteristic();
        myBus.characteristic();
        myScooter.characteristic();


    }

}


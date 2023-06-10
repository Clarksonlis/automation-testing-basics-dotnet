using System;
using OOP_Task.Exceptions;

namespace OOP_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                List <Transport> autos = new List<Transport>();
                AutoCollection autoCollection = new AutoCollection(autos);

                autoCollection.InitializeAutos();

                autoCollection.PrintAutoCollection();

                Console.WriteLine("Adding a new car model...");
                autoCollection.AddAuto(new PassengerCar(new Engine("200 HP", 2.0, "Gasoline", "54321"),
                                                        new Chassis("SUV", "98765", 5),
                                                        new Transmission("CVT", 8, "ABC Manufacturer"),
                                                        5));

                autoCollection.PrintAutoCollection();

                Console.WriteLine("Getting an auto by parameter...");
                Console.WriteLine("Choose characteristic: Engine, Chassis, Transmission");
                string parameter = Console.ReadLine();
                Console.WriteLine("Write value of parameter:");
                string value = Console.ReadLine();
                autoCollection.GetAutoByParameter(parameter, value);

                Console.WriteLine("Updating an auto by ID...");
                Console.WriteLine("Input auto's ID:");
                string idInput = (Console.ReadLine());
                int id = int.Parse(idInput);
                Transport transport = new PassengerCar (new Engine("200 HP", 2.0, "Gasoline", "54321"),
                                        new Chassis("SUV", "98765", 5),
                                        new Transmission("CVT", 8, "ABC Manufacturer"),
                                        5);
                autoCollection.UpdateAuto(id, transport);

                Console.WriteLine("Removing an auto by ID...");
                Console.WriteLine("Input auto's ID:");
                idInput = (Console.ReadLine());
                id = int.Parse(idInput);
                autoCollection.RemoveAuto(id);
            }

            catch (InitializationException ex)
            {
                Console.WriteLine($"InitializationException: {ex.Message}");
            }
            catch (RemoveAutoException ex)
            {
                Console.WriteLine($"RemoveAutoException: {ex.Message}");
            }
            catch (UpdateAutoException ex)
            {
                Console.WriteLine($"UpdateAutoException: {ex.Message}");
            }

            catch (GetAutoByParameterException ex)
            {
                Console.WriteLine($"GetAutoByParameterException: {ex.Message}");
            }
            catch (AddException ex)
            {
                Console.WriteLine($"AddException: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
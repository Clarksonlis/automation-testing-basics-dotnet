using System;
using System.Collections.Generic;
using OOP_Task.Exceptions;

namespace OOP_Task
{
    public class AutoCollection
    {
        private List<Transport> _autos;

        public AutoCollection(List<Transport> autos)
        {
            _autos = autos;
        }

        public void InitializeAutos()
        {
            if(_autos == null)
            {
                throw new InitializationException("Unable to initialize the collection!");
            }

            Engine engine1 = new Engine("150 HP", 1.5, "Gasoline", "12345");
            Chassis chassis1 = new Chassis("Sedan", "67890", 5);
            Transmission transmission1 = new Transmission("AMT", 6, "American Axle & Manufacturing Holdings");
            PassengerCar passengerCar = new PassengerCar(engine1, chassis1, transmission1, 5);
            _autos.Add(passengerCar);

            Engine engine2 = new Engine("400 HP", 3.0, "Diesel", "54321");
            Chassis chassis2 = new Chassis("Truck", "09876", 10);
            Transmission transmission2 = new Transmission("MT", 10, "Eaton Corporation plc");
            Truck truck = new Truck (engine2, chassis2, transmission2, 10);
            _autos.Add(truck);

            Engine engine3 = new Engine("250 HP", 2.0, "Gasoline", "13579");
            Chassis chassis3 = new Chassis("Bus", "24680", 20);
            Transmission transmission3 = new Transmission("ATS", 5, "Allison Transmission");
            Bus bus = new Bus(engine3, chassis3, transmission3, 20);
            _autos.Add(bus);

            Engine engine4 = new Engine("10 HP", 0.1, "Gasoline", "97531");
            Chassis chassis4 = new Chassis("Scooter", "86420", 1);
            Transmission transmission4 = new Transmission("CVT", 1, "Tarushi Tech Private Limited");
            Scooter scooter = new Scooter(engine4, chassis4, transmission4, 16);
            _autos.Add(scooter);
        }


        public void PrintAutoCollection()
        {
            Console.WriteLine("Auto Collection:");
            foreach (var auto in _autos)
            {
                Console.WriteLine($"ID: {auto.Id}");
                Console.WriteLine($"Engine: Power - {auto.Engine.Power}, Volume - {auto.Engine.Volume}, Type - {auto.Engine.Type}, Serial Number - {auto.Engine.SerialNumber}");
                Console.WriteLine($"Chassis: Type - {auto.Chassis.Type}, Serial Number - {auto.Chassis.SerialNumber}, Capacity - {auto.Chassis.Capacity}");
                Console.WriteLine($"Transmission: Type - {auto.Transmission.Type}, Number of gears - {auto.Transmission.NumberOfGears}, Manufacturer - {auto.Transmission.Manufacturer}");
                Console.WriteLine();
            }
        }

        public void AddAuto(Transport auto)
        {
            if (auto == null || _autos == null)
            {
                throw new AddException("Unable to add an auto!");
            }
            _autos.Add(auto);
        }

        public List<Transport> GetAutoByParameter(string parameter, string value)
        {
            List<Transport> autosWithParameter = new List<Transport>();

            switch (parameter)
            {
                case "Engine":
                    {
                        autosWithParameter = _autos.Where(a => a.Engine.SerialNumber == value).ToList();
                        break;
                    }
                case "Chassis":
                    {
                        autosWithParameter = _autos.Where(a => a.Chassis.SerialNumber == value).ToList();
                        break;
                    }
                case "Transmission":
                    {
                        autosWithParameter = _autos.Where(a => a.Transmission.Type == value).ToList();
                        break;
                    }

                default:
                    throw new GetAutoByParameterException("The parameter doesn't exist.");
            }

            if (!autosWithParameter.Any())
            {
                throw new GetAutoByParameterException("Can't find the auto by parameter.");
            }

            return autosWithParameter;
        }

        public void UpdateAuto(int id, Transport transport)
        {
            RemoveAuto(id);
            AddAuto(transport);
        }

        public void RemoveAuto(int id)
        {
            Transport oldTransport = _autos.FirstOrDefault(a => a.Id == id);

            if (oldTransport == null)
            {
                throw new RemoveAutoException("Can't find an auto by this Id.");
            }

            _autos.Remove(oldTransport);
        }

    }
}
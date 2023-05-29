using System;
using System.Collections.Generic;
using System.Xml.Linq;

public class Program
{
    static void Main(string[] args)
    {
        List<Transport> vehicles = new List<Transport>();

        var PassengerCarEngine = new Engine("150 HP", 1.5, "Gasoline", "12345");
        var PassengerCarChassis = new Chassis("Sedan", "67890", 5);
        var PassengerCarTransmission = new Transmission("AMT", 6, "American Axle & Manufacturing Holdings");

        var TruckEngine = new Engine("400 HP", 3.0, "Diesel", "54321");
        var TruckChassis = new Chassis("Truck", "09876", 10);
        var TruckTransmission = new Transmission("MT", 10, "Eaton Corporation plc");

        var BusEngine = new Engine("250 HP", 2.0, "Gasoline", "13579");
        var BusChassis = new Chassis("Bus", "24680", 20);
        var BusTransmission = new Transmission("ATS", 5, "Allison Transmission");

        var ScooterEngine = new Engine("10 HP", 0.1, "Gasoline", "97531");
        var ScooterChassis = new Chassis("Scooter", "86420", 1);
        var ScooterTransmission = new Transmission("CVT", 1, "Tarushi Tech Private Limited");

        vehicles.Add(new PassengerCar(PassengerCarEngine, PassengerCarChassis, PassengerCarTransmission, 6));
        vehicles.Add(new Truck(TruckEngine, TruckChassis, TruckTransmission, 2000));
        vehicles.Add(new Bus(BusEngine, BusChassis, BusTransmission, 30));
        vehicles.Add(new Scooter(ScooterEngine, ScooterChassis, ScooterTransmission, 18));

        XElement engineVolumeXml = new XElement("EngineVolume",
            from vehicle in vehicles
            let engine = vehicle.Engine
            where engine.Volume > 1.5
            select new XElement("Vehicle",
                new XAttribute("Power", engine.Power),
                new XAttribute("Volume", engine.Volume),
                new XAttribute("Type", engine.Type),
                new XAttribute("SerialNumber", engine.SerialNumber)
            )
        );

        XElement busTruckXml = new XElement("BusTruck",
            from vehicle in vehicles
            where vehicle is Bus || vehicle is Truck
            select new XElement("Vehicle",
                new XElement("Engine",
                    new XAttribute("Type", vehicle.Engine.Type),
                    new XAttribute("SerialNumber", vehicle.Engine.SerialNumber),
                    new XAttribute("Power", vehicle.Engine.Power)
                )
            )
        );

        XElement groupedByTransmissionXml = new XElement("GroupedByTransmission",
            from vehicle in vehicles
            group vehicle by vehicle.Transmission.Type into transmissionGroup
            select new XElement("Group",
                new XAttribute("TransmissionType", transmissionGroup.Key),
                from v in transmissionGroup
                select new XElement("Vehicle",
                    new XElement("Engine",
                        new XAttribute("Power", v.Engine.Power),
                        new XAttribute("Volume", v.Engine.Volume),
                        new XAttribute("Type", v.Engine.Type),
                        new XAttribute("SerialNumber", v.Engine.SerialNumber)
                    ),
                    new XElement("Chassis",
                        new XAttribute("Type", v.Chassis.Type),
                        new XAttribute("SerialNumber", v.Chassis.SerialNumber),
                        new XAttribute("Capacity", v.Chassis.Capacity)
                    ),
                    new XElement("Transmission",
                        new XAttribute("Type", v.Transmission.Type),
                        new XAttribute("NumberOfGears", v.Transmission.NumberOfGears),
                        new XAttribute("Manufacturer", v.Transmission.Manufacturer)
                    )
                )
            )
        );

        engineVolumeXml.Save("EngineVolume.xml");
        busTruckXml.Save("BusTruck.xml");
        groupedByTransmissionXml.Save("GroupedByTransmission.xml");

        Console.WriteLine("XML files created successfully.");
    }
}
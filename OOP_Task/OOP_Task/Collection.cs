using System;
using System.Collections.Generic;
using System.Numerics;
using System.Linq;
using System.Xml.Linq;


namespace OOP_Task
{
    public class Collection
	{
		public Collection()
		{
            List<Transport> transports = new List<Transport>()
            {

                new Truck()
                {
                    engine = new Engine("600 hp", 6.5, "diesel", "OS51279"),
                    chassis = new Chassis(18, "4S3BMHB63286050", "1400 kg"),
                    transmission = new Transmission("MT", 10, "Eaton Corporation plc"),

        },

                new PassengerCar()
                {
                    engine = new Engine("180 hp", 2.5, "internal combustion", "MN97278"),
                    chassis = new Chassis(4, "4S3BMHB63286050", "600 kg"),
                    transmission = new Transmission("AMT", 6, "American Axle & Manufacturing Holdings"),
        },

               new Bus()
                {
                    engine = new Engine("450 hp", 10, "diesel", "DM65779"),
                    chassis = new Chassis(6, "4S3BMHB63286050", "60 people"),
                    transmission = new Transmission("ATS", 5, "Allison Transmission"),
        },

                new Scooter()
                {
                    engine = new Engine("400 W", 0.15, "gasoline", "PK51429"),
                    chassis = new Chassis(2, "4S3BMHB63286050", "120 kg"),
                    transmission = new Transmission("CVT", 1, "Tarushi Tech Private Limited")
        }



    };




        // Get all vehicles with engine capacity > 1.5 liters
        var vehiclesWithBigEngines = from t in transports
                                         where t.engine.volume > 1.5
                                         select t;

            // Write information to XML file
            XDocument bigEngineDoc = new XDocument(
                new XElement("vehicles",
                    from v in vehiclesWithBigEngines
                    select new XElement("vehicle",
                        new XAttribute("type", v.GetType().Name),
                        new XElement("engine",
                            new XAttribute("type", v.engine.type),
                            new XAttribute("serialNumber", v.engine.serialNumber),
                            new XAttribute("power", v.engine.power)),
                        new XElement("chassis",
                            new XAttribute("wheelsNumber", v.chassis.wheelsNumber),
                            new XAttribute("number", v.chassis.number),
                            new XAttribute("permissibleLoad", v.chassis.permissibleLoad)),
                        new XElement("transmission",
                            new XAttribute("type", v.transmission.type),
                            new XAttribute("numberOfGears", v.transmission.numberOfGears),
                            new XAttribute("manufacturer", v.transmission.manufacturer))
                    )
                )
            );



            bigEngineDoc.Save("big_engine_vehicles.xml");

            // Get engine type, serial number and power rating for all buses and trucks
            var busAndTruckEngines = from t in transports
                                     where t is Bus || t is Truck
                                     select new
                                     {
                                         EngineType = t.engine.type,
                                         SerialNumber = t.engine.serialNumber,
                                         Power = t.engine.power,
                                     };

            // Write information to XML file
            XDocument busAndTruckEnginesDoc = new XDocument(
                new XElement("engines",
                    from e in busAndTruckEngines
                    select new XElement("engine",
                        new XAttribute("type", e.EngineType),
                        new XAttribute("serialNumber", e.SerialNumber),
                        new XAttribute("power", e.Power))
                )
            );

            busAndTruckEnginesDoc.Save("bus_and_truck_engines.xml");

            // Group vehicles by transmission type
            var vehiclesByTransmission = from t in transports
                                         group t by t.transmission.type into g
                                         select new
                                         {
                                             TransmissionType = g.Key,
                                             Vehicles = g.ToList()
                                         };

            // Write information to XML file
            XDocument vehiclesByTransmissionDoc = new XDocument(
                new XElement("vehicles",
                    from t in vehiclesByTransmission
                    select new XElement("transmission",
                        new XAttribute("type", t.TransmissionType),
                        from v in t.Vehicles
                        select new XElement("vehicle",
                            new XAttribute("type", v.GetType().Name),
                            new XElement("engine",
                                new XAttribute("type", v.engine.type),
                                new XAttribute("serialNumber", v.engine.serialNumber),
                                new XAttribute("powerRating", v.engine.power)),
                            new XElement("chassis",
                                new XAttribute("numberOfWheels", v.chassis.wheelsNumber),
                                new XAttribute("number", v.chassis.number),
                                new XAttribute("permissibleLoad", v.chassis.permissibleLoad)),
                            new XElement("transmission",
                                new XAttribute("type", v.transmission.type),
                                new XAttribute("numberOfGears", v.transmission.numberOfGears),
                                new XAttribute("manufacturer", v.transmission.manufacturer))
                        )
                    )
                )
            );

            vehiclesByTransmissionDoc.Save("vehicles_by_transmission.xml");


        }

    }
}

  



using System;

namespace OOP_Task
{
    public class Chassis
    {
        // Number of wheels on the chassis
        public int wheelsNumber;
        // Chassis number
        public string number;
        // Permissible load of the chassis
        public string permissibleLoad;

        public Chassis(int chassisWheelsNumber, string chassisNumber, string chassisPermissibleLoad)
        {
            wheelsNumber = chassisWheelsNumber;
            number = chassisNumber;
            permissibleLoad = chassisPermissibleLoad;
        }
    }
}
using System;
namespace OOP_Task
{
	public class Chassis
	{

        public int wheelsNumber;
        public string number;
        public string permissibleLoad;

        public Chassis(int chassisWheelsNumber, string chassisNumber, string chassisPermissibleLoad)
        {
            wheelsNumber = chassisWheelsNumber;
            number = chassisNumber;
            permissibleLoad = chassisPermissibleLoad;
        }
    }
}


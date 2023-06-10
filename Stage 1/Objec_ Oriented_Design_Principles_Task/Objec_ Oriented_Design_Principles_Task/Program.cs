using System;
using System.Reflection;

namespace ObjectOrientedDesignPrinciples_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager manager = CarManager.GetInstance();
            while (true)
            {
                Console.WriteLine("Enter command (add, count types, count all, average price, average price type, exit)");

                string commandInput = Console.ReadLine();
                ICommand commandObject = CommandFactory.CreateCommand(commandInput, manager);
                if (commandObject != null)
                {
                    commandObject.Execute();
                    if (commandObject is ExitCommand)
                    {
                        break;
                    }
                }
            }
        }
    }
}

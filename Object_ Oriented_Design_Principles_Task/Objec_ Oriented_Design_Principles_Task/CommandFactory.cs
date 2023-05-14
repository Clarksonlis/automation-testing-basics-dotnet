using System;
using ObjectOrientedDesignPrinciples_Task.Commands;

namespace ObjectOrientedDesignPrinciples_Task
{
    public static class CommandFactory
    {
        public static ICommand CreateCommand(string commandName, CarManager manager)
        {
            switch (commandName.ToLower())
            {
                case "count all":
                    return new CountAllCommand(manager);
                case "count types":
                    return new CountTypesCommand(manager);
                case "average price":
                    return new AveragePriceCommand(manager);
                case "average price type":
                    return new AveragePriceTypeCommand(manager);
                case "exit":
                    return new ExitCommand(manager);
                default:
                    return null;
            }
        }
    }
}

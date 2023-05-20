using System;

namespace Interfaces_Abstract_Classes_Task
{
    public interface IFlyable
    {
        // Sets the current position to the specified coordinate
        void FlyTo(Coordinate coordinate);

        // Calculates and returns the flying time to reach the specified coordinate
        double GetFlyTime(Coordinate coordinate);
    }
}
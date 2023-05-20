using System;

namespace Interfaces_Abstract_Classes_Task
{
    public class Drone : IFlyable
    {
        private Coordinate currentPosition;

        // Constructor
        public Drone()
        {
        }

        // Sets the current position of the drone to the specified coordinate
        public void FlyTo(Coordinate coordinate)
        {
            currentPosition = coordinate;
        }

        // Calculates and returns the flying time to reach the specified coordinate, considering hovering time
        public double GetFlyTime(Coordinate coordinate)
        {
            double distance = currentPosition.DistanceTo(coordinate);
            ValidateDistance(distance);

            double speed = GetSpeed();
            ValidateSpeed(speed);

            double flyTime = distance / speed;
            double flyTimeWithHover = flyTime;

            while (flyTime > 10)
            {
                flyTime -= 10;
                flyTimeWithHover++;
            }

            return flyTimeWithHover;
        }

        // Generates a random speed for the drone
        private double GetSpeed()
        {
            Random random = new Random();
            int speed = random.Next(0, 50);

            return speed;
        }

        // Validates that the speed is non-negative
        private void ValidateSpeed(double speed)
        {
            if (speed < 0)
            {
                throw new Exception("Speed cannot be a negative number!");
            }
        }

        // Validates that the distance is non-negative and within the drone's capabilities
        private void ValidateDistance(double distance)
        {
            if (distance < 0)
            {
                throw new Exception("Distance cannot be a negative number!");
            }

            if (distance > 1000)
            {
                throw new Exception("Distance is too long to fly for a drone!");
            }
        }
    }
}
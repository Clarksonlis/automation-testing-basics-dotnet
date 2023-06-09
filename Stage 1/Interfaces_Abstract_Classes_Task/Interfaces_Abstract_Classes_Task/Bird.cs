﻿using System;

namespace Interfaces_Abstract_Classes_Task
{
    public class Bird : IFlyable
    {
        private Coordinate currentPosition;

        // Constructor
        public Bird()
        {
        }

        // Sets the current position of the bird to the specified coordinate
        public void FlyTo(Coordinate coordinate)
        {
            currentPosition = coordinate;
        }

        // Calculates and returns the flying time to reach the specified coordinate
        public double GetFlyTime(Coordinate coordinate)
        {
            double speed = GetSpeed();

            ValidateSpeed(speed);

            double distance = currentPosition.DistanceTo(coordinate);

            ValidateDistance(distance);

            double flyTime = distance / speed;

            return flyTime;
        }

        // Generates a random speed for the bird
        private double GetSpeed()
        {
            Random random = new Random();
            int speed = random.Next(0, 20);

            return speed;
        }

        // Validates that the speed is within acceptable limits
        private void ValidateSpeed(double speed)
        {
            if (speed < 0)
            {
                throw new Exception("Speed cannot be a negative number!");
            }

            if (speed > 300)
            {
                throw new Exception("Such a high speed is impossible for a bird!");
            }
        }

        // Validates that the distance is non-negative
        private void ValidateDistance(double distance)
        {
            if (distance < 0)
            {
                throw new Exception("Distance cannot be a negative number!");
            }
        }
    }
}
﻿using System;

namespace Interfaces_Abstract_Classes_Task
{
    public class Airplane : IFlyable
    {
        private Coordinate currentPosition;

        // Constructor
        public Airplane()
        {
        }

        // Sets the current position of the airplane to the specified coordinate
        public void FlyTo(Coordinate coordinate)
        {
            currentPosition = coordinate;
        }

        // Calculates and returns the flying time to reach the specified coordinate
        public double GetFlyTime(Coordinate coordinate)
        {
            double distance = currentPosition.DistanceTo(coordinate);
            ValidateDistance(distance);

            double speed = GetSpeed(distance);
            ValidateSpeed(speed);

            double flyTime = distance / speed;

            return flyTime;
        }

        // Calculates the speed based on the distance traveled
        private double GetSpeed(double distance)
        {
            double speed = 200;
            int iterations = 0;

            while (distance > 10)
            {
                distance -= 10;
                speed += 10;
                iterations++;
            }

            double result = speed / iterations;

            return result;
        }

        // Validates that the speed is within acceptable limits
        private void ValidateSpeed(double speed)
        {
            if (speed < 0)
            {
                throw new Exception("Speed cannot be a negative number!");
            }

            if (speed > 500)
            {
                throw new Exception("Speed is too dangerous for an airplane!");
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
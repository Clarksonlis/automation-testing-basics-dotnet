using System;

namespace Interfaces_Abstract_Classes_Task
{
    public class Airplane : IFlyable
    {
        //поля
        Coordinate currentPosition;

        //конструктор
        public Airplane()
        {
        }

        //свойства

        //методы

        public void FlyTo(Coordinate coordinate)
        {
            currentPosition = coordinate;
        }

        public double GetFlyTime(Coordinate coordinate)
        {
            double distance = currentPosition.DistanceTo(coordinate);
            ValidateDistance(distance);

            double speed = GetSpeed(distance);
            ValidateSpeed(speed);

            double flyTime = distance / speed;

            return flyTime;
        }

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

        private void ValidateSpeed(double speed)
        {
            if (speed < 0)
            {
                throw new Exception("Speed cannot be a negative number!");
            }

            if (speed > 500)
            {
                throw new Exception("Speed is too dangeouros for an airplan!");
            }
        }

        private void ValidateDistance(double distance)
        {
            if (distance < 0)
            {
                throw new Exception("Distance cannot be a negative number!");
            }
        }
    }
    
}
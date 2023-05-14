using System;
namespace Interfaces_Abstract_Classes_Task
{
    public class Bird : IFlyable
    {

        //поля
        Coordinate currentPosition;


        //конструктор
        public Bird()
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
            double speed = GetSpeed();

            ValidateSpeed(speed);

            double distance = currentPosition.DistanceTo(coordinate);

            ValidateDistance(distance);

            double flyTime = distance / speed;

            return flyTime;
        }

        private double GetSpeed()
        {
            Random random = new Random();
            int speed = random.Next(0, 20);

            return speed;
        }



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

        private void ValidateDistance(double distance)
        {

            if (distance < 0)
            {
                throw new Exception("Distance cannot be a negative number!");
            }
        }
    }
}


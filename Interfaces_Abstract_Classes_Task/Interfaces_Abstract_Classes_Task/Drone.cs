using System;
namespace Interfaces_Abstract_Classes_Task
{
	public class Drone : IFlyable
    {

        //поля
        Coordinate currentPosition;

		//конструктор
        public Drone()
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

        private double GetSpeed()
        {
            Random random = new Random();
            int speed = random.Next(0, 50);

            return speed;

        }



        private void ValidateSpeed(double speed)
        {

            if (speed < 0)
            {
                throw new Exception("Speed cannot be a negative number!");
            }
        }

        private void ValidateDistance(double distance)
        {

            if (distance < 0)
            {
                throw new Exception("Distance cannot be a negative number!");
            }

            if (distance > 1000)
            {
                throw new Exception("Distance is too long to fly for a dron!");
            }
        }
    }
}


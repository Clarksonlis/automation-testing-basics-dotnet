using System;
namespace Interfaces_Abstract_Classes_Task
{
	public struct Coordinate
	{
		public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }


        public double DistanceTo(Coordinate coordinate)
        {
            double  newX = coordinate.X - this.X;
            double  newY = coordinate.Y - this.Y;
            double  newZ = coordinate.Z - this.Z;

            newX *= newX;
            newY *= newY;
            newZ *= newZ;



            double result = Math.Sqrt(newX + newY + newZ);
            return result;

        }
    }
}


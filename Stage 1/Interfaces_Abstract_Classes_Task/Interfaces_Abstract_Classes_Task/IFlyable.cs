using System;

namespace Interfaces_Abstract_Classes_Task
{
	public interface IFlyable
	{
		public void FlyTo(Coordinate coordinate);
		public double GetFlyTime(Coordinate coordinate);

    }
}
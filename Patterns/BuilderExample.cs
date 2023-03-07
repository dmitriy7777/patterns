using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns
{
	class Roof
	{
		public Roof()
		{
			Console.WriteLine("Roof has been built");
		}
	}
	class Basement
	{
		public Basement()
		{
			Console.WriteLine("Basement has been built");
		}
	}

	class House
	{
		ArrayList parts = new ArrayList();

		public void Add(object part)
		{
			parts.Add(part);
		}
	}
	class Storey
	{
		public Storey()
		{
			Console.WriteLine("Storey has been built");
		}
	}

	abstract class Builder
	{
		public abstract void BuildBasement();
		public abstract void BuildStorey();
		public abstract void BuildRoof();
		public abstract House GetResult();
	}

	class ConcreteBuilder : Builder
	{
		House house = new House();

		public override void BuildBasement()
		{
			house.Add(new Basement());
		}

		public override void BuildStorey()
		{
			house.Add(new Storey());
		}

		public override void BuildRoof()
		{
			house.Add(new Roof());
		}

		public override House GetResult()
		{
			return house;
		}
	}		
}

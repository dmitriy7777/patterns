using System.Collections;

class FlyweightFactory
{
	Hashtable flyweights = new Hashtable();
	public FlyweightFactory()
	{
		flyweights.Add("X", new ConcreteFlyweight());
		flyweights.Add("Y", new ConcreteFlyweight());
		flyweights.Add("Z", new ConcreteFlyweight());
	}
	public Flyweight GetFlyweight(string key)
	{
		if (!flyweights.ContainsKey(key))
			flyweights.Add(key, new ConcreteFlyweight());
		return flyweights[key] as Flyweight;
	}
}

abstract class Flyweight
{
	public abstract void Operation(int extrinsicState);
}

class ConcreteFlyweight : Flyweight
{
	int intrinsicState;
	public override void Operation(int extrinsicState)
	{
		Console.WriteLine("ConcreteFlyweight. extrinsicState = {0}", extrinsicState);
	}
}

class UnsharedConcreteFlyweight : Flyweight
{
	int allState;
	public override void Operation(int extrinsicState)
	{
		allState = extrinsicState;
		Console.WriteLine("UnsharedConcreteFlyweight. allState = {0}", allState);
	}
}
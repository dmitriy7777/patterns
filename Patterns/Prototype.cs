class ClientPrototype
{
	public void Operation()
	{
		Prototype prototype = new ConcretePrototype1(1);
		Console.WriteLine(prototype.Id);
		Prototype clone = prototype.Clone();
		Console.WriteLine(clone.Id);
		prototype = new ConcretePrototype2(2);
		Console.WriteLine(prototype.Id);
		clone = prototype.Clone();
		Console.WriteLine(clone.Id);
	}
}

abstract class Prototype
{
	public int Id { get; private set; }
	public Prototype(int id)
	{
		this.Id = id;
	}
	public abstract Prototype Clone();
}

class ConcretePrototype1 : Prototype
{
	public ConcretePrototype1(int id)
		: base(id)
	{ }
	public override Prototype Clone()
	{
		return new ConcretePrototype1(Id);
	}
}

class ConcretePrototype2 : Prototype
{
	public ConcretePrototype2(int id)
		: base(id)
	{ }
	public override Prototype Clone()
	{
		return new ConcretePrototype2(Id);
	}
}
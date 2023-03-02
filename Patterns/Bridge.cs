abstract class Abstraction
{
	protected Implementor implementor;
	public Implementor Implementor
	{
		set { implementor = value; }
	}
	public Abstraction(Implementor imp)
	{
		implementor = imp;
	}
	public virtual void Operation()
	{
		implementor.OperationImp();
	}
}

abstract class Implementor
{
	public abstract void OperationImp();
}

class RefinedAbstraction : Abstraction
{
	public RefinedAbstraction(Implementor imp)
		: base(imp)
	{
		implementor = imp;
	}
	public override void Operation()
	{
		implementor.OperationImp();
	}
}

class ConcreteImplementorA : Implementor
{
	public override void OperationImp()
	{
		Console.WriteLine("ConcreteImplementorA");
	}
}

class ConcreteImplementorB : Implementor
{
	public override void OperationImp()
	{
		Console.WriteLine("ConcreteImplementorB");
	}
}
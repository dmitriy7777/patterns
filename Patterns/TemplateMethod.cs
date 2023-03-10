/// <summary>
/// The 'AbstractClass' abstract base class
/// </summary>
public abstract class AbstractBaseTemplateClass
{
	// The "Template method"
	public abstract void TemplateMethod();	
}

/// <summary>
/// The 'AbstractClass' abstract class
/// </summary>
public abstract class AbstractTemplateClass: AbstractBaseTemplateClass
{
	public abstract void PrimitiveOperation1();
	public abstract void PrimitiveOperation2();

	// The "Template method"
	public sealed override void TemplateMethod()
	{
		PrimitiveOperation1();
		PrimitiveOperation2();
		Console.WriteLine("");
	}
}

/// <summary>
/// A 'ConcreteClass' class
/// </summary>
public class ConcreteTemplateClassA : AbstractTemplateClass
{
	public override void PrimitiveOperation1()
	{
		Console.WriteLine("ConcreteClassA.PrimitiveOperation1()");
	}
	public override void PrimitiveOperation2()
	{
		Console.WriteLine("ConcreteClassA.PrimitiveOperation2()");
	}
}

/// <summary>
/// A 'ConcreteClass' class
/// </summary>
public class ConcreteTemplateClassB : AbstractTemplateClass
{
	public override void PrimitiveOperation1()
	{
		Console.WriteLine("ConcreteClassB.PrimitiveOperation1()");
	}
	public override void PrimitiveOperation2()
	{
		Console.WriteLine("ConcreteClassB.PrimitiveOperation2()");
	}
}
﻿/// <summary>
/// The 'Visitor' abstract class
/// </summary>
abstract class Visitor
{
	public abstract void VisitConcreteElementA(
	  ConcreteElementA concreteElementA);
	public abstract void VisitConcreteElementB(
	  ConcreteElementB concreteElementB);
}

/// <summary>
/// A 'ConcreteVisitor' class
/// </summary>
class ConcreteVisitor1 : Visitor
{
	public override void VisitConcreteElementA(
	  ConcreteElementA concreteElementA)
	{
		Console.WriteLine("{0} visited by {1}",
		  concreteElementA.GetType().Name, this.GetType().Name);
	}

	public override void VisitConcreteElementB(
	  ConcreteElementB concreteElementB)
	{
		Console.WriteLine("{0} visited by {1}",
		  concreteElementB.GetType().Name, this.GetType().Name);
	}
}

/// <summary>
/// A 'ConcreteVisitor' class
/// </summary>
class ConcreteVisitor2 : Visitor
{
	public override void VisitConcreteElementA(
	  ConcreteElementA concreteElementA)
	{
		Console.WriteLine("{0} visited by {1}",
		  concreteElementA.GetType().Name, this.GetType().Name);
	}

	public override void VisitConcreteElementB(
	  ConcreteElementB concreteElementB)
	{
		Console.WriteLine("{0} visited by {1}",
		  concreteElementB.GetType().Name, this.GetType().Name);
	}
}

/// <summary>
/// The 'Element' abstract class
/// </summary>
abstract class Element
{
	public abstract void Accept(Visitor visitor);
}

/// <summary>
/// A 'ConcreteElement' class
/// </summary>
class ConcreteElementA : Element
{
	public override void Accept(Visitor visitor)
	{
		visitor.VisitConcreteElementA(this);
	}

	public void OperationA()
	{
	}
}

/// <summary>
/// A 'ConcreteElement' class
/// </summary>
class ConcreteElementB : Element
{
	public override void Accept(Visitor visitor)
	{
		visitor.VisitConcreteElementB(this);
	}

	public void OperationB()
	{
	}
}

/// <summary>
/// The 'ObjectStructure' class
/// </summary>
class ObjectStructure
{
	private List<Element> _elements = new List<Element>();

	public void Attach(Element element)
	{
		_elements.Add(element);
	}

	public void Detach(Element element)
	{
		_elements.Remove(element);
	}

	public void Accept(Visitor visitor)
	{
		foreach (Element element in _elements)
		{
			element.Accept(visitor);
		}
	}
}

// One more Visitor example - Example from game area - When someone Hits/Shoots to somewhere in the game

abstract class Hit
{
	public abstract void Accept(IHitVisiter visiter);
}

class TargetHit : Hit
{
	public override void Accept(IHitVisiter visiter)
	{
		visiter.Visit(this);
	}
}

class EnviromentHit : Hit
{
	public override void Accept(IHitVisiter visiter)
	{
		visiter.Visit(this);
	}
}

interface IHitVisiter
{
	void Visit(Hit hit);
	void Visit(TargetHit hit);
	void Visit(EnviromentHit Hit);
}

class Dosomething : IHitVisiter
{
	public void Visit(Hit hit)
	{
		Console.WriteLine("Hit");
	}

	public void Visit(TargetHit hit)
	{
		Console.WriteLine("Target Hit");
	}

	public void Visit(EnviromentHit Hit)
	{
		Console.WriteLine("Enviroment Hit");
	}
}

class Shooter
{
	public Hit Shoot()
	{
		var random = new Random();
		var randomHit = random.Next(0, 2);
		if (randomHit == 0)
		{
			return new TargetHit();
		}
		else if (randomHit == 1)
		{
			return new EnviromentHit();
		}
		return new EnviromentHit();
	}
}

abstract class Pizza
{
	public Pizza(string n)
	{
		this.Name = n;
	}
	public string Name { get; protected set; }
	public abstract int GetCost();
}

class ItalianPizza : Pizza
{
	public ItalianPizza() : base("Italian Pizza")
	{ }
	public override int GetCost()
	{
		return 10;
	}
}
class BulgerianPizza : Pizza
{
	public BulgerianPizza()
		: base("Bulgerian Pizza")
	{ }
	public override int GetCost()
	{
		return 8;
	}
}

abstract class PizzaDecorator : Pizza
{
	protected Pizza pizza;
	public PizzaDecorator(string n, Pizza pizza) : base(n)
	{
		this.pizza = pizza;
	}
}

class TomatoPizza : PizzaDecorator
{
	public TomatoPizza(Pizza p)
		: base(p.Name + ", Tomato Pizza", p)
	{ }

	public override int GetCost()
	{
		return pizza.GetCost() + 3;
	}
}

class CheesePizza : PizzaDecorator
{
	public CheesePizza(Pizza p)
		: base(p.Name + ", Cheese Pizza", p)
	{ }

	public override int GetCost()
	{
		return pizza.GetCost() + 5;
	}
}
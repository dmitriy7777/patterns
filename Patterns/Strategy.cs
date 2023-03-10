/// <summary>
/// The 'Strategy' abstract class
/// </summary>
public abstract class Strategy
{
	public abstract void AlgorithmInterface();
}

/// <summary>
/// A 'ConcreteStrategy' class
/// </summary>
public class ConcreteStrategyA : Strategy
{
	public override void AlgorithmInterface()
	{
		Console.WriteLine(
		  "Called ConcreteStrategyA.AlgorithmInterface()");
	}
}

/// <summary>
/// A 'ConcreteStrategy' class
/// </summary>
public class ConcreteStrategyB : Strategy
{
	public override void AlgorithmInterface()
	{
		Console.WriteLine(
		  "Called ConcreteStrategyB.AlgorithmInterface()");
	}
}

/// <summary>
/// A 'ConcreteStrategy' class
/// </summary>
public class ConcreteStrategyC : Strategy
{
	public override void AlgorithmInterface()
	{
		Console.WriteLine(
		  "Called ConcreteStrategyC.AlgorithmInterface()");
	}
}

/// <summary>
/// The 'Context' class
/// </summary>
public class StrategyContext
{
	private readonly Strategy _strategy;

	// Constructor
	public StrategyContext(Strategy strategy)
	{
		_strategy = strategy;
	}

	public void ContextInterface()
	{
		_strategy.AlgorithmInterface();
	}
}
/// <summary>
/// The 'Command' abstract class
/// </summary>
abstract class Command
{
	protected CommandReceiver receiver;

	// Constructor
	public Command(CommandReceiver receiver)
	{
		this.receiver = receiver;
	}

	public abstract void Execute();
}

/// <summary>
/// The 'ConcreteCommand' class
/// </summary>
class ConcreteCommand : Command
{
	// Constructor
	public ConcreteCommand(CommandReceiver receiver) :
	  base(receiver)
	{
	}

	public override void Execute()
	{
		receiver.Action();
	}
}

/// <summary>
/// The 'Receiver' class
/// </summary>
class CommandReceiver
{
	public void Action()
	{
		Console.WriteLine("Called Receiver.Action()");
	}
}

/// <summary>
/// The 'Invoker' class
/// </summary>
class Invoker
{
	private Command _command;

	public void SetCommand(Command command)
	{
		this._command = command;
	}

	public void ExecuteCommand()
	{
		_command.Execute();
	}
}

public interface ICommand 
{
	void Positive();
	void Negative();
}

public class Conveyor
{
	public void On() => Console.WriteLine("Conveyor has been started");
	public void Off() => Console.WriteLine("Conveyor has been stopped");
	public void SpeedIncrease() => Console.WriteLine("Conveyor speed has been increased");
	public void SpeedDecrease() => Console.WriteLine("Conveyor speed has been decreased");
}

public class ConveyorWorkCommand : ICommand
{
	private Conveyor _conveyor;
	public ConveyorWorkCommand(Conveyor conveyor)
	{
		_conveyor = conveyor;
	}

	public void Negative()
	{
		_conveyor.Off();
	}

	public void Positive()
	{
		_conveyor.On();
	}
}

public class ConveyorAdjustCommand : ICommand
{
	private Conveyor _conveyor;
	public ConveyorAdjustCommand(Conveyor conveyor)
	{
		_conveyor = conveyor;
	}

	public void Negative()
	{
		_conveyor.SpeedDecrease();
	}

	public void Positive()
	{
		_conveyor.SpeedIncrease();
	}
}

public class Multipult
{
	private List<ICommand> _commands;
	private Stack<ICommand> _history;

	public Multipult() 
	{
		_commands = new List<ICommand>()
		{
			null, 
			null
		};
		_history = new Stack<ICommand>();
	}

	public void SetCommand(int button, ICommand command)
	{
		_commands[button] = command;
	}

	public void PressOn(int button)
	{
		_commands[button].Positive();
		_history.Push(_commands[button]);
	}

	public void PressCancel()
	{
		if (_history.Count != 0) 
		{ 
			_history.Pop().Negative();
		}
	}
}
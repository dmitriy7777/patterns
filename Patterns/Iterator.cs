using System.Collections;

abstract class Aggregate
{
	public abstract Iterator CreateIterator();
}

/// <summary>
/// The 'ConcreteAggregate' class
/// </summary>
class ConcreteAggregate : Aggregate
{
	private ArrayList _items = new ArrayList();

	public override Iterator CreateIterator()
	{
		return new ConcreteIterator(this);
	}

	// Gets item count
	public int Count
	{
		get { return _items.Count; }
	}

	// Indexer
	public object this[int index]
	{
		get { return _items[index]; }
		set { _items.Insert(index, value); }
	}
}

/// <summary>
/// The 'Iterator' abstract class
/// </summary>
abstract class Iterator
{
	public abstract object First();
	public abstract object Next();
	public abstract bool IsDone();
	public abstract object CurrentItem();
}

/// <summary>
/// The 'ConcreteIterator' class
/// </summary>
class ConcreteIterator : Iterator
{
	private ConcreteAggregate _aggregate;
	private int _current = 0;

	// Constructor
	public ConcreteIterator(ConcreteAggregate aggregate)
	{
		this._aggregate = aggregate;
	}

	// Gets first iteration item
	public override object First()
	{
		return _aggregate[0];
	}

	// Gets next iteration item
	public override object Next()
	{
		object ret = null;
		if (_current < _aggregate.Count - 1)
		{
			ret = _aggregate[++_current];
		}

		return ret;
	}

	// Gets current iteration item
	public override object CurrentItem()
	{
		return _aggregate[_current];
	}

	// Gets whether iterations are complete
	public override bool IsDone()
	{
		return _current >= _aggregate.Count;
	}
}
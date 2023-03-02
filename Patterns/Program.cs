namespace Patterns
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//Factory Method
			Console.WriteLine("Factory");
			Creator[] creators = new Creator[2];

			creators[0] = new ConcreteCreatorA();
			creators[1] = new ConcreteCreatorB();

			// Iterate over creators and create products
			foreach (Creator creator in creators)
			{
				Product product = creator.FactoryMethod();
				Console.WriteLine("Created {0}",
				  product.GetType().Name);
			}

			// Wait for user
			Console.ReadKey();
			Console.WriteLine();

			// Builder
			Console.WriteLine("Builder");
			ConcreteBuilder cb = new ConcreteBuilder();
			cb.BuildBasement();
			cb.BuildStorey();
			cb.BuildRoof();
			cb.GetResult();

			// Wait for user
			Console.ReadKey();
			Console.WriteLine();

			// Abstract factory #1
			Console.WriteLine("Abstract Factory");
			AbstractFactory factory1 = new ConcreteFactory1();
			Client client1 = new Client(factory1);
			client1.Run();

			// Abstract factory #2
			AbstractFactory factory2 = new ConcreteFactory2();
			Client client2 = new Client(factory2);
			client2.Run();

			// Wait for user input
			Console.ReadKey();
			Console.WriteLine();

			//Prototype
			Console.WriteLine("Prototype");
			ClientPrototype cp = new ClientPrototype();
			cp.Operation();
			// Wait for user input
			Console.ReadKey();
			Console.WriteLine();

			//Singleton
			Console.WriteLine("Singleton");
			var sngletonInst = Singleton.Instance;
			Console.WriteLine("Singlton = {0}", sngletonInst.GetType().ToString());
			// Wait for user input
			Console.ReadKey();
			Console.WriteLine();

			//Adapter - LINQ-провайдера - IQueryProvider, TextReader/TextWriter, BinaryReader/BinaryWriter
			Console.WriteLine("Adapter");
			Target target = new Adapter();
			target.Request();
			// Wait for user
			Console.ReadKey();
			Console.WriteLine();

			//Bridge
			Console.WriteLine("Bridge");
			Abstraction abstraction;
			abstraction = new RefinedAbstraction(new ConcreteImplementorA());
			abstraction.Operation();
			abstraction.Implementor = new ConcreteImplementorB();
			abstraction.Operation();
			// Wait for user
			Console.ReadKey();
			Console.WriteLine();

			//Composite
			Console.WriteLine("Composite");
			Component root = new Composite("Root");
			Component leaf = new Leaf("Leaf");
			Composite subtree = new Composite("Subtree");
			root.Add(leaf);
			root.Add(subtree);
			root.Display();
			// Wait for user
			Console.ReadKey();
			Console.WriteLine();
		}

		abstract class Product
		{
		}

		class ConcreteProductA : Product
		{
		}

		class ConcreteProductB : Product
		{
		}

		abstract class Creator
		{
			public abstract Product FactoryMethod();
		}

		class ConcreteCreatorA : Creator
		{
			public override Product FactoryMethod()
			{
				return new ConcreteProductA();
			}
		}

		class ConcreteCreatorB : Creator
		{
			public override Product FactoryMethod()
			{
				return new ConcreteProductB();
			}
		}
	}
}
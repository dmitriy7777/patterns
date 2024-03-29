﻿using System;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Patterns
{
	internal class Program
	{
		static void Main(string[] args)
		{
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

			//Decorator
			Console.WriteLine("Decorator");
			Pizza pizza1 = new ItalianPizza();
			pizza1 = new TomatoPizza(pizza1); // итальянская пицца с томатами
			Console.WriteLine("Name: {0}", pizza1.Name);
			Console.WriteLine("Price: {0}", pizza1.GetCost());

			Pizza pizza2 = new ItalianPizza();
			pizza2 = new CheesePizza(pizza2);// итальянская пиццы с сыром
			Console.WriteLine("Name: {0}", pizza2.Name);
			Console.WriteLine("Price: {0}", pizza2.GetCost());

			Pizza pizza3 = new BulgerianPizza();
			pizza3 = new TomatoPizza(pizza3);
			pizza3 = new CheesePizza(pizza3);// болгарская пиццы с томатами и сыром
			Console.WriteLine("Name: {0}", pizza3.Name);
			Console.WriteLine("Price: {0}", pizza3.GetCost());
			// Wait for user
			Console.ReadKey();
			Console.WriteLine();

			//Facade
			Console.WriteLine("Facade");
			Facade facade = new Facade();
			facade.MethodA();
			facade.MethodB();
			// Wait for user
			Console.ReadKey();
			Console.WriteLine();

			//Flyweight
			Console.WriteLine("Flyweight");
			int extrinsicstate = 22;

			FlyweightFactory f = new FlyweightFactory();

			Flyweight fx = f.GetFlyweight("X");
			fx.Operation(--extrinsicstate);

			Flyweight fy = f.GetFlyweight("Y");
			fy.Operation(--extrinsicstate);

			Flyweight fd = f.GetFlyweight("D");
			fd.Operation(--extrinsicstate);

			UnsharedConcreteFlyweight uf = new UnsharedConcreteFlyweight();

			uf.Operation(--extrinsicstate);
			// Wait for user
			Console.ReadKey();
			Console.WriteLine();			

			//Proxy
			Console.WriteLine("Proxy");
			Subject subject = new Proxy();
			subject.Request();
			// Wait for user
			Console.ReadKey();
			Console.WriteLine();

			//ChainOfResponsibility
			Console.WriteLine("ChainOfResponsibility");
			Receiver receiver = new Receiver(false, true, true);
			PaymentHandler bankPaymentHandler = new BankPaymentHandler();
			PaymentHandler moneyPaymentHnadler = new MoneyPaymentHandler();
			PaymentHandler paypalPaymentHandler = new PayPalPaymentHandler();
			bankPaymentHandler.Successor = paypalPaymentHandler;
			paypalPaymentHandler.Successor = moneyPaymentHnadler;
			bankPaymentHandler.Handle(receiver);			
			// Wait for user
			Console.ReadKey();
			Console.WriteLine();

			//Command - IDbCommand в ADO.NET and Объект класса Task<T> принимает делегат Func<T>, который можно рассматривать в виде команды
			Console.WriteLine("Command");
			// Create receiver, command, and invoker
			CommandReceiver commandReceiver = new CommandReceiver();
			Command command = new ConcreteCommand(commandReceiver);
			Invoker invoker = new Invoker();
			// Set and execute command
			invoker.SetCommand(command);
			invoker.ExecuteCommand();

			Conveyor conveyor = new Conveyor();
			Multipult multipult = new Multipult();
			multipult.SetCommand(0, new ConveyorWorkCommand(conveyor));
			multipult.SetCommand(1, new ConveyorAdjustCommand(conveyor));
			multipult.PressOn(0);
			multipult.PressOn(1);
			multipult.PressCancel();
			multipult.PressCancel();
			// Wait for user
			Console.ReadKey();
			Console.WriteLine();

			//Interpreter
			Console.WriteLine("Interpreter");
			string roman = "MMXVIII";
			Context context = new Context(roman);

			//Строим 'parse tree'
			List<Expression> tree = new List<Expression>
			{
				new ThousandExpression(),
				new HundredExpression(),
				new TenExpression(),
				new OneExpression()
			};

			//Интерпритатор
			foreach (Expression exp in tree)
			{
				exp.Interpret(context);
			}
			Console.WriteLine("{0} = {1}",
				roman, context.Output);
			// Wait for user
			Console.ReadKey();
			Console.WriteLine();

			//Iterator - IEnumerable/IEnumerator , IEnumerable<T>/IEnumerator<T>, IObservable<T>/IObserver<T>
			Console.WriteLine("Iterator");
			ConcreteAggregate a = new ConcreteAggregate();
			a[0] = "Item A";
			a[1] = "Item B";
			a[2] = "Item C";
			a[3] = "Item D";

			// Create Iterator and provide aggregate
			Iterator i = a.CreateIterator();

			Console.WriteLine("Iterating over collection:");

			object item = i.First();
			while (item != null)
			{
				Console.WriteLine(item);
				item = i.Next();
			}
			// Wait for user
			Console.ReadKey();
			Console.WriteLine();

			//Mediator (Посредник) - MVC, MVP  - Controller и Presenter выступают в роли посредника
			Console.WriteLine("Mediator");
			ManagerMediator mediator = new ManagerMediator();
			Colleague customer = new CustomerColleague(mediator);
			Colleague programmer = new ProgrammerColleague(mediator);
			Colleague tester = new TesterColleague(mediator);
			mediator.Customer = customer;
			mediator.Programmer = programmer;
			mediator.Tester = tester;
			customer.Send("There is an order. It is neccessary to create application");
			programmer.Send("Application is completted. It is neccessary to test it");
			tester.Send("Application is tested and ready for sale.");
			// Wait for user
			Console.ReadKey();
			Console.WriteLine();

			//Memento - Хранитель
			Console.WriteLine("Memento");
			Originator o = new Originator();
			o.State = "On";
			// Store internal state
			Caretaker c = new Caretaker();
			c.Memento = o.CreateMemento();
			// Continue changing originator
			o.State = "Off";
			// Restore saved state
			o.SetMemento(c.Memento);			
			// Wait for user
			Console.ReadKey();
			Console.WriteLine();

			//Observer - Наблюдатель
			Console.WriteLine("Observer");
			// Configure Observer pattern
			ConcreteSubject s = new ConcreteSubject();
			s.Attach(new ConcreteObserver(s, "X"));
			s.Attach(new ConcreteObserver(s, "Y"));
			s.Attach(new ConcreteObserver(s, "Z"));
			// Change subject and notify observers
			s.SubjectState = "ABC";
			s.Notify();
			// Wait for user
			Console.ReadKey();
			Console.WriteLine();

			//State - Task реализует конечный автомат перехода между состояниями задачи: Created, WaitingForActivation, WaitingToRun, Running, Run ToCompletion, Canceled, Faulted.
			Console.WriteLine("State");
			// Setup context in a state
			StateContext сontext = new StateContext(new ConcreteStateA());
			// Issue requests, which toggles state
			сontext.Request();
			сontext.Request();
			сontext.Request();
			сontext.Request();
			// Wait for user
			Console.ReadKey();
			Console.WriteLine();

			//Strategy - LINQ (Language Integrated Query),  IComparer<T> или IEqualityComparer<T>, использует паттерн «Стратегия». IErrorHandler — стратегия обработки коммуникационных ошибок; IChannelInitializer — стратегия инициализации канала; IDispatchMessageFormatter — стратегия форматирования сообщений; MessageFilter — стратегия фильтрации сообщений
			Console.WriteLine("Strategy");
			StrategyContext strategy = new StrategyContext(new ConcreteStrategyA());
			strategy.ContextInterface();
			strategy = new StrategyContext(new ConcreteStrategyB());
			strategy.ContextInterface();
			strategy = new StrategyContext(new ConcreteStrategyC());
			strategy.ContextInterface();
			// Wait for user
			Console.ReadKey();
			Console.WriteLine();

			//TemplateMethod - По большому счету, любой абстрактный класс, который содержит защищенный абстрактный метод, является примером паттерна «Шаблонный метод».
			Console.WriteLine("TemplateMethod");
			AbstractTemplateClass ac = new ConcreteTemplateClassA();
			ac.PrimitiveOperation1();
			ac.PrimitiveOperation2();
			ac = new ConcreteTemplateClassB();
			ac.PrimitiveOperation1();
			ac.PrimitiveOperation2();
			// Wait for user
			Console.ReadKey();
			Console.WriteLine();

			//Visitor - DbExpressionVisitor используется в Entity Framework для SQL-выражений.
			Console.WriteLine("Visitor");
			// Setup structure
			ObjectStructure os = new ObjectStructure();
			os.Attach(new ConcreteElementA());
			os.Attach(new ConcreteElementB());
			// Create visitor objects
			ConcreteVisitor1 v1 = new ConcreteVisitor1();
			ConcreteVisitor2 v2 = new ConcreteVisitor2();
			// Structure accepting visitors
			os.Accept(v1);
			os.Accept(v2);
			//Visitor - Shooting example
			Console.WriteLine("---------------------------------");
			Console.WriteLine("Visitor - Shooting example");
			var shooter = new Shooter();

			for (var i2 = 0; i2 <= 10; i2++)
			{
				Hit hit = shooter.Shoot();
				hit.Accept(new Dosomething());
			}
			// Wait for user
			Console.ReadKey();
			Console.WriteLine();

			//Bin Tree Implementation
			Console.WriteLine("Bin Tree Implementation");
			var rootTree = new TreeNode<int>()
			{
				NodeValue = 10,
				LeftNode = new TreeNode<int>()
				{
					NodeValue = 20,
					RightNode = new TreeNode<int>() { NodeValue = 30 }
				},
				RightNode = new TreeNode<int>()
				{
					NodeValue = 40,
					LeftNode = new TreeNode<int>() { NodeValue = 50 },
					RightNode = new TreeNode<int>() { NodeValue = 60 }
				}
			};

			ByPass<int>(rootTree);
			Console.WriteLine(string.Join(";", ToEnumerable(rootTree)));
			Console.WriteLine(string.Join(";", ToEnumerable2(rootTree)));

			// Wait for user
			Console.ReadKey();
			Console.WriteLine();
		}

		static void ByPass<T>(TreeNode<T> node)
		{
			if (node == null) 
			{
				return;
			}
			Console.WriteLine(node.NodeValue);
			ByPass(node.LeftNode);
			ByPass(node.RightNode);
		}

		static IEnumerable<T> ToEnumerable<T>(TreeNode<T> node) 
		{
			if (node == null) 
			{ 
				yield break;
			}
			yield return node.NodeValue;
			foreach (var element in ToEnumerable(node.LeftNode).Concat(ToEnumerable(node.RightNode))) 
			{
				yield return element;
			}
		}

		static IEnumerable<T> ToEnumerable2<T>(TreeNode<T> node) 
		{ 
			var stack = new Stack<TreeNode<T>>();
			stack.Push(node);

			while (stack.Count > 0) 
			{ 
				var current = stack.Pop();
				if (current == null) 
				{
					continue;
				}
				yield return current.NodeValue;
				stack.Push(current.LeftNode);
				stack.Push(current.RightNode);
			}
		}		
	}
}
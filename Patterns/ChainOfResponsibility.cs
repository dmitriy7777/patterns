class Receiver
{
	// банковские переводы
	public bool BankTransfer { get; set; }
	// денежные переводы - WesternUnion, Unistream
	public bool MoneyTransfer { get; set; }
	// перевод через PayPal
	public bool PayPalTransfer { get; set; }
	public Receiver(bool bt, bool mt, bool ppt)
	{
		BankTransfer = bt;
		MoneyTransfer = mt;
		PayPalTransfer = ppt;
	}
}
abstract class PaymentHandler
{
	public PaymentHandler Successor { get; set; }
	public abstract void Handle(Receiver receiver);
}

class BankPaymentHandler : PaymentHandler
{
	public override void Handle(Receiver receiver)
	{
		if (receiver.BankTransfer == true)
			Console.WriteLine("Processing bank transfer");
		else if (Successor != null)
			Successor.Handle(receiver);
	}
}

class PayPalPaymentHandler : PaymentHandler
{
	public override void Handle(Receiver receiver)
	{
		if (receiver.PayPalTransfer == true)
			Console.WriteLine("Processing bank transfer using PayPal");
		else if (Successor != null)
			Successor.Handle(receiver);
	}
}
// переводы с помощью системы денежных переводов
class MoneyPaymentHandler : PaymentHandler
{
	public override void Handle(Receiver receiver)
	{
		if (receiver.MoneyTransfer == true)
			Console.WriteLine("Processing bank transfer using system of money transfering");
		else if (Successor != null)
			Successor.Handle(receiver);
	}
}
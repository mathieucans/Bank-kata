using System;

namespace BankAccount
{
	public class DepositTransaction : IAccountTransaction
	{
		public DateTime Date { get; private set; }
		public double Amount { get; private set; }

		public DepositTransaction(DateTime date, double amount)
		{
			Date = date;
			Amount = amount;
		}
	}
}
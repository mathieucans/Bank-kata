using System;

namespace BankAccount
{
	public class StatementLine : IStatementItem
	{
	

		public DateTime Time { get; private set; }
		public double Amount { get; private set; }
		public double Balance { get; private set; }

		public StatementLine(DateTime dateTime, double amount, double balance)
		{
			Time = dateTime;
			Amount = amount;
			Balance = balance;
		}

		public void Accept(IStatementVisitor visitor)
		{
			visitor.Visit(this);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != this.GetType()) return false;
			return Equals((StatementLine) obj);
		}

		protected bool Equals(StatementLine other)
		{
			return Time.Equals(other.Time) && Amount.Equals(other.Amount) && Balance.Equals(other.Balance);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				var hashCode = Time.GetHashCode();
				hashCode = (hashCode * 397) ^ Amount.GetHashCode();
				hashCode = (hashCode * 397) ^ Balance.GetHashCode();
				return hashCode;
			}
		}

		public override string ToString()
		{
			return String.Format("{0:dd/mm/yyyy}, amount {1}, balance {2}", Time, Amount,Balance);
		}
	}
}
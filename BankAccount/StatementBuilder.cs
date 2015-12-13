using System;
using System.Collections.Generic;

namespace BankAccount
{
	public class StatementBuilder
	{
		private List<IStatementItem> _statementItems;

		public StatementBuilder()
		{
			_statementItems = new List<IStatementItem>();
		}

		public StatementBuilder Add(string date, double amount, double balance)
		{
			_statementItems.Add(new StatementLine(DateTime.Parse(date), amount, balance));
			return this;
		}

		public AccountStatement Build()
		{
			return new AccountStatement(_statementItems);
		}
	}
}
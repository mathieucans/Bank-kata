using System;
using System.Collections.Generic;
using System.Linq;

namespace BankAccount
{
	public class StatementProvider : IStatementProvider
	{
		private readonly ITransactionProvider _transactionProvider;

		public StatementProvider(ITransactionProvider transactionProvider)
		{
			_transactionProvider = transactionProvider;
		}

		public IAccountStatement GetStatements()
		{
			var statementItems = new List<StatementLine>();
				
			double balance = 0;
			foreach (var accountTransaction in _transactionProvider.Transaction)
			{
				balance += accountTransaction.Amount;
				statementItems.Add(new StatementLine(accountTransaction.Date, accountTransaction.Amount, balance));				
			}
			statementItems.Sort((a, b) => b.Time.CompareTo(a.Time));
			return new AccountStatement(statementItems.ToList<IStatementItem>());
		}
	}
}
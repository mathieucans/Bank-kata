using System;
using System.Collections.Generic;
using BankAccount;
using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BankAccountTest
{
	[TestClass]
	public class StatementProviderShould
	{
		private static readonly AccountStatement EMPTY_STATEMENT = new StatementBuilder().Build();

		private static readonly AccountStatement POSITIVE_STATEMENTS = new StatementBuilder()
			.Add("12/12/2015", 150.0, 250.0)
			.Add("11/12/2015", 100.0, 100.0)
			.Build();

		private static readonly DepositTransaction[] DEPOSIT_TRANSACTIONS = new []
		{
			new DepositTransaction(DateTime.Parse("11/12/2015"), 100),
			new DepositTransaction(DateTime.Parse("12/12/2015"), 150)
		};

		private ITransactionProvider _transactionProvider;

		private StatementProvider CreateStatementProvider()
		{
			return new StatementProvider(_transactionProvider);
		}

		[TestInitialize]
		public void TestInitialize()
		{
			_transactionProvider = A.Fake<ITransactionProvider>();
		}

		[TestMethod]
		public void provides_an_empty_statement_when_no_transaction_has_been_done()
		{
			var provider = CreateStatementProvider();

			var accountStatement = provider.GetStatements();

			Assert.AreEqual(EMPTY_STATEMENT, accountStatement);
		}

		[TestMethod]
		public void provides_positive_amount_when_transaction_are_deposit_in_inverse_chronologicalorder()
		{			
			var provider = CreateStatementProvider();
			A.CallTo(() => _transactionProvider.Transaction).Returns(DEPOSIT_TRANSACTIONS);

			var accountStatement = provider.GetStatements();

			Assert.AreEqual(POSITIVE_STATEMENTS, accountStatement);
		}
	}

	
}
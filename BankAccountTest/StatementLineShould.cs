using System;
using BankAccount;
using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BankAccountTest
{
	[TestClass]
	public class StatementLineShould
	{
		[TestMethod]
		public void VisitHimselfWhenAcceptVisitor()
		{
			var statementLine = new StatementLine(DateTime.MinValue, 0.0,0.0);
			var visitor = A.Fake<IStatementVisitor>();

			statementLine.Accept(visitor);

			A.CallTo(() => visitor.Visit(statementLine)).MustHaveHappened(Repeated.Exactly.Once);
		}
	}
}
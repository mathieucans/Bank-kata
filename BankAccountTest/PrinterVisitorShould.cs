using System;
using System.Collections.Generic;
using BankAccount;
using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BankAccountTest
{
	[TestClass]
	public class PrinterVisitorShould
	{
		private IPrinter _printer;

		[TestInitialize]
		public void TestInitialize()
		{
			_printer =  A.Fake<IPrinter>();
		}

		[TestMethod]
		public void WriteLineWhenVisitingStatementLine()
		{
			var visitor = Create();

			visitor.Visit(new StatementLine(DateTime.Parse("10/11/2015"), 100.0, 200.0));

			A.CallTo(() => _printer.WriteLine("10/11/2015|100.00|200.00")).MustHaveHappened(Repeated.Exactly.Once);
		}

		[TestMethod]
		public void WriteHeaderWhenVisitingAccountStatement()
		{
			var visitor = Create();

			visitor.Visit(new AccountStatement(A.CollectionOfFake<IStatementItem>(0)));

			A.CallTo(() => _printer.WriteLine("DATE|AMOUNT|BALANCE")).MustHaveHappened(Repeated.Exactly.Once);
		}


		private PrinterVisitor Create()
		{
			var visitor = new PrinterVisitor(_printer);
			return visitor;
		}
	}
}
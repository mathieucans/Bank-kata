using BankAccount;
using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BankAccountTest
{
	[TestClass]
	public class PrintServiceShould
	{
		private IPrinter _printer =  A.Fake<IPrinter>();
		private IStatementProvider _statementService;

		[TestInitialize]
		public void TestInitialize()
		{
			_statementService = A.Fake<IStatementProvider>();
		}

		[TestMethod]
		public void print_should_visit_the_statement()
		{
			var statement = A.Fake<IAccountStatement>();
			A.CallTo(() => _statementService.GetStatements()).Returns(statement);
			var printService = Create();

			printService.PrintStatement();

			A.CallTo(() => statement.Accept(A<PrinterVisitor>.Ignored)).MustHaveHappened(Repeated.Exactly.Once);
		}

		private PrintService Create()
		{
			var printService = new PrintService(_printer, _statementService);
			return printService;
		}
	}

}
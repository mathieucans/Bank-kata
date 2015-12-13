namespace BankAccount
{
	public class PrintService : IPrintService
	{
		private IPrinter _printer;
		private readonly IStatementProvider _statementService;

		public PrintService(IPrinter printer, IStatementProvider statementService)
		{
			_printer = printer;
			_statementService = statementService;
		}

		public void PrintStatement()
		{
			var printer = new PrinterVisitor(_printer);
			_statementService.GetStatements().Accept(printer);
		}
	}
}
using System.Globalization;

namespace BankAccount
{
	public class PrinterVisitor : IStatementVisitor
	{
		private readonly IPrinter _printer;

		public PrinterVisitor(IPrinter printer)
		{
			_printer = printer;
		}

		public void Visit(StatementLine statementLine)
		{
			_printer.WriteLine(
				string.Format(new CultureInfo("en-us"), "{0:dd/MM/yyyy}|{1:0.00}|{2:0.00}", 
					statementLine.Time, 
					statementLine.Amount, 
					statementLine.Balance));
		}

		public void Visit(AccountStatement accountStatement)
		{
			_printer.WriteLine("DATE|AMOUNT|BALANCE");			
		}
	}
}
namespace BankAccount
{
	public interface IAccountStatement
	{
		void Accept(IStatementVisitor statementVisitor);
	}
}
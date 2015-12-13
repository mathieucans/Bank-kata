namespace BankAccount
{
	public interface IStatementProvider
	{
		IAccountStatement GetStatements();
	}
}
namespace BankAccount
{
	public interface IStatementItem
	{
		void Accept(IStatementVisitor visitor);
	}
}
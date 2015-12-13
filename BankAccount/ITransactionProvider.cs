using System.Collections.Generic;

namespace BankAccount
{
	public interface ITransactionProvider
	{
		IEnumerable<DepositTransaction> Transaction { get; }
	}
}
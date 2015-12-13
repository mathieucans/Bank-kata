using System.Collections.Generic;

namespace BankAccount
{
	public class TransactionProvider : ITransactionProvider
	{
		public IEnumerable<DepositTransaction> Transaction { get; private set; }
	}
}
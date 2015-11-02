using System.Linq;
using BankAccount;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BankAccountTest
{
	[TestClass]
	public class OperationServiceShould
	{
		[TestMethod]
		public void create_and_add_deposit_operation_in_operations_list()
		{
			var operationService = new OperationService();
			int amount = 100;
			operationService.StoreDeposit(amount);

			var lastOperation = operationService.Operations.Last();
			Assert.AreEqual(OperationType.Deposit, lastOperation.Type);
			Assert.AreEqual(amount, lastOperation.Amount);
		}
	}
}
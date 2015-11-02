using System;
using System.Text;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using BankAccount;
using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BankAccountTest
{
	[TestClass]
	public class AccountServiceShould
	{
		[TestMethod]
		public void store_deposit_operation()
		{
			var accountService = Create();

			accountService.Deposit(100);

			A.CallTo(() => _operationService.StoreDeposit(100)).MustHaveHappened(Repeated.Exactly.Once);
		}

		[TestMethod]
		public void store_withdraw_operation()
		{
			var accountService = Create();

			accountService.Withdraw(100);

			A.CallTo(() => _operationService.StoreWithdraw(100)).MustHaveHappened(Repeated.Exactly.Once);
		}

		[TestMethod]
		public void give_all_operations_to_statement_printer()
		{
			var operationList = A.Fake<IEnumerable<IOperation>>();
			A.CallTo(() => _operationService.Operations).Returns(operationList);
			var accountServce = Create();

			accountServce.PrintStatement();

			A.CallTo(() => _printService.Print(operationList)).MustHaveHappened(Repeated.Exactly.Once);
		}

		[TestInitialize]
		public void TestInitialize()
		{
			_operationService = A.Fake<IOperationService>();
			_printService = A.Fake<IPrintService>();
		}

		private AccountService Create()
		{
			var accountService = new AccountService(_operationService, _printService);
			return accountService;
		}

		private IOperationService _operationService;

		private IPrintService _printService;
	}
}

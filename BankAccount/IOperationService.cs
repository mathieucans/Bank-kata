﻿using System.Collections.Generic;

namespace BankAccount
{
	public interface IOperationService
	{
		void StoreDeposit(int amount);
		void StoreWithdraw(int amount);
	}
}
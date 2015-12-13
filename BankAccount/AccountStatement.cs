using System;
using System.Collections.Generic;

namespace BankAccount
{
	public class AccountStatement : IAccountStatement
	{
		
		private readonly IList<IStatementItem> _statementItems;

		public AccountStatement(IList<IStatementItem> statementItems)
		{
			_statementItems = statementItems;
		}

		public void Accept(IStatementVisitor visitor)
		{			
			visitor.Visit(this);
			foreach (var statementItem in _statementItems)
			{
				statementItem.Accept(visitor);
			}
		}

		public override bool Equals(object obj)
		{
			var result = false;

			if (obj is AccountStatement)
			{
				var otherStatement = ((AccountStatement) obj);
				if (otherStatement._statementItems.Count == _statementItems.Count)
				{
					result = true;
					for (int i = 0; i < _statementItems.Count && result; i++)
					{
						result = _statementItems[i].Equals(otherStatement._statementItems[i]);
					}
				}
					
			}
			return result;
		}

		public override int GetHashCode()
		{
			return _statementItems.Count.GetHashCode();
		}

		public override string ToString()
		{
			var result = "";
			foreach (var statementItem in _statementItems)
			{
				result = string.Concat(result, "[");
				result = String.Concat(result, statementItem);
				result = string.Concat(result, "]");
			}
			return result;
		}
	}
}
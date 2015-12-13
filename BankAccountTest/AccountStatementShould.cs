using BankAccount;
using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BankAccountTest
{
	[TestClass]
	public class AccountStatementShould
	{
		[TestMethod]
		public void VisitHimselfWhenAcceptVisitor()
		{
			var accountStatement = new AccountStatement(A.CollectionOfFake<IStatementItem>(3));
			var visitor = A.Fake<IStatementVisitor>();

			accountStatement.Accept(visitor);

			A.CallTo(() => visitor.Visit(accountStatement)).MustHaveHappened(Repeated.Exactly.Once);
		}

		[TestMethod]
		public void TellEachLineToAcceptVisitorInTheRightOrder()
		{
			var collectionOfFake = A.CollectionOfFake<IStatementItem>(3);
			var accountStatement = new AccountStatement(collectionOfFake);
			var visitor = A.Fake<IStatementVisitor>();

			using (var scope = Fake.CreateScope())
			{
				accountStatement.Accept(visitor);

				using (scope.OrderedAssertions())
				{
					foreach (var statementItem in collectionOfFake)
					{
						A.CallTo(() => statementItem.Accept(visitor)).MustHaveHappened(Repeated.Exactly.Once);
					}
				}
			}
		}

		[TestMethod]
		public void TellEachLineToAcceptVisitorWhenAcceptVisitor()
		{
			var statementItems = A.CollectionOfFake<IStatementItem>(3);
			var accountStatement = new AccountStatement(statementItems);
			var visitor = A.Fake<IStatementVisitor>();

			accountStatement.Accept(visitor);

			A.CallTo(() => statementItems[0].Accept(visitor)).MustHaveHappened(Repeated.Exactly.Once);
			A.CallTo(() => statementItems[1].Accept(visitor)).MustHaveHappened(Repeated.Exactly.Once);
			A.CallTo(() => statementItems[2].Accept(visitor)).MustHaveHappened(Repeated.Exactly.Once);

		}

	}
}
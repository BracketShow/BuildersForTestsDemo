using System;

namespace Banking.Tests
{
    public class TestBuilders
    {
        protected class AccountBuilder : BuilderBase<Account>
        {
            public AccountBuilder(Func<Account> item) : base(item)
            {
            }

            public AccountBuilder WithBalance(decimal balance)
            {
                With(a => a.Balance = balance);
                return this;
            }
        }

        protected AccountBuilder DefaultAccount(int number) => new AccountBuilder(() => new Account()
        {
            Number = number
        });
    }
}
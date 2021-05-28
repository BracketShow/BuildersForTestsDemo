using System;

namespace Banking.Tests
{
    internal class AccountBuilder : Builder<AccountBuilder, Account>
    {
        private static int _lastNumber = 0;

        public AccountBuilder(int? number = null)
        {
            As(() => new Account(number ?? ++_lastNumber));
            _lastNumber = number ?? _lastNumber;
        }

        public AccountBuilder WithBalance(decimal balance)
        {
            With(a => a.Deposit(balance));
            return this;
        }

        public AccountBuilder WithDescription(string description)
        {
            With(a => a.Description = description);
            return this;
        }
    }
}
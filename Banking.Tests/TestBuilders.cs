﻿using System;

namespace Banking.Tests
{
    public class TestBuilders
    {
        protected class AccountBuilder
        {
            private readonly Account _account;

            public AccountBuilder(Account account) => _account = account;

            protected AccountBuilder With(Action<Account> action)
            {
                action(_account);
                return this;
            }

            protected Account Build() => _account;
        }

        protected AccountBuilder DefaultAccount(int number) => new AccountBuilder(new Account()
        {
            Number = number
        });
    }
}
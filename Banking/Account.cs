using System;

namespace Banking
{
    public class Account
    {
        private decimal _balance;
        private string _description;

        public Account(int number, AccountType type = AccountType.Checking)
        {
            Number = number;
            Type = type;
        }

        public decimal Balance => _balance;

        public string Description
        {
            get => _description;
            set => _description = value;
        }

        public int Number { get; }

        public AccountType Type { get; }

        public void Withdraw(decimal amount)
        {
            if (_balance > amount)
            {
                _balance -= amount;
                Console.WriteLine(Resource.Account_Withdraw_Withdraw_of__0__from_account__1_, amount, Number);
            }
            else
                throw new InsufficientFundException();
        }

        public void Deposit(decimal amount)
        {
            _balance += amount;
            Console.WriteLine(Resource.Account_Deposit_Deposit_of__0__in_account__1_, amount, Number);
        }

        public Fund Transfer(decimal amount)
        {
            _balance -= amount;
            return new Fund(amount);
        }

        public class Fund
        {
            private readonly decimal _amount;

            internal Fund(decimal amount)
            {
                _amount = amount;
            }

            public void To(Account account)
            {
                account.Deposit(_amount);
            }
        }
    }
}
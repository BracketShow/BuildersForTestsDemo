using System;

namespace Banking
{
    public class Account
    {
        public decimal Balance { get; set; }

        public int Number { get; set; }

        public AccountType Type { get; set; }

        public void Withdraw(decimal amount)
        {
            if (Balance > amount)
            {
                Balance -= amount;
                Console.WriteLine(Resource.Account_Withdraw_Withdraw_of__0__from_account__1_, amount, Number);
            }
            else
                throw new InsufficientFundException();
        }

        public void Deposit(decimal amount)
        {
            Balance += amount;
            Console.WriteLine(Resource.Account_Deposit_Deposit_of__0__in_account__1_, amount, Number);
        }

        public Fund Transfer(decimal amount)
        {
            Balance -= amount;
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
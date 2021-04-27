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
                Balance -= amount;
            else
                throw new InsufficientFundException();
        }

        public void Deposit(decimal amount)
        {
            Balance += amount;
        }

        public Fund Transfer(decimal amount)
        {
            Balance -= amount;
            return new Fund(amount);
        }

        public class Fund
        {
            private readonly decimal _amount;

            public Fund(decimal amount)
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
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
    }
}
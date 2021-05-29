using System;
using System.Xml.Serialization;
using FluentAssertions;
using Xunit;

namespace Banking.Tests
{
    public class BankingTests
    {
        [Fact]
        public void Withdraw_Amount_Greater_Than_Balance_Should_Throw_InsufficientFundException()
        {
            // Arrange
            var account = new Account(1);
            account.Deposit(1000);

            // Act
            Action action = account.Invoking(a => a.Withdraw(2000));

            // Assert
            action.Should().Throw<InsufficientFundException>();
        }

        [Fact]
        public void Creating_default_account_should_work()
        {
            // Act
            Account account = new AccountBuilder(1);

            // Assert
            account.Number.Should().Be(1);
            account.Balance.Should().Be(0);
            account.Type.Should().Be(AccountType.Checking);
        }

        [Fact]
        public void Transfer_amount_should_update_both_account()
        {
            // Arrange 
            Account account1 = new AccountBuilder(1).With(a => a.Deposit(1000));
            Account account2 = new AccountBuilder();

            // Act
            account1.Transfer(200).To(account2);

            // Assert
            account1.Balance.Should().Be(800);
            account1.Number.Should().Be(1);
            account2.Balance.Should().Be(200);
            account2.Number.Should().Be(2);
        }
    }
}

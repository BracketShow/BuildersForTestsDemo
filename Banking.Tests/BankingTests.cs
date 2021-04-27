using System;
using System.Xml.Serialization;
using FluentAssertions;
using Xunit;

namespace Banking.Tests
{
    public class BankingTests : TestBuilders
    {
        [Fact]
        public void Withdraw_Amount_Grater_Than_Balance_Should_Throw_InsufficientFundException()
        {
            // Arrange
            var account = new Account()
            {
                Number = 1,
                Type = AccountType.Checking,
                Balance = 1000
            };

            // Act
            var action = account.Invoking(a => a.Withdraw(2000));

            // Assert
            action.Should().Throw<InsufficientFundException>();
        }

        [Fact]
        public void Creating_default_account_should_work()
        {
            // Act
            var account = DefaultAccount(1).Build();

            // Assert
            account.Number.Should().Be(1);
            account.Balance.Should().Be(0);
            account.Type.Should().Be(AccountType.Checking);
        }

        [Fact]
        public void Transfer_amount_should_update_both_account()
        {
            // Arrange 
            var account1 = DefaultAccount(1).With(a => a.Balance = 1000).Build();
            var account2 = DefaultAccount(2).Build();

            // Act
            account1.Transfer(200).To(account2);

            // Assert
            account1.Balance.Should().Be(800);
            account2.Balance.Should().Be(200);
        }
    }
}

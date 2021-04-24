using System;
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
    }
}

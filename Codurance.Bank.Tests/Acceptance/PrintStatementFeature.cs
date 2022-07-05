using Moq;
using NUnit.Framework;

namespace Codurance.Bank.Tests.Acceptance;

public class PrintStatementFeature
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Print_statement_showing_multiple_withdraws_and_deposits()
    {
        var accountService = new AccountService();
        var testConsoleMock = new Mock<IConsoleService>();

        accountService.Deposit(100);
        accountService.Withdraw(50);

        accountService.PrintStatement();

        const string header = "DATE | AMOUNT | BALANCE";
        const string withdrawStatement = "05/07/2022 | -50 | 50";
        const string depositStatement = "05/07/2022 | 100 | 100";
        
        testConsoleMock.Verify(c => c.WriteMessage(header), Times.Once());
        testConsoleMock.Verify(c => c.WriteMessage(withdrawStatement), Times.Once());
        testConsoleMock.Verify(c => c.WriteMessage(depositStatement), Times.Once());
    }
}

public class AccountService
{
    public void Deposit(int amount)
    {
        throw new System.NotImplementedException();
    }

    public void Withdraw(int amount)
    {
        throw new System.NotImplementedException();
    }

    public void PrintStatement()
    {
        
    }
}

public interface IConsoleService
{
    void WriteMessage(string statement);
}
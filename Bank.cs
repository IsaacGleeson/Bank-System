using System;
using SplashKitSDK;
using System.Collections.Generic;

public class Bank
{
    private static List<Account> _accounts = new List<Account>();
    private List<Transaction> _transactions = new List<Transaction>();

    public void addAccount(Account account)
    {
        _accounts.Add(account);
    }
    
    public Account GetAccount(string name)
    {
        foreach ( Account value in _accounts )
        {
            if (value.Name == name)
            {
                return value;
            }
        }
        return null;
    }

    public void ExecuteTransaction(Transaction transaction)
    {
        _transactions.Add(transaction);
        transaction.Execute();
    }

    public void PrintTransactionHistory()
    {
        foreach ( Transaction transaction in _transactions)
        {
            Console.WriteLine(transaction);
        }
    }
}




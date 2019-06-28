using System;
using SplashKitSDK;
public class WithdrawTransaction : Transaction
{
    private Account _account;
    private bool _success = false;

    public override bool Success
    {
        get
        {
            return _success;
        }
    }

    public WithdrawTransaction(Account account, decimal amount) : base(amount)
    {
        _account = account;
        _amount = amount;
    
    }

    public override void Print()
    {
        Console.WriteLine(_account);
        Console.WriteLine(_amount);
    }

    public override void Execute()
    {
        base.Execute();
        _success = _account.Withdraw(_amount);
 
    }

    public override void Rollback()
    {
        base.Rollback();
        _success = _account.Deposit(_amount);
    
    }
}
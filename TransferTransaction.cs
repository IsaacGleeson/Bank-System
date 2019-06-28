using System;
using SplashKitSDK;

public class TransferTransaction : Transaction
{
    private Account _toAccount;
    private Account _fromAccount;

    private DepositTransaction _theDeposit;
    private WithdrawTransaction _theWithdraw;
    private bool _success = false;

    public TransferTransaction(Account fromAccount, Account toAccount, decimal amount) : base(amount)
    {
        _amount = amount;
        _toAccount = toAccount;
        _fromAccount = fromAccount;

        _theWithdraw = new WithdrawTransaction(fromAccount, amount);
        _theDeposit = new DepositTransaction(toAccount, amount);

    }

    public override bool Success
    {
        get
        {
            return _success;
        }
    }

    public override void Print()
    {
        decimal X = _amount;
        Console.WriteLine("Transfered $" + X + " From the account.");

    }

    public override void Execute()
    {
        
        _theWithdraw.Execute();
        if (_theWithdraw.Success == true)
        {
            _theDeposit.Execute();
            if (_theDeposit.Success != true)
            {
                _theDeposit.Rollback();
            }
            else
            {
                base.Execute();
                _success = true;
            }
        }
        
    }

    public override void Rollback()
    {

        if (_theWithdraw.Success == false)
        {
            _theWithdraw.Rollback();
        }

        if (_theDeposit.Success == false)
        {
            _theDeposit.Rollback();
        }
        
        base.Rollback();
    }
}

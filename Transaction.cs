using System;
using SplashKitSDK;

public abstract class Transaction 
{
    protected decimal _amount;
    private bool _executed;
    private bool _reversed;
    private DateTime _dateStamp;

    public Transaction(decimal amount) 
    {
        amount = _amount;
    }

    public abstract bool Success
    {
        get;
    }

    public bool Reversed
    {
        get
        {
            return _reversed;
        }
    }

    public bool Executed
    {
        get
        {
            return _executed;
        }
    }

    public DateTime DateStamp()
    {
        return _dateStamp;
    }

    public abstract void Print();

    public virtual void Execute()
    {
        
        if( _executed )
        {
            throw new Exception("Transaction has already been executed");
        }

        _executed = true;
        _dateStamp = DateTime.Now;
    }

    public virtual void Rollback()
    {
        if ( ! _executed )
        {
            throw new Exception("Transaction has been rolled back");
        }

        _reversed = true;
        _dateStamp = DateTime.Now;
    }
}
using System;
using SplashKitSDK;

public class Account
{
    public decimal _balance;
    public string _name;

    public Account (string name, decimal Balance)
    {
        _balance = Balance;
        _name = name;
    }

    public void Print()
    {   
        Console.WriteLine(_name + " " + _balance);
    }

     public string Name
    {
        get { return _name; }
    }

    public bool Deposit(decimal amountToDeposit)
    {   
        
        if (amountToDeposit > 0 && amountToDeposit > 0)
        {
            _balance = _balance + amountToDeposit;
            return true;

        }
        return false;
    }

    public bool Withdraw(decimal amountToTake)
    {   

        if (amountToTake < _balance && amountToTake > 0)
        {
            _balance = _balance - amountToTake;
            return true;

        }
        return false;
    }

   
}






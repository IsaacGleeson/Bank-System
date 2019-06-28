using System;
using SplashKitSDK;
using System.Collections.Generic;

public enum MenuOption
{
    Withdraw,
    Deposit,
    Print,
    Transfer,
    PrintTransfer,
    NewAccount,
    Quit,
}
public class Program
{
    public decimal _balance;
    public string _name;

    public static void Main()
    {  
        MenuOption userSelection;

        Account account1 = new Account ("Isaac", 1000);
        Account account2 = new Account ("Tim", 1000);

        Bank Bank = new Bank();
        Bank.addAccount(account1);
        Bank.addAccount(account2);
        
        do
        {   
            userSelection = ReadUserOption();
            
            Console.WriteLine("How can I help you today?");

            switch(userSelection)
            {
                case MenuOption.Withdraw:
                    DoWithdraw(Bank);
                    DoPrint(Bank);
                    break;
                case MenuOption.Deposit:
                    DoDeposit(Bank);
                    DoPrint(Bank);
                    break;
                case MenuOption.Print:
                    DoPrint(Bank);
                    break;
                case MenuOption.Transfer:
                    DoTransfer(Bank);
                    Console.WriteLine("Transfer successful");
                    break;
                case MenuOption.PrintTransfer:
                    DoPrintTransactionHistory(Bank);
                    break;
                case MenuOption.NewAccount:
                    Console.WriteLine("Enter new name for the account: ");
                    string _newName = Console.ReadLine();
                    Console.WriteLine("Enter new Amount: ");

                    decimal _newAmount = Convert.ToDecimal(Console.ReadLine());
                    Account _new = new Account(_newName, _newAmount);
                    
                    Bank.addAccount(_new);
                    Console.WriteLine("New account added");
                    Console.WriteLine(_new);
                    break;
                case MenuOption.Quit:
                    return;  
            }

        }  while (userSelection != MenuOption.Quit);
    }

    private static MenuOption ReadUserOption()
    {
        int option = 0;
        String inputText;
        do
        {
            Console.WriteLine("1: Withdrawl");
            Console.WriteLine("2: Deposit");
            Console.WriteLine("3: Print");
            Console.WriteLine("4: Transfer");
            Console.WriteLine("5: Print Transfer History");
            Console.WriteLine("6: Add Account");
            Console.WriteLine("7: Quit");
            Console.WriteLine("Choose your option: ");
            try
            {
                inputText = Console.ReadLine();
                option = Convert.ToInt32(inputText); 
            }
            catch(System.FormatException)
            {
                Console.WriteLine("Not a number");
            }

         return (MenuOption)(option - 1);
        } while (option < 7);
    }

    private static void DoTransfer(Bank toBank)
    {
        Account toAccount; 
        Account fromAccount;
        String input;
        decimal transfer = 0; 

        Console.WriteLine("Which account do you wish to transfer from?: ");
        fromAccount = FindAccount(toBank);

        Console.WriteLine("Which account do you wish to transfer To?: ");
        toAccount = FindAccount(toBank);

        Console.WriteLine("How much would you like to transfer?: ");

        try
        {
            input = Console.ReadLine();
            transfer = Convert.ToDecimal(input);
        }
        catch(System.FormatException)
        {
            Console.WriteLine("Not a number");
        }
        
        TransferTransaction transferT = new TransferTransaction (toAccount, fromAccount, transfer);
        toBank.ExecuteTransaction(transferT);
        transferT.Print();    
    }
    
    private static void DoDeposit(Bank toBank)
    {
        Account toAccount = FindAccount(toBank);
        if (toAccount == null) return;

        String input;
        decimal deposit = 0;

        Console.WriteLine("How much would you like to deposit?: ");

        try
        {
            input = Console.ReadLine();
            deposit = Convert.ToDecimal(input);
        }
        catch(System.FormatException)
        {
            Console.WriteLine("Not a number");
        }
        
        DepositTransaction depositT = new DepositTransaction (toAccount, deposit);
        toBank.ExecuteTransaction(depositT);
        depositT.Print();    
    }

    private static void DoWithdraw(Bank fromBank)
    {
        Account toBank = FindAccount(fromBank);
        if (toBank == null) return;

        String input;
        decimal withdraw = 0;

        Console.WriteLine("How much would you like to withdraw?: ");
        input = Console.ReadLine();
        withdraw = Convert.ToDecimal(input);
        
        try
        {
            input = Console.ReadLine();
            withdraw = Convert.ToDecimal(input);
        }
        catch(System.FormatException)
        {
            Console.WriteLine("Not a number");
        }

        WithdrawTransaction withdrawT = new WithdrawTransaction (toBank, withdraw);
        fromBank.ExecuteTransaction(withdrawT);
        withdrawT.Print();    
    }

    private static void DoPrint(Bank toBank)
    {
        Account toAccount = FindAccount(toBank);
        if (toAccount == null) return;
        toAccount.Print();
         
    }

    private static void DoPrintTransactionHistory(Bank toBank)
    {
        toBank.PrintTransactionHistory();
    }

    private static Account FindAccount (Bank fromBank)
    {
        Console.Write("Enter account name: ");
        String name = Console.ReadLine();
        Account result = fromBank.GetAccount(name);

        if ( result == null )
        {
            Console.WriteLine($"No account found with name {name}");
        }

        return result;
    }
}



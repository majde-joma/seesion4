using System;
using System.Collections.Generic;

// Structure to hold individual account data
class Account
{
    public string Name { get; set; }
    public string PIN { get; set; }
    public double Balance { get; set; }
    public List<string> Transactions { get; set; } = new List<string>();
}

class ATMBankingSystem
{
    // Dictionary to store accounts: Key = Account Number
    static Dictionary<string, Account> accounts = new Dictionary<string, Account>();
    static Account loggedInUser = null;

    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("--- Welcome to the ATM System ---");

            if (loggedInUser == null)
            {
                // Main Menu
                Console.WriteLine("1. Create a new account");
                Console.WriteLine("2. Login");
                Console.WriteLine("3. Exit");
                Console.Write("\nSelect an option: ");
                string choice = Console.ReadLine();

                if (choice == "1") CreateAccount();
                else if (choice == "2") Login();
                else if (choice == "3") break;
            }
            else
            {
                // Logged-in Menu
                Console.WriteLine($"\nHello, {loggedInUser.Name}");
                Console.WriteLine("1. Check Balance");
                Console.WriteLine("2. Deposit Money");
                Console.WriteLine("3. Withdraw Money");
                Console.WriteLine("4. View Transaction History");
                Console.WriteLine("5. Logout");
                Console.Write("\nSelect an option: ");
                string choice = Console.ReadLine();

                if (choice == "1") Console.WriteLine($"Current Balance: {loggedInUser.Balance:C}");
                else if (choice == "2") Deposit();
                else if (choice == "3") Withdraw();
                else if (choice == "4") ViewHistory();
                else if (choice == "5") loggedInUser = null;

                if (choice != "5") { Console.WriteLine("\nPress Enter to continue..."); Console.ReadLine(); }
            }
        }
    }

    static void CreateAccount()
    {
        Console.Write("Enter your name: ");
        string name = Console.ReadLine();
        Console.Write("Set a 4-digit PIN: ");
        string pin = Console.ReadLine();

        // Generate a random 6-digit account number
        string accNum = new Random().Next(100000, 999999).ToString();

        accounts.Add(accNum, new Account { Name = name, PIN = pin, Balance = 0 });

        Console.WriteLine($"\nAccount created successfully! Your Account Number is: {accNum}");
        Console.WriteLine("Press Enter to return to menu...");
        Console.ReadLine();
    }

    static void Login()
    {
        Console.Write("Enter Account Number: ");
        string accNum = Console.ReadLine();
        Console.Write("Enter PIN: ");
        string pin = Console.ReadLine();

        if (accounts.ContainsKey(accNum) && accounts[accNum].PIN == pin)
        {
            loggedInUser = accounts[accNum];
            Console.WriteLine("\nLogin Successful!");
        }
        else
        {
            Console.WriteLine("\nInvalid Account Number or PIN.");
            Console.ReadLine();
        }
    }

    static void Deposit()
    {
        Console.Write("Enter amount to deposit: ");
        if (double.TryParse(Console.ReadLine(), out double amount) && amount > 0)
        {
            loggedInUser.Balance += amount;
            loggedInUser.Transactions.Add($"{DateTime.Now}: Deposited {amount:C}. New Balance: {loggedInUser.Balance:C}");
            Console.WriteLine("Deposit successful.");
        }
    }

    static void Withdraw()
    {
        Console.Write("Enter amount to withdraw: ");
        if (double.TryParse(Console.ReadLine(), out double amount) && amount > 0)
        {
            if (amount <= loggedInUser.Balance)
            {
                loggedInUser.Balance -= amount;
                loggedInUser.Transactions.Add($"{DateTime.Now}: Withdrew {amount:C}. New Balance: {loggedInUser.Balance:C}");
                Console.WriteLine("Withdrawal successful.");
            }
            else Console.WriteLine("Insufficient funds.");
        }
    }

    static void ViewHistory()
    {
        Console.WriteLine("\n--- Transaction History ---");
        if (loggedInUser.Transactions.Count == 0) Console.WriteLine("No transactions yet.");
        foreach (var t in loggedInUser.Transactions) Console.WriteLine(t);
    }
}

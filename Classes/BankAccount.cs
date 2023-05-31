namespace Classes;

public class BankAccount
{
    // It's also static, which means it's shared by all of the BankAccount objects.
    // The value of a non-static variable is unique to each instance of the BankAccount object.
    private static int _accountNumberSeed = 1234567890;

    public string Number { get; }
    public string Owner { get; set; }
    public decimal Balance
    {
        get
        {
            decimal balance = 0;
            foreach (var item in _allTransactions)
            {
                balance += item.Amount;
            }
            return balance;
        }
    }

    public BankAccount(string name, decimal initialBalance)
    {
        Number = _accountNumberSeed.ToString();
        _accountNumberSeed++;

        Owner = name;
        MakeDeposit(initialBalance, DateTime.Now, "Initial balance");
    }

    private List<Transaction> _allTransactions = new List<Transaction>();

    // The throw statement throws an exception.
    // Execution of the current block ends, and control transfers to the first matching catch block found in the call stack. 

    public void MakeDeposit(decimal amount, DateTime date, string note)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be greater than 0");
        }
        var deposit = new Transaction(amount, date, note);
        _allTransactions.Add(deposit);
    }

    public void MakeWithdrawal(decimal amount, DateTime date, string note)
    {
        if (amount <=0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be greater than 0");
        }
        if (Balance - amount < 0)
        {
            throw new InvalidOperationException("Insufficient funds for this withdrwawal");
        }
        var withdrawal = new Transaction(-amount, date, note);
        _allTransactions.Add(withdrawal);
    }
}
namespace Classes;

public class BankAccount
{
    // It's also static, which means it's shared by all of the BankAccount objects.
    // The value of a non-static variable is unique to each instance of the BankAccount object.
    private static int _accountNumberSeed = 1234567890;

    public string Number { get; }
    public string Owner { get; set; }
    public decimal Balance { get; set; }

    public BankAccount(string name, decimal initialBalance)
    {
        this.Owner = name;
        this.Balance = initialBalance;
        this.Number = _accountNumberSeed.ToString();
        _accountNumberSeed++;
    }

    public void MakeDeposit(decimal amount, DateTime date, string note)
    {

    }

    public void MakeWithdrawal(decimal amount, DateTime date, string note)
    {

    }
}
using Classes;

var account = new BankAccount("Ronnie", 1000);
var account2 = new BankAccount("Shun", 10000);
Console.WriteLine($"Account {account.Number} was created for {account.Owner} with {account.Balance} initial balance.");
Console.WriteLine($"Account {account2.Number} was created for {account2.Owner} with {account2.Balance} initial balance.");
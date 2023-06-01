namespace Inheritance;

public sealed class Book : Publication
{
    // The first constructor uses the this keyword to call the other constructor. Constructor chaining is a common pattern in defining constructors.
    // Constructors with fewer parameters provide default values when calling the constructor with the greatest number of parameters.
    public Book(string title, string author, string publisher) :
        this(title, string.Empty, author, publisher)
    {  }

    public Book(string title, string isbn, string author, string publisher) : base(title, publisher, PublicationType.Book)
    {
        // another way to validate isbn length would be to compare its checksum digit to a computed checksum
        if (!string.IsNullOrEmpty(isbn))
        {
            if (!(isbn.Length == 10 | isbn.Length == 13))
                throw new ArgumentException("the ISBN must be a 10 or 13-character numeric string");
            // The primitive data types prefixed with "u" are unsigned versions with the same bit sizes.
            // Effectively, this means they cannot store negative numbers, but on the other hand they can store positive numbers twice as large as their signed counterparts.
            // The signed counterparts do not have "u" prefixed.
            // https://stackoverflow.com/questions/3724242/what-is-the-difference-between-int-and-uint-long-and-ulong

            if (!ulong.TryParse(isbn, out _))
                throw new ArgumentException("the ISBN can consist of numeric characters only");
        }
        ISBN = isbn;

        author = author;
    }

    public string ISBN { get; }
    public string Author { get; }
    public decimal Price { get; private set; }
    public string? Currency { get; private set; }

    public decimal SetPrice(decimal price, string currency)
    {
        if (price < 0)
            throw new ArgumentOutOfRangeException(nameof(price), "the price cannot be negative");
        decimal oldValue = Price;
        Price = price;

        if (currency.Length != 3)
            throw new ArgumentException("the ISO currency symbol is a 3-character string");
        Currency = currency;

        return oldValue;
    }

    // Unless it is overridden, the Object.Equals(Object) method tests for reference equality.
    // That is, two object variables are considered to be equal if they refer to the same object.
    // In the Book class, on the other hand, two Book objects should be equal if they have the same ISBN.
    public override bool Equals(object? obj)
    {
        if (obj is not Book book)
            return false;
        else return ISBN == book.ISBN;
    }

    // When you override the Object.Equals(Object) method, you must also override the GetHashCode method, which returns a value that the runtime uses to store items in hashed collections for efficient retrieval. The hash code should return a value that's consistent with the test for equality.
    // Since you've overridden Object.Equals(Object) to return true if the ISBN properties of two Book objects are equal, you return the hash code computed by calling the GetHashCode method of the string returned by the ISBN property.

    public override int GetHashCode() => ISBN.GetHashCode();
    public override string ToString() => $"{(string.IsNullOrEmpty(Author) ? "" : Author + ", ")}{Title}";
}

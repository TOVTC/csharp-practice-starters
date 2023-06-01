namespace Inheritance;

public abstract class Publication
{
	private bool _published = false;
	private DateTime _datePublished;
	private int _totalPages;

	public Publication(string title, string publisher, PublicationType type)
	{
		if (string.IsNullOrWhiteSpace(publisher))
			throw new ArgumentException("The publisher is required.");
		Publisher = publisher;

		if (string.IsNullOrWhiteSpace(title))
			throw new ArgumentException("The title is required");
		Title = title;

		Type = type;
	}

	public string Publisher { get; }
	public string Title { get; }
	public PublicationType Type { get; }
	public string? CopyrightName { get; private set; }
	public int CopyrightDate { get; private set; }
	public int Pages
	{
		get { return _totalPages; }
		set
		{
			if (value <= 0)
				throw new ArgumentOutOfRangeException(nameof(value), "The number of pages cannot be 0.");
			_totalPages = value;
		}
	}
	
	public string GetPublicationDate()
	{
		if (!_published)
			return "NYP";
		else
			return _datePublished.ToString("d");
	}

	public void Publish(DateTime datePublished)
	{
		_published = true;
		_datePublished = datePublished;
	}

	public void Copyright(string copyrightName, int copyrightDate)
	{
		if (string.IsNullOrWhiteSpace(copyrightName))
			throw new ArgumentException("the name of the copyright holder is required");
		CopyrightName = copyrightName;

		int currentYear = DateTime.Now.Year;
		if (copyrightDate < currentYear - 10 || copyrightDate > currentYear + 2)
			throw new ArgumentOutOfRangeException($"the copyright year must be between {currentYear - 10} and {currentYear + 1}");
		CopyrightDate = copyrightDate;
	}

    // If a type does not override the Object.ToString method, it returns the fully qualified name of the type, which is of little use in differentiating one instance from another.
	// The Publication class overrides Object.ToString to return the value of the Title property.
    public override string ToString() => Title;
}

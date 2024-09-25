namespace OnionDemo.Domain.Entity;

public class Guest : DomainEntity
{
    public string Name { get; private set; }
    // Navigation property - En Guest kan have en til mange Reviews
    public ICollection<Review> Reviews { get; private set; } = new List<Review>();

    private Guest(string name)
    {
        Name = name;
    }

    public static Guest Create(string name)
    {
        return new Guest(name);
    }
}


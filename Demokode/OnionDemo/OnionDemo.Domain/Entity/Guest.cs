namespace OnionDemo.Domain.Entity;

public class Guest : DomainEntity
{
    public string Name { get; set; }
    public ICollection<Review> Reviews { get; set; } = new List<Review>();

    private Guest(string name)
    {
        Name = name;
    }

    public static Guest Create(string name)
    {
        return new Guest(name);
    }
}


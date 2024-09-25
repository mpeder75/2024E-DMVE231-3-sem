#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning disable CS0649 // Field is never assigned to, and will always have its default value
namespace OnionDemo.Domain.Entity;

public class Host : DomainEntity
{
    private readonly List<Accommodation>? _accommodations;

    public string Name { get; set; }

    // read-only property for Accommodations - Navigation property
    public IReadOnlyCollection<Accommodation> Accommodations => _accommodations ?? [];
}
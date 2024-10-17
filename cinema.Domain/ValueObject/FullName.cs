namespace cinema.Domain.ValueObject;

public class FullName : BaseValueObject
{
    public string firstName { get; set; }
    public string lastName { get; set; }
    
    public FullName(string? firstName,  string? lastName)
    {
        this.firstName = firstName;
        this.lastName = lastName;
    }
}
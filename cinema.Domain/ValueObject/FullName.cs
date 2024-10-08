namespace cinema.Domain.ValueObject;

public class FullName : BaseValueObject
{
    public string firstName { get; set; }
    public string? middleName { get; set; } = null;
    public string lastName { get; set; }
    
}
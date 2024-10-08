using System.Text.Json;

namespace cinema.Domain.ValueObject;

public class BaseValueObject
{
    public override bool Equals(object? obj)
    {
        if (obj is not BaseValueObject baseValueObject)
            return false;
        var serializedValueObject = Serialize(baseValueObject);
        var serializedThisValueObject = Serialize(this);

        return string.CompareOrdinal(serializedValueObject, serializedThisValueObject) == 0;
    }

    public override int GetHashCode()
    {
        return Serialize(this).GetHashCode();
    }
    
    public string Serialize(BaseValueObject baseValueObject)
    {
        var serializedValueObject = JsonSerializer.Serialize(baseValueObject);
        return serializedValueObject;
    }
}
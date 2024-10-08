namespace cinema.Application.DTOs.User;

public record RegisterRequest
{
     public FullNameDto fullName { get; init; }
     public string email { get; init; }
     public string password { get; init; }
}
namespace cinema.Application.DTOs.User;

public record RegisterationRequest
{
     public FullNameDto fullName { get; init; }
     public string email { get; init; }
     public string role { get; init; }
     public string password { get; init; }
}
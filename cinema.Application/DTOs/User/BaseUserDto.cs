namespace cinema.Application.DTOs.User;

public class BaseUserDto
{
    public FullNameDto fullName { get; init; }
    public string email { get; init; }
    public string token { get; init; }
}
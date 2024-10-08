namespace cinema.Application.DTOs.User.Reaponce;

public class LoginResponce
{
    public Guid Id { get; set; }
    public FullNameDto fullName { get; init; }
    public string email { get; init; }
    public string token { get; init; }
}
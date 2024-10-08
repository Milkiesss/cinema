namespace cinema.Application.DTOs.User.Reaponce;

public class RegisterResponce
{
    public Guid Id { get; set; }
    public FullNameDto fullName { get; set; }
    public string email { get; set; }
    public string token { get; set; }
}
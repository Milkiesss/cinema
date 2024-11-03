using cinema.Domain.Enums;

namespace cinema.Application.DTOs.User;

public class BaseUserDto
{
    public FullNameDto fullName { get; set; }  
    public string email { get; set; }
    public string password { get; set; }
    public DateTime birthDate { get; set; }
    public EnumRole role { get; set; }
}
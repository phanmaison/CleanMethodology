namespace CleanMethodology.Application.Contracts.Entities.Users;

public class UserEntity
{
    public int UserId { get; set; }
    public string Username { get; set; } = string.Empty;
    public string PasswordSalt { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}

using CleanMethodology.Application.Contracts.Entities.Users;
using CleanMethodology.Application.Contracts.Repositories;
using CleanMethodology.Core.Exceptions;

namespace CleanMethodology.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private static readonly List<UserEntity> _users =
    [
        CreateTestUser(1),
        CreateTestUser(2),
        CreateTestUser(3),
        CreateTestUser(4),
        CreateTestUser(5)
    ];

    private static UserEntity CreateTestUser(int userId) => new()
    {
        UserId = userId,
        Username = $"test_{userId}",
        Email = $"test_{userId}@email.com",
        FullName = $"Test {userId}",
    };

    public Task ValidateUserAsync(UserEntity user)
    {
        if (string.IsNullOrEmpty(user.Username))
            throw new RequiredFieldException(nameof(user.Username));

        if (string.IsNullOrEmpty(user.Email))
            throw new RequiredFieldException(nameof(user.Username));

        if (_users.Any(x => x.UserId != user.UserId &&
            x.Username.Equals(user.Username, StringComparison.OrdinalIgnoreCase)))
        {
            throw new BusinessException($"Username '{user.Username}' already exists");
        }

        return Task.CompletedTask;
    }
}

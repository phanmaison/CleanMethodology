using CleanMethodology.Application.Contracts.Entities.Users;

namespace CleanMethodology.Application.Contracts.Repositories;

public interface IUserRepository
{
    // validate and throw exception if any
    Task ValidateUserAsync(UserEntity user);

    Task<UserEntity> CreateUserAsync(UserEntity user);

    Task<List<UserEntity>> ListUserAsync();

}

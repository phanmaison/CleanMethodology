using CleanMethodology.Application.Contracts.Entities.Users;
using CleanMethodology.Application.Contracts.Repositories;

namespace CleanMethodology.Application.Domains.User;

public class UserListUsecase(IUserRepository _userRepository)
{
    public async Task<List<UserEntity>> ExecuteAsync()
    {
        var users = await _userRepository.ListUserAsync();

        return users;
    }

    public class Request
    {
        // search / paging criteria
    }
}

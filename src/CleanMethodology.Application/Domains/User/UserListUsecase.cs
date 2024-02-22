using CleanMethodology.Application.Contracts.Entities.Users;
using CleanMethodology.Application.Contracts.Repositories;

namespace CleanMethodology.Application.Domains.User;

public class UserListUsecase
{
    private readonly IUserRepository _userRepository;


    public UserListUsecase(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

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

using CleanMethodology.Application.Contracts.Entities.Users;
using CleanMethodology.Application.Contracts.Repositories;

namespace CleanMethodology.Application.Domains.User;

public class UserCreateUsecase
{
    public Task ExecuteAsync()
    {
        return Task.CompletedTask;
    }
}

/**
 * Create the usecase that map to a business requirement
 */
public class Step1_DefineBusinessLogic
{
    public Task<Response> ExecuteAsync(Request request)
    {
        // validate input

        // persist the user into datasource

        // send email to user

        return Task.FromResult(new Response());
    }

    public class Request()
    {
    }

    public class Response()
    {
    }
}

/**
 * Define the input (Request) and output (Response) of the usecase
 */
public class Step2_DefineModel
{
    public Task<Response> ExecuteAsync(Request request)
    {
        // validate input

        // persist the user into datasource

        // send email to user

        return Task.FromResult(new Response());
    }

    public class Request
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }

    public class Response
    {
        public int UserId { get; set; }
        public string Username { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}

/**
 * Implement a specific action of the usecase: e.g. validate input
 */
public class Step3_Action1
{
    private readonly IUserRepository _userRepository;

    public Step3_Action1(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Response> ExecuteAsync(Request request)
    {
        var entity = request.ToUserEntity();

        // validate input
        await _userRepository.ValidateUserAsync(entity);

        // persist the user into datasource

        // send email to user

        return new Response();
    }

    public class Request
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public UserEntity ToUserEntity() => new()
        {
            Username = Username,
            PasswordHash = Password,
            FullName = FullName,
            Email = Email
        };
    }

    public class Response
    {
        public int UserId { get; set; }
        public string Username { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
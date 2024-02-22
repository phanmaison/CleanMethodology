using CleanMethodology.Application.Contracts.Entities.Users;
using CleanMethodology.Application.Contracts.Repositories;
using CleanMethodology.Application.Contracts.Services;

namespace CleanMethodology.Application.Domains.User;

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
    private readonly IEmailTemplateService _emailTemplateService;
    private readonly IEmailService _emailService;

    public Step3_Action1(
        IUserRepository userRepository,
        IEmailTemplateService emailTemplateService,
        IEmailService emailService)
    {
        _userRepository = userRepository;
        _emailTemplateService = emailTemplateService;
        _emailService = emailService;
    }

    public async Task<UserEntity> ExecuteAsync(Request request)
    {
        var entity = request.ToUserEntity();

        // validate input
        await _userRepository.ValidateUserAsync(entity);

        // persist the user into datasource
        await _userRepository.CreateUserAsync(entity);

        // send email to user
        var emailTemplate = _emailTemplateService.GetUserRegistrationEmail(entity);
        await _emailService.SendEmailAsync(emailTemplate);

        return entity;
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
            FullName = FullName,
            Email = Email
        };
    }
}
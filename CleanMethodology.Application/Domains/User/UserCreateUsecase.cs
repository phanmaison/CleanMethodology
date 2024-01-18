using CleanMethodology.Application.Contracts.Entities.Users;
using CleanMethodology.Application.Contracts.Repositories;
using CleanMethodology.Application.Contracts.Services;

namespace CleanMethodology.Application.Domains.User;

public class UserCreateUsecase
{
    private readonly IUserRepository _userRepository;
    private readonly IEmailTemplateService _emailTemplateService;
    private readonly IEmailService _emailService;

    public UserCreateUsecase(
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

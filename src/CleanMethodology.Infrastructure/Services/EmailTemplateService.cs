using CleanMethodology.Application.Contracts.Entities.Emails;
using CleanMethodology.Application.Contracts.Entities.Users;
using CleanMethodology.Application.Contracts.Services;
using CleanMethodology.Core.Helpers;

namespace CleanMethodology.Infrastructure.Services;

public class EmailTemplateService : IEmailTemplateService
{
    public EmailMessage GetUserRegistrationEmail(UserEntity user)
    {
        LogHelper.Info($"Generating registration email for user {user.FullName}");

        return new EmailMessage
        {
            ToEmail = user.Email,
            Subject = "Registration succecssfully",
            Body = $"Welcome {user.FullName}"
        };
    }
}

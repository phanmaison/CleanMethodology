using CleanMethodology.Application.Contracts.Entities.Emails;
using CleanMethodology.Application.Contracts.Entities.Users;

namespace CleanMethodology.Application.Contracts.Services;

public interface IEmailTemplateService
{
    // Remember ISP & SRP: segregate interfaces in real projects and each interface should have only one reason to change
    public EmailMessage GetUserRegistrationEmail(UserEntity user);
}

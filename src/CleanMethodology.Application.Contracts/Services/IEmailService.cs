using CleanMethodology.Application.Contracts.Entities.Emails;

namespace CleanMethodology.Application.Contracts.Services;

public interface IEmailService
{
    public Task SendEmailAsync(EmailMessage message);
}

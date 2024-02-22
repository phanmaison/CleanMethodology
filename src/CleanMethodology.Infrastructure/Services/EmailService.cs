using CleanMethodology.Application.Contracts.Entities.Emails;
using CleanMethodology.Application.Contracts.Services;
using CleanMethodology.Core.Helpers;

namespace CleanMethodology.Infrastructure.Services;

public class EmailService : IEmailService
{
    public Task SendEmailAsync(EmailMessage message)
    {
        LogHelper.Info($"Sending email to {message.ToEmail} with subject {message.Subject}");

        return Task.CompletedTask;
    }
}

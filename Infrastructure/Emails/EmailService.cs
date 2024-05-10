using Application.Abstractions.Emails;
using Domain.JobCandidates;

namespace Infrastructure.Emails;

internal sealed class EmailService : IEmailService
{
    public Task SendAsync(Email recipient, string subject, string body)
    {
        return Task.CompletedTask;
    }
}

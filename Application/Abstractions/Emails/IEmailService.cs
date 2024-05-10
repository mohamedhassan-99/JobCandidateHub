using Domain.JobCandidates;

namespace Application.Abstractions.Emails;

public interface IEmailService
{
    Task SendAsync(Email recipient, string subject, string body);
}

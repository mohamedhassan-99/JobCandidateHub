using Application.Abstractions.Emails;
using Domain.JobCandidates.Events;
using MediatR;

namespace Application.JobCanidates.CreateCandidate;

public class CandidateCreatedEventHandler(IEmailService emailService) : INotificationHandler<JobCandidateCreatedEvent>
{
    public Task Handle(JobCandidateCreatedEvent notification, CancellationToken cancellationToken)
    {
        emailService.SendAsync(notification.Candidate.Email, "Hi There!", "Congrats you've win the lottery");

        return Task.CompletedTask;
    }
}

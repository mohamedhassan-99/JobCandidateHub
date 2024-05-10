using Application.Abstractions.Emails;
using Domain.JobCandidates.Events;
using MediatR;

namespace Application.JobCanidates.UpdateCandidate;

public class CandidateUpdatedEventHandler(IEmailService emailService) : INotificationHandler<JobCandidateUpdatedEvent>
{
    public Task Handle(JobCandidateUpdatedEvent notification, CancellationToken cancellationToken)
    {
        emailService.SendAsync(notification.Candidate.Email, "Hi There!", "Can you believe it?! .. you've win the lottery again");

        return Task.CompletedTask;
    }
}

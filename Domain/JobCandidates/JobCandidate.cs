using Domain.Common.Contract;
using Domain.JobCandidates.Events;

namespace Domain.JobCandidates;

public class JobCandidate : Entity<JobCandidateId>
{
    private JobCandidate() { }
    public FirstName FirstName { get; private set; }
    public LastName LastName { get; private set; }
    public PhoneNumber? PhoneNumber { get; private set; }
    public Email Email { get; private set; }
    public TimeInterval? CallIn { get; private set; }
    public URL? LinkedIn { get; private set; }
    public URL? GitHub { get; private set; }
    public Comment Comment { get; private set; }

    
    public JobCandidate Update(JobCandidateId id,
        FirstName? firstName,
        LastName? lastName,
        PhoneNumber? phone,
        Email? email,
        TimeInterval? callIn,
        URL? linkedIn,
        URL? gitHub,
        Comment? comment)
    {
        FirstName = firstName ?? FirstName;
        LastName = lastName ?? LastName;
        PhoneNumber = phone ?? PhoneNumber;
        Email = email ?? Email;
        CallIn = callIn ?? CallIn;
        LinkedIn = linkedIn ?? LinkedIn;
        GitHub = gitHub ?? GitHub;
        Comment = comment ?? Comment;

        if(!GetDomainEvents().Any(a => a.GetType() ==  typeof(JobCandidateUpdatedEvent)))
            RaiseDomainEvent(new JobCandidateUpdatedEvent(this));

        return this;
    }
    public static JobCandidate Create(
        FirstName firstName,
        LastName lastName,
        PhoneNumber phone,
        Email email,
        TimeInterval? callIn,
        URL linkedIn,
        URL gitHub,
        Comment comment)
    {
        var jobCandidate = new JobCandidate()
        {
            Id = new(Guid.NewGuid()),
            FirstName = firstName,
            LastName = lastName,
            PhoneNumber = phone,
            Email = email,
            CallIn = callIn,
            LinkedIn = linkedIn,
            GitHub = gitHub,
            Comment = comment
        };

        jobCandidate.RaiseDomainEvent(new JobCandidateCreatedEvent(jobCandidate));

        return jobCandidate;
    }
}

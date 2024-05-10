using Domain.Common.Contract;

namespace Domain.JobCandidates.Events;

public record JobCandidateUpdatedEvent(JobCandidate Candidate) : IDomainEvent;
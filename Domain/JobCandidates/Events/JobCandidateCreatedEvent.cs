using Domain.Common.Contract;

namespace Domain.JobCandidates.Events;

public record JobCandidateCreatedEvent(JobCandidate Candidate) : IDomainEvent;
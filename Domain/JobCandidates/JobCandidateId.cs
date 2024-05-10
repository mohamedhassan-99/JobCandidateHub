namespace Domain.JobCandidates;

public record JobCandidateId(Guid Value)
{
    public static JobCandidateId New() => new(Guid.NewGuid());
}

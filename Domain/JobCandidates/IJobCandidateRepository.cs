namespace Domain.JobCandidates;

public interface IJobCandidateRepository
{
    Task<JobCandidate?> GetByIdAsync(JobCandidateId id, CancellationToken cancellationToken = default);

    void Add(JobCandidate candidate);
}

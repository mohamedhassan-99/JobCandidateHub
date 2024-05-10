namespace Domain.JobCandidates;

public interface IJobCandidateRepository
{
    Task<JobCandidate?> GetByIdAsync(JobCandidateId id, CancellationToken cancellationToken = default);

    Task<IEnumerable<JobCandidate>> GetJobCandidatesAsync(CancellationToken cancellationToken = default);

    Task<IEnumerable<JobCandidate>> GetJobCandidatesPageAsync(int pageNo = 0, int pageSize = 10, CancellationToken cancellationToken = default);

    void Add(JobCandidate booking);

    void UpdateAsync(JobCandidate booking, CancellationToken cancellationToken = default);
}

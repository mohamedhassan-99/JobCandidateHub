using Domain.JobCandidates;

namespace Infrastructure.Repositories;

public class JobCandidateRepository(CandidateContext context) : Repository<JobCandidate, JobCandidateId>(context), IJobCandidateRepository
{
}

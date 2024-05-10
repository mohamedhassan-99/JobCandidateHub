using Domain.Common.Contract;

namespace Domain.JobCandidates;

public class JobCandidate : Entity<JobCandidateId>
{
    public required FirstName FirstName { get; set; }
    public required LastName LastName { get; set; }
    public PhoneNumber PhoneNumber { get; set; }
    public required Email Email { get; set; }
    public TimeInterval CallIn{ get; set; }
    public URL LinkedIn { get; set; }
    public URL GitHub { get; set; }
    public required Comment Comment { get; set; }
}

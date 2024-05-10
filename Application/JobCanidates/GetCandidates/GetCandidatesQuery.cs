using Application.Abstractions.Messaging;

namespace Application.JobCanidates.GetCandidates;

public sealed record GetCandidatesQuery : IQuery<IEnumerable<JobCandidateResponse>>;

using Application.Abstractions.Messaging;
using Application.Shared.Response;

namespace Application.JobCanidates.GetCandidatesPage;

public sealed record GetCandidatesPageQuery(int? PageNo = 0, int? PageSize = 10) : IQuery<PaginatedListResponse<JobCandidateResponse>>;

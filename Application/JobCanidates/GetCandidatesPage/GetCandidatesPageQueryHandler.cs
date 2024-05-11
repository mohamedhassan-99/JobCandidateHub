using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Domain.Common.Contract;
using Dapper;
using Application.Shared.Response;

namespace Application.JobCanidates.GetCandidatesPage;

public class GetCandidatesPageQueryHandler(ISqlConnectionFactory sqlConnectionFactory) : IQueryHandler<GetCandidatesPageQuery, PaginatedListResponse<JobCandidateResponse>>
{
    public async Task<Result<PaginatedListResponse<JobCandidateResponse>>> Handle(GetCandidatesPageQuery request, CancellationToken cancellationToken)
    {
        var take = request.PageSize > 100 ? 100 : request.PageSize;
        var skip = request.PageSize * request.PageNo;
        using var connection = sqlConnectionFactory.CreateConnection();

        const string sql = """
            SELECT [Id]
                  ,[FirstName]
                  ,[LastName]
                  ,[PhoneNumber]
                  ,[Email]
                  ,[CallInFrom] As CallFrom
                  ,[CallInTo] As CallTo
                  ,[LinkedIn]
                  ,[GitHub]
                  ,[Comment]
              FROM [dbo].[JobCandidates]
              ORDER BY [Id] OFFSET @skip ROWS FETCH NEXT @take ROWS ONLY
            """;

        var candidates = await connection.QueryAsync<JobCandidateResponse>(
            sql, new
            {
                skip,
                take,
            });

        return new PaginatedListResponse<JobCandidateResponse>(request.PageNo.Value, take.Value, candidates.ToList());
    }
}

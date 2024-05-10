using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Domain.Common.Contract;
using Dapper;

namespace Application.JobCanidates.GetCandidates;

public class GetCandidateQueryHandler(ISqlConnectionFactory sqlConnectionFactory) : IQueryHandler<GetCandidatesQuery, IEnumerable<JobCandidateResponse>>
{
    public async Task<Result<IEnumerable<JobCandidateResponse>>> Handle(GetCandidatesQuery request, CancellationToken cancellationToken)
    {
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
            """;

        var candidates = await connection.QueryAsync<JobCandidateResponse>(sql);

        return candidates.ToList();
    }
}

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
            SELECT
                Id,
                SUBSTRING([Name], 1, CHARINDEX('-', [Name]) - 1) AS FirstName,
                SUBSTRING([Name], CHARINDEX('-', [Name]) + 1, LEN([Name])) AS LastName,
                PhoneNumber,
                Email,
                LinkedIn,
                GitHub,
                Comment,
                CallInFrom As CallFrom,
                CallInTo As CallTo
            FROM apartments
            """;

        var candidates = await connection.QueryAsync<JobCandidateResponse>(sql);

        return candidates.ToList();
    }
}

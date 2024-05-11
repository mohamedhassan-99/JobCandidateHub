using Application.Abstractions.Data;
using Bogus;
using Dapper;

namespace Host.Extensions
{
    public static class SeedDataExtensions
    {
        public static void SeedData(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();

            var sqlConnectionFactory = scope.ServiceProvider.GetRequiredService<ISqlConnectionFactory>();

            using var connection = sqlConnectionFactory.CreateConnection();

            var faker = new Faker();

            List<object> jobCandidates = new();
            for (var i = 0; i < 20; i++)
            {
                jobCandidates.Add(new
                {
                    Id = Guid.NewGuid(),
                    FirstName = faker.Name.FirstName(),
                    LastName = faker.Name.LastName(),
                    PhoneNumber = faker.Phone.PhoneNumber(),
                    Email = faker.Person.Email,
                    CallInFrom = faker.Date.BetweenTimeOnly(new TimeOnly(0, 1, 1, 1), new TimeOnly(23, 59, 59, 9)),
                    CallInTo = faker.Date.BetweenTimeOnly(new TimeOnly(0, 1, 1, 1), new TimeOnly(23, 59, 59, 9)),
                    LinkedIn = faker.Internet.Url(),
                    GitHub = faker.Internet.Url(),
                    Comment = faker.Person.FullName
                });
            }

            const string sql = """
                   INSERT INTO [dbo].[JobCandidates]
                  ([Id]
                  ,[FirstName]
                  ,[LastName]
                  ,[PhoneNumber]
                  ,[Email]
                  ,[CallInFrom]
                  ,[CallInTo]
                  ,[LinkedIn]
                  ,[GitHub]
                  ,[Comment])
            VALUES
                  (@Id
                  ,@FirstName
                  ,@LastName
                  ,@PhoneNumber
                  ,@Email
                  ,@CallInFrom
                  ,@CallInTo
                  ,@LinkedIn
                  ,@GitHub
                  ,@Comment);
            """;

            connection.Execute(sql, jobCandidates);
        }
    }
}

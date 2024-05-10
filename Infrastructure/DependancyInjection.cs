using Application.Abstractions.Data;
using Application.Abstractions.Emails;
using Dapper;
using Domain.Common.Contract;
using Domain.JobCandidates;
using Infrastructure.Configurations.DbContextConfiguration.Interceptors;
using Infrastructure.Data;
using Infrastructure.Emails;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data;

namespace Infrastructure;

public static class DependancyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Database") ?? throw new ArgumentNullException(nameof(configuration));

        services.AddTransient<IEmailService, EmailService>();

        services.AddScoped<DomainEventsInterceptor>();

        services.AddDbContext<CandidateContext>((serviceProvider, options) =>
        {
            options.UseSqlServer(connectionString);
            options.AddInterceptors(serviceProvider.GetRequiredService<DomainEventsInterceptor>());
        });

        services.AddScoped<IJobCandidateRepository, JobCandidateRepository>();
        
        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<CandidateContext>());

        services.AddSingleton<ISqlConnectionFactory>(_ => new SqlConnectionFactory(connectionString));

        SqlMapper.AddTypeHandler(new SqlTimeOnlyTypeHandler());

        return services;
    }

}

public class SqlTimeOnlyTypeHandler : SqlMapper.TypeHandler<TimeOnly>
{
    public override void SetValue(IDbDataParameter parameter, TimeOnly time)
    {
        parameter.Value = time.ToString();
    }

    public override TimeOnly Parse(object value)
    {
        return TimeOnly.FromTimeSpan((TimeSpan)value);
    }
}

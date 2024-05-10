using Application.Abstractions.Data;
using Domain.Common.Contract;
using Domain.JobCandidates;
using Infrastructure.Configurations.DbContextConfiguration.Interceptors;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependancyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Database") ?? throw new ArgumentNullException(nameof(configuration));
        
        services.AddScoped<DomainEventsInterceptor>();

        services.AddDbContext<CandidateContext>((serviceProvider, options) =>
        {
            options.UseSqlServer(connectionString);
            options.AddInterceptors(serviceProvider.GetRequiredService<DomainEventsInterceptor>());
        });

        services.AddScoped<IJobCandidateRepository, JobCandidateRepository>();
        
        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<CandidateContext>());

        services.AddSingleton<ISqlConnectionFactory>(_ => new SqlConnectionFactory(connectionString));

        return services;
    }
}

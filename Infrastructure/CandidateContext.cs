using Domain.Common.Contract;
using Domain.JobCandidates;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class CandidateContext(DbContextOptions options) : DbContext(options) , IUnitOfWork
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CandidateContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }

    public DbSet<JobCandidate> JobCandidates { get; set; }
}

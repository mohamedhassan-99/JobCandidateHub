using Domain.JobCandidates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations.EntitiesTypesConfigurations;

public class JobCandidateETC : IEntityTypeConfiguration<JobCandidate>
{
    public void Configure(EntityTypeBuilder<JobCandidate> builder)
    {
        builder.HasKey(candidate => candidate.Id);

        builder.Property(candidate => candidate.Id)
            .HasConversion(candidateId => candidateId.Value, value => new JobCandidateId(value));

        builder.OwnsOne(candidate => candidate.CallIn, ownedTypeBuilder =>
        {
            ownedTypeBuilder.Property(call => call.From).HasColumnName(nameof(JobCandidate.CallIn) + nameof(JobCandidate.CallIn.From));
            ownedTypeBuilder.Property(call => call.To).HasColumnName(nameof(JobCandidate.CallIn) + nameof(JobCandidate.CallIn.To));
        });

        builder.Property(candidate => candidate.FirstName)
            .IsRequired()
            .HasMaxLength(100)
            .HasConversion(name => name.Value, value => new FirstName(value));

        builder.Property(candidate => candidate.LastName)
            .IsRequired()
            .HasMaxLength(100)
            .HasConversion(name => name.Value, value => new LastName(value));

        builder.Property(candidate => candidate.PhoneNumber)
            .HasMaxLength(100)
            .HasConversion(name => name.Value, value => new PhoneNumber(value));

        builder.Property(candidate => candidate.Email)
            .IsRequired()
            .HasMaxLength(200)
            .HasConversion(name => name.Value, value => new Email(value));

        builder.Property(candidate => candidate.LinkedIn)
            .HasMaxLength(500)
            .HasConversion(name => name.Value, value => new URL(value));

        builder.Property(candidate => candidate.GitHub)
            .HasMaxLength(500)
            .HasConversion(name => name.Value, value => new URL(value));

        builder.Property(candidate => candidate.Comment)
            .IsRequired()
            .HasMaxLength(1500)
            .HasConversion(name => name.Value, value => new Comment(value));
    }
}

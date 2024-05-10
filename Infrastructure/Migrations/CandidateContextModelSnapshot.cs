﻿// <auto-generated />
using System;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(CandidateContext))]
    partial class CandidateContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.JobCandidates.JobCandidate", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasMaxLength(1500)
                        .HasColumnType("nvarchar(1500)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("GitHub")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LinkedIn")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("JobCandidates");
                });

            modelBuilder.Entity("Domain.JobCandidates.JobCandidate", b =>
                {
                    b.OwnsOne("Domain.JobCandidates.TimeInterval", "CallIn", b1 =>
                        {
                            b1.Property<Guid>("JobCandidateId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<TimeOnly>("From")
                                .HasColumnType("time")
                                .HasColumnName("CallInFrom");

                            b1.Property<TimeOnly>("To")
                                .HasColumnType("time")
                                .HasColumnName("CallInTo");

                            b1.HasKey("JobCandidateId");

                            b1.ToTable("JobCandidates");

                            b1.WithOwner()
                                .HasForeignKey("JobCandidateId");
                        });

                    b.Navigation("CallIn");
                });
#pragma warning restore 612, 618
        }
    }
}

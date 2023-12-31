﻿// <auto-generated />
using System;
using Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Infrastructure.EF.Entities.LanguageEntity", b =>
                {
                    b.Property<int>("LanguageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LanguageId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("LanguageId");

                    b.ToTable("Languages");

                    b.HasData(
                        new
                        {
                            LanguageId = 1,
                            Name = "C#"
                        },
                        new
                        {
                            LanguageId = 2,
                            Name = "Java"
                        },
                        new
                        {
                            LanguageId = 3,
                            Name = "Python"
                        },
                        new
                        {
                            LanguageId = 4,
                            Name = "C++"
                        },
                        new
                        {
                            LanguageId = 5,
                            Name = "Javascript"
                        });
                });

            modelBuilder.Entity("Infrastructure.EF.Entities.ProjectEntity", b =>
                {
                    b.Property<int>("ProjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProjectId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int>("DifficultyLevel")
                        .HasColumnType("int");

                    b.Property<DateTime?>("FinishDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("PrivateRecruitment")
                        .HasColumnType("bit");

                    b.Property<string>("RepositoryUrl")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Requirements")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<DateTime?>("SubmissionDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("TeamId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("ProjectId");

                    b.HasIndex("TeamId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("Infrastructure.EF.Entities.ProjectStatusEntity", b =>
                {
                    b.Property<int>("ProjectStatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProjectStatusId"));

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ProjectId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("StatusId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("ProjectStatusId");

                    b.HasIndex("ProjectId");

                    b.HasIndex("StatusId");

                    b.ToTable("ProjectStatuses");
                });

            modelBuilder.Entity("Infrastructure.EF.Entities.StatusEntity", b =>
                {
                    b.Property<int>("StatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StatusId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("StatusId");

                    b.ToTable("Statuses");

                    b.HasData(
                        new
                        {
                            StatusId = 1,
                            Name = "Created"
                        },
                        new
                        {
                            StatusId = 2,
                            Name = "Team Completed"
                        },
                        new
                        {
                            StatusId = 3,
                            Name = "Development"
                        },
                        new
                        {
                            StatusId = 4,
                            Name = "Tested"
                        },
                        new
                        {
                            StatusId = 5,
                            Name = "Done"
                        });
                });

            modelBuilder.Entity("Infrastructure.EF.Entities.TeamEntity", b =>
                {
                    b.Property<int>("TeamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TeamId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("TeamId");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("Infrastructure.EF.Entities.TeamRoleEntity", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("RoleId");

                    b.ToTable("TeamRoles");

                    b.HasData(
                        new
                        {
                            RoleId = 1,
                            Name = "Developer"
                        },
                        new
                        {
                            RoleId = 2,
                            Name = "Tester"
                        },
                        new
                        {
                            RoleId = 3,
                            Name = "Leader"
                        },
                        new
                        {
                            RoleId = 4,
                            Name = "DevOps"
                        });
                });

            modelBuilder.Entity("Infrastructure.EF.Entities.TeamUserEntity", b =>
                {
                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<int?>("TeamId")
                        .HasColumnType("int");

                    b.Property<int?>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "TeamId", "RoleId");

                    b.HasIndex("RoleId");

                    b.HasIndex("TeamId");

                    b.ToTable("TeamUsers");
                });

            modelBuilder.Entity("Infrastructure.EF.Entities.TechEntity", b =>
                {
                    b.Property<int>("TechId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TechId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("TechId");

                    b.ToTable("Technologies");

                    b.HasData(
                        new
                        {
                            TechId = 1,
                            Name = "ASP.NET"
                        },
                        new
                        {
                            TechId = 2,
                            Name = "UWP"
                        },
                        new
                        {
                            TechId = 3,
                            Name = "Selenium"
                        },
                        new
                        {
                            TechId = 4,
                            Name = "Entity Framework"
                        },
                        new
                        {
                            TechId = 5,
                            Name = "React"
                        });
                });

            modelBuilder.Entity("Infrastructure.EF.Entities.UserEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<int>("Points")
                        .HasColumnType("int");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("LanguageEntityProjectEntity", b =>
                {
                    b.Property<int>("LanguagesLanguageId")
                        .HasColumnType("int");

                    b.Property<int>("ProjectsProjectId")
                        .HasColumnType("int");

                    b.HasKey("LanguagesLanguageId", "ProjectsProjectId");

                    b.HasIndex("ProjectsProjectId");

                    b.ToTable("LanguageEntityProjectEntity");
                });

            modelBuilder.Entity("LanguageEntityUserEntity", b =>
                {
                    b.Property<int>("LaguagesLanguageId")
                        .HasColumnType("int");

                    b.Property<int>("UsersId")
                        .HasColumnType("int");

                    b.HasKey("LaguagesLanguageId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("LanguageEntityUserEntity");
                });

            modelBuilder.Entity("ProjectEntityTechEntity", b =>
                {
                    b.Property<int>("ProjectsProjectId")
                        .HasColumnType("int");

                    b.Property<int>("TechnologiesTechId")
                        .HasColumnType("int");

                    b.HasKey("ProjectsProjectId", "TechnologiesTechId");

                    b.HasIndex("TechnologiesTechId");

                    b.ToTable("ProjectEntityTechEntity");
                });

            modelBuilder.Entity("ProjectEntityUserEntity", b =>
                {
                    b.Property<int>("ApplicantsId")
                        .HasColumnType("int");

                    b.Property<int>("AppliedProjectsProjectId")
                        .HasColumnType("int");

                    b.HasKey("ApplicantsId", "AppliedProjectsProjectId");

                    b.HasIndex("AppliedProjectsProjectId");

                    b.ToTable("ProjectEntityUserEntity");
                });

            modelBuilder.Entity("TechEntityUserEntity", b =>
                {
                    b.Property<int>("TechnologiesTechId")
                        .HasColumnType("int");

                    b.Property<int>("UsersId")
                        .HasColumnType("int");

                    b.HasKey("TechnologiesTechId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("TechEntityUserEntity");
                });

            modelBuilder.Entity("Infrastructure.EF.Entities.ProjectEntity", b =>
                {
                    b.HasOne("Infrastructure.EF.Entities.TeamEntity", "Team")
                        .WithMany()
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Team");
                });

            modelBuilder.Entity("Infrastructure.EF.Entities.ProjectStatusEntity", b =>
                {
                    b.HasOne("Infrastructure.EF.Entities.ProjectEntity", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infrastructure.EF.Entities.StatusEntity", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("Infrastructure.EF.Entities.TeamUserEntity", b =>
                {
                    b.HasOne("Infrastructure.EF.Entities.TeamRoleEntity", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infrastructure.EF.Entities.TeamEntity", "Team")
                        .WithMany()
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infrastructure.EF.Entities.UserEntity", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("Team");

                    b.Navigation("User");
                });

            modelBuilder.Entity("LanguageEntityProjectEntity", b =>
                {
                    b.HasOne("Infrastructure.EF.Entities.LanguageEntity", null)
                        .WithMany()
                        .HasForeignKey("LanguagesLanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infrastructure.EF.Entities.ProjectEntity", null)
                        .WithMany()
                        .HasForeignKey("ProjectsProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LanguageEntityUserEntity", b =>
                {
                    b.HasOne("Infrastructure.EF.Entities.LanguageEntity", null)
                        .WithMany()
                        .HasForeignKey("LaguagesLanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infrastructure.EF.Entities.UserEntity", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProjectEntityTechEntity", b =>
                {
                    b.HasOne("Infrastructure.EF.Entities.ProjectEntity", null)
                        .WithMany()
                        .HasForeignKey("ProjectsProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infrastructure.EF.Entities.TechEntity", null)
                        .WithMany()
                        .HasForeignKey("TechnologiesTechId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProjectEntityUserEntity", b =>
                {
                    b.HasOne("Infrastructure.EF.Entities.UserEntity", null)
                        .WithMany()
                        .HasForeignKey("ApplicantsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infrastructure.EF.Entities.ProjectEntity", null)
                        .WithMany()
                        .HasForeignKey("AppliedProjectsProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TechEntityUserEntity", b =>
                {
                    b.HasOne("Infrastructure.EF.Entities.TechEntity", null)
                        .WithMany()
                        .HasForeignKey("TechnologiesTechId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infrastructure.EF.Entities.UserEntity", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

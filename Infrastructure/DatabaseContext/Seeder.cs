
using Microsoft.EntityFrameworkCore;
using Infrastructure.EF.Entities;

namespace Infrastructure.DatabaseContext
{
    public class Seeder
    {
        private ModelBuilder modelBuilder;

        public Seeder(ModelBuilder modelBuilder)
        {
            this.modelBuilder = modelBuilder;
        }

        public Seeder SeedRoles()
        {
            modelBuilder.Entity<TeamRoleEntity>().HasData(
                               new TeamRoleEntity { RoleId = 1, Name = "Developer" },
                                              new TeamRoleEntity { RoleId = 2, Name = "Tester" },
                                              new TeamRoleEntity { RoleId = 3, Name = "Leader" },
                                              new TeamRoleEntity { RoleId = 4, Name = "DevOps" }
                                                         );
            return this;
        }


        public Seeder SeedStatuses()
        {
            modelBuilder.Entity<StatusEntity>().HasData(
                                              new StatusEntity { StatusId = 1, Name = "Created" },
                                    new StatusEntity { StatusId = 2, Name = "Team Completed" },
                                    new StatusEntity { StatusId = 3, Name = "Development" },
                                    new StatusEntity { StatusId = 4, Name = "Tested" },
                                    new StatusEntity  { StatusId = 5, Name = "Done" }
                                    );
            return this;
        }

        public Seeder SeedLanguages()
        {
            modelBuilder.Entity<LanguageEntity>().HasData(
                new LanguageEntity { LanguageId = 1, Name = "C#" },
                new LanguageEntity { LanguageId = 2, Name = "Java" },
                new LanguageEntity { LanguageId = 3, Name = "Python" },
                new LanguageEntity { LanguageId = 4, Name = "C++" },
                new LanguageEntity { LanguageId = 5, Name = "Javascript" }
                );
            return this;
        }

        public Seeder SeedTechnologies()
        {
            modelBuilder.Entity<TechEntity>().HasData(
                new TechEntity { TechId = 1, Name = "ASP.NET" },
                new TechEntity { TechId = 2, Name = "UWP" },
                new TechEntity { TechId = 3, Name = "Selenium" },
                new TechEntity { TechId = 4, Name = "Entity Framework" },
                new TechEntity { TechId = 5, Name = "React" }
                );
            return this;
        }
    }
}

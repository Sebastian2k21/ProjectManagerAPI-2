using Infrastructure.EF.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;


namespace Infrastructure.DatabaseContext
{
    public class AppDbContext : DbContext
    {
        public DbSet<LanguageEntity> Languages { get; set; }
        public DbSet<ProjectEntity> Projects { get; set; }
        public DbSet<ProjectStatusEntity> ProjectStatuses { get; set; }
        public DbSet<TeamRoleEntity> TeamRoles { get; set; }
        public DbSet<StatusEntity> Statuses { get; set; }
        public DbSet<TeamEntity> Teams { get; set; }
        public DbSet<TechEntity> Technologies { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<TeamUserEntity> TeamUsers { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(
                "DATA SOURCE=DESKTOP-SBST8LD\\SQLEXPRESS;DATABASE=ProjektBACKENDAPI2;Integrated Security=true;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TeamUserEntity>().HasKey(u => new
            {
                u.UserId,
                u.TeamId,
                u.RoleId
            });

            new Seeder(modelBuilder)
                .SeedRoles()
                .SeedLanguages()
                .SeedTechnologies()
                .SeedStatuses();
        }
    }
}

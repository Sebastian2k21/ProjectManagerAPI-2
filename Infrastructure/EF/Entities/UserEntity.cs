using ApplicationCore.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EF.Entities
{
    public class UserEntity: IdentityUser<int>
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Email { get; set; }

        [Required]
        [MaxLength(50)]
        public string? FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string? LastName { get; set; }

        [Required]
        public byte[]? PasswordHash { get; set; }

        [Required]
        public byte[]? PasswordSalt { get; set; }

        public int Points { get; set; }

        public List<TechEntity> Technologies { get; set; } = new List<TechEntity>();
        public List<LanguageEntity> Laguages { get; set; } = new List<LanguageEntity>();
        public List<ProjectEntity> AppliedProjects { get; set; } = new List<ProjectEntity>();
    }
}

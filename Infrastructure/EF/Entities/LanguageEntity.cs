using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EF.Entities
{
    public class LanguageEntity
    {
        [Key]
        public int LanguageId { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Name { get; set; }

        public List<ProjectEntity> Projects { get; set; } = new List<ProjectEntity>();
        public List<UserEntity> Users { get; set; } = new List<UserEntity>();
    }
}

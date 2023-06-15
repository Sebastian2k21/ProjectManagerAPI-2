using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EF.Entities
{
    public class ProjectEntity
    {
        [Key]
        public int ProjectId { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Name { get; set; }

        [Required]
        [MaxLength(1000)]
        public string? Description { get; set; }

        [Required]
        [MaxLength(1000)]
        public string? Requirements { get; set; }

        [Required]
        public int DifficultyLevel { get; set; }

        public DateTime? FinishDate { get; set; }

        public DateTime? SubmissionDate { get; set; }

        [Required]
        public TeamEntity? Team { get; set; }

        [ForeignKey(nameof(Team))]
        public int? TeamId { get; set; }

        [Required]
        public bool PrivateRecruitment { get; set; }

        [MaxLength(200)]
        public string? RepositoryUrl { get; set; }

        public List<UserEntity> Applicants { get; set; } = new List<UserEntity>();

        public List<LanguageEntity> Languages { get; set; } = new List<LanguageEntity>();
        public List<TechEntity> Technologies { get; set; } = new List<TechEntity>();
    }
}

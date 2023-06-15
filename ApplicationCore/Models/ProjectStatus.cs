using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{
    public class ProjectStatus
    {
        [Key]

        public int ProjectStatusId { get; set; }
        [Required]
        public Project? Project { get; set; }

        [Required]
        public Status? Status { get; set; }

        [ForeignKey(nameof(Project))]
        public int? ProjectId { get; set; }

        [ForeignKey(nameof(Status))]
        public int? StatusId { get; set; }

        public DateTime? DateCreated { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EF.Entities
{
    public class TeamEntity
    {
        [Key]
        public int TeamId { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Name { get; set; }
    }
}

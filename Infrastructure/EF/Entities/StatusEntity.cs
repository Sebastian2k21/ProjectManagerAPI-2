using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EF.Entities
{
    public class StatusEntity
    {
        [Key]
        public int StatusId { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Name { get; set; }
    }
}

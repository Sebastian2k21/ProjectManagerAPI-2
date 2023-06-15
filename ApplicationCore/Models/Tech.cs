using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{
    public class Tech
    {
        [Key]
        public int TechId { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Name { get; set; }

        public List<Project> Projects { get; set; } = new List<Project>();
        public List<User> Users { get; set; } = new List<User>();
    }
}


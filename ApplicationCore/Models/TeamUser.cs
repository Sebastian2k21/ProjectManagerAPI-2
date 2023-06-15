using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{
    public class TeamUser
    {
        public User? User { get; set; }
        public Team? Team { get; set; }
        public Role? Role { get; set; }

        [ForeignKey(nameof(User))]
        public int? UserId { get; set; }

        [ForeignKey(nameof(Team))]
        public int? TeamId { get; set; }

        [ForeignKey(nameof(Role))]
        public int? RoleId { get; set; }
    }
}


using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EF.Entities
{
    public class TeamUserEntity
    {
        public UserEntity? User { get; set; }
        public TeamEntity? Team { get; set; }
        public TeamRoleEntity? Role { get; set; }

        [ForeignKey(nameof(User))]
        public int? UserId { get; set; }

        [ForeignKey(nameof(Team))]
        public int? TeamId { get; set; }

        [ForeignKey(nameof(Role))]
        public int? RoleId { get; set; }
    }
}

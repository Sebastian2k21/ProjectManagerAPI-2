using System.ComponentModel.DataAnnotations;

namespace ProjectManagerApi.Dto
{
    public class TeamUserDto
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public int ProjectId { get; set; }

        [Required]
        public int RoleId { get; set; } 
    }
}

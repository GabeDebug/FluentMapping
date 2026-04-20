using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Models
{
    public class UserRole
    {
        public int UserId { get; set; }

        public int RoleId { get; set; }
    }
}

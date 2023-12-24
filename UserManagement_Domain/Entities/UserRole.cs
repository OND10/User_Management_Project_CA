using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement_Domain.Entities
{
    public class UserRole
    {
        public int Id { get; set; }

        public int RoleId { get; set; }

        public int UserId { get; set; }

        [ForeignKey("RoleId")]
        public ICollection<Role>? Roles { get; set;}


        [ForeignKey("UserId")]
        public ICollection<User>? Users { get; set; }
    }
}

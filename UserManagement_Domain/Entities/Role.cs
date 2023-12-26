using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement_Domain.Common;

namespace UserManagement_Domain.Entities
{
    public class Role: AuditableEntity
    {

        public Role()
        {
            UserRoles = new HashSet<UserRole>();
            PermissionRoles = new HashSet<PermissionRole>(); 
        }

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="The field is required")]
        [Display(Name ="Role Name")]
        public string Name { get; set; } = null!;

        public string Description { get; set; }=string.Empty;

        [InverseProperty(nameof(UserRole.rolee))]
        public ICollection<UserRole> UserRoles { get; set; }

        [InverseProperty(nameof(PermissionRole.role))]
        public ICollection<PermissionRole> PermissionRoles { get; set; }

    }
}

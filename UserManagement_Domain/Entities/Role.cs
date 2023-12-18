using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement_Domain.Entities
{
    public class Role
    {

        public Role()
        {
                Users=new HashSet<User>();
        }

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="The field is required")]
        [Display(Name ="Role Name")]
        public string Name { get; set; } = null!;

        public string Description { get; set; }=string.Empty;

        [InverseProperty(nameof(User.roles))]
        public ICollection<User>? Users { get; set;}

    }
}

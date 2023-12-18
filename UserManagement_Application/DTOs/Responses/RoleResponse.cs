using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement_Domain.Entities;

namespace UserManagement_Application.DTOs.Responses
{
    public class RoleResponse
    {

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "The field is required")]
        [Display(Name = "Role Name")]
        public string Name { get; set; } = null!;

        public string Description { get; set; } = string.Empty;

        [InverseProperty(nameof(User.roles))]
        public ICollection<User>? Users { get; set; }



        public RoleResponse FromModel(Role role)
        {
            return new RoleResponse 
            { 
                Id=role.Id,
                Name=role.Name,
                Description=role.Description,
                Users=role.Users,
            };
        }

        public List<RoleResponse> FromModel(IEnumerable<Role> role)
        {

            List<RoleResponse> responses = new List<RoleResponse>();
            foreach (var item in role)
            {
                var res = new RoleResponse
                {
                    Id = item.Id,
                    Name=item.Name,
                    Description=item.Description,
                    Users=item.Users,

                };

                responses.Add(res);
            }
            var list = new List<RoleResponse>();
            list.AddRange(role.Select((x) => FromModel(x)));
            return list;

        }

    }
}

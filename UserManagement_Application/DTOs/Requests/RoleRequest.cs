using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement_Domain.Entities;

namespace UserManagement_Application.DTOs.Requests
{
    public class RoleRequest
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "The field is required")]
        [Display(Name = "Role Name")]
        public string Name { get; set; } = null!;

        public string Description { get; set; } = string.Empty;



        public async Task<Role> ToModel(RoleRequest request)
        {
            return await Task.FromResult<Role>(new Role
            {
                Name = request.Name,
                Description = request.Description,
            });
        }

        public async Task<RoleRequest> ToRequest(Role role)
        {
            return await Task.FromResult<RoleRequest>(new RoleRequest
            {
                Name = role.Name,
                Description = role.Description,
            });
        }

    }
}

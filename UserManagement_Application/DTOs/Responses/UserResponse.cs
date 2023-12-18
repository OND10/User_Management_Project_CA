using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement_Domain.Entities;

namespace UserManagement_Application.DTOs.Responses
{
    public class UserResponse
    {

        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public bool State { get; set; } = false;

        public string? Address { get; set; }

        public int? Role_Id { get; set; }

        [ForeignKey(nameof(Role_Id))]
        [InverseProperty(nameof(Role.Users))]

        public ICollection<Role>? roles { get; set; }

        public UserResponse FromModel(User user)
        {
            return new UserResponse { Id = user.Id, Name = user.Name, Email = user.Email, State = user.State, Address = user.Address };
        }

        public List<UserResponse> FromModel(IEnumerable<User>user) {

            List<UserResponse> responses=new List<UserResponse>();
            foreach(var item in user)
            {
                var res = new UserResponse
                {
                    Id = item.Id,
                    Name = item.Name,
                    Email = item.Email,
                    State = item.State,
                    Address = item.Address,
                    Role_Id = item.Role_Id,
                    roles=item.roles

                };
                responses.Add(res);
            }
            var list=new List<UserResponse>();
            list.AddRange(user.Select((x) => FromModel(x)));
            return list;
        
        }
    }
}

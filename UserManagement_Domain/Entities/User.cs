using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement_Domain.Common;
using UserManagement_Domain.Common.Enums;

namespace UserManagement_Domain.Entities
{
    public class User: AuditableEntity
    {

        public User()
        {
            UserRoles = new HashSet<UserRole>();
            UserGroups = new HashSet<UserGroup>(); 
        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }=string.Empty;

        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [StringLength(8,ErrorMessage ="You password must contains at least 8 digits")]
        public string? Password { get; set; }= string.Empty;

        public bool Gender { get; set; } =Convert.ToBoolean(GenderEnum.Female);

        public string Username { get; set; }

        [Phone]
        public string PhoneNumber {  get; set; } = string.Empty;

        [Compare("Password", ErrorMessage = "Passwords are not not matching ")]
        public string ConfirmPassword { get; set; }=string.Empty;

        public bool State { get; set; } = false;


        public string? Address { get; set; }
       
        public string ImageUrl {  get; set; }

        [NotMapped]
        public IFormFile? File { get; set; } 

        public DateTime CreatedDate { get; set; }

        public DateTime LastModifiedDate { get; set; }


        [InverseProperty(nameof(UserRole.user))]
        public virtual ICollection<UserRole> UserRoles { get; set; }



        [InverseProperty(nameof(UserGroup.user))]
        public virtual ICollection<UserGroup> UserGroups { get; set; }
    }

}

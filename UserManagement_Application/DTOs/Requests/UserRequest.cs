using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement_Domain.Common.Enums;
using UserManagement_Domain.Entities;

namespace UserManagement_Application.DTOs.Requests
{
    public class UserRequest
    {
        [Required(ErrorMessage = "This field is required")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "This field is required")]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "This field is required")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public bool Gender { get; set; } = Convert.ToBoolean(GenderEnum.Female);

        [Required(ErrorMessage = "This field is required")]
        public string Username { get; set; } = null!;

        [Required(ErrorMessage = "This field is required")]
        [Phone]
        public string PhoneNumber { get; set; } = string.Empty;


        [Compare("Password", ErrorMessage = "Passwords are not not matching ")]
        public string ConfirmPassword { get; set; } = null!;



        public bool State { get; set; } = false;

        [Required(ErrorMessage = "This field is required")]
        public string? Address { get; set; }


        public string ImageUrl { get; set; } = null!;


        public int? Role_Id { get; set; }

        [NotMapped]
        public IFormFile? File { get; set; }



        public User ToModel(UserRequest request)
        {
            return new User
            {
                Name = request.Name,
                Email = request.Email,
                Password = request.Password,
                ConfirmPassword = request.ConfirmPassword,
                PhoneNumber = request.PhoneNumber,
                Address = request.Address,
                ImageUrl = request.ImageUrl,
                Username = request.Username,
                Gender = request.Gender,
                File = request.File
            };
        }

        public UserRequest ToRequest(User user)
        {
            return new UserRequest
            {
                Name = user.Name,
                Email = user.Email,
                Password = user.Password,
                ConfirmPassword = user.ConfirmPassword,
                PhoneNumber = user.PhoneNumber,
                Address = user.Address,
                ImageUrl = user.ImageUrl,
                Username = user.Username,
                Gender = user.Gender,
                File = user.File
            };
        }

    }
}

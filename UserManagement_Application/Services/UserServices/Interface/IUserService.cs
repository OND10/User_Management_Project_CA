using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement_Application.DTOs.Requests;
using UserManagement_Application.DTOs.Responses;
using UserManagement_Application.Utly;
using UserManagement_Domain.Entities;

namespace UserManagement_Application.Services
{
    public interface IUserService
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Phonenumber {  get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        

        Task<IResponse<IEnumerable<UserResponse>>> GetAllAsync();

        Task<IResponse<UserRequest>> GetByIdAsync(int id);

        Task<IResponse<UserResponse>> CreateAsync(UserRequest model);

        Task<IResponse> DeleteAsync(UserRequest model);


    }
}

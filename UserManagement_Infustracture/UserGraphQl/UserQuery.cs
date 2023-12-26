using Microsoft.AspNetCore.Http;
using UserManagement_Application.DTOs.Responses;
using UserManagement_Application.Services;
using UserManagement_Application.Utly;
using UserManagement_Domain.Entities;
using UserManagement_Domain.Interfaces;
using UserManagement_Infustracture.DBContext;

namespace Get_Post_Microservice.Models
{
    public class UserQuery
    {
        private readonly IUserRepository _repository;
        private readonly AppDbContext _context;
        private readonly IUserService _service;

        public UserQuery(IUserRepository repository, AppDbContext context,IUserService service)
        {
            _repository = repository;
            _context = context;
            _service = service;
        }

        protected void Configure(IObjectTypeDescriptor descriptor)
        {
            descriptor.Field("users")
                .Type<UserType>()
                .Argument("id", arg => arg.Type<IntType>())
                .Resolve(context =>
                {
                    var userId = context.ArgumentValue<int>("id");
                    var user = _repository.GetByIdAsync(userId);
                    return user;
                });
        }



        public  async Task<IResponse<IEnumerable<UserResponseDTO>>> Users()
        {
               return await _service.GetAllAsync();
        }


        //public async Task<User> UploadProfilePicture([Service] IFileStorage fileStorage, IFormFile file)
        //{
        //    // Process the file, save it to storage, and update the user's profile picture
        //    // Example: fileStorage.SaveFile(file, "profile_pictures");

        //    // For simplicity, return a user with the file details
        //    return new User { File = file.FileName };
        //}


        //public User getbyid(int id)
        //{
        //    return _repository.GetById(id);
        //}

        //Get user name with User1 specified with condition
        //public User GetUserName => _service.GetUser();
    }
}

//To use GaphQl you have to do three things 
// 1) Create a graph entity type of your extenal entity
// 2) Get the query ready via creating a class 
// 3) Get the schema ready to know what you would to execute
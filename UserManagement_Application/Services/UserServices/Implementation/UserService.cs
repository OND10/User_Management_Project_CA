using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement_Application.DTOs.Requests;
using UserManagement_Application.DTOs.Responses;
using UserManagement_Application.Utly;
using UserManagement_Domain.Common.Enums;
using UserManagement_Domain.Common.Exceptions;
using UserManagement_Domain.Entities;
using UserManagement_Domain.Interfaces;

namespace UserManagement_Application.Services
{
    public class UserService:IUserService
    {
        private readonly IManagerRepository _repository;
        private readonly IUserRepository _userRepository;
        public List<User> users;

        public UserService(IManagerRepository repository, IUserRepository userRepository)
        {
            users = new List<User>()
            {
                new User
                {
                    Id=1,Name="User1",Username="OND",Email="user1@gmail.com",Gender=Convert.ToBoolean(GenderEnum.Male),
                    PhoneNumber="+967-777777777",Password="Osamadammag2002$",ConfirmPassword="Osamadammag2002$"
                },

                new User
                {
                    Id=2,Name="User2",Username="Shelly",Email="user2@gmail.com",Gender=Convert.ToBoolean(GenderEnum.Female),
                    PhoneNumber="+967-777777254",Password="Shelly232@",ConfirmPassword="Shelly232@"
                },

            };
            _repository=repository;
            _userRepository = userRepository;
        }
        public string Email { get; set; } = string.Empty;
        public string Phonenumber { get; set; } = null!;
        public string Password { get; set; }= string.Empty;
        public string ConfirmPassword { get; set; }=string.Empty;
        public int Id { get; set; }



        public async Task<IResponse<UserResponseDTO>> CreateAsync(UserRequestDTO model)
        {
            try
            {
                //Mapped the userrequest to domain model
                User modelobj =  model.ToModel(model);
                //Added to list of type domain model
                await _repository.UserRepository.AddAsync(modelobj);
                var responseobj = new UserResponseDTO();

                return Response<UserResponseDTO>.Success(responseobj.FromModel(modelobj)," ");
            }
            catch (Exception)
            {
                throw  new  ModelNullException(nameof(model), "Exception in adding User");
            }
        }

        public async Task<IResponse> DeleteAsync(UserRequestDTO model)
        {
            try
            {
                User domainmodel= model.ToModel(model);
                await _repository.UserRepository.DeleteAsync(domainmodel);
                return Response.Success();
            }
            catch (Exception)
            {
                throw new ModelNullException(nameof(model), "Exception in removing User");
            }
        }

        public async Task<IResponse<IEnumerable<UserResponseDTO>>> GetAllAsync()
        {
            
                var list = await _userRepository.GetAllAsync();
                var responseobj=new UserResponseDTO();
                var converted= responseobj.FromModel(list);

                return await Response<IEnumerable<UserResponseDTO>>.SuccessAsync(converted," ");
            
            
        }

        public async Task<IResponse<UserRequestDTO>> GetByIdAsync(int id)
        {
            try
            {
                var find = await _repository.UserRepository.GetByIdAsync(id);
                if (find==null) 
                {
                    throw new IdNullException("Exception : Id is Null");
                }
                else
                {
                    var requestobj=new UserRequestDTO();
                    return Response<UserRequestDTO>.Success(await requestobj.ToRequest(find)," ");
                }
            }
            catch (Exception)
            {
                throw new ModelNullException(nameof(id), "Exception in finding the User");
            }
        }

        public async Task<int> SaveChangeAsync()
        {
            return await _repository.UserRepository.SaveChangeAsync();
        }

        public async Task<IResponse<UserResponseDTO>> UpdateAsync(UserRequestDTO model)
        {
            try
            {
                //Mapped the userrequest to domain model
                User modelobj = model.ToModel(model);
                //Added to list of type domain model
                await _repository.UserRepository.UpdateAsync(modelobj);
                var responseobj = new UserResponseDTO();

                return Response<UserResponseDTO>.Success( responseobj.FromModel(modelobj), " ");
            }
            catch (Exception)
            {
                throw new ModelNullException(nameof(model), "Exception in updating User");
            }

        }

      
    }
}

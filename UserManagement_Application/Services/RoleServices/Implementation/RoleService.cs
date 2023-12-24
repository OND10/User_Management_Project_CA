using AutoMapper;
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

namespace UserManagement_Application.Services.RoleServices
{
    public class RoleService : IRoleService
    {

        public List<Role> roles;
        private readonly IMapper _mapper;

        public RoleService(IMapper mapper)
        {
            roles = new List<Role>()
            {
                new Role
                {
                    Id = Convert.ToInt16(RolesEnum.Admin),
                    Name ="Admin",
                    Description = "Controlling all users,endusers and managers in the system"
                },
                new Role
                {
                    Id = Convert.ToInt16(RolesEnum.User),
                    Name ="User",
                    Description = "Interacting with system as other users"
                }
            };
            _mapper = mapper;
        }

        public async Task<IResponse<RoleResponse>> CreateAsync(RoleRequest model)
        {
            try
            {
                var domainmodel = _mapper.Map<Role>(model);
                roles.Add(domainmodel);
                var responsemodel = new RoleResponse();
                return await Response<RoleResponse>.SuccessAsync(await responsemodel.FromModel(domainmodel), "Added Successfully");
            }
            catch (Exception)
            {
                throw new ModelNullException(nameof(roles), "Exception in adding roles");
            }
        }

        public async Task<IResponse> DeleteAsync(RoleRequest model)
        {
            try
            {
                var domainmodel = _mapper.Map<Role>(model);
                roles.Remove(domainmodel);
                return await Response.SuccessAsync();
            }
            catch (Exception)
            {
                throw new ModelNullException(nameof(roles), "Exception in deleting roles");
            }
        }

        public async Task<IResponse<IEnumerable<RoleResponse>>> GetAllAsync()
        {
            try
            {
                var list = roles.ToList();
                var responsemodel = new RoleResponse();
                var converted = await responsemodel.FromModel(list);
                return await Response<IEnumerable<RoleResponse>>.SuccessAsync(converted, "Viewd Successfully");
            }
            catch (Exception)
            {
                throw new ModelNullException(nameof(roles), "Exception in returning roles");
            }
        }

        public async Task<IResponse<RoleRequest>> GetByIdAsync(int id)
        {
            try
            {
                var find = roles.FirstOrDefault(r => r.Id == id);
                if (find == null)
                {
                    throw new IdNullException("Exception : Id is Null");
                }
                else
                {
                    var requestmodel = new RoleRequest();
                    var findrequest = await requestmodel.ToRequest(find);
                    return await Response<RoleRequest>.SuccessAsync(findrequest, "");
                }
            }
            catch (Exception)
            {

                throw new ModelNullException(nameof(id), "Exception in finding roles");
            }
        }

        public Task<IResponse<RoleResponse>> UpdateAsync(RoleRequest model)
        {
            throw new ModelNullException(nameof(model), "Exception in updating roles");
        }
    }
}

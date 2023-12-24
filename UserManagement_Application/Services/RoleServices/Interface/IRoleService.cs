using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement_Application.DTOs.Requests;
using UserManagement_Application.DTOs.Responses;
using UserManagement_Application.Utly;

namespace UserManagement_Application.Services.RoleServices
{
    public interface IRoleService
    {

        Task<IResponse<IEnumerable<RoleResponse>>> GetAllAsync();

        Task<IResponse<RoleResponse>> CreateAsync(RoleRequest model);

        Task<IResponse<RoleResponse>> UpdateAsync(RoleRequest model);

        Task<IResponse<RoleRequest>> GetByIdAsync(int id);

        Task<IResponse> DeleteAsync(RoleRequest model);


    }
}

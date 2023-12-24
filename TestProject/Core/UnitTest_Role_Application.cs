using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement_Application.DTOs.Requests;
using UserManagement_Application.DTOs.Responses;
using UserManagement_Application.Services.RoleServices;
using UserManagement_Application.Utly;
using UserManagement_Domain.Common.Enums;
using Xunit;

namespace TestProject.Core
{
    public class UnitTest_Role_Application
    {
        private readonly Mock<IRoleService> _roleService;
        public UnitTest_Role_Application(Mock<IRoleService> roleService)
        {
            _roleService= roleService;
        }

        [Fact]
        public async Task Role_Get_AllAsync_Method_Test()
        {
            // Arrange
            //Mocked the IRoleService to return the specified method using the Dependency Injection
            _roleService.Setup(role => role.GetAllAsync())
                .ReturnsAsync(await Response<IEnumerable<RoleResponse>>.SuccessAsync(new List<RoleResponse>
                {
                    //Making a new object of the Roleresponse
                    new RoleResponse
                    {
                            Id=Convert.ToInt16(RolesEnum.Admin),Name="Admin",Description = "Controlling all users,endusers and managers in the system"
                    },
                    
                    //Making another new object of the Roleresponse
                    new RoleResponse
                    {
                            Id=Convert.ToInt16(RolesEnum.User),Name="User",Description = "Interacting with system as other users"
                    },

                }, " ")
                );


            // Acting
            IRoleService mockedrole = _roleService.Object;
            //Assigning actualed_value to getall method
            var actualed_value = await mockedrole.GetAllAsync();


            // Asserting
            //This IsAssignableFrom is used to check if its parameter equals the actualed_value
            var responses = Assert.IsAssignableFrom<Response<IEnumerable<RoleResponse>>>(actualed_value);
            //fetching the data of the Roleresponse as a list
            var models = responses.Data;
            //To check times of data recorded => measn how many recors are returned
            Assert.Equal(2, models.Count());
        }


        [Fact]
        public async Task Role_CreateAsync_Method_Test()
        {

            //Arrange
            //Mocked the IRoleService to return the specified method
            _roleService.Setup(role => role.CreateAsync(It.IsAny<RoleRequest>())).
                ReturnsAsync(await Response<RoleResponse>.SuccessAsync(new RoleResponse
                {
                    Id = Convert.ToInt16(RolesEnum.Admin), Name="Admin",Description = "Controlling all users,endusers and managers in the system"
                }));

            //Making a new instance of RoleRequest
            var requestmodel = new RoleRequest
            {

                Id = Convert.ToInt16(RolesEnum.Admin),
                Name = "Admin",
                Description = "Controlling all users,endusers and managers in the system"
            };

            //Acting
            IRoleService mockedrole = _roleService.Object;
            //Assigning actualed_value to create method
            var actualed_value = mockedrole.CreateAsync(requestmodel);

            //Asserting
            //Check if actualed_value is not null
            Assert.NotNull(actualed_value);
          
        }


        [Fact]

        public async Task Role_GetById_Method_Test()
        {

            //Arrange
            //Mocked the IUserService to return the specified method
            _roleService.Setup(role => role.GetByIdAsync(It.IsAny<int>())).
                ReturnsAsync(await Response<RoleRequest>.SuccessAsync(new RoleRequest
                {
                    Id = Convert.ToInt16(RolesEnum.Admin),
                    Name = "Admin",
                    Description = "Controlling all users,endusers and managers in the system"
                }));

            //Acting
            IRoleService mockedrole= _roleService.Object;
            //Assigning actualed_value to getbyid method
            var actualed_value = mockedrole.GetByIdAsync(It.IsAny<int>());


            //Asserting
            Assert.NotNull(actualed_value);

        }

        [Fact]
        public async Task Role_Delete_Method_Test()
        {

            //Arrange
            //Mocked the IUserService to return the specified method
            _roleService.Setup(role => role.DeleteAsync(It.IsAny<RoleRequest>())).
                ReturnsAsync(await Response.SuccessAsync());
            //Making a new object of the RoleRequest
            var requestmodel = new RoleRequest
                 {
                     Id = Convert.ToInt16(RolesEnum.Admin),
                     Name = "Admin",
                     Description = "Controlling all users,endusers and managers in the system"
                 };

            //Acting
            IRoleService mockedrole= _roleService.Object;
            //Assigning actualed_value to delete method
            var actualed_value = await mockedrole.DeleteAsync(requestmodel);

            //Asserting
            Assert.NotNull(actualed_value);
            Assert.True(actualed_value.IsSuccess);

        }
    }
}

using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.FakeEntities;
using UserManagement_Application.DTOs.Responses;
using UserManagement_Application.Services;
using UserManagement_Application.Utly;
using UserManagement_WebApi.Controllers;

namespace TestProject.Api
{
    public class UnitTest_UserController_Api:DtoFakeBaseModel
    {

        [Fact]


        public async Task Test_UserController_Api()
        {

            //Arrange
            var callmocking = new Mock<IUserService>();
            callmocking.Setup(ctr => ctr.GetAllAsync()).ReturnsAsync(Response<IEnumerable<UserResponseDTO>>.Success(userresponseDTOs, " "));

            //Acting
            var usercontroller = new UserController(callmocking.Object);
            var actualed_value = await usercontroller.Get();

            //Asserting
            //This IsAssignableFrom is used to check if its parameter equals the actualed_value
            var responses = Assert.IsAssignableFrom<Response<IEnumerable<UserResponseDTO>>>(actualed_value);
            //fetching the data of the UserResponse as a list
            var models = responses.Data;
            //To check times of data recorded => measn how many recors are returned
            Assert.Equal(2, models.Count());

        }


    }
}

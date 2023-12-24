using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using UserManagement_Application.DTOs.Requests;
using UserManagement_Application.DTOs.Responses;
using UserManagement_Application.Services;
using UserManagement_Application.Utly;
using UserManagement_Domain.Common.Enums;
using UserManagement_Domain.Entities;
using Xunit;
namespace TestProject.Core
{
    public class UnitTest_User_Application
    {
        private readonly Mock<IUserService> _userServiceMock;
        public UnitTest_User_Application(Mock<IUserService> userServiceMock)
        {
            _userServiceMock = userServiceMock;
        }


        [Fact]
        public async Task User_Get_AllAsync_Method_Test()
        {
            // Arrange
            //Mocked the IUserService to return the specified method
            _userServiceMock.Setup(user => user.GetAllAsync())
                .ReturnsAsync(Response<IEnumerable<UserResponse>>.Success(new List<UserResponse>
                {
                    //Making a new object of the UserResponse
                    new UserResponse
                    {
                            Id=1,Name="User1",Username="OND",Email=UnitTest_User_Domain.Email_Unit_Test_Validation("osama@gmail.com"),Gender=Convert.ToBoolean(GenderEnum.Male),
                            PhoneNumber=UnitTest_User_Domain.Phone_Unit_Test_Validation("+967-779136337")
                    },
                    
                    //Making another new object of the UserResponse
                    new UserResponse
                    {
                            Id=2,Name="User2",Username="Shelly",Email="user2@gmail.com",Gender=Convert.ToBoolean(GenderEnum.Female),
                            PhoneNumber="+967-777777254"
                    },

                }, " ")
                );


            // Acting
            IUserService mockeduser = _userServiceMock.Object;
            //Assigning actualed_value to getall method
            var actualed_value = await mockeduser.GetAllAsync();


            // Asserting
            //This IsAssignableFrom is used to check if its parameter equals the actualed_value
            var responses = Assert.IsAssignableFrom<Response<IEnumerable<UserResponse>>>(actualed_value);
            //fetching the data of the UserResponse as a list
            var models = responses.Data;
            //To check times of data recorded => measn how many recors are returned
            Assert.Equal(2, models.Count());
        }


        [Fact]
        public async Task User_CreateAsync_Method_Test()
        {
            // Arrange
            //Mocked the IUserService to return the specified method
            _userServiceMock.Setup(user => user.CreateAsync(It.IsAny<UserRequest>()))
                .ReturnsAsync(Response<UserResponse>.Success(new UserResponse
                {
                    Id = 1,
                    Name = "User1",
                    Username = "OND",
                    Email = UnitTest_User_Domain.Email_Unit_Test_Validation("osama@gmail.com"),
                    Gender = Convert.ToBoolean(GenderEnum.Male),
                    PhoneNumber = UnitTest_User_Domain.Phone_Unit_Test_Validation("+967-779136337")
                }));

            //Making a new object of the UserRequest
            var userAdd = new UserRequest
            {
                Id = 1,
                Name = "User1",
                Username = "OND",
                Email = UnitTest_User_Domain.Email_Unit_Test_Validation("osama@gmail.com"),
                Gender = Convert.ToBoolean(GenderEnum.Male),
                PhoneNumber = UnitTest_User_Domain.Phone_Unit_Test_Validation("+967-779136337")
            };


            // Acting
            IUserService mockeduser= _userServiceMock.Object;
            //Assigning actualed_value to create method
            var actualed_value = await mockeduser.CreateAsync(userAdd);


            // Asserting
            Assert.NotNull(actualed_value);
        }


        [Fact]
        public async Task User_GetById_Test_Method()
        {

            //Arrange
            //Mocked the IUserService to return the specified method
            _userServiceMock.Setup(user => user.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(Response<UserRequest>.Success(new UserRequest
                {
                    Id = 1,
                    Name = "User1",
                    Username = "OND",
                    Email = UnitTest_User_Domain.Email_Unit_Test_Validation("osama@gmail.com"),
                    Gender = Convert.ToBoolean(GenderEnum.Male),
                    PhoneNumber = UnitTest_User_Domain.Phone_Unit_Test_Validation("+967-779136337"),
                    Password = UnitTest_User_Domain.Password_Unit_Test_Validation("Osamadammag2002%"),
                    ConfirmPassword = "Osamadammag2002%"
                }));

            //Acting
            //making an object of IUserService
            IUserService mockeduser = _userServiceMock.Object;
            //Assigning actualed_value to getbyid method
            var actualed_value = await mockeduser.GetByIdAsync(It.IsAny<int>());

            //Asserting
            Assert.NotNull(actualed_value);
        }

        [Fact]
        public async Task User_Delete_Test_Method()
        {

            //Arrange
            //Mocked the IUserService to return the specified method
            _userServiceMock.Setup(user => user.DeleteAsync(It.IsAny<UserRequest>())).ReturnsAsync(Response.Success());
            //Making a new object of the UserRequest
            var requestobj = new UserRequest
            {
                Id = 1,
                Name = "User1",
                Username = "OND",
                Email = UnitTest_User_Domain.Email_Unit_Test_Validation("osama@gmail.com"),
                Gender = Convert.ToBoolean(GenderEnum.Male),
                PhoneNumber = UnitTest_User_Domain.Phone_Unit_Test_Validation("+967-779136337"),
                Password = UnitTest_User_Domain.Password_Unit_Test_Validation("Osamadammag2002%"),
                ConfirmPassword = "Osamadammag2002%"
            };

            //Acting
            //making an object of IUserService
            IUserService mockeduser= _userServiceMock.Object;
            //Assigning actualed_value to delete method
            var actualed_value = await mockeduser.DeleteAsync(requestobj);

            //Asserting
            Assert.NotNull(actualed_value);
            Assert.True(actualed_value.IsSuccess);

        }
    }
}

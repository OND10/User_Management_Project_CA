using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;
using UserManagement_Domain.Interfaces;
using UserManagement_Domain.Entities;
using UserManagement_Domain.Common.Enums;
using TestProject;
using AutoMapper;

namespace TestProject
{
    public class UnitTest_UserRepository_Infustracture
    {
        private readonly Mock<IUserRepository> _userRepository;
        private readonly IMapper _mapper;
        public UnitTest_UserRepository_Infustracture(Mock<IUserRepository> repository)
        {
            _userRepository=repository;
            // // Configure AutoMapper profiles (you may need to create a profile for each model)
            // var mapperConfiguration = new MapperConfiguration(cfg =>
            // {
            //     cfg.CreateMap<User, UserFakeDataObject>();
            //     // Add other mappings if needed
            // });

            // _mapper = new Mapper(mapperConfiguration);
        }


        [Fact]
        public async Task UserRepository_GetAll_Metod_Test()
        {

            //Arrange
            //Mocked the IUserRepository to get the specified method
            _userRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(new List<User>
            {
                new User
                {
                     Id=1,Name="User1",Username="OND",Email=UnitTest_User_Domain.Email_Unit_Test_Validation("user1@gmail.com"),Gender=Convert.ToBoolean(GenderEnum.Male),
                     PhoneNumber=UnitTest_User_Domain.Phone_Unit_Test_Validation("+967-777777777"),
                     Password=UnitTest_User_Domain.Password_Unit_Test_Validation("Osamadammag2002$")
                },
                new User
                {

                     Id=2,Name="User2",Username="Shelly",Email=UnitTest_User_Domain.Email_Unit_Test_Validation("user2@gmail.com"),Gender=Convert.ToBoolean(GenderEnum.Female),
                     PhoneNumber=UnitTest_User_Domain.Phone_Unit_Test_Validation("+967-777777254"),
                     Password=UnitTest_User_Domain.Password_Unit_Test_Validation("Shelly232@")
                     
                }
            });

            //Acting
            IUserRepository mockeduserrepo = _userRepository.Object;
            var actualed_value = await mockeduserrepo.GetAllAsync();

            //Asserting
            var userlist = Assert.IsAssignableFrom<List<User>>(actualed_value);
            //fetching the data from the User as a list
            var models = userlist.ToList();
            Assert.Equal(2, models.Count);

        }


        [Fact]

        public async Task UserRepository_CreateAsync_Metod_Test()
        {


            //Arrange
            var userobject = new UserFakeData
            {
                Id = 1,
                Name = "User1",
                Username = "OND",
                Email = "user1@gmail.com",
                Gender = Convert.ToBoolean(GenderEnum.Male),
                PhoneNumber = "+967-777777777",
                Password = "Osamadammag2002$"
                
            };

            //Mocked the IUserRepository to get the specified method
            _userRepository.Setup(repo => repo.AddAsync(userobject.ToModel(userobject))).ReturnsAsync(new UserFakeData
            {
                Id = 1,
                Name = "User1",
                Username = "OND",
                Email = "user1@gmail.com",
                Gender = Convert.ToBoolean(GenderEnum.Male),
                PhoneNumber = "+967-777777777",
                Password = "Osamadammag2002$",
              
            });

            //Making a new instance of a User 
            var usermodel = new User
            {
                Id = 1,
                Name = "User1",
                Username = "OND",
                Email = "user1@gmail.com",
                Gender = Convert.ToBoolean(GenderEnum.Male),
                PhoneNumber = "+967-777777777",
                Password = "Osamadammag2002$",
                ConfirmPassword = "Osamadammag2002$"
            };

            //Acting
            IUserRepository mockeduser = _userRepository.Object;
            //mocking the IUserRepository to call the create method
            var actualed_value = await mockeduser.AddAsync(usermodel);

            //Asserting
            Assert.NotNull(actualed_value);
        }

        [Fact]
        public async Task UserRepository_GetByIdAsync_Metod_Test()
        {
            //Arrange
            //Mocked the IUserRepository to get the specified method
            _userRepository.Setup(repo => repo.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(new User
            {
                Id = 1,
                Name = "User1",
                Username = "OND",
                Email = "user1@gmail.com",
                Gender = Convert.ToBoolean(GenderEnum.Male),
                PhoneNumber = "+967-777777777",
                Password = "Osamadammag2002$",
                ConfirmPassword = "Osamadammag2002$"
            });

            //Acting
            IUserRepository mockeduser = _userRepository.Object;
            //mocking the IUserRepository to call the getbyid method
            var actualed_value = await mockeduser.GetByIdAsync(It.IsAny<int>());

            //Asserting
            Assert.NotNull(actualed_value);

        }

        [Fact]
        public async Task UserRepository_DeleteAsync_Metod_Test()
        {
            //Arrange
            //Mocked the IUserRepository to get the specified method
            _userRepository.Setup(repo => repo.DeleteAsync(It.IsAny<User>())).ReturnsAsync(new User
            {
                Id = 1,
                Name = "User1",
                Username = "OND",
                Email = "user1@gmail.com",
                Gender = Convert.ToBoolean(GenderEnum.Male),
                PhoneNumber = "+967-777777777",
                Password = "Osamadammag2002$",
                ConfirmPassword = "Osamadammag2002$"
            });

            //Acting
            IUserRepository mockeduser = _userRepository.Object;
            //mocking the IUserRepository to call the getbyid method
            var actualed_value = await mockeduser.DeleteAsync(It.IsAny<User>());

            //Asserting
            Assert.NotNull(actualed_value);

        }

    }
}

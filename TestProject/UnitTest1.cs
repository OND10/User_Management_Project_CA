using Moq;
using UserManagement_Application.Services;
using UserManagement_Domain.Entities;
using Xunit;
namespace TestProject
{
    public class UnitTest1
    {
        [Fact]

        public void Email_Unit_Test_Validition()
        {
            var callmocking = new Mock<IUser>();
            callmocking.Setup(user => user.Email).Returns("user@gmail.com");
            IUser mockeduser= callmocking.Object;
            string defaultEmail= mockeduser.Email;
            Assert.Equal("user@gmail.com",defaultEmail);
        }

        [Fact]

        public void Phone_Unit_Test_Validition()
        {
            var callmocking= new Mock<IUser>();
            callmocking.Setup(user => user.Phonenumber).Returns("+967 779136337");
            IUser mockeduser= callmocking.Object;
            string defaultphone = mockeduser.Phonenumber;

            Assert.Equal("+967 779136337", defaultphone);

        }
    }
}
using MixerBL;
using MixerModels;
using MixerREST.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MixerTests
{
    public class UserControllerTest
    {
        private Mock<IMixerBL> _mixBLMock;

        public UserControllerTest()
        {
            _mixBLMock = new Mock<IMixerBL>();
        }
        [Fact]
        public async Task GetUserByIdShouldGetUser()
        {
            var userId = 1;
            var user = new User { Id = userId };
            _mixBLMock.Setup(x => x.GetUserByIDAsync(It.IsAny<int>())).Returns(Task.FromResult(user));
            var userController = new UserController(_mixBLMock.Object);
            var result = await userController.GetUserByIDAsync(userId);
            Assert.Equal(userId, ((User)((OkObjectResult)result).Value).Id);
            _mixBLMock.Verify(x => x.GetUserByIDAsync(userId));
        }
        [Fact]
        public async Task AddUserShouldAddUser()
        {
            var user = new User();
            _mixBLMock.Setup(x => x.AddUserAsync(It.IsAny<User>())).Returns(Task.FromResult<User>(user));
            var userController = new UserController(_mixBLMock.Object);
            var result = await userController.AddUserAsync(new User());
            Assert.IsAssignableFrom<CreatedAtActionResult>(result);
            _mixBLMock.Verify(x => x.AddUserAsync((It.IsAny<User>())));
        }
         [Fact]
        public async Task DeleteUserShouldDeleteUser()
        {
            var user = new User{Id = 1};
            _mixBLMock.Setup(x => x.DeleteUserAsync(It.IsAny<User>())).Returns(Task.FromResult<User>(user));
            var userController = new UserController(_mixBLMock.Object);
            var result = await userController.DeleteUserAsync(user.Id);
            Assert.IsAssignableFrom<NoContentResult>(result);
            _mixBLMock.Verify(x => x.DeleteUserAsync((It.IsAny<User>())));
        }
        [Fact]
        public async Task GetUserByEmailShouldGetUser()
        {
            var userEmail = "test@email.com";
            var user = new User { Email = userEmail };
            _mixBLMock.Setup(x => x.GetUserByEmail(It.IsAny<string>())).Returns(Task.FromResult(user));
            var userController = new UserController(_mixBLMock.Object);
            var result = await userController.GetUserByEmail(userEmail);
            Assert.Equal(userEmail, ((User)((OkObjectResult)result).Value).Email);
            _mixBLMock.Verify(x => x.GetUserByEmail(userEmail));
        }
    }
}
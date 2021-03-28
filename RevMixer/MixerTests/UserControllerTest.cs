//using System;
using System.Collections.Generic;
// using System.Linq;
// using System.Text;
//using System.Threading.Tasks;
using Xunit;
using Moq;
using MixerBL;
using MixerModels;
using MixerREST.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace MixerTests
{
    public class UserControllerTest
    {
        // [Fact]
        // public async Task GetUsersAsync_ReturnsAViewResult_WithAListOfUsers()
        // {
        //     // Arrange
        //     var mockRepo = new Mock<IMixerBL>();
        //     mockRepo.Setup(repo => repo.GetUsersAsync())
        //         .ReturnsAsync(GetTestUsers());
        //     var controller = new UserController(mockRepo.Object);

        //     // Act
        //     var result = await controller.GetUsersAsync();

        //     // Assert
        //     //var viewResult = Assert.IsType<ViewResult>(result);
        //     //var model = Assert.IsAssignableFrom<IEnumerable<UserIndexVM>>(
        //       //  viewResult.ViewData.Model);
        //     //Assert.Equal(2, model.Count());
        // }
        // [Fact]
        // public void TestGetUserByIdAsync()
        // {
        //     User testUser = new User()
        //     {
        //         Id = 1,
        //         UserName = "WestonD123",
        //         Email = "westondavidson@outlook.com",
        //         IsAdmin = true
        //     };
        //     int userId = testUser.Id;
        //      var mockUserClient = new Mock<IMixerBL>();
        //     mockUserClient.Setup(c => c.GetUserByIDAsync(testUser.Id))
        //     .Returns(testUser);
        //     UserController service = new UserController(mockUserClient.Object);
        //     var result = service.GetUserByIDAsync(userId).Result as ObjectResult;
        //     var actualResult = result.Value;
        //     Assert.Equal(testUser.Id, ((User)actualResult).Id);
        // }
        private List<User> GetTestUsers()
        {
            var users = new List<User>();
            users.Add(new User()
            {
                Id = 1,
                UserName = "WestonD123",
                Email = "westondavidson@outlook.com",
                IsAdmin = true

            });
            users.Add(new User()
            {
                Id = 2,
                UserName = "JackLongDog",
                Email = "jacklong@gmail.com",
                IsAdmin = false
            });
            return users;
        }
    }
}
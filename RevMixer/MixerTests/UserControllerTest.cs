// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Text;
// using System.Threading.Tasks;
// using Xunit;
// using Moq;
// using MixerBL;
// using MixerModels;
// using MixerREST.Controllers;

// namespace MixerTests
// {
//     public class UserControllerTest
//     {
//         [Fact]
//         public async Task Index_ReturnsAViewResult_WithAListOfBrainstormSessions()
//         {
//             // Arrange
//             var mockRepo = new Mock<IMixerBL>();
//             mockRepo.Setup(repo => repo.GetUsersAsync())
//                 .ReturnsAsync(GetTestUsers());
//             var controller = new UserController(mockRepo.Object);

//             // Act
//             var result = await controller.Index();

//             // Assert
//             var viewResult = Assert.IsType<ViewResult>(result);
//             var model = Assert.IsAssignableFrom<IEnumerable<UserIndexVM>>(
//                 viewResult.ViewData.Model);
//             Assert.Equal(2, model.Count());
//         }
//         private List<User> GetTestUsers()
//         {
//             var users = new List<User>();
//             users.Add(new User()
//             {
//                 Id = 1,
//                 UserName = "WestonD123",
//                 Email = "westondavidson@outlook.com",
//                 IsAdmin = true

//             });
//             users.Add(new User()
//             {
//                 Id = 2,
//                 UserName = "JackLongDog",
//                 Email = "jacklong@gmail.com",
//                 IsAdmin = false
//             });
//             return users;
//         }
//     }
// }
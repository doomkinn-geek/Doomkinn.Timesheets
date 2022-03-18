using Doomkinn.Timesheets.Models;
using Doomkinn.Timesheets.Repository;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace TimeSheetsTestsProject.UserController
{
    public class GetUsersTests
    {
        [Fact]
        public void GetUsersTest_return_Ok()
        {
            var mockRepo = new Mock<UserRepository>();
            mockRepo.Setup(repo => repo.Get())
                .ReturnsAsync(new User());
            var controller = new UserController(mockRepo.Object);

            // Act
            var result = await controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<User>>(
                viewResult.ViewData.Model);
            Assert.Equal(2, model.Count());
        }
    }
}

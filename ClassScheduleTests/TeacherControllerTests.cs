using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using ClassSchedule.Models;
using ClassSchedule.Controllers;
using ClassSchedule.Models.DataLayer;
using System.Collections.Generic; 

namespace ClassScheduleTests
{
    public class TeacherControllerTests
    {
        [Fact]
        public void IndexActionMethod_ReturnsAViewResult()
        {
            var mockRepo = new Mock<IRepository<Teacher>>();

            mockRepo.Setup(m => m.List(It.IsAny<QueryOptions<Teacher>>()))
                .Returns(new List<Teacher>());

            var controller = new TeacherController(mockRepo.Object);

            var result = controller.Index();

            Assert.IsType<ViewResult>(result);
        }
        

        }
    }

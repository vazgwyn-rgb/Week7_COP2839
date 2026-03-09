using System.Collections.Generic;
using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using ClassSchedule.Models;
using ClassSchedule.Models.DataLayer;
using ClassSchedule.Controllers;

namespace ClassScheduleTests
{
    public class HomeControllerTests
    {
        [Fact]
        public void IndexActionMethod_ReturnsAViewResult()
        {
            var mockClassRepo = new Mock<IRepository<Class>>();
            var mockDayRepo = new Mock<IRepository<Day>>();
            var mockUnit = new Mock<IClassScheduleUnitOfWork>();
            var mockHttp = new Mock<IHttpContextAccessor>();

            mockClassRepo
                .Setup(r => r.List(It.IsAny<QueryOptions<Class>>()))
                .Returns(new List<Class>());
            mockDayRepo
                .Setup(r => r.List(It.IsAny<QueryOptions<Day>>()))
                .Returns(new List<Day>());
            mockUnit.Setup(u => u.Classes).Returns(mockClassRepo.Object);
            mockUnit.Setup(u => u.Days).Returns(mockDayRepo.Object);

            var context = new DefaultHttpContext(); 
            mockHttp.Setup(h => h.HttpContext).Returns(context);

            var controller = new HomeController(mockUnit.Object, mockHttp.Object);

            var result = controller.Index(0);
            Assert.IsType<ViewResult>(result);
        }
    }
}

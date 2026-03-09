using Microsoft.AspNetCore.Mvc;
using ClassSchedule.Models;
using ClassSchedule.Models.DataLayer;
using Microsoft.AspNetCore.Http;

namespace ClassSchedule.Controllers
{
    public class HomeController : Controller
    {
        private IClassScheduleUnitOfWork data {  get; set; }
        private IHttpContextAccessor http { get; set; }

        public HomeController(IClassScheduleUnitOfWork unit, IHttpContextAccessor httpContextAccessor)
        {
            data = unit;
            http = httpContextAccessor;
        }

        public ViewResult Index(int id)
        {
            // options for Days query
            var dayOptions = new QueryOptions<Day> {
                OrderBy = d => d.DayId
            };

            // options for Classes query
            var classOptions = new QueryOptions<Class> {
                Includes = "Teacher, Day"
            };

            // order classes by day and then time on first load (ie, there's no filter value).
            // Otherwise, filter by day and order by time.
            if (id == 0) {
                classOptions.OrderBy = c => c.DayId;
                classOptions.ThenOrderBy = c => c.MilitaryTime;
            }
            else {
                classOptions.Where = c => c.DayId == id;
                classOptions.OrderBy = c => c.MilitaryTime;
            }

            // execute queries
            var dayList = data.Days.List(dayOptions);
            var classList = data.Classes.List(classOptions);

            // send data to view
            ViewBag.Id = id;
            ViewBag.Days = dayList;
            return View(classList);
        }
    }
}
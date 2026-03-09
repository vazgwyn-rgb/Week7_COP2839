using Microsoft.AspNetCore.Mvc;
using ClassSchedule.Models;
using ClassSchedule.Models.DataLayer;

namespace ClassSchedule.Controllers
{
    public class TeacherController : Controller
    {
        private IRepository<Teacher> data { get; set; }
        public TeacherController(IRepository<Teacher> repo)
        {
            data = repo;
        }


        public ViewResult Index()
        {
            var teachers = data.List(new QueryOptions<Teacher>
            {
                OrderBy = t => t.LastName
            });
            return View(teachers);
        }

        [HttpGet]
        public ViewResult Add() => View();

        [HttpPost]
        public IActionResult Add(Teacher teacher)
        {
            if (ModelState.IsValid) {
                data.Insert(teacher);
                data.Save();
                return RedirectToAction("Index");
            }
            else{
                return View(teacher);
            }
        }

        [HttpGet]
        public ViewResult Delete(int id) => View(data.Get(id));

        [HttpPost]
        public RedirectToActionResult Delete(Teacher teacher)
        {
            data.Delete(teacher);
            data.Save();
            return RedirectToAction("Index");
        }
    }
}
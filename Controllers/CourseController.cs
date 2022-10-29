using CourseApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CourseApp.Controllers
{
    public class CourseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Apply() //for only view aApply.cshtml
        {
            return View();      //localhost/course/apply
        }

        [HttpPost]
        public IActionResult Apply(Student std) //for save form data into server/repository
        {
            if (ModelState.IsValid)
            {
                //save data in repository
                Repository.AddStudent(std);
                return View("Thanks", std); //localhost/course/apply
            }
            else
            {
                return View(std);
            }
            }
        public IActionResult List() 
        {
            var s = Repository.studs.Where(i => i.Confirm == true).ToList();
            return View(s);
        }
    
    }
}
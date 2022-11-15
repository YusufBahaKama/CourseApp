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

        public IActionResult ByReleased(int year, int month){
            return Content("year = " + year + " month = " + month);
        }

//Examples for returning type

      /*public RedirectToActionResult Index1()
        {
            return RedirectToAction("List");
        }
        public NotFoundResult index2()
        {
            return NotFound();
        }
        public UnauthorizedResult Index3()
        {
            return Unauthorized();
        }
        public RedirectResult Index4()
        {
            return Redirect("Index");
        }
        public IActionResult Index5()
        {
            return Content("Hello World");
        }
        public IActionResult Index6()
        {
            return BadRequest();
        }*/

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
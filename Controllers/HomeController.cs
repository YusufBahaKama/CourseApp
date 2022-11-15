using CourseApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CourseApp.Controllers
{
    public class HomeController : Controller
    {
        public  IActionResult Index()
        {
            ViewBag.Greeting = DateTime.Now.Hour < 12 ? "Good Morning" : "Good Afternoon";
            ViewBag.User = "Test Name";

            return View(); //localhost:7078/home/index
        }

        public  IActionResult About()
        {
            return View(); //localhost:7078/home/list
        }
        public IActionResult Details(int? id, string? sortby)//, int year, int month)
            {
            /*var course = new Course();
            course.Name = "ASP .NET CORE MVC";
            course.Description = "MVC FUDAMENTALS";
            course.IsOpen = true;
            return View(course); //localhost:7078/home/details */


            //return Content("id = " + id + " sortby = " + sortby + " year = "+ year + " month = " + month);
            if(!id.HasValue){
                id = 1;
            }
            if(string.IsNullOrEmpty(sortby)){
                sortby = "name";
            }
           return Content("id = " + id + " sortby = " + sortby);    
            }
    }
}
using CourseApp.Models;

namespace CourseApp.ViewModels
{
    public class CourseStudentsViewModel
    {
        public Course crs { get; set; }
        public List<Student> std { get; set; }
    }
}
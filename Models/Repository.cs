namespace CourseApp.Models
{
    public class Repository
    {
        private static List<Student> _std = new List<Student>();
        public static List<Student> studs{
            get
            {
                return _std;
            }
        }
        public static void AddStudent(Student st)
        {
            _std.Add(st);  //add student to list from apply form
        }
    }
}

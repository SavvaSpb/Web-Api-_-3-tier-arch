namespace ASP.NET_Core_EF_CodeFirst.Models
{
    public class CourseModel
    {
        public int CoursesId { get; set; }
        public string ExternalCourseId { get; set; }
        public string CoursesTypeName { get; set; }
        public int InstituteId { get; set; }
        public int TeacherId { get; set; }
        public int Salary { get; set; }
    }
}

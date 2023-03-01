namespace BLL.Models
{
    public class CourseModel
    {
        public int CourseId { get; set; }
        public string? ExternalCourseId { get; set; }
        public string CourseTypeName { get; set; }
        public int InstituteId { get; set; }
        public string InstituteName { get; set; }
        public int TeacherId { get; set; }
        public string TeacherName { get; set; }
        public int Salary { get; set; }
    }
}

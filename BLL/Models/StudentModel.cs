namespace ASP.NET_Core_EF_CodeFirst.Models
{
    public class StudentModel
    {
        public int StudentsId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? Birthday { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string Email { get; set; }
    }
}

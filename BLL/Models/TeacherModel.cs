﻿namespace BLL.Models
{
    public class TeacherModel
    {
        public int Id { get; set; }

        public int TotalSalary { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? Birthday { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}

using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Context
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UserAccount>()
                .HasIndex(u => u.Email)
                .IsUnique();

            builder.Entity<Teacher>()
                .ToTable(u => u.HasCheckConstraint("Phone", "Phone like '+374%'" ));

            builder.Entity<Teacher>()
                .HasIndex(u => u.Email)
                .IsUnique();

            builder.Entity<Course>()
                .ToTable(u => u.HasCheckConstraint("Salary", "Salary > 50 "));
        }

        public DbSet<Teacher> Teacher { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<Institute> Institute { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<StudentCourse> StudentCourse { get; set; }
        public DbSet<UserAccount> UserAccount { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;

namespace AplusCurator.Models
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class InstructorDbContext : DbContext
    {
        public InstructorDbContext(DbContextOptions<InstructorDbContext> options)
            : base(options)
        {
        }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<InstructorAttendance> InstructorsAttendance { get; set; }

    }
}

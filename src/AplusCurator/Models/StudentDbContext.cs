using Microsoft.EntityFrameworkCore;

namespace AplusCurator.Models
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options) 
            : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;

namespace AplusCurator.Models
{
    public class ContentDbContext : DbContext
    {
        public ContentDbContext(DbContextOptions<ContentDbContext> options)
            : base(options)
        {

        }

        public DbSet<LearningPlan> LearningPlans { get; set; }
        public DbSet<Assessment> Assessments { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Section> Sections { get; set; }
    }
}

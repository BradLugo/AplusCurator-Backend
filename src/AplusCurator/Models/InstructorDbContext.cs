using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
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
    }
}

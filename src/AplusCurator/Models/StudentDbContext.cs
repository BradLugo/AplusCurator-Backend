using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace AplusCurator.Models
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext() : base()
        {

        }

        public DbSet<Student> Students { get; set; }
    }
}

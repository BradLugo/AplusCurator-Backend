using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace AplusCurator.Models
{
    public class GuardianDbContext : DbContext
    {
        public GuardianDbContext() : base()
        {

        }

        public DbSet<Guardian> Guardians { get; set; }
    }
}

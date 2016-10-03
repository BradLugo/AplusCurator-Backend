﻿using Microsoft.EntityFrameworkCore;

namespace AplusCurator.Models
{
    public class GuardianDbContext : DbContext
    {
        public GuardianDbContext(DbContextOptions<GuardianDbContext> options) 
            : base(options)
        {

        }

        public DbSet<Guardian> Guardians { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace AplusCurator.Models
{
    public class AttendanceDbContext : DbContext
    {
        public AttendanceDbContext() : base()
        {

        }

        public DbSet<Attendance> Students { get; set; }
    }
}

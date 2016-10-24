using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace AplusCurator.Models
{
    public static class StudentDbExtensions
    {
        public static void EnsureSeedData(this StudentDbContext context)
        {
            if (!context.Students.Any())
            {
                context.Students.AddRange(
                    new Student { FirstName = "Thumb", LastName = "Jerome", Status = 1, CurrentGrade = 4, DateOfBirth = DateTime.Now, Description = "Yeah he's ok", Gender = 0 },
                    new Student { FirstName = "Whatev", LastName = "Yeh", Status = 2, CurrentGrade = 5, DateOfBirth = DateTime.Now, Description = "Yeah he's ok", Gender = 0 },
                    new Student { FirstName = "Mikey", LastName = "Bro", Status = 1, CurrentGrade = 9, DateOfBirth = DateTime.Now, Description = "Yeah he's ok", Gender = 0 },
                    new Student { FirstName = "Notaperson", LastName = "Thatexists", Status = 0, CurrentGrade = 5, DateOfBirth = DateTime.Now, Description = "Yeah he's ok", Gender = 0 },
                    new Student { FirstName = "Steven", LastName = "Jackson", Status = 2, CurrentGrade = 5, DateOfBirth = DateTime.Now, Description = "Yeah he's ok", Gender = 0 },
                    new Student { FirstName = "Billy", LastName = "Idle", Status = 1, CurrentGrade = 2, DateOfBirth = DateTime.Now, Description = "Yeah he's ok", Gender = 0 },
                    new Student { FirstName = "Snap", LastName = "Dragon", Status = 0, CurrentGrade = 11, DateOfBirth = DateTime.Now, Description = "Yeah he's ok", Gender = 0 },
                    new Student { FirstName = "Dr", LastName = "Jones", Status = 0, CurrentGrade = 1, DateOfBirth = DateTime.Now, Description = "Yeah he's ok", Gender = 0 },
                    new Student { FirstName = "Harison", LastName = "Jones", Status = 0, CurrentGrade = 5, DateOfBirth = DateTime.Now, Description = "Yeah he's ok", Gender = 0 },
                    new Student { FirstName = "Lilly", LastName = "Bo", Status = 0, CurrentGrade = 5, DateOfBirth = DateTime.Now, Description = "Yeah She's ok", Gender = 1 }
                    );
                context.SaveChanges();
            }
        }
    }
}

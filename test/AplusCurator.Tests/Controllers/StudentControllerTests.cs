﻿using AplusCurator.Controllers;
using AplusCurator.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace AplusCurator.Tests.Controllers
{
    /// <summary>
    /// Student Controller testing class
    /// </summary>
    public class StudentControllerTests
    {

        private StudentDbContext _context;

        #region Controller method tests
        [Fact]
        public void CanGetStudents()
        {
            // Seed the new context on each test to ensure a clean test environment
            _context = CreateAndSeedContext();

            // New up the controller
            using (var controller = new StudentsController(_context))
            {
                // Perform some work in here
                var results = controller.Get();

                // Assert that the work was completed correctly
                Assert.Equal(4, results.Count());
            }
        }

        [Fact]
        public void CanGetStudentsById()
        {
            // Seed the new context on each test to ensure a clean test environment
            _context = CreateAndSeedContext();

            // New up the controller
            using (var controller = new StudentsController(_context))
            {
                // Perform some work in here
                var results = controller.GetById(1);

                // Assert that the work was completed correctly
                Assert.NotEmpty(results);
            }
        }

        [Fact]
        public void CanGetStudentsByName()
        {
            // Seed the new context on each test to ensure a clean test environment
            _context = CreateAndSeedContext();

            // New up the controller
            using (var controller = new StudentsController(_context))
            {
                // Perform some work in here
                var results = controller.GetByName("Jerry");

                // Assert that the work was completed correctly
                Assert.NotEmpty(results);
            }
        }

        [Fact]
        public void CanGetStudentsByStatus()
        {
            // Seed the new context on each test to ensure a clean test environment
            _context = CreateAndSeedContext();

            // New up the controller
            using (var controller = new StudentsController(_context))
            {
                // Perform some work in here
                var results = controller.GetByStatus(1);

                // Assert that the work was completed correctly
                Assert.NotEmpty(results);
            }
        }

        [Fact]
        public void CanAddStudentFromBody()
        {
            // Seed the new context on each test to ensure a clean test environment
            _context = CreateAndSeedContext();

            // New up the controller
            using (var controller = new StudentsController(_context))
            {
                // Perform some work in here
                var results = controller.CreateFromBody(new Student
                {
                    FirstName = "Test",
                    LastName = "Body",
                    DateOfBirth = DateTime.Now,
                    Gender = 1,
                    CurrentGrade = 5,
                    Description = "He's a body Tester.",
                    Status = 1,
                    SystemInfo = "Info here"
                });

                // Assert that the work was completed correctly
                Student result = controller.GetByName("Test").First();
                Assert.NotNull(result);
            }
        }

        public void CanAddStudentFromForm()
        {
            // Seed the new context on each test to ensure a clean test environment
            _context = CreateAndSeedContext();

            // New up the controller
            using (var controller = new StudentsController(_context))
            {
                // Perform some work in here
                var results = controller.CreateFromForm(new Student
                {
                    FirstName = "Test",
                    LastName = "Form",
                    DateOfBirth = DateTime.Now,
                    Gender = 1,
                    CurrentGrade = 5,
                    Description = "He's a form Tester.",
                    Status = 1,
                    SystemInfo = "Info here"
                });

                // Assert that the work was completed correctly
                Student result = controller.GetByName("Test").First();
                Assert.NotNull(result);
            }
        }
        #endregion

        #region Student Validation Tests

        [Fact]
        public void IsStudentWithAllValid()
        {
            //This student has everything valid
            var student = new Student
            {
                FirstName = "Dragon",
                LastName = "Boy",
                DateOfBirth = DateTime.Now,
                Gender = 1,
                CurrentGrade = 6,
                Description = "He's a dragon boy.",
                Status = 0,
                SystemInfo = "Info here"
            };
        }
        #endregion

        #region Helper methods
        /// <summary>
        /// Used to create a database in memory for use by the testing framework.
        /// The created database does not have a SQL connection but rather is simply in memory.
        /// </summary>
        /// <returns> The in memory Db context </returns>
        private StudentDbContext CreateAndSeedContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<StudentDbContext>();
            optionsBuilder.UseInMemoryDatabase();

            var inMemoryContext = new StudentDbContext(optionsBuilder.Options);
            inMemoryContext.Database.EnsureDeleted();
            inMemoryContext.Database.EnsureCreated();
            inMemoryContext.Students.AddRange(GetStudents());
            inMemoryContext.SaveChanges();
            return inMemoryContext;
        }


        /// <summary>
        /// Used by the CreateAndSeedContext method to get an array of instructors
        /// </summary>
        /// <returns> Array of intructor seed data </returns>
        private Student[] GetStudents()
        {
            Student[] newStudents = {
                new Student {FirstName = "Jerry", LastName = "Slime", DateOfBirth = DateTime.Now, Gender = 1, CurrentGrade = 5, Description = "He's a slime.", Status = 1, SystemInfo = "Info here"},
                new Student {FirstName = "Larry", LastName = "Cucumber", DateOfBirth = DateTime.Now, Gender = 0, CurrentGrade = 11, Description = "He's a cucumber.", Status = 1, SystemInfo = "Info here"},
                new Student {FirstName = "Berry", LastName = "Skittle", DateOfBirth = DateTime.Now, Gender = 1, CurrentGrade = 2, Description = "He's a skittle.", Status = 1, SystemInfo = "Info here"},
                new Student {FirstName = "Perry", LastName = "Pear", DateOfBirth = DateTime.Now, Gender = 1, CurrentGrade = 7, Description = "He's a pear.", Status = 1, SystemInfo = "Info here"}
        };
            return newStudents;
        }
        #endregion
    }
}

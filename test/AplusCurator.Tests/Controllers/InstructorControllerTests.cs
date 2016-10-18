﻿using AplusCurator.Controllers;
using AplusCurator.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace AplusCurator.Tests.Controllers
{
    /// <summary>
    /// Instructor Controller testing class
    /// </summary>
    public class InstructorControllerTests
    {
        private InstructorDbContext _context;


        [Fact]
        public void CanGetInstructors()
        {
            // Seed the new context on each test to ensure a clean test environment
            _context = CreateAndSeedContext();

            // New up the controller
            using (var controller = new InstructorController(_context))
            {
                // Perform some work in here
                var results = controller.Get();

                // Assert that the work was completed correctly
                Assert.Equal(8, results.Count());
            }
        }


        /// <summary>
        /// Used to create a database in memory for use by the testing framework.
        /// The created database does not have a SQL connection but rather is simply in memory.
        /// </summary>
        /// <returns> The in memory Db context </returns>
        private InstructorDbContext CreateAndSeedContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<InstructorDbContext>();
            optionsBuilder.UseInMemoryDatabase();

            var inMemoryContext = new InstructorDbContext(optionsBuilder.Options);
            inMemoryContext.Database.EnsureDeleted();
            inMemoryContext.Database.EnsureCreated();
            inMemoryContext.Instructors.AddRange(GetInstructors());
            inMemoryContext.SaveChanges();
            return inMemoryContext;
        }


        /// <summary>
        /// Used by the CreateAndSeedContext method to get an array of instructors
        /// </summary>
        /// <returns> Array of intructor seed data </returns>
        private Instructor[] GetInstructors()
        {
            Instructor[] newInstructors = {
                new Instructor { FirstName = "Thumb", LastName = "Jerome", MiddleName = "Jochem", Address = "1234 I Declare Rd.", Email = "notarealemail@notarealdomain.com", PhoneNumber = "1234567890", MobilePhoneNumber = "1234567890", EmergencyContactName = "The po-po", EmergencyContactPhone = "1800-call-911", Role = 0, Status = 0, EmploymentStartDate = DateTime.Now, EmploymentTerminationDate = DateTime.Now },
                    new Instructor { FirstName = "Denton", LastName = "Traylor", MiddleName = "Waldo", Address = "54321 Boom Dr.", Email = "notarealemail@notarealdomain.com", PhoneNumber = "1234567890", MobilePhoneNumber = "1234567890", EmergencyContactName = "Eynever Panic", EmergencyContactPhone = "1800-call-911", Role = 0, Status = 0, EmploymentStartDate = DateTime.Now, EmploymentTerminationDate = DateTime.Now },
                    new Instructor { FirstName = "Roselyn", LastName = "Jekyll", MiddleName = "Nikolas", Address = "128 Igotlazymakingupaddressesok Rd.", Email = "notarealemail@notarealdomain.com", PhoneNumber = "1234567890", MobilePhoneNumber = "1234567890", EmergencyContactName = "Fake Data", EmergencyContactPhone = "1800-call-911", Role = 0, Status = 0, EmploymentStartDate = DateTime.Now, EmploymentTerminationDate = DateTime.Now },
                    new Instructor { FirstName = "Michael", LastName = "Geyer", MiddleName = "Alexander", Address = "25250 Not My Real Address ln.", Email = "notarealemail@notarealdomain.com", PhoneNumber = "1234567890", MobilePhoneNumber = "1234567890", EmergencyContactName = "Faux Info", EmergencyContactPhone = "1800-call-911", Role = 0, Status = 0, EmploymentStartDate = DateTime.Now, EmploymentTerminationDate = DateTime.Now },
                    new Instructor { FirstName = "David", LastName = "Patrick", MiddleName = "", Address = "5481 Another Fake Address Dr.", Email = "notarealemail@notarealdomain.com", PhoneNumber = "1234567890", MobilePhoneNumber = "1234567890", EmergencyContactName = "Notaperson Thatexists", EmergencyContactPhone = "1800-call-911", Role = 0, Status = 0, EmploymentStartDate = DateTime.Now, EmploymentTerminationDate = DateTime.Now },
                    new Instructor { FirstName = "Richard", LastName = "Tran", MiddleName = "", Address = "56445 Random Words", Email = "notarealemail@notarealdomain.com", PhoneNumber = "1234567890", MobilePhoneNumber = "1234567890", EmergencyContactName = "Somuchjunk Inthisform", EmergencyContactPhone = "1800-call-911", Role = 0, Status = 0, EmploymentStartDate = DateTime.Now, EmploymentTerminationDate = DateTime.Now },
                    new Instructor { FirstName = "Brad", LastName = "Lugo", MiddleName = "", Address = "898 Typing Words Ave.", Email = "notarealemail@notarealdomain.com", PhoneNumber = "1234567890", MobilePhoneNumber = "1234567890", EmergencyContactName = "Makeupnames Icannot", EmergencyContactPhone = "1800-call-911", Role = 0, Status = 0, EmploymentStartDate = DateTime.Now, EmploymentTerminationDate = DateTime.Now },
                    new Instructor { FirstName = "Samson", LastName = "Farade", MiddleName = "", Address = "5468 More Words ln.", Email = "notarealemail@notarealdomain.com", PhoneNumber = "1234567890", MobilePhoneNumber = "1234567890", EmergencyContactName = "Helpmeplease Imtiredofthis", EmergencyContactPhone = "1800-call-911", Role = 0, Status = 0, EmploymentStartDate = DateTime.Now, EmploymentTerminationDate = DateTime.Now }
        };
                return newInstructors;
        }

    }
}
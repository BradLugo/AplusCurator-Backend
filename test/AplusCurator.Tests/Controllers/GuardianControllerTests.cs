using AplusCurator.Controllers;
using AplusCurator.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Xunit;


namespace AplusCurator.Tests.Controllers
{
    public class GuardianControllerTests
    {

        private GuardianDbContext _context;

        #region Controller method tests
        [Fact]
        public void CanGetGuardians()
        {
            // Seed the new context on each test to ensure a clean test environment
            _context = CreateAndSeedContext();

            // New up the controller
            using (var controller = new GuardiansController(_context))
            {
                // Perform some work in here
                var results = controller.Get();

                // Assert that the work was completed correctly
                Assert.Equal(4, results.Count());
            }
        }

        [Fact]
        public void CanGetGuardiansById()
        {
            // Seed the new context on each test to ensure a clean test environment
            _context = CreateAndSeedContext();

            // New up the controller
            using (var controller = new GuardiansController(_context))
            {
                // Perform some work in here
                var results = controller.GetById(1);

                // Assert that the work was completed correctly
                Assert.NotEmpty(results);
            }
        }

        [Fact]
        public void CanGetGuardiansByName()
        {
            // Seed the new context on each test to ensure a clean test environment
            _context = CreateAndSeedContext();

            // New up the controller
            using (var controller = new GuardiansController(_context))
            {
                // Perform some work in here
                var results = controller.GetByName("Smaug");

                // Assert that the work was completed correctly
                Assert.NotEmpty(results);
            }
        }

        [Fact]
        public void CanGetGuardiansByRole()
        {
            // Seed the new context on each test to ensure a clean test environment
            _context = CreateAndSeedContext();

            // New up the controller
            using (var controller = new GuardiansController(_context))
            {
                // Perform some work in here
                var results = controller.GetByRole(5);

                // Assert that the work was completed correctly
                Assert.NotEmpty(results);
            }
        }

        [Fact]
        public void CanGetGuardiansByStatus()
        {
            // Seed the new context on each test to ensure a clean test environment
            _context = CreateAndSeedContext();

            // New up the controller
            using (var controller = new GuardiansController(_context))
            {
                // Perform some work in here
                var results = controller.GetByStatus(4);

                // Assert that the work was completed correctly
                Assert.NotEmpty(results);
            }
        }

        [Fact]
        public void CanAddGuardianFromBody()
        {
            // Seed the new context on each test to ensure a clean test environment
            _context = CreateAndSeedContext();

            // New up the controller
            using (var controller = new GuardiansController(_context))
            {
                // Perform some work in here
                var results = controller.CreateFromBody(new Guardian
                {
                    FirstName = "Deathwing",
                    LastName = "Dragonlord",
                    Address = "12 Space",
                    Email = "wingeddeath@gmail.com",
                    PhoneNumber = "7531598520",
                    MobileNumber = "00000000000",
                    Role = 9,
                    ContactName = "Francis",
                    ContactNumber = "6666666668",
                    Status = 1,
                    Description = "A dragon lord",
                    SystemInfo = "Random stuff"
                });

                // Assert that the work was completed correctly
                Guardian result = controller.GetByName("Deathwing").First();
                Assert.NotNull(result);
            }
        }

        [Fact]
        public void CanAddGuardianFromForm()
        {
            // Seed the new context on each test to ensure a clean test environment
            _context = CreateAndSeedContext();

            // New up the controller
            using (var controller = new GuardiansController(_context))
            {
                // Perform some work in here
                var results = controller.CreateFromForm(new Guardian
                {
                    FirstName = "Deathwing",
                    LastName = "Dragonlord",
                    Address = "12 Space",
                    Email = "wingeddeath@gmail.com",
                    PhoneNumber = "7531598520",
                    MobileNumber = "00000000000",
                    Role = 9,
                    ContactName = "Francis",
                    ContactNumber = "6666666668",
                    Status = 1,
                    Description = "A dragon lord",
                    SystemInfo = "Random stuff"
                });

                // Assert that the work was completed correctly
                Guardian result = controller.GetByName("Deathwing").First();
                Assert.NotNull(result);
            }
        }
        #endregion

        #region Guardian Validation Tests

        [Fact]
        public void IsGuardianWithAllValid()
        {
            //This guardian has everything valid
            var guardian = new Guardian
            {
                FirstName = "Deathwing",
                LastName = "Dragonlord",
                Address = "12 Space",
                Email = "wingeddeath@gmail.com",
                PhoneNumber = "7531598520",
                MobileNumber = "00000000000",
                Role = 9,
                ContactName = "Francis",
                ContactNumber = "6666666668",
                Status = 1,
                Description = "A dragon lord",
                SystemInfo = "Random stuff"
            };

            //Tries to validate the object
            var context = new ValidationContext(guardian, null, null);
            var results = new List<ValidationResult>();
            var isModelsStateValid = Validator.TryValidateObject(guardian, context, results, true);

            Assert.True(isModelsStateValid);
        }

        [Fact]
        public void IsGuardianWithBlankFirstName()
        {
            //This guardian has a blank first name
            var guardian = new Guardian
            {
                FirstName = "",
                LastName = "Dragonlord",
                Address = "12 Space",
                Email = "wingeddeath@gmail.com",
                PhoneNumber = "7531598520",
                MobileNumber = "00000000000",
                Role = 9,
                ContactName = "Francis",
                ContactNumber = "6666666668",
                Status = 1,
                Description = "A dragon lord",
                SystemInfo = "Random stuff"
            };

            //Tries to validate the object
            var context = new ValidationContext(guardian, null, null);
            var results = new List<ValidationResult>();
            var isModelsStateValid = Validator.TryValidateObject(guardian, context, results, true);

            Assert.False(isModelsStateValid);
        }

        [Fact]
        public void IsGuardianWithBlankLastName()
        {
            //This guardian has a blank last name
            var guardian = new Guardian
            {
                FirstName = "Deathwing",
                LastName = "",
                Address = "12 Space",
                Email = "wingeddeath@gmail.com",
                PhoneNumber = "7531598520",
                MobileNumber = "00000000000",
                Role = 9,
                ContactName = "Francis",
                ContactNumber = "6666666668",
                Status = 1,
                Description = "A dragon lord",
                SystemInfo = "Random stuff"
            };

            //Tries to validate the object
            var context = new ValidationContext(guardian, null, null);
            var results = new List<ValidationResult>();
            var isModelsStateValid = Validator.TryValidateObject(guardian, context, results, true);

            Assert.False(isModelsStateValid);
        }

        [Fact]
        public void IsGuardianWithBlankAddress()
        {
            //This guardian has a blank address
            var guardian = new Guardian
            {
                FirstName = "Deathwing",
                LastName = "Dragonlord",
                Address = "",
                Email = "wingeddeath@gmail.com",
                PhoneNumber = "7531598520",
                MobileNumber = "00000000000",
                Role = 9,
                ContactName = "Francis",
                ContactNumber = "6666666668",
                Status = 1,
                Description = "A dragon lord",
                SystemInfo = "Random stuff"
            };

            //Tries to validate the object
            var context = new ValidationContext(guardian, null, null);
            var results = new List<ValidationResult>();
            var isModelsStateValid = Validator.TryValidateObject(guardian, context, results, true);

            Assert.False(isModelsStateValid);
        }

        [Fact]
        public void IsGuardianWithBlankEmail()
        {
            //This guardian has a blank email
            var guardian = new Guardian
            {
                FirstName = "Deathwing",
                LastName = "Dragonlord",
                Address = "12 Space",
                Email = "",
                PhoneNumber = "7531598520",
                MobileNumber = "00000000000",
                Role = 9,
                ContactName = "Francis",
                ContactNumber = "6666666668",
                Status = 1,
                Description = "A dragon lord",
                SystemInfo = "Random stuff"
            };

            //Tries to validate the object
            var context = new ValidationContext(guardian, null, null);
            var results = new List<ValidationResult>();
            var isModelsStateValid = Validator.TryValidateObject(guardian, context, results, true);

            Assert.False(isModelsStateValid);
        }

        [Fact]
        public void IsGuardianWithBlankPhoneNumber()
        {
            //This guardian has a blank phone number
            var guardian = new Guardian
            {
                FirstName = "Deathwing",
                LastName = "Dragonlord",
                Address = "12 Space",
                Email = "wingeddeath@gmail.com",
                PhoneNumber = "",
                MobileNumber = "00000000000",
                Role = 9,
                ContactName = "Francis",
                ContactNumber = "6666666668",
                Status = 1,
                Description = "A dragon lord",
                SystemInfo = "Random stuff"
            };

            //Tries to validate the object
            var context = new ValidationContext(guardian, null, null);
            var results = new List<ValidationResult>();
            var isModelsStateValid = Validator.TryValidateObject(guardian, context, results, true);

            Assert.False(isModelsStateValid);
        }

        [Fact]
        public void IsGuardianWithBlankMoblieNumber()
        {
            //This guardian has a blank moblie number
            var guardian = new Guardian
            {
                FirstName = "Deathwing",
                LastName = "Dragonlord",
                Address = "12 Space",
                Email = "wingeddeath@gmail.com",
                PhoneNumber = "7531598520",
                MobileNumber = "",
                Role = 9,
                ContactName = "Francis",
                ContactNumber = "6666666668",
                Status = 1,
                Description = "A dragon lord",
                SystemInfo = "Random stuff"
            };

            //Tries to validate the object
            var context = new ValidationContext(guardian, null, null);
            var results = new List<ValidationResult>();
            var isModelsStateValid = Validator.TryValidateObject(guardian, context, results, true);

            Assert.True(isModelsStateValid);
        }

        [Fact]
        public void IsGuardianWithBlankRole()
        {
            //This guardian has a blank role
            var guardian = new Guardian
            {
                FirstName = "Deathwing",
                LastName = "Dragonlord",
                Address = "12 Space",
                Email = "wingeddeath@gmail.com",
                PhoneNumber = "7531598520",
                MobileNumber = "00000000000",
                ContactName = "Francis",
                ContactNumber = "6666666668",
                Status = 1,
                Description = "A dragon lord",
                SystemInfo = "Random stuff"
            };

            //Tries to validate the object
            var context = new ValidationContext(guardian, null, null);
            var results = new List<ValidationResult>();
            var isModelsStateValid = Validator.TryValidateObject(guardian, context, results, true);

            Assert.False(isModelsStateValid);
        }

        [Fact]
        public void IsGuardianWithBlankContactName()
        {
            //This guardian has a blank contact name
            var guardian = new Guardian
            {
                FirstName = "Deathwing",
                LastName = "Dragonlord",
                Address = "12 Space",
                Email = "wingeddeath@gmail.com",
                PhoneNumber = "7531598520",
                MobileNumber = "00000000000",
                Role = 9,
                ContactName = "",
                ContactNumber = "6666666668",
                Status = 1,
                Description = "A dragon lord",
                SystemInfo = "Random stuff"
            };

            //Tries to validate the object
            var context = new ValidationContext(guardian, null, null);
            var results = new List<ValidationResult>();
            var isModelsStateValid = Validator.TryValidateObject(guardian, context, results, true);

            Assert.False(isModelsStateValid);
        }

        [Fact]
        public void IsGuardianWithBlankContactNumber()
        {
            //This guardian has a blank contact number
            var guardian = new Guardian
            {
                FirstName = "Deathwing",
                LastName = "Dragonlord",
                Address = "12 Space",
                Email = "wingeddeath@gmail.com",
                PhoneNumber = "7531598520",
                MobileNumber = "00000000000",
                Role = 9,
                ContactName = "Francis",
                ContactNumber = "",
                Status = 1,
                Description = "A dragon lord",
                SystemInfo = "Random stuff"
            };

            //Tries to validate the object
            var context = new ValidationContext(guardian, null, null);
            var results = new List<ValidationResult>();
            var isModelsStateValid = Validator.TryValidateObject(guardian, context, results, true);

            Assert.False(isModelsStateValid);
        }

        [Fact]
        public void IsGuardianWithBlankStatus()
        {
            //This guardian has a blank status
            var guardian = new Guardian
            {
                FirstName = "Deathwing",
                LastName = "Dragonlord",
                Address = "12 Space",
                Email = "wingeddeath@gmail.com",
                PhoneNumber = "7531598520",
                MobileNumber = "00000000000",
                Role = 9,
                ContactName = "Francis",
                ContactNumber = "6666666668",
                Description = "A dragon lord",
                SystemInfo = "Random stuff"
            };

            //Tries to validate the object
            var context = new ValidationContext(guardian, null, null);
            var results = new List<ValidationResult>();
            var isModelsStateValid = Validator.TryValidateObject(guardian, context, results, true);

            Assert.True(isModelsStateValid);
        }

        [Fact]
        public void IsGuardianWithBlankDescription()
        {
            //This guardian has a blank description
            var guardian = new Guardian
            {
                FirstName = "Deathwing",
                LastName = "Dragonlord",
                Address = "12 Space",
                Email = "wingeddeath@gmail.com",
                PhoneNumber = "7531598520",
                MobileNumber = "00000000000",
                Role = 9,
                ContactName = "Francis",
                ContactNumber = "6666666668",
                Status = 1,
                Description = "",
                SystemInfo = "Random stuff"
            };

            //Tries to validate the object
            var context = new ValidationContext(guardian, null, null);
            var results = new List<ValidationResult>();
            var isModelsStateValid = Validator.TryValidateObject(guardian, context, results, true);

            Assert.True(isModelsStateValid);
        }

        [Fact]
        public void IsGuardianWithBlankSystemInfo()
        {
            //This guardian has a blank system info
            var guardian = new Guardian
            {
                FirstName = "Deathwing",
                LastName = "Dragonlord",
                Address = "12 Space",
                Email = "wingeddeath@gmail.com",
                PhoneNumber = "7531598520",
                MobileNumber = "00000000000",
                Role = 9,
                ContactName = "Francis",
                ContactNumber = "6666666668",
                Status = 1,
                Description = "A dragon lord",
                SystemInfo = ""
            };

            //Tries to validate the object
            var context = new ValidationContext(guardian, null, null);
            var results = new List<ValidationResult>();
            var isModelsStateValid = Validator.TryValidateObject(guardian, context, results, true);

            Assert.True(isModelsStateValid);
        }

        #endregion

        #region Helper methods
        /// <summary>
        /// Used to create a database in memory for use by the testing framework.
        /// The created database does not have a SQL connection but rather is simply in memory.
        /// </summary>
        /// <returns> The in memory Db context </returns>
        private GuardianDbContext CreateAndSeedContext()
        {
            // Create a fresh service provider, and therefore a fresh 
            // InMemory database instance.
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            var builder = new DbContextOptionsBuilder<GuardianDbContext>();
            builder.UseInMemoryDatabase()
                   .UseInternalServiceProvider(serviceProvider);

            //  var optionsBuilder = new DbContextOptionsBuilder<StudentDbContext>();
            //    optionsBuilder.UseInMemoryDatabase();

            var inMemoryContext = new GuardianDbContext(builder.Options);
            inMemoryContext.Database.EnsureDeleted();
            inMemoryContext.Database.EnsureCreated();
            inMemoryContext.Guardians.AddRange(GetGuardians());
            inMemoryContext.SaveChanges();
            return inMemoryContext;
        }


        /// <summary>
        /// Used by the CreateAndSeedContext method to get an array of instructors
        /// </summary>
        /// <returns> Array of intructor seed data </returns>
        private Guardian[] GetGuardians()
        {
            Guardian[] newGuardians = {
                new Guardian {FirstName = "Smaug", LastName = "Samson", Address = "123 Misty Mountain", Email = "smaug@gmail.com", PhoneNumber = "9999999999", MobileNumber = "8888888888", Role = 1, ContactName = "Gandalf", ContactNumber = "7777777777", Status = 1, Description = "A dragon", SystemInfo = "Random"},
                new Guardian {FirstName = "Lockheed", LastName = "Lockheart", Address = "1234 Misty Mountain", Email = "lockheart@gmail.com", PhoneNumber = "1111111111", MobileNumber = "4444444444", Role = 0, ContactName = "Gandalf", ContactNumber = "7777777777", Status = 1, Description = "A dragon", SystemInfo = "Random"},
                new Guardian {FirstName = "Porunga", LastName = "Patrick", Address = "1 Cloudy Mountain", Email = "PoD8@gmail.com", PhoneNumber = "1234567890", MobileNumber = "0987654321", Role = 2, ContactName = "Gandalf", ContactNumber = "7777777777", Status = 4, Description = "A dragon", SystemInfo = "Random"},
                new Guardian {FirstName = "Balrog", LastName = "Demon", Address = "Hell", Email = "balrog@gmail.com", PhoneNumber = "3434343434", MobileNumber = "1212121212", Role = 5, ContactName = "Gandalf", ContactNumber = "7777777777", Status = 2, Description = "A dragon", SystemInfo = "Random"}

        };
            return newGuardians;
        }
        #endregion
    }
}


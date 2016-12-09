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
        public void CanUpdateGuardianFirstNameFromBody()
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

                result.FirstName = "Dragonsquire";
                var results2 = controller.UpdateFromBody(result);
                Guardian galaxy = controller.GetByName("Dragonsquire").First();
                Assert.True(galaxy.FirstName == "Dragonsquire");
            }
        }

        [Fact]
        public void CanUpdateGuardianLastNameFromBody()
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

                result.LastName = "Dragonwing";
                var results2 = controller.UpdateFromBody(result);
                Guardian galaxy = controller.GetByName("Deathwing").First();
                Assert.True(galaxy.LastName == "Dragonwing");
            }
        }

        [Fact]
        public void CanUpdateGuardianAddressFromBody()
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

                result.Address = "123 Misty Mountain";
                var results2 = controller.UpdateFromBody(result);
                Guardian galaxy = controller.GetByName("Deathwing").First();
                Assert.True(galaxy.Address == "123 Misty Mountain");
            }
        }

        [Fact]
        public void CanUpdateGuardianEmailFromBody()
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

                result.Email = "power@incarnate.com";
                var results2 = controller.UpdateFromBody(result);
                Guardian galaxy = controller.GetByName("Deathwing").First();
                Assert.True(galaxy.Email == "power@incarnate.com");
            }
        }

        [Fact]
        public void CanUpdateGuardianPhoneNumberFromBody()
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

                result.PhoneNumber = "6666666665";
                var results2 = controller.UpdateFromBody(result);
                Guardian galaxy = controller.GetByName("Deathwing").First();
                Assert.True(galaxy.PhoneNumber == "6666666665");
            }
        }

        [Fact]
        public void CanUpdateGuardianMobileFromBody()
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

                result.MobileNumber = "7777777777";
                var results2 = controller.UpdateFromBody(result);
                Guardian galaxy = controller.GetByName("Deathwing").First();
                Assert.True(galaxy.MobileNumber == "7777777777");
            }
        }

        [Fact]
        public void CanUpdateGuardianRoleFromBody()
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

                result.Role = 1;
                var results2 = controller.UpdateFromBody(result);
                Guardian galaxy = controller.GetByName("Deathwing").First();
                Assert.True(galaxy.Role == 1);
            }
        }

        [Fact]
        public void CanUpdateGuardianContactNameFromBody()
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

                result.ContactName = "Ysera";
                var results2 = controller.UpdateFromBody(result);
                Guardian galaxy = controller.GetByName("Deathwing").First();
                Assert.True(galaxy.ContactName == "Ysera");
            }
        }

        [Fact]
        public void CanUpdateGuardianContactNumberFromBody()
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

                result.ContactNumber = "8888888888";
                var results2 = controller.UpdateFromBody(result);
                Guardian galaxy = controller.GetByName("Deathwing").First();
                Assert.True(galaxy.ContactNumber == "8888888888");
            }
        }

        [Fact]
        public void CanUpdateGuardianStatusFromBody()
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

                result.Status = 2;
                var results2 = controller.UpdateFromBody(result);
                Guardian galaxy = controller.GetByName("Deathwing").First();
                Assert.True(galaxy.Status == 2);
            }
        }

        [Fact]
        public void CanUpdateGuardianDescriptionFromBody()
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

                result.Description = "An ex dragon lord";
                var results2 = controller.UpdateFromBody(result);
                Guardian galaxy = controller.GetByName("Deathwing").First();
                Assert.True(galaxy.Description == "An ex dragon lord");
            }
        }

        [Fact]
        public void CanUpdateGuardianSystemInfoFromBody()
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

                result.SystemInfo = "System info goes here";
                var results2 = controller.UpdateFromBody(result);
                Guardian galaxy = controller.GetByName("Deathwing").First();
                Assert.True(galaxy.SystemInfo == "System info goes here");
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

        [Fact]
        public void CanUpdateGuardianFirstNameFromForm()
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

                result.FirstName = "Dragonsquire";
                var results2 = controller.UpdateFromForm(result);
                Guardian galaxy = controller.GetByName("Dragonsquire").First();
                Assert.True(galaxy.FirstName == "Dragonsquire");
            }
        }

        [Fact]
        public void CanUpdateGuardianLastNameFromForm()
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

                result.LastName = "Dragonwing";
                var results2 = controller.UpdateFromForm(result);
                Guardian galaxy = controller.GetByName("Deathwing").First();
                Assert.True(galaxy.LastName == "Dragonwing");
            }
        }

        [Fact]
        public void CanUpdateGuardianAddressFromForm()
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

                result.Address = "123 Misty Mountain";
                var results2 = controller.UpdateFromForm(result);
                Guardian galaxy = controller.GetByName("Deathwing").First();
                Assert.True(galaxy.Address == "123 Misty Mountain");
            }
        }

        [Fact]
        public void CanUpdateGuardianEmailFromForm()
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

                result.Email = "power@incarnate.com";
                var results2 = controller.UpdateFromForm(result);
                Guardian galaxy = controller.GetByName("Deathwing").First();
                Assert.True(galaxy.Email == "power@incarnate.com");
            }
        }

        [Fact]
        public void CanUpdateGuardianPhoneNumberFromForm()
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

                result.PhoneNumber = "6666666665";
                var results2 = controller.UpdateFromForm(result);
                Guardian galaxy = controller.GetByName("Deathwing").First();
                Assert.True(galaxy.PhoneNumber == "6666666665");
            }
        }

        [Fact]
        public void CanUpdateGuardianMobileFromForm()
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

                result.MobileNumber = "7777777777";
                var results2 = controller.UpdateFromForm(result);
                Guardian galaxy = controller.GetByName("Deathwing").First();
                Assert.True(galaxy.MobileNumber == "7777777777");
            }
        }

        [Fact]
        public void CanUpdateGuardianRoleFromForm()
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

                result.Role = 1;
                var results2 = controller.UpdateFromForm(result);
                Guardian galaxy = controller.GetByName("Deathwing").First();
                Assert.True(galaxy.Role == 1);
            }
        }

        [Fact]
        public void CanUpdateGuardianContactNameFromForm()
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

                result.ContactName = "Ysera";
                var results2 = controller.UpdateFromForm(result);
                Guardian galaxy = controller.GetByName("Deathwing").First();
                Assert.True(galaxy.ContactName == "Ysera");
            }
        }

        [Fact]
        public void CanUpdateGuardianContactNumberFromForm()
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

                result.ContactNumber = "8888888888";
                var results2 = controller.UpdateFromForm(result);
                Guardian galaxy = controller.GetByName("Deathwing").First();
                Assert.True(galaxy.ContactNumber == "8888888888");
            }
        }

        [Fact]
        public void CanUpdateGuardianStatusFromForm()
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

                result.Status = 2;
                var results2 = controller.UpdateFromForm(result);
                Guardian galaxy = controller.GetByName("Deathwing").First();
                Assert.True(galaxy.Status == 2);
            }
        }

        [Fact]
        public void CanUpdateGuardianDescriptionFromForm()
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

                result.Description = "An ex dragon lord";
                var results2 = controller.UpdateFromForm(result);
                Guardian galaxy = controller.GetByName("Deathwing").First();
                Assert.True(galaxy.Description == "An ex dragon lord");
            }
        }

        [Fact]
        public void CanUpdateGuardianSystemInfoFromForm()
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

                result.SystemInfo = "System info goes here";
                var results2 = controller.UpdateFromForm(result);
                Guardian galaxy = controller.GetByName("Deathwing").First();
                Assert.True(galaxy.SystemInfo == "System info goes here");
            }
        }

        [Fact]
        public void CanDeleteGuardianFromBody()
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

                controller.DeleteFromBody(result);
                Assert.Empty(controller.GetByName("Deathwing"));
            }
        }

        [Fact]
        public void CanDeleteGuardianFromForm()
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

                controller.DeleteFromForm(result);
                Assert.Empty(controller.GetByName("Deathwing"));
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
                MobileNumber = "1234567890",
                Role = 2,
                ContactName = "Francis",
                ContactNumber = "1234567890",
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
        public void IsGuardianWithInvalidFirstNameValid()
        {
            //This guardian has an invalid first name
            var guardian = new Guardian
            {
                FirstName = "Deathwing@@KappaPride420",
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
        public void IsGuardianWithInvalidLastNameValid()
        {
            //This guardian has an invalid last name
            var guardian = new Guardian
            {
                FirstName = "Deathwing",
                LastName = "Dragonlord6666666",
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

            Assert.False(isModelsStateValid);
        }

        [Fact]
        public void IsGuardianWithBlankAddressValid()
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
        public void IsGuardianWithInvalidAddressValid()
        {
            //This guardian has a invalid address
            var guardian = new Guardian
            {
                FirstName = "Deathwing",
                LastName = "Dragonlord",
                Address = "$$$ Main Street",
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
        public void IsGuardianWithBlankEmailValid()
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
        public void IsGuardianWithInvalidEmailValid()
        {
            //This guardian has a invalid email
            var guardian = new Guardian
            {
                FirstName = "Deathwing",
                LastName = "Dragonlord",
                Address = "12 Space",
                Email = "wingeddeathgmail.com",
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
        public void IsGuardianWithBlankPhoneNumberValid()
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
        public void IsGuardianWithInvalidPhoneValid()
        {
            //This guardian has an invalid phone number
            var guardian = new Guardian
            {
                FirstName = "Deathwing",
                LastName = "Dragonlord",
                Address = "12 Space",
                Email = "wingeddeath@gmail.com",
                PhoneNumber = "753*****8520",
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

            Assert.False(isModelsStateValid);
        }

        [Fact]
        public void IsGuardianWithShortPhoneValid()
        {
            //This guardian has a short phone number
            var guardian = new Guardian
            {
                FirstName = "Deathwing",
                LastName = "Dragonlord",
                Address = "12 Space",
                Email = "wingeddeath@gmail.com",
                PhoneNumber = "753",
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

            Assert.False(isModelsStateValid);
        }

        [Fact]
        public void IsGuardianWithLongPhoneValid()
        {
            //This guardian has a long phone number
            var guardian = new Guardian
            {
                FirstName = "Deathwing",
                LastName = "Dragonlord",
                Address = "12 Space",
                Email = "wingeddeath@gmail.com",
                PhoneNumber = "753753753753753753753753753753753753",
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

            Assert.False(isModelsStateValid);
        }

        [Fact]
        public void IsGuardianWithBlankMoblieNumberValid()
        {
            //This guardian has a blank moblie number
            var guardian = new Guardian
            {
                FirstName = "Deathwing",
                LastName = "Dragonlord",
                Address = "12 Space",
                Email = "wingeddeath@gmail.com",
                PhoneNumber = "7531598520",
                Role = 2,
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
        public void IsGuardianWithInvalidMoblieNumberValid()
        {
            //This guardian has a invalid moblie number
            var guardian = new Guardian
            {
                FirstName = "Deathwing",
                LastName = "Dragonlord",
                Address = "12 Space",
                Email = "wingeddeath@gmail.com",
                PhoneNumber = "7531598999",
                MobileNumber = "$$$$$$$$$$",
                Role = 2,
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
        public void IsGuardianWithShortMoblieNumberValid()
        {
            //This guardian has a short moblie number
            var guardian = new Guardian
            {
                FirstName = "Deathwing",
                LastName = "Dragonlord",
                Address = "12 Space",
                Email = "wingeddeath@gmail.com",
                PhoneNumber = "1234567890",
                MobileNumber = "1",
                Role = 2,
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
        public void IsGuardianWithLongMoblieNumberValid()
        {
            //This guardian has a long moblie number
            var guardian = new Guardian
            {
                FirstName = "Deathwing",
                LastName = "Dragonlord",
                Address = "12 Space",
                Email = "wingeddeath@gmail.com",
                PhoneNumber = "1234567890",
                MobileNumber = "111111111111",
                Role = 2,
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
        public void IsGuardianWithBlankRoleValid()
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
        public void IsGuardianWithInvalidRoleValid()
        {
            //This guardian has a invalid role
            var guardian = new Guardian
            {
                FirstName = "Deathwing",
                LastName = "Dragonlord",
                Address = "12 Space",
                Email = "wingeddeath@gmail.com",
                PhoneNumber = "7531598520",
                MobileNumber = "00000000000",
                Role = 2,
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
        public void IsGuardianWithBlankContactNameValid()
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
                Role = 2,
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
        public void IsGuardianWithInvalidContactNameValid()
        {
            //This guardian has a invalid contact name
            var guardian = new Guardian
            {
                FirstName = "Deathwing",
                LastName = "Dragonlord",
                Address = "12 Space",
                Email = "wingeddeath@gmail.com",
                PhoneNumber = "7531598520",
                MobileNumber = "00000000000",
                Role = 2,
                ContactName = "Ke$ha",
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
        public void IsGuardianWithBlankContactNumberValid()
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
                Role = 2,
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
        public void IsGuardianWithBlankInvalidNumberValid()
        {
            //This guardian has a invalid contact number
            var guardian = new Guardian
            {
                FirstName = "Deathwing",
                LastName = "Dragonlord",
                Address = "12 Space",
                Email = "wingeddeath@gmail.com",
                PhoneNumber = "7531598520",
                MobileNumber = "00000000000",
                Role = 2,
                ContactName = "Francis",
                ContactNumber = "%%%%%%%%%%",
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
        public void IsGuardianWithBlankShortNumberValid()
        {
            //This guardian has a short contact number
            var guardian = new Guardian
            {
                FirstName = "Deathwing",
                LastName = "Dragonlord",
                Address = "12 Space",
                Email = "wingeddeath@gmail.com",
                PhoneNumber = "7531598520",
                MobileNumber = "00000000000",
                Role = 2,
                ContactName = "Francis",
                ContactNumber = "11",
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
        public void IsGuardianWithBlankLongNumberValid()
        {
            //This guardian has a long contact number
            var guardian = new Guardian
            {
                FirstName = "Deathwing",
                LastName = "Dragonlord",
                Address = "12 Space",
                Email = "wingeddeath@gmail.com",
                PhoneNumber = "7531598520",
                MobileNumber = "00000000000",
                Role = 2,
                ContactName = "Francis",
                ContactNumber = "11111111111",
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
                MobileNumber = "1234567890",
                Role = 2,
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
        public void IsGuardianWithInvalidStatus()
        {
            //This guardian has a invalid status
            var guardian = new Guardian
            {
                FirstName = "Deathwing",
                LastName = "Dragonlord",
                Address = "12 Space",
                Email = "wingeddeath@gmail.com",
                PhoneNumber = "7531598520",
                MobileNumber = "1234567890",
                Role = 2,
                ContactName = "Francis",
                ContactNumber = "6666666668",
                Status = 99,
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
                MobileNumber = "1234567890",
                Role = 2,
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
                MobileNumber = "1234567890",
                Role = 2,
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


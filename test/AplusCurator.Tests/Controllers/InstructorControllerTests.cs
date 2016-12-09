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
    /// <summary>
    /// Instructor Controller testing class
    /// </summary>
    public class InstructorControllerTests
    {
        private InstructorDbContext _context;

        #region Controller method tests
        [Fact]
        public void CanGetInstructors()
        {
            // Seed the new context on each test to ensure a clean test environment
            _context = CreateAndSeedContext();

            // New up the controller
            using (var controller = new InstructorsController(_context))
            {
                // Perform some work in here
                var results = controller.Get();

                // Assert that the work was completed correctly
                Assert.Equal(8, results.Count());
            }
        }
        [Fact]
        public void CanGetInstructorsById()
        {
            // Seed the new context on each test to ensure a clean test environment
            _context = CreateAndSeedContext();

            // New up the controller
            using (var controller = new InstructorsController(_context))
            {
                // Perform some work in here
                var results = controller.GetById(1);

                // Assert that the work was completed correctly
                Assert.NotEmpty(results);
            }
        }

        [Fact]
        public void CanGetInstructorsByName()
        {
            // Seed the new context on each test to ensure a clean test environment
            _context = CreateAndSeedContext();

            // New up the controller
            using (var controller = new InstructorsController(_context))
            {
                // Perform some work in here
                var results = controller.GetByName("Michael");

                // Assert that the work was completed correctly
                Assert.Equal("Michael", results.First().FirstName);
            }
        }

        [Fact]
        public void CanGetInstructorsByRole()
        {
            // Seed the new context on each test to ensure a clean test environment
            _context = CreateAndSeedContext();

            // New up the controller
            using (var controller = new InstructorsController(_context))
            {
                // Perform some work in here
                var results = controller.GetByRole(1);

                // Assert that the work was completed correctly
                Assert.NotEmpty(results);
            }
        }
        [Fact]
        public void CanGetInstructorsByStatus()
        {
            // Seed the new context on each test to ensure a clean test environment
            _context = CreateAndSeedContext();

            // New up the controller
            using (var controller = new InstructorsController(_context))
            {
                // Perform some work in here
                var results = controller.GetByStatus(1);

                // Assert that the work was completed correctly
                Assert.NotEmpty(results);
            }
        }

        [Fact]
        public void CanAddInstructorFromBody()
        {
            // Seed the new context on each test to ensure a clean test environment
            _context = CreateAndSeedContext();

            // New up the controller
            using (var controller = new InstructorsController(_context))
            {
                // Perform some work in here
                var results = controller.CreateFromBody( new Instructor { FirstName = "Atest"
                    , LastName = "This"
                    , MiddleName = "Isa"
                    , Address = "1234 A Valid Address Rd"
                    , Email = "notarealemail@notarealdomain.com"
                    , PhoneNumber = "1234567890"
                    , MobilePhoneNumber = "1234567890"
                    , EmergencyContactName = "Random"
                    , EmergencyContactPhone = "9119119119"
                    , Role = 0
                    , Status = 0
                    , EmploymentStartDate = DateTime.Now
                    , EmploymentTerminationDate = DateTime.Now } );

                // Assert that the work was completed correctly
                Instructor result = controller.GetByName("Atest").First();
                Assert.NotNull(result);
            }
        }

       [Fact]
        public void CanUpdateInstructorFirstNameFromBody()
        {
            // Seed the new context on each test to ensure a clean test environment
            _context = CreateAndSeedContext();

            // New up the controller
            using (var controller = new InstructorsController(_context))
            {
                // Perform some work in here
                var results = controller.CreateFromBody( new Instructor { FirstName = "Atest"
                    , LastName = "This"
                    , MiddleName = "Isa"
                    , Address = "1234 A Valid Address Rd"
                    , Email = "notarealemail@notarealdomain.com"
                    , PhoneNumber = "1234567890"
                    , MobilePhoneNumber = "1234567890"
                    , EmergencyContactName = "Random"
                    , EmergencyContactPhone = "9119119119"
                    , Role = 0
                    , Status = 0
                    , EmploymentStartDate = DateTime.Now
                    , EmploymentTerminationDate = DateTime.Now } );

                // Assert that the work was completed correctly
                Instructor result = controller.GetByName("Atest").First();
                Assert.NotNull(result);

                result.FirstName = "Richard";
                var results2 = controller.UpdateFromBody(result);

                Instructor updatedresult = controller.GetByName("Richard").First();
                Assert.NotNull(results2);
                Assert.True(updatedresult.FirstName == "Richard");
            }
        }

        [Fact]
        public void CanUpdateInstructorLastNameFromBody()
        {
            // Seed the new context on each test to ensure a clean test environment
            _context = CreateAndSeedContext();

            // New up the controller
            using (var controller = new InstructorsController(_context))
            {
                // Perform some work in here
                var results = controller.CreateFromBody( new Instructor { FirstName = "Atest"
                    , LastName = "This"
                    , MiddleName = "Isa"
                    , Address = "1234 A Valid Address Rd"
                    , Email = "notarealemail@notarealdomain.com"
                    , PhoneNumber = "1234567890"
                    , MobilePhoneNumber = "1234567890"
                    , EmergencyContactName = "Random"
                    , EmergencyContactPhone = "9119119119"
                    , Role = 0
                    , Status = 0
                    , EmploymentStartDate = DateTime.Now
                    , EmploymentTerminationDate = DateTime.Now } );

                // Assert that the work was completed correctly
                Instructor result = controller.GetByName("Atest").First();
                Assert.NotNull(result);

                result.LastName = "Tran";
                var results2 = controller.UpdateFromBody(result);

                Instructor updatedresult = controller.GetByName("Atest").First();
                Assert.NotNull(results2);
                Assert.True(updatedresult.LastName == "Tran");
            }
        }

         [Fact]
        public void CanUpdateInstructorMiddleNameFromBody()
        {
            // Seed the new context on each test to ensure a clean test environment
            _context = CreateAndSeedContext();

            // New up the controller
            using (var controller = new InstructorsController(_context))
            {
                // Perform some work in here
                var results = controller.CreateFromBody( new Instructor { FirstName = "Atest"
                    , LastName = "This"
                    , MiddleName = "Isa"
                    , Address = "1234 A Valid Address Rd"
                    , Email = "notarealemail@notarealdomain.com"
                    , PhoneNumber = "1234567890"
                    , MobilePhoneNumber = "1234567890"
                    , EmergencyContactName = "Random"
                    , EmergencyContactPhone = "9119119119"
                    , Role = 0
                    , Status = 0
                    , EmploymentStartDate = DateTime.Now
                    , EmploymentTerminationDate = DateTime.Now } );

                // Assert that the work was completed correctly
                Instructor result = controller.GetByName("Atest").First();
                Assert.NotNull(result);

                result.MiddleName = "Bob";
                var results2 = controller.UpdateFromBody(result);

                Instructor updatedresult = controller.GetByName("Atest").First();
                Assert.NotNull(results2);
                Assert.True(updatedresult.MiddleName == "Bob");
            }
        }

         [Fact]
        public void CanUpdateInstructorAddressFromBody()
        {
            // Seed the new context on each test to ensure a clean test environment
            _context = CreateAndSeedContext();

            // New up the controller
            using (var controller = new InstructorsController(_context))
            {
                // Perform some work in here
                var results = controller.CreateFromBody( new Instructor { FirstName = "Atest"
                    , LastName = "This"
                    , MiddleName = "Isa"
                    , Address = "1234 A Valid Address Rd"
                    , Email = "notarealemail@notarealdomain.com"
                    , PhoneNumber = "1234567890"
                    , MobilePhoneNumber = "1234567890"
                    , EmergencyContactName = "Random"
                    , EmergencyContactPhone = "9119119119"
                    , Role = 0
                    , Status = 0
                    , EmploymentStartDate = DateTime.Now
                    , EmploymentTerminationDate = DateTime.Now } );

                // Assert that the work was completed correctly
                Instructor result = controller.GetByName("Atest").First();
                Assert.NotNull(result);

                result.Address = "123 Rocky Road";
                var results2 = controller.UpdateFromBody(result);

                Instructor updatedresult = controller.GetByName("Atest").First();
                Assert.NotNull(results2);
                Assert.True(updatedresult.Address == "123 Rocky Road");
            }
        }

         [Fact]
        public void CanUpdateInstructorEmailFromBody()
        {
            // Seed the new context on each test to ensure a clean test environment
            _context = CreateAndSeedContext();

            // New up the controller
            using (var controller = new InstructorsController(_context))
            {
                // Perform some work in here
                var results = controller.CreateFromBody( new Instructor { FirstName = "Atest"
                    , LastName = "This"
                    , MiddleName = "Isa"
                    , Address = "1234 A Valid Address Rd"
                    , Email = "notarealemail@notarealdomain.com"
                    , PhoneNumber = "1234567890"
                    , MobilePhoneNumber = "1234567890"
                    , EmergencyContactName = "Random"
                    , EmergencyContactPhone = "9119119119"
                    , Role = 0
                    , Status = 0
                    , EmploymentStartDate = DateTime.Now
                    , EmploymentTerminationDate = DateTime.Now } );

                // Assert that the work was completed correctly
                Instructor result = controller.GetByName("Atest").First();
                Assert.NotNull(result);

                result.Email = "spicytaco@theborder.com";
                var results2 = controller.UpdateFromBody(result);

                Instructor updatedresult = controller.GetByName("Atest").First();
                Assert.NotNull(results2);
                Assert.True(updatedresult.Email == "spicytaco@theborder.com");
            }
        }

         [Fact]
        public void CanUpdateInstructorPhoneNumberFromBody()
        {
            // Seed the new context on each test to ensure a clean test environment
            _context = CreateAndSeedContext();

            // New up the controller
            using (var controller = new InstructorsController(_context))
            {
                // Perform some work in here
                var results = controller.CreateFromBody( new Instructor { FirstName = "Atest"
                    , LastName = "This"
                    , MiddleName = "Isa"
                    , Address = "1234 A Valid Address Rd"
                    , Email = "notarealemail@notarealdomain.com"
                    , PhoneNumber = "2108675309"
                    , MobilePhoneNumber = "1234567890"
                    , EmergencyContactName = "Random"
                    , EmergencyContactPhone = "9119119119"
                    , Role = 0
                    , Status = 0
                    , EmploymentStartDate = DateTime.Now
                    , EmploymentTerminationDate = DateTime.Now } );

                // Assert that the work was completed correctly
                Instructor result = controller.GetByName("Atest").First();
                Assert.NotNull(result);

                result.PhoneNumber = "2104936336";
                var results2 = controller.UpdateFromBody(result);

                Instructor updatedresult = controller.GetByName("Atest").First();
                Assert.NotNull(results2);
                Assert.True(updatedresult.PhoneNumber == "2104936336");
            }
        }

         [Fact]
        public void CanUpdateInstructorMobileFromBody()
        {
            // Seed the new context on each test to ensure a clean test environment
            _context = CreateAndSeedContext();

            // New up the controller
            using (var controller = new InstructorsController(_context))
            {
                // Perform some work in here
                var results = controller.CreateFromBody( new Instructor { FirstName = "Atest"
                    , LastName = "This"
                    , MiddleName = "Isa"
                    , Address = "1234 A Valid Address Rd"
                    , Email = "notarealemail@notarealdomain.com"
                    , PhoneNumber = "1234567890"
                    , MobilePhoneNumber = "1234567890"
                    , EmergencyContactName = "Random"
                    , EmergencyContactPhone = "9119119119"
                    , Role = 0
                    , Status = 0
                    , EmploymentStartDate = DateTime.Now
                    , EmploymentTerminationDate = DateTime.Now } );

                // Assert that the work was completed correctly
                Instructor result = controller.GetByName("Atest").First();
                Assert.NotNull(result);

                result.MobilePhoneNumber = "1111111111";
                var results2 = controller.UpdateFromBody(result);

                Instructor updatedresult = controller.GetByName("Atest").First();
                Assert.NotNull(results2);
                Assert.True(updatedresult.MobilePhoneNumber == "1111111111");
            }
        }

         [Fact]
        public void CanUpdateInstructorEmergencyNameFromBody()
        {
            // Seed the new context on each test to ensure a clean test environment
            _context = CreateAndSeedContext();

            // New up the controller
            using (var controller = new InstructorsController(_context))
            {
                // Perform some work in here
                var results = controller.CreateFromBody( new Instructor { FirstName = "Atest"
                    , LastName = "This"
                    , MiddleName = "Isa"
                    , Address = "1234 A Valid Address Rd"
                    , Email = "notarealemail@notarealdomain.com"
                    , PhoneNumber = "1234567890"
                    , MobilePhoneNumber = "1234567890"
                    , EmergencyContactName = "Random"
                    , EmergencyContactPhone = "9119119119"
                    , Role = 0
                    , Status = 0
                    , EmploymentStartDate = DateTime.Now
                    , EmploymentTerminationDate = DateTime.Now } );

                // Assert that the work was completed correctly
                Instructor result = controller.GetByName("Atest").First();
                Assert.NotNull(result);

                result.EmergencyContactName = "Tranwreck";
                var results2 = controller.UpdateFromBody(result);

                Instructor updatedresult = controller.GetByName("Atest").First();
                Assert.NotNull(results2);
                Assert.True(updatedresult.EmergencyContactName == "Tranwreck");
            }
        }

         [Fact]
        public void CanUpdateInstructorEmergencyPhoneFromBody()
        {
            // Seed the new context on each test to ensure a clean test environment
            _context = CreateAndSeedContext();

            // New up the controller
            using (var controller = new InstructorsController(_context))
            {
                // Perform some work in here
                var results = controller.CreateFromBody( new Instructor { FirstName = "Atest"
                    , LastName = "This"
                    , MiddleName = "Isa"
                    , Address = "1234 A Valid Address Rd"
                    , Email = "notarealemail@notarealdomain.com"
                    , PhoneNumber = "1234567890"
                    , MobilePhoneNumber = "1234567890"
                    , EmergencyContactName = "Random"
                    , EmergencyContactPhone = "9119119119"
                    , Role = 0
                    , Status = 0
                    , EmploymentStartDate = DateTime.Now
                    , EmploymentTerminationDate = DateTime.Now } );

                // Assert that the work was completed correctly
                Instructor result = controller.GetByName("Atest").First();
                Assert.NotNull(result);

                result.EmergencyContactPhone = "1597531597";
                var results2 = controller.UpdateFromBody(result);

                Instructor updatedresult = controller.GetByName("Atest").First();
                Assert.NotNull(results2);
                Assert.True(updatedresult.EmergencyContactPhone == "1597531597");
            }
        }

         [Fact]
        public void CanUpdateInstructorRoleFromBody()
        {
            // Seed the new context on each test to ensure a clean test environment
            _context = CreateAndSeedContext();

            // New up the controller
            using (var controller = new InstructorsController(_context))
            {
                // Perform some work in here
                var results = controller.CreateFromBody( new Instructor { FirstName = "Atest"
                    , LastName = "This"
                    , MiddleName = "Isa"
                    , Address = "1234 A Valid Address Rd"
                    , Email = "notarealemail@notarealdomain.com"
                    , PhoneNumber = "1234567890"
                    , MobilePhoneNumber = "1234567890"
                    , EmergencyContactName = "Random"
                    , EmergencyContactPhone = "9119119119"
                    , Role = 0
                    , Status = 0
                    , EmploymentStartDate = DateTime.Now
                    , EmploymentTerminationDate = DateTime.Now } );

                // Assert that the work was completed correctly
                Instructor result = controller.GetByName("Atest").First();
                Assert.NotNull(result);

                result.Role = 1;
                var results2 = controller.UpdateFromBody(result);

                Instructor updatedresult = controller.GetByName("Atest").First();
                Assert.NotNull(results2);
                Assert.True(updatedresult.Role == 1);
            }
        }

         [Fact]
        public void CanUpdateInstructorStatusFromBody()
        {
            // Seed the new context on each test to ensure a clean test environment
            _context = CreateAndSeedContext();

            // New up the controller
            using (var controller = new InstructorsController(_context))
            {
                // Perform some work in here
                var results = controller.CreateFromBody( new Instructor { FirstName = "Atest"
                    , LastName = "This"
                    , MiddleName = "Isa"
                    , Address = "1234 A Valid Address Rd"
                    , Email = "notarealemail@notarealdomain.com"
                    , PhoneNumber = "1234567890"
                    , MobilePhoneNumber = "1234567890"
                    , EmergencyContactName = "Random"
                    , EmergencyContactPhone = "9119119119"
                    , Role = 0
                    , Status = 0
                    , EmploymentStartDate = DateTime.Now
                    , EmploymentTerminationDate = DateTime.Now } );

                // Assert that the work was completed correctly
                Instructor result = controller.GetByName("Atest").First();
                Assert.NotNull(result);

                result.Status = 1;
                var results2 = controller.UpdateFromBody(result);

                Instructor updatedresult = controller.GetByName("Atest").First();
                Assert.NotNull(results2);
                Assert.True(updatedresult.Status == 1);
            }
        }

         [Fact]
        public void CanUpdateInstructorEmploymentStartFromBody()
        {
            // Seed the new context on each test to ensure a clean test environment
            _context = CreateAndSeedContext();

            // New up the controller
            using (var controller = new InstructorsController(_context))
            {
                // Perform some work in here
                var results = controller.CreateFromBody( new Instructor { FirstName = "Atest"
                    , LastName = "This"
                    , MiddleName = "Isa"
                    , Address = "1234 A Valid Address Rd"
                    , Email = "notarealemail@notarealdomain.com"
                    , PhoneNumber = "1234567890"
                    , MobilePhoneNumber = "1234567890"
                    , EmergencyContactName = "Random"
                    , EmergencyContactPhone = "9119119119"
                    , Role = 0
                    , Status = 0
                    , EmploymentStartDate = DateTime.Now
                    , EmploymentTerminationDate = DateTime.Now } );

                // Assert that the work was completed correctly
                Instructor result = controller.GetByName("Atest").First();
                Assert.NotNull(result);

                DateTime newhire = DateTime.Now;
                result.EmploymentStartDate = newhire;
                var results2 = controller.UpdateFromBody(result);

                Instructor updatedresult = controller.GetByName("Atest").First();
                Assert.NotNull(results2);
                Assert.True(updatedresult.EmploymentStartDate == newhire);
            }
        }

         [Fact]
        public void CanUpdateInstructorEmploymentEndFromBody()
        {
            // Seed the new context on each test to ensure a clean test environment
            _context = CreateAndSeedContext();

            // New up the controller
            using (var controller = new InstructorsController(_context))
            {
                // Perform some work in here
                var results = controller.CreateFromBody( new Instructor { FirstName = "Atest"
                    , LastName = "This"
                    , MiddleName = "Isa"
                    , Address = "1234 A Valid Address Rd"
                    , Email = "notarealemail@notarealdomain.com"
                    , PhoneNumber = "1234567890"
                    , MobilePhoneNumber = "1234567890"
                    , EmergencyContactName = "Random"
                    , EmergencyContactPhone = "9119119119"
                    , Role = 0
                    , Status = 0
                    , EmploymentStartDate = DateTime.Now
                    , EmploymentTerminationDate = DateTime.Now } );

                // Assert that the work was completed correctly
                Instructor result = controller.GetByName("Atest").First();
                Assert.NotNull(result);

                DateTime fired = DateTime.Now;
                result.EmploymentTerminationDate = fired;
                var results2 = controller.UpdateFromBody(result);

                Instructor updatedresult = controller.GetByName("Atest").First();
                Assert.NotNull(results2);
                Assert.True(updatedresult.EmploymentTerminationDate == fired);
            }
        }

        [Fact]
        public void CanUpdateInstructorFirstNameFromForm()
        {
            // Seed the new context on each test to ensure a clean test environment
            _context = CreateAndSeedContext();

            // New up the controller
            using (var controller = new InstructorsController(_context))
            {
                // Perform some work in here
                var results = controller.CreateFromForm( new Instructor { FirstName = "Atest"
                    , LastName = "This"
                    , MiddleName = "Isa"
                    , Address = "1234 A Valid Address Rd"
                    , Email = "notarealemail@notarealdomain.com"
                    , PhoneNumber = "1234567890"
                    , MobilePhoneNumber = "1234567890"
                    , EmergencyContactName = "Random"
                    , EmergencyContactPhone = "9119119119"
                    , Role = 0
                    , Status = 0
                    , EmploymentStartDate = DateTime.Now
                    , EmploymentTerminationDate = DateTime.Now } );

                // Assert that the work was completed correctly
                Instructor result = controller.GetByName("Atest").First();
                Assert.NotNull(result);

                result.FirstName = "Richard";
                var results2 = controller.UpdateFromForm(result);

                Instructor updatedresult = controller.GetByName("Richard").First();
                Assert.NotNull(results2);
                Assert.True(updatedresult.FirstName == "Richard");
            }
        }

        [Fact]
        public void CanUpdateInstructorLastNameFromForm()
        {
            // Seed the new context on each test to ensure a clean test environment
            _context = CreateAndSeedContext();

            // New up the controller
            using (var controller = new InstructorsController(_context))
            {
                // Perform some work in here
                var results = controller.CreateFromForm( new Instructor { FirstName = "Atest"
                    , LastName = "This"
                    , MiddleName = "Isa"
                    , Address = "1234 A Valid Address Rd"
                    , Email = "notarealemail@notarealdomain.com"
                    , PhoneNumber = "1234567890"
                    , MobilePhoneNumber = "1234567890"
                    , EmergencyContactName = "Random"
                    , EmergencyContactPhone = "9119119119"
                    , Role = 0
                    , Status = 0
                    , EmploymentStartDate = DateTime.Now
                    , EmploymentTerminationDate = DateTime.Now } );

                // Assert that the work was completed correctly
                Instructor result = controller.GetByName("Atest").First();
                Assert.NotNull(result);

                result.LastName = "Tran";
                var results2 = controller.UpdateFromForm(result);

                Instructor updatedresult = controller.GetByName("Atest").First();
                Assert.NotNull(results2);
                Assert.True(updatedresult.LastName == "Tran");
            }
        }

         [Fact]
        public void CanUpdateInstructorMiddleNameFromForm()
        {
            // Seed the new context on each test to ensure a clean test environment
            _context = CreateAndSeedContext();

            // New up the controller
            using (var controller = new InstructorsController(_context))
            {
                // Perform some work in here
                var results = controller.CreateFromForm( new Instructor { FirstName = "Atest"
                    , LastName = "This"
                    , MiddleName = "Isa"
                    , Address = "1234 A Valid Address Rd"
                    , Email = "notarealemail@notarealdomain.com"
                    , PhoneNumber = "1234567890"
                    , MobilePhoneNumber = "1234567890"
                    , EmergencyContactName = "Random"
                    , EmergencyContactPhone = "9119119119"
                    , Role = 0
                    , Status = 0
                    , EmploymentStartDate = DateTime.Now
                    , EmploymentTerminationDate = DateTime.Now } );

                // Assert that the work was completed correctly
                Instructor result = controller.GetByName("Atest").First();
                Assert.NotNull(result);

                result.MiddleName = "Bob";
                var results2 = controller.UpdateFromForm(result);

                Instructor updatedresult = controller.GetByName("Atest").First();
                Assert.NotNull(results2);
                Assert.True(updatedresult.MiddleName == "Bob");
            }
        }

         [Fact]
        public void CanUpdateInstructorAddressFromForm()
        {
            // Seed the new context on each test to ensure a clean test environment
            _context = CreateAndSeedContext();

            // New up the controller
            using (var controller = new InstructorsController(_context))
            {
                // Perform some work in here
                var results = controller.CreateFromForm( new Instructor { FirstName = "Atest"
                    , LastName = "This"
                    , MiddleName = "Isa"
                    , Address = "1234 A Valid Address Rd"
                    , Email = "notarealemail@notarealdomain.com"
                    , PhoneNumber = "1234567890"
                    , MobilePhoneNumber = "1234567890"
                    , EmergencyContactName = "Random"
                    , EmergencyContactPhone = "9119119119"
                    , Role = 0
                    , Status = 0
                    , EmploymentStartDate = DateTime.Now
                    , EmploymentTerminationDate = DateTime.Now } );

                // Assert that the work was completed correctly
                Instructor result = controller.GetByName("Atest").First();
                Assert.NotNull(result);

                result.Address = "123 Rocky Road";
                var results2 = controller.UpdateFromForm(result);

                Instructor updatedresult = controller.GetByName("Atest").First();
                Assert.NotNull(results2);
                Assert.True(updatedresult.Address == "123 Rocky Road");
            }
        }

         [Fact]
        public void CanUpdateInstructorEmailFromForm()
        {
            // Seed the new context on each test to ensure a clean test environment
            _context = CreateAndSeedContext();

            // New up the controller
            using (var controller = new InstructorsController(_context))
            {
                // Perform some work in here
                var results = controller.CreateFromForm( new Instructor { FirstName = "Atest"
                    , LastName = "This"
                    , MiddleName = "Isa"
                    , Address = "1234 A Valid Address Rd"
                    , Email = "notarealemail@notarealdomain.com"
                    , PhoneNumber = "1234567890"
                    , MobilePhoneNumber = "1234567890"
                    , EmergencyContactName = "Random"
                    , EmergencyContactPhone = "9119119119"
                    , Role = 0
                    , Status = 0
                    , EmploymentStartDate = DateTime.Now
                    , EmploymentTerminationDate = DateTime.Now } );

                // Assert that the work was completed correctly
                Instructor result = controller.GetByName("Atest").First();
                Assert.NotNull(result);

                result.Email = "spicytaco@theborder.com";
                var results2 = controller.UpdateFromForm(result);

                Instructor updatedresult = controller.GetByName("Atest").First();
                Assert.NotNull(results2);
                Assert.True(updatedresult.Email == "spicytaco@theborder.com");
            }
        }

         [Fact]
        public void CanUpdateInstructorPhoneNumberFromForm()
        {
            // Seed the new context on each test to ensure a clean test environment
            _context = CreateAndSeedContext();

            // New up the controller
            using (var controller = new InstructorsController(_context))
            {
                // Perform some work in here
                var results = controller.CreateFromForm( new Instructor { FirstName = "Atest"
                    , LastName = "This"
                    , MiddleName = "Isa"
                    , Address = "1234 A Valid Address Rd"
                    , Email = "notarealemail@notarealdomain.com"
                    , PhoneNumber = "2108675309"
                    , MobilePhoneNumber = "1234567890"
                    , EmergencyContactName = "Random"
                    , EmergencyContactPhone = "9119119119"
                    , Role = 0
                    , Status = 0
                    , EmploymentStartDate = DateTime.Now
                    , EmploymentTerminationDate = DateTime.Now } );

                // Assert that the work was completed correctly
                Instructor result = controller.GetByName("Atest").First();
                Assert.NotNull(result);

                result.PhoneNumber = "2104936336";
                var results2 = controller.UpdateFromForm(result);

                Instructor updatedresult = controller.GetByName("Atest").First();
                Assert.NotNull(results2);
                Assert.True(updatedresult.PhoneNumber == "2104936336");
            }
        }

         [Fact]
        public void CanUpdateInstructorMobileFromForm()
        {
            // Seed the new context on each test to ensure a clean test environment
            _context = CreateAndSeedContext();

            // New up the controller
            using (var controller = new InstructorsController(_context))
            {
                // Perform some work in here
                var results = controller.CreateFromForm( new Instructor { FirstName = "Atest"
                    , LastName = "This"
                    , MiddleName = "Isa"
                    , Address = "1234 A Valid Address Rd"
                    , Email = "notarealemail@notarealdomain.com"
                    , PhoneNumber = "1234567890"
                    , MobilePhoneNumber = "1234567890"
                    , EmergencyContactName = "Random"
                    , EmergencyContactPhone = "9119119119"
                    , Role = 0
                    , Status = 0
                    , EmploymentStartDate = DateTime.Now
                    , EmploymentTerminationDate = DateTime.Now } );

                // Assert that the work was completed correctly
                Instructor result = controller.GetByName("Atest").First();
                Assert.NotNull(result);

                result.MobilePhoneNumber = "1111111111";
                var results2 = controller.UpdateFromForm(result);

                Instructor updatedresult = controller.GetByName("Atest").First();
                Assert.NotNull(results2);
                Assert.True(updatedresult.MobilePhoneNumber == "1111111111");
            }
        }

         [Fact]
        public void CanUpdateInstructorEmergencyNameFromForm()
        {
            // Seed the new context on each test to ensure a clean test environment
            _context = CreateAndSeedContext();

            // New up the controller
            using (var controller = new InstructorsController(_context))
            {
                // Perform some work in here
                var results = controller.CreateFromForm( new Instructor { FirstName = "Atest"
                    , LastName = "This"
                    , MiddleName = "Isa"
                    , Address = "1234 A Valid Address Rd"
                    , Email = "notarealemail@notarealdomain.com"
                    , PhoneNumber = "1234567890"
                    , MobilePhoneNumber = "1234567890"
                    , EmergencyContactName = "Random"
                    , EmergencyContactPhone = "9119119119"
                    , Role = 0
                    , Status = 0
                    , EmploymentStartDate = DateTime.Now
                    , EmploymentTerminationDate = DateTime.Now } );

                // Assert that the work was completed correctly
                Instructor result = controller.GetByName("Atest").First();
                Assert.NotNull(result);

                result.EmergencyContactName = "Tranwreck";
                var results2 = controller.UpdateFromForm(result);

                Instructor updatedresult = controller.GetByName("Atest").First();
                Assert.NotNull(results2);
                Assert.True(updatedresult.EmergencyContactName == "Tranwreck");
            }
        }

         [Fact]
        public void CanUpdateInstructorEmergencyPhoneFromForm()
        {
            // Seed the new context on each test to ensure a clean test environment
            _context = CreateAndSeedContext();

            // New up the controller
            using (var controller = new InstructorsController(_context))
            {
                // Perform some work in here
                var results = controller.CreateFromForm( new Instructor { FirstName = "Atest"
                    , LastName = "This"
                    , MiddleName = "Isa"
                    , Address = "1234 A Valid Address Rd"
                    , Email = "notarealemail@notarealdomain.com"
                    , PhoneNumber = "1234567890"
                    , MobilePhoneNumber = "1234567890"
                    , EmergencyContactName = "Random"
                    , EmergencyContactPhone = "9119119119"
                    , Role = 0
                    , Status = 0
                    , EmploymentStartDate = DateTime.Now
                    , EmploymentTerminationDate = DateTime.Now } );

                // Assert that the work was completed correctly
                Instructor result = controller.GetByName("Atest").First();
                Assert.NotNull(result);

                result.EmergencyContactPhone = "1597531597";
                var results2 = controller.UpdateFromForm(result);

                Instructor updatedresult = controller.GetByName("Atest").First();
                Assert.NotNull(results2);
                Assert.True(updatedresult.EmergencyContactPhone == "1597531597");
            }
        }

         [Fact]
        public void CanUpdateInstructorRoleFromForm()
        {
            // Seed the new context on each test to ensure a clean test environment
            _context = CreateAndSeedContext();

            // New up the controller
            using (var controller = new InstructorsController(_context))
            {
                // Perform some work in here
                var results = controller.CreateFromForm( new Instructor { FirstName = "Atest"
                    , LastName = "This"
                    , MiddleName = "Isa"
                    , Address = "1234 A Valid Address Rd"
                    , Email = "notarealemail@notarealdomain.com"
                    , PhoneNumber = "1234567890"
                    , MobilePhoneNumber = "1234567890"
                    , EmergencyContactName = "Random"
                    , EmergencyContactPhone = "9119119119"
                    , Role = 0
                    , Status = 0
                    , EmploymentStartDate = DateTime.Now
                    , EmploymentTerminationDate = DateTime.Now } );

                // Assert that the work was completed correctly
                Instructor result = controller.GetByName("Atest").First();
                Assert.NotNull(result);

                result.Role = 1;
                var results2 = controller.UpdateFromForm(result);

                Instructor updatedresult = controller.GetByName("Atest").First();
                Assert.NotNull(results2);
                Assert.True(updatedresult.Role == 1);
            }
        }

         [Fact]
        public void CanUpdateInstructorStatusFromForm()
        {
            // Seed the new context on each test to ensure a clean test environment
            _context = CreateAndSeedContext();

            // New up the controller
            using (var controller = new InstructorsController(_context))
            {
                // Perform some work in here
                var results = controller.CreateFromForm( new Instructor { FirstName = "Atest"
                    , LastName = "This"
                    , MiddleName = "Isa"
                    , Address = "1234 A Valid Address Rd"
                    , Email = "notarealemail@notarealdomain.com"
                    , PhoneNumber = "1234567890"
                    , MobilePhoneNumber = "1234567890"
                    , EmergencyContactName = "Random"
                    , EmergencyContactPhone = "9119119119"
                    , Role = 0
                    , Status = 0
                    , EmploymentStartDate = DateTime.Now
                    , EmploymentTerminationDate = DateTime.Now } );

                // Assert that the work was completed correctly
                Instructor result = controller.GetByName("Atest").First();
                Assert.NotNull(result);

                result.Status = 1;
                var results2 = controller.UpdateFromForm(result);

                Instructor updatedresult = controller.GetByName("Atest").First();
                Assert.NotNull(results2);
                Assert.True(updatedresult.Status == 1);
            }
        }

         [Fact]
        public void CanUpdateInstructorEmploymentStartFromForm()
        {
            // Seed the new context on each test to ensure a clean test environment
            _context = CreateAndSeedContext();

            // New up the controller
            using (var controller = new InstructorsController(_context))
            {
                // Perform some work in here
                var results = controller.CreateFromForm( new Instructor { FirstName = "Atest"
                    , LastName = "This"
                    , MiddleName = "Isa"
                    , Address = "1234 A Valid Address Rd"
                    , Email = "notarealemail@notarealdomain.com"
                    , PhoneNumber = "1234567890"
                    , MobilePhoneNumber = "1234567890"
                    , EmergencyContactName = "Random"
                    , EmergencyContactPhone = "9119119119"
                    , Role = 0
                    , Status = 0
                    , EmploymentStartDate = DateTime.Now
                    , EmploymentTerminationDate = DateTime.Now } );

                // Assert that the work was completed correctly
                Instructor result = controller.GetByName("Atest").First();
                Assert.NotNull(result);

                DateTime newhire = DateTime.Now;
                result.EmploymentStartDate = newhire;
                var results2 = controller.UpdateFromForm(result);

                Instructor updatedresult = controller.GetByName("Atest").First();
                Assert.NotNull(results2);
                Assert.True(updatedresult.EmploymentStartDate == newhire);
            }
        }

         [Fact]
        public void CanUpdateInstructorEmploymentEndFromForm()
        {
            // Seed the new context on each test to ensure a clean test environment
            _context = CreateAndSeedContext();

            // New up the controller
            using (var controller = new InstructorsController(_context))
            {
                // Perform some work in here
                var results = controller.CreateFromForm( new Instructor { FirstName = "Atest"
                    , LastName = "This"
                    , MiddleName = "Isa"
                    , Address = "1234 A Valid Address Rd"
                    , Email = "notarealemail@notarealdomain.com"
                    , PhoneNumber = "1234567890"
                    , MobilePhoneNumber = "1234567890"
                    , EmergencyContactName = "Random"
                    , EmergencyContactPhone = "9119119119"
                    , Role = 0
                    , Status = 0
                    , EmploymentStartDate = DateTime.Now
                    , EmploymentTerminationDate = DateTime.Now } );

                // Assert that the work was completed correctly
                Instructor result = controller.GetByName("Atest").First();
                Assert.NotNull(result);

                DateTime fired = DateTime.Now;
                result.EmploymentTerminationDate = fired;
                var results2 = controller.UpdateFromForm(result);

                Instructor updatedresult = controller.GetByName("Atest").First();
                Assert.NotNull(results2);
                Assert.True(updatedresult.EmploymentTerminationDate == fired);
            }
        }

        [Fact]
        public void CanAddInstructorFromForm()
        {
            // Seed the new context on each test to ensure a clean test environment
            _context = CreateAndSeedContext();

            // New up the controller
            using (var controller = new InstructorsController(_context))
            {
                // Perform some work in here
                var results = controller.CreateFromForm( new Instructor { FirstName = "Atest"
                    , LastName = "This"
                    , MiddleName = "Isa"
                    , Address = "1234 A Valid Address Rd"
                    , Email = "notarealemail@notarealdomain.com"
                    , PhoneNumber = "1234567890"
                    , MobilePhoneNumber = "1234567890"
                    , EmergencyContactName = "Random"
                    , EmergencyContactPhone = "9119119119"
                    , Role = 0
                    , Status = 0
                    , EmploymentStartDate = DateTime.Now
                    , EmploymentTerminationDate = DateTime.Now } );

                // Assert that the work was completed correctly
                Instructor result = controller.GetByName("Atest").First();
                Assert.NotNull(result);
            }
        }

        [Fact]
        public void CanDeleteInstructorFromBody()
        {
            // Seed the new context on each test to ensure a clean test environment
            _context = CreateAndSeedContext();

            // New up the controller
            using (var controller = new InstructorsController(_context))
            {
                // Perform some work in here
                var results = controller.CreateFromBody( new Instructor { FirstName = "Atest"
                    , LastName = "This"
                    , MiddleName = "Isa"
                    , Address = "1234 A Valid Address Rd"
                    , Email = "notarealemail@notarealdomain.com"
                    , PhoneNumber = "1234567890"
                    , MobilePhoneNumber = "1234567890"
                    , EmergencyContactName = "Random"
                    , EmergencyContactPhone = "9119119119"
                    , Role = 0
                    , Status = 0
                    , EmploymentStartDate = DateTime.Now
                    , EmploymentTerminationDate = DateTime.Now } );

                // Assert that the work was completed correctly
                Instructor result = controller.GetByName("Atest").First();
                Assert.NotNull(result);

                controller.DeleteFromBody(result);
                Assert.Empty(controller.GetByName("Atest"));
            }
        }

        [Fact]
        public void CanDeleteInstructorFromForm()
        {
            // Seed the new context on each test to ensure a clean test environment
            _context = CreateAndSeedContext();

            // New up the controller
            using (var controller = new InstructorsController(_context))
            {
                // Perform some work in here
                var results = controller.CreateFromForm( new Instructor { FirstName = "Atest"
                    , LastName = "This"
                    , MiddleName = "Isa"
                    , Address = "1234 A Valid Address Rd"
                    , Email = "notarealemail@notarealdomain.com"
                    , PhoneNumber = "1234567890"
                    , MobilePhoneNumber = "1234567890"
                    , EmergencyContactName = "Random"
                    , EmergencyContactPhone = "9119119119"
                    , Role = 0
                    , Status = 0
                    , EmploymentStartDate = DateTime.Now
                    , EmploymentTerminationDate = DateTime.Now } );

                // Assert that the work was completed correctly
                Instructor result = controller.GetByName("Atest").First();
                Assert.NotNull(result);

                controller.DeleteFromForm(result);
                Assert.Empty(controller.GetByName("Atest"));
            }
        }

        #endregion

        #region Instructor validation tests

        [Fact]
        public void IsInstructorWithAllValid()
        {
            // This instructor is valid
            var instructor = new Instructor { FirstName = "Michale",
                    LastName = "This"
                    , MiddleName = "Isa"
                    , Email = "notarealaddress@notarealdomain.com"
                    , Address = "1234 A Valid Address Rd"
                    , PhoneNumber = "1234567890"
                    , MobilePhoneNumber = "1234567890"
                    , EmergencyContactName = "Random"
                    , EmergencyContactPhone = "8009119119"
                    , Role = 0
                    , Status = 0
                    , EmploymentStartDate = DateTime.Now
                    , EmploymentTerminationDate = DateTime.Now };

            // Try to validate the object
            var context = new ValidationContext(instructor, null, null);
            var results =  new List<ValidationResult>();
            var isModelsStateValid = Validator.TryValidateObject(instructor, context, results, true);

            Assert.True(isModelsStateValid);
        }

          [Fact]
        public void IsInstructorWithoutFirstNameNotValid()
        {
            // This instructor is missing a first name
            var instructor = new Instructor { 
                    LastName = "This"
                    , MiddleName = "Isa"
                    , Email = "notarealaddress@notarealdomain.com"
                    , Address = "1234 A Valid Address Rd"
                    , PhoneNumber = "1234567890"
                    , MobilePhoneNumber = "1234567890"
                    , EmergencyContactName = "Random"
                    , EmergencyContactPhone = "9119119119"
                    , Role = 0
                    , Status = 0
                    , EmploymentStartDate = DateTime.Now
                    , EmploymentTerminationDate = DateTime.Now };

            // Try to validate the object
            var context = new ValidationContext(instructor, null, null);
            var results =  new List<ValidationResult>();
            var isModelsStateValid = Validator.TryValidateObject(instructor, context, results, true);

            Assert.False(isModelsStateValid);
        }

        [Fact]
        public void IsInstructorInvalidFirstNameNotValid()
        {
            // This instructor has invalid 1st name
            var instructor = new Instructor {  FirstName = "Michale88888"
                    ,LastName = "This"
                    , MiddleName = "Isa"
                    , Email = "notarealaddress@notarealdomain.com"
                    , Address = "1234 A Valid Address Rd"
                    , PhoneNumber = "1234567890"
                    , MobilePhoneNumber = "1234567890"
                    , EmergencyContactName = "Random"
                    , EmergencyContactPhone = "9119119119"
                    , Role = 0
                    , Status = 0
                    , EmploymentStartDate = DateTime.Now
                    , EmploymentTerminationDate = DateTime.Now };

            // Try to validate the object
            var context = new ValidationContext(instructor, null, null);
            var results =  new List<ValidationResult>();
            var isModelsStateValid = Validator.TryValidateObject(instructor, context, results, true);

            Assert.False(isModelsStateValid);
        }

        [Fact]
        public void IsInstructorWithoutLastNameNotValid()
        {
            // This instructor is missing a last name
            var instructor = new Instructor { FirstName = "Atest"
                    , MiddleName = "Isa"
                    , Address = "1234 A Valid Address Rd"
                    , Email = "notarealemail@notarealdomain.com"
                    , PhoneNumber = "1234567890"
                    , MobilePhoneNumber = "1234567890"
                    , EmergencyContactName = "Random"
                    , EmergencyContactPhone = "9119119119"
                    , Role = 0
                    , Status = 0
                    , EmploymentStartDate = DateTime.Now
                    , EmploymentTerminationDate = DateTime.Now };

            // Try to validate the object
            var context = new ValidationContext(instructor, null, null);
            var results =  new List<ValidationResult>();
            var isModelsStateValid = Validator.TryValidateObject(instructor, context, results, true);

            Assert.False(isModelsStateValid);
        }

        [Fact]
        public void IsInstructorInvalidLastNameNotValid()
        {
            // This instructor has an invalid last name
            var instructor = new Instructor { FirstName = "Atest"
                    , LastName = "Es%%%ds"
                    , MiddleName = "Isa"
                    , Address = "1234 A Valid Address Rd"
                    , Email = "notarealemail@notarealdomain.com"
                    , PhoneNumber = "1234567890"
                    , MobilePhoneNumber = "1234567890"
                    , EmergencyContactName = "Random"
                    , EmergencyContactPhone = "9119119119"
                    , Role = 0
                    , Status = 0
                    , EmploymentStartDate = DateTime.Now
                    , EmploymentTerminationDate = DateTime.Now };

            // Try to validate the object
            var context = new ValidationContext(instructor, null, null);
            var results =  new List<ValidationResult>();
            var isModelsStateValid = Validator.TryValidateObject(instructor, context, results, true);

            Assert.False(isModelsStateValid);
        }

        [Fact]
        public void IsInstructorWithoutMiddleNameValid()
        {
            // This instructor is missing a middle name
            var instructor = new Instructor { FirstName = "Atest"
                    , LastName = "Isa"
                    , Address = "1234 A Valid Address Rd"
                    , Email = "notarealemail@notarealdomain.com"
                    , PhoneNumber = "1234567890"
                    , MobilePhoneNumber = "1234567890"
                    , EmergencyContactName = "Random"
                    , EmergencyContactPhone = "9119119119"
                    , Role = 0
                    , Status = 0
                    , EmploymentStartDate = DateTime.Now
                    , EmploymentTerminationDate = DateTime.Now };

            // Try to validate the object
            var context = new ValidationContext(instructor, null, null);
            var results =  new List<ValidationResult>();
            var isModelsStateValid = Validator.TryValidateObject(instructor, context, results, true);

            Assert.True(isModelsStateValid);
        }

        [Fact]
        public void IsInstructorInvalidMiddleNameNotValid()
        {
            // This instructor has an invalid middle name
            var instructor = new Instructor { FirstName = "Atest"
                    , LastName = "Esper"
                    , MiddleName = "Isa%%%%%$$"
                    , Address = "1234 A Valid Address Rd"
                    , Email = "notarealemail@notarealdomain.com"
                    , PhoneNumber = "1234567890"
                    , MobilePhoneNumber = "1234567890"
                    , EmergencyContactName = "Random"
                    , EmergencyContactPhone = "9119119119"
                    , Role = 0
                    , Status = 0
                    , EmploymentStartDate = DateTime.Now
                    , EmploymentTerminationDate = DateTime.Now };

            // Try to validate the object
            var context = new ValidationContext(instructor, null, null);
            var results =  new List<ValidationResult>();
            var isModelsStateValid = Validator.TryValidateObject(instructor, context, results, true);

            Assert.False(isModelsStateValid);
        }

        [Fact]
        public void IsInstructorWithoutAddressNotValid()
        {
            // This instructor is missing an address
            var instructor = new Instructor { FirstName = "test"
                    , LastName = "This"
                    , MiddleName = "Isa"
                    , Email = "notarealemail@notarealdomain.com"
                    , PhoneNumber = "1234567890"
                    , MobilePhoneNumber = "1234567890"
                    , EmergencyContactName = "Random"
                    , EmergencyContactPhone = "9119119119"
                    , Role = 0
                    , Status = 0
                    , EmploymentStartDate = DateTime.Now
                    , EmploymentTerminationDate = DateTime.Now };

            // Try to validate the object
            var context = new ValidationContext(instructor, null, null);
            var results =  new List<ValidationResult>();
            var isModelsStateValid = Validator.TryValidateObject(instructor, context, results, true);

            Assert.False(isModelsStateValid);
        }

        [Fact]
        public void IsInstructorInvalidAddressNotValid()
        {
            // This instructor has an invalid address
            var instructor = new Instructor { FirstName = "test"
                    , LastName = "This"
                    , MiddleName = "Isa"
                    , Address = "$$ street"
                    , Email = "notarealemail@notarealdomain.com"
                    , PhoneNumber = "1234567890"
                    , MobilePhoneNumber = "1234567890"
                    , EmergencyContactName = "Random"
                    , EmergencyContactPhone = "9119119119"
                    , Role = 0
                    , Status = 0
                    , EmploymentStartDate = DateTime.Now
                    , EmploymentTerminationDate = DateTime.Now };

            // Try to validate the object
            var context = new ValidationContext(instructor, null, null);
            var results =  new List<ValidationResult>();
            var isModelsStateValid = Validator.TryValidateObject(instructor, context, results, true);

            Assert.False(isModelsStateValid);
        }

        [Fact]
        public void IsInstructorWithoutEmailNotValid()
        {
            // This instructor is missing an Email
            var instructor = new Instructor { FirstName = "test"
                    , LastName = "This"
                    , MiddleName = "Isa"
                    , Address = "1234 A Valid Address Rd"
                    , PhoneNumber = "1234567890"
                    , MobilePhoneNumber = "1234567890"
                    , EmergencyContactName = "Random"
                    , EmergencyContactPhone = "9119119119"
                    , Role = 0
                    , Status = 0
                    , EmploymentStartDate = DateTime.Now
                    , EmploymentTerminationDate = DateTime.Now };

            // Try to validate the object
            var context = new ValidationContext(instructor, null, null);
            var results =  new List<ValidationResult>();
            var isModelsStateValid = Validator.TryValidateObject(instructor, context, results, true);

            Assert.False(isModelsStateValid);
        }

        [Fact]
        public void IsInstructorInvalidEmailNotValid()
        {
            // This instructor has an invalid email
            var instructor = new Instructor { FirstName = "test"
                    , LastName = "This"
                    , MiddleName = "Isa"
                    , Address = "1234 A Valid Address Rd"
                    , Email = "notarealemailnotarealdomain.com"
                    , PhoneNumber = "1234567890"
                    , MobilePhoneNumber = "1234567890"
                    , EmergencyContactName = "Random"
                    , EmergencyContactPhone = "9119119119"
                    , Role = 0
                    , Status = 0
                    , EmploymentStartDate = DateTime.Now
                    , EmploymentTerminationDate = DateTime.Now };

            // Try to validate the object
            var context = new ValidationContext(instructor, null, null);
            var results =  new List<ValidationResult>();
            var isModelsStateValid = Validator.TryValidateObject(instructor, context, results, true);

            Assert.False(isModelsStateValid);
        }

        [Fact]
        public void IsInstructorWithoutPhoneNumberNotValid()
        {
            // This instructor is missing a phone number
            var instructor = new Instructor { FirstName = "test"
                    , LastName = "This"
                    , MiddleName = "Isa"
                    , Email = "notarealaddress@notarealdomain.com"
                    , Address = "1234 A Valid Address Rd"
                    , MobilePhoneNumber = "1234567890"
                    , EmergencyContactName = "Random"
                    , EmergencyContactPhone = "9119119119"
                    , Role = 0
                    , Status = 0
                    , EmploymentStartDate = DateTime.Now
                    , EmploymentTerminationDate = DateTime.Now };

            // Try to validate the object
            var context = new ValidationContext(instructor, null, null);
            var results =  new List<ValidationResult>();
            var isModelsStateValid = Validator.TryValidateObject(instructor, context, results, true);

            Assert.False(isModelsStateValid);
        }

        [Fact]
        public void IsInstructorInvalidPhoneNumberNotValid()
        {
            // This instructor has invalid phone number
            var instructor = new Instructor { FirstName = "test"
                    , LastName = "This"
                    , MiddleName = "Isa"
                    , Email = "notarealaddress@notarealdomain.com"
                    , Address = "1234 A Valid Address Rd"
                    , PhoneNumber = "1212$$1212"
                    , MobilePhoneNumber = "1234567890"
                    , EmergencyContactName = "Random"
                    , EmergencyContactPhone = "9119119119"
                    , Role = 0
                    , Status = 0
                    , EmploymentStartDate = DateTime.Now
                    , EmploymentTerminationDate = DateTime.Now };

            // Try to validate the object
            var context = new ValidationContext(instructor, null, null);
            var results =  new List<ValidationResult>();
            var isModelsStateValid = Validator.TryValidateObject(instructor, context, results, true);

            Assert.False(isModelsStateValid);
        }

        [Fact]
        public void IsInstructorShortPhoneNumberNotValid()
        {
            // This instructor has a short phone number
            var instructor = new Instructor { FirstName = "test"
                    , LastName = "This"
                    , MiddleName = "Isa"
                    , Email = "notarealaddress@notarealdomain.com"
                    , Address = "1234 A Valid Address Rd"
                    , PhoneNumber = "121"
                    , MobilePhoneNumber = "1234567890"
                    , EmergencyContactName = "Random"
                    , EmergencyContactPhone = "9119119119"
                    , Role = 0
                    , Status = 0
                    , EmploymentStartDate = DateTime.Now
                    , EmploymentTerminationDate = DateTime.Now };

            // Try to validate the object
            var context = new ValidationContext(instructor, null, null);
            var results =  new List<ValidationResult>();
            var isModelsStateValid = Validator.TryValidateObject(instructor, context, results, true);

            Assert.False(isModelsStateValid);
        }

        [Fact]
        public void IsInstructorLongPhoneNumberNotValid()
        {
            // This instructor has a long phone number
            var instructor = new Instructor { FirstName = "test"
                    , LastName = "This"
                    , MiddleName = "Isa"
                    , Email = "notarealaddress@notarealdomain.com"
                    , Address = "1234 A Valid Address Rd"
                    , PhoneNumber = "121212121212"
                    , MobilePhoneNumber = "1234567890"
                    , EmergencyContactName = "Random"
                    , EmergencyContactPhone = "9119119119"
                    , Role = 0
                    , Status = 0
                    , EmploymentStartDate = DateTime.Now
                    , EmploymentTerminationDate = DateTime.Now };

            // Try to validate the object
            var context = new ValidationContext(instructor, null, null);
            var results =  new List<ValidationResult>();
            var isModelsStateValid = Validator.TryValidateObject(instructor, context, results, true);

            Assert.False(isModelsStateValid);
        }

        [Fact]
        public void IsInstructorWithoutRoleNotValid()
        {
            // This instructor is missing a Role
            var instructor = new Instructor { FirstName = "test"
                    , LastName = "This"
                    , MiddleName = "Isa"
                    , Email = "notarealaddress@notarealdomain.com"
                    , Address = "1234 A Valid Address Rd"
                    , PhoneNumber = "1234567890"
                    , MobilePhoneNumber = "1234567890"
                    , EmergencyContactName = "Random"
                    , EmergencyContactPhone = "9119119119"
                    , Status = 0
                    , EmploymentStartDate = DateTime.Now
                    , EmploymentTerminationDate = DateTime.Now };

            // Try to validate the object
            var context = new ValidationContext(instructor, null, null);
            var results =  new List<ValidationResult>();
            var isModelsStateValid = Validator.TryValidateObject(instructor, context, results, true);

            Assert.False(isModelsStateValid);
        }

         [Fact]
        public void IsInstructorInvalidRoleNotValid()
        {
            // This instructor has an invalid role
            var instructor = new Instructor { FirstName = "test"
                    , LastName = "This"
                    , MiddleName = "Isa"
                    , Email = "notarealaddress@notarealdomain.com"
                    , Address = "1234 A Valid Address Rd"
                    , PhoneNumber = "1234567890"
                    , MobilePhoneNumber = "1234567890"
                    , EmergencyContactName = "Random"
                    , EmergencyContactPhone = "9119119119"
                    , Role = 11
                    , Status = 0
                    , EmploymentStartDate = DateTime.Now
                    , EmploymentTerminationDate = DateTime.Now };

            // Try to validate the object
            var context = new ValidationContext(instructor, null, null);
            var results =  new List<ValidationResult>();
            var isModelsStateValid = Validator.TryValidateObject(instructor, context, results, true);

            Assert.False(isModelsStateValid);
        }

        [Fact]
        public void IsInstructorWithoutStatusNotValid()
        {
            // This instructor is missing a status
            var instructor = new Instructor { FirstName = "test"
                    , LastName = "This"
                    , MiddleName = "Isa"
                    , Email = "notarealaddress@notarealdomain.com"
                    , Address = "1234 A Valid Address Rd"
                    , PhoneNumber = "1234567890"
                    , MobilePhoneNumber = "1234567890"
                    , EmergencyContactName = "Random"
                    , EmergencyContactPhone = "9119119119"
                    , Role = 0
                    , EmploymentStartDate = DateTime.Now
                    , EmploymentTerminationDate = DateTime.Now };

            // Try to validate the object
            var context = new ValidationContext(instructor, null, null);
            var results =  new List<ValidationResult>();
            var isModelsStateValid = Validator.TryValidateObject(instructor, context, results, true);

            Assert.False(isModelsStateValid);
        }

        [Fact]
        public void IsInstructorInvalidStatusNotValid()
        {
            // This instructor has an invalid status
            var instructor = new Instructor { FirstName = "test"
                    , LastName = "This"
                    , MiddleName = "Isa"
                    , Email = "notarealaddress@notarealdomain.com"
                    , Address = "1234 A Valid Address Rd"
                    , PhoneNumber = "1234567890"
                    , MobilePhoneNumber = "1234567890"
                    , EmergencyContactName = "Random"
                    , EmergencyContactPhone = "9119119119"
                    , Role = 0
                    , Status = 11
                    , EmploymentStartDate = DateTime.Now
                    , EmploymentTerminationDate = DateTime.Now };

            // Try to validate the object
            var context = new ValidationContext(instructor, null, null);
            var results =  new List<ValidationResult>();
            var isModelsStateValid = Validator.TryValidateObject(instructor, context, results, true);

            Assert.False(isModelsStateValid);
        }

        [Fact]
        public void IsInstructorWithoutEmploymentStartDateNotValid()
        {
            // This instructor is missing an employment start date
            var instructor = new Instructor { FirstName = "test"
                    , LastName = "This"
                    , MiddleName = "Isa"
                    , Email = "notarealaddress@notarealdomain.com"
                    , Address = "1234 A Valid Address Rd"
                    , PhoneNumber = "1234567890"
                    , MobilePhoneNumber = "1234567890"
                    , EmergencyContactName = "Random"
                    , EmergencyContactPhone = "9119119119"
                    , Role = 0
                    , Status = 0
                    , EmploymentTerminationDate = DateTime.Now };

            // Try to validate the object
            var context = new ValidationContext(instructor, null, null);
            var results =  new List<ValidationResult>();
            var isModelsStateValid = Validator.TryValidateObject(instructor, context, results, true);

            Assert.False(isModelsStateValid);
        }

        [Fact]
        public void IsInstructorWithLargeFirstNameValid()
        {
            // This instructor is missing a phone number
            var instructor = new Instructor { FirstName = "testtesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttest"
                    , LastName = "This"
                    , MiddleName = "Isa"
                    , Email = "notarealaddress@notarealdomain.com"
                    , Address = "1234 A Valid Address Rd"
                    , PhoneNumber = "1234567890"
                    , MobilePhoneNumber = "1234567890"
                    , EmergencyContactName = "Random"
                    , EmergencyContactPhone = "9119119119"
                    , Role = 0
                    , Status = 0
                    , EmploymentStartDate = DateTime.Now
                    , EmploymentTerminationDate = DateTime.Now };

            // Try to validate the object
            var context = new ValidationContext(instructor, null, null);
            var results =  new List<ValidationResult>();
            var isModelsStateValid = Validator.TryValidateObject(instructor, context, results, true);

            Assert.False(isModelsStateValid);
        }

        #endregion

        #region Helper methods
        /// <summary>
        /// Used to create a database in memory for use by the testing framework.
        /// The created database does not have a SQL connection but rather is simply in memory.
        /// </summary>
        /// <returns> The in memory Db context </returns>
        private InstructorDbContext CreateAndSeedContext()
        {
            // Create a fresh service provider, and therefore a fresh 
            // InMemory database instance.
            var serviceProvider = new ServiceCollection()
               .AddEntityFrameworkInMemoryDatabase()
               .BuildServiceProvider();

            var builder = new DbContextOptionsBuilder<InstructorDbContext>();
            builder.UseInMemoryDatabase()
                   .UseInternalServiceProvider(serviceProvider);

         //   var optionsBuilder = new DbContextOptionsBuilder<InstructorDbContext>();
         //   optionsBuilder.UseInMemoryDatabase();

            var inMemoryContext = new InstructorDbContext(builder.Options);
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
                new Instructor { FirstName = "Thumb", LastName = "Jerome", MiddleName = "Jochem", Address = "1234 I Declare Rd.", Email = "notarealemail@notarealdomain.com", PhoneNumber = "1234567890", MobilePhoneNumber = "1234567890", EmergencyContactName = "Random", EmergencyContactPhone = "9119119119", Role = 0, Status = 1, EmploymentStartDate = DateTime.Now, EmploymentTerminationDate = DateTime.Now },
                    new Instructor { FirstName = "Denton", LastName = "Traylor", MiddleName = "Waldo", Address = "54321 Boom Dr.", Email = "notarealemail@notarealdomain.com", PhoneNumber = "1234567890", MobilePhoneNumber = "1234567890", EmergencyContactName = "Eynever Panic", EmergencyContactPhone = "9119119119", Role = 1, Status = 0, EmploymentStartDate = DateTime.Now, EmploymentTerminationDate = DateTime.Now },
                    new Instructor { FirstName = "Roselyn", LastName = "Jekyll", MiddleName = "Nikolas", Address = "128 Igotlazymakingupaddressesok Rd.", Email = "notarealemail@notarealdomain.com", PhoneNumber = "1234567890", MobilePhoneNumber = "1234567890", EmergencyContactName = "Fake Data", EmergencyContactPhone = "9119119119", Role = 0, Status = 0, EmploymentStartDate = DateTime.Now, EmploymentTerminationDate = DateTime.Now },
                    new Instructor { FirstName = "Michael", LastName = "Geyer", MiddleName = "Alexander", Address = "25250 Not My Real Address ln.", Email = "notarealemail@notarealdomain.com", PhoneNumber = "1234567890", MobilePhoneNumber = "1234567890", EmergencyContactName = "Faux Info", EmergencyContactPhone = "9119119119", Role = 1, Status = 0, EmploymentStartDate = DateTime.Now, EmploymentTerminationDate = DateTime.Now },
                    new Instructor { FirstName = "David", LastName = "Patrick", MiddleName = "", Address = "5481 Another Fake Address Dr.", Email = "notarealemail@notarealdomain.com", PhoneNumber = "1234567890", MobilePhoneNumber = "1234567890", EmergencyContactName = "Notaperson Thatexists", EmergencyContactPhone = "9119119119", Role = 0, Status = 1, EmploymentStartDate = DateTime.Now, EmploymentTerminationDate = DateTime.Now },
                    new Instructor { FirstName = "Richard", LastName = "Tran", MiddleName = "", Address = "56445 Random Words", Email = "notarealemail@notarealdomain.com", PhoneNumber = "1234567890", MobilePhoneNumber = "1234567890", EmergencyContactName = "Somuchjunk Inthisform", EmergencyContactPhone = "9119119119", Role = 0, Status = 1, EmploymentStartDate = DateTime.Now, EmploymentTerminationDate = DateTime.Now },
                    new Instructor { FirstName = "Brad", LastName = "Lugo", MiddleName = "", Address = "898 Typing Words Ave.", Email = "notarealemail@notarealdomain.com", PhoneNumber = "1234567890", MobilePhoneNumber = "1234567890", EmergencyContactName = "Makeupnames Icannot", EmergencyContactPhone = "9119119119", Role = 1, Status = 0, EmploymentStartDate = DateTime.Now, EmploymentTerminationDate = DateTime.Now },
                    new Instructor { FirstName = "Samson", LastName = "Farade", MiddleName = "", Address = "5468 More Words ln.", Email = "notarealemail@notarealdomain.com", PhoneNumber = "1234567890", MobilePhoneNumber = "1234567890", EmergencyContactName = "Helpmeplease Imtiredofthis", EmergencyContactPhone = "9119119119", Role = 0, Status = 1, EmploymentStartDate = DateTime.Now, EmploymentTerminationDate = DateTime.Now }
        };
                return newInstructors;
        }
        #endregion

    }
}

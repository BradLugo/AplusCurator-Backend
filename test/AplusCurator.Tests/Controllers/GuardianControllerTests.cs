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
                new Guardian {FirstName = "Samug", LastName = "Samson", Address = "123 Misty Mountain", Email = "smaug@gmail.com", PhoneNumber = "9999999999", MobileNumber = "8888888888", Role = 1, ContactName = "Gandalf", ContactNumber = "7777777777", Status = 1, Description = "A dragon", SystemInfo = "Random"},
                new Guardian {FirstName = "Lockheed", LastName = "Lockheart", Address = "1234 Misty Mountain", Email = "lockheart@gmail.com", PhoneNumber = "1111111111", MobileNumber = "4444444444", Role = 0, ContactName = "Gandalf", ContactNumber = "7777777777", Status = 1, Description = "A dragon", SystemInfo = "Random"},
                new Guardian {FirstName = "Porunga", LastName = "Patrick", Address = "1 Cloudy Mountain", Email = "PoD8@gmail.com", PhoneNumber = "1234567890", MobileNumber = "0987654321", Role = 2, ContactName = "Gandalf", ContactNumber = "7777777777", Status = 4, Description = "A dragon", SystemInfo = "Random"},
                new Guardian {FirstName = "Balrog", LastName = "Demon", Address = "Hell", Email = "balrog@gmail.com", PhoneNumber = "3434343434", MobileNumber = "1212121212", Role = 5, ContactName = "Gandalf", ContactNumber = "7777777777", Status = 2, Description = "A dragon", SystemInfo = "Random"}

        };
            return newGuardians;
        }
        #endregion
    }
}


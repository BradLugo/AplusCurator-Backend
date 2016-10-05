using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace AplusCurator.Models
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public static class InstructorDbExtensions
    {
        public static void EnsureSeedData(this InstructorDbContext context)
        {
            if (!context.Instructors.Any())
            {
                context.Instructors.AddRange(
                    new Instructor { FirstName = "Thumb", LastName = "Jerome", MiddleName = "Jochem", Address = "1234 I Declare Rd.", Email = "notarealemail@notarealdomain.com", PhoneNumber = "1234567890", MobilePhoneNumber = "1234567890", EmergencyContactName = "The po-po", EmergencyContactPhone = "1800-call-911", Role = 0, Status = 0, EmploymentStartDate = DateTime.Now, EmploymentTerminationDate = DateTime.Now },
                    new Instructor { FirstName = "Denton", LastName = "Traylor", MiddleName = "Waldo", Address = "54321 Boom Dr.", Email = "notarealemail@notarealdomain.com", PhoneNumber = "1234567890", MobilePhoneNumber = "1234567890", EmergencyContactName = "Eynever Panic", EmergencyContactPhone = "1800-call-911", Role = 0, Status = 0, EmploymentStartDate = DateTime.Now, EmploymentTerminationDate = DateTime.Now },
                    new Instructor { FirstName = "Roselyn", LastName = "Jekyll", MiddleName = "Nikolas", Address = "128 Igotlazymakingupaddressesok Rd.", Email = "notarealemail@notarealdomain.com", PhoneNumber = "1234567890", MobilePhoneNumber = "1234567890", EmergencyContactName = "Fake Data", EmergencyContactPhone = "1800-call-911", Role = 0, Status = 0, EmploymentStartDate = DateTime.Now, EmploymentTerminationDate = DateTime.Now },
                    new Instructor { FirstName = "Michael", LastName = "Geyer", MiddleName = "Alexander", Address = "25250 Not My Real Address ln.", Email = "notarealemail@notarealdomain.com", PhoneNumber = "1234567890", MobilePhoneNumber = "1234567890", EmergencyContactName = "Faux Info", EmergencyContactPhone = "1800-call-911", Role = 0, Status = 0, EmploymentStartDate = DateTime.Now, EmploymentTerminationDate = DateTime.Now },
                    new Instructor { FirstName = "David", LastName = "Patrick", MiddleName = "", Address = "5481 Another Fake Address Dr.", Email = "notarealemail@notarealdomain.com", PhoneNumber = "1234567890", MobilePhoneNumber = "1234567890", EmergencyContactName = "Notaperson Thatexists", EmergencyContactPhone = "1800-call-911", Role = 0, Status = 0, EmploymentStartDate = DateTime.Now, EmploymentTerminationDate = DateTime.Now },
                    new Instructor { FirstName = "Richard", LastName = "Tran", MiddleName = "", Address = "56445 Random Words", Email = "notarealemail@notarealdomain.com", PhoneNumber = "1234567890", MobilePhoneNumber = "1234567890", EmergencyContactName = "Somuchjunk Inthisform", EmergencyContactPhone = "1800-call-911", Role = 0, Status = 0, EmploymentStartDate = DateTime.Now, EmploymentTerminationDate = DateTime.Now },
                    new Instructor { FirstName = "Brad", LastName = "Lugo", MiddleName = "", Address = "898 Typing Words Ave.", Email = "notarealemail@notarealdomain.com", PhoneNumber = "1234567890", MobilePhoneNumber = "1234567890", EmergencyContactName = "Makeupnames Icannot", EmergencyContactPhone = "1800-call-911", Role = 0, Status = 0, EmploymentStartDate = DateTime.Now, EmploymentTerminationDate = DateTime.Now },
                    new Instructor { FirstName = "Samson", LastName = "Farade", MiddleName = "", Address = "5468 More Words ln.", Email = "notarealemail@notarealdomain.com", PhoneNumber = "1234567890", MobilePhoneNumber = "1234567890", EmergencyContactName = "Helpmeplease Imtiredofthis", EmergencyContactPhone = "1800-call-911", Role = 0, Status = 0, EmploymentStartDate = DateTime.Now, EmploymentTerminationDate = DateTime.Now } );
                context.SaveChanges();
            }
        }
    }
}

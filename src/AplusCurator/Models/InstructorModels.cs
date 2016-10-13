using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace AplusCurator.Models
{
    public class Instructor
    {
        [Key]
        public int InstructorId { get; set; }

        [StringLength(127), Required]
        public string FirstName { get; set; }

        [StringLength(127), Required]
        public string LastName { get; set; }

        [StringLength(127)]
        public string MiddleName { get; set; }

        [StringLength(255), Required]
        public string Address { get; set; }

        [StringLength(255), Required]
        public string Email { get; set; }

        [StringLength(15), Required]
        public string PhoneNumber { get; set; }

        [StringLength(15)]
        public string MobilePhoneNumber { get; set; }

        [StringLength(127)]
        public string EmergencyContactName { get; set; }

        [StringLength(15)]
        public string EmergencyContactPhone { get; set; }

        [Required]
        public int Role { get; set; }

        [Required]
        public int Status { get; set; }

        [Required]
        public DateTime EmploymentStartDate { get; set; }

        public DateTime EmploymentTerminationDate { get; set; }

        // View model needs attachment type, SQL DB will have a table for attachements with secondary key on Id

    }
    // May not be usefull in our case
    public class InstructorViewModel
    {

    }
}

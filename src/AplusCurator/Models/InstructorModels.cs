using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace AplusCurator.Models
{
    public class Instructor
    {
        [Key]
        public int? InstructorId { get; set; }

        [StringLength(127), Required]
        [RegularExpression(@"^[A-Za-z]+")]
        public string FirstName { get; set; }

        [StringLength(127), Required]
        [RegularExpression(@"^[A-Za-z]+")]
        public string LastName { get; set; }

        [StringLength(127)]
        [RegularExpression(@"^[A-Za-z]+")]
        public string MiddleName { get; set; }

        [StringLength(255), Required]
        [RegularExpression(@"[A-Za-z0-9\s]+")]
        public string Address { get; set; }

        [StringLength(255), Required]
        [EmailAddress]
        public string Email { get; set; }

        [StringLength(15), Required]
        [RegularExpression(@"^[0-9]{10}")]
        public string PhoneNumber { get; set; }

        [StringLength(15)]
        [RegularExpression(@"^[0-9]{10}")]
        public string MobilePhoneNumber { get; set; }

        [StringLength(127)]
        [RegularExpression(@"^[A-Za-z\s]+")]
        public string EmergencyContactName { get; set; }

        [StringLength(15)]
        [RegularExpression(@"^[0-9]{10}")]
        public string EmergencyContactPhone { get; set; }

        [Required]
        [Range(0, 3)]
        public int? Role { get; set; }

        [Required]
        [Range(0, 2)]
        public int? Status { get; set; }

        [Required]
        public DateTime? EmploymentStartDate { get; set; }

        public DateTime? EmploymentTerminationDate { get; set; }

        // View model needs attachment type, SQL DB will have a table for attachements with secondary key on Id

    }
    // May not be usefull in our case
    public class InstructorViewModel
    {

    }
}

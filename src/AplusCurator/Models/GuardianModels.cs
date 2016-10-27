using System.ComponentModel.DataAnnotations;

namespace AplusCurator.Models
{
    public class Guardian
    {
        [Key]
        public int GuardianId { get; set; }

        [StringLength(127), Required]
        [RegularExpression(@"^[A-Za-z]+")]
        public string FirstName { get; set; }

        [StringLength(127), Required]
        [RegularExpression(@"^[A-Za-z]+")]
        public string LastName { get; set; }

        [StringLength(127), Required]
        [RegularExpression(@"[A-Za-z0-9\s]+")]
        public string Address { get; set; }

        [StringLength(127), Required]
        [EmailAddress]
        public string Email { get; set; }

        [StringLength(127), Required]
        [RegularExpression(@"^[0-9]{10}")]
        public string PhoneNumber { get; set; }

        [StringLength(127)]
        [RegularExpression(@"^[0-9]{10}")]
        public string MobileNumber { get; set; }

        [Required]
        [Range(0, 3)]
        public int? Role { get; set; }

        [StringLength(127), Required]
        [RegularExpression(@"^[A-Za-z\s]+")]
        public string ContactName { get; set; }

        [StringLength(127), Required]
        [RegularExpression(@"^[0-9]{10}")]
        public string ContactNumber { get; set; }

        [Range(0, 2)]
        public int? Status { get; set; }

        [StringLength(99999)]
        public string Description { get; set; }

        [StringLength(99999)]
        public string SystemInfo { get; set; }
    }
}

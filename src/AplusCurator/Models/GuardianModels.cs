using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AplusCurator.Models
{
    public class Guardian
    {
        [Key]
        public int GuardianId { get; set; }

        [Column(TypeName = "Date")]
        public DateTime? MostRecentPayement { get; set; }

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

        [Range(0, 3), Required]
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

    public class StudentRelation
    {
        [Key]
        public int relationId { get; set; }

        [ForeignKey("studentId")]
        public int studentId { get; set; }

        [ForeignKey("guardianId")]
        public int guardianId { get; set; }
    }

    public class Invoice
    {

        [Key]
        public int InvoiceId { get; set; }

        [Required]
        public double DueAmount { get; set; }

        [Required]
        public double PaidAmount { get; set; }

        [ForeignKey("GuardianId")]
        public int GuardianId { get; set; }

        [ForeignKey("StudentId")]
        public int StudentId { get; set; }

        [Column(TypeName = "Date"), Required]
        public DateTime DueDate { get; set; }

        [Column(TypeName = "Date")]
        public DateTime? PaidDate { get; set; }
    }
}

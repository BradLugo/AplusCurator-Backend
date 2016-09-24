using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace AplusCurator.Models
{
    public class Guardian
    {
        [Key]
        public int GuardianId { get; set; }

        [StringLength(127), Required]
        public string FirstName { get; set; }

        [StringLength(127), Required]
        public string LastName { get; set; }

        [StringLength(127), Required]
        public string Address { get; set; }

        [StringLength(127), Required]
        public string Email { get; set; }

        [StringLength(127), Required]
        public string PhoneNumber { get; set; }

        [StringLength(127)]
        public string MobileNumber { get; set; }

        [Required]
        public int Role { get; set; }

        [StringLength(127), Required]
        public string ContactName { get; set; }

        [StringLength(127), Required]
        public string ContactNumber { get; set; }

        public int Status { get; set; }

        [StringLength(99999)]
        public string Description { get; set; }

        [StringLength(99999)]
        public string SystemInfo { get; set; }
    }
}

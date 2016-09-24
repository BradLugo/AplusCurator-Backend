using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AplusCurator.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }

        [StringLength(127), Required]
        public string FirstName { get; set; }

        [StringLength(127), Required]
        public string LastName { get; set; }

        [Column(TypeName = "Date"), Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public int Gender { get; set; }

        [Required]
        public int CurrentGrade { get; set; }

        public int Status { get; set; }

        [StringLength(99999)]
        public string Description { get; set; }

        [StringLength(99999)]
        public string SystemInfo { get; set; }

    }
}

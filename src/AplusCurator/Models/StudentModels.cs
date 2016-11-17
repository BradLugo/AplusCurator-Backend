using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AplusCurator.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }

        [StringLength(127), Required]
        [RegularExpression(@"^[A-Za-z]+")]
        public string FirstName { get; set; }

        [StringLength(127), Required]
        [RegularExpression(@"^[A-Za-z]+")]
        public string LastName { get; set; }

        [Column(TypeName = "Date"), Required]
        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }

        [Required]
        [Range(0, 1)]
        public int? Gender { get; set; }

        [Required]
        [Range(1, 12)]
        public int? CurrentGrade { get; set; }

        [Range(0, 5)]
        public int? Status { get; set; }

        [StringLength(99999)]
        public string Description { get; set; }

        [StringLength(99999)]
        public string SystemInfo { get; set; }

    }

    public class StudentAttendance
    {
        [Key]
        public int StudentAttendanceId { get; set; }

        [ForeignKey("StudentId")]
        public int? StudentId { get; set; }

        [Column(TypeName = "Date"), Required]
        public DateTime AttendanceDate { get; set; }

        [Column(TypeName = "Time"), Required]
        public TimeSpan EntryTime { get; set; }

        [Column(TypeName = "Time")]
        public TimeSpan? Duration { get; set; }

    }
}

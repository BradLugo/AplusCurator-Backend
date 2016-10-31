using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace AplusCurator.Models
{
    public class Attendance
    {
        [Key]
        public int AttendanceId { get; set; }

        [Column(TypeName = "Date"), Required]
        public DateTime AttendanceTime { get; set; }

        [Column(TypeName = "Time"), Required]
        public DateTime EntryTime { get; set; }

        [Column(TypeName = "Time")]
        public DateTime ExitTime { get; set; }

    }
}

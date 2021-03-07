using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StudentManagement.Models
{
    public class Attendance
    {
        public int AttendanceId { get; set; }
        public int SessionDetailId { get; set; }
        public virtual SessionDetail SessionDetail { get; set; }

        [Required]
        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        public int Attend { get; set; }

        [MaxLength]
        [Column(TypeName = "TEXT")]
        public string Note { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentManagement.Models
{
    public class Subject
    {
        public int SubjectId { get; set; }

        [StringLength(255)]
        [Required]
        public string SubjectName { get; set; }

        [StringLength(255)]
        [Required]
        public string SubjectCode { get; set; }

        public string Description { get; set; }

        public int NumberLession { get; set; }

        public SubjectStatus Status { get; set; }

        public enum SubjectStatus
        {
            ACTIVE, DEACTIVE, DELETED
        }

        public virtual ICollection<Session> Sessions { get; set; }
    }
}
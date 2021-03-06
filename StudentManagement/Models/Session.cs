using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StudentManagement.Models
{
    public class Session
    {
        public int SessionId { get; set; }
        public int RoomId { get; set; }
        public virtual Room Room { get; set; }

        public int SubjectId { get; set; }
        public virtual Subject Subject { get; set; }

        public int ClazzId { get; set; }
        public virtual Clazz Clazz { get; set; }

        [DisplayName("Teacher")]
        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        public int NumBerSession { get; set; }

        [Required]
        [Column(TypeName = "TEXT")]
        public string ListStudent { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm:ss}")]
        [DisplayName("Start Time")]
        public TimeSpan StartTime { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm:ss}")]
        [DisplayName("Finish Time")]
        public TimeSpan FinishTime { get; set; }

        [DataType(DataType.Date)]
        [Column(TypeName = "date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DisplayName("Begin Time")]
        public DateTime BeginTime { get; set; }

        [DataType(DataType.Date)]
        [Column(TypeName = "date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DisplayName("End Time")]
        public DateTime EndTime { get; set; }

        public SessionStatus Status { get; set; }

        public enum SessionStatus
        {
            ACTIVE, DEACTIVE, DELETED
        }

        public virtual ICollection<SessionDetail> SessionDetails { get; set; }

    }
}
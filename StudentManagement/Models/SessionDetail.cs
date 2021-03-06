using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StudentManagement.Models
{
    public class SessionDetail
    {
        public int SessionDetailId { get; set; }

        public int SessionId { get; set; }
        public virtual Session Session { get; set; }

        public string SessionDetailName { get; set; }

        public string TeacherId { get; set; }

        public int RoomId { get; set; }

        [Index(IsUnique = true)]
        [StringLength(255)]
        [Required]
        public string SessionDetailCode { get; set; }

        public virtual ICollection<Attendance> Attendances { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DisplayName("Date Start")]
        [Column(TypeName = "date")]
        public DateTime DateStart { get; set; }

        public SessionDetailStatus Status { get; set; }

        public enum SessionDetailStatus
        {
            [Display(Name = "Done")]
            DONE,
            [Display(Name = "Up Comming")]
            UPCOMING,
            [Display(Name = "On Going")]
            ONGOING
        }
    }
}
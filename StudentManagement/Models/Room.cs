using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentManagement.Models
{
    public class Room
    {
        public int RoomId { get; set; }

        [StringLength(255)]
        [Required]
        public string RoomName { get; set; }

        [StringLength(255)]
        [Required]
        public string RoomCode { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        public RoomStatus Status { get; set; }

        public enum RoomStatus
        {
            ACTIVE, DEACTIVE, DELETED
        }

        public virtual ICollection<Session> Sessions { get; set; }
    }
}
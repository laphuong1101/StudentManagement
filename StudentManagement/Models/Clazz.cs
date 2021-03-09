using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StudentManagement.Models
{
    public class Clazz
    {
        public int ClazzId { get; set; }

        [StringLength(255)]
        [Required]
        [Display(Name = "Tên lớp")]
        public string ClazzName { get; set; }

        [StringLength(255)]
        [Required]
        [Display(Name = "Mã lớp")]
        public string ClazzCode { get; set; }

        [Required]
        [Column(TypeName = "TEXT")]
        [Display(Name = "Danh sách sinh viên")]
        public string ListStudentId { get; set; }

        [StringLength(255)]
        [Display(Name = "Mô tả")]
        public string Description { get; set; }
        [Display(Name = "Trạng thái")]
        public ClazzStatus Status { get; set; }

        public enum ClazzStatus
        {
            [Display(Name = "Hoạt động")]
            ACTIVE,
            [Display(Name = "Không hoạt động")]
            DEACTIVE,
            [Display(Name = "Đã xóa")]
            DELETED
        }

        public virtual ICollection<Session> Sessions { get; set; }
    }
}
using SLK.TryEdu.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLK.TryEdu.ModuleLearningCore;

[Table("LEARNING_ENROLLMENT")]
public class EntityEnrollment : EntityBase
{
    [Display(Name = "User ID")]
    [Required]
    public int UserId { get; set; }

    [Display(Name = "Course ID")]
    [Required]
    public int CourseId { get; set; }

    [Display(Name = "Ngày đăng ký")]
    public DateTime EnrolledAt { get; set; } = DateTime.UtcNow;

    [Display(Name = "Tiến độ (%)")]
    [Column(TypeName = "decimal(5,2)")]
    public decimal Progress { get; set; } = 0;

    [Display(Name = "Trạng thái")]
    [MaxLength(20)]
    public string Status { get; set; } = "Active"; 

    [Display(Name = "Ngày hoàn thành")]
    public DateTime? CompletedAt { get; set; }

    [Display(Name = "Lần truy cập cuối")]
    public DateTime? LastAccessedAt { get; set; }
    public Guid UserGuid { get; set; }
    public Guid CourseGuid { get; set; }
}

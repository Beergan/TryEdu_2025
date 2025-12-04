using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SLK.TryEdu.Abstract;

namespace SLK.TryEdu.ModuleContentCore;   

[Table("COURSE")]
public class EntityCourse : EntityBase
{


    [Display(Name = "Tiêu đề")]
    [Required(ErrorMessage = "Tiêu đề không được để trống!")]
    [MaxLength(500)]
    public string Title { get; set; }

    [Display(Name = "Slug")]
    [MaxLength(500)]
    public string Slug { get; set; }

    [Display(Name = "Mô tả ngắn")]
    [MaxLength(1000)]
    public string Description { get; set; }

    [Display(Name = "Mô tả chi tiết")]
    [Column(TypeName = "text")]
    public string FullDescription { get; set; }

    [Display(Name = "Ảnh thumbnail")]
    [MaxLength(500)]
    public string ThumbnailUrl { get; set; }

    [Display(Name = "Level")]
    [MaxLength(50)]
    public string Level { get; set; } // A1, A2, B1, B2, C1, C2

    [Display(Name = "Category")]
    [MaxLength(100)]
    public string Category { get; set; } // IELTS, TOEFL, General English

    [Display(Name = "Loại khóa học")]
    [MaxLength(20)]
    public string CourseType { get; set; } = "Free"; // Free, Premium

    [Display(Name = "Giá (coin)")]
    public int? Price { get; set; }

    [Display(Name = "Thời lượng (phút)")]
    public int? Duration { get; set; }

    [Display(Name = "Số học viên")]
    public int StudentCount { get; set; } = 0;

    [Display(Name = "Rating trung bình")]
    [Column(TypeName = "decimal(3,2)")]
    public decimal? AverageRating { get; set; }

    [Display(Name = "Trạng thái")]
    [MaxLength(20)]
    public string Status { get; set; } = "Draft"; // Draft, Published, Archived

    [Display(Name = "Ngày xuất bản")]
    public DateTime? PublishedAt { get; set; }

    [Display(Name = "Tags")]
    [MaxLength(500)]
    public string Tags { get; set; } // JSON array or comma-separated

    [Display(Name = "MongoDB Course ID")]
    [MaxLength(50)]
    public string MongoDbCourseId { get; set; } // Reference to MongoDB document

}

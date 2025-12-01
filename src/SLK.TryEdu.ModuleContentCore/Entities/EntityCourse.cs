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

    [Required]
    [MaxLength(255)]
    public string Title { get; set; } = string.Empty;

    [MaxLength(500)]
    public string Slug { get; set; } = string.Empty; 

    [MaxLength(1000)]
    public string Description { get; set; } = string.Empty;

    [MaxLength(500)]
    public string ThumbnailUrl { get; set; } = string.Empty;

    [Required]
    [MaxLength(20)]
    public string CourseType { get; set; } = "Free"; 

    [Required]
    [Column(TypeName = "decimal(12,2)")]
    public decimal PriceCoins { get; set; } = 0; 

    [Required]
    [MaxLength(20)]
    public string Level { get; set; } = "Beginner"; 
    [MaxLength(100)]
    public string Category { get; set; } = string.Empty;

    [Required]
    public int CreatedByUserId { get; set; }

    [Required]
    [MaxLength(20)]
    public string Status { get; set; } = "Draft"; 

    public DateTime? PublishedAt { get; set; }

    [Column(TypeName = "jsonb")]
    public string CourseData { get; set; } 

    public Guid EmployeeCre { get; set; }

  

}

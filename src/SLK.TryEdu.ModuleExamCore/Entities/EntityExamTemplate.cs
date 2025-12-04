using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SLK.TryEdu.Abstract;

namespace SLK.TryEdu.ModuleExamCore;      

[Table("EXAM_TEMPLATE")]
public class EntityExamTemplate : EntityBase
{

    [Required, MaxLength(255)]
    public string Title { get; set; } = string.Empty;

    [MaxLength(500)]
    public string Slug { get; set; } = string.Empty;

    [MaxLength(1000)]
    public string Description { get; set; } = string.Empty;

    [Required]
    [MaxLength(20)]
    public string Level { get; set; } = "B1";

    [Required]
    [MaxLength(50)]
    public string ExamType { get; set; } = "IELTS";

    [Required]
    public int DurationMinutes { get; set; } = 120;

    [Required]
    [Column(TypeName = "decimal(5,2)")]
    public decimal PassingScore { get; set; } = 60m;

    [Required]
    public int CreatedByUserId { get; set; }

    [Required]
    [MaxLength(20)]
    public string Status { get; set; } = "Draft";

    [Column(TypeName = "jsonb")]
    public string Metadata { get; set; }


}

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SLK.TryEdu.Abstract;

namespace SLK.TryEdu.ModuleExamCore;      

[Table("EXAM_TEMPLATE_SECTION")]
public class EntityExamTemplateSection : EntityBase 
{
    [Required]
    public int ExamTemplateId { get; set; }

    [Required, MaxLength(100)]
    public string SectionName { get; set; } = string.Empty;

    [Required]
    public int Order { get; set; }

    [Required]
    public int QuestionCount { get; set; }

    [Required]
    [Column(TypeName = "decimal(5,2)")]
    public decimal WeightPercentage { get; set; } = 25m;

    [Column(TypeName = "jsonb")]
    public string  Config { get; set; }

    [ForeignKey(nameof(ExamTemplateId))]
    public virtual EntityExamTemplate ExamTemplate { get; set; } = null!;

}

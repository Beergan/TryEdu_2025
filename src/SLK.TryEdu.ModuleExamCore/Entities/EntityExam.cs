using SLK.TryEdu.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLK.TryEdu.ModuleExamCore;

[Table("EXAM")]
public class EntityExam : EntityBase
{
    [Required]
    public int ExamTemplateId { get; set; } 

    [Required, MaxLength(255)]
    public string Title { get; set; } = string.Empty;

    [MaxLength(500)]
    public string Slug { get; set; } = string.Empty;

    [Column(TypeName = "decimal(12,2)")]
    public decimal PriceCoins { get; set; } = 200;

    public int DurationMinutes { get; set; }

    [Column(TypeName = "jsonb")]
    public string SnapshotData { get; set; } = string.Empty; 

    [Required]
    [MaxLength(20)]
    public string Status { get; set; } = "Draft";

    public DateTime? PublishedAt { get; set; }

    [ForeignKey(nameof(ExamTemplateId))]
    public virtual EntityExamTemplate Template { get; set; } = null!;

}

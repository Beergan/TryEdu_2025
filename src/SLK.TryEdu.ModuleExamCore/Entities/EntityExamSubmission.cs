using SLK.TryEdu.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLK.TryEdu.ModuleExamCore;

[Table("EXAM_SUBMISSION")]
public class EntityExamSubmission : EntityBase
{
    [Required]
    public int ExamId { get; set; } 
    [Required]
    public int UserId { get; set; }

    [Required, MaxLength(20)]
    public string Status { get; set; } = "InProgress"; 

    public DateTime? StartedAt { get; set; }
    public DateTime? SubmittedAt { get; set; }

    [Column(TypeName = "decimal(5,2)")]
    public decimal? Score { get; set; }

    [Column(TypeName = "decimal(5,2)")]
    public decimal? Percentage { get; set; }

    [Column(TypeName = "jsonb")]
    public string Answers { get; set; } 

    [Column(TypeName = "jsonb")]
    public string AIGradingResult { get; set; } 

    [ForeignKey(nameof(ExamId))]
    public virtual EntityExam Exam { get; set; } = null!;
    public Guid UserGuid { get; set; }

}

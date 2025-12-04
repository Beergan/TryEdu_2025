using SLK.TryEdu.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLK.TryEdu.ModuleExamCore;

[Table("EXAM_ATTEMPT_QUESTION")]
public class EntityExamAttemptQuestion : EntityBase
{
    [Required]
    public int ExamSubmissionId { get; set; } 

    [Required]
    public int ExamQuestionId { get; set; }

    public int? QuestionOptionId { get; set; } 

    [Column(TypeName = "jsonb")]
    public string? UserAnswer { get; set; } 

    [Column(TypeName = "decimal(5,2)")]
    public decimal? Score { get; set; }

    public bool IsCorrect { get; set; }

    [ForeignKey(nameof(ExamSubmissionId))]
    public virtual EntityExamSubmission Submission { get; set; } = null!;

    [ForeignKey(nameof(ExamQuestionId))]
    public virtual EntityExamQuestion Question { get; set; } = null!;

}

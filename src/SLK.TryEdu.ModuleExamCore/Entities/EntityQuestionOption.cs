using SLK.TryEdu.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLK.TryEdu.ModuleExamCore;

[Table("EXAM_QUESTION_OPTION")]
public class EntityQuestionOption : EntityBase
{
    [Required]
    public int ExamQuestionId { get; set; }

    [Required, MaxLength(200)]
    public string Label { get; set; } = string.Empty; 
    [Required, Column(TypeName = "text")]
    public string Content { get; set; } = string.Empty;

    [Required]
    public bool IsCorrect { get; set; } = false;

    public int DisplayOrder { get; set; }

    [ForeignKey(nameof(ExamQuestionId))]
    public virtual EntityExamQuestion Question { get; set; } = null!;

}

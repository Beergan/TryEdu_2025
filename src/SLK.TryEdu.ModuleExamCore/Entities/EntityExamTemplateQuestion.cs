using SLK.TryEdu.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLK.TryEdu.ModuleExamCore;

[Table("EXAM_TEMPLATE_QUESTION")]
public class EntityExamTemplateQuestion :EntityBase
{
    [Required]
    public int ExamTemplateSectionId { get; set; }

    [Required]
    public int ExamQuestionId { get; set; }

    [Required]
    public int Order { get; set; }

    [Column(TypeName = "decimal(5,2)")]
    public decimal? OverridePoint { get; set; }

    [Column(TypeName = "jsonb")]
    public string Constraints { get; set; } 

    [ForeignKey(nameof(ExamTemplateSectionId))]
    public virtual EntityExamTemplateSection Section { get; set; } = null!;

    [ForeignKey(nameof(ExamQuestionId))]
    public virtual EntityExamQuestion Question { get; set; } = null!;

}

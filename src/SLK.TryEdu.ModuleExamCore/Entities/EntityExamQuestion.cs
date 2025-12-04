using SLK.TryEdu.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLK.TryEdu.ModuleExamCore;

[Table("EXAM_QUESTION")]
public class EntityExamQuestion : EntityBase
{
    [Required, MaxLength(50)]
    public string QuestionType { get; set; } = "MultipleChoice"; 

    [Required, MaxLength(500)]
    public string Title { get; set; } = string.Empty;

    [Column(TypeName = "text")]
    public string Prompt { get; set; } 

    [Column(TypeName = "jsonb")]
    public string RichContent { get; set; } 

    [Required]
    [Column(TypeName = "decimal(5,2)")]
    public decimal DefaultPoint { get; set; } = 1m;

    [MaxLength(20)]
    public string Difficulty { get; set; } = "Medium";

    [MaxLength(50)]
    public string Skill { get; set; } = "Reading";

    [MaxLength(100)]
    public string Category { get; set; } = string.Empty;

    [Required]
    public bool IsActive { get; set; } = true;
    public Guid GroupId { get; set; } 

    [Column(TypeName = "jsonb")]
    public string AnswerSchema { get; set; }

}

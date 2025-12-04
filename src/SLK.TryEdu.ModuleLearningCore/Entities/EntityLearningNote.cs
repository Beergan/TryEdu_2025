using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SLK.TryEdu.Abstract;

namespace SLK.TryEdu.ModuleLearningCore;    

[Table("LEARNING_NOTE")]
public class EntityLearningNote : EntityBase
{

    [Required]
    public Guid UserGuid { get; set; }

    [Required]
    public Guid CourseGuid { get; set; }

    public Guid CourseLessonGuid { get; set; } 

    [Required]
    [MaxLength(255)]
    public string Title { get; set; } = string.Empty;

    [Column(TypeName = "text")]
    public string Content { get; set; } = string.Empty; 

    [MaxLength(50)]
    public string Tags { get; set; } 

}

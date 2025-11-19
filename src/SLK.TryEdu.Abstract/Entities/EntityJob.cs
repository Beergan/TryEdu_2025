using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SLK.TryEdu.Abstract;

[Table("SETTING_JOB")]
public class EntityJob : EntityBase
{
    [Display(Name = "Vị trí công việc")]
    [Required(ErrorMessage = "Vị trí công việc không được để trống!")]
    public string JobName { get; set; }
}
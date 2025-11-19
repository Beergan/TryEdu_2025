using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLK.TryEdu.Abstract;

[Table("SETTING_PERMISSION")]
public class EntityPermission : EntityBase
{
    public string GroupName { get; set; }

}
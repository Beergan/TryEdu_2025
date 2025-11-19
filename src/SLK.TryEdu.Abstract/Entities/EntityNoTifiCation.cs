using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLK.TryEdu.Abstract;

[Table("SETTING_NOTIFICATION")]
public class EntityNoTifiCation : EntityBase
{
    public string TitleEn { get; set; }

    public string TitleVi { get; set; }

    public string Href { get; set; }

    public Guid Guid_NoTifiCation { get; set; }

    public Guid Guid_User { get; set; }

    public Guid[] Guid_UserNoTify { get; set; }

    public string Avatar { get; set; }
    
    public bool Check { get; set; } = false;
    
    public string Module { get; set; }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLK.TryEdu.Abstract;

[Table("SYSTEM_AUGDIT_LOG")]
public class AuditLog : EntityBase
{
    public string UserName { get; set; }
    public Guid EmployeeGuid { get; set; }
    public string IpAddress { get; set; }
    public string ActionType { get; set; }
    public string TableName { get; set; }
    public int? RecordId { get; set; }
    public Guid? RecordGuid { get; set; }
    public string ChangeValues { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}

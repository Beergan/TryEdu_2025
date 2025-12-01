using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SLK.TryEdu.Abstract;

namespace SLK.TryEdu.ModulePartnerCore;  

[Table("COMMISSION_TRANSACTION")]
public class EntityCommissionTransaction : EntityBase
{
    [Required]
    public Guid PartnerGuid { get; set; }
    [Required]
    public int PartnerCenterId  { get; set; }
    public Guid UserGuid { get; set; }

    [Required]
    [Column(TypeName = "decimal(12,2)")]
    public decimal TransactionAmount { get; set; }

    [Required]
    [Column(TypeName = "decimal(12,2)")]
    public decimal CommissionAmount { get; set; }

    [Required]
    [Column(TypeName = "decimal(5,2)")]
    public decimal CommissionRate { get; set; } 

    [Required]
    [MaxLength(50)]
    public string TransactionType { get; set; } = string.Empty;
    [Required]
    [MaxLength(20)]
    public string Status { get; set; } = "Pending"; 
    public DateTime? PaidAt { get; set; }

    [ForeignKey(nameof(PartnerCenterId))]
    public virtual EntityPartnerCenter PartnerCenter { get; set; } = null!;

}

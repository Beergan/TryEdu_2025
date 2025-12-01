using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SLK.TryEdu.Abstract;

namespace SLK.TryEdu.ModulePartnerCore;  

[Table("REFERRAL_CODE")]
public class EntityReferralCode : EntityBase
{
    [Required]
    public int  PartnerCenterId { get; set; }

    [Required]
    [MaxLength(50)]
    public string Code { get; set; } = string.Empty;

    [MaxLength(200)]
    public string Description { get; set; } = string.Empty;

    [Required]
    [Column(TypeName = "decimal(5,2)")]
    public decimal DisscountPercent { get; set; } = 0.00m;

    [Required]
    public int MaxUsage { get; set; } = 100;
    [Required]
    public int UsedCount { get; set; } = 0;
    [Required]
    public bool IsActive { get; set; } = true;

    public DateTime? ExpiryDate { get; set; }
    public DateTime? LastUsedAt { get; set; }


    [ForeignKey(nameof(PartnerCenterId))]
    public virtual EntityPartnerCenter PartnerCenter { get; set; } = null!;

}

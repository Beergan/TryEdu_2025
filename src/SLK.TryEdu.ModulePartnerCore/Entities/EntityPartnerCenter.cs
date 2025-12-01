using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SLK.TryEdu.Abstract;

namespace SLK.TryEdu.ModulePartnerCore;  

[Table("PARTNER_CENTER")]
public class EntityPartnerCenter : EntityBase
{

    [Required]
    [MaxLength(100)]
    public string CenterName { get; set; } = string.Empty;

    [Required]
    [MaxLength(20)]
    public string CetnterCode { get; set; } = string.Empty;

    [Required]
    [MaxLength(255)]
    public string Email { get; set; } = string.Empty;

    [Required]
    [MaxLength(20)]
    public string Phone { get; set; } = string.Empty;

    [MaxLength(500)]
    public string Address { get; set; } = string.Empty;

    [MaxLength(100)]
    public string  City { get; set; } = string.Empty;

    [MaxLength(100)]
    public string Country { get; set; } = string.Empty;
    public string LogoUrl { get; set; } = string.Empty;
    public string LicenseUrl { get; set; } = string.Empty;

    [Required]
    [MaxLength(20)]
    public string Status { get; set; } = "Pending";

    [Required]
    [MaxLength(20)]
    public string Tier { get; set; } = "Bronze";

    [Required]
    [Column(TypeName = "decimal(5,2)")]
    public decimal CommissionRate { get; set; } = 0.00m;
    public Guid ApprovedByEmployeeGuid { get; set; }
    public DateTime? ApprovedAt { get; set; }
    [MaxLength(500)]
    public string RejectionReason { get; set; }

    public virtual ICollection<EntityReferralCode> ReferralCodes { get; set; } = new List<EntityReferralCode>();
}

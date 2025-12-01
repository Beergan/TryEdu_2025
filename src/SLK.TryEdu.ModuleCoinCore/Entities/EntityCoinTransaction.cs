using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SLK.TryEdu.Abstract;

namespace SLK.TryEdu.ModuleCoinCore; 

[Table("COIN_TRANSACTION")]
public class EntityCoinTransaction : EntityBase
{
    public Guid UserGuid { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string TransactionType { get; set; } = string.Empty;
    
    [Required]
    [Column(TypeName = "decimal(12,2)")]
    public decimal Amount { get; set; }
    
    [Required]
    [MaxLength(20)]
    public string Status { get; set; } = "PENDING";

    [MaxLength(500)]
    public string Description { get; set; }

    public Guid  ReferralCodeGuid { get; set; }

    public Guid RelatedTransactionGuid { get; set; }

}

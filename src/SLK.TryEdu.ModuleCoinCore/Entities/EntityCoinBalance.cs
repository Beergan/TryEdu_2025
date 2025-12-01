using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SLK.TryEdu.Abstract;

namespace SLK.TryEdu.ModuleCoinCore; 

[Table("COIN_BALANCES")]
public class EntityCoinBalance : EntityBase
{
    public Guid UserGuid { get; set; }
    [Required]
    [Column(TypeName = "decimal(12,2)")]
    public decimal Balance { get; set; } = 0;
    [Required]
    [Column(TypeName = "decimal(12,2)")]
    public decimal TotalEarned { get; set; } = 0;
    [Required]
    [Column(TypeName = "decimal(12,2)")]
    public decimal TotalSpent { get; set; } = 0;
    [MaxLength(20)]
    public string Status { get; set; } = "ACTIVE";

}

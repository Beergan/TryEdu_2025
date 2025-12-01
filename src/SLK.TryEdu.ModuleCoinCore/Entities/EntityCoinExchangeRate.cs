using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SLK.TryEdu.Abstract;

namespace SLK.TryEdu.ModuleCoinCore; 

[Table("COIN_EXCHANGERATE")]
public class EntityCoinExchangeRate : EntityBase
{
    [Required]
    [MaxLength(10)]
    public string Currency { get; set; } = "VNĐ";

    [Required]
    [Column(TypeName = "decimal(12,2)")]
    public decimal Rate { get; set; } // 1 Coin = Rate VND

    [Required]
    public bool IsActive { get; set; } = true;
    public DateTime? EffectiveDate { get; set; } = DateTime.UtcNow;
    public DateTime? ExpiryDate { get; set; }



}

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SLK.TryEdu.Abstract;

public class EntityBase
{
    [Key]
    [Column (Order = 1)]
    public int Id { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column (Order = 2)]
    public Guid Guid { get; set; }

    [Display(Name ="Created date|Ngày tạo")]
    public DateTime DateCreated { get; set; } = DateTime.UtcNow;

    [Display(Name ="Modified date|Ngày chỉnh sửa")]
    public DateTime DateModified { get; set; } = DateTime.UtcNow;

    [Display(Name = "Created User|Người tạo")]
    public string UserCreated { get; set; } = "System";

    [Display(Name ="Modified user|Người chỉnh sửa")]
    public string UserModified { get; set; } = "System";
}
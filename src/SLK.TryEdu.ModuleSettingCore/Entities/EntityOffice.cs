using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SLK.TryEdu.Abstract;

namespace SLK.TryEdu.ModuleSettingCore;

[Table("SETTING_OFFICE")]
public class EntityOffice : EntityBase
{
    [Display(Name = "Logo")]
    public string Avatar { get; set; }

    [Required(ErrorMessage = "Tên chi nhánh không được để trống!")]
    [Display(Name = "Tên chi nhánh")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Địa chỉ không được để trống!")]
    [Display(Name = "Địa chỉ")]
    public string Address { get; set; }

    [Required(ErrorMessage = "Số điện thoại không được để trống!")]
    [Phone(ErrorMessage = "Số điện thoại không hợp lệ!")]
    [Display(Name = "Số điện thoại")]
    public string Phone { get; set; }

    [Required(ErrorMessage = "Email không được để trống!")]
    [EmailAddress(ErrorMessage = "Email không hợp lệ!")]
    [Display(Name = "Email")]
    public string Email { get; set; }

    public bool IsPrimary { get; set; }

    [Display(Name = "Kích hoạt")]
    public bool Active { get; set; }
}
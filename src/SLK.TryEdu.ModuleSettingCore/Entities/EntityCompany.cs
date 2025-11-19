using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SLK.TryEdu.Abstract;

namespace SLK.TryEdu.ModuleSettingCore;

[Table("SEYYING_COMPANY")]
public class EntityCompany : EntityBase
{
    //Logo
    public string CompanyLogo { get; set; }

    //Tên công ty"
    [Required(ErrorMessage = "Tên công ty không được để trống!")]
    public string CompanyName { get; set; }

    //WebSite
    [Required(ErrorMessage = "WebSite không được để trống!")]
    public string CompanyWebSite { get; set; }

    //Điện thoại
    [Required(ErrorMessage = "Điện thoại không được để trống!")]
    public string CompanyPhone { get; set; }

    //Email
    [Required(ErrorMessage = "Email không được để trống!")]
    [EmailAddress(ErrorMessage = "Email không hợp lệ!")]
    public string CompanyEmail { get; set; }

    //Mô tả
    [Required(ErrorMessage = "Mô tả không được để trống!")]
    public string CompanyOverview { get; set; }
   
}
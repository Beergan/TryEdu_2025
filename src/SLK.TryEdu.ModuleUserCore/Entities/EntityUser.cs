using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SLK.TryEdu.Abstract;

namespace SLK.TryEdu.ModuleUserCore;

[Table("USERS")]
public class EntityUser : EntityBase
{

    [Display(Name = "Email đăng nhập")]
    [Required(ErrorMessage = "Email không được để trống!")]
    [EmailAddress(ErrorMessage = "Địa chỉ email không hợp lệ!")]
    public string Email { get; set; }

    [Display(Name = "Mật khẩu")]
    [Required(ErrorMessage = "Mật khẩu không được để trống!")]
    public string PasswordHash { get; set; }

    [Display(Name = "Tên")]
    [Required(ErrorMessage = "Tên không được để trống!")]
    public string FirstName { get; set; }

    [Display(Name = "Họ")]
    [Required(ErrorMessage = "Họ không được để trống!")]
    public string LastName { get; set; }

    [NotMapped]
    [Display(Name = "Họ và tên")]
    public string FullName => $"{LastName} {FirstName}";

    [Display(Name = "Số điện thoại")]
    public string Phone { get; set; }

    [Display(Name = "Địa chỉ")]
    public string Address { get; set; }
    [Display(Name = "Năm sinh")]
    public DateTime HBD { get; set; }

    [Display(Name = "Quốc gia")]
    public string Country { get; set; }

    [Display(Name = "Thành phố")]
    public string City { get; set; }

    [Display(Name = "Phường")]
    public string Ward  { get; set; }
    [Display(Name = "Trạng thái hoạt động")]
    public bool IsActive { get; set; } = true;

    [Display(Name = "Đã xác thực email")]
    public bool IsVerified { get; set; } = false;

    [Display(Name = "Thời gian xác thực email")]
    public DateTime? EmailVerifiedAt { get; set; }
    [Display(Name = "Lần đăng nhập cuối")]
    public DateTime? LastLogin { get; set; }
}

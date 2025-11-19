using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Dynamic;
using SLK.TryEdu.Abstract;

namespace SLK.TryEdu.ModuleEmployeeCore;

[Table("EMPLOYEE")]
public class EntityEmployee : EntityBase
{
    [Display(Name = "Ảnh")]
    public string Avatar { get; set; }

    [Display(Name = "Họ")]
    public string LastName { get; set; }

    [Display(Name = "Tên")]
    public string FirstName { get; set; }

    [NotMapped]
    [Display(Name = "Họ và tên")]
    public string FullName => $"{LastName} {FirstName}";

    [Display(Name = "Email")]
    [Required(ErrorMessage = "Email address can not be empty!|Địa chỉ email không được để trống!")]
    [EmailAddress(ErrorMessage = "Invalid email!|Email không hợp lệ!")]
    public string Email { get; set; }

    [Display(Name = "CCCD")]
    public string CitizenID { get; set; }

    [Display(Name = "Điện thoại")]
    public string Phone { get; set; }

    [Display(Name = "Ngày sinh")]
    public DateTime? DateOfBirth { get; set; }

    [Display(Name = "Giới tính")]
    public string Gender { get; set; }

    // Thông tin chuyên môn

    [Display(Name = "Học vấn")]
    public string Education_Level { get; set; }

    [Display(Name = "Chuyên môn")]
    public string ProfessionalQualification { get; set; }

    [Display(Name = "Nghề nghiệp")]
    [RequiredGuid(ErrorMessage = "Nghề nghiệp không được để trống!")]
    public Guid JobGuid { get; set; }

    [Display(Name = "Nghề nghiệp")]
    public string JobName { get; set; }

    [Display(Name = "Chi nhánh")]
    public string OfficeName { get; set; }

    [RequiredGuid(ErrorMessage = "Chi nhánh không được để trống!")]
    public Guid OfficeGuid { get; set; }
    public bool Active { get; set; }

    public string _EmployeeGender()
    {
        string gender = "";
        gender = BasicCodes.GenderOptions[this.Gender].TextVi;

        return gender;
    }
}
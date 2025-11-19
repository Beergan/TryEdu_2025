using SLK.TryEdu.Abstract;

namespace SLK.TryEdu.ModuleEmployeeCore;

[Feature(Name = "ModuleEmployee", TextEn = "", TextVi = "MODULE NHÂN SỰ")]
public enum PERMISSION
{
    [Function(TextEn = "", TextVi = "Xem danh sách nhân sự")]
    EMPLOYEE_VIEW,

    [Function(TextEn = "", TextVi = "Xem hồ sơ nhân sự")]
    FILE_EMPLOYEE_VIEW,

    [Function(TextEn = "", TextVi = "Tạo mới/ hiệu chỉnh nhân sự")]
    EMPLOYEE_CREATE_UPDATE,

    [Function(TextEn = "", TextVi = "Kích hoạt tài khoản nhân sự")]
    EMPLOYEE_ACTIVE_ACCOUNT,

    [Function(TextEn = "", TextVi = "Tài liệu cá nhân")]
    EMPLOYEE_DOCUMENT,
}
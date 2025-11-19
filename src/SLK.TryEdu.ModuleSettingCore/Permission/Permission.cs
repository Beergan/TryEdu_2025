using System;
using SLK.TryEdu.Abstract;

namespace SLK.TryEdu.ModuleSettingCore;

[Feature(Name = "ModuleSetting", TextEn = "", TextVi = "MODULE THIẾT LẬP")]
public enum PERMISSION
{
    [Function(TextEn = "", TextVi = "Xem thông tin công ty")]
    COMPANY_VIEW,

    [Function(TextEn = "", TextVi = "Xem danh sách chi nhánh")]
    OFFICE_VIEW,

    [Function(TextEn = "", TextVi = "Xem danh sách nghề nghiệp")]
    JOB_VIEW,

    [Function(TextEn = "", TextVi = "Hiệu chỉnh thông tin công ty")]
    COMPANY_EDIT_SAVE,

    [Function(TextEn = "", TextVi = "Tạo mới/ hiệu chỉnh chi nhánh")]
    OFFICE_EDIT_SAVE,

    [Function(TextEn = "", TextVi = "Tạo mới/ hiệu chỉnh nghề nghiệp")]
    JOB_EDIT_SAVE,

    [Function(TextEn = "", TextVi = "Xóa chi nhánh")]
    OFFICE_DELETE,

    [Function(TextEn = "", TextVi = "Xóa nghề nghiệp")]
    JOB_DELETE,

    [Function(TextEn = "", TextVi = "Đặt chi nhánh làm trụ sở chính")]
    OFFICE_HEAD_QUARTER,

    [Function(TextEn = "", TextVi = "Kích hoạt chi nhánh")]
    OFFICE_ACTIVE,
}
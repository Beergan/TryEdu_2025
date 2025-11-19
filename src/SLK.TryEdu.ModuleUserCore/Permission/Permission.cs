using SLK.TryEdu.Abstract;

namespace SLK.TryEdu.ModuleUserCore;
 
[Feature(Name = "ModuleUser", TextEn = "", TextVi = "MODULE HỌC VIÊN")]
public enum PERMISSION
{
    [Function(TextEn = "", TextVi = "Xem danh sách học viên")]
    USER_VIEW,

 
    [Function(TextEn = "", TextVi = "Tạo mới/ hiệu chỉnh học viên")]
    USER_CREATE_UPDATE,

    [Function(TextEn = "", TextVi = "Kích hoạt tài khoản học viên")]
    USER_ACTIVE_ACCOUNT,

}
using SLK.TryEdu.Abstract;
namespace SLK.TryEdu.ModuleContentCore;  
 
[Feature(Name = "ModuleCourse", TextEn = "", TextVi = "MODULE NỘI DỤNG")]
public enum PERMISSION
{
    [Function(TextEn = "", TextVi = "Xem danh khóa học")]
    COURSE_VIEW,

 
    [Function(TextEn = "", TextVi = "Tạo mới/ hiệu chỉnh khóa học")]
    COURSE_CREATE_UPDATE,

    [Function(TextEn = "", TextVi = "Kích hoạt tài tiền")]
    COURSE_ACTIVE_ACCOUNT, 

}
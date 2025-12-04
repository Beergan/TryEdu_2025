using SLK.TryEdu.Abstract;
namespace SLK.TryEdu.ModuleExamCore;    
 
[Feature(Name = "ModuleEXAM", TextEn = "", TextVi = "MODULE THI THỬ")]
public enum PERMISSION
{
    [Function(TextEn = "", TextVi = "Xem danh sách thi thử")]
    EXAM_VIEW,

 
    [Function(TextEn = "", TextVi = "Tạo mới/ hiệu chỉnh thi thử")]
    EXAM_CREATE_UPDATE,

    [Function(TextEn = "", TextVi = "Kích hoạt thi thử")] 
    EXAM_ACTIVE_ACCOUNT,

}
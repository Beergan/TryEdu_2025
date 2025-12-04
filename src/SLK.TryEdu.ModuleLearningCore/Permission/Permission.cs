using SLK.TryEdu.Abstract;
namespace SLK.TryEdu.ModuleLearningCore;   
 
[Feature(Name = "ModuleLearning", TextEn = "", TextVi = "MODULE HỌC TẬP")]
public enum PERMISSION
{
    [Function(TextEn = "", TextVi = "Xem danh học tập")]
    LEARNING_VIEW,

 
    [Function(TextEn = "", TextVi = "Tạo mới/ hiệu học tập")]
    LEARNING_CREATE_UPDATE,

}
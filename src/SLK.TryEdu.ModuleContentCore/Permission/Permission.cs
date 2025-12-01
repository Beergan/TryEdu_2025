using SLK.TryEdu.Abstract;
namespace SLK.TryEdu.ModuleContentCore;  
 
[Feature(Name = "ModuleCoin", TextEn = "", TextVi = "MODULE TIỀN TỆ")]
public enum PERMISSION
{
    [Function(TextEn = "", TextVi = "Xem danh sách tiền")]
    COIN_VIEW,

 
    [Function(TextEn = "", TextVi = "Tạo mới/ hiệu chỉnh tiền")]
    COIN_CREATE_UPDATE,

    [Function(TextEn = "", TextVi = "Kích hoạt tài tiền")]
    COIN_ACTIVE_ACCOUNT,

}
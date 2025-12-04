using SLK.TryEdu.Abstract;

namespace SLK.TryEdu.ModulePartnerCore;  
 
[Feature(Name = "ModulePartner", TextEn = "", TextVi = "MODULE ĐỐI TÁC")]
public enum PERMISSION
{
    [Function(TextEn = "", TextVi = "Xem danh đối tác")]
    PARTNER_VIEW,

 
    [Function(TextEn = "", TextVi = "Tạo mới/ hiệu đối tác")]
    PARTNER_CREATE_UPDATE,

    [Function(TextEn = "", TextVi = "Kích hoạt đối tác")]
    PARTNER_ACTIVE_ACCOUNT, 

}
using System;
using SLK.TryEdu.Abstract;

namespace SLK.TryEdu.ModuleManagementCore;

[Feature(Name = "ModuleManagement", TextEn = "", TextVi = "MODULE QUẢN TRỊ")]
public enum PERMISSION
{
    [Function(TextEn = "", TextVi = "Quản trị")]
    ADMIN_ACCOUNTS,

    [Function(TextEn = "", TextVi = "Xem logs hệ thống")]
    AUDIT_LOG,
}
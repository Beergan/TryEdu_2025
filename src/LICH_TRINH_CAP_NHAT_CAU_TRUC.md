# 📋 TÓM TẮT CẬP NHẬT LỊCH TRÌNH THEO CẤU TRÚC HIỆN TẠI

## 🔄 THAY ĐỔI CHÍNH

### **1. Cấu trúc Module thay vì Microservices**

**Trước (Lịch trình cũ):**
- `SLK.TryEdu.CoreService` (Web API)
- `SLK.TryEdu.CoinService` (Web API)
- `SLK.TryEdu.ContentService` (Web API)

**Sau (Cấu trúc hiện tại):**
- `SLK.TryEdu.ModuleCoin` (Controllers, Services, Queries)
- `SLK.TryEdu.ModuleCoinCore` (Entities, Interfaces, Models)
- `SLK.TryEdu.ModuleCoinBlazor` (Blazor components)
- Tương tự cho `ModulePartner`, `ModuleContent`

### **2. Database Infrastructure**

**Đã có sẵn:**
- `SLK.TryEdu.Db` với PostgreSQL, MySQL, SQL Server support
- `DbPostgresContext` kế thừa từ `IdentityDbContext<SA_USER>`
- Entity registration pattern qua `SetupAction`
- Audit logging tự động
- UTC timestamp conversion tự động

**Cần làm:**
- Tạo entities kế thừa từ `EntityBase`
- Register entities trong `EntityRegister.cs`
- Tạo migrations

### **3. Service Pattern**

**Pattern hiện tại:**
```csharp
public class UserService : MyServiceBase, IUserService
{
    private readonly IMyContext _ctx;
    
    public async Task<ResultOf<EntityUser>> Get(Guid guid)
    {
        if (!_ctx.CheckPermission(PERMISSION.USER_VIEW))
            return ResultOf<EntityUser>.Error("Not authorized");
        
        var data = await _ctx.Repo<EntityUser>().Query(t => t.Guid == guid)
            .SingleOrDefaultAsync();
        
        return ResultOf<EntityUser>.Ok(data);
    }
}
```

**Controller Pattern:**
```csharp
[Authorize]
[Route("api/User/[action]")]
[ApiController]
public class UserController : UserService, IUserService
{
    public UserController(IMyContext ctx, ILogger<UserService> log, IWebHostEnvironment env) 
        : base(ctx, log, env)
    {
    }
}
```

### **4. Entity Base Class**

**EntityBase có sẵn:**
```csharp
public class EntityBase
{
    public int Id { get; set; }
    public Guid Guid { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime DateModified { get; set; }
    public string UserCreated { get; set; }
    public string UserModified { get; set; }
}
```

**Tất cả entities phải:**
- Kế thừa từ `EntityBase`
- Có `[Table("table_name")]` attribute
- Guid phải có alternate key trong DbContext

### **5. Authentication & Authorization**

**Đã có:**
- JWT authentication trong `SLK.TryEdu.Base`
- Permission system trong `SLK.TryEdu.Abstract/Permission/`
- `_ctx.CheckPermission()` trong services
- Identity với `SA_USER`

**Cần làm:**
- Thêm Partner role vào Identity
- Thêm permissions mới cho Coin & Partner
- Cập nhật JWT claims

### **6. Frontend**

**Đã có:**
- `SLK.TryEdu.WebHost` - Razor Pages (Server-side)
- `SLK.TryEdu.WebApp` - Blazor WebAssembly
- MudBlazor và Syncfusion components

**Cần làm:**
- Tạo Blazor components trong `ModuleXBlazor`
- Tích hợp với WebHost/WebApp

## 📝 CHECKLIST CẬP NHẬT

### **TUẦN 1: Setup**
- [x] Tạo ModuleCoin, ModulePartner, ModuleContent
- [x] Setup project references
- [x] Tạo entities kế thừa EntityBase
- [x] Register entities trong DbContext
- [x] Tạo migrations

### **TUẦN 2: Authentication**
- [ ] Cập nhật EntityUser để support Partner role
- [ ] Thêm PartnerRegistrationService
- [ ] Cập nhật UserController với RegisterPartner endpoint
- [ ] Thêm permissions mới
- [ ] Cập nhật JWT configuration

### **TUẦN 3-4: Course & Exam**
- [ ] Tạo EntityCourse, EntityExam trong ModuleContentCore
- [ ] Tạo CourseService, ExamService trong ModuleContent
- [ ] Tạo CourseController, ExamController
- [ ] Tích hợp với Coin system

### **TUẦN 5-6: Coin & Referral**
- [ ] Tạo CoinService trong ModuleCoin
- [ ] Tạo ReferralCodeService
- [ ] Tạo CommissionService
- [ ] Tích hợp với payment gateway

### **TUẦN 7-8: Partner Portal**
- [ ] Tạo PartnerService trong ModulePartner
- [ ] Tạo PartnerController
- [ ] Tạo Blazor components trong ModulePartnerBlazor
- [ ] Dashboard, Referral Code Management

### **TUẦN 9-10: Integration & Testing**
- [ ] End-to-end testing
- [ ] Bug fixes
- [ ] Demo preparation

## ⚠️ LƯU Ý QUAN TRỌNG

1. **Không tạo services riêng**, dùng module pattern
2. **Tất cả entities** phải kế thừa `EntityBase`
3. **Sử dụng `_ctx.Repo<T>()`** để access database
4. **Sử dụng `ResultOf<T>`** cho return types
5. **Check permissions** với `_ctx.CheckPermission()`
6. **UTC timestamps** được handle tự động
7. **Guid alternate key** phải được config trong DbContext

## 🔗 LIÊN KẾT

- Database Schema: `database_schema_postgresql.md`
- Requirements: `HỆ THỐNG GIÁO DỤC TRỰC TUYẾN - V2.0 (B2B2C).md`
- Functional Overview: `DINH_HUONG_CHUC_NANG_V2.0.md`
- Updated Timeline: `LICH_TRINH_VIET_CODE_BAN_THU_NGHIEM.md`


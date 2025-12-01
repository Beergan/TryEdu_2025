# 📅 LỊCH TRÌNH VIẾT CODE - BẢN THỬ NGHIỆM ĐẦU TIÊN
## HỆ THỐNG GIÁO DỤC TRỰC TUYẾN V2.0 (B2B2C)

---

## 🎯 MỤC TIÊU BẢN THỬ NGHIỆM

**Thời gian:** 2.5 tháng (10 tuần làm việc)
**Mục tiêu:** Có thể demo hệ thống với các tính năng cốt lõi

### ✅ Tính năng tối thiểu cần có:
1. ✅ Đăng ký/Đăng nhập (Student, Teacher, Admin, Partner)
2. ✅ Quản lý khóa học miễn phí (Admin tạo, Student xem)
3. ✅ Hệ thống Coin cơ bản (Nạp coin, Mua bài thi)
4. ✅ Mã giới thiệu cơ bản (Partner tạo, Student dùng)
5. ✅ Tạo và làm bài thi (Admin tạo, Student làm)
6. ✅ Chấm điểm AI cơ bản
7. ✅ Partner Portal MVP (Dashboard, Quản lý mã)
8. ✅ Admin Portal cơ bản

---

## 📊 TIMELINE TỔNG QUAN

```
TUẦN 1-2: Setup & Infrastructure
TUẦN 3-4: Authentication & User Management
TUẦN 5-6: Course & Exam System
TUẦN 7-8: Coin & Referral System
TUẦN 9-10: Partner Portal & Integration Testing
```

---

## 📋 CHI TIẾT TỪNG TUẦN

---

## 🔧 TUẦN 1: SETUP PROJECT & DATABASE (Ngày 1-5)

### **Ngày 1: Setup Solution Structure**

#### **Bước 1.1: Tạo Modules Mới (Theo Pattern Hiện Tại)**

**Lưu ý:** Hệ thống đã có cấu trúc module-based. Chúng ta sẽ tạo modules mới theo pattern hiện có.

```bash
# Solution đã tồn tại: SLK.TryEdu.sln
# Cấu trúc hiện có:
# - SLK.TryEdu.Abstract (Shared abstractions)
# - SLK.TryEdu.Base (Base classes với MediatR, JWT, RabbitMQ)
# - SLK.TryEdu.Db (Database layer với PostgreSQL, MySQL, SQL Server)
# - SLK.TryEdu.WebHost (Server-side Razor Pages)
# - SLK.TryEdu.WebApp (Blazor WebAssembly)
# - Modules: ModuleUser, ModuleEmployee, ModuleManagement, ModuleSetting

# Tạo modules mới cho V2.0:
# ModuleCoin: Coin & Referral Code System
# ModulePartner: Partner Portal
# ModuleContent: Course & Exam System

# Tạo ModuleCoin
dotnet new classlib -n SLK.TryEdu.ModuleCoinCore -f net8.0
dotnet new classlib -n SLK.TryEdu.ModuleCoin -f net8.0
dotnet new razorclasslib -n SLK.TryEdu.ModuleCoinBlazor -f net8.0

# Tạo ModulePartner
dotnet new classlib -n SLK.TryEdu.ModulePartnerCore -f net8.0
dotnet new classlib -n SLK.TryEdu.ModulePartner -f net8.0
dotnet new razorclasslib -n SLK.TryEdu.ModulePartnerBlazor -f net8.0

# Tạo ModuleContent
dotnet new classlib -n SLK.TryEdu.ModuleContentCore -f net8.0
dotnet new classlib -n SLK.TryEdu.ModuleContent -f net8.0
dotnet new razorclasslib -n SLK.TryEdu.ModuleContentBlazor -f net8.0

# Add to solution
dotnet sln add src/SLK.TryEdu.ModuleCoinCore/SLK.TryEdu.ModuleCoinCore.csproj
dotnet sln add src/SLK.TryEdu.ModuleCoin/SLK.TryEdu.ModuleCoin.csproj
dotnet sln add src/SLK.TryEdu.ModuleCoinBlazor/SLK.TryEdu.ModuleCoinBlazor.csproj

dotnet sln add src/SLK.TryEdu.ModulePartnerCore/SLK.TryEdu.ModulePartnerCore.csproj
dotnet sln add src/SLK.TryEdu.ModulePartner/SLK.TryEdu.ModulePartner.csproj
dotnet sln add src/SLK.TryEdu.ModulePartnerBlazor/SLK.TryEdu.ModulePartnerBlazor.csproj

dotnet sln add src/SLK.TryEdu.ModuleContentCore/SLK.TryEdu.ModuleContentCore.csproj
dotnet sln add src/SLK.TryEdu.ModuleContent/SLK.TryEdu.ModuleContent.csproj
dotnet sln add src/SLK.TryEdu.ModuleContentBlazor/SLK.TryEdu.ModuleContentBlazor.csproj
```

**Ràng buộc:**
- ✅ Tất cả projects phải dùng .NET 8.0
- ✅ Tuân theo pattern module hiện có: `ModuleX`, `ModuleXCore`, `ModuleXBlazor`
- ✅ ModuleXCore: Entities, Interfaces, Models
- ✅ ModuleX: Controllers, Services, Queries
- ✅ ModuleXBlazor: Blazor components và Pages
- ✅ Naming convention: SLK.TryEdu.Module{Name}

**Acceptance Criteria:**
- [ ] Solution build thành công
- [ ] Tất cả modules mới được add vào solution
- [ ] Project references được setup đúng (ModuleX → ModuleXCore → Abstract/Base/Db)

---

#### **Bước 1.2: Setup Project References**

**ModuleCoinCore:**
```bash
cd src/SLK.TryEdu.ModuleCoinCore
dotnet add reference ../SLK.TryEdu.Abstract/SLK.TryEdu.Abstract.csproj
```

**ModuleCoin:**
```bash
cd ../SLK.TryEdu.ModuleCoin
dotnet add reference ../SLK.TryEdu.ModuleCoinCore/SLK.TryEdu.ModuleCoinCore.csproj
dotnet add reference ../SLK.TryEdu.Base/SLK.TryEdu.Base.csproj
dotnet add reference ../SLK.TryEdu.Db/SLK.TryEdu.Db.csproj
```

**ModuleCoinBlazor:**
```bash
cd ../SLK.TryEdu.ModuleCoinBlazor
dotnet add reference ../SLK.TryEdu.ModuleCoinCore/SLK.TryEdu.ModuleCoinCore.csproj
dotnet add reference ../SLK.TryEdu.Abstract/SLK.TryEdu.Abstract.csproj
```

**Lưu ý:** 
- ✅ Packages đã được install trong Base, Db, Abstract
- ✅ Chỉ cần add project references
- ✅ ModuleXCore không reference Base/Db (chỉ Abstract)
- ✅ ModuleX reference Base và Db để dùng services
- ✅ ModuleXBlazor reference Abstract và ModuleXCore

**Ràng buộc:**
- ✅ Tuân theo dependency hierarchy: Blazor → Module → Core → Abstract/Base/Db
- ✅ Không có circular dependencies
- ✅ Tất cả modules phải reference Abstract

---

### **Ngày 2-3: Database Schema Design**

#### **Bước 2.1: Tạo Migration cho Coin & Partner Tables**

**Lưu ý:** Database đã có infrastructure trong `SLK.TryEdu.Db`. Chúng ta sẽ tạo migration mới.

Tạo file `src/SLK.TryEdu.Db/Migrations/20250101_AddCoinAndPartnerTables.cs`:

```csharp
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace SLK.TryEdu.Db.Migrations
{
    public partial class AddCoinAndPartnerTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Partner Centers Table
            migrationBuilder.CreateTable(
                name: "partner_centers",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    guid = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    contact_person = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    phone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    address = table.Column<string>(type: "text", nullable: true),
                    commission_rate = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: false, defaultValue: 5.00m),
                    tier = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false, defaultValue: "Bronze"),
                    status = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false, defaultValue: "Pending"),
                    business_license_url = table.Column<string>(type: "text", nullable: true),
                    logo_url = table.Column<string>(type: "text", nullable: true),
                    date_created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    date_modified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    user_created = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false, defaultValue: "System"),
                    user_modified = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false, defaultValue: "System")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_partner_centers", x => x.id);
                    table.UniqueConstraint("ak_partner_centers_guid", x => x.guid);
                });

            migrationBuilder.CreateIndex(
                name: "ix_partner_centers_email",
                table: "partner_centers",
                column: "email",
                unique: true);

            // Referral Codes Table
            migrationBuilder.CreateTable(
                name: "referral_codes",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    guid = table.Column<Guid>(type: "uuid", nullable: false),
                    partner_center_id = table.Column<int>(type: "integer", nullable: false),
                    code = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    discount_percentage = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: false, defaultValue: 10.00m),
                    discount_coins = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    expiry_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    usage_count = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    max_usage = table.Column<int>(type: "integer", nullable: false, defaultValue: -1),
                    date_created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    date_modified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    user_created = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false, defaultValue: "System"),
                    user_modified = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false, defaultValue: "System")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_referral_codes", x => x.id);
                    table.UniqueConstraint("ak_referral_codes_guid", x => x.guid);
                    table.ForeignKey(
                        name: "fk_referral_codes_partner_centers_partner_center_id",
                        column: x => x.partner_center_id,
                        principalTable: "partner_centers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_referral_codes_code",
                table: "referral_codes",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_referral_codes_partner_center_id",
                table: "referral_codes",
                column: "partner_center_id");

            // Coin Transactions Table
            migrationBuilder.CreateTable(
                name: "coin_transactions",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    guid = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    amount = table.Column<decimal>(type: "numeric(12,2)", precision: 12, scale: 2, nullable: false),
                    coins_received = table.Column<int>(type: "integer", nullable: false),
                    exchange_rate = table.Column<decimal>(type: "numeric(8,4)", precision: 8, scale: 4, nullable: false),
                    payment_method = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    referral_code_id = table.Column<int>(type: "integer", nullable: true),
                    status = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false, defaultValue: "Pending"),
                    transaction_id = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    date_created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    date_modified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    user_created = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false, defaultValue: "System"),
                    user_modified = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false, defaultValue: "System")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_coin_transactions", x => x.id);
                    table.UniqueConstraint("ak_coin_transactions_guid", x => x.guid);
                    table.ForeignKey(
                        name: "fk_coin_transactions_referral_codes_referral_code_id",
                        column: x => x.referral_code_id,
                        principalTable: "referral_codes",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "ix_coin_transactions_user_id",
                table: "coin_transactions",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_coin_transactions_status",
                table: "coin_transactions",
                column: "status");

            // Commission Transactions Table
            migrationBuilder.CreateTable(
                name: "commission_transactions",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    guid = table.Column<Guid>(type: "uuid", nullable: false),
                    partner_center_id = table.Column<int>(type: "integer", nullable: false),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    referral_code_id = table.Column<int>(type: "integer", nullable: true),
                    transaction_amount = table.Column<decimal>(type: "numeric(12,2)", precision: 12, scale: 2, nullable: false),
                    commission_amount = table.Column<decimal>(type: "numeric(12,2)", precision: 12, scale: 2, nullable: false),
                    commission_rate = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: false),
                    transaction_type = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    status = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false, defaultValue: "Pending"),
                    date_created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    date_modified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    user_created = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false, defaultValue: "System"),
                    user_modified = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false, defaultValue: "System")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_commission_transactions", x => x.id);
                    table.UniqueConstraint("ak_commission_transactions_guid", x => x.guid);
                    table.ForeignKey(
                        name: "fk_commission_transactions_partner_centers_partner_center_id",
                        column: x => x.partner_center_id,
                        principalTable: "partner_centers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_commission_transactions_partner_center_id",
                table: "commission_transactions",
                column: "partner_center_id");

            migrationBuilder.CreateIndex(
                name: "ix_commission_transactions_status",
                table: "commission_transactions",
                column: "status");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "commission_transactions");
            migrationBuilder.DropTable(name: "coin_transactions");
            migrationBuilder.DropTable(name: "referral_codes");
            migrationBuilder.DropTable(name: "partner_centers");
        }
    }
}
```

**Ràng buộc:**
- ✅ Tất cả entities phải kế thừa từ `EntityBase` (có Id, Guid, DateCreated, DateModified, UserCreated, UserModified)
- ✅ Table names phải lowercase với underscore (snake_case)
- ✅ Foreign keys phải có `ON DELETE CASCADE` hoặc `ON DELETE SET NULL`
- ✅ Indexes cho các columns thường query
- ✅ Constraints cho data validation
- ✅ Guid phải unique (alternate key)

---

#### **Bước 2.2: Register Entities trong DbContext**

Cập nhật `src/SLK.TryEdu.Db/DbPostgres/Context/DbPostgresContext.cs` hoặc tạo file registration:

Tạo file `src/SLK.TryEdu.ModuleCoin/Classes/EntityRegister.cs`:

```csharp
using Microsoft.EntityFrameworkCore;
using SLK.TryEdu.ModuleCoinCore.Entities;
using SLK.TryEdu.Db.DbPostgres;

namespace SLK.TryEdu.ModuleCoin.Classes
{
    public class EntityRegister
    {
        public static void RegisterEntities(ModelBuilder builder)
        {
            // Partner Center Configuration
            builder.Entity<EntityPartnerCenter>(entity =>
            {
                entity.ToTable("partner_centers");
                entity.HasKey(e => e.Id);
                entity.HasAlternateKey(e => e.Guid);
                entity.HasIndex(e => e.Email).IsUnique();
                entity.Property(e => e.CommissionRate).HasPrecision(5, 2);
                entity.Property(e => e.Tier).HasDefaultValue("Bronze");
                entity.Property(e => e.Status).HasDefaultValue("Pending");
            });

            // Referral Code Configuration
            builder.Entity<EntityReferralCode>(entity =>
            {
                entity.ToTable("referral_codes");
                entity.HasKey(e => e.Id);
                entity.HasAlternateKey(e => e.Guid);
                entity.HasIndex(e => e.Code).IsUnique();
                entity.Property(e => e.DiscountPercentage).HasPrecision(5, 2);
                entity.HasOne(e => e.PartnerCenter)
                    .WithMany(p => p.ReferralCodes)
                    .HasForeignKey(e => e.PartnerCenterId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // Coin Transaction Configuration
            builder.Entity<EntityCoinTransaction>(entity =>
            {
                entity.ToTable("coin_transactions");
                entity.HasKey(e => e.Id);
                entity.HasAlternateKey(e => e.Guid);
                entity.Property(e => e.Amount).HasPrecision(12, 2);
                entity.Property(e => e.ExchangeRate).HasPrecision(8, 4);
                entity.HasIndex(e => e.UserId);
                entity.HasIndex(e => e.Status);
            });

            // Commission Transaction Configuration
            builder.Entity<EntityCommissionTransaction>(entity =>
            {
                entity.ToTable("commission_transactions");
                entity.HasKey(e => e.Id);
                entity.HasAlternateKey(e => e.Guid);
                entity.Property(e => e.TransactionAmount).HasPrecision(12, 2);
                entity.Property(e => e.CommissionAmount).HasPrecision(12, 2);
                entity.Property(e => e.CommissionRate).HasPrecision(5, 2);
                entity.HasOne(e => e.PartnerCenter)
                    .WithMany(p => p.CommissionTransactions)
                    .HasForeignKey(e => e.PartnerCenterId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
```

**Ràng buộc:**
- ✅ Tất cả entities phải kế thừa từ `EntityBase`
- ✅ Table names phải lowercase với underscore
- ✅ Guid phải có alternate key
- ✅ Foreign keys phải có `OnDelete` behavior rõ ràng
- ✅ Indexes cho performance

---

#### **Bước 2.3: Course & Exam Tables (PostgreSQL)**

**Lưu ý:** Với cấu trúc hiện tại, chúng ta có thể lưu Course và Exam trong PostgreSQL. Nếu cần MongoDB cho content chi tiết, sẽ thêm sau.

Tạo migration cho Course & Exam:

```csharp
// Courses Table
migrationBuilder.CreateTable(
    name: "courses",
    columns: table => new
    {
        id = table.Column<int>(type: "integer", nullable: false),
        guid = table.Column<Guid>(type: "uuid", nullable: false),
        title = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
        description = table.Column<string>(type: "text", nullable: true),
        is_free = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
        price_coins = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
        created_by = table.Column<int>(type: "integer", nullable: true),
        date_created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
        date_modified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
        user_created = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
        user_modified = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
    },
    constraints: table =>
    {
        table.PrimaryKey("pk_courses", x => x.id);
        table.UniqueConstraint("ak_courses_guid", x => x.guid);
    });

// Exams Table
migrationBuilder.CreateTable(
    name: "exams",
    columns: table => new
    {
        id = table.Column<int>(type: "integer", nullable: false),
        guid = table.Column<Guid>(type: "uuid", nullable: false),
        title = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
        description = table.Column<string>(type: "text", nullable: true),
        price_coins = table.Column<int>(type: "integer", nullable: false),
        duration = table.Column<int>(type: "integer", nullable: false), // seconds
        exam_data = table.Column<string>(type: "jsonb", nullable: true), // JSON cho sections, questions
        created_by = table.Column<int>(type: "integer", nullable: true),
        date_created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
        date_modified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
        user_created = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
        user_modified = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
    },
    constraints: table =>
    {
        table.PrimaryKey("pk_exams", x => x.id);
        table.UniqueConstraint("ak_exams_guid", x => x.guid);
    });
```

**Ràng buộc:**
- ✅ Tất cả entities phải kế thừa từ `EntityBase`
- ✅ Course miễn phí phải có `price_coins = 0`
- ✅ Exam phải có `price_coins > 0`
- ✅ Exam data có thể lưu JSONB cho flexibility
- ✅ Nếu cần MongoDB sau, sẽ migrate dần

---

### **Ngày 4-5: Entity Models & Registration**

#### **Bước 4.1: Tạo Entity Models trong ModuleCoinCore**

Tạo file `src/SLK.TryEdu.ModuleCoinCore/Entities/EntityPartnerCenter.cs`:

```csharp
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SLK.TryEdu.Abstract;

namespace SLK.TryEdu.ModuleCoinCore.Entities
{
    [Table("partner_centers")]
    public class EntityPartnerCenter : EntityBase
    {
        [Required]
        [MaxLength(255)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(255)]
        public string? ContactPerson { get; set; }

        [Required]
        [MaxLength(255)]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [MaxLength(20)]
        public string? Phone { get; set; }

        public string? Address { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal CommissionRate { get; set; } = 5.00m;

        [MaxLength(20)]
        public string Tier { get; set; } = "Bronze"; // Bronze, Silver, Gold, Platinum

        [MaxLength(20)]
        public string Status { get; set; } = "Pending"; // Pending, Approved, Rejected, Active, Suspended

        public string? BusinessLicenseUrl { get; set; }
        public string? LogoUrl { get; set; }

        // Navigation
        public virtual ICollection<EntityReferralCode> ReferralCodes { get; set; } = new List<EntityReferralCode>();
        public virtual ICollection<EntityCommissionTransaction> CommissionTransactions { get; set; } = new List<EntityCommissionTransaction>();
    }
}
```

Tạo file `src/SLK.TryEdu.ModuleCoinCore/Entities/EntityReferralCode.cs`:

```csharp
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SLK.TryEdu.Abstract;

namespace SLK.TryEdu.ModuleCoinCore.Entities
{
    [Table("referral_codes")]
    public class EntityReferralCode : EntityBase
    {
        [Required]
        public int PartnerCenterId { get; set; }

        [Required]
        [MaxLength(20)]
        public string Code { get; set; } = string.Empty;

        [Column(TypeName = "decimal(5,2)")]
        public decimal DiscountPercentage { get; set; } = 10.00m;

        public int DiscountCoins { get; set; } = 0;

        public bool IsActive { get; set; } = true;

        public DateTime? ExpiryDate { get; set; }

        public int UsageCount { get; set; } = 0;

        public int MaxUsage { get; set; } = -1; // -1 = unlimited

        // Navigation
        [ForeignKey(nameof(PartnerCenterId))]
        public virtual EntityPartnerCenter PartnerCenter { get; set; } = null!;
    }
}
```

Tạo file `src/SLK.TryEdu.ModuleCoinCore/Entities/EntityCoinTransaction.cs`:

```csharp
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SLK.TryEdu.Abstract;

namespace SLK.TryEdu.ModuleCoinCore.Entities
{
    [Table("coin_transactions")]
    public class EntityCoinTransaction : EntityBase
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        [Column(TypeName = "decimal(12,2)")]
        public decimal Amount { get; set; }

        [Required]
        public int CoinsReceived { get; set; }

        [Required]
        [Column(TypeName = "decimal(8,4)")]
        public decimal ExchangeRate { get; set; }

        [MaxLength(50)]
        public string? PaymentMethod { get; set; }

        public int? ReferralCodeId { get; set; }

        [MaxLength(20)]
        public string Status { get; set; } = "Pending"; // Pending, Completed, Failed, Cancelled

        [MaxLength(100)]
        public string? TransactionId { get; set; }

        // Navigation
        [ForeignKey(nameof(ReferralCodeId))]
        public virtual EntityReferralCode? ReferralCode { get; set; }
    }
}
```

Tạo file `src/SLK.TryEdu.ModuleCoinCore/Entities/EntityCommissionTransaction.cs`:

```csharp
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SLK.TryEdu.Abstract;

namespace SLK.TryEdu.ModuleCoinCore.Entities
{
    [Table("commission_transactions")]
    public class EntityCommissionTransaction : EntityBase
    {
        [Required]
        public int PartnerCenterId { get; set; }

        [Required]
        public int UserId { get; set; }

        public int? ReferralCodeId { get; set; }

        [Required]
        [Column(TypeName = "decimal(12,2)")]
        public decimal TransactionAmount { get; set; }

        [Required]
        [Column(TypeName = "decimal(12,2)")]
        public decimal CommissionAmount { get; set; }

        [Required]
        [Column(TypeName = "decimal(5,2)")]
        public decimal CommissionRate { get; set; }

        [Required]
        [MaxLength(50)]
        public string TransactionType { get; set; } = string.Empty; // CoinPurchase, ExamPurchase

        [MaxLength(20)]
        public string Status { get; set; } = "Pending"; // Pending, Paid, Cancelled

        // Navigation
        [ForeignKey(nameof(PartnerCenterId))]
        public virtual EntityPartnerCenter PartnerCenter { get; set; } = null!;
    }
}
```

#### **Bước 4.2: Register Entities trong DbContext**

Cập nhật `src/SLK.TryEdu.ModuleCoin/Classes/EntityRegister.cs` để register entities:

```csharp
using Microsoft.EntityFrameworkCore;
using SLK.TryEdu.ModuleCoinCore.Entities;

namespace SLK.TryEdu.ModuleCoin.Classes
{
    public class EntityRegister
    {
        public static void RegisterEntities(ModelBuilder builder)
        {
            // Partner Center
            builder.Entity<EntityPartnerCenter>(entity =>
            {
                entity.ToTable("partner_centers");
                entity.HasKey(e => e.Id);
                entity.HasAlternateKey(e => e.Guid);
                entity.HasIndex(e => e.Email).IsUnique();
                entity.Property(e => e.CommissionRate).HasPrecision(5, 2);
            });

            // Referral Code
            builder.Entity<EntityReferralCode>(entity =>
            {
                entity.ToTable("referral_codes");
                entity.HasKey(e => e.Id);
                entity.HasAlternateKey(e => e.Guid);
                entity.HasIndex(e => e.Code).IsUnique();
                entity.Property(e => e.DiscountPercentage).HasPrecision(5, 2);
                entity.HasOne(e => e.PartnerCenter)
                    .WithMany(p => p.ReferralCodes)
                    .HasForeignKey(e => e.PartnerCenterId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // Coin Transaction
            builder.Entity<EntityCoinTransaction>(entity =>
            {
                entity.ToTable("coin_transactions");
                entity.HasKey(e => e.Id);
                entity.HasAlternateKey(e => e.Guid);
                entity.Property(e => e.Amount).HasPrecision(12, 2);
                entity.Property(e => e.ExchangeRate).HasPrecision(8, 4);
                entity.HasIndex(e => e.UserId);
                entity.HasIndex(e => e.Status);
            });

            // Commission Transaction
            builder.Entity<EntityCommissionTransaction>(entity =>
            {
                entity.ToTable("commission_transactions");
                entity.HasKey(e => e.Id);
                entity.HasAlternateKey(e => e.Guid);
                entity.Property(e => e.TransactionAmount).HasPrecision(12, 2);
                entity.Property(e => e.CommissionAmount).HasPrecision(12, 2);
                entity.Property(e => e.CommissionRate).HasPrecision(5, 2);
                entity.HasOne(e => e.PartnerCenter)
                    .WithMany(p => p.CommissionTransactions)
                    .HasForeignKey(e => e.PartnerCenterId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
```

Cập nhật `src/SLK.TryEdu.Db/DbPostgres/Context/DbPostgresContext.cs` để gọi registration:

```csharp
protected override void OnModelCreating(ModelBuilder builder)
{
    base.OnModelCreating(builder);
    
    // Register entities from modules
    SLK.TryEdu.ModuleCoin.Classes.EntityRegister.RegisterEntities(builder);
    // ... other module registrations
}
```

**Ràng buộc:**
- ✅ Tất cả entities phải kế thừa từ `EntityBase`
- ✅ Table names phải lowercase với underscore
- ✅ Guid phải có alternate key
- ✅ Foreign keys phải có `OnDelete` behavior rõ ràng
- ✅ Indexes cho performance
- ✅ Decimal precision phải đúng

**Acceptance Criteria:**
- [ ] Entities compile thành công
- [ ] Entity registration được gọi trong DbContext
- [ ] Migrations có thể tạo được
- [ ] Database có thể update được
- [ ] Tất cả constraints được enforce

---

## 🔐 TUẦN 2: AUTHENTICATION & USER MANAGEMENT (Ngày 6-10)

### **Ngày 6-7: Cập nhật User Module cho Partner Role**

#### **Bước 6.1: Cập nhật EntityUser để support Partner role**

**Lưu ý:** `EntityUser` đã tồn tại trong `SLK.TryEdu.ModuleUserCore`. Chúng ta cần:

1. **Kiểm tra role support:**
   - Xem `EntityUser` có field Role không
   - Nếu chưa có, thêm field Role
   - Đảm bảo Role support: 'Student', 'Teacher', 'Admin', 'Partner', 'Accountant'

2. **Cập nhật UserService:**
   - Thêm validation cho Partner role
   - Thêm logic đăng ký Partner

Tạo file `src/SLK.TryEdu.ModuleUser/Services/PartnerRegistrationService.cs`:

```csharp
using SLK.TryEdu.Base;
using SLK.TryEdu.ModuleUserCore;
using SLK.TryEdu.ModuleCoinCore.Entities;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Hosting;

namespace SLK.TryEdu.ModuleUser.Services
{
    public interface IPartnerRegistrationService
    {
        Task<ResultOf<EntityUser>> RegisterPartnerAsync(PartnerRegistrationDto dto);
    }

    public class PartnerRegistrationService : MyServiceBase, IPartnerRegistrationService
    {
        private readonly ILogger<PartnerRegistrationService> _logger;
        private readonly IWebHostEnvironment _env;

        public PartnerRegistrationService(
            IMyContext ctx,
            ILogger<PartnerRegistrationService> logger,
            IWebHostEnvironment env) : base(ctx)
        {
            _logger = logger;
            _env = env;
        }

        public async Task<ResultOf<EntityUser>> RegisterPartnerAsync(PartnerRegistrationDto dto)
        {
            try
            {
                // Validate email
                var existingUser = await _ctx.Repo<EntityUser>()
                    .Query(u => u.Email == dto.Email)
                    .FirstOrDefaultAsync();

                if (existingUser != null)
                {
                    return ResultOf<EntityUser>.Error("Email already exists");
                }

                // Create user with Partner role
                var user = new EntityUser
                {
                    Email = dto.Email,
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                    FirstName = dto.ContactPersonFirstName,
                    LastName = dto.ContactPersonLastName,
                    Phone = dto.Phone,
                    IsActive = false, // Inactive until approved
                    IsVerified = false,
                    DateCreated = DateTime.UtcNow,
                    DateModified = DateTime.UtcNow,
                    UserCreated = "System"
                };

                // TODO: Set Role - cần check xem EntityUser có Role field không
                // Nếu dùng Identity, role sẽ ở bảng AspNetUserRoles

                await _ctx.Repo<EntityUser>().AddAsync(user);
                await _ctx.SaveChangesAsync();

                // Create Partner Center record
                var partnerCenter = new EntityPartnerCenter
                {
                    Name = dto.CenterName,
                    ContactPerson = $"{dto.ContactPersonFirstName} {dto.ContactPersonLastName}",
                    Email = dto.Email,
                    Phone = dto.Phone,
                    Address = dto.Address,
                    Status = "Pending",
                    Tier = "Bronze",
                    CommissionRate = 5.00m,
                    BusinessLicenseUrl = dto.BusinessLicenseUrl,
                    LogoUrl = dto.LogoUrl,
                    DateCreated = DateTime.UtcNow,
                    DateModified = DateTime.UtcNow,
                    UserCreated = "System"
                };

                await _ctx.Repo<EntityPartnerCenter>().AddAsync(partnerCenter);
                await _ctx.SaveChangesAsync();

                return ResultOf<EntityUser>.Ok(user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error registering partner");
                return ResultOf<EntityUser>.Error("Error during registration");
            }
        }
    }

    public class PartnerRegistrationDto
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string CenterName { get; set; } = string.Empty;
        public string ContactPersonFirstName { get; set; } = string.Empty;
        public string ContactPersonLastName { get; set; } = string.Empty;
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? BusinessLicenseUrl { get; set; }
        public string? LogoUrl { get; set; }
    }
}
```

**Ràng buộc:**
- ✅ Email phải unique
- ✅ Password phải hash (BCrypt)
- ✅ Partner user phải inactive cho đến khi admin approve
- ✅ Partner Center phải được tạo cùng lúc với user
- ✅ Timestamps phải UTC

---

#### **Bước 6.2: Cập nhật UserService để support Partner Registration**

**Lưu ý:** `UserService` đã tồn tại trong `SLK.TryEdu.ModuleUser`. Chúng ta cần:

1. **Kiểm tra authentication hiện tại:**
   - Xem `SLK.TryEdu.WebHost/Controllers/AuthController.cs`
   - Xem `SLK.TryEdu.Base` có JWT authentication chưa
   - Xem `SLK.TryEdu.WebHost/Services/ServerAuthService.cs`

2. **Cập nhật UserService:**
   - Thêm method `RegisterPartnerAsync`
   - Thêm validation cho Partner role

Cập nhật `src/SLK.TryEdu.ModuleUser/Services/UserService.cs`:

```csharp
// Thêm method mới vào UserService
public async Task<ResultOf<EntityUser>> RegisterPartnerAsync(PartnerRegistrationDto dto)
{
    if (!_ctx.CheckPermission(PERMISSION.USER_CREATE))
        return ResultOf<EntityUser>.Error(_ctx.Text["You are not authorized!", "Bạn không có quyền!"]);

    try
    {
        // Validate email exists
        var existingUser = await _ctx.Repo<EntityUser>()
            .Query(u => u.Email == dto.Email)
            .FirstOrDefaultAsync();

        if (existingUser != null)
        {
            return ResultOf<EntityUser>.Error("Email already exists");
        }

        // Hash password
        var passwordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password);

        // Create user
        var user = new EntityUser
        {
            Email = dto.Email,
            PasswordHash = passwordHash,
            FirstName = dto.ContactPersonFirstName,
            LastName = dto.ContactPersonLastName,
            Phone = dto.Phone,
            IsActive = false, // Inactive until admin approves
            IsVerified = false,
            DateCreated = DateTime.UtcNow,
            DateModified = DateTime.UtcNow,
            UserCreated = "System"
        };

        await _ctx.Repo<EntityUser>().AddAsync(user);
        await _ctx.SaveChangesAsync();

        // TODO: Assign Partner role (nếu dùng Identity, thêm vào AspNetUserRoles)

        // Create Partner Center
        var partnerCenter = new EntityPartnerCenter
        {
            Name = dto.CenterName,
            ContactPerson = $"{dto.ContactPersonFirstName} {dto.ContactPersonLastName}",
            Email = dto.Email,
            Phone = dto.Phone,
            Address = dto.Address,
            Status = "Pending",
            Tier = "Bronze",
            CommissionRate = 5.00m,
            BusinessLicenseUrl = dto.BusinessLicenseUrl,
            LogoUrl = dto.LogoUrl,
            DateCreated = DateTime.UtcNow,
            DateModified = DateTime.UtcNow,
            UserCreated = "System"
        };

        await _ctx.Repo<EntityPartnerCenter>().AddAsync(partnerCenter);
        await _ctx.SaveChangesAsync();

        return ResultOf<EntityUser>.Ok(user);
    }
    catch (Exception ex)
    {
        _log.LogError($"{_ctx.Summary} - {ex.Message}");
        return ResultOf<EntityUser>.Error("Error during registration");
    }
}
```

**Ràng buộc:**
- ✅ Sử dụng pattern `ResultOf<T>` như các services khác
- ✅ Sử dụng `_ctx.Repo<T>()` để access database
- ✅ Sử dụng `_ctx.CheckPermission()` cho authorization
- ✅ Password phải hash bằng BCrypt
- ✅ Partner user phải inactive cho đến khi admin approve
- ✅ Logging cho security events

**Acceptance Criteria:**
- [ ] Register Partner thành công với email mới
- [ ] Register fail với email đã tồn tại
- [ ] Partner Center được tạo cùng lúc với user
- [ ] User status = inactive cho đến khi approve

---

### **Ngày 8-9: JWT Configuration & Authorization**

#### **Bước 8.1: Kiểm tra JWT Configuration Hiện Tại**

**Lưu ý:** JWT authentication đã có trong `SLK.TryEdu.Base`. Chúng ta cần:

1. **Kiểm tra JWT setup:**
   - Xem `SLK.TryEdu.WebHost/Program.cs` hoặc `Startup.cs`
   - Xem JWT configuration trong `appsettings.json`
   - Xem `SLK.TryEdu.Base` có JWT services chưa

2. **Cập nhật nếu cần:**
   - Đảm bảo JWT support Partner role
   - Đảm bảo token có claims đầy đủ

Kiểm tra file `src/SLK.TryEdu.WebHost/Program.cs`:

```csharp
// Tìm JWT configuration
// Nếu chưa có, thêm vào:

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    // Configuration từ appsettings.json
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
    options.AddPolicy("TeacherOrAdmin", policy => policy.RequireRole("Teacher", "Admin"));
    options.AddPolicy("PartnerOrAdmin", policy => policy.RequireRole("Partner", "Admin"));
    options.AddPolicy("StudentOrPartner", policy => policy.RequireRole("Student", "Partner"));
});
```

**Ràng buộc:**
- ✅ JWT key phải đủ dài (ít nhất 32 characters)
- ✅ Token expiration phải hợp lý (24 hours)
- ✅ CORS phải configure đúng
- ✅ Swagger phải có JWT authentication (nếu có API)

---

#### **Bước 8.2: Permission System**

**Lưu ý:** Hệ thống đã có permission system trong `SLK.TryEdu.Abstract/Permission/`. Chúng ta cần:

1. **Thêm permissions mới:**
   - `PARTNER_VIEW`, `PARTNER_CREATE`, `PARTNER_UPDATE`, `PARTNER_DELETE`
   - `COIN_VIEW`, `COIN_PURCHASE`, `COIN_REFUND`
   - `REFERRAL_CODE_CREATE`, `REFERRAL_CODE_VIEW`
   - `COMMISSION_VIEW`, `COMMISSION_PAY`

Cập nhật file permission (nếu có):

```csharp
// Thêm vào permission constants
public const string PARTNER_VIEW = "PARTNER_VIEW";
public const string PARTNER_CREATE = "PARTNER_CREATE";
public const string PARTNER_APPROVE = "PARTNER_APPROVE";
public const string COIN_PURCHASE = "COIN_PURCHASE";
public const string REFERRAL_CODE_CREATE = "REFERRAL_CODE_CREATE";
```

**Ràng buộc:**
- ✅ Sử dụng permission system hiện có
- ✅ Check permission trong services với `_ctx.CheckPermission()`
- ✅ Permissions phải được assign cho roles đúng

**Acceptance Criteria:**
- [ ] JWT authentication hoạt động
- [ ] Partner role được support
- [ ] Permission checks hoạt động đúng
- [ ] Unauthorized request trả về 401
- [ ] Forbidden request trả về 403

---

### **Ngày 10: Cập nhật User Controller cho Partner**

#### **Bước 10.1: Thêm Partner Registration Endpoint**

**Lưu ý:** `UserController` đã tồn tại trong `SLK.TryEdu.ModuleUser/Controllers/UserController.cs`. Chúng ta cần:

1. **Thêm endpoint mới:**
   - `RegisterPartner` - Đăng ký trung tâm đối tác
   - `ApprovePartner` - Admin phê duyệt đối tác (sẽ làm ở ModulePartner)

Cập nhật `src/SLK.TryEdu.ModuleUser/Controllers/UserController.cs`:

```csharp
[HttpPost("RegisterPartner")]
[AllowAnonymous] // Cho phép đăng ký không cần auth
public async Task<ActionResult<ResultOf<EntityUser>>> RegisterPartner([FromBody] PartnerRegistrationDto dto)
{
    try
    {
        var result = await RegisterPartnerAsync(dto);
        
        if (!result.Success)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }
    catch (Exception ex)
    {
        _log.LogError($"{_ctx.Summary} - {ex.Message}");
        return StatusCode(500, ResultOf<EntityUser>.Error("Internal server error"));
    }
}
```

**Ràng buộc:**
- ✅ Sử dụng pattern `ResultOf<T>` như các methods khác
- ✅ `RegisterPartner` endpoint phải `[AllowAnonymous]`
- ✅ Validation đầy đủ trước khi tạo user
- ✅ Tất cả operations phải log

**Acceptance Criteria:**
- [ ] POST /api/User/RegisterPartner thành công với email mới
- [ ] POST /api/User/RegisterPartner fail với email đã tồn tại
- [ ] Partner Center được tạo cùng lúc
- [ ] User status = inactive

---

## 📚 TUẦN 3-4: COURSE & EXAM SYSTEM (Ngày 11-20)

### **Ngày 11-12: Course Management**

#### **Bước 11.1: Course Entity trong ModuleContentCore**

Tạo file `src/SLK.TryEdu.ModuleContentCore/Entities/EntityCourse.cs`:

```csharp
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SLK.TryEdu.Abstract;

namespace SLK.TryEdu.ModuleContentCore.Entities
{
    [Table("courses")]
    public class EntityCourse : EntityBase
    {
        [Required]
        [MaxLength(255)]
        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; }

        public bool IsFree { get; set; } = true;

        public int PriceCoins { get; set; } = 0;

        public int? CreatedBy { get; set; }

        // Navigation
        public virtual ICollection<EntityEnrollment> Enrollments { get; set; } = new List<EntityEnrollment>();
    }
}
```

#### **Bước 11.2: Course Service trong ModuleContent**

Tạo file `src/SLK.TryEdu.ModuleContent/Services/CourseService.cs`:

```csharp
using SLK.TryEdu.Base;
using SLK.TryEdu.ModuleContentCore.Entities;
using SLK.TryEdu.ModuleContentCore.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

namespace SLK.TryEdu.ModuleContent.Services
{
    public class CourseService : MyServiceBase, ICourseService
    {
        private readonly ILogger<CourseService> _logger;
        private readonly IWebHostEnvironment _env;

        public CourseService(
            IMyContext ctx,
            ILogger<CourseService> logger,
            IWebHostEnvironment env) : base(ctx)
        {
            _logger = logger;
            _env = env;
        }

        public async Task<ResultsOf<EntityCourse>> GetList(bool? isFree = null)
        {
            if (!_ctx.CheckPermission(PERMISSION.COURSE_VIEW))
                return ResultsOf<EntityCourse>.Error(_ctx.Text["You are not authorized!", "Bạn không có quyền!"]);

            try
            {
                var query = _ctx.Repo<EntityCourse>().Query();

                if (isFree.HasValue)
                {
                    query = query.Where(c => c.IsFree == isFree.Value);
                }

                var courses = await query.ToListAsync();
                return ResultsOf<EntityCourse>.Ok(courses);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{_ctx.Summary} - {ex.Message}");
                return ResultsOf<EntityCourse>.Error("Error getting courses");
            }
        }

        public async Task<ResultOf<EntityCourse>> Create(CreateCourseDto dto)
        {
            if (!_ctx.CheckPermission(PERMISSION.COURSE_CREATE))
                return ResultOf<EntityCourse>.Error(_ctx.Text["You are not authorized!", "Bạn không có quyền!"]);

            try
            {
                var course = new EntityCourse
                {
                    Title = dto.Title,
                    Description = dto.Description,
                    IsFree = dto.IsFree,
                    PriceCoins = dto.IsFree ? 0 : dto.PriceCoins,
                    CreatedBy = _ctx.UserId,
                    DateCreated = DateTime.UtcNow,
                    DateModified = DateTime.UtcNow,
                    UserCreated = _ctx.UserName ?? "System"
                };

                await _ctx.Repo<EntityCourse>().AddAsync(course);
                await _ctx.SaveChangesAsync();

                return ResultOf<EntityCourse>.Ok(course);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{_ctx.Summary} - {ex.Message}");
                return ResultOf<EntityCourse>.Error("Error creating course");
            }
        }
    }
}
```

Tạo file `src/SLK.TryEdu.ModuleContent/Controllers/CourseController.cs`:

```csharp
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using SLK.TryEdu.ModuleContentCore;
using SLK.TryEdu.ModuleContentCore.Entities;
using SLK.TryEdu.Base;

namespace SLK.TryEdu.ModuleContent.Controllers
{
    [Authorize]
    [Route("api/Course/[action]")]
    [ApiController]
    public class CourseController : CourseService, ICourseService
    {
        public CourseController(IMyContext ctx, ILogger<CourseService> log, IWebHostEnvironment env) 
            : base(ctx, log, env)
        {
        }
    }
}
```

**Ràng buộc:**
- ✅ Course miễn phí phải có `PriceCoins = 0`
- ✅ Chỉ Admin/Teacher mới tạo được course
- ✅ Student chỉ xem được courses
- ✅ Course phải có title và description

---

### **Ngày 13-14: Exam Management**

#### **Bước 13.1: Exam Entity trong ModuleContentCore**

Tạo file `src/SLK.TryEdu.ModuleContentCore/Entities/EntityExam.cs`:

```csharp
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SLK.TryEdu.Abstract;
using System.Text.Json;

namespace SLK.TryEdu.ModuleContentCore.Entities
{
    [Table("exams")]
    public class EntityExam : EntityBase
    {
        [Required]
        [MaxLength(255)]
        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; }

        [Required]
        public int PriceCoins { get; set; }

        [Required]
        public int Duration { get; set; } // seconds

        // JSONB column for flexible exam structure
        [Column(TypeName = "jsonb")]
        public string? ExamData { get; set; } // JSON cho sections, questions

        public int? CreatedBy { get; set; }

        // Helper property để serialize/deserialize ExamData
        [NotMapped]
        public ExamSections? Sections
        {
            get => string.IsNullOrEmpty(ExamData) 
                ? null 
                : JsonSerializer.Deserialize<ExamSections>(ExamData);
            set => ExamData = value == null 
                ? null 
                : JsonSerializer.Serialize(value);
        }
    }

    public class ExamSections
    {
        public List<ReadingQuestion> Reading { get; set; } = new();
        public List<ListeningQuestion> Listening { get; set; } = new();
        public WritingTask Writing { get; set; } = new();
        public SpeakingTask Speaking { get; set; } = new();
    }
}
```

#### **Bước 13.2: Exam Service trong ModuleContent**

Tạo file `src/SLK.TryEdu.ModuleContent/Services/ExamService.cs`:

```csharp
using SLK.TryEdu.Base;
using SLK.TryEdu.ModuleContentCore.Entities;
using SLK.TryEdu.ModuleContentCore.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

namespace SLK.TryEdu.ModuleContent.Services
{
    public class ExamService : MyServiceBase, IExamService
    {
        private readonly ILogger<ExamService> _logger;
        private readonly IWebHostEnvironment _env;

        public ExamService(
            IMyContext ctx,
            ILogger<ExamService> logger,
            IWebHostEnvironment env) : base(ctx)
        {
            _logger = logger;
            _env = env;
        }

        public async Task<ResultsOf<EntityExam>> GetList()
        {
            if (!_ctx.CheckPermission(PERMISSION.EXAM_VIEW))
                return ResultsOf<EntityExam>.Error(_ctx.Text["You are not authorized!", "Bạn không có quyền!"]);

            try
            {
                var exams = await _ctx.Repo<EntityExam>().Query().ToListAsync();
                return ResultsOf<EntityExam>.Ok(exams);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{_ctx.Summary} - {ex.Message}");
                return ResultsOf<EntityExam>.Error("Error getting exams");
            }
        }

        public async Task<ResultOf<EntityExam>> Create(CreateExamDto dto)
        {
            if (!_ctx.CheckPermission(PERMISSION.EXAM_CREATE))
                return ResultOf<EntityExam>.Error(_ctx.Text["You are not authorized!", "Bạn không có quyền!"]);

            try
            {
                var exam = new EntityExam
                {
                    Title = dto.Title,
                    Description = dto.Description,
                    PriceCoins = dto.PriceCoins,
                    Duration = dto.Duration,
                    Sections = dto.Sections,
                    CreatedBy = _ctx.UserId,
                    DateCreated = DateTime.UtcNow,
                    DateModified = DateTime.UtcNow,
                    UserCreated = _ctx.UserName ?? "System"
                };

                await _ctx.Repo<EntityExam>().AddAsync(exam);
                await _ctx.SaveChangesAsync();

                return ResultOf<EntityExam>.Ok(exam);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{_ctx.Summary} - {ex.Message}");
                return ResultOf<EntityExam>.Error("Error creating exam");
            }
        }

        public async Task<ResultOf<bool>> PurchaseExam(int examId, int? referralCodeId = null)
        {
            if (!_ctx.CheckPermission(PERMISSION.EXAM_PURCHASE))
                return ResultOf<bool>.Error(_ctx.Text["You are not authorized!", "Bạn không có quyền!"]);

            try
            {
                // TODO: Integrate with Coin Service
                // 1. Get exam
                // 2. Check coin balance
                // 3. Deduct coins (with referral discount if applicable)
                // 4. Create exam purchase record
                // 5. Calculate commission if referral code used

                return ResultOf<bool>.Ok(true);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{_ctx.Summary} - {ex.Message}");
                return ResultOf<bool>.Error("Error purchasing exam");
            }
        }
    }
}
```

**Ràng buộc:**
- ✅ Exam phải có price coins > 0
- ✅ Duration phải > 0
- ✅ ExamId phải unique và auto-increment
- ✅ Purchase phải check coin balance

---

## 💰 TUẦN 5-6: COIN & REFERRAL SYSTEM (Ngày 21-30)

### **Ngày 21-22: Coin Service Implementation**

#### **Bước 21.1: Coin Service trong ModuleCoin**

Tạo file `src/SLK.TryEdu.ModuleCoin/Services/CoinService.cs`:

```csharp
using SLK.TryEdu.Base;
using SLK.TryEdu.ModuleCoinCore.Entities;
using SLK.TryEdu.ModuleCoinCore.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

namespace SLK.TryEdu.ModuleCoin.Services
{
    public class CoinService : MyServiceBase, ICoinService
    {
        private readonly ILogger<CoinService> _logger;
        private readonly IWebHostEnvironment _env;

        public CoinService(
            IMyContext ctx,
            ILogger<CoinService> logger,
            IWebHostEnvironment env) : base(ctx)
        {
            _logger = logger;
            _env = env;
        }

        public async Task<ResultOf<EntityCoinTransaction>> PurchaseCoins(PurchaseCoinsDto dto)
        {
            if (!_ctx.CheckPermission(PERMISSION.COIN_PURCHASE))
                return ResultOf<EntityCoinTransaction>.Error(_ctx.Text["You are not authorized!", "Bạn không có quyền!"]);

            try
            {
                // Validate amount
                if (dto.Amount < 50000) // Minimum 50,000 VNĐ
                {
                    return ResultOf<EntityCoinTransaction>.Error("Minimum purchase amount is 50,000 VNĐ");
                }

                // Calculate coins (1 VNĐ = 1 Coin by default)
                var exchangeRate = 1.0m;
                var coinsReceived = (int)(dto.Amount * exchangeRate);

                // Apply referral discount if provided
                EntityReferralCode? referralCode = null;
                if (!string.IsNullOrEmpty(dto.ReferralCode))
                {
                    referralCode = await _ctx.Repo<EntityReferralCode>()
                        .Query(r => r.Code == dto.ReferralCode && r.IsActive)
                        .FirstOrDefaultAsync();

                    if (referralCode != null && 
                        (referralCode.ExpiryDate == null || referralCode.ExpiryDate > DateTime.UtcNow) &&
                        (referralCode.MaxUsage == -1 || referralCode.UsageCount < referralCode.MaxUsage))
                    {
                        // Apply discount
                        if (referralCode.DiscountPercentage > 0)
                        {
                            var discount = dto.Amount * (referralCode.DiscountPercentage / 100);
                            coinsReceived += (int)discount;
                        }
                        if (referralCode.DiscountCoins > 0)
                        {
                            coinsReceived += referralCode.DiscountCoins;
                        }
                    }
                }

                // Create transaction
                var transaction = new EntityCoinTransaction
                {
                    UserId = _ctx.UserId ?? 0,
                    Amount = dto.Amount,
                    CoinsReceived = coinsReceived,
                    ExchangeRate = exchangeRate,
                    PaymentMethod = dto.PaymentMethod,
                    ReferralCodeId = referralCode?.Id,
                    Status = "Pending",
                    DateCreated = DateTime.UtcNow,
                    DateModified = DateTime.UtcNow,
                    UserCreated = _ctx.UserName ?? "System"
                };

                await _ctx.Repo<EntityCoinTransaction>().AddAsync(transaction);
                await _ctx.SaveChangesAsync();

                // TODO: Process payment (integrate with payment gateway)
                // After payment success, update status to "Completed"
                // Update coin balance (có thể lưu trong MongoDB hoặc PostgreSQL)

                // Calculate commission if referral code used
                if (referralCode != null)
                {
                    await CalculateCommissionAsync(transaction, referralCode);
                }

                return ResultOf<EntityCoinTransaction>.Ok(transaction);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{_ctx.Summary} - {ex.Message}");
                return ResultOf<EntityCoinTransaction>.Error("Error purchasing coins");
            }
        }

        private async Task CalculateCommissionAsync(EntityCoinTransaction transaction, EntityReferralCode referralCode)
        {
            var partnerCenter = await _ctx.Repo<EntityPartnerCenter>()
                .Query(p => p.Id == referralCode.PartnerCenterId)
                .FirstOrDefaultAsync();

            if (partnerCenter == null) return;

            // Get commission rate based on tier
            var commissionRate = GetCommissionRateByTier(partnerCenter.Tier);
            var commissionAmount = transaction.Amount * (commissionRate / 100);

            var commission = new EntityCommissionTransaction
            {
                PartnerCenterId = partnerCenter.Id,
                UserId = transaction.UserId,
                ReferralCodeId = referralCode.Id,
                TransactionAmount = transaction.Amount,
                CommissionAmount = commissionAmount,
                CommissionRate = commissionRate,
                TransactionType = "CoinPurchase",
                Status = "Pending",
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow,
                UserCreated = "System"
            };

            await _ctx.Repo<EntityCommissionTransaction>().AddAsync(commission);
            await _ctx.SaveChangesAsync();

            // Update referral code usage count
            referralCode.UsageCount++;
            referralCode.DateModified = DateTime.UtcNow;
            await _ctx.SaveChangesAsync();
        }

        private decimal GetCommissionRateByTier(string tier)
        {
            return tier switch
            {
                "Bronze" => 3.00m,
                "Silver" => 5.00m,
                "Gold" => 7.00m,
                "Platinum" => 10.00m,
                _ => 3.00m
            };
        }
    }
}
```

**Ràng buộc:**
- ✅ Coin transaction phải atomic (dùng transaction)
- ✅ Referral code validation phải real-time
- ✅ Commission calculation phải chính xác theo tier
- ✅ Tất cả transactions phải log
- ✅ Minimum purchase: 50,000 VNĐ

---

### **Ngày 23-24: Referral Code System**

#### **Bước 23.1: Referral Code Service trong ModuleCoin**

Tạo file `src/SLK.TryEdu.ModuleCoin/Services/ReferralCodeService.cs`:

```csharp
using SLK.TryEdu.Base;
using SLK.TryEdu.ModuleCoinCore.Entities;
using SLK.TryEdu.ModuleCoinCore.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

namespace SLK.TryEdu.ModuleCoin.Services
{
    public class ReferralCodeService : MyServiceBase, IReferralCodeService
    {
        private readonly ILogger<ReferralCodeService> _logger;
        private readonly IWebHostEnvironment _env;

        public ReferralCodeService(
            IMyContext ctx,
            ILogger<ReferralCodeService> logger,
            IWebHostEnvironment env) : base(ctx)
        {
            _logger = logger;
            _env = env;
        }

        public async Task<ResultOf<EntityReferralCode>> Create(CreateReferralCodeDto dto)
        {
            if (!_ctx.CheckPermission(PERMISSION.REFERRAL_CODE_CREATE))
                return ResultOf<EntityReferralCode>.Error(_ctx.Text["You are not authorized!", "Bạn không có quyền!"]);

            try
            {
                // Get partner center for current user
                var partnerCenter = await _ctx.Repo<EntityPartnerCenter>()
                    .Query(p => p.Email == _ctx.UserEmail)
                    .FirstOrDefaultAsync();

                if (partnerCenter == null || partnerCenter.Status != "Active")
                {
                    return ResultOf<EntityReferralCode>.Error("Partner center not found or not active");
                }

                // Check if code already exists
                var existingCode = await _ctx.Repo<EntityReferralCode>()
                    .Query(r => r.Code == dto.Code)
                    .FirstOrDefaultAsync();

                if (existingCode != null)
                {
                    return ResultOf<EntityReferralCode>.Error("Referral code already exists");
                }

                // Generate code if not provided
                var code = string.IsNullOrEmpty(dto.Code) 
                    ? GenerateUniqueCode() 
                    : dto.Code.ToUpper();

                var referralCode = new EntityReferralCode
                {
                    PartnerCenterId = partnerCenter.Id,
                    Code = code,
                    DiscountPercentage = dto.DiscountPercentage ?? 10.00m,
                    DiscountCoins = dto.DiscountCoins ?? 0,
                    IsActive = true,
                    ExpiryDate = dto.ExpiryDate,
                    MaxUsage = dto.MaxUsage ?? -1,
                    UsageCount = 0,
                    DateCreated = DateTime.UtcNow,
                    DateModified = DateTime.UtcNow,
                    UserCreated = _ctx.UserName ?? "System"
                };

                await _ctx.Repo<EntityReferralCode>().AddAsync(referralCode);
                await _ctx.SaveChangesAsync();

                return ResultOf<EntityReferralCode>.Ok(referralCode);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{_ctx.Summary} - {ex.Message}");
                return ResultOf<EntityReferralCode>.Error("Error creating referral code");
            }
        }

        public async Task<ResultsOf<EntityReferralCode>> GetList(int? partnerCenterId = null)
        {
            if (!_ctx.CheckPermission(PERMISSION.REFERRAL_CODE_VIEW))
                return ResultsOf<EntityReferralCode>.Error(_ctx.Text["You are not authorized!", "Bạn không có quyền!"]);

            try
            {
                var query = _ctx.Repo<EntityReferralCode>().Query();

                if (partnerCenterId.HasValue)
                {
                    query = query.Where(r => r.PartnerCenterId == partnerCenterId.Value);
                }
                else if (!_ctx.IsAdmin)
                {
                    // Partner chỉ xem được codes của mình
                    var partnerCenter = await _ctx.Repo<EntityPartnerCenter>()
                        .Query(p => p.Email == _ctx.UserEmail)
                        .FirstOrDefaultAsync();
                    
                    if (partnerCenter != null)
                    {
                        query = query.Where(r => r.PartnerCenterId == partnerCenter.Id);
                    }
                }

                var codes = await query
                    .Include(r => r.PartnerCenter)
                    .OrderByDescending(r => r.DateCreated)
                    .ToListAsync();

                return ResultsOf<EntityReferralCode>.Ok(codes);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{_ctx.Summary} - {ex.Message}");
                return ResultsOf<EntityReferralCode>.Error("Error getting referral codes");
            }
        }

        public async Task<ResultOf<EntityReferralCode>> ValidateCode(string code)
        {
            try
            {
                var referralCode = await _ctx.Repo<EntityReferralCode>()
                    .Query(r => r.Code == code.ToUpper() && r.IsActive)
                    .Include(r => r.PartnerCenter)
                    .FirstOrDefaultAsync();

                if (referralCode == null)
                {
                    return ResultOf<EntityReferralCode>.Error("Referral code not found");
                }

                // Check expiry
                if (referralCode.ExpiryDate.HasValue && referralCode.ExpiryDate < DateTime.UtcNow)
                {
                    return ResultOf<EntityReferralCode>.Error("Referral code has expired");
                }

                // Check max usage
                if (referralCode.MaxUsage != -1 && referralCode.UsageCount >= referralCode.MaxUsage)
                {
                    return ResultOf<EntityReferralCode>.Error("Referral code has reached maximum usage");
                }

                // Check partner center status
                if (referralCode.PartnerCenter.Status != "Active")
                {
                    return ResultOf<EntityReferralCode>.Error("Partner center is not active");
                }

                return ResultOf<EntityReferralCode>.Ok(referralCode);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{_ctx.Summary} - {ex.Message}");
                return ResultOf<EntityReferralCode>.Error("Error validating referral code");
            }
        }

        private string GenerateUniqueCode()
        {
            var random = new Random();
            var code = "";
            bool isUnique = false;

            while (!isUnique)
            {
                code = $"REF{random.Next(100000, 999999)}";
                var exists = _ctx.Repo<EntityReferralCode>()
                    .Query(r => r.Code == code)
                    .Any();
                isUnique = !exists;
            }

            return code;
        }
    }
}
```

**Ràng buộc:**
- ✅ Code phải unique
- ✅ Validate expiry date
- ✅ Validate max usage
- ✅ Increment usage count atomically
- ✅ Partner chỉ tạo được code cho center của mình
- ✅ Auto-generate code nếu không provided

---

### **Ngày 25-26: Commission Calculation & Balance Management**

#### **Bước 25.1: Commission Service trong ModuleCoin**

Tạo file `src/SLK.TryEdu.ModuleCoin/Services/CommissionService.cs`:

```csharp
using SLK.TryEdu.Base;
using SLK.TryEdu.ModuleCoinCore.Entities;
using SLK.TryEdu.ModuleCoinCore.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

namespace SLK.TryEdu.ModuleCoin.Services
{
    public class CommissionService : MyServiceBase, ICommissionService
    {
        private readonly ILogger<CommissionService> _logger;
        private readonly IWebHostEnvironment _env;

        public CommissionService(
            IMyContext ctx,
            ILogger<CommissionService> logger,
            IWebHostEnvironment env) : base(ctx)
        {
            _logger = logger;
            _env = env;
        }

        public async Task<ResultsOf<EntityCommissionTransaction>> GetCommissions(int? partnerCenterId = null, DateTime? fromDate = null, DateTime? toDate = null)
        {
            if (!_ctx.CheckPermission(PERMISSION.COMMISSION_VIEW))
                return ResultsOf<EntityCommissionTransaction>.Error(_ctx.Text["You are not authorized!", "Bạn không có quyền!"]);

            try
            {
                var query = _ctx.Repo<EntityCommissionTransaction>().Query();

                if (partnerCenterId.HasValue)
                {
                    query = query.Where(c => c.PartnerCenterId == partnerCenterId.Value);
                }
                else if (!_ctx.IsAdmin)
                {
                    // Partner chỉ xem được commissions của mình
                    var partnerCenter = await _ctx.Repo<EntityPartnerCenter>()
                        .Query(p => p.Email == _ctx.UserEmail)
                        .FirstOrDefaultAsync();
                    
                    if (partnerCenter != null)
                    {
                        query = query.Where(c => c.PartnerCenterId == partnerCenter.Id);
                    }
                }

                if (fromDate.HasValue)
                {
                    query = query.Where(c => c.DateCreated >= fromDate.Value);
                }

                if (toDate.HasValue)
                {
                    query = query.Where(c => c.DateCreated <= toDate.Value);
                }

                var commissions = await query
                    .Include(c => c.PartnerCenter)
                    .Include(c => c.ReferralCode)
                    .OrderByDescending(c => c.DateCreated)
                    .ToListAsync();

                return ResultsOf<EntityCommissionTransaction>.Ok(commissions);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{_ctx.Summary} - {ex.Message}");
                return ResultsOf<EntityCommissionTransaction>.Error("Error getting commissions");
            }
        }

        public async Task<ResultOf<CommissionSummaryDto>> GetSummary(int? partnerCenterId = null, DateTime? fromDate = null, DateTime? toDate = null)
        {
            if (!_ctx.CheckPermission(PERMISSION.COMMISSION_VIEW))
                return ResultOf<CommissionSummaryDto>.Error(_ctx.Text["You are not authorized!", "Bạn không có quyền!"]);

            try
            {
                var query = _ctx.Repo<EntityCommissionTransaction>()
                    .Query(c => c.Status == "Paid");

                if (partnerCenterId.HasValue)
                {
                    query = query.Where(c => c.PartnerCenterId == partnerCenterId.Value);
                }

                if (fromDate.HasValue)
                {
                    query = query.Where(c => c.DateCreated >= fromDate.Value);
                }

                if (toDate.HasValue)
                {
                    query = query.Where(c => c.DateCreated <= toDate.Value);
                }

                var totalCommission = await query.SumAsync(c => c.CommissionAmount);
                var totalTransactions = await query.CountAsync();
                var pendingCommission = await _ctx.Repo<EntityCommissionTransaction>()
                    .Query(c => c.Status == "Pending" && 
                                (partnerCenterId == null || c.PartnerCenterId == partnerCenterId))
                    .SumAsync(c => c.CommissionAmount);

                var summary = new CommissionSummaryDto
                {
                    TotalCommission = totalCommission,
                    TotalTransactions = totalTransactions,
                    PendingCommission = pendingCommission,
                    PaidCommission = totalCommission
                };

                return ResultOf<CommissionSummaryDto>.Ok(summary);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{_ctx.Summary} - {ex.Message}");
                return ResultOf<CommissionSummaryDto>.Error("Error getting commission summary");
            }
        }

        public async Task<ResultOf<bool>> PayCommission(int commissionId)
        {
            if (!_ctx.CheckPermission(PERMISSION.COMMISSION_PAY))
                return ResultOf<bool>.Error(_ctx.Text["You are not authorized!", "Bạn không có quyền!"]);

            try
            {
                var commission = await _ctx.Repo<EntityCommissionTransaction>()
                    .Query(c => c.Id == commissionId)
                    .FirstOrDefaultAsync();

                if (commission == null)
                {
                    return ResultOf<bool>.Error("Commission not found");
                }

                if (commission.Status != "Pending")
                {
                    return ResultOf<bool>.Error("Commission is not pending");
                }

                commission.Status = "Paid";
                commission.DateModified = DateTime.UtcNow;
                commission.UserModified = _ctx.UserName ?? "System";

                await _ctx.SaveChangesAsync();

                // TODO: Send notification to partner
                // TODO: Update partner center balance

                return ResultOf<bool>.Ok(true);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{_ctx.Summary} - {ex.Message}");
                return ResultOf<bool>.Error("Error paying commission");
            }
        }
    }
}
```

#### **Bước 25.2: Coin Balance Service**

Tạo file `src/SLK.TryEdu.ModuleCoin/Services/CoinBalanceService.cs`:

```csharp
using SLK.TryEdu.Base;
using SLK.TryEdu.ModuleCoinCore.Entities;
using SLK.TryEdu.ModuleCoinCore.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

namespace SLK.TryEdu.ModuleCoin.Services
{
    public class CoinBalanceService : MyServiceBase, ICoinBalanceService
    {
        private readonly ILogger<CoinBalanceService> _logger;

        public CoinBalanceService(
            IMyContext ctx,
            ILogger<CoinBalanceService> logger) : base(ctx)
        {
            _logger = logger;
        }

        public async Task<ResultOf<CoinBalanceDto>> GetBalance(int userId)
        {
            if (!_ctx.CheckPermission(PERMISSION.COIN_VIEW))
                return ResultOf<CoinBalanceDto>.Error(_ctx.Text["You are not authorized!", "Bạn không có quyền!"]);

            try
            {
                // User chỉ xem được balance của mình (trừ Admin)
                if (userId != _ctx.UserId && !_ctx.IsAdmin)
                {
                    return ResultOf<CoinBalanceDto>.Error("Unauthorized");
                }

                // Calculate balance from transactions
                var totalCoins = await _ctx.Repo<EntityCoinTransaction>()
                    .Query(t => t.UserId == userId && t.Status == "Completed")
                    .SumAsync(t => t.CoinsReceived);

                var usedCoins = await _ctx.Repo<EntityCoinTransaction>()
                    .Query(t => t.UserId == userId && t.Status == "Completed" && t.Amount < 0)
                    .SumAsync(t => Math.Abs(t.CoinsReceived));

                var balance = new CoinBalanceDto
                {
                    UserId = userId,
                    AvailableCoins = totalCoins - usedCoins,
                    TotalCoins = totalCoins,
                    UsedCoins = usedCoins
                };

                return ResultOf<CoinBalanceDto>.Ok(balance);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{_ctx.Summary} - {ex.Message}");
                return ResultOf<CoinBalanceDto>.Error("Error getting coin balance");
            }
        }

        public async Task<ResultOf<bool>> DeductCoins(int userId, int coins, string reason)
        {
            if (!_ctx.CheckPermission(PERMISSION.COIN_DEDUCT))
                return ResultOf<bool>.Error(_ctx.Text["You are not authorized!", "Bạn không có quyền!"]);

            try
            {
                // Get current balance
                var balanceResult = await GetBalance(userId);
                if (!balanceResult.Success || balanceResult.Data == null)
                {
                    return ResultOf<bool>.Error("Cannot get balance");
                }

                if (balanceResult.Data.AvailableCoins < coins)
                {
                    return ResultOf<bool>.Error("Insufficient coin balance");
                }

                // Create deduction transaction
                var transaction = new EntityCoinTransaction
                {
                    UserId = userId,
                    Amount = -coins, // Negative for deduction
                    CoinsReceived = -coins,
                    ExchangeRate = 1.0m,
                    Status = "Completed",
                    TransactionId = $"DEDUCT_{Guid.NewGuid()}",
                    DateCreated = DateTime.UtcNow,
                    DateModified = DateTime.UtcNow,
                    UserCreated = _ctx.UserName ?? "System"
                };

                await _ctx.Repo<EntityCoinTransaction>().AddAsync(transaction);
                await _ctx.SaveChangesAsync();

                return ResultOf<bool>.Ok(true);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{_ctx.Summary} - {ex.Message}");
                return ResultOf<bool>.Error("Error deducting coins");
            }
        }
    }
}
```

**Ràng buộc:**
- ✅ Commission rate theo tier:
  - Bronze: 3%
  - Silver: 5%
  - Gold: 7%
  - Platinum: 10%
- ✅ Minimum commission: 10K VNĐ
- ✅ Maximum commission: 1M VNĐ
- ✅ Commission phải tính ngay sau transaction
- ✅ Balance được tính từ transactions
- ✅ Deduct coins phải check balance trước

---

## 🏢 TUẦN 7-8: PARTNER PORTAL (Ngày 31-40)

### **Ngày 31-32: Partner Service & Controller**

#### **Bước 31.1: Partner Service trong ModulePartner**

Tạo file `src/SLK.TryEdu.ModulePartner/Services/PartnerService.cs`:

```csharp
using SLK.TryEdu.Base;
using SLK.TryEdu.ModuleCoinCore.Entities;
using SLK.TryEdu.ModulePartnerCore.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

namespace SLK.TryEdu.ModulePartner.Services
{
    public class PartnerService : MyServiceBase, IPartnerService
    {
        private readonly ILogger<PartnerService> _logger;
        private readonly IWebHostEnvironment _env;

        public PartnerService(
            IMyContext ctx,
            ILogger<PartnerService> logger,
            IWebHostEnvironment env) : base(ctx)
        {
            _logger = logger;
            _env = env;
        }

        public async Task<ResultOf<EntityPartnerCenter>> GetPartnerCenter(int? partnerCenterId = null)
        {
            if (!_ctx.CheckPermission(PERMISSION.PARTNER_VIEW))
                return ResultOf<EntityPartnerCenter>.Error(_ctx.Text["You are not authorized!", "Bạn không có quyền!"]);

            try
            {
                var id = partnerCenterId ?? await GetPartnerCenterIdByUser();

                if (id == null)
                {
                    return ResultOf<EntityPartnerCenter>.Error("Partner center not found");
                }

                var partnerCenter = await _ctx.Repo<EntityPartnerCenter>()
                    .Query(p => p.Id == id.Value)
                    .Include(p => p.ReferralCodes)
                    .Include(p => p.CommissionTransactions)
                    .FirstOrDefaultAsync();

                if (partnerCenter == null)
                {
                    return ResultOf<EntityPartnerCenter>.Error("Partner center not found");
                }

                return ResultOf<EntityPartnerCenter>.Ok(partnerCenter);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{_ctx.Summary} - {ex.Message}");
                return ResultOf<EntityPartnerCenter>.Error("Error getting partner center");
            }
        }

        public async Task<ResultOf<PartnerDashboardDto>> GetDashboard(int? partnerCenterId = null)
        {
            if (!_ctx.CheckPermission(PERMISSION.PARTNER_VIEW))
                return ResultOf<PartnerDashboardDto>.Error(_ctx.Text["You are not authorized!", "Bạn không có quyền!"]);

            try
            {
                var id = partnerCenterId ?? await GetPartnerCenterIdByUser();

                if (id == null)
                {
                    return ResultOf<PartnerDashboardDto>.Error("Partner center not found");
                }

                // Get KPIs
                var totalReferralCodes = await _ctx.Repo<EntityReferralCode>()
                    .Query(r => r.PartnerCenterId == id.Value)
                    .CountAsync();

                var activeReferralCodes = await _ctx.Repo<EntityReferralCode>()
                    .Query(r => r.PartnerCenterId == id.Value && r.IsActive)
                    .CountAsync();

                var totalUsage = await _ctx.Repo<EntityReferralCode>()
                    .Query(r => r.PartnerCenterId == id.Value)
                    .SumAsync(r => r.UsageCount);

                var totalCommission = await _ctx.Repo<EntityCommissionTransaction>()
                    .Query(c => c.PartnerCenterId == id.Value && c.Status == "Paid")
                    .SumAsync(c => c.CommissionAmount);

                var pendingCommission = await _ctx.Repo<EntityCommissionTransaction>()
                    .Query(c => c.PartnerCenterId == id.Value && c.Status == "Pending")
                    .SumAsync(c => c.CommissionAmount);

                var dashboard = new PartnerDashboardDto
                {
                    PartnerCenterId = id.Value,
                    TotalReferralCodes = totalReferralCodes,
                    ActiveReferralCodes = activeReferralCodes,
                    TotalUsage = totalUsage,
                    TotalCommission = totalCommission,
                    PendingCommission = pendingCommission
                };

                return ResultOf<PartnerDashboardDto>.Ok(dashboard);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{_ctx.Summary} - {ex.Message}");
                return ResultOf<PartnerDashboardDto>.Error("Error getting dashboard");
            }
        }

        public async Task<ResultOf<EntityPartnerCenter>> ApprovePartner(int partnerCenterId)
        {
            if (!_ctx.CheckPermission(PERMISSION.PARTNER_APPROVE))
                return ResultOf<EntityPartnerCenter>.Error(_ctx.Text["You are not authorized!", "Bạn không có quyền!"]);

            try
            {
                var partnerCenter = await _ctx.Repo<EntityPartnerCenter>()
                    .Query(p => p.Id == partnerCenterId)
                    .FirstOrDefaultAsync();

                if (partnerCenter == null)
                {
                    return ResultOf<EntityPartnerCenter>.Error("Partner center not found");
                }

                partnerCenter.Status = "Active";
                partnerCenter.DateModified = DateTime.UtcNow;
                partnerCenter.UserModified = _ctx.UserName ?? "System";

                await _ctx.SaveChangesAsync();

                // TODO: Send notification email to partner
                // TODO: Activate user account

                return ResultOf<EntityPartnerCenter>.Ok(partnerCenter);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{_ctx.Summary} - {ex.Message}");
                return ResultOf<EntityPartnerCenter>.Error("Error approving partner");
            }
        }

        public async Task<ResultOf<EntityPartnerCenter>> RejectPartner(int partnerCenterId, string reason)
        {
            if (!_ctx.CheckPermission(PERMISSION.PARTNER_APPROVE))
                return ResultOf<EntityPartnerCenter>.Error(_ctx.Text["You are not authorized!", "Bạn không có quyền!"]);

            try
            {
                var partnerCenter = await _ctx.Repo<EntityPartnerCenter>()
                    .Query(p => p.Id == partnerCenterId)
                    .FirstOrDefaultAsync();

                if (partnerCenter == null)
                {
                    return ResultOf<EntityPartnerCenter>.Error("Partner center not found");
                }

                partnerCenter.Status = "Rejected";
                partnerCenter.DateModified = DateTime.UtcNow;
                partnerCenter.UserModified = _ctx.UserName ?? "System";

                await _ctx.SaveChangesAsync();

                // TODO: Send rejection email with reason

                return ResultOf<EntityPartnerCenter>.Ok(partnerCenter);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{_ctx.Summary} - {ex.Message}");
                return ResultOf<EntityPartnerCenter>.Error("Error rejecting partner");
            }
        }

        private async Task<int?> GetPartnerCenterIdByUser()
        {
            var partnerCenter = await _ctx.Repo<EntityPartnerCenter>()
                .Query(p => p.Email == _ctx.UserEmail)
                .FirstOrDefaultAsync();

            return partnerCenter?.Id;
        }
    }
}
```

Tạo file `src/SLK.TryEdu.ModulePartner/Controllers/PartnerController.cs`:

```csharp
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using SLK.TryEdu.ModulePartnerCore;
using SLK.TryEdu.ModuleCoinCore.Entities;
using SLK.TryEdu.Base;
using Microsoft.AspNetCore.Hosting;

namespace SLK.TryEdu.ModulePartner.Controllers
{
    [Authorize]
    [Route("api/Partner/[action]")]
    [ApiController]
    public class PartnerController : PartnerService, IPartnerService
    {
        public PartnerController(IMyContext ctx, ILogger<PartnerService> log, IWebHostEnvironment env) 
            : base(ctx, log, env)
        {
        }
    }
}
```

**Ràng buộc:**
- ✅ Form validation đầy đủ
- ✅ File upload: giấy phép max 5MB, logo max 2MB
- ✅ Email notification sau khi submit
- ✅ Status: Pending → Approved/Rejected
- ✅ Partner chỉ xem được data của mình
- ✅ Admin mới approve/reject được

---

### **Ngày 33-34: Partner Dashboard Blazor Components**

#### **Bước 33.1: Dashboard Component**

Tạo file `src/SLK.TryEdu.ModulePartnerBlazor/Pages/Dashboard.razor`:

```razor
@page "/partner/dashboard"
@using SLK.TryEdu.ModulePartnerCore.Models
@using SLK.TryEdu.Abstract
@inject IMyContext Context
@inject RestEase.IReferralCodeApi ReferralCodeApi
@inject RestEase.IPartnerApi PartnerApi

<PageTitle>Partner Dashboard</PageTitle>

<MudContainer MaxWidth="MaxWidth.ExtraLarge" Class="mt-4">
    <MudGrid>
        <MudItem xs="12">
            <MudText Typo="Typo.h4" Class="mb-4">Partner Dashboard</MudText>
        </MudItem>

        <!-- KPI Cards -->
        <MudItem xs="12" sm="6" md="3">
            <MudCard>
                <MudCardContent>
                    <MudText Typo="Typo.h6">Total Referral Codes</MudText>
                    <MudText Typo="Typo.h4" Class="mt-2">@dashboard?.TotalReferralCodes</MudText>
                </MudCardContent>
            </MudCard>
        </MudItem>

        <MudItem xs="12" sm="6" md="3">
            <MudCard>
                <MudCardContent>
                    <MudText Typo="Typo.h6">Active Codes</MudText>
                    <MudText Typo="Typo.h4" Class="mt-2">@dashboard?.ActiveReferralCodes</MudText>
                </MudCardContent>
            </MudCard>
        </MudItem>

        <MudItem xs="12" sm="6" md="3">
            <MudCard>
                <MudCardContent>
                    <MudText Typo="Typo.h6">Total Usage</MudText>
                    <MudText Typo="Typo.h4" Class="mt-2">@dashboard?.TotalUsage</MudText>
                </MudCardContent>
            </MudCard>
        </MudItem>

        <MudItem xs="12" sm="6" md="3">
            <MudCard>
                <MudCardContent>
                    <MudText Typo="Typo.h6">Total Commission</MudText>
                    <MudText Typo="Typo.h4" Class="mt-2">@FormatCurrency(dashboard?.TotalCommission ?? 0)</MudText>
                </MudCardContent>
            </MudCard>
        </MudItem>

        <!-- Referral Codes List -->
        <MudItem xs="12" Class="mt-4">
            <MudCard>
                <MudCardContent>
                    <MudText Typo="Typo.h6" Class="mb-3">Recent Referral Codes</MudText>
                    <MudTable Items="@referralCodes" Hover="true" Dense="true">
                        <HeaderContent>
                            <MudTh>Code</MudTh>
                            <MudTh>Discount</MudTh>
                            <MudTh>Usage</MudTh>
                            <MudTh>Status</MudTh>
                            <MudTh>Actions</MudTh>
                        </HeaderContent>
                        <RowTemplate>
                            <MudTd DataLabel="Code">@context.Code</MudTd>
                            <MudTd DataLabel="Discount">@context.DiscountPercentage%</MudTd>
                            <MudTd DataLabel="Usage">@context.UsageCount / @(context.MaxUsage == -1 ? "∞" : context.MaxUsage.ToString())</MudTd>
                            <MudTd DataLabel="Status">
                                <MudChip Size="Size.Small" Color="@(context.IsActive ? Color.Success : Color.Default)">
                                    @(context.IsActive ? "Active" : "Inactive")
                                </MudChip>
                            </MudTd>
                            <MudTd DataLabel="Actions">
                                <MudButton Variant="Variant.Text" Size="Size.Small" OnClick="@(() => CopyToClipboard(context.Code))">
                                    Copy
                                </MudButton>
                            </MudTd>
                        </RowTemplate>
                    </MudTable>
                </MudCardContent>
            </MudCard>
        </MudItem>
    </MudGrid>
</MudContainer>

@code {
    private PartnerDashboardDto? dashboard;
    private List<ReferralCodeDto> referralCodes = new();

    protected override async Task OnInitializedAsync()
    {
        await LoadDashboard();
        await LoadReferralCodes();
    }

    private async Task LoadDashboard()
    {
        var result = await PartnerApi.GetDashboard();
        if (result.Success && result.Data != null)
        {
            dashboard = result.Data;
        }
    }

    private async Task LoadReferralCodes()
    {
        var result = await ReferralCodeApi.GetList();
        if (result.Success && result.Data != null)
        {
            referralCodes = result.Data.Take(10).ToList();
        }
    }

    private string FormatCurrency(decimal amount)
    {
        return amount.ToString("N0") + " VNĐ";
    }

    private async Task CopyToClipboard(string code)
    {
        // TODO: Implement copy to clipboard
        await Task.CompletedTask;
    }
}
```

**Ràng buộc:**
- ✅ KPIs phải real-time
- ✅ Data phải aggregate từ database
- ✅ Response time < 3 seconds
- ✅ Có pagination cho lists
- ✅ Mobile responsive
- ✅ Copy to clipboard functionality

---

### **Ngày 35-36: Referral Code Management UI**

#### **Bước 35.1: Referral Code Management Component**

Tạo file `src/SLK.TryEdu.ModulePartnerBlazor/Pages/ReferralCodes.razor`:

```razor
@page "/partner/referral-codes"
@using SLK.TryEdu.ModuleCoinCore.Models
@inject RestEase.IReferralCodeApi ReferralCodeApi

<PageTitle>Manage Referral Codes</PageTitle>

<MudContainer MaxWidth="MaxWidth.ExtraLarge" Class="mt-4">
    <MudGrid>
        <MudItem xs="12">
            <MudText Typo="Typo.h4" Class="mb-4">Referral Codes</MudText>
            <MudButton Variant="Variant.Filled" Color="Color.Primary" OnClick="OpenCreateDialog">
                Create New Code
            </MudButton>
        </MudItem>

        <MudItem xs="12" Class="mt-4">
            <MudCard>
                <MudCardContent>
                    <MudTable Items="@referralCodes" Hover="true" Dense="true">
                        <HeaderContent>
                            <MudTh>Code</MudTh>
                            <MudTh>Discount %</MudTh>
                            <MudTh>Discount Coins</MudTh>
                            <MudTh>Usage</MudTh>
                            <MudTh>Expiry Date</MudTh>
                            <MudTh>Status</MudTh>
                            <MudTh>Actions</MudTh>
                        </HeaderContent>
                        <RowTemplate>
                            <MudTd DataLabel="Code">@context.Code</MudTd>
                            <MudTd DataLabel="Discount %">@context.DiscountPercentage%</MudTd>
                            <MudTd DataLabel="Discount Coins">@context.DiscountCoins</MudTd>
                            <MudTd DataLabel="Usage">@context.UsageCount / @(context.MaxUsage == -1 ? "∞" : context.MaxUsage.ToString())</MudTd>
                            <MudTd DataLabel="Expiry Date">@(context.ExpiryDate?.ToString("dd/MM/yyyy") ?? "No expiry")</MudTd>
                            <MudTd DataLabel="Status">
                                <MudChip Size="Size.Small" Color="@(context.IsActive ? Color.Success : Color.Default)">
                                    @(context.IsActive ? "Active" : "Inactive")
                                </MudChip>
                            </MudTd>
                            <MudTd DataLabel="Actions">
                                <MudButton Variant="Variant.Text" Size="Size.Small" OnClick="@(() => CopyToClipboard(context.Code))">
                                    Copy
                                </MudButton>
                                <MudButton Variant="Variant.Text" Size="Size.Small" OnClick="@(() => ToggleActive(context))">
                                    @(context.IsActive ? "Deactivate" : "Activate")
                                </MudButton>
                            </MudTd>
                        </RowTemplate>
                    </MudTable>
                </MudCardContent>
            </MudCard>
        </MudItem>
    </MudGrid>
</MudContainer>

<!-- Create Dialog -->
<MudDialog @bind-IsVisible="showCreateDialog" Options="dialogOptions">
    <TitleContent>
        <MudText Typo="Typo.h6">Create Referral Code</MudText>
    </TitleContent>
    <DialogContent>
        <MudTextField @bind-Value="newCode.Code" Label="Code (leave empty to auto-generate)" />
        <MudNumericField @bind-Value="newCode.DiscountPercentage" Label="Discount Percentage" Min="0" Max="100" />
        <MudNumericField @bind-Value="newCode.DiscountCoins" Label="Discount Coins" Min="0" />
        <MudDatePicker @bind-Date="newCode.ExpiryDate" Label="Expiry Date (optional)" />
        <MudNumericField @bind-Value="newCode.MaxUsage" Label="Max Usage (-1 for unlimited)" Min="-1" />
    </DialogContent>
    <DialogActions>
        <MudButton OnClick="CloseCreateDialog">Cancel</MudButton>
        <MudButton Color="Color.Primary" Variant="Variant.Filled" OnClick="CreateCode">Create</MudButton>
    </DialogActions>
</MudDialog>

@code {
    private List<ReferralCodeDto> referralCodes = new();
    private bool showCreateDialog = false;
    private CreateReferralCodeDto newCode = new();
    private DialogOptions dialogOptions = new() { MaxWidth = MaxWidth.Small, FullWidth = true };

    protected override async Task OnInitializedAsync()
    {
        await LoadReferralCodes();
    }

    private async Task LoadReferralCodes()
    {
        var result = await ReferralCodeApi.GetList();
        if (result.Success && result.Data != null)
        {
            referralCodes = result.Data;
        }
    }

    private void OpenCreateDialog()
    {
        newCode = new CreateReferralCodeDto();
        showCreateDialog = true;
    }

    private void CloseCreateDialog()
    {
        showCreateDialog = false;
    }

    private async Task CreateCode()
    {
        var result = await ReferralCodeApi.Create(newCode);
        if (result.Success)
        {
            showCreateDialog = false;
            await LoadReferralCodes();
        }
    }

    private async Task CopyToClipboard(string code)
    {
        // TODO: Implement copy to clipboard
        await Task.CompletedTask;
    }

    private async Task ToggleActive(ReferralCodeDto code)
    {
        // TODO: Implement toggle active
        await Task.CompletedTask;
    }
}
```

**Ràng buộc:**
- ✅ Form validation client-side
- ✅ Real-time code validation
- ✅ Copy to clipboard functionality
- ✅ Mobile responsive
- ✅ Auto-generate code nếu không provided

---

## 🧪 TUẦN 9-10: INTEGRATION & TESTING (Ngày 41-50)

### **Ngày 41-42: Integration & End-to-End Testing**

#### **Bước 41.1: Integrate Coin Service với Exam Purchase**

Cập nhật `src/SLK.TryEdu.ModuleContent/Services/ExamService.cs`:

```csharp
public async Task<ResultOf<bool>> PurchaseExam(int examId, int? referralCodeId = null)
{
    if (!_ctx.CheckPermission(PERMISSION.EXAM_PURCHASE))
        return ResultOf<bool>.Error(_ctx.Text["You are not authorized!", "Bạn không có quyền!"]);

    try
    {
        // 1. Get exam
        var exam = await _ctx.Repo<EntityExam>()
            .Query(e => e.Id == examId)
            .FirstOrDefaultAsync();

        if (exam == null)
        {
            return ResultOf<bool>.Error("Exam not found");
        }

        // 2. Check coin balance
        var coinBalanceService = new CoinBalanceService(_ctx, _logger);
        var balanceResult = await coinBalanceService.GetBalance(_ctx.UserId ?? 0);
        
        if (!balanceResult.Success || balanceResult.Data == null)
        {
            return ResultOf<bool>.Error("Cannot get coin balance");
        }

        var price = exam.PriceCoins;

        // 3. Apply referral discount if applicable
        EntityReferralCode? referralCode = null;
        if (referralCodeId.HasValue)
        {
            referralCode = await _ctx.Repo<EntityReferralCode>()
                .Query(r => r.Id == referralCodeId.Value && r.IsActive)
                .FirstOrDefaultAsync();

            if (referralCode != null)
            {
                if (referralCode.DiscountPercentage > 0)
                {
                    price = (int)(price * (1 - referralCode.DiscountPercentage / 100));
                }
                if (referralCode.DiscountCoins > 0)
                {
                    price = Math.Max(0, price - referralCode.DiscountCoins);
                }
            }
        }

        if (balanceResult.Data.AvailableCoins < price)
        {
            return ResultOf<bool>.Error("Insufficient coin balance");
        }

        // 4. Deduct coins
        var deductResult = await coinBalanceService.DeductCoins(
            _ctx.UserId ?? 0, 
            price, 
            $"Purchase exam: {exam.Title}");

        if (!deductResult.Success)
        {
            return ResultOf<bool>.Error("Error deducting coins");
        }

        // 5. Create exam purchase record (có thể tạo bảng exam_purchases)
        // TODO: Create exam purchase record

        // 6. Calculate commission if referral code used
        if (referralCode != null)
        {
            var coinService = new CoinService(_ctx, _logger, _env);
            // Commission sẽ được tính tự động trong CoinService
        }

        return ResultOf<bool>.Ok(true);
    }
    catch (Exception ex)
    {
        _logger.LogError($"{_ctx.Summary} - {ex.Message}");
        return ResultOf<bool>.Error("Error purchasing exam");
    }
}
```

#### **Bước 41.2: Test Scenarios**

Tạo file `src/Tests/EndToEndTests.md`:

```markdown
# End-to-End Test Scenarios

## 1. Student Journey
1. Register as Student
2. Login
3. View free courses
4. Purchase coins (50,000 VNĐ)
5. Use referral code (if available)
6. Purchase exam with coins
7. Take exam
8. View results

## 2. Partner Journey
1. Register as Partner
2. Submit business license
3. Wait for admin approval
4. Login after approval
5. Create referral code
6. View dashboard
7. View commissions
8. Copy referral code to share

## 3. Admin Journey
1. Login as Admin
2. View partner registration requests
3. Approve/Reject partner
4. Create course
5. Create exam
6. View reports
7. View commission transactions
```

**Ràng buộc:**
- ✅ Tất cả user journeys phải test
- ✅ Error cases phải test
- ✅ Performance phải acceptable
- ✅ Integration giữa các modules phải smooth

---

### **Ngày 43-44: Bug Fixes & Performance Optimization**

#### **Bước 43.1: Priority Bug Fixes**

**Critical (P0):**
- [ ] Authentication không hoạt động
- [ ] Coin transaction bị mất
- [ ] Commission tính sai
- [ ] Referral code validation fail

**High (P1):**
- [ ] UI không responsive
- [ ] API timeout
- [ ] Data không sync
- [ ] File upload fail

**Medium (P2):**
- [ ] Performance issues
- [ ] UI/UX improvements
- [ ] Error messages không rõ ràng

#### **Bước 43.2: Performance Optimization**

1. **Database Indexes:**
   - Đảm bảo tất cả foreign keys có indexes
   - Indexes cho các columns thường query (status, date_created, etc.)

2. **Caching:**
   - Cache coin balance
   - Cache partner dashboard data
   - Cache referral codes

3. **Query Optimization:**
   - Sử dụng `Include()` đúng cách
   - Tránh N+1 queries
   - Pagination cho large lists

---

### **Ngày 45-50: Demo Preparation & Final Polish**

#### **Bước 45.1: Seed Data Script**

Tạo file `src/SLK.TryEdu.Db/Migrations/SeedData.cs`:

```csharp
using SLK.TryEdu.ModuleUserCore;
using SLK.TryEdu.ModuleCoinCore.Entities;
using SLK.TryEdu.ModuleContentCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace SLK.TryEdu.Db.Migrations
{
    public static class SeedData
    {
        public static async Task SeedAsync(IMyContext context)
        {
            // Seed Users
            if (!await context.Repo<EntityUser>().Query().AnyAsync())
            {
                var admin = new EntityUser
                {
                    Email = "admin@tryedu.com",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("Admin123!"),
                    FirstName = "Admin",
                    LastName = "System",
                    IsActive = true,
                    IsVerified = true,
                    DateCreated = DateTime.UtcNow,
                    DateModified = DateTime.UtcNow,
                    UserCreated = "System"
                };
                await context.Repo<EntityUser>().AddAsync(admin);

                // Seed Students
                for (int i = 1; i <= 5; i++)
                {
                    var student = new EntityUser
                    {
                        Email = $"student{i}@test.com",
                        PasswordHash = BCrypt.Net.BCrypt.HashPassword("Student123!"),
                        FirstName = $"Student{i}",
                        LastName = "Test",
                        IsActive = true,
                        IsVerified = true,
                        DateCreated = DateTime.UtcNow,
                        DateModified = DateTime.UtcNow,
                        UserCreated = "System"
                    };
                    await context.Repo<EntityUser>().AddAsync(student);
                }

                await context.SaveChangesAsync();
            }

            // Seed Partner Centers
            if (!await context.Repo<EntityPartnerCenter>().Query().AnyAsync())
            {
                var partner1 = new EntityPartnerCenter
                {
                    Name = "ABC Language Center",
                    ContactPerson = "Nguyen Van A",
                    Email = "partner1@test.com",
                    Phone = "0123456789",
                    Status = "Active",
                    Tier = "Gold",
                    CommissionRate = 7.00m,
                    DateCreated = DateTime.UtcNow,
                    DateModified = DateTime.UtcNow,
                    UserCreated = "System"
                };
                await context.Repo<EntityPartnerCenter>().AddAsync(partner1);

                var partner2 = new EntityPartnerCenter
                {
                    Name = "XYZ Test Center",
                    ContactPerson = "Tran Thi B",
                    Email = "partner2@test.com",
                    Phone = "0987654321",
                    Status = "Pending",
                    Tier = "Bronze",
                    CommissionRate = 3.00m,
                    DateCreated = DateTime.UtcNow,
                    DateModified = DateTime.UtcNow,
                    UserCreated = "System"
                };
                await context.Repo<EntityPartnerCenter>().AddAsync(partner2);

                await context.SaveChangesAsync();

                // Seed Referral Codes
                var referralCode1 = new EntityReferralCode
                {
                    PartnerCenterId = partner1.Id,
                    Code = "ABC2024",
                    DiscountPercentage = 10.00m,
                    DiscountCoins = 0,
                    IsActive = true,
                    MaxUsage = -1,
                    DateCreated = DateTime.UtcNow,
                    DateModified = DateTime.UtcNow,
                    UserCreated = "System"
                };
                await context.Repo<EntityReferralCode>().AddAsync(referralCode1);
            }

            // Seed Courses
            if (!await context.Repo<EntityCourse>().Query().AnyAsync())
            {
                var course1 = new EntityCourse
                {
                    Title = "IELTS Preparation - Free Course",
                    Description = "Basic IELTS preparation course",
                    IsFree = true,
                    PriceCoins = 0,
                    DateCreated = DateTime.UtcNow,
                    DateModified = DateTime.UtcNow,
                    UserCreated = "System"
                };
                await context.Repo<EntityCourse>().AddAsync(course1);

                var course2 = new EntityCourse
                {
                    Title = "TOEIC Advanced Course",
                    Description = "Advanced TOEIC preparation",
                    IsFree = false,
                    PriceCoins = 500,
                    DateCreated = DateTime.UtcNow,
                    DateModified = DateTime.UtcNow,
                    UserCreated = "System"
                };
                await context.Repo<EntityCourse>().AddAsync(course2);
            }

            // Seed Exams
            if (!await context.Repo<EntityExam>().Query().AnyAsync())
            {
                var exam1 = new EntityExam
                {
                    Title = "IELTS Mock Test 1",
                    Description = "Full IELTS mock test",
                    PriceCoins = 200,
                    Duration = 7200, // 2 hours
                    DateCreated = DateTime.UtcNow,
                    DateModified = DateTime.UtcNow,
                    UserCreated = "System"
                };
                await context.Repo<EntityExam>().AddAsync(exam1);

                var exam2 = new EntityExam
                {
                    Title = "TOEIC Practice Test",
                    Description = "TOEIC practice exam",
                    PriceCoins = 150,
                    Duration = 3600, // 1 hour
                    DateCreated = DateTime.UtcNow,
                    DateModified = DateTime.UtcNow,
                    UserCreated = "System"
                };
                await context.Repo<EntityExam>().AddAsync(exam2);
            }

            await context.SaveChangesAsync();
        }
    }
}
```

#### **Bước 45.2: UI/UX Final Polish**

1. **Consistent Styling:**
   - Đảm bảo tất cả components dùng MudBlazor theme nhất quán
   - Color scheme thống nhất
   - Typography consistent

2. **Error Handling:**
   - User-friendly error messages
   - Loading states
   - Success notifications

3. **Mobile Responsive:**
   - Test trên các screen sizes khác nhau
   - Touch-friendly buttons
   - Responsive tables

#### **Bước 45.3: Documentation**

1. **API Documentation:**
   - Swagger/OpenAPI documentation
   - API endpoint descriptions
   - Request/Response examples

2. **User Guides:**
   - Student guide
   - Partner guide
   - Admin guide

3. **Technical Documentation:**
   - Architecture overview
   - Database schema
   - Deployment guide

**Ràng buộc:**
- ✅ Demo data phải realistic
- ✅ Tất cả flows phải work
- ✅ UI phải đẹp và professional
- ✅ Documentation đầy đủ
- ✅ Performance acceptable

---

## 📋 CHECKLIST HOÀN THÀNH

### **Infrastructure (Tuần 1)**
- [ ] Solution structure setup (ModuleCoin, ModulePartner, ModuleContent)
- [ ] Project references configured
- [ ] Entity models created (kế thừa EntityBase)
- [ ] Entity registration trong DbContext
- [ ] Database migrations created và run
- [ ] Database indexes configured

### **Authentication & User Management (Tuần 2)**
- [ ] EntityUser updated để support Partner role
- [ ] PartnerRegistrationService implemented
- [ ] UserController updated với RegisterPartner endpoint
- [ ] Permissions mới được thêm (PARTNER_*, COIN_*, REFERRAL_*, COMMISSION_*)
- [ ] JWT configuration updated
- [ ] Role-based authorization working

### **Course & Exam System (Tuần 3-4)**
- [ ] EntityCourse, EntityExam created
- [ ] CourseService, ExamService implemented
- [ ] CourseController, ExamController created
- [ ] Exam purchase integration với Coin service
- [ ] Course/Exam Blazor components

### **Coin & Referral System (Tuần 5-6)**
- [ ] CoinService implemented
- [ ] CoinBalanceService implemented
- [ ] ReferralCodeService implemented
- [ ] CommissionService implemented
- [ ] CoinController, ReferralCodeController, CommissionController created
- [ ] Coin transaction atomic operations
- [ ] Commission calculation theo tier
- [ ] Referral code validation

### **Partner Portal (Tuần 7-8)**
- [ ] PartnerService implemented
- [ ] PartnerController created
- [ ] Partner Dashboard Blazor component
- [ ] Referral Code Management UI
- [ ] Commission viewing UI
- [ ] Partner approval/rejection flow
- [ ] File upload cho business license và logo

### **Integration & Testing (Tuần 9-10)**
- [ ] Coin service integrated với Exam purchase
- [ ] Commission calculation integrated
- [ ] End-to-end test scenarios documented
- [ ] Critical bugs fixed
- [ ] Performance optimized
- [ ] Seed data script created
- [ ] UI/UX polished
- [ ] Documentation completed

### **Frontend (Throughout)**
- [ ] Student Portal (basic) - Course browsing, Exam purchase
- [ ] Admin Portal (basic) - Partner approval, Course/Exam management
- [ ] Partner Portal (MVP) - Dashboard, Referral code management
- [ ] Authentication UI - Login, Register, Partner Registration
- [ ] Coin management UI - Purchase coins, View balance, Transaction history
- [ ] Referral code UI - Create, View, Copy, Manage
- [ ] Mobile responsive design

### **Security & Quality**
- [ ] Authentication working correctly
- [ ] Authorization checks in place
- [ ] Input validation implemented
- [ ] SQL injection prevention
- [ ] XSS prevention
- [ ] Error handling comprehensive
- [ ] Logging configured
- [ ] Audit trail working

### **Deployment Ready**
- [ ] Environment configuration
- [ ] Database connection strings configured
- [ ] File storage configured
- [ ] Email service configured (nếu có)
- [ ] Payment gateway integration (nếu có)
- [ ] Production build successful
- [ ] Deployment documentation

---

## ⚠️ RÀNG BUỘC TỔNG QUAN

### **Technical Constraints**
1. ✅ .NET 8.0 only
2. ✅ PostgreSQL for transactional data (có thể thêm MongoDB sau cho content chi tiết)
3. ✅ Module-based architecture (không phải microservices)
4. ✅ EntityBase cho tất cả entities
5. ✅ MyServiceBase pattern cho services
6. ✅ ResultOf<T> pattern cho return types
7. ✅ JWT for authentication (đã có trong Base)
8. ✅ BCrypt for password hashing
9. ✅ All timestamps in UTC (auto-handled)
10. ✅ All amounts in VNĐ
11. ✅ All coin amounts as integers

### **Business Constraints**
1. ✅ Minimum coin purchase: 50,000 VNĐ
2. ✅ Exchange rate: 1 VNĐ = 1 Coin (default)
3. ✅ Commission rates by tier (fixed):
   - Bronze: 3%
   - Silver: 5%
   - Gold: 7%
   - Platinum: 10%
4. ✅ Minimum commission: 10,000 VNĐ
5. ✅ Maximum commission: 1,000,000 VNĐ
6. ✅ Referral code expiry: configurable
7. ✅ Partner approval: manual by Admin
8. ✅ Partner status flow: Pending → Approved/Rejected → Active

### **Security Constraints**
1. ✅ Passwords must be hashed (BCrypt)
2. ✅ JWT tokens must expire (24 hours default)
3. ✅ Permission checks với `_ctx.CheckPermission()`
4. ✅ File uploads must be validated (max 5MB business license, 2MB logo)
5. ✅ SQL injection prevention (EF Core parameterized queries)
6. ✅ XSS prevention (Razor auto-encoding)
7. ✅ User chỉ access được data của mình (trừ Admin)

### **Performance Constraints**
1. ✅ API response time < 300ms (95th percentile)
2. ✅ Database queries optimized (indexes, Include())
3. ✅ Pagination for large lists
4. ✅ Caching where appropriate (coin balance, dashboard data)
5. ✅ Async/await for I/O operations
6. ✅ Avoid N+1 queries

---

## 📊 METRICS THÀNH CÔNG

### **Code Quality**
- ✅ Code follows module pattern consistently
- ✅ All entities kế thừa EntityBase
- ✅ All services kế thừa MyServiceBase
- ✅ Error handling với ResultOf<T> pattern
- ✅ Logging đầy đủ
- ✅ No critical security vulnerabilities
- ✅ Code review passed
- ✅ Documentation complete

### **Functionality**
- ✅ All MVP features working:
  - User registration (Student, Teacher, Partner)
  - Partner approval workflow
  - Coin purchase với referral code
  - Exam purchase với coins
  - Commission calculation tự động
  - Partner dashboard với KPIs
  - Referral code management
- ✅ All user journeys pass:
  - Student: Register → Login → View courses → Purchase coins → Buy exam
  - Partner: Register → Wait approval → Login → Create codes → View dashboard
  - Admin: Login → Approve partners → Manage courses/exams → View reports
- ✅ Error handling complete
- ✅ Data validation complete
- ✅ Integration giữa modules smooth

### **Performance**
- ✅ API response time < 300ms (95th percentile)
- ✅ Database query time < 100ms
- ✅ Page load time < 2 seconds
- ✅ Dashboard load time < 3 seconds
- ✅ No N+1 queries
- ✅ Proper indexing

### **User Experience**
- ✅ UI responsive trên mobile
- ✅ Error messages user-friendly
- ✅ Loading states rõ ràng
- ✅ Success notifications
- ✅ Consistent design với MudBlazor
- ✅ Copy to clipboard working
- ✅ Form validation client-side

---

## 🚀 DEPLOYMENT CHECKLIST

### **Pre-Deployment**
- [ ] All migrations run successfully
- [ ] Seed data loaded
- [ ] Environment variables configured
- [ ] Connection strings set
- [ ] File storage configured
- [ ] Email service configured (nếu có)
- [ ] Payment gateway configured (nếu có)
- [ ] SSL certificates ready
- [ ] Domain names configured

### **Deployment Steps**
1. [ ] Build production version
2. [ ] Run database migrations
3. [ ] Seed initial data
4. [ ] Deploy WebHost application
5. [ ] Deploy WebApp (Blazor WASM)
6. [ ] Configure reverse proxy (nginx/IIS)
7. [ ] Setup monitoring và logging
8. [ ] Test all critical paths
9. [ ] Performance testing
10. [ ] Security scan

### **Post-Deployment**
- [ ] Monitor error logs
- [ ] Monitor performance metrics
- [ ] User acceptance testing
- [ ] Backup strategy in place
- [ ] Disaster recovery plan
- [ ] Documentation updated

---

## 📚 TÀI LIỆU THAM KHẢO

### **Internal Documents**
- `HỆ THỐNG GIÁO DỤC TRỰC TUYẾN - V2.0 (B2B2C).md` - Requirements document
- `DINH_HUONG_CHUC_NANG_V2.0.md` - Functional overview
- `database_schema_postgresql.md` - Database schema
- `LICH_TRINH_CAP_NHAT_CAU_TRUC.md` - Architecture updates

### **Code Structure**
- `SLK.TryEdu.Abstract` - Shared abstractions
- `SLK.TryEdu.Base` - Base classes và services
- `SLK.TryEdu.Db` - Database layer
- `SLK.TryEdu.ModuleCoin` - Coin & Referral system
- `SLK.TryEdu.ModulePartner` - Partner management
- `SLK.TryEdu.ModuleContent` - Course & Exam system
- `SLK.TryEdu.ModuleUser` - User management
- `SLK.TryEdu.WebHost` - Server-side application
- `SLK.TryEdu.WebApp` - Blazor WebAssembly

---

## ✅ KẾT LUẬN

Lịch trình này đã được cập nhật để phù hợp với cấu trúc code hiện tại của dự án. Tất cả các modules, services, và components đều tuân theo pattern đã có sẵn trong hệ thống.

**Điểm quan trọng:**
1. ✅ Sử dụng module-based architecture thay vì microservices
2. ✅ Tất cả entities kế thừa EntityBase
3. ✅ Services sử dụng MyServiceBase và ResultOf<T> pattern
4. ✅ Controllers kế thừa Services
5. ✅ Database access qua `_ctx.Repo<T>()`
6. ✅ Permission checks với `_ctx.CheckPermission()`
7. ✅ UTC timestamps được handle tự động

**Timeline:** 10 tuần (2.5 tháng) để có bản thử nghiệm đầu tiên với đầy đủ tính năng MVP.

**Tài liệu này sẽ được cập nhật hàng tuần theo tiến độ thực tế.**

---

**Tài liệu này sẽ được cập nhật hàng tuần theo tiến độ thực tế.**


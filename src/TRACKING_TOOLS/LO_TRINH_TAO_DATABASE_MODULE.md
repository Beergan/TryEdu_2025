# 🗄️ LỘ TRÌNH TẠO DATABASE CHO TỪNG MODULE

## 🎯 MỤC ĐÍCH

File này hướng dẫn **từng bước** cách tạo database (entities, migrations, seed data) cho mỗi module trong hệ thống TryEdu V2.0.

---

## 📋 TỔNG QUAN QUY TRÌNH

### Quy trình chung cho mỗi module:

```
1. Tạo Entity Models (ModuleXCore/Entities/)
2. Tạo EntityRegister.cs (ModuleX/Classes/)
3. Register entities trong DbContext
4. Tạo EF Core Migration
5. Test migration
6. Tạo Seed Data (nếu cần)
7. Document schema
```

---

## 🪙 MODULE 1: MODULECOIN - COIN SYSTEM

### 📊 Database Tables Cần Tạo:

1. **coin_balances** - Số dư coin của user
2. **coin_transactions** - Lịch sử giao dịch coin
3. **coin_exchange_rates** - Tỷ giá đổi coin (VND → Coin)

### 🔧 Bước 1: Tạo Entity Models

#### 1.1. Tạo `EntityCoinBalance.cs`

**File:** `src/SLK.TryEdu.ModuleCoinCore/Entities/EntityCoinBalance.cs`

```csharp
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SLK.TryEdu.Abstract;

namespace SLK.TryEdu.ModuleCoinCore.Entities
{
    [Table("coin_balances")]
    public class EntityCoinBalance : EntityBase
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        [Column(TypeName = "decimal(12,2)")]
        public decimal Balance { get; set; } = 0;

        [Required]
        [Column(TypeName = "decimal(12,2)")]
        public decimal TotalEarned { get; set; } = 0;

        [Required]
        [Column(TypeName = "decimal(12,2)")]
        public decimal TotalSpent { get; set; } = 0;

        [MaxLength(20)]
        public string Status { get; set; } = "Active"; // Active, Frozen, Closed

        // Navigation
        [ForeignKey(nameof(UserId))]
        public virtual EntityUser User { get; set; } = null!;
    }
}
```

**Checklist:**
- [ ] File đã tạo
- [ ] Kế thừa từ EntityBase
- [ ] Table name: `coin_balances`
- [ ] UserId foreign key
- [ ] Balance, TotalEarned, TotalSpent (decimal 12,2)
- [ ] Status field

---

#### 1.2. Tạo `EntityCoinTransaction.cs`

**File:** `src/SLK.TryEdu.ModuleCoinCore/Entities/EntityCoinTransaction.cs`

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
        [MaxLength(50)]
        public string TransactionType { get; set; } = string.Empty; 
        // Purchase, Use, Refund, Bonus, Commission

        [Required]
        [Column(TypeName = "decimal(12,2)")]
        public decimal Amount { get; set; }

        [Required]
        [MaxLength(20)]
        public string Status { get; set; } = "Pending"; // Pending, Completed, Failed, Cancelled

        [MaxLength(500)]
        public string Description { get; set; } = string.Empty;

        public int? ReferralCodeId { get; set; }

        public int? RelatedTransactionId { get; set; } // For refunds

        // Navigation
        [ForeignKey(nameof(UserId))]
        public virtual EntityUser User { get; set; } = null!;

        [ForeignKey(nameof(ReferralCodeId))]
        public virtual EntityReferralCode? ReferralCode { get; set; }
    }
}
```

**Checklist:**
- [ ] File đã tạo
- [ ] TransactionType enum values
- [ ] Amount (decimal 12,2)
- [ ] Status field
- [ ] Foreign keys: UserId, ReferralCodeId

---

#### 1.3. Tạo `EntityCoinExchangeRate.cs`

**File:** `src/SLK.TryEdu.ModuleCoinCore/Entities/EntityCoinExchangeRate.cs`

```csharp
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SLK.TryEdu.Abstract;

namespace SLK.TryEdu.ModuleCoinCore.Entities
{
    [Table("coin_exchange_rates")]
    public class EntityCoinExchangeRate : EntityBase
    {
        [Required]
        [MaxLength(10)]
        public string Currency { get; set; } = "VND"; // VND, USD, etc.

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Rate { get; set; } // 1 Coin = ? VND

        [Required]
        public bool IsActive { get; set; } = true;

        public DateTime? EffectiveFrom { get; set; }

        public DateTime? EffectiveTo { get; set; }
    }
}
```

**Checklist:**
- [ ] File đã tạo
- [ ] Currency field
- [ ] Rate (decimal 10,2)
- [ ] IsActive flag
- [ ] Effective dates

---

### 🔧 Bước 2: Tạo EntityRegister.cs

**File:** `src/SLK.TryEdu.ModuleCoin/Classes/EntityRegister.cs`

```csharp
using Microsoft.EntityFrameworkCore;
using SLK.TryEdu.ModuleCoinCore.Entities;

namespace SLK.TryEdu.ModuleCoin.Classes
{
    public class EntityRegister
    {
        public static void RegisterEntities(ModelBuilder builder)
        {
            // Coin Balance Configuration
            builder.Entity<EntityCoinBalance>(entity =>
            {
                entity.ToTable("coin_balances");
                entity.HasKey(e => e.Id);
                entity.HasAlternateKey(e => e.Guid);
                
                entity.HasIndex(e => e.UserId).IsUnique(); // One balance per user
                
                entity.Property(e => e.Balance)
                    .HasPrecision(12, 2)
                    .HasDefaultValue(0);
                    
                entity.Property(e => e.TotalEarned)
                    .HasPrecision(12, 2)
                    .HasDefaultValue(0);
                    
                entity.Property(e => e.TotalSpent)
                    .HasPrecision(12, 2)
                    .HasDefaultValue(0);
                    
                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .HasDefaultValue("Active");
                
                entity.HasOne(e => e.User)
                    .WithOne()
                    .HasForeignKey<EntityCoinBalance>(e => e.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // Coin Transaction Configuration
            builder.Entity<EntityCoinTransaction>(entity =>
            {
                entity.ToTable("coin_transactions");
                entity.HasKey(e => e.Id);
                entity.HasAlternateKey(e => e.Guid);
                
                entity.HasIndex(e => e.UserId);
                entity.HasIndex(e => e.TransactionType);
                entity.HasIndex(e => e.DateCreated);
                
                entity.Property(e => e.Amount)
                    .HasPrecision(12, 2);
                    
                entity.Property(e => e.TransactionType)
                    .HasMaxLength(50)
                    .IsRequired();
                    
                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .HasDefaultValue("Pending");
                
                entity.HasOne(e => e.User)
                    .WithMany()
                    .HasForeignKey(e => e.UserId)
                    .OnDelete(DeleteBehavior.Restrict);
                    
                entity.HasOne(e => e.ReferralCode)
                    .WithMany()
                    .HasForeignKey(e => e.ReferralCodeId)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            // Coin Exchange Rate Configuration
            builder.Entity<EntityCoinExchangeRate>(entity =>
            {
                entity.ToTable("coin_exchange_rates");
                entity.HasKey(e => e.Id);
                entity.HasAlternateKey(e => e.Guid);
                
                entity.HasIndex(e => new { e.Currency, e.IsActive });
                
                entity.Property(e => e.Rate)
                    .HasPrecision(10, 2);
                    
                entity.Property(e => e.Currency)
                    .HasMaxLength(10)
                    .IsRequired();
            });
        }
    }
}
```

**Checklist:**
- [ ] File đã tạo
- [ ] Register CoinBalance với unique UserId
- [ ] Register CoinTransaction với indexes
- [ ] Register CoinExchangeRate
- [ ] Foreign keys configured
- [ ] Decimal precision set

---

### 🔧 Bước 3: Register trong DbContext

**File:** `src/SLK.TryEdu.Db/DbPostgres/Context/DbPostgresContext.cs`

Cập nhật method `OnModelCreating`:

```csharp
protected override void OnModelCreating(ModelBuilder builder)
{
    base.OnModelCreating(builder);
    
    // Register entities from modules
    SLK.TryEdu.ModuleCoin.Classes.EntityRegister.RegisterEntities(builder);
    // ... other module registrations
}
```

**Checklist:**
- [ ] EntityRegister.RegisterEntities được gọi
- [ ] Build solution thành công
- [ ] Không có lỗi compile

---

### 🔧 Bước 4: Tạo EF Core Migration

**Terminal Command:**

```bash
cd src/SLK.TryEdu.Db
dotnet ef migrations add AddCoinModuleTables --startup-project ../SLK.TryEdu.WebHost
```

**Migration sẽ tạo:**
- `coin_balances` table
- `coin_transactions` table
- `coin_exchange_rates` table
- Indexes và foreign keys

**Checklist:**
- [ ] Migration file đã tạo
- [ ] Review migration code
- [ ] Không có lỗi syntax

---

### 🔧 Bước 5: Test Migration

**Terminal Command:**

```bash
# Update database
dotnet ef database update --startup-project ../SLK.TryEdu.WebHost

# Verify tables created
psql -U postgres -d tryedu_db -c "\dt coin_*"
```

**Expected Output:**
```
coin_balances
coin_transactions
coin_exchange_rates
```

**Checklist:**
- [ ] Migration chạy thành công
- [ ] Tables đã tạo trong database
- [ ] Indexes đã tạo
- [ ] Foreign keys đã tạo

---

### 🔧 Bước 6: Tạo Seed Data

**File:** `src/SLK.TryEdu.Db/Migrations/SeedData/SeedCoinExchangeRates.cs`

```csharp
using Microsoft.EntityFrameworkCore;
using SLK.TryEdu.Db.DbPostgres.Context;
using SLK.TryEdu.ModuleCoinCore.Entities;

namespace SLK.TryEdu.Db.Migrations.SeedData
{
    public static class SeedCoinExchangeRates
    {
        public static void Seed(DbPostgresContext context)
        {
            if (context.Set<EntityCoinExchangeRate>().Any())
                return; // Already seeded

            var rates = new[]
            {
                new EntityCoinExchangeRate
                {
                    Currency = "VND",
                    Rate = 1000, // 1 Coin = 1000 VND
                    IsActive = true,
                    EffectiveFrom = DateTime.UtcNow,
                    UserCreated = "System",
                    UserModified = "System"
                }
            };

            context.Set<EntityCoinExchangeRate>().AddRange(rates);
            context.SaveChanges();
        }
    }
}
```

**Checklist:**
- [ ] Seed data file đã tạo
- [ ] Default exchange rate: 1 Coin = 1000 VND
- [ ] Seed method được gọi trong startup

---

### ✅ MODULECOIN - ACCEPTANCE CRITERIA

- [ ] EntityCoinBalance.cs đã tạo
- [ ] EntityCoinTransaction.cs đã tạo
- [ ] EntityCoinExchangeRate.cs đã tạo
- [ ] EntityRegister.cs đã tạo và register đúng
- [ ] DbContext đã gọi RegisterEntities
- [ ] Migration đã tạo thành công
- [ ] Database update thành công
- [ ] Tables đã tạo trong PostgreSQL
- [ ] Seed data đã chạy
- [ ] Test query data thành công

---

## 🤝 MODULE 2: MODULEPARTNER - PARTNER SYSTEM

### 📊 Database Tables Cần Tạo:

1. **partner_centers** - Thông tin trung tâm đối tác
2. **referral_codes** - Mã giới thiệu
3. **commission_transactions** - Giao dịch hoa hồng

### 🔧 Bước 1: Tạo Entity Models

#### 1.1. Tạo `EntityPartnerCenter.cs`

**File:** `src/SLK.TryEdu.ModulePartnerCore/Entities/EntityPartnerCenter.cs`

```csharp
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SLK.TryEdu.Abstract;

namespace SLK.TryEdu.ModulePartnerCore.Entities
{
    [Table("partner_centers")]
    public class EntityPartnerCenter : EntityBase
    {
        [Required]
        [MaxLength(100)]
        public string CenterName { get; set; } = string.Empty;

        [Required]
        [MaxLength(20)]
        public string CenterCode { get; set; } = string.Empty; // Unique code

        [Required]
        [MaxLength(255)]
        public string Email { get; set; } = string.Empty;

        [MaxLength(20)]
        public string Phone { get; set; } = string.Empty;

        [MaxLength(500)]
        public string Address { get; set; } = string.Empty;

        [MaxLength(100)]
        public string City { get; set; } = string.Empty;

        [MaxLength(100)]
        public string Country { get; set; } = string.Empty;

        [MaxLength(500)]
        public string LogoUrl { get; set; } = string.Empty;

        [MaxLength(500)]
        public string LicenseUrl { get; set; } = string.Empty; // Business license

        [Required]
        [MaxLength(20)]
        public string Status { get; set; } = "Pending"; // Pending, Approved, Rejected, Suspended

        [Required]
        [MaxLength(20)]
        public string Tier { get; set; } = "Bronze"; // Bronze, Silver, Gold, Platinum

        [Required]
        [Column(TypeName = "decimal(5,2)")]
        public decimal CommissionRate { get; set; } = 5.00m; // Default 5%

        public int? ApprovedByUserId { get; set; }

        public DateTime? ApprovedAt { get; set; }

        [MaxLength(500)]
        public string RejectionReason { get; set; } = string.Empty;

        // Navigation
        public virtual ICollection<EntityReferralCode> ReferralCodes { get; set; } = new List<EntityReferralCode>();
    }
}
```

**Checklist:**
- [ ] File đã tạo
- [ ] CenterCode unique
- [ ] Email unique
- [ ] Status: Pending, Approved, Rejected, Suspended
- [ ] Tier: Bronze, Silver, Gold, Platinum
- [ ] CommissionRate (decimal 5,2)

---

#### 1.2. Tạo `EntityReferralCode.cs`

**File:** `src/SLK.TryEdu.ModulePartnerCore/Entities/EntityReferralCode.cs`

```csharp
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SLK.TryEdu.Abstract;

namespace SLK.TryEdu.ModulePartnerCore.Entities
{
    [Table("referral_codes")]
    public class EntityReferralCode : EntityBase
    {
        [Required]
        public int PartnerCenterId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Code { get; set; } = string.Empty; // Unique code

        [MaxLength(200)]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "decimal(5,2)")]
        public decimal DiscountPercentage { get; set; } = 10.00m; // Default 10%

        [Required]
        public int MaxUsage { get; set; } = 100; // -1 = unlimited

        [Required]
        public int UsedCount { get; set; } = 0;

        [Required]
        public bool IsActive { get; set; } = true;

        public DateTime? ExpiryDate { get; set; }

        public DateTime? StartDate { get; set; }

        // Navigation
        [ForeignKey(nameof(PartnerCenterId))]
        public virtual EntityPartnerCenter PartnerCenter { get; set; } = null!;
    }
}
```

**Checklist:**
- [ ] File đã tạo
- [ ] Code unique
- [ ] DiscountPercentage (decimal 5,2)
- [ ] MaxUsage (-1 = unlimited)
- [ ] UsedCount tracking
- [ ] ExpiryDate optional

---

#### 1.3. Tạo `EntityCommissionTransaction.cs`

**File:** `src/SLK.TryEdu.ModulePartnerCore/Entities/EntityCommissionTransaction.cs`

```csharp
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SLK.TryEdu.Abstract;

namespace SLK.TryEdu.ModulePartnerCore.Entities
{
    [Table("commission_transactions")]
    public class EntityCommissionTransaction : EntityBase
    {
        [Required]
        public int PartnerCenterId { get; set; }

        [Required]
        public int UserId { get; set; } // Student who made purchase

        public int? ReferralCodeId { get; set; }

        [Required]
        [Column(TypeName = "decimal(12,2)")]
        public decimal TransactionAmount { get; set; } // Original transaction amount

        [Required]
        [Column(TypeName = "decimal(12,2)")]
        public decimal CommissionAmount { get; set; } // Commission earned

        [Required]
        [Column(TypeName = "decimal(5,2)")]
        public decimal CommissionRate { get; set; } // Rate used

        [Required]
        [MaxLength(50)]
        public string TransactionType { get; set; } = string.Empty; // CoinPurchase, ExamPurchase

        [Required]
        [MaxLength(20)]
        public string Status { get; set; } = "Pending"; // Pending, Paid, Cancelled

        public DateTime? PaidAt { get; set; }

        // Navigation
        [ForeignKey(nameof(PartnerCenterId))]
        public virtual EntityPartnerCenter PartnerCenter { get; set; } = null!;
    }
}
```

**Checklist:**
- [ ] File đã tạo
- [ ] TransactionAmount (decimal 12,2)
- [ ] CommissionAmount (decimal 12,2)
- [ ] CommissionRate (decimal 5,2)
- [ ] TransactionType enum
- [ ] Status: Pending, Paid, Cancelled

---

### 🔧 Bước 2: Tạo EntityRegister.cs

**File:** `src/SLK.TryEdu.ModulePartner/Classes/EntityRegister.cs`

```csharp
using Microsoft.EntityFrameworkCore;
using SLK.TryEdu.ModulePartnerCore.Entities;

namespace SLK.TryEdu.ModulePartner.Classes
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
                
                entity.HasIndex(e => e.CenterCode).IsUnique();
                entity.HasIndex(e => e.Email).IsUnique();
                entity.HasIndex(e => e.Status);
                
                entity.Property(e => e.CommissionRate)
                    .HasPrecision(5, 2)
                    .HasDefaultValue(5.00m);
                    
                entity.Property(e => e.Tier)
                    .HasMaxLength(20)
                    .HasDefaultValue("Bronze");
                    
                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .HasDefaultValue("Pending");
            });

            // Referral Code Configuration
            builder.Entity<EntityReferralCode>(entity =>
            {
                entity.ToTable("referral_codes");
                entity.HasKey(e => e.Id);
                entity.HasAlternateKey(e => e.Guid);
                
                entity.HasIndex(e => e.Code).IsUnique();
                entity.HasIndex(e => e.PartnerCenterId);
                entity.HasIndex(e => new { e.IsActive, e.ExpiryDate });
                
                entity.Property(e => e.DiscountPercentage)
                    .HasPrecision(5, 2)
                    .HasDefaultValue(10.00m);
                    
                entity.Property(e => e.MaxUsage)
                    .HasDefaultValue(100);
                    
                entity.Property(e => e.UsedCount)
                    .HasDefaultValue(0);
                    
                entity.Property(e => e.IsActive)
                    .HasDefaultValue(true);
                
                entity.HasOne(e => e.PartnerCenter)
                    .WithMany(p => p.ReferralCodes)
                    .HasForeignKey(e => e.PartnerCenterId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // Commission Transaction Configuration
            builder.Entity<EntityCommissionTransaction>(entity =>
            {
                entity.ToTable("commission_transactions");
                entity.HasKey(e => e.Id);
                entity.HasAlternateKey(e => e.Guid);
                
                entity.HasIndex(e => e.PartnerCenterId);
                entity.HasIndex(e => e.UserId);
                entity.HasIndex(e => e.DateCreated);
                
                entity.Property(e => e.TransactionAmount)
                    .HasPrecision(12, 2);
                    
                entity.Property(e => e.CommissionAmount)
                    .HasPrecision(12, 2);
                    
                entity.Property(e => e.CommissionRate)
                    .HasPrecision(5, 2);
                    
                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .HasDefaultValue("Pending");
                
                entity.HasOne(e => e.PartnerCenter)
                    .WithMany()
                    .HasForeignKey(e => e.PartnerCenterId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
```

**Checklist:**
- [ ] File đã tạo
- [ ] PartnerCenter với unique CenterCode và Email
- [ ] ReferralCode với unique Code
- [ ] CommissionTransaction với indexes
- [ ] Foreign keys configured

---

### 🔧 Bước 3-6: Tương tự ModuleCoin

- [ ] Register trong DbContext
- [ ] Tạo migration: `AddPartnerModuleTables`
- [ ] Test migration
- [ ] Seed data (nếu cần)

---

### ✅ MODULEPARTNER - ACCEPTANCE CRITERIA

- [ ] EntityPartnerCenter.cs đã tạo
- [ ] EntityReferralCode.cs đã tạo
- [ ] EntityCommissionTransaction.cs đã tạo
- [ ] EntityRegister.cs đã tạo
- [ ] Migration thành công
- [ ] Tables đã tạo
- [ ] Test queries thành công

---

## 📚 MODULE 3: MODULECONTENT - CONTENT SYSTEM

### 📊 Database Tables Cần Tạo:

1. **courses** - Khóa học
2. **course_lessons** - Danh sách bài học thuộc khóa
3. **lesson_contents** - Nội dung chi tiết (video/text/quiz) lưu JSONB
4. **course_enrollments** - Đăng ký khóa học
5. **lesson_progress** - Tiến độ học từng bài (optional – MongoDB hoặc PostgreSQL)

### 🔧 Bước 1: Tạo Entity Models

#### 1.1. Tạo `EntityCourse.cs`

**File:** `src/SLK.TryEdu.ModuleContentCore/Entities/EntityCourse.cs`

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

        [MaxLength(500)]
        public string Slug { get; set; } = string.Empty; // URL-friendly

        [MaxLength(1000)]
        public string Description { get; set; } = string.Empty;

        [MaxLength(500)]
        public string ThumbnailUrl { get; set; } = string.Empty;

        [Required]
        [MaxLength(20)]
        public string CourseType { get; set; } = "Free"; // Free, Premium

        [Required]
        [Column(TypeName = "decimal(12,2)")]
        public decimal PriceCoins { get; set; } = 0; // 0 for free courses

        [Required]
        [MaxLength(20)]
        public string Level { get; set; } = "Beginner"; // Beginner, Intermediate, Advanced

        [MaxLength(100)]
        public string Category { get; set; } = string.Empty;

        [Required]
        public int CreatedByUserId { get; set; }

        [Required]
        [MaxLength(20)]
        public string Status { get; set; } = "Draft"; // Draft, Published, Archived

        public DateTime? PublishedAt { get; set; }

        // JSONB for flexible lesson structure (or use MongoDB)
        [Column(TypeName = "jsonb")]
        public string? CourseData { get; set; } // Lessons, sections, etc.

        // Navigation
        [ForeignKey(nameof(CreatedByUserId))]
        public virtual EntityUser CreatedBy { get; set; } = null!;
    }
}
```

**Checklist:**
- [ ] File đã tạo
- [ ] Slug unique (for SEO)
- [ ] CourseType: Free, Premium
- [ ] PriceCoins = 0 for free
- [ ] Status: Draft, Published, Archived
- [ ] CourseData JSONB (or MongoDB)

---

#### 1.2. Tạo `EntityCourseLesson.cs`

**File:** `src/SLK.TryEdu.ModuleContentCore/Entities/EntityCourseLesson.cs`

```csharp
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SLK.TryEdu.Abstract;

namespace SLK.TryEdu.ModuleContentCore.Entities;

[Table("course_lessons")]
public class EntityCourseLesson : EntityBase
{
    [Required]
    public int CourseId { get; set; }

    [Required, MaxLength(255)]
    public string Title { get; set; } = string.Empty;

    [MaxLength(1000)]
    public string Description { get; set; } = string.Empty;

    [Required]
    public int Order { get; set; }

    [Required]
    [MaxLength(20)]
    public string LessonType { get; set; } = "Video"; // Video, Article, Quiz

    [Column(TypeName = "jsonb")]
    public string? Resources { get; set; } // videoUrl, attachments, etc.

    [ForeignKey(nameof(CourseId))]
    public virtual EntityCourse Course { get; set; } = null!;

    public virtual ICollection<EntityLessonContent> Contents { get; set; } = new List<EntityLessonContent>();
}
```

#### 1.3. Tạo `EntityLessonContent.cs`

```csharp
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SLK.TryEdu.Abstract;

namespace SLK.TryEdu.ModuleContentCore.Entities;

[Table("lesson_contents")]
public class EntityLessonContent : EntityBase
{
    [Required]
    public int CourseLessonId { get; set; }

    [Required, MaxLength(20)]
    public string ContentType { get; set; } = "Video"; // Video, Text, QuizBlock

    [Required]
    public int Order { get; set; }

    [Column(TypeName = "jsonb")]
    public string Payload { get; set; } = string.Empty; // videoUrl, markdown, quiz schema

    public bool IsPreview { get; set; } = false;

    [ForeignKey(nameof(CourseLessonId))]
    public virtual EntityCourseLesson Lesson { get; set; } = null!;
}
```

#### 1.4. Tạo `EntityCourseEnrollment.cs`

**File:** `src/SLK.TryEdu.ModuleContentCore/Entities/EntityCourseEnrollment.cs`

```csharp
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SLK.TryEdu.Abstract;

namespace SLK.TryEdu.ModuleContentCore.Entities
{
    [Table("course_enrollments")]
    public class EntityCourseEnrollment : EntityBase
    {
        [Required]
        public int CourseId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        [MaxLength(20)]
        public string Status { get; set; } = "Active"; // Active, Completed, Cancelled

        public DateTime? EnrolledAt { get; set; }

        public DateTime? CompletedAt { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal? ProgressPercentage { get; set; } = 0;

        public int? ReferralCodeId { get; set; }

        // Navigation
        [ForeignKey(nameof(CourseId))]
        public virtual EntityCourse Course { get; set; } = null!;

        [ForeignKey(nameof(UserId))]
        public virtual EntityUser User { get; set; } = null!;
    }
}
```

**Checklist:**
- [ ] File đã tạo
- [ ] Unique (CourseId, UserId)
- [ ] Status: Active, Completed, Cancelled
- [ ] ProgressPercentage tracking
- [ ] ReferralCodeId optional

---

### 🔧 Bước 2-6: Tương tự các module trước

- [ ] EntityRegister.cs
- [ ] Register trong DbContext
- [ ] Migration: `AddContentModuleTables`
- [ ] Test migration
- [ ] Seed data

---

- [ ] Seed data (cặp khóa học mẫu + lesson sample)

---

### ✅ MODULECONTENT - ACCEPTANCE CRITERIA

- [ ] EntityCourse.cs đã tạo
- [ ] EntityCourseLesson.cs đã tạo
- [ ] EntityLessonContent.cs đã tạo
- [ ] EntityCourseEnrollment.cs đã tạo
- [ ] Migration thành công
- [ ] Tables/relations đã tạo
- [ ] Test queries (lấy course -> lessons -> contents) thành công

---

## 📝 MODULE 4: MODULEEXAM - EXAM SYSTEM

### 📊 Database Tables Cần Tạo:

1. **exam_templates** – định nghĩa bộ đề chuẩn (metadata tổng).
2. **exam_template_sections** – các section (Reading, Listening…) với số câu và trọng số.
3. **exam_questions** – ngân hàng câu hỏi tái sử dụng.
4. **question_options** – đáp án cho câu hỏi dạng lựa chọn.
5. **exam_template_questions** – mapping template ↔ câu hỏi + vị trí/thứ tự.
6. **exams** – phiên bản đề thi xuất bản (snapshot từ template).
7. **exam_attempts / exam_submissions** – bài thi thí sinh đã làm.
8. **exam_attempt_questions** – câu hỏi cụ thể đã bốc cho attempt (để audit).

> Tùy nhu cầu có thể thêm `exam_purchases` (nếu tách khỏi course_enrollments) và `exam_question_groups` (group audio/passage).

### 🔧 Bước 1: Tạo Entity Models

**⚠️ LƯU Ý QUAN TRỌNG: Thứ tự tạo entities phải đúng logic:**
1. **ExamTemplate** (blueprint) → 2. **Exam** (instance từ template)

#### 1.1. `EntityExamTemplate.cs`

**File:** `src/SLK.TryEdu.ModuleExamCore/Entities/EntityExamTemplate.cs`

```csharp
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SLK.TryEdu.Abstract;

namespace SLK.TryEdu.ModuleExamCore.Entities;

[Table("exam_templates")]
public class EntityExamTemplate : EntityBase
{
    [Required, MaxLength(255)]
    public string Title { get; set; } = string.Empty;

    [MaxLength(500)]
    public string Slug { get; set; } = string.Empty;

    [MaxLength(1000)]
    public string Description { get; set; } = string.Empty;

    [Required]
    [MaxLength(20)]
    public string Level { get; set; } = "B1";

    [Required]
    [MaxLength(50)]
    public string ExamType { get; set; } = "IELTS";

    [Required]
    public int DurationMinutes { get; set; } = 120;

    [Required]
    [Column(TypeName = "decimal(5,2)")]
    public decimal PassingScore { get; set; } = 60m;

    [Required]
    public int CreatedByUserId { get; set; }

    [Required]
    [MaxLength(20)]
    public string Status { get; set; } = "Draft"; // Draft, Published, Archived

    [Column(TypeName = "jsonb")]
    public string? Metadata { get; set; } // extra settings (e.g. instructions, scoring schema)

    // Navigation
    public virtual ICollection<EntityExamTemplateSection> Sections { get; set; } = new List<EntityExamTemplateSection>();
}
```

#### 1.2. `EntityExamTemplateSection.cs`

**File:** `src/SLK.TryEdu.ModuleExamCore/Entities/EntityExamTemplateSection.cs`

> **⚠️ LƯU Ý:** Entity này có foreign key `ExamTemplateId`, nên cần `EntityExamTemplate` tồn tại trước.

```csharp
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SLK.TryEdu.Abstract;

namespace SLK.TryEdu.ModuleExamCore.Entities;

[Table("exam_template_sections")]
public class EntityExamTemplateSection : EntityBase
{
    [Required]
    public int ExamTemplateId { get; set; }

    [Required, MaxLength(100)]
    public string SectionName { get; set; } = string.Empty; // Reading, Listening,...

    [Required]
    public int Order { get; set; }

    [Required]
    public int QuestionCount { get; set; }

    [Required]
    [Column(TypeName = "decimal(5,2)")]
    public decimal WeightPercentage { get; set; } = 25m;

    [Column(TypeName = "jsonb")]
    public string? Config { get; set; } // time limit, audio source, etc.

    [ForeignKey(nameof(ExamTemplateId))]
    public virtual EntityExamTemplate ExamTemplate { get; set; } = null!;

    public virtual ICollection<EntityExamTemplateQuestion> TemplateQuestions { get; set; } = new List<EntityExamTemplateQuestion>();
}
```

#### 1.3. `EntityExamQuestion.cs`

**File:** `src/SLK.TryEdu.ModuleExamCore/Entities/EntityExamQuestion.cs`

> **⚠️ LƯU Ý:** Entity này không có dependencies, có thể tạo song song với ExamTemplate.

```csharp
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SLK.TryEdu.Abstract;

namespace SLK.TryEdu.ModuleExamCore.Entities;

[Table("exam_questions")]
public class EntityExamQuestion : EntityBase
{
    [Required, MaxLength(50)]
    public string QuestionType { get; set; } = "MultipleChoice"; // MCQ, Essay, DragDrop...

    [Required]
    [MaxLength(500)]
    public string Title { get; set; } = string.Empty;

    [Column(TypeName = "text")]
    public string? Prompt { get; set; } // question text / passage

    [Column(TypeName = "jsonb")]
    public string? RichContent { get; set; } // store structured content (audio url, image, etc.)

    [Required]
    [Column(TypeName = "decimal(5,2)")]
    public decimal DefaultPoint { get; set; } = 1m;

    [MaxLength(20)]
    public string Difficulty { get; set; } = "Medium";

    [MaxLength(50)]
    public string Skill { get; set; } = "Reading";

    [MaxLength(100)]
    public string Category { get; set; } = string.Empty;

    [Required]
    public bool IsActive { get; set; } = true;

    public int? GroupId { get; set; } // group passage/audio (optional)

    // JSON structure to store correct answers for essay/fill-in
    [Column(TypeName = "jsonb")]
    public string? AnswerSchema { get; set; }

    public virtual ICollection<EntityQuestionOption> Options { get; set; } = new List<EntityQuestionOption>();
}
```

#### 1.4. `EntityQuestionOption.cs`

**File:** `src/SLK.TryEdu.ModuleExamCore/Entities/EntityQuestionOption.cs`

> **⚠️ LƯU Ý:** Entity này có foreign key `ExamQuestionId`, nên cần `EntityExamQuestion` tồn tại trước.

```csharp
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SLK.TryEdu.Abstract;

namespace SLK.TryEdu.ModuleExamCore.Entities;

[Table("question_options")]
public class EntityQuestionOption : EntityBase
{
    [Required]
    public int ExamQuestionId { get; set; }

    [Required]
    [MaxLength(200)]
    public string Label { get; set; } = string.Empty; // e.g. "A", "B"

    [Required]
    [Column(TypeName = "text")]
    public string Content { get; set; } = string.Empty;

    [Required]
    public bool IsCorrect { get; set; } = false;

    public int DisplayOrder { get; set; }

    [ForeignKey(nameof(ExamQuestionId))]
    public virtual EntityExamQuestion Question { get; set; } = null!;
}
```

#### 1.5. `EntityExamTemplateQuestion.cs`

**File:** `src/SLK.TryEdu.ModuleExamCore/Entities/EntityExamTemplateQuestion.cs`

> **⚠️ LƯU Ý:** Entity này có foreign keys `ExamTemplateSectionId` và `ExamQuestionId`, nên cần cả 2 entities tồn tại trước.

```csharp
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SLK.TryEdu.Abstract;

namespace SLK.TryEdu.ModuleExamCore.Entities;

[Table("exam_template_questions")]
public class EntityExamTemplateQuestion : EntityBase
{
    [Required]
    public int ExamTemplateSectionId { get; set; }

    [Required]
    public int ExamQuestionId { get; set; }

    [Required]
    public int Order { get; set; }

    [Column(TypeName = "decimal(5,2)")]
    public decimal? OverridePoint { get; set; }

    [Column(TypeName = "jsonb")]
    public string? Constraints { get; set; } // time limit per question, shuffle flag...

    [ForeignKey(nameof(ExamTemplateSectionId))]
    public virtual EntityExamTemplateSection Section { get; set; } = null!;

    [ForeignKey(nameof(ExamQuestionId))]
    public virtual EntityExamQuestion Question { get; set; } = null!;
}
```

#### 1.6. `EntityExam.cs` (Published Exam Snapshot)

> **⚠️ LƯU Ý:** `EntityExam` là **snapshot/instance** được generate từ `EntityExamTemplate`. Vì có foreign key `ExamTemplateId` (required), nên **PHẢI** tạo `EntityExamTemplate` trước `EntityExam`.

**File:** `src/SLK.TryEdu.ModuleExamCore/Entities/EntityExam.cs`

```csharp
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SLK.TryEdu.Abstract;

namespace SLK.TryEdu.ModuleExamCore.Entities;

[Table("exams")]
public class EntityExam : EntityBase
{
    [Required]
    public int ExamTemplateId { get; set; } // ⚠️ Foreign key → cần ExamTemplate tồn tại trước

    [Required, MaxLength(255)]
    public string Title { get; set; } = string.Empty;

    [MaxLength(500)]
    public string Slug { get; set; } = string.Empty; // URL-friendly

    [Column(TypeName = "decimal(12,2)")]
    public decimal PriceCoins { get; set; } = 200;

    public int DurationMinutes { get; set; }

    [Column(TypeName = "jsonb")]
    public string SnapshotData { get; set; } = string.Empty; // sections + questions snapshot

    [Required]
    [MaxLength(20)]
    public string Status { get; set; } = "Draft"; // Draft, Published, Archived

    public DateTime? PublishedAt { get; set; }

    [ForeignKey(nameof(ExamTemplateId))]
    public virtual EntityExamTemplate Template { get; set; } = null!;
}
```

#### 1.7. `EntityExamSubmission.cs`

**File:** `src/SLK.TryEdu.ModuleExamCore/Entities/EntityExamSubmission.cs`

> **⚠️ LƯU Ý:** Entity này có foreign key `ExamId`, nên cần `EntityExam` tồn tại trước.

```csharp
[Table("exam_submissions")]
public class EntityExamSubmission : EntityBase
{
    [Required]
    public int ExamId { get; set; }

    [Required]
    public int UserId { get; set; }

    [Required]
    [MaxLength(20)]
    public string Status { get; set; } = "InProgress"; // InProgress, Submitted, Graded

    public DateTime? StartedAt { get; set; }
    public DateTime? SubmittedAt { get; set; }

    [Column(TypeName = "decimal(5,2)")]
    public decimal? Score { get; set; }

    [Column(TypeName = "decimal(5,2)")]
    public decimal? Percentage { get; set; }

    [Column(TypeName = "jsonb")]
    public string? Answers { get; set; } // All answers snapshot

    [Column(TypeName = "jsonb")]
    public string? AIGradingResult { get; set; } // AI grading results

    [ForeignKey(nameof(ExamId))]
    public virtual EntityExam Exam { get; set; } = null!;

    [ForeignKey(nameof(UserId))]
    public virtual EntityUser User { get; set; } = null!;

    public virtual ICollection<EntityExamAttemptQuestion> AttemptQuestions { get; set; } = new List<EntityExamAttemptQuestion>();
}
```

#### 1.8. `EntityExamAttemptQuestion.cs`

**File:** `src/SLK.TryEdu.ModuleExamCore/Entities/EntityExamAttemptQuestion.cs`

> **⚠️ LƯU Ý:** Entity này có foreign keys đến `EntityExamSubmission` và `EntityExamQuestion`, nên cần cả 2 entities tồn tại trước.

```csharp
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SLK.TryEdu.Abstract;

namespace SLK.TryEdu.ModuleExamCore.Entities;

[Table("exam_attempt_questions")]
public class EntityExamAttemptQuestion : EntityBase
{
    [Required]
    public int ExamSubmissionId { get; set; } // ⚠️ Foreign key → cần ExamSubmission tồn tại trước

    [Required]
    public int ExamQuestionId { get; set; } // ⚠️ Foreign key → cần ExamQuestion tồn tại trước

    public int? QuestionOptionId { get; set; } // nếu MCQ

    [Column(TypeName = "jsonb")]
    public string? UserAnswer { get; set; } // essay / fill-in answers

    [Column(TypeName = "decimal(5,2)")]
    public decimal? Score { get; set; }

    public bool IsCorrect { get; set; }

    [ForeignKey(nameof(ExamSubmissionId))]
    public virtual EntityExamSubmission Submission { get; set; } = null!;

    [ForeignKey(nameof(ExamQuestionId))]
    public virtual EntityExamQuestion Question { get; set; } = null!;
}
```

#### 1.10. `EntityExamQuestionGroup.cs` (Optional - cho Reading/Listening passages)

**File:** `src/SLK.TryEdu.ModuleExamCore/Entities/EntityExamQuestionGroup.cs`

```csharp
[Table("exam_question_groups")]
public class EntityExamQuestionGroup : EntityBase
{
    [Required, MaxLength(255)]
    public string Title { get; set; } = string.Empty;

    [Column(TypeName = "text")]
    public string? PassageText { get; set; } // Reading passage text

    [MaxLength(500)]
    public string? AudioUrl { get; set; } // Listening audio URL

    [Column(TypeName = "jsonb")]
    public string? Images { get; set; } // Array of image URLs

    [MaxLength(50)]
    public string Skill { get; set; } = "Reading"; // Reading, Listening

    [MaxLength(20)]
    public string Level { get; set; } = "B1";

    public virtual ICollection<EntityExamQuestion> Questions { get; set; } = new List<EntityExamQuestion>();
}
```

**Checklist:**
- [ ] File đã tạo
- [ ] Support cho Reading passages và Listening audio
- [ ] Foreign key relationship với EntityExamQuestion

Sau đó thêm `GroupId` foreign key trong `EntityExamQuestion` (đã có trường `GroupId`).

#### 1.11. `EntityLanguage.cs` (Multi-language support)

**File:** `src/SLK.TryEdu.ModuleExamCore/Entities/EntityLanguage.cs`

```csharp
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SLK.TryEdu.Abstract;

namespace SLK.TryEdu.ModuleExamCore.Entities;

[Table("languages")]
public class EntityLanguage : EntityBase
{
    [Required]
    [MaxLength(10)]
    public string LanguageCode { get; set; } = string.Empty; // en, vi, ja, etc.

    [Required]
    [MaxLength(100)]
    public string LanguageName { get; set; } = string.Empty; // English, Tiếng Việt, etc.

    [Required]
    [MaxLength(100)]
    public string NativeName { get; set; } = string.Empty; // English, Tiếng Việt, etc.

    [MaxLength(500)]
    public string? FlagIconUrl { get; set; }

    [Required]
    public bool IsActive { get; set; } = true;

    [Required]
    public int DisplayOrder { get; set; } = 0;
}
```

#### 1.12. `EntityExamCategory.cs` (Exam categories)

**File:** `src/SLK.TryEdu.ModuleExamCore/Entities/EntityExamCategory.cs`

```csharp
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SLK.TryEdu.Abstract;

namespace SLK.TryEdu.ModuleExamCore.Entities;

[Table("exam_categories")]
public class EntityExamCategory : EntityBase
{
    [Required]
    public int LanguageId { get; set; } // Foreign key to EntityLanguage

    [Required]
    [MaxLength(50)]
    public string CategoryCode { get; set; } = string.Empty; // IELTS, TOEFL, etc.

    [Required]
    [MaxLength(255)]
    public string CategoryName { get; set; } = string.Empty;

    [MaxLength(1000)]
    public string? Description { get; set; }

    [MaxLength(500)]
    public string? IconUrl { get; set; }

    [Required]
    public int DisplayOrder { get; set; } = 0;

    [Required]
    public bool IsActive { get; set; } = true;

    [ForeignKey(nameof(LanguageId))]
    public virtual EntityLanguage Language { get; set; } = null!;
}
```

> **Giải thích thứ tự logic tổng hợp:**
> 1. **EntityExamTemplate** (blueprint) - không có dependencies
> 2. **EntityExamTemplateSection** - có FK `ExamTemplateId` → cần ExamTemplate trước
> 3. **EntityExamQuestion** (question bank) - không có dependencies
> 4. **EntityQuestionOption** - có FK `ExamQuestionId` → cần ExamQuestion trước
> 5. **EntityExamTemplateQuestion** - có FK `ExamTemplateSectionId` và `ExamQuestionId` → cần cả 2 trước
> 6. **EntityLanguage** - không có dependencies
> 7. **EntityExamCategory** - có FK `LanguageId` → cần Language trước
> 8. **EntityExamQuestionGroup** - không có dependencies (optional)
> 9. **EntityExam** - có FK `ExamTemplateId` → cần ExamTemplate trước
> 10. **EntityExamSubmission** - có FK `ExamId` → cần Exam trước
> 11. **EntityExamAttemptQuestion** - có FK `ExamSubmissionId` và `ExamQuestionId` → cần cả 2 trước
> 12. **EntityExamPurchase** - có FK `ExamId` → cần Exam trước

### 🔧 Bước 2: EntityRegister cho ModuleExam

**File:** `src/SLK.TryEdu.ModuleExam/Classes/EntityRegister.cs`

```csharp
using Microsoft.EntityFrameworkCore;
using SLK.TryEdu.ModuleExamCore.Entities;

namespace SLK.TryEdu.ModuleExam.Classes;

public static class EntityRegister
{
    public static void RegisterEntities(ModelBuilder builder)
    {
        builder.Entity<EntityExamTemplate>(entity =>
        {
            entity.HasAlternateKey(e => e.Guid);
            entity.HasIndex(e => e.Slug).IsUnique();
            entity.Property(e => e.PassingScore).HasPrecision(5, 2);
        });

        builder.Entity<EntityExamTemplateSection>(entity =>
        {
            entity.HasAlternateKey(e => e.Guid);
            entity.HasIndex(e => new { e.ExamTemplateId, e.Order }).IsUnique();
            entity.Property(e => e.WeightPercentage).HasPrecision(5, 2);
            
            // Foreign key relationship
            entity.HasOne(e => e.ExamTemplate)
                .WithMany(t => t.Sections)
                .HasForeignKey(e => e.ExamTemplateId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        builder.Entity<EntityExamQuestion>(entity =>
        {
            entity.HasAlternateKey(e => e.Guid);
            entity.HasIndex(e => new { e.QuestionType, e.Skill, e.Level, e.IsActive });
            entity.HasIndex(e => e.GroupId); // Index for optional GroupId
            entity.Property(e => e.DefaultPoint).HasPrecision(5, 2);
        });

        builder.Entity<EntityQuestionOption>(entity =>
        {
            entity.HasAlternateKey(e => e.Guid);
            entity.HasIndex(e => e.ExamQuestionId);
            
            // Foreign key relationship
            entity.HasOne(e => e.Question)
                .WithMany(q => q.Options)
                .HasForeignKey(e => e.ExamQuestionId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        builder.Entity<EntityExamTemplateQuestion>(entity =>
        {
            entity.HasAlternateKey(e => e.Guid);
            entity.HasIndex(e => new { e.ExamTemplateSectionId, e.Order }).IsUnique();
            entity.Property(e => e.OverridePoint).HasPrecision(5, 2);
            
            // Foreign key relationships
            entity.HasOne(e => e.Section)
                .WithMany(s => s.TemplateQuestions)
                .HasForeignKey(e => e.ExamTemplateSectionId)
                .OnDelete(DeleteBehavior.Cascade);
                
            entity.HasOne(e => e.Question)
                .WithMany()
                .HasForeignKey(e => e.ExamQuestionId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        builder.Entity<EntityExam>(entity =>
        {
            entity.HasAlternateKey(e => e.Guid);
            entity.HasIndex(e => e.Slug).IsUnique();
            entity.HasIndex(e => e.ExamTemplateId);
            entity.Property(e => e.PriceCoins).HasPrecision(12, 2);
            
            // Foreign key relationship
            entity.HasOne(e => e.Template)
                .WithMany()
                .HasForeignKey(e => e.ExamTemplateId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        builder.Entity<EntityExamSubmission>(entity =>
        {
            entity.HasAlternateKey(e => e.Guid);
            entity.HasIndex(e => new { e.ExamId, e.UserId });
            entity.Property(e => e.Score).HasPrecision(5, 2);
            entity.Property(e => e.Percentage).HasPrecision(5, 2);
            
            // Foreign key relationships
            entity.HasOne(e => e.Exam)
                .WithMany()
                .HasForeignKey(e => e.ExamId)
                .OnDelete(DeleteBehavior.Restrict);
                
            entity.HasOne(e => e.User)
                .WithMany()
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        builder.Entity<EntityExamAttemptQuestion>(entity =>
        {
            entity.HasAlternateKey(e => e.Guid);
            entity.HasIndex(e => e.ExamSubmissionId);
            entity.HasIndex(e => e.ExamQuestionId);
            entity.Property(e => e.Score).HasPrecision(5, 2);
            
            // Foreign key relationships
            entity.HasOne(e => e.Submission)
                .WithMany(s => s.AttemptQuestions)
                .HasForeignKey(e => e.ExamSubmissionId)
                .OnDelete(DeleteBehavior.Cascade);
                
            entity.HasOne(e => e.Question)
                .WithMany()
                .HasForeignKey(e => e.ExamQuestionId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        builder.Entity<EntityExamPurchase>(entity =>
        {
            entity.HasAlternateKey(e => e.Guid);
            entity.HasIndex(e => new { e.ExamId, e.UserId }).IsUnique();
            entity.HasIndex(e => e.UserId);
            entity.Property(e => e.PricePaid).HasPrecision(12, 2);
            entity.Property(e => e.DiscountAmount).HasPrecision(12, 2);
            
            // Foreign key relationships
            entity.HasOne(e => e.Exam)
                .WithMany()
                .HasForeignKey(e => e.ExamId)
                .OnDelete(DeleteBehavior.Restrict);
                
            entity.HasOne(e => e.User)
                .WithMany()
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        builder.Entity<EntityExamQuestionGroup>(entity =>
        {
            entity.HasAlternateKey(e => e.Guid);
            entity.HasIndex(e => new { e.Skill, e.Level });
        });

        builder.Entity<EntityLanguage>(entity =>
        {
            entity.HasAlternateKey(e => e.Guid);
            entity.HasIndex(e => e.LanguageCode).IsUnique();
            entity.HasIndex(e => e.DisplayOrder);
        });

        builder.Entity<EntityExamCategory>(entity =>
        {
            entity.HasAlternateKey(e => e.Guid);
            entity.HasIndex(e => new { e.CategoryCode, e.LanguageId }).IsUnique();
            entity.HasIndex(e => e.LanguageId);
            
            // Foreign key relationship
            entity.HasOne(e => e.Language)
                .WithMany()
                .HasForeignKey(e => e.LanguageId)
                .OnDelete(DeleteBehavior.Restrict);
        });
        
        builder.Entity<EntityExamQuestionGroup>(entity =>
        {
            entity.HasAlternateKey(e => e.Guid);
            entity.HasIndex(e => new { e.Skill, e.Level });
        });
        
        // Cập nhật lại EntityExamQuestion để thêm foreign key đến Group (sau khi đã register Group)
        // Note: Phải configure lại sau khi EntityExamQuestionGroup đã được register
        builder.Entity<EntityExamQuestion>(entity =>
        {
            // Optional foreign key to Group
            entity.HasOne<EntityExamQuestionGroup>()
                .WithMany(g => g.Questions)
                .HasForeignKey(e => e.GroupId)
                .OnDelete(DeleteBehavior.SetNull);
        });
    }
}
```

### 🔧 Bước 3: Register trong DbContext

```csharp
protected override void OnModelCreating(ModelBuilder builder)
{
    base.OnModelCreating(builder);

    SLK.TryEdu.ModuleExam.Classes.EntityRegister.RegisterEntities(builder);
}
```

### 🔧 Bước 4: Tạo Migration

```bash
cd src/SLK.TryEdu.Db
dotnet ef migrations add AddExamQuestionBank --startup-project ../SLK.TryEdu.WebHost
```

> Kiểm tra migration đảm bảo các bảng trên + indexes.

### 🔧 Bước 5: Test Migration & Seed Data

- Update database, verify bằng `\d exam_*`.
- Seed script đề xuất:
  - 1 template IELTS General
  - 4 sections (Reading/Listening/Writing/Speaking)
  - 3 câu hỏi mẫu mỗi section
  - 1 bộ đáp án MCQ

#### 1.9. `EntityExamPurchase.cs` (Mua bài thi bằng coin)

**File:** `src/SLK.TryEdu.ModuleExamCore/Entities/EntityExamPurchase.cs`

> **⚠️ LƯU Ý:** Entity này có foreign key `ExamId`, nên cần `EntityExam` tồn tại trước.

```csharp
[Table("exam_purchases")]
public class EntityExamPurchase : EntityBase
{
    [Required]
    public int ExamId { get; set; }

    [Required]
    public int UserId { get; set; }

    [Required]
    [Column(TypeName = "decimal(12,2)")]
    public decimal PricePaid { get; set; } // Coin amount paid

    [Column(TypeName = "decimal(12,2)")]
    public decimal? DiscountAmount { get; set; } // Discount from referral code

    public int? ReferralCodeId { get; set; }

    public int? CoinTransactionId { get; set; } // Link to coin_transactions

    [Required]
    [MaxLength(20)]
    public string Status { get; set; } = "Purchased"; // Purchased, Used, Expired

    public DateTime? PurchasedAt { get; set; }

    [ForeignKey(nameof(ExamId))]
    public virtual EntityExam Exam { get; set; } = null!;

    [ForeignKey(nameof(UserId))]
    public virtual EntityUser User { get; set; } = null!;
}
```

**Checklist:**
- [ ] File đã tạo
- [ ] Unique (ExamId, UserId) - một user chỉ mua một lần
- [ ] Foreign keys: ExamId, UserId, ReferralCodeId, CoinTransactionId
- [ ] Status: Purchased, Used, Expired

---

### ✅ MODULEEXAM - ACCEPTANCE CRITERIA

- [ ] `EntityExamTemplate` đã tạo (1.1) - **PHẢI TẠO TRƯỚC**
- [ ] `EntityExamTemplateSection` đã tạo (1.2) - có FK ExamTemplateId
- [ ] `EntityExamQuestion` đã tạo (1.3) - question bank
- [ ] `EntityQuestionOption` đã tạo (1.4) - có FK ExamQuestionId
- [ ] `EntityExamTemplateQuestion` đã tạo (1.5) - có FK ExamTemplateSectionId và ExamQuestionId
- [ ] `EntityLanguage` đã tạo (1.11) - multi-language support
- [ ] `EntityExamCategory` đã tạo (1.12) - có FK LanguageId
- [ ] `EntityExamQuestionGroup` đã tạo (1.10) - optional, cho Reading/Listening passages
- [ ] `EntityExam` đã tạo (1.6) - **CÓ FK ExamTemplateId** → cần ExamTemplate trước
- [ ] `EntityExamSubmission` đã tạo (1.7) - có FK ExamId
- [ ] `EntityExamAttemptQuestion` đã tạo (1.8) - có FK ExamSubmissionId và ExamQuestionId
- [ ] `EntityExamPurchase` đã tạo (1.9) - có FK ExamId
- [ ] EntityRegister cấu hình indexes/precision đầy đủ
- [ ] EntityRegister cấu hình foreign keys đầy đủ
- [ ] Migration `AddExamQuestionBank` chạy thành công
- [ ] Seed data mẫu tạo được template + câu hỏi + languages + categories
- [ ] API (hoặc Repo) có thể:
  - Tạo template → thêm section → gán câu hỏi
  - Publish template → tạo `exams`
  - Mua exam → tạo `exam_purchases`
  - Sinh attempt → lưu câu trả lời & chấm điểm

---

## 🔔 MODULE 14: MODULENOTIFICATION - NOTIFICATION SYSTEM (DEMO PHASE)

### 📊 Database Tables Cần Tạo:

1. **notifications** - Thông báo trong hệ thống (đã có EntityNoTifiCation trong Abstract)
2. **email_templates** - Email templates cho các loại email
3. **notification_preferences** - Tùy chọn thông báo của user

### 🔧 Bước 1: Tạo Entity Models

#### 1.1. `EntityNotification.cs` (Đã có trong Abstract)

**File:** `src/SLK.TryEdu.Abstract/Entities/EntityNoTifiCation.cs`

Entity đã tồn tại với các trường:
- TitleEn, TitleVi
- Href
- Guid_NoTifiCation, Guid_User
- Guid_UserNoTify (array)
- Avatar
- Check (read status)
- Module

**Checklist:**
- [x] File đã tồn tại
- [ ] EntityRegister đã cấu hình
- [ ] Indexes cho Guid_User, Check, Module

#### 1.2. `EntityEmailTemplate.cs`

**File:** `src/SLK.TryEdu.ModuleNotificationCore/Entities/EntityEmailTemplate.cs`

```csharp
[Table("email_templates")]
public class EntityEmailTemplate : EntityBase
{
    [Required]
    [MaxLength(100)]
    public string TemplateCode { get; set; } = string.Empty; // Unique: EMAIL_VERIFICATION, PARTNER_APPROVAL, etc.

    [Required]
    [MaxLength(255)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [MaxLength(255)]
    public string Subject { get; set; } = string.Empty;

    [Required]
    [Column(TypeName = "text")]
    public string BodyHtml { get; set; } = string.Empty; // HTML template

    [Column(TypeName = "text")]
    public string? BodyText { get; set; } // Plain text version

    [MaxLength(500)]
    public string? Variables { get; set; } // JSON: available variables for template

    [Required]
    [MaxLength(20)]
    public string Language { get; set; } = "vi"; // vi, en

    [Required]
    public bool IsActive { get; set; } = true;

    [MaxLength(500)]
    public string? Description { get; set; }
}
```

#### 1.3. `EntityNotificationPreference.cs`

**File:** `src/SLK.TryEdu.ModuleNotificationCore/Entities/EntityNotificationPreference.cs`

```csharp
[Table("notification_preferences")]
public class EntityNotificationPreference : EntityBase
{
    [Required]
    public int UserId { get; set; }

    [Required]
    [MaxLength(50)]
    public string NotificationType { get; set; } = string.Empty; // Email, SMS, Push, InApp

    [Required]
    [MaxLength(100)]
    public string EventType { get; set; } = string.Empty; // CourseEnrolled, ExamGraded, CoinPurchased, etc.

    [Required]
    public bool IsEnabled { get; set; } = true;

    [ForeignKey(nameof(UserId))]
    public virtual EntityUser User { get; set; } = null!;
}
```

### 🔧 Bước 2: Tạo EntityRegister.cs

**File:** `src/SLK.TryEdu.ModuleNotification/Classes/EntityRegister.cs`

```csharp
using Microsoft.EntityFrameworkCore;
using SLK.TryEdu.Abstract;
using SLK.TryEdu.ModuleNotificationCore.Entities;

namespace SLK.TryEdu.ModuleNotification.Classes;

public class EntityRegister
{
    public static void RegisterEntities(ModelBuilder builder)
    {
        // Notification (đã có trong Abstract)
        builder.Entity<EntityNoTifiCation>(entity =>
        {
            entity.HasAlternateKey(e => e.Guid);
            entity.HasIndex(e => e.Guid_User);
            entity.HasIndex(e => new { e.Guid_User, e.Check });
            entity.HasIndex(e => e.Module);
        });

        // Email Templates
        builder.Entity<EntityEmailTemplate>(entity =>
        {
            entity.HasAlternateKey(e => e.Guid);
            entity.HasIndex(e => new { e.TemplateCode, e.Language }).IsUnique();
        });

        // Notification Preferences
        builder.Entity<EntityNotificationPreference>(entity =>
        {
            entity.HasAlternateKey(e => e.Guid);
            entity.HasIndex(e => new { e.UserId, e.NotificationType, e.EventType }).IsUnique();
        });
    }
}
```

### ✅ MODULENOTIFICATION - ACCEPTANCE CRITERIA

- [x] EntityNoTifiCation.cs đã tồn tại
- [ ] EntityEmailTemplate.cs đã tạo
- [ ] EntityNotificationPreference.cs đã tạo
- [ ] EntityRegister.cs đã tạo
- [ ] Migration thành công
- [ ] Tables đã tạo
- [ ] Seed data (email templates mẫu)
- [ ] Test queries thành công

---

## ⚙️ MODULE 15: MODULESETTING - SYSTEM SETTINGS & USER PREFERENCES (DEMO PHASE)

### 📊 Database Tables Cần Tạo:

1. **system_settings** - Cấu hình hệ thống
2. **user_preferences** - Tùy chọn của user (language, theme, etc.)
3. **content_approval_workflow** - Workflow phê duyệt nội dung (US7.2)

### 🔧 Bước 1: Tạo Entity Models

#### 1.1. `EntitySystemSetting.cs`

**File:** `src/SLK.TryEdu.ModuleSettingCore/Entities/EntitySystemSetting.cs`

```csharp
[Table("system_settings")]
public class EntitySystemSetting : EntityBase
{
    [Required]
    [MaxLength(100)]
    public string Key { get; set; } = string.Empty; // Unique key

    [Required]
    [MaxLength(500)]
    public string Value { get; set; } = string.Empty;

    [MaxLength(255)]
    public string? Description { get; set; }

    [Required]
    [MaxLength(50)]
    public string Category { get; set; } = "General"; // General, Email, Payment, Security, etc.

    [Required]
    [MaxLength(20)]
    public string DataType { get; set; } = "String"; // String, Number, Boolean, JSON

    [Required]
    public bool IsPublic { get; set; } = false; // Public settings can be read by frontend
}
```

#### 1.2. `EntityUserPreference.cs`

**File:** `src/SLK.TryEdu.ModuleSettingCore/Entities/EntityUserPreference.cs`

```csharp
[Table("user_preferences")]
public class EntityUserPreference : EntityBase
{
    [Required]
    public int UserId { get; set; }

    [Required]
    [MaxLength(50)]
    public string PreferenceKey { get; set; } = string.Empty; // language, theme, timezone, etc.

    [MaxLength(500)]
    public string? PreferenceValue { get; set; }

    [ForeignKey(nameof(UserId))]
    public virtual EntityUser User { get; set; } = null!;
}
```

#### 1.3. `EntityContentApproval.cs`

**File:** `src/SLK.TryEdu.ModuleSettingCore/Entities/EntityContentApproval.cs`

```csharp
[Table("content_approvals")]
public class EntityContentApproval : EntityBase
{
    [Required]
    [MaxLength(50)]
    public string ContentType { get; set; } = string.Empty; // Course, Exam, BlogPost

    [Required]
    public int ContentId { get; set; } // ID of course/exam/blog post

    [Required]
    public int SubmittedByUserId { get; set; } // Teacher/Admin who submitted

    [Required]
    [MaxLength(20)]
    public string Status { get; set; } = "Pending"; // Pending, Approved, Rejected

    public int? ReviewedByUserId { get; set; } // Admin who reviewed

    public DateTime? ReviewedAt { get; set; }

    [Column(TypeName = "text")]
    public string? ReviewComments { get; set; }

    [MaxLength(500)]
    public string? RejectionReason { get; set; }

    [ForeignKey(nameof(SubmittedByUserId))]
    public virtual EntityUser SubmittedBy { get; set; } = null!;

    [ForeignKey(nameof(ReviewedByUserId))]
    public virtual EntityUser? ReviewedBy { get; set; }
}
```

### 🔧 Bước 2: Cập nhật EntityRegister.cs

**File:** `src/SLK.TryEdu.ModuleSetting/Classes/EntityRegister.cs`

```csharp
using Microsoft.EntityFrameworkCore;
using SLK.TryEdu.ModuleSettingCore;

namespace SLK.TryEdu.ModuleSetting.Classes
{
    public class EntityRegister
    {
        public static void RegisterEntities(ModelBuilder builder)
        {
            // Company & Office (đã có)
            builder.Entity<EntityCompany>(entity =>
            {
                entity.HasAlternateKey(e => e.Guid);
                entity.HasIndex(e => e.CompanyEmail).IsUnique();
            });

            builder.Entity<EntityOffice>(entity =>
            {
                entity.HasAlternateKey(e => e.Guid);
                entity.HasIndex(e => e.Email).IsUnique();
                entity.HasIndex(e => new { e.IsPrimary, e.Active });
            });

            // System Settings
            builder.Entity<EntitySystemSetting>(entity =>
            {
                entity.HasAlternateKey(e => e.Guid);
                entity.HasIndex(e => e.Key).IsUnique();
                entity.HasIndex(e => e.Category);
            });

            // User Preferences
            builder.Entity<EntityUserPreference>(entity =>
            {
                entity.HasAlternateKey(e => e.Guid);
                entity.HasIndex(e => new { e.UserId, e.PreferenceKey }).IsUnique();
            });

            // Content Approval
            builder.Entity<EntityContentApproval>(entity =>
            {
                entity.HasAlternateKey(e => e.Guid);
                entity.HasIndex(e => new { e.ContentType, e.ContentId }).IsUnique();
                entity.HasIndex(e => e.Status);
                entity.HasIndex(e => e.SubmittedByUserId);
            });
        }
    }
}
```

### ✅ MODULESETTING (Bổ sung) - ACCEPTANCE CRITERIA

- [x] EntityCompany.cs đã tồn tại
- [x] EntityOffice.cs đã tồn tại
- [ ] EntitySystemSetting.cs đã tạo
- [ ] EntityUserPreference.cs đã tạo
- [ ] EntityContentApproval.cs đã tạo
- [ ] EntityRegister.cs đã cập nhật
- [ ] Migration thành công
- [ ] Tables đã tạo
- [ ] Seed data (system settings mẫu)
- [ ] Test queries thành công

---

## 📚 MODULE 10: MODULELEARNING - LEARNING SYSTEM (EPIC 3 - DEMO PHASE)

### 📊 Database Tables Cần Tạo:

1. **learning_notes** - Ghi chú khi học
2. **lesson_progress** - Tiến độ học từng bài
3. **video_progress** - Tiến độ xem video
4. **quiz_submissions** - Kết quả quiz sau mỗi bài
5. **user_achievements** - Achievements của học viên
6. **learning_history** - Lịch sử hoạt động học tập

### 🔧 Bước 1: Tạo Entity Models

#### 1.1. `EntityLearningNote.cs`

**File:** `src/SLK.TryEdu.ModuleLearningCore/Entities/EntityLearningNote.cs`

```csharp
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SLK.TryEdu.Abstract;

namespace SLK.TryEdu.ModuleLearningCore.Entities;

[Table("learning_notes")]
public class EntityLearningNote : EntityBase
{
    [Required]
    public int UserId { get; set; }

    [Required]
    public int CourseId { get; set; }

    public int? CourseLessonId { get; set; } // Optional: note for specific lesson

    [Required]
    [MaxLength(255)]
    public string Title { get; set; } = string.Empty;

    [Column(TypeName = "text")]
    public string Content { get; set; } = string.Empty; // Rich text content

    [MaxLength(50)]
    public string? Tags { get; set; } // Comma-separated tags

    [ForeignKey(nameof(UserId))]
    public virtual EntityUser User { get; set; } = null!;

    [ForeignKey(nameof(CourseId))]
    public virtual EntityCourse Course { get; set; } = null!;
}
```

#### 1.2. `EntityLessonProgress.cs`

**File:** `src/SLK.TryEdu.ModuleLearningCore/Entities/EntityLessonProgress.cs`

```csharp
[Table("lesson_progress")]
public class EntityLessonProgress : EntityBase
{
    [Required]
    public int UserId { get; set; }

    [Required]
    public int CourseLessonId { get; set; }

    [Required]
    [MaxLength(20)]
    public string Status { get; set; } = "NotStarted"; // NotStarted, InProgress, Completed

    [Column(TypeName = "decimal(5,2)")]
    public decimal ProgressPercentage { get; set; } = 0;

    public DateTime? StartedAt { get; set; }
    public DateTime? CompletedAt { get; set; }
    public DateTime? LastAccessedAt { get; set; }

    [Column(TypeName = "int")]
    public int TimeSpentSeconds { get; set; } = 0; // Total time spent

    [ForeignKey(nameof(UserId))]
    public virtual EntityUser User { get; set; } = null!;

    [ForeignKey(nameof(CourseLessonId))]
    public virtual EntityCourseLesson Lesson { get; set; } = null!;
}
```

#### 1.3. `EntityVideoProgress.cs`

**File:** `src/SLK.TryEdu.ModuleLearningCore/Entities/EntityVideoProgress.cs`

```csharp
[Table("video_progress")]
public class EntityVideoProgress : EntityBase
{
    [Required]
    public int UserId { get; set; }

    [Required]
    public int CourseLessonId { get; set; }

    [MaxLength(500)]
    public string VideoUrl { get; set; } = string.Empty;

    [Column(TypeName = "int")]
    public int CurrentPositionSeconds { get; set; } = 0; // Last watched position

    [Column(TypeName = "int")]
    public int TotalDurationSeconds { get; set; } = 0;

    [Column(TypeName = "decimal(5,2)")]
    public decimal WatchPercentage { get; set; } = 0;

    public DateTime? LastWatchedAt { get; set; }

    [Required]
    public bool IsCompleted { get; set; } = false;

    [ForeignKey(nameof(UserId))]
    public virtual EntityUser User { get; set; } = null!;
}
```

#### 1.4. `EntityQuizSubmission.cs`

**File:** `src/SLK.TryEdu.ModuleLearningCore/Entities/EntityQuizSubmission.cs`

```csharp
[Table("quiz_submissions")]
public class EntityQuizSubmission : EntityBase
{
    [Required]
    public int UserId { get; set; }

    [Required]
    public int CourseLessonId { get; set; }

    [Column(TypeName = "jsonb")]
    public string Answers { get; set; } = string.Empty; // User answers

    [Column(TypeName = "decimal(5,2)")]
    public decimal Score { get; set; } = 0;

    [Column(TypeName = "decimal(5,2)")]
    public decimal MaxScore { get; set; } = 0;

    [Column(TypeName = "decimal(5,2)")]
    public decimal Percentage { get; set; } = 0;

    [Required]
    public bool IsPassed { get; set; } = false;

    public DateTime? SubmittedAt { get; set; }

    [Column(TypeName = "int")]
    public int AttemptNumber { get; set; } = 1; // Retry count

    [ForeignKey(nameof(UserId))]
    public virtual EntityUser User { get; set; } = null!;

    [ForeignKey(nameof(CourseLessonId))]
    public virtual EntityCourseLesson Lesson { get; set; } = null!;
}
```

#### 1.5. `EntityUserAchievement.cs`

**File:** `src/SLK.TryEdu.ModuleLearningCore/Entities/EntityUserAchievement.cs`

```csharp
[Table("user_achievements")]
public class EntityUserAchievement : EntityBase
{
    [Required]
    public int UserId { get; set; }

    [Required]
    [MaxLength(100)]
    public string AchievementCode { get; set; } = string.Empty; // e.g., "FIRST_COURSE", "PERFECT_SCORE"

    [Required]
    [MaxLength(255)]
    public string AchievementName { get; set; } = string.Empty;

    [MaxLength(500)]
    public string Description { get; set; } = string.Empty;

    [MaxLength(500)]
    public string IconUrl { get; set; } = string.Empty;

    [Column(TypeName = "jsonb")]
    public string? Metadata { get; set; } // Additional data

    public DateTime? UnlockedAt { get; set; }

    [ForeignKey(nameof(UserId))]
    public virtual EntityUser User { get; set; } = null!;
}
```

#### 1.6. `EntityLearningHistory.cs`

**File:** `src/SLK.TryEdu.ModuleLearningCore/Entities/EntityLearningHistory.cs`

```csharp
[Table("learning_history")]
public class EntityLearningHistory : EntityBase
{
    [Required]
    public int UserId { get; set; }

    [Required]
    [MaxLength(50)]
    public string ActivityType { get; set; } = string.Empty; // CourseEnroll, LessonComplete, QuizSubmit, ExamPurchase, etc.

    public int? CourseId { get; set; }
    public int? CourseLessonId { get; set; }
    public int? ExamId { get; set; }

    [MaxLength(500)]
    public string Description { get; set; } = string.Empty;

    [Column(TypeName = "jsonb")]
    public string? Metadata { get; set; } // Additional activity data

    [ForeignKey(nameof(UserId))]
    public virtual EntityUser User { get; set; } = null!;
}
```

### 🔧 Bước 2: Tạo EntityRegister.cs

**File:** `src/SLK.TryEdu.ModuleLearning/Classes/EntityRegister.cs`

```csharp
using Microsoft.EntityFrameworkCore;
using SLK.TryEdu.ModuleLearningCore.Entities;

namespace SLK.TryEdu.ModuleLearning.Classes;

public class EntityRegister
{
    public static void RegisterEntities(ModelBuilder builder)
    {
        builder.Entity<EntityLearningNote>(entity =>
        {
            entity.HasAlternateKey(e => e.Guid);
            entity.HasIndex(e => new { e.UserId, e.CourseId });
        });

        builder.Entity<EntityLessonProgress>(entity =>
        {
            entity.HasAlternateKey(e => e.Guid);
            entity.HasIndex(e => new { e.UserId, e.CourseLessonId }).IsUnique();
            entity.Property(e => e.ProgressPercentage).HasPrecision(5, 2);
        });

        builder.Entity<EntityVideoProgress>(entity =>
        {
            entity.HasAlternateKey(e => e.Guid);
            entity.HasIndex(e => new { e.UserId, e.CourseLessonId, e.VideoUrl }).IsUnique();
            entity.Property(e => e.WatchPercentage).HasPrecision(5, 2);
        });

        builder.Entity<EntityQuizSubmission>(entity =>
        {
            entity.HasAlternateKey(e => e.Guid);
            entity.HasIndex(e => new { e.UserId, e.CourseLessonId });
            entity.Property(e => e.Score).HasPrecision(5, 2);
            entity.Property(e => e.MaxScore).HasPrecision(5, 2);
            entity.Property(e => e.Percentage).HasPrecision(5, 2);
        });

        builder.Entity<EntityUserAchievement>(entity =>
        {
            entity.HasAlternateKey(e => e.Guid);
            entity.HasIndex(e => new { e.UserId, e.AchievementCode }).IsUnique();
        });

        builder.Entity<EntityLearningHistory>(entity =>
        {
            entity.HasAlternateKey(e => e.Guid);
            entity.HasIndex(e => new { e.UserId, e.DateCreated });
            entity.HasIndex(e => e.ActivityType);
        });
    }
}
```

### ✅ MODULELEARNING - ACCEPTANCE CRITERIA

- [ ] EntityLearningNote.cs đã tạo
- [ ] EntityLessonProgress.cs đã tạo
- [ ] EntityVideoProgress.cs đã tạo
- [ ] EntityQuizSubmission.cs đã tạo
- [ ] EntityUserAchievement.cs đã tạo
- [ ] EntityLearningHistory.cs đã tạo
- [ ] EntityRegister.cs đã tạo
- [ ] Migration thành công
- [ ] Tables đã tạo
- [ ] Test queries thành công

---

## 🆘 MODULE 11: MODULESUPPORT - FAQ & HELP VIDEOS (EPIC 6 - US6.1 - DEMO PHASE)

### 📊 Database Tables Cần Tạo:

1. **faqs** - Câu hỏi thường gặp
2. **faq_categories** - Danh mục FAQ
3. **help_videos** - Video hướng dẫn
4. **help_video_categories** - Danh mục video

### 🔧 Bước 1: Tạo Entity Models

#### 1.1. `EntityFAQCategory.cs`

**File:** `src/SLK.TryEdu.ModuleSupportCore/Entities/EntityFAQCategory.cs`

```csharp
[Table("faq_categories")]
public class EntityFAQCategory : EntityBase
{
    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    [MaxLength(500)]
    public string Description { get; set; } = string.Empty;

    [MaxLength(50)]
    public string Icon { get; set; } = string.Empty;

    [Required]
    public int Order { get; set; } = 0;

    [Required]
    public bool IsActive { get; set; } = true;

    public virtual ICollection<EntityFAQ> FAQs { get; set; } = new List<EntityFAQ>();
}
```

#### 1.2. `EntityFAQ.cs`

**File:** `src/SLK.TryEdu.ModuleSupportCore/Entities/EntityFAQ.cs`

```csharp
[Table("faqs")]
public class EntityFAQ : EntityBase
{
    [Required]
    public int CategoryId { get; set; }

    [Required]
    [MaxLength(255)]
    public string Question { get; set; } = string.Empty;

    [Required]
    [Column(TypeName = "text")]
    public string Answer { get; set; } = string.Empty;

    [Required]
    public int Order { get; set; } = 0;

    [Required]
    public int ViewCount { get; set; } = 0;

    [Required]
    public bool IsActive { get; set; } = true;

    [MaxLength(500)]
    public string? Tags { get; set; } // Comma-separated tags for search

    [ForeignKey(nameof(CategoryId))]
    public virtual EntityFAQCategory Category { get; set; } = null!;
}
```

#### 1.3. `EntityHelpVideoCategory.cs`

**File:** `src/SLK.TryEdu.ModuleSupportCore/Entities/EntityHelpVideoCategory.cs`

```csharp
[Table("help_video_categories")]
public class EntityHelpVideoCategory : EntityBase
{
    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    [MaxLength(500)]
    public string Description { get; set; } = string.Empty;

    [Required]
    public int Order { get; set; } = 0;

    [Required]
    public bool IsActive { get; set; } = true;

    public virtual ICollection<EntityHelpVideo> Videos { get; set; } = new List<EntityHelpVideo>();
}
```

#### 1.4. `EntityHelpVideo.cs`

**File:** `src/SLK.TryEdu.ModuleSupportCore/Entities/EntityHelpVideo.cs`

```csharp
[Table("help_videos")]
public class EntityHelpVideo : EntityBase
{
    [Required]
    public int CategoryId { get; set; }

    [Required]
    [MaxLength(255)]
    public string Title { get; set; } = string.Empty;

    [MaxLength(1000)]
    public string Description { get; set; } = string.Empty;

    [Required]
    [MaxLength(500)]
    public string VideoUrl { get; set; } = string.Empty;

    [MaxLength(500)]
    public string ThumbnailUrl { get; set; } = string.Empty;

    [Column(TypeName = "int")]
    public int DurationSeconds { get; set; } = 0;

    [Required]
    public int Order { get; set; } = 0;

    [Required]
    public int ViewCount { get; set; } = 0;

    [Required]
    public bool IsActive { get; set; } = true;

    [MaxLength(500)]
    public string? Tags { get; set; } // For search

    [ForeignKey(nameof(CategoryId))]
    public virtual EntityHelpVideoCategory Category { get; set; } = null!;
}
```

### 🔧 Bước 2: Tạo EntityRegister.cs

**File:** `src/SLK.TryEdu.ModuleSupport/Classes/EntityRegister.cs`

```csharp
using Microsoft.EntityFrameworkCore;
using SLK.TryEdu.ModuleSupportCore.Entities;

namespace SLK.TryEdu.ModuleSupport.Classes;

public class EntityRegister
{
    public static void RegisterEntities(ModelBuilder builder)
    {
        builder.Entity<EntityFAQCategory>(entity =>
        {
            entity.HasAlternateKey(e => e.Guid);
            entity.HasIndex(e => e.Order);
        });

        builder.Entity<EntityFAQ>(entity =>
        {
            entity.HasAlternateKey(e => e.Guid);
            entity.HasIndex(e => e.CategoryId);
            entity.HasIndex(e => new { e.IsActive, e.Order });
            // Full-text search index for Question and Answer
        });

        builder.Entity<EntityHelpVideoCategory>(entity =>
        {
            entity.HasAlternateKey(e => e.Guid);
            entity.HasIndex(e => e.Order);
        });

        builder.Entity<EntityHelpVideo>(entity =>
        {
            entity.HasAlternateKey(e => e.Guid);
            entity.HasIndex(e => e.CategoryId);
            entity.HasIndex(e => new { e.IsActive, e.Order });
        });
    }
}
```

### ✅ MODULESUPPORT (US6.1) - ACCEPTANCE CRITERIA

- [ ] EntityFAQCategory.cs đã tạo
- [ ] EntityFAQ.cs đã tạo
- [ ] EntityHelpVideoCategory.cs đã tạo
- [ ] EntityHelpVideo.cs đã tạo
- [ ] EntityRegister.cs đã tạo
- [ ] Migration thành công
- [ ] Tables đã tạo
- [ ] Seed data (sample FAQs và help videos)
- [ ] Test queries thành công

---

## 👨‍💼 MODULE 5: MODULEEMPLOYEE - EMPLOYEE MANAGEMENT

### 📊 Database Tables Cần Tạo:

1. **employee** - Thông tin nhân viên
2. **employee_documents** - Tài liệu của nhân viên

### 🔧 Bước 1: Tạo Entity Models

#### 1.1. `EntityEmployee.cs` (Đã có)

**File:** `src/SLK.TryEdu.ModuleEmployeeCore/Entities/EntityEmployee.cs`

Entity đã tồn tại với các trường:
- Avatar, LastName, FirstName, Email, CitizenID, Phone
- DateOfBirth, Gender
- Education_Level, ProfessionalQualification
- JobGuid, JobName, OfficeGuid, OfficeName
- Active

**Checklist:**
- [x] File đã tạo
- [ ] EntityRegister đã cấu hình
- [ ] Foreign keys: JobGuid, OfficeGuid

---

#### 1.2. `EntityEmployeeDocument.cs` (Đã có)

**File:** `src/SLK.TryEdu.ModuleEmployeeCore/Entities/EntityEmployeeDocument.cs`

Entity đã tồn tại với các trường:
- GuidEmployeePost, NameEmployeePost
- GuidEmployee
- NameFile, TypeFile, FolderName

**Checklist:**
- [x] File đã tạo
- [ ] EntityRegister đã cấu hình
- [ ] Foreign key: GuidEmployee

---

### 🔧 Bước 2: Tạo EntityRegister.cs

**File:** `src/SLK.TryEdu.ModuleEmployee/Classes/EntityRegister.cs`

```csharp
using Microsoft.EntityFrameworkCore;
using SLK.TryEdu.ModuleEmployeeCore;

namespace SLK.TryEdu.ModuleEmployee.Classes
{
    public class EntityRegister
    {
        public static void RegisterEntities(ModelBuilder builder)
        {
            builder.Entity<EntityEmployee>(entity =>
            {
                entity.HasAlternateKey(e => e.Guid);
                entity.HasIndex(e => e.Email).IsUnique();
                entity.HasIndex(e => e.JobGuid);
                entity.HasIndex(e => e.OfficeGuid);
            });

            builder.Entity<EntityEmployeeDocument>(entity =>
            {
                entity.HasAlternateKey(e => e.Guid);
                entity.HasIndex(e => e.GuidEmployee);
            });
        }
    }
}
```

**Checklist:**
- [ ] File đã tạo
- [ ] Register Employee với unique Email
- [ ] Register EmployeeDocument với indexes

---

### ✅ MODULEEMPLOYEE - ACCEPTANCE CRITERIA

- [x] EntityEmployee.cs đã tạo
- [x] EntityEmployeeDocument.cs đã tạo
- [ ] EntityRegister.cs đã tạo
- [ ] Migration thành công
- [ ] Tables đã tạo
- [ ] Test queries thành công

---

## ⚙️ MODULE 6: MODULESETTING - SYSTEM SETTINGS

### 📊 Database Tables Cần Tạo:

1. **setting_company** - Thông tin công ty
2. **setting_office** - Chi nhánh/văn phòng

### 🔧 Bước 1: Tạo Entity Models

#### 1.1. `EntityCompany.cs` (Đã có)

**File:** `src/SLK.TryEdu.ModuleSettingCore/Entities/EntityCompany.cs`

Entity đã tồn tại với các trường:
- CompanyLogo, CompanyName, CompanyWebSite
- CompanyPhone, CompanyEmail, CompanyOverview

**Checklist:**
- [x] File đã tạo
- [ ] EntityRegister đã cấu hình
- [ ] Unique constraints nếu cần

---

#### 1.2. `EntityOffice.cs` (Đã có)

**File:** `src/SLK.TryEdu.ModuleSettingCore/Entities/EntityOffice.cs`

Entity đã tồn tại với các trường:
- Avatar, Name, Address, Phone, Email
- IsPrimary, Active

**Checklist:**
- [x] File đã tạo
- [ ] EntityRegister đã cấu hình
- [ ] Unique constraint cho IsPrimary

---

### 🔧 Bước 2: Tạo EntityRegister.cs

**File:** `src/SLK.TryEdu.ModuleSetting/Classes/EntityRegister.cs`

```csharp
using Microsoft.EntityFrameworkCore;
using SLK.TryEdu.ModuleSettingCore;

namespace SLK.TryEdu.ModuleSetting.Classes
{
    public class EntityRegister
    {
        public static void RegisterEntities(ModelBuilder builder)
        {
            builder.Entity<EntityCompany>(entity =>
            {
                entity.HasAlternateKey(e => e.Guid);
                entity.HasIndex(e => e.CompanyEmail).IsUnique();
            });

            builder.Entity<EntityOffice>(entity =>
            {
                entity.HasAlternateKey(e => e.Guid);
                entity.HasIndex(e => e.Email).IsUnique();
                entity.HasIndex(e => new { e.IsPrimary, e.Active });
            });
        }
    }
}
```

**Checklist:**
- [ ] File đã tạo
- [ ] Register Company với unique Email
- [ ] Register Office với unique Email và IsPrimary index

---

### ✅ MODULESETTING - ACCEPTANCE CRITERIA

- [x] EntityCompany.cs đã tạo
- [x] EntityOffice.cs đã tạo
- [ ] EntityRegister.cs đã tạo
- [ ] Migration thành công
- [ ] Tables đã tạo
- [ ] Test queries thành công

---

## 📝 MODULE 7: MODULEGRADING - GRADING & FEEDBACK SYSTEM (EPIC 4)

### 📊 Database Tables Cần Tạo:

1. **exam_grading_feedback** - Feedback chi tiết từ giáo viên
2. **exam_grading_history** - Lịch sử chấm điểm (nếu cần audit)

### 🔧 Bước 1: Tạo Entity Models

#### 1.1. `EntityExamGradingFeedback.cs`

**File:** `src/SLK.TryEdu.ModuleGradingCore/Entities/EntityExamGradingFeedback.cs`

```csharp
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SLK.TryEdu.Abstract;

namespace SLK.TryEdu.ModuleGradingCore.Entities;

[Table("exam_grading_feedback")]
public class EntityExamGradingFeedback : EntityBase
{
    [Required]
    public int ExamSubmissionId { get; set; }

    [Required]
    public int TeacherId { get; set; }

    [Required]
    [MaxLength(50)]
    public string SectionType { get; set; } = string.Empty; // Writing, Speaking

    [Column(TypeName = "decimal(5,2)")]
    public decimal? Score { get; set; }

    [Column(TypeName = "text")]
    public string? Feedback { get; set; }

    [Column(TypeName = "jsonb")]
    public string? DetailedFeedback { get; set; } // Structured feedback

    [Required]
    [MaxLength(20)]
    public string Status { get; set; } = "Draft"; // Draft, Submitted, Reviewed

    public DateTime? GradedAt { get; set; }

    [ForeignKey(nameof(ExamSubmissionId))]
    public virtual EntityExamSubmission ExamSubmission { get; set; } = null!;

    [ForeignKey(nameof(TeacherId))]
    public virtual EntityUser Teacher { get; set; } = null!;
}
```

**Checklist:**
- [ ] File đã tạo
- [ ] Foreign keys: ExamSubmissionId, TeacherId
- [ ] Status: Draft, Submitted, Reviewed

---

### 🔧 Bước 2-6: Tương tự các module trước

- [ ] EntityRegister.cs
- [ ] Register trong DbContext
- [ ] Migration: `AddGradingModuleTables`
- [ ] Test migration
- [ ] Seed data (nếu cần)

---

### ✅ MODULEGRADING - ACCEPTANCE CRITERIA

- [ ] EntityExamGradingFeedback.cs đã tạo
- [ ] Migration thành công
- [ ] Tables đã tạo
- [ ] Test queries thành công

---

## 💳 MODULE 8: MODULEPAYMENT - PAYMENT & VOUCHER SYSTEM (EPIC 5)

### 📊 Database Tables Cần Tạo:

1. **payments** - Giao dịch thanh toán từ external gateway
2. **vouchers** - Mã voucher/khuyến mại
3. **voucher_usage** - Lịch sử sử dụng voucher

### 🔧 Bước 1: Tạo Entity Models

#### 1.1. `EntityPayment.cs`

**File:** `src/SLK.TryEdu.ModulePaymentCore/Entities/EntityPayment.cs`

```csharp
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SLK.TryEdu.Abstract;

namespace SLK.TryEdu.ModulePaymentCore.Entities;

[Table("payments")]
public class EntityPayment : EntityBase
{
    [Required]
    public int UserId { get; set; }

    [Required]
    [MaxLength(50)]
    public string PaymentMethod { get; set; } = string.Empty; // VNPay, MoMo, Banking

    [Required]
    [Column(TypeName = "decimal(12,2)")]
    public decimal Amount { get; set; }

    [Required]
    [MaxLength(20)]
    public string Status { get; set; } = "Pending"; // Pending, Success, Failed, Cancelled

    [MaxLength(100)]
    public string? TransactionId { get; set; } // External gateway transaction ID

    [MaxLength(500)]
    public string? GatewayResponse { get; set; } // JSON response from gateway

    public int? CoinTransactionId { get; set; } // Link to coin_transactions

    [ForeignKey(nameof(UserId))]
    public virtual EntityUser User { get; set; } = null!;
}
```

#### 1.2. `EntityVoucher.cs`

```csharp
[Table("vouchers")]
public class EntityVoucher : EntityBase
{
    [Required]
    [MaxLength(50)]
    public string Code { get; set; } = string.Empty; // Unique code

    [Required]
    [MaxLength(255)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [MaxLength(20)]
    public string DiscountType { get; set; } = "Percentage"; // Percentage, FixedAmount

    [Required]
    [Column(TypeName = "decimal(12,2)")]
    public decimal DiscountValue { get; set; }

    [Column(TypeName = "decimal(12,2)")]
    public decimal? MinimumPurchase { get; set; }

    [Required]
    public int MaxUsage { get; set; } = 1; // -1 = unlimited

    [Required]
    public int UsedCount { get; set; } = 0;

    [Required]
    public bool IsActive { get; set; } = true;

    public DateTime? StartDate { get; set; }
    public DateTime? ExpiryDate { get; set; }

    [MaxLength(500)]
    public string? Description { get; set; }
}
```

#### 1.3. `EntityVoucherUsage.cs`

```csharp
[Table("voucher_usage")]
public class EntityVoucherUsage : EntityBase
{
    [Required]
    public int VoucherId { get; set; }

    [Required]
    public int UserId { get; set; }

    [Required]
    [Column(TypeName = "decimal(12,2)")]
    public decimal DiscountAmount { get; set; }

    public int? CoinTransactionId { get; set; }
    public int? CourseEnrollmentId { get; set; }
    public int? ExamId { get; set; }

    [ForeignKey(nameof(VoucherId))]
    public virtual EntityVoucher Voucher { get; set; } = null!;

    [ForeignKey(nameof(UserId))]
    public virtual EntityUser User { get; set; } = null!;
}
```

---

### ✅ MODULEPAYMENT - ACCEPTANCE CRITERIA

- [ ] EntityPayment.cs đã tạo
- [ ] EntityVoucher.cs đã tạo
- [ ] EntityVoucherUsage.cs đã tạo
- [ ] Migration thành công
- [ ] Tables đã tạo

---

## 🆘 MODULE 9: MODULESUPPORT - SUPPORT & COMMUNITY SYSTEM (EPIC 6)

### 📊 Database Tables Cần Tạo:

1. **support_tickets** - Ticket hỗ trợ
2. **support_ticket_messages** - Tin nhắn trong ticket
3. **forum_categories** - Danh mục forum
4. **forum_posts** - Bài viết forum
5. **forum_replies** - Trả lời bài viết
6. **study_groups** - Nhóm học tập
7. **study_group_members** - Thành viên nhóm

### 🔧 Bước 1: Tạo Entity Models

#### 1.1. `EntitySupportTicket.cs`

```csharp
[Table("support_tickets")]
public class EntitySupportTicket : EntityBase
{
    [Required]
    public int UserId { get; set; }

    [Required]
    [MaxLength(255)]
    public string Subject { get; set; } = string.Empty;

    [Required]
    [MaxLength(20)]
    public string Status { get; set; } = "Open"; // Open, InProgress, Resolved, Closed

    [Required]
    [MaxLength(20)]
    public string Priority { get; set; } = "Medium"; // Low, Medium, High, Urgent

    [MaxLength(50)]
    public string? Category { get; set; }

    public int? AssignedToUserId { get; set; } // Support staff

    public DateTime? ResolvedAt { get; set; }

    [ForeignKey(nameof(UserId))]
    public virtual EntityUser User { get; set; } = null!;
}
```

#### 1.2. `EntitySupportTicketMessage.cs`

```csharp
[Table("support_ticket_messages")]
public class EntitySupportTicketMessage : EntityBase
{
    [Required]
    public int TicketId { get; set; }

    [Required]
    public int UserId { get; set; }

    [Required]
    [Column(TypeName = "text")]
    public string Message { get; set; } = string.Empty;

    [MaxLength(500)]
    public string? AttachmentUrl { get; set; }

    [ForeignKey(nameof(TicketId))]
    public virtual EntitySupportTicket Ticket { get; set; } = null!;

    [ForeignKey(nameof(UserId))]
    public virtual EntityUser User { get; set; } = null!;
}
```

#### 1.3. `EntityForumCategory.cs`

**File:** `src/SLK.TryEdu.ModuleSupportCore/Entities/EntityForumCategory.cs`

```csharp
[Table("forum_categories")]
public class EntityForumCategory : EntityBase
{
    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    [MaxLength(500)]
    public string Description { get; set; } = string.Empty;

    [MaxLength(50)]
    public string Icon { get; set; } = string.Empty;

    [Required]
    public int Order { get; set; } = 0;

    [Required]
    public bool IsActive { get; set; } = true;

    public virtual ICollection<EntityForumPost> Posts { get; set; } = new List<EntityForumPost>();
}
```

#### 1.4. `EntityForumPost.cs`

**File:** `src/SLK.TryEdu.ModuleSupportCore/Entities/EntityForumPost.cs`

```csharp
[Table("forum_posts")]
public class EntityForumPost : EntityBase
{
    [Required]
    public int CategoryId { get; set; }

    [Required]
    public int UserId { get; set; }

    [Required]
    [MaxLength(255)]
    public string Title { get; set; } = string.Empty;

    [Required]
    [Column(TypeName = "text")]
    public string Content { get; set; } = string.Empty;

    [Required]
    public int ViewCount { get; set; } = 0;

    [Required]
    public int ReplyCount { get; set; } = 0;

    [Required]
    public int LikeCount { get; set; } = 0;

    [Required]
    [MaxLength(20)]
    public string Status { get; set; } = "Published"; // Draft, Published, Locked, Deleted

    public DateTime? PinnedUntil { get; set; } // Pin post to top

    [MaxLength(500)]
    public string? Tags { get; set; } // Comma-separated tags

    [ForeignKey(nameof(CategoryId))]
    public virtual EntityForumCategory Category { get; set; } = null!;

    [ForeignKey(nameof(UserId))]
    public virtual EntityUser User { get; set; } = null!;

    public virtual ICollection<EntityForumReply> Replies { get; set; } = new List<EntityForumReply>();
}
```

#### 1.5. `EntityForumReply.cs`

**File:** `src/SLK.TryEdu.ModuleSupportCore/Entities/EntityForumReply.cs`

```csharp
[Table("forum_replies")]
public class EntityForumReply : EntityBase
{
    [Required]
    public int PostId { get; set; }

    [Required]
    public int UserId { get; set; }

    public int? ParentReplyId { get; set; } // For nested replies

    [Required]
    [Column(TypeName = "text")]
    public string Content { get; set; } = string.Empty;

    [Required]
    public int LikeCount { get; set; } = 0;

    [Required]
    [MaxLength(20)]
    public string Status { get; set; } = "Published"; // Published, Deleted

    [Required]
    public bool IsBestAnswer { get; set; } = false; // Mark as best answer

    [ForeignKey(nameof(PostId))]
    public virtual EntityForumPost Post { get; set; } = null!;

    [ForeignKey(nameof(UserId))]
    public virtual EntityUser User { get; set; } = null!;

    [ForeignKey(nameof(ParentReplyId))]
    public virtual EntityForumReply? ParentReply { get; set; }
}
```

#### 1.6. `EntityStudyGroup.cs`

**File:** `src/SLK.TryEdu.ModuleSupportCore/Entities/EntityStudyGroup.cs`

```csharp
[Table("study_groups")]
public class EntityStudyGroup : EntityBase
{
    [Required]
    public int CreatedByUserId { get; set; }

    [Required]
    [MaxLength(255)]
    public string Name { get; set; } = string.Empty;

    [MaxLength(1000)]
    public string Description { get; set; } = string.Empty;

    [MaxLength(500)]
    public string? CoverImageUrl { get; set; } = string.Empty;

    [Required]
    [MaxLength(20)]
    public string Privacy { get; set; } = "Public"; // Public, Private, InviteOnly

    [Required]
    public int MaxMembers { get; set; } = 50;

    [Required]
    public int CurrentMemberCount { get; set; } = 0;

    [Required]
    [MaxLength(20)]
    public string Status { get; set; } = "Active"; // Active, Archived, Deleted

    public int? CourseId { get; set; } // Optional: group for specific course

    [ForeignKey(nameof(CreatedByUserId))]
    public virtual EntityUser CreatedBy { get; set; } = null!;

    public virtual ICollection<EntityStudyGroupMember> Members { get; set; } = new List<EntityStudyGroupMember>();
}
```

#### 1.7. `EntityStudyGroupMember.cs`

**File:** `src/SLK.TryEdu.ModuleSupportCore/Entities/EntityStudyGroupMember.cs`

```csharp
[Table("study_group_members")]
public class EntityStudyGroupMember : EntityBase
{
    [Required]
    public int StudyGroupId { get; set; }

    [Required]
    public int UserId { get; set; }

    [Required]
    [MaxLength(20)]
    public string Role { get; set; } = "Member"; // Owner, Admin, Member

    [Required]
    [MaxLength(20)]
    public string Status { get; set; } = "Active"; // Active, Left, Removed

    public DateTime? JoinedAt { get; set; }

    [ForeignKey(nameof(StudyGroupId))]
    public virtual EntityStudyGroup StudyGroup { get; set; } = null!;

    [ForeignKey(nameof(UserId))]
    public virtual EntityUser User { get; set; } = null!;
}
```

### 🔧 Bước 2: Tạo EntityRegister.cs

**File:** `src/SLK.TryEdu.ModuleSupport/Classes/EntityRegister.cs`

```csharp
using Microsoft.EntityFrameworkCore;
using SLK.TryEdu.ModuleSupportCore.Entities;

namespace SLK.TryEdu.ModuleSupport.Classes;

public class EntityRegister
{
    public static void RegisterEntities(ModelBuilder builder)
    {
        // Support Tickets (đã có ở trên - US6.1)
        
        // Forum
        builder.Entity<EntityForumCategory>(entity =>
        {
            entity.HasAlternateKey(e => e.Guid);
            entity.HasIndex(e => e.Order);
        });

        builder.Entity<EntityForumPost>(entity =>
        {
            entity.HasAlternateKey(e => e.Guid);
            entity.HasIndex(e => new { e.CategoryId, e.DateCreated });
            entity.HasIndex(e => new { e.Status, e.DateCreated });
        });

        builder.Entity<EntityForumReply>(entity =>
        {
            entity.HasAlternateKey(e => e.Guid);
            entity.HasIndex(e => new { e.PostId, e.DateCreated });
            entity.HasIndex(e => e.ParentReplyId);
        });

        // Study Groups
        builder.Entity<EntityStudyGroup>(entity =>
        {
            entity.HasAlternateKey(e => e.Guid);
            entity.HasIndex(e => new { e.Status, e.DateCreated });
            entity.HasIndex(e => e.CourseId);
        });

        builder.Entity<EntityStudyGroupMember>(entity =>
        {
            entity.HasAlternateKey(e => e.Guid);
            entity.HasIndex(e => new { e.StudyGroupId, e.UserId }).IsUnique();
            entity.HasIndex(e => e.UserId);
        });
    }
}
```

### ✅ MODULESUPPORT (US6.2, US6.3) - ACCEPTANCE CRITERIA

- [ ] EntitySupportTicket.cs đã tạo
- [ ] EntitySupportTicketMessage.cs đã tạo
- [ ] EntityForumCategory.cs đã tạo
- [ ] EntityForumPost.cs đã tạo
- [ ] EntityForumReply.cs đã tạo
- [ ] EntityStudyGroup.cs đã tạo
- [ ] EntityStudyGroupMember.cs đã tạo
- [ ] EntityRegister.cs đã tạo
- [ ] Migration thành công
- [ ] Tables đã tạo
- [ ] Test queries thành công

---

## 🛡️ MODULE 12: MODULESECURITY - SECURITY & COMPLIANCE (EPIC 7 - US7.3, US7.4 - OFFICIAL PHASE)

### 📊 Database Tables Cần Tạo:

1. **security_audit_logs** - Audit logs cho security events
2. **security_login_attempts** - Lịch sử đăng nhập
3. **compliance_records** - Bản ghi tuân thủ
4. **data_privacy_requests** - Yêu cầu quyền riêng tư (GDPR)

### 🔧 Bước 1: Tạo Entity Models

#### 1.1. `EntitySecurityAuditLog.cs`

**File:** `src/SLK.TryEdu.ModuleSecurityCore/Entities/EntitySecurityAuditLog.cs`

```csharp
[Table("security_audit_logs")]
public class EntitySecurityAuditLog : EntityBase
{
    [Required]
    [MaxLength(50)]
    public string EventType { get; set; } = string.Empty; // Login, Logout, PermissionChange, DataAccess, etc.

    [Required]
    public int? UserId { get; set; } // Nullable for system events

    [MaxLength(50)]
    public string? IpAddress { get; set; }

    [MaxLength(500)]
    public string? UserAgent { get; set; }

    [Required]
    [MaxLength(20)]
    public string Severity { get; set; } = "Info"; // Info, Warning, Error, Critical

    [Required]
    [MaxLength(255)]
    public string Action { get; set; } = string.Empty; // What was done

    [Column(TypeName = "text")]
    public string? Details { get; set; } // JSON details

    [Column(TypeName = "text")]
    public string? RequestPath { get; set; }

    [MaxLength(10)]
    public string? HttpMethod { get; set; }

    [Column(TypeName = "int")]
    public int? StatusCode { get; set; }

    [ForeignKey(nameof(UserId))]
    public virtual EntityUser? User { get; set; }
}
```

#### 1.2. `EntitySecurityLoginAttempt.cs`

**File:** `src/SLK.TryEdu.ModuleSecurityCore/Entities/EntitySecurityLoginAttempt.cs`

```csharp
[Table("security_login_attempts")]
public class EntitySecurityLoginAttempt : EntityBase
{
    [MaxLength(255)]
    public string? Email { get; set; } // Email used in attempt

    [MaxLength(50)]
    public string? IpAddress { get; set; }

    [MaxLength(500)]
    public string? UserAgent { get; set; }

    [Required]
    [MaxLength(20)]
    public string Status { get; set; } = "Failed"; // Success, Failed, Blocked

    [MaxLength(500)]
    public string? FailureReason { get; set; } // Invalid password, Account locked, etc.

    public int? UserId { get; set; } // If successful, link to user

    [ForeignKey(nameof(UserId))]
    public virtual EntityUser? User { get; set; }
}
```

#### 1.3. `EntityComplianceRecord.cs`

**File:** `src/SLK.TryEdu.ModuleSecurityCore/Entities/EntityComplianceRecord.cs`

```csharp
[Table("compliance_records")]
public class EntityComplianceRecord : EntityBase
{
    [Required]
    [MaxLength(50)]
    public string ComplianceType { get; set; } = string.Empty; // GDPR, DataRetention, SecurityPolicy, etc.

    [Required]
    [MaxLength(100)]
    public string RecordType { get; set; } = string.Empty; // DataDeletion, DataExport, ConsentChange, etc.

    [Required]
    public int? UserId { get; set; } // User affected

    [Required]
    [MaxLength(20)]
    public string Status { get; set; } = "Pending"; // Pending, Completed, Failed

    [Column(TypeName = "text")]
    public string? Description { get; set; }

    [Column(TypeName = "text")]
    public string? Details { get; set; } // JSON details

    public DateTime? CompletedAt { get; set; }

    public int? ProcessedByUserId { get; set; } // Admin who processed

    [ForeignKey(nameof(UserId))]
    public virtual EntityUser? User { get; set; }
}
```

#### 1.4. `EntityDataPrivacyRequest.cs`

**File:** `src/SLK.TryEdu.ModuleSecurityCore/Entities/EntityDataPrivacyRequest.cs`

```csharp
[Table("data_privacy_requests")]
public class EntityDataPrivacyRequest : EntityBase
{
    [Required]
    public int UserId { get; set; }

    [Required]
    [MaxLength(50)]
    public string RequestType { get; set; } = string.Empty; // DataExport, DataDeletion, DataCorrection, ConsentWithdrawal

    [Required]
    [MaxLength(20)]
    public string Status { get; set; } = "Pending"; // Pending, InProgress, Completed, Rejected

    [Column(TypeName = "text")]
    public string? Description { get; set; }

    [MaxLength(500)]
    public string? VerificationToken { get; set; } // For email verification

    public DateTime? VerifiedAt { get; set; }

    public DateTime? CompletedAt { get; set; }

    [MaxLength(500)]
    public string? ResultUrl { get; set; } // Link to exported data

    [Column(TypeName = "text")]
    public string? RejectionReason { get; set; }

    public int? ProcessedByUserId { get; set; }

    [ForeignKey(nameof(UserId))]
    public virtual EntityUser User { get; set; } = null!;
}
```

### 🔧 Bước 2: Tạo EntityRegister.cs

**File:** `src/SLK.TryEdu.ModuleSecurity/Classes/EntityRegister.cs`

```csharp
using Microsoft.EntityFrameworkCore;
using SLK.TryEdu.ModuleSecurityCore.Entities;

namespace SLK.TryEdu.ModuleSecurity.Classes;

public class EntityRegister
{
    public static void RegisterEntities(ModelBuilder builder)
    {
        builder.Entity<EntitySecurityAuditLog>(entity =>
        {
            entity.HasAlternateKey(e => e.Guid);
            entity.HasIndex(e => new { e.EventType, e.DateCreated });
            entity.HasIndex(e => e.UserId);
            entity.HasIndex(e => e.IpAddress);
        });

        builder.Entity<EntitySecurityLoginAttempt>(entity =>
        {
            entity.HasAlternateKey(e => e.Guid);
            entity.HasIndex(e => new { e.Email, e.DateCreated });
            entity.HasIndex(e => e.IpAddress);
            entity.HasIndex(e => e.Status);
        });

        builder.Entity<EntityComplianceRecord>(entity =>
        {
            entity.HasAlternateKey(e => e.Guid);
            entity.HasIndex(e => new { e.ComplianceType, e.Status });
            entity.HasIndex(e => e.UserId);
        });

        builder.Entity<EntityDataPrivacyRequest>(entity =>
        {
            entity.HasAlternateKey(e => e.Guid);
            entity.HasIndex(e => new { e.UserId, e.RequestType });
            entity.HasIndex(e => e.Status);
            entity.HasIndex(e => e.VerificationToken);
        });
    }
}
```

### ✅ MODULESECURITY - ACCEPTANCE CRITERIA

- [ ] EntitySecurityAuditLog.cs đã tạo
- [ ] EntitySecurityLoginAttempt.cs đã tạo
- [ ] EntityComplianceRecord.cs đã tạo
- [ ] EntityDataPrivacyRequest.cs đã tạo
- [ ] EntityRegister.cs đã tạo
- [ ] Migration thành công
- [ ] Tables đã tạo
- [ ] Test queries thành công

---

## ⭐ MODULE 16: MODULECONTENT - RATINGS, REVIEWS & FAVORITES (DEMO PHASE)

### 📊 Database Tables Cần Tạo:

1. **course_ratings** - Đánh giá khóa học (1-5 sao)
2. **course_reviews** - Review chi tiết khóa học
3. **review_helpful_votes** - Vote hữu ích cho review
4. **course_favorites** - Khóa học yêu thích
5. **download_history** - Lịch sử download video
6. **course_categories** - Danh mục khóa học
7. **course_completion_certificates** - Chứng chỉ hoàn thành khóa học

### 🔧 Bước 1: Tạo Entity Models

#### 1.1. `EntityCourseRating.cs`

**File:** `src/SLK.TryEdu.ModuleContentCore/Entities/EntityCourseRating.cs`

```csharp
[Table("course_ratings")]
public class EntityCourseRating : EntityBase
{
    [Required]
    public int CourseId { get; set; }

    [Required]
    public int UserId { get; set; }

    [Required]
    [Column(TypeName = "decimal(3,2)")]
    public decimal Rating { get; set; } // 1.0 - 5.0

    [ForeignKey(nameof(CourseId))]
    public virtual EntityCourse Course { get; set; } = null!;

    [ForeignKey(nameof(UserId))]
    public virtual EntityUser User { get; set; } = null!;
}
```

#### 1.2. `EntityCourseReview.cs`

**File:** `src/SLK.TryEdu.ModuleContentCore/Entities/EntityCourseReview.cs`

```csharp
[Table("course_reviews")]
public class EntityCourseReview : EntityBase
{
    [Required]
    public int CourseId { get; set; }

    [Required]
    public int UserId { get; set; }

    [Required]
    [Column(TypeName = "text")]
    public string ReviewText { get; set; } = string.Empty;

    [Required]
    [Column(TypeName = "decimal(3,2)")]
    public decimal Rating { get; set; } // 1.0 - 5.0

    [Required]
    public int HelpfulCount { get; set; } = 0; // Số người thấy hữu ích

    [Required]
    [MaxLength(20)]
    public string Status { get; set; } = "Published"; // Published, Hidden, Deleted

    [ForeignKey(nameof(CourseId))]
    public virtual EntityCourse Course { get; set; } = null!;

    [ForeignKey(nameof(UserId))]
    public virtual EntityUser User { get; set; } = null!;

    public virtual ICollection<EntityReviewHelpfulVote> HelpfulVotes { get; set; } = new List<EntityReviewHelpfulVote>();
}
```

#### 1.2.1. `EntityReviewHelpfulVote.cs`

**File:** `src/SLK.TryEdu.ModuleContentCore/Entities/EntityReviewHelpfulVote.cs`

```csharp
[Table("review_helpful_votes")]
public class EntityReviewHelpfulVote : EntityBase
{
    [Required]
    public int ReviewId { get; set; }

    [Required]
    public int UserId { get; set; }

    [Required]
    public bool IsHelpful { get; set; } = true; // true = helpful, false = not helpful

    [ForeignKey(nameof(ReviewId))]
    public virtual EntityCourseReview Review { get; set; } = null!;

    [ForeignKey(nameof(UserId))]
    public virtual EntityUser User { get; set; } = null!;
}
```

#### 1.3. `EntityCourseFavorite.cs`

**File:** `src/SLK.TryEdu.ModuleContentCore/Entities/EntityCourseFavorite.cs`

```csharp
[Table("course_favorites")]
public class EntityCourseFavorite : EntityBase
{
    [Required]
    public int CourseId { get; set; }

    [Required]
    public int UserId { get; set; }

    [ForeignKey(nameof(CourseId))]
    public virtual EntityCourse Course { get; set; } = null!;

    [ForeignKey(nameof(UserId))]
    public virtual EntityUser User { get; set; } = null!;
}
```

#### 1.4. `EntityDownloadHistory.cs`

**File:** `src/SLK.TryEdu.ModuleContentCore/Entities/EntityDownloadHistory.cs`

```csharp
[Table("download_history")]
public class EntityDownloadHistory : EntityBase
{
    [Required]
    public int UserId { get; set; }

    [Required]
    public int CourseLessonId { get; set; }

    [MaxLength(500)]
    public string FileUrl { get; set; } = string.Empty;

    [MaxLength(100)]
    public string FileName { get; set; } = string.Empty;

    [Column(TypeName = "bigint")]
    public long FileSizeBytes { get; set; } = 0;

    [Required]
    [MaxLength(20)]
    public string Status { get; set; } = "Completed"; // InProgress, Completed, Failed

    public DateTime? DownloadedAt { get; set; }

    [ForeignKey(nameof(UserId))]
    public virtual EntityUser User { get; set; } = null!;

    [ForeignKey(nameof(CourseLessonId))]
    public virtual EntityCourseLesson Lesson { get; set; } = null!;
}
```

#### 1.5. `EntityCourseCategory.cs`

**File:** `src/SLK.TryEdu.ModuleContentCore/Entities/EntityCourseCategory.cs`

```csharp
[Table("course_categories")]
public class EntityCourseCategory : EntityBase
{
    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    [MaxLength(500)]
    public string Description { get; set; } = string.Empty;

    [MaxLength(500)]
    public string Slug { get; set; } = string.Empty; // URL-friendly

    [MaxLength(500)]
    public string? IconUrl { get; set; }

    [MaxLength(500)]
    public string? ImageUrl { get; set; }

    public int? ParentCategoryId { get; set; } // For nested categories

    [Required]
    public int Order { get; set; } = 0;

    [Required]
    public bool IsActive { get; set; } = true;

    [ForeignKey(nameof(ParentCategoryId))]
    public virtual EntityCourseCategory? ParentCategory { get; set; }

    public virtual ICollection<EntityCourseCategory> SubCategories { get; set; } = new List<EntityCourseCategory>();
}
```

#### 1.6. `EntityCourseCompletionCertificate.cs`

**File:** `src/SLK.TryEdu.ModuleContentCore/Entities/EntityCourseCompletionCertificate.cs`

```csharp
[Table("course_completion_certificates")]
public class EntityCourseCompletionCertificate : EntityBase
{
    [Required]
    public int CourseId { get; set; }

    [Required]
    public int UserId { get; set; }

    [Required]
    public int CourseEnrollmentId { get; set; }

    [Required]
    [MaxLength(100)]
    public string CertificateNumber { get; set; } = string.Empty; // Unique certificate number

    [MaxLength(500)]
    public string CertificateUrl { get; set; } = string.Empty; // PDF/Image URL

    [Required]
    public DateTime CompletedAt { get; set; }

    [Required]
    [Column(TypeName = "decimal(5,2)")]
    public decimal FinalScore { get; set; } = 0; // Final course score

    [MaxLength(500)]
    public string? VerificationCode { get; set; } // For certificate verification

    [ForeignKey(nameof(CourseId))]
    public virtual EntityCourse Course { get; set; } = null!;

    [ForeignKey(nameof(UserId))]
    public virtual EntityUser User { get; set; } = null!;

    [ForeignKey(nameof(CourseEnrollmentId))]
    public virtual EntityCourseEnrollment Enrollment { get; set; } = null!;
}
```

### 🔧 Bước 2: Cập nhật EntityRegister.cs

**File:** `src/SLK.TryEdu.ModuleContent/Classes/EntityRegister.cs`

```csharp
// Thêm vào EntityRegister hiện có
builder.Entity<EntityCourseRating>(entity =>
{
    entity.HasAlternateKey(e => e.Guid);
    entity.HasIndex(e => new { e.CourseId, e.UserId }).IsUnique();
    entity.Property(e => e.Rating).HasPrecision(3, 2);
});

builder.Entity<EntityCourseReview>(entity =>
{
    entity.HasAlternateKey(e => e.Guid);
    entity.HasIndex(e => new { e.CourseId, e.UserId }).IsUnique();
    entity.HasIndex(e => e.CourseId);
    entity.Property(e => e.Rating).HasPrecision(3, 2);
});

builder.Entity<EntityReviewHelpfulVote>(entity =>
{
    entity.HasAlternateKey(e => e.Guid);
    entity.HasIndex(e => new { e.ReviewId, e.UserId }).IsUnique();
});

builder.Entity<EntityCourseFavorite>(entity =>
{
    entity.HasAlternateKey(e => e.Guid);
    entity.HasIndex(e => new { e.CourseId, e.UserId }).IsUnique();
});

builder.Entity<EntityDownloadHistory>(entity =>
{
    entity.HasAlternateKey(e => e.Guid);
    entity.HasIndex(e => new { e.UserId, e.DownloadedAt });
});

builder.Entity<EntityCourseCategory>(entity =>
{
    entity.HasAlternateKey(e => e.Guid);
    entity.HasIndex(e => e.Slug).IsUnique();
    entity.HasIndex(e => e.ParentCategoryId);
});

builder.Entity<EntityCourseCompletionCertificate>(entity =>
{
    entity.HasAlternateKey(e => e.Guid);
    entity.HasIndex(e => new { e.CourseId, e.UserId }).IsUnique();
    entity.HasIndex(e => e.CertificateNumber).IsUnique();
    entity.HasIndex(e => e.VerificationCode);
    entity.Property(e => e.FinalScore).HasPrecision(5, 2);
});
```

### ✅ MODULECONTENT (Ratings & Reviews) - ACCEPTANCE CRITERIA

- [ ] EntityCourseRating.cs đã tạo
- [ ] EntityCourseReview.cs đã tạo
- [ ] EntityReviewHelpfulVote.cs đã tạo
- [ ] EntityCourseFavorite.cs đã tạo
- [ ] EntityDownloadHistory.cs đã tạo
- [ ] EntityCourseCategory.cs đã tạo
- [ ] EntityCourseCompletionCertificate.cs đã tạo
- [ ] EntityRegister.cs đã cập nhật
- [ ] Migration thành công
- [ ] Tables đã tạo
- [ ] Test queries thành công

---

## 📝 MODULE 13: MODULEBLOG - BLOG & ARTICLE MANAGEMENT (EPIC 7 - US7.5 - OFFICIAL PHASE)

### 📊 Database Tables Cần Tạo:

1. **blog_categories** - Danh mục blog
2. **blog_posts** - Bài viết blog
3. **blog_post_tags** - Tags cho bài viết
4. **blog_comments** - Bình luận bài viết

### 🔧 Bước 1: Tạo Entity Models

#### 1.1. `EntityBlogCategory.cs`

**File:** `src/SLK.TryEdu.ModuleBlogCore/Entities/EntityBlogCategory.cs`

```csharp
[Table("blog_categories")]
public class EntityBlogCategory : EntityBase
{
    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    [MaxLength(500)]
    public string Description { get; set; } = string.Empty;

    [MaxLength(500)]
    public string Slug { get; set; } = string.Empty; // URL-friendly

    [MaxLength(500)]
    public string? ImageUrl { get; set; }

    [Required]
    public int Order { get; set; } = 0;

    [Required]
    public bool IsActive { get; set; } = true;

    public virtual ICollection<EntityBlogPost> Posts { get; set; } = new List<EntityBlogPost>();
}
```

#### 1.2. `EntityBlogPost.cs`

**File:** `src/SLK.TryEdu.ModuleBlogCore/Entities/EntityBlogPost.cs`

```csharp
[Table("blog_posts")]
public class EntityBlogPost : EntityBase
{
    [Required]
    public int CategoryId { get; set; }

    [Required]
    public int AuthorId { get; set; } // Teacher or Admin

    [Required]
    [MaxLength(255)]
    public string Title { get; set; } = string.Empty;

    [MaxLength(500)]
    public string Slug { get; set; } = string.Empty; // URL-friendly

    [MaxLength(1000)]
    public string Excerpt { get; set; } = string.Empty; // Short description

    [Required]
    [Column(TypeName = "text")]
    public string Content { get; set; } = string.Empty; // Full content (HTML/Markdown)

    [MaxLength(500)]
    public string? FeaturedImageUrl { get; set; }

    [Required]
    [MaxLength(20)]
    public string Status { get; set; } = "Draft"; // Draft, Published, Archived

    [Required]
    public int ViewCount { get; set; } = 0;

    [Required]
    public int LikeCount { get; set; } = 0;

    [Required]
    public int CommentCount { get; set; } = 0;

    public DateTime? PublishedAt { get; set; }

    [MaxLength(500)]
    public string? MetaTitle { get; set; } // SEO

    [MaxLength(1000)]
    public string? MetaDescription { get; set; } // SEO

    [MaxLength(500)]
    public string? Tags { get; set; } // Comma-separated tags

    [ForeignKey(nameof(CategoryId))]
    public virtual EntityBlogCategory Category { get; set; } = null!;

    [ForeignKey(nameof(AuthorId))]
    public virtual EntityUser Author { get; set; } = null!;

    public virtual ICollection<EntityBlogComment> Comments { get; set; } = new List<EntityBlogComment>();
}
```

#### 1.3. `EntityBlogComment.cs`

**File:** `src/SLK.TryEdu.ModuleBlogCore/Entities/EntityBlogComment.cs`

```csharp
[Table("blog_comments")]
public class EntityBlogComment : EntityBase
{
    [Required]
    public int PostId { get; set; }

    [Required]
    public int UserId { get; set; }

    public int? ParentCommentId { get; set; } // For nested comments

    [Required]
    [Column(TypeName = "text")]
    public string Content { get; set; } = string.Empty;

    [Required]
    [MaxLength(20)]
    public string Status { get; set; } = "Published"; // Published, Pending, Spam, Deleted

    [Required]
    public int LikeCount { get; set; } = 0;

    [ForeignKey(nameof(PostId))]
    public virtual EntityBlogPost Post { get; set; } = null!;

    [ForeignKey(nameof(UserId))]
    public virtual EntityUser User { get; set; } = null!;

    [ForeignKey(nameof(ParentCommentId))]
    public virtual EntityBlogComment? ParentComment { get; set; }
}
```

### 🔧 Bước 2: Tạo EntityRegister.cs

**File:** `src/SLK.TryEdu.ModuleBlog/Classes/EntityRegister.cs`

```csharp
using Microsoft.EntityFrameworkCore;
using SLK.TryEdu.ModuleBlogCore.Entities;

namespace SLK.TryEdu.ModuleBlog.Classes;

public class EntityRegister
{
    public static void RegisterEntities(ModelBuilder builder)
    {
        builder.Entity<EntityBlogCategory>(entity =>
        {
            entity.HasAlternateKey(e => e.Guid);
            entity.HasIndex(e => e.Slug).IsUnique();
            entity.HasIndex(e => e.Order);
        });

        builder.Entity<EntityBlogPost>(entity =>
        {
            entity.HasAlternateKey(e => e.Guid);
            entity.HasIndex(e => e.Slug).IsUnique();
            entity.HasIndex(e => new { e.CategoryId, e.Status, e.PublishedAt });
            entity.HasIndex(e => e.AuthorId);
        });

        builder.Entity<EntityBlogComment>(entity =>
        {
            entity.HasAlternateKey(e => e.Guid);
            entity.HasIndex(e => new { e.PostId, e.DateCreated });
            entity.HasIndex(e => e.ParentCommentId);
        });
    }
}
```

### ✅ MODULEBLOG - ACCEPTANCE CRITERIA

- [ ] EntityBlogCategory.cs đã tạo
- [ ] EntityBlogPost.cs đã tạo
- [ ] EntityBlogComment.cs đã tạo
- [ ] EntityRegister.cs đã tạo
- [ ] Migration thành công
- [ ] Tables đã tạo
- [ ] Test queries thành công

---

---

## 📋 TỔNG KẾT - CHECKLIST TẤT CẢ MODULES

### ModuleCoin:
- [ ] coin_balances
- [ ] coin_transactions
- [ ] coin_exchange_rates

### ModulePartner:
- [ ] partner_centers
- [ ] referral_codes
- [ ] commission_transactions
- [ ] partner_tier_upgrade_history

### ModuleContent:
- [ ] courses
- [ ] course_lessons
- [ ] lesson_contents
- [ ] course_enrollments
- [ ] course_categories
- [ ] course_ratings
- [ ] course_reviews
- [ ] review_helpful_votes
- [ ] course_favorites
- [ ] download_history
- [ ] course_completion_certificates

### ModuleExam:
- [ ] exam_templates
- [ ] exam_template_sections
- [ ] exam_questions
- [ ] question_options
- [ ] exam_template_questions
- [ ] exams (published snapshot)
- [ ] exam_submissions
- [ ] exam_attempt_questions
- [ ] exam_purchases (mua bài thi bằng coin)

### ModuleUser (đã có + bổ sung):
- [ ] users (đã tồn tại)
- [ ] password_reset_tokens
- [ ] email_verification_tokens
- [ ] user_files

### ModuleEmployee:
- [ ] employee
- [ ] employee_documents

### ModuleSetting:
- [ ] setting_company
- [ ] setting_office

### ModuleContent (bổ sung):
- [ ] course_lessons
- [ ] lesson_contents

### ModuleEmployee:
- [ ] employee
- [ ] employee_documents

### ModuleSetting:
- [ ] setting_company
- [ ] setting_office

### ModuleGrading (EPIC 4 - DEMO Phase):
- [ ] exam_grading_feedback
- [ ] teacher_earnings
- [ ] teacher_earning_transactions

### ModulePayment (EPIC 5 - DEMO Phase):
- [ ] payments (external gateway transactions)
- [ ] vouchers
- [ ] voucher_usage
- [ ] refund_requests
- [ ] commission_payment_schedule

### ModuleLearning (EPIC 3 - DEMO Phase):
- [ ] learning_notes (ghi chú khi học)
- [ ] lesson_progress (tiến độ học từng bài)
- [ ] video_progress (tiến độ xem video)
- [ ] quiz_submissions (kết quả quiz sau mỗi bài)
- [ ] user_achievements (achievements của học viên)
- [ ] learning_history (lịch sử hoạt động học tập)

### ModuleSupport (EPIC 6 - DEMO Phase - US6.1):
- [ ] faqs (câu hỏi thường gặp)
- [ ] faq_categories (danh mục FAQ)
- [ ] help_videos (video hướng dẫn)
- [ ] help_video_categories (danh mục video)

### ModuleSupport (EPIC 6 - OFFICIAL Phase - US6.2, US6.3):
- [ ] support_tickets
- [ ] support_ticket_messages
- [ ] forum_categories
- [ ] forum_posts
- [ ] forum_replies
- [ ] study_groups
- [ ] study_group_members

### ModuleSecurity (EPIC 7 - OFFICIAL Phase - US7.3, US7.4):
- [ ] security_audit_logs
- [ ] security_login_attempts
- [ ] compliance_records
- [ ] data_privacy_requests

### ModuleBlog (EPIC 7 - OFFICIAL Phase - US7.5):
- [ ] blog_categories
- [ ] blog_posts
- [ ] blog_comments

### ModuleNotification (DEMO Phase):
- [ ] notifications (SETTING_NOTIFICATION - đã có)
- [ ] email_templates
- [ ] notification_preferences

### ModuleExam (Bổ sung):
- [ ] exam_question_groups (optional - cho Reading/Listening passages)

### ModuleContent (Bổ sung - DEMO Phase):
- [ ] course_ratings (đánh giá khóa học)
- [ ] course_reviews (review khóa học)
- [ ] review_helpful_votes (vote hữu ích cho review)
- [ ] course_favorites (yêu thích khóa học)
- [ ] download_history (lịch sử download video)
- [ ] course_categories (danh mục khóa học)
- [ ] course_completion_certificates (chứng chỉ hoàn thành khóa học)

### ModulePayment (Bổ sung - DEMO Phase):
- [ ] refund_requests (yêu cầu hoàn tiền)
- [ ] commission_payment_schedule (lịch thanh toán hoa hồng)

### ModuleGrading (Bổ sung - DEMO Phase):
- [ ] teacher_earnings (thu nhập giáo viên)
- [ ] teacher_earning_transactions (giao dịch thanh toán cho giáo viên)

### ModulePartner (Bổ sung - DEMO Phase):
- [ ] partner_tier_upgrade_history (lịch sử nâng cấp tier)

### ModuleUser (Bổ sung - DEMO Phase):
- [ ] password_reset_tokens (tokens reset password)
- [ ] email_verification_tokens (tokens xác thực email)
- [ ] user_files (quản lý file upload: avatar, CV, certificates)

---

## 📅 TIMELINE DATABASE CREATION (CHỈ TÍNH NGÀY LÀM VIỆC - KHÔNG TÍNH THỨ 7, CN)

### **PHASE 1: DEMO (27/11 - 29/12)** - 32 ngày làm việc

**Tuần 1-2 (27/11 - 10/12): Foundation & Core Modules**
- [ ] ModuleCoin (3 tables) - Ngày 3-5
- [ ] ModulePartner (3 tables) - Ngày 3-5
- [ ] ModuleContent (4 tables) - Ngày 3-5
- [ ] ModuleExam (12 tables) - Ngày 6-7 (9 + exam_question_groups + languages + exam_categories)
- [ ] ModuleLearning (6 tables) - Ngày 8-10
- [ ] ModuleSupport - FAQ (4 tables) - Ngày 8-10

**Tuần 3-4 (11/12 - 24/12): Extended Modules**
- [ ] ModuleEmployee (2 tables) - Ngày 11-12
- [ ] ModuleSetting (5 tables) - Ngày 11-12
- [ ] ModuleNotification (3 tables) - Ngày 13-14
- [ ] ModuleUser - Tokens & Files (3 tables) - Ngày 13-14
- [ ] ModuleContent - Ratings & Reviews (7 tables) - Ngày 15-16 (ratings + reviews + helpful_votes + favorites + download_history + categories + certificates)
- [ ] ModuleGrading (3 tables) - Ngày 15-16
- [ ] ModulePayment (5 tables) - Ngày 17-18
- [ ] ModulePartner - Tier Upgrade (1 table) - Ngày 19

**Tuần 5 (25/12 - 29/12): Testing & Refinement**
- [ ] Database testing & optimization
- [ ] Index optimization
- [ ] Seed data preparation

---

### **PHASE 2: OFFICIAL (30/12 - 26/01)** - 28 ngày làm việc

**Tuần 1 (30/12 - 05/01): Community & Support**
- [ ] ModuleSupport - Forum & Study Groups (7 tables) - Ngày 30/12 - 02/01
- [ ] Testing & integration

**Tuần 2 (06/01 - 12/01): Security & Compliance**
- [ ] ModuleSecurity (4 tables) - Ngày 06/01 - 09/01
- [ ] Testing & security audit

**Tuần 3 (13/01 - 19/01): Content Management**
- [ ] ModuleBlog (3 tables) - Ngày 13/01 - 16/01
- [ ] Testing & integration

**Tuần 4 (20/01 - 26/01): Final Testing & Optimization**
- [ ] Database performance optimization
- [ ] Final testing
- [ ] Production preparation

---

## 📊 TỔNG KẾT DATABASE TABLES

### **DEMO Phase (29/12):**
- **Tổng cộng: 54 tables**
  - ModuleCoin: 3
  - ModulePartner: 4 (3 + tier_upgrade_history)
  - ModuleContent: 11 (4 + categories + ratings + reviews + helpful_votes + favorites + download_history + certificates)
  - ModuleExam: 12 (9 + exam_question_groups + exam_categories + languages)
  - ModuleLearning: 6
  - ModuleSupport (US6.1): 4
  - ModuleEmployee: 2
  - ModuleSetting: 5 (2 + system_settings + user_preferences + content_approvals)
  - ModuleNotification: 3 (notifications đã có + email_templates + notification_preferences)
  - ModuleGrading: 3 (1 + teacher_earnings + teacher_earning_transactions)
  - ModulePayment: 5 (3 + refund_requests + commission_payment_schedule)
  - ModuleUser: 3 (password_reset_tokens + email_verification_tokens + user_files)

### **OFFICIAL Phase (26/01):**
- **Tổng cộng: 68 tables** (54 DEMO + 14 OFFICIAL)
  - ModuleSupport (US6.2, US6.3): 7
  - ModuleSecurity: 4
  - ModuleBlog: 3

### **Tổng cộng toàn bộ hệ thống: 68 tables**

---

> **Lưu ý:** 
> - **ModuleLearning** (EPIC 3) thuộc **DEMO Phase** - cần tạo database ngay
> - **ModuleSupport** (US6.1 - FAQ & Help Videos) thuộc **DEMO Phase** - cần tạo database ngay
> - **ModuleGrading, ModulePayment** thuộc **DEMO Phase** (cơ bản)
> - **ModuleSupport** (US6.2, US6.3), **ModuleSecurity**, **ModuleBlog** thuộc **OFFICIAL Phase** (30/12 - 26/01)
> - **Timeline chỉ tính ngày làm việc (Thứ 2 - Thứ 6), không tính Thứ 7 và Chủ Nhật**

---

## 🔧 COMMON STEPS FOR ALL MODULES

### Step 1: Create Entity Models
```
1. Create EntityX.cs in ModuleXCore/Entities/
2. Inherit from EntityBase
3. Add [Table("table_name")] attribute
4. Add properties with DataAnnotations
5. Add Navigation properties
```

### Step 2: Create EntityRegister
```
1. Create EntityRegister.cs in ModuleX/Classes/
2. Register each entity with ModelBuilder
3. Configure indexes
4. Configure foreign keys
5. Set decimal precision
```

### Step 3: Register in DbContext
```
1. Open DbPostgresContext.cs
2. Call EntityRegister.RegisterEntities(builder)
3. Build solution
```

### Step 4: Create Migration
```
dotnet ef migrations add AddXModuleTables --startup-project ../SLK.TryEdu.WebHost
```

### Step 5: Test Migration
```
dotnet ef database update --startup-project ../SLK.TryEdu.WebHost
```

### Step 6: Verify
```
psql -U postgres -d tryedu_db -c "\dt"
```

---

## 📚 REFERENCES

- EntityBase: `src/SLK.TryEdu.Abstract/EntityBase.cs`
- DbContext: `src/SLK.TryEdu.Db/DbPostgres/Context/DbPostgresContext.cs`
- Database Schema: `src/database_schema_postgresql.md`
- Migration Guide: `src/LICH_TRINH_VIET_CODE_BAN_THU_NGHIEM.md`

---

## 🆘 TROUBLESHOOTING

### ❌ Migration fails với foreign key error
**✅ Solution:**
```
1. Check EntityRegister foreign key configuration
2. Ensure referenced tables exist
3. Check OnDelete behavior
```

### ❌ Decimal precision issues
**✅ Solution:**
```
1. Use HasPrecision(12,2) for amounts
2. Use HasPrecision(5,2) for percentages/rates
3. Check Column(TypeName = "decimal(x,y)")
```

### ❌ Unique constraint violations
**✅ Solution:**
```
1. Check HasIndex().IsUnique() configuration
2. Ensure seed data doesn't duplicate
3. Check existing data before seeding
```

---

*Lộ trình tạo: 28/11/2025*  
*Version: 1.0*  
*For: TryEdu V2.0 Project*



# 🎓 Giao diện Người dùng V2.0 - TryEdu B2B2C

## 📋 Tổng quan

Đã tạo sẵn **7 trang giao diện người dùng** hoàn chỉnh theo **yêu cầu hệ thống V2.0 B2B2C**:

### ✅ Đã hoàn thành:

1. **Dashboard** (`/student/dashboard`) - Tổng quan với stats
2. **Ví Coin** (`/student/coin-wallet`) - Nạp coin, xem balance, lịch sử ⭐ MỚI
3. **Khóa học Miễn phí** (`/student/free-courses`) - Browse free courses ⭐ MỚI
4. **Danh sách Khóa học** (`/student/courses`) - Browse paid courses
5. **Chi tiết Khóa học** (`/student/course/{id}`) - Course details
6. **Danh sách Trắc nghiệm** (`/student/quizzes`) - Browse quizzes
7. **Chi tiết Trắc nghiệm** (`/student/quiz/{id}`) - Take quiz with timer

---

## 🆕 Tính năng mới V2.0

### 💰 1. Hệ thống Coin (Ví Coin)
**Trang:** `CoinWallet.cshtml`

**Chức năng:**
- ✅ Hiển thị số dư coin hiện tại
- ✅ **6 gói nạp coin** với bonus:
  - 50K VNĐ → 50 coins
  - 100K VNĐ → 105 coins (+5 bonus)
  - 500K VNĐ → 550 coins (+50 bonus) 🔥 PHỔ BIẾN
  - 1M VNĐ → 1,150 coins (+150 bonus)
  - 2M VNĐ → 2,400 coins (+400 bonus)
  - Tùy chỉnh (min 50K VNĐ)
- ✅ **Input mã giới thiệu** để nhận thêm 10% coin
- ✅ **4 phương thức thanh toán**:
  - VNPay (Thẻ ATM/Visa/MasterCard)
  - MoMo
  - Banking
  - ZaloPay
- ✅ **Lịch sử giao dịch** real-time:
  - Nạp coin (+)
  - Mua bài thi (-)
  - Bonus từ mã giới thiệu (+)
  - Mua khóa học (-)
- ✅ **Stats**: Đã nạp, Đã sử dụng, Tiết kiệm

**Dữ liệu mẫu:**
```javascript
{
  currentBalance: 1250,
  totalDeposited: 2000,
  totalUsed: 750,
  savingsPercent: 15,
  transactions: [
    { type: 'add', amount: 550, description: 'Nạp coin', date: 'Today, 10:30 AM' },
    { type: 'minus', amount: 200, description: 'Mua bài thi IELTS', date: 'Yesterday, 3:15 PM' },
    { type: 'bonus', amount: 50, description: 'Bonus từ mã ABC Center', date: '2 days ago' }
  ],
  referralCode: 'ABC2024' // Mã test (nhập để test chức năng)
}
```

---

### 🎁 2. Khóa học Miễn phí
**Trang:** `FreeCourses.cshtml`

**Chức năng:**
- ✅ Hero section với stats (50+ courses, 200+ lessons, 100% free)
- ✅ **4 Benefits cards**:
  - Truy cập ngay lập tức
  - Chất lượng cao
  - Nhận chứng chỉ
  - Học linh hoạt
- ✅ **Filter theo 7 danh mục**:
  - Grammar
  - Listening
  - Reading
  - Writing
  - Speaking
  - Vocabulary
  - Tất cả
- ✅ **6 khóa học miễn phí mẫu** với:
  - Badge "MIỄN PHÍ" xanh lá
  - Thumbnail image
  - Category badge
  - Instructor info + avatar
  - Stats: Học viên, Bài học, Thời lượng
  - Button "Bắt đầu học" hoặc "Tiếp tục học"
  - Progress badge (nếu đã học)
- ✅ **CTA section** khuyến khích đăng ký

**Dữ liệu mẫu:**
```javascript
[
  {
    id: 1,
    title: 'Basic English Grammar for Beginners',
    category: 'Grammar',
    instructor: 'Ms. Sarah Johnson',
    students: 15200,
    lessons: 25,
    duration: '6h 30p',
    progress: 35,
    thumbnail: 'photo-1434030216411-0b793f4b4173'
  },
  {
    id: 2,
    title: 'English Listening Skills Practice',
    category: 'Listening',
    instructor: 'Mr. David Lee',
    students: 12800,
    lessons: 30,
    duration: '8h 15p',
    progress: 0
  },
  // ... 4 more courses
]
```

---

## 📂 Cấu trúc File

```
SLK.TryEdu.WebHost/Areas/Student/Pages/
├── Dashboard.cshtml + .cs                    ✅ Đã có
├── CoinWallet.cshtml + .cs                   ⭐ MỚI
├── FreeCourses.cshtml + .cs                  ⭐ MỚI
├── Courses.cshtml + .cs                      ✅ Đã có
├── CourseDetail.cshtml + .cs                 ✅ Đã có
├── Quizzes.cshtml + .cs                      ✅ Đã có
├── QuizDetail.cshtml + .cs                   ✅ Đã có
├── GIAO_DIEN_NGUOI_DUNG_README.md           📄 Old
└── GIAO_DIEN_V2_README.md                   📄 NEW (this file)
```

---

## 🎨 Thiết kế V2.0

### Color Palette mới:

#### Coin System:
- **Primary Gradient**: `#667eea → #764ba2` (Purple)
- **Success Green**: `#10b981` (Free courses & positive transactions)
- **Bonus Badge**: `#48bb78` (Bonus coins)

#### Free Courses:
- **Hero Green**: `#10b981 → #059669`
- **Badge Free**: `#10b981`
- **Benefits**: Light green gradients

### Typography:
- Coin amount: `72px`, `font-weight: 800`
- Package amount: `36px`, `font-weight: 800`
- Section titles: `h4`, `fw-bold`

### Components mới:

#### 1. Coin Balance Card
```css
.coin-balance-card {
    background: white;
    border-radius: 24px;
    padding: 40px;
    box-shadow: 0 8px 32px rgba(0,0,0,0.12);
    position: relative;
    overflow: hidden;
}
.balance-amount {
    font-size: 72px;
    font-weight: 800;
    background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
    -webkit-background-clip: text;
    -webkit-text-fill-color: transparent;
}
```

#### 2. Package Card
```css
.package-card {
    border: 3px solid #e2e8f0;
    border-radius: 20px;
    padding: 30px;
    cursor: pointer;
    transition: all 0.3s ease;
}
.package-card:hover {
    border-color: #667eea;
    transform: translateY(-8px);
    box-shadow: 0 12px 32px rgba(102, 126, 234, 0.2);
}
.package-card.popular {
    border-color: #f59e0b;
    background: linear-gradient(135deg, #fff7ed 0%, #fef3c7 100%);
}
```

#### 3. Transaction Card
```css
.transaction-card {
    background: white;
    border-radius: 16px;
    padding: 20px;
    display: flex;
    align-items: center;
    gap: 16px;
    box-shadow: 0 2px 12px rgba(0,0,0,0.06);
}
.transaction-icon {
    width: 50px;
    height: 50px;
    border-radius: 12px;
    display: flex;
    align-items: center;
    justify-content: center;
}
.icon-add { background: #d1fae5; } /* Green for positive */
.icon-minus { background: #fee2e2; } /* Red for negative */
```

---

## 🚀 Hướng dẫn sử dụng

### 1. Test Ví Coin

**Bước 1:** Truy cập `/student/coin-wallet`

**Bước 2:** Nhập mã giới thiệu test: `ABC2024`

**Bước 3:** Click "Áp dụng" → Sẽ hiện thông báo "Mã hợp lệ! +10% coin"

**Bước 4:** Chọn gói nạp (click vào card)

**Bước 5:** Chọn phương thức thanh toán

**Bước 6:** Click "Nạp coin ngay"

**Kết quả mong đợi:**
- Discount info hiển thị
- Số coin được cộng thêm 10%
- Package card được highlight (border màu xanh)
- Payment method được chọn

### 2. Test Khóa học Miễn phí

**Bước 1:** Truy cập `/student/free-courses`

**Bước 2:** Click filter category (Grammar, Listening, etc.)

**Bước 3:** Click "Bắt đầu học" trên course card

**Bước 4:** Xem course detail (sẽ redirect sang CourseDetail)

**Kết quả mong đợi:**
- Hero section với stats
- 6 course cards với badge "MIỄN PHÍ"
- Filter hoạt động (active state)
- Course cards có hover effect

---

## 🔗 Routes đầy đủ

| Trang | URL | Trạng thái |
|-------|-----|-----------|
| Dashboard | `/student/dashboard` | ✅ |
| **Ví Coin** | `/student/coin-wallet` | ⭐ MỚI |
| **Khóa học Miễn phí** | `/student/free-courses` | ⭐ MỚI |
| Khóa học Paid | `/student/courses` | ✅ |
| Chi tiết Khóa học | `/student/course/{id}` | ✅ |
| Trắc nghiệm | `/student/quizzes` | ✅ |
| Chi tiết Trắc nghiệm | `/student/quiz/{id}` | ✅ |

---

## 📊 Dữ liệu mẫu chi tiết

### Coin Wallet Sample Data

```csharp
public class CoinWalletModel : PageModel
{
    // Current balance
    public decimal CurrentBalance { get; set; } = 1250;
    public decimal TotalDeposited { get; set; } = 2000;
    public decimal TotalUsed { get; set; } = 750;
    public decimal SavingsPercent { get; set; } = 15;
    
    // Packages
    public List<CoinPackage> Packages { get; set; } = new List<CoinPackage>
    {
        new() { Amount = 50000, Coins = 50, Bonus = 0, Label = "Gói cơ bản" },
        new() { Amount = 100000, Coins = 105, Bonus = 5, Label = "Gói tiết kiệm" },
        new() { Amount = 500000, Coins = 550, Bonus = 50, Label = "Gói phổ biến", IsPopular = true },
        new() { Amount = 1000000, Coins = 1150, Bonus = 150, Label = "Gói đặc biệt" },
        new() { Amount = 2000000, Coins = 2400, Bonus = 400, Label = "Gói VIP" }
    };
    
    // Recent transactions
    public List<Transaction> Transactions { get; set; } = new List<Transaction>
    {
        new() { Type = "add", Amount = 550, Description = "Nạp coin", Date = "Hôm nay, 10:30 AM", Source = "500K VNĐ" },
        new() { Type = "minus", Amount = 200, Description = "Mua bài thi", Date = "Hôm qua, 3:15 PM", Source = "IELTS Mock Test" },
        new() { Type = "bonus", Amount = 50, Description = "Bonus từ mã giới thiệu", Date = "2 ngày trước", Source = "ABC Center" },
        new() { Type = "minus", Amount = 150, Description = "Mua khóa học", Date = "3 ngày trước", Source = "Advanced Grammar" }
    };
    
    // Test referral code
    public string TestReferralCode { get; set; } = "ABC2024";
    public decimal ReferralDiscount { get; set; } = 10; // 10%
}
```

### Free Courses Sample Data

```csharp
public class FreeCoursesModel : PageModel
{
    public List<FreeCourse> Courses { get; set; } = new List<FreeCourse>
    {
        new() 
        { 
            Id = 1,
            Title = "Basic English Grammar for Beginners",
            Category = "Grammar",
            CategoryColor = "#d1fae5",
            CategoryTextColor = "#065f46",
            Instructor = "Ms. Sarah Johnson",
            InstructorRole = "English Teacher",
            InstructorAvatar = "https://i.pravatar.cc/150?img=1",
            Students = 15200,
            Lessons = 25,
            Duration = "6h 30p",
            Progress = 35,
            Thumbnail = "https://images.unsplash.com/photo-1434030216411-0b793f4b4173?w=600",
            Description = "Học ngữ pháp tiếng Anh cơ bản từ A-Z, phù hợp cho người mới bắt đầu"
        },
        new() 
        { 
            Id = 2,
            Title = "English Listening Skills Practice",
            Category = "Listening",
            CategoryColor = "#dbeafe",
            CategoryTextColor = "#1e40af",
            Instructor = "Mr. David Lee",
            InstructorRole = "IELTS Trainer",
            InstructorAvatar = "https://i.pravatar.cc/150?img=2",
            Students = 12800,
            Lessons = 30,
            Duration = "8h 15p",
            Progress = 0,
            Thumbnail = "https://images.unsplash.com/photo-1546410531-bb4caa6b424d?w=600",
            Description = "Rèn luyện kỹ năng nghe tiếng Anh qua các bài tập thực hành đa dạng"
        },
        // ... Add 4 more courses
    };
}
```

---

## ✨ Features chưa implement (cần backend)

### Cần API cho Coin System:
- [ ] `POST /api/coin/purchase` - Nạp coin
- [ ] `GET /api/coin/balance/{userId}` - Lấy số dư
- [ ] `POST /api/coin/validate-referral` - Validate mã giới thiệu
- [ ] `GET /api/coin/transactions/{userId}` - Lịch sử giao dịch
- [ ] `POST /api/coin/use` - Sử dụng coin (mua bài thi/khóa học)

### Cần API cho Free Courses:
- [ ] `GET /api/courses/free` - Lấy danh sách khóa học miễn phí
- [ ] `GET /api/courses/free/{id}` - Chi tiết khóa học miễn phí
- [ ] `POST /api/courses/free/{id}/enroll` - Đăng ký khóa học miễn phí
- [ ] `GET /api/courses/free/{id}/progress` - Tiến độ học tập

### Cần implement:
- [ ] Payment Gateway integration (VNPay, MoMo, Banking, ZaloPay)
- [ ] Real-time coin balance updates
- [ ] Transaction history pagination
- [ ] Referral code validation logic
- [ ] Commission calculation cho Partner

---

## 🎯 Next Steps

### Phase 1: Backend Integration (Sprint 3-4)
1. Tạo Coin Service API endpoints
2. Tích hợp Payment Gateway
3. Implement Commission System
4. Real-time updates với SignalR

### Phase 2: Partner Portal (Sprint 5-6)
1. Tạo Partner Portal UI
2. Dashboard hoa hồng
3. Quản lý mã giới thiệu
4. Theo dõi học viên

### Phase 3: Testing & Optimization (Sprint 7-8)
1. Load testing
2. Security audit
3. Performance optimization
4. User acceptance testing

---

## 📞 Hỗ trợ

Tất cả giao diện đã **sẵn sàng với dữ liệu mẫu**. Team chỉ cần:

1. ✅ **Kết nối backend APIs**
2. ✅ **Thay thế dữ liệu mẫu bằng dữ liệu thật từ database**
3. ✅ **Tích hợp Payment Gateway**
4. ✅ **Implement Commission System**

**Giao diện hoàn toàn phù hợp với HỆ THỐNG V2.0 B2B2C!** 🚀


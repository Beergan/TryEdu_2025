# ĐỊNH HƯỚNG CHỨC NĂNG HỆ THỐNG V2.0 - B2B2C MODEL

## 📋 TỔNG QUAN

Hệ thống giáo dục trực tuyến V2.0 với mô hình **B2B2C**, bao gồm:
- **9 EPICs** chính
- **30+ User Stories** chi tiết
- **5 vai trò người dùng**: Student, Teacher, Admin, Accountant, Partner
- **5 Portals**: Student App/Web, Teacher Portal, Admin Back Office, Accounting Portal, Partner Portal

---

## 🎯 CÁC CHỨC NĂNG THEO EPIC

### 👥 **EPIC 1: QUẢN LÝ NGƯỜI DÙNG VÀ XÁC THỰC**

#### **US1.1: Đăng ký tài khoản học viên**
- ✅ Form đăng ký với validation
- ✅ Xác thực email
- ✅ Hoàn thiện profile
- ✅ Upload avatar

#### **US1.2: Đăng ký tài khoản giáo viên**
- ✅ Form đăng ký với upload CV/chứng chỉ
- ✅ Chờ admin phê duyệt
- ✅ Email notification

#### **US1.3: Đăng nhập hệ thống**
- ✅ Đăng nhập với email/password
- ✅ Remember me
- ✅ Forgot password
- ✅ Multi-factor authentication (tùy chọn)

#### **US1.4: Quản lý tài khoản người dùng (Admin)**
- ✅ Phê duyệt giáo viên
- ✅ Khóa/mở khóa tài khoản
- ✅ Quản lý roles và permissions
- ✅ Xem danh sách người dùng

---

### 📚 **EPIC 2: QUẢN LÝ KHÓA HỌC VÀ BÀI THI**

#### **US2.1: Tạo khóa học (Admin)**
- ✅ Tạo khóa học miễn phí
- ✅ Tạo khóa học có thu phí
- ✅ Upload video, tài liệu
- ✅ Quản lý bài học trong khóa học

#### **US2.2: Truy cập và mua khóa học (Student)**
- ✅ Xem danh sách khóa học
- ✅ Truy cập khóa học miễn phí ngay lập tức
- ✅ Mua khóa học có thu phí bằng coin
- ✅ Xem preview khóa học

#### **US2.3: Tạo bài thi thử có thu phí (Admin)**
- ✅ Tạo bài thi với cấu trúc (Reading, Listening, Writing, Speaking)
- ✅ Thiết lập giá bài thi bằng coin
- ✅ Quản lý thời gian làm bài
- ✅ Cấu hình chấm điểm tự động

#### **US2.4: Mua bài thi thử có thu phí (Student)**
- ✅ Xem danh sách bài thi
- ✅ Mua bài thi bằng coin
- ✅ Sử dụng mã giới thiệu khi mua
- ✅ Bài thi xuất hiện trong "Bài thi của tôi"

#### **US2.5: Quản lý khóa học và bài thi (Admin)**
- ✅ CRUD khóa học và bài thi
- ✅ Thống kê số lượng học viên
- ✅ Quản lý trạng thái (active/inactive)

#### **US2.6: Quản lý ngân hàng đề thi (Teacher + Admin)**
- ✅ Tạo và quản lý câu hỏi
- ✅ Phân loại câu hỏi theo level, topic
- ✅ Import/Export câu hỏi
- ✅ Quản lý đáp án

#### **US2.7: Quản lý ngân hàng bài học (Teacher + Admin)**
- ✅ Tạo bài học với video, text, quiz
- ✅ Quản lý tài liệu đính kèm
- ✅ Phân loại bài học

#### **US2.8: Tạo cấu trúc đề thi tự động (Teacher + Admin)**
- ✅ Sử dụng template để tạo đề thi
- ✅ Thuật toán tự động chọn câu hỏi
- ✅ Thiết lập độ khó, số lượng câu hỏi

---

### 🎯 **EPIC 3: HỆ THỐNG HỌC TẬP TRỰC TUYẾN**

#### **US3.1: Học khóa học miễn phí (Student)**
- ✅ Xem video bài học
- ✅ Làm quiz sau mỗi bài
- ✅ Tạo ghi chú
- ✅ Học offline (download video)

#### **US3.2: Làm bài thi thử có thu phí (Student)**
- ✅ Làm bài thi với timer
- ✅ Auto-save progress
- ✅ Submit bài thi
- ✅ Xem kết quả ngay sau khi làm xong

#### **US3.3: Quản lý tiến độ học tập (Student)**
- ✅ Dashboard học tập
- ✅ Lịch sử hoạt động
- ✅ Achievements
- ✅ Báo cáo tiến độ chi tiết

---

### ✅ **EPIC 4: HỆ THỐNG ĐÁNH GIÁ VÀ CHẤM ĐIỂM**

#### **US4.1: Chấm bài thi có thu phí (Teacher)**
- ✅ Xem danh sách bài thi cần chấm
- ✅ Chấm Writing và Speaking
- ✅ Sử dụng AI hỗ trợ chấm điểm
- ✅ Viết feedback chi tiết
- ✅ Submit kết quả

#### **US4.2: Quản lý đánh giá (Admin)**
- ✅ Xem tất cả bài thi đã chấm
- ✅ Quản lý chất lượng chấm bài
- ✅ Thống kê điểm số

---

### 💳 **EPIC 5: QUẢN LÝ TÀI CHÍNH VÀ THANH TOÁN**

#### **US5.1: Quản lý thanh toán từ bài thi thử (Accountant)**
- ✅ Xem giao dịch coin
- ✅ Xử lý thanh toán thất bại
- ✅ Reconcile ngân hàng
- ✅ Refund coin

#### **US5.2: Quản lý voucher và khuyến mại (Admin)**
- ✅ Tạo voucher
- ✅ Thiết lập điều kiện sử dụng
- ✅ Quản lý chương trình khuyến mại

---

### 🤝 **EPIC 6: HỆ THỐNG HỖ TRỢ VÀ TƯƠNG TÁC**

#### **US6.1: Hỗ trợ khách hàng (Student)**
- ✅ Tạo ticket hỗ trợ
- ✅ Chat trực tiếp
- ✅ FAQ
- ✅ Video hướng dẫn

#### **US6.2: Quản lý hỗ trợ (Admin)**
- ✅ Xem và xử lý tickets
- ✅ Phân công tickets
- ✅ Thống kê hỗ trợ

#### **US6.3: Tương tác cộng đồng (Student)**
- ✅ Forum discussion
- ✅ Study groups
- ✅ Peer review
- ✅ Social features

---

### 🛡️ **EPIC 7: QUẢN TRỊ, BÁO CÁO VÀ BẢO MẬT**

#### **US7.1: Dashboard quản trị (Admin)**
- ✅ Dashboard tổng quan với KPIs
- ✅ Báo cáo doanh thu
- ✅ Báo cáo người dùng
- ✅ Analytics AI

#### **US7.2: Quản lý nội dung (Admin)**
- ✅ Quản lý tất cả nội dung
- ✅ Phê duyệt nội dung
- ✅ Quản lý categories

#### **US7.3: Bảo mật hệ thống (Admin)**
- ✅ Security audit logs
- ✅ Firewall configuration
- ✅ Intrusion detection
- ✅ Backup & recovery

#### **US7.4: Quản lý tuân thủ (Admin)**
- ✅ GDPR compliance
- ✅ Data retention policies
- ✅ Privacy settings

#### **US7.5: Quản lý bài viết nâng cao (Admin + Teacher)**
- ✅ CMS cho bài viết
- ✅ Quản lý thông báo
- ✅ SEO optimization

---

### 🏢 **EPIC 8: HỆ THỐNG TRUNG TÂM ĐỐI TÁC (MỚI - ƯU TIÊN CAO)**

#### **US8.1: Đăng ký trung tâm đối tác (Partner Portal)**
- ✅ Form đăng ký với thông tin trung tâm
- ✅ Upload giấy phép kinh doanh (PDF/JPG, max 5MB)
- ✅ Upload logo (PNG/JPG, max 2MB)
- ✅ Chọn tier (Bronze, Silver, Gold, Platinum)
- ✅ Workflow phê duyệt với admin
- ✅ Email notification cho mọi trạng thái
- ✅ Tự động tạo mã giới thiệu sau khi phê duyệt

#### **US8.2: Quản lý mã giới thiệu (Partner Portal)**
- ✅ Tạo mã giới thiệu mới với tên, giảm giá, thời hạn
- ✅ Thiết lập mức giảm giá (% hoặc coin cố định)
- ✅ Thiết lập số lần sử dụng tối đa
- ✅ Copy mã để chia sẻ
- ✅ Xem thống kê sử dụng real-time
- ✅ Edit/Tạm dừng/Xóa mã
- ✅ Export báo cáo Excel/PDF

#### **US8.3: Dashboard hoa hồng (Partner Portal)**
- ✅ KPIs: Tổng hoa hồng, hoa hồng tháng này, số học viên
- ✅ Biểu đồ doanh thu theo thời gian
- ✅ Top mã giới thiệu hiệu quả nhất
- ✅ Filter theo loại giao dịch (nạp coin, mua bài thi)
- ✅ Export báo cáo Excel/PDF
- ✅ Xem lịch thanh toán hoa hồng
- ✅ Download hóa đơn hoa hồng

#### **US8.4: Quản lý học viên giới thiệu (Partner Portal)**
- ✅ Xem danh sách học viên được giới thiệu
- ✅ Filter theo trạng thái (active, inactive, premium)
- ✅ Search theo tên, email, số điện thoại
- ✅ Xem thông tin chi tiết và lịch sử hoạt động
- ✅ Gửi thông báo cho học viên
- ✅ Privacy compliance

#### **US8.5: Quản lý trung tâm đối tác (Admin Back Office)**
- ✅ Review và phê duyệt/từ chối hồ sơ đối tác
- ✅ Thiết lập tỷ lệ hoa hồng theo tier
- ✅ Cấu hình hoa hồng cho từng trung tâm
- ✅ Dashboard monitoring real-time
- ✅ Fraud detection system
- ✅ Báo cáo tổng hợp

---

### 💰 **EPIC 9: HỆ THỐNG COIN VÀ MÃ GIỚI THIỆU (MỚI - ƯU TIÊN CAO)**

#### **US9.1: Nạp coin vào tài khoản (Student App)**
- ✅ Chọn số tiền nạp (50K, 100K, 200K, 500K, 1M VNĐ hoặc tùy chỉnh)
- ✅ Xem số coin sẽ nhận được (tỷ lệ 1:1 hoặc có bonus)
- ✅ Chọn phương thức thanh toán (VNPay, MoMo, Banking)
- ✅ Nhập mã giới thiệu (tùy chọn)
- ✅ Validate mã và áp dụng giảm giá
- ✅ Thanh toán và nhận coin ngay lập tức
- ✅ Email xác nhận giao dịch
- ✅ Lịch sử giao dịch chi tiết

#### **US9.2: Sử dụng mã giới thiệu (Student App)**
- ✅ Validate mã giới thiệu real-time
- ✅ Hiển thị thông tin trung tâm phát hành mã
- ✅ Hiển thị mức giảm giá (% hoặc số coin)
- ✅ Áp dụng giảm giá tự động khi nạp coin
- ✅ Áp dụng giảm giá tự động khi mua bài thi
- ✅ Thông báo lỗi rõ ràng khi mã không hợp lệ
- ✅ Lưu lịch sử sử dụng mã

#### **US9.3: Mua bài thi bằng coin (Student App)**
- ✅ Xem giá bài thi bằng coin
- ✅ Kiểm tra số coin hiện có
- ✅ Nhập mã giới thiệu (tùy chọn)
- ✅ Xem tổng giá sau giảm giá
- ✅ Trừ coin từ tài khoản
- ✅ Email xác nhận mua bài thi
- ✅ Thông báo khi không đủ coin và gợi ý nạp thêm

#### **US9.4: Tính toán hoa hồng tự động (System)**
- ✅ Tính hoa hồng từ nạp coin (5% giá trị giao dịch)
- ✅ Tính hoa hồng từ mua bài thi (5% giá trị coin)
- ✅ Tính hoa hồng theo tier (Bronze: 3%, Silver: 5%, Gold: 7%, Platinum: 10%)
- ✅ Tự động nâng cấp tier khi đạt điều kiện
- ✅ Lưu giao dịch hoa hồng vào database
- ✅ Cập nhật dashboard trung tâm real-time
- ✅ Audit trail đầy đủ

#### **US9.5: Quản lý giao dịch coin (Admin Back Office)**
- ✅ Dashboard tổng quan: Tổng coin nạp, coin sử dụng, số giao dịch
- ✅ Filter theo trạng thái, phương thức, trung tâm
- ✅ Search theo học viên, mã giao dịch
- ✅ Xử lý giao dịch thất bại
- ✅ Refund coin
- ✅ Báo cáo và phân tích xu hướng
- ✅ Export báo cáo Excel/PDF

#### **US9.6: Hệ thống tỷ giá coin (Admin Back Office)**
- ✅ Quản lý tỷ giá cơ bản (VD: 1 VNĐ = 1 Coin)
- ✅ Thiết lập tỷ giá theo từng gói nạp (bonus %)
- ✅ Tạo chương trình khuyến mại nạp coin
- ✅ Thiết lập tỷ giá đặc biệt cho từng trung tâm
- ✅ Kích hoạt/tạm dừng chương trình
- ✅ Thống kê hiệu quả chương trình

---

## 🎯 ƯU TIÊN THEO PHASE

### **PHASE 1: FOUNDATION (Tháng 1-3) - MVP**

#### **Sprint 1-2: Setup & Authentication**
1. ✅ Project setup và infrastructure
2. ✅ Database design (PostgreSQL, MongoDB, Redis)
3. ✅ User registration/login
4. ✅ Email verification
5. ✅ Role-based access control (Student, Teacher, Admin, Partner, Accountant)

#### **Sprint 3-4: Core Course Management**
1. ✅ Tạo khóa học miễn phí (Admin)
2. ✅ Truy cập khóa học miễn phí (Student)
3. ✅ Basic course browsing
4. ✅ Admin approval workflow

### **PHASE 2: CORE FEATURES (Tháng 4-6) - BETA**

#### **Sprint 5-6: Learning System**
1. ✅ Video player
2. ✅ Progress tracking
3. ✅ Note-taking
4. ✅ Quiz functionality

#### **Sprint 7-8: Exam System**
1. ✅ Tạo bài thi có thu phí (Admin)
2. ✅ Làm bài thi (Student)
3. ✅ Basic AI grading
4. ✅ Result display

#### **Sprint 9-10: Coin & Partner System (MỚI - QUAN TRỌNG)**
1. ✅ **Coin transaction system**
   - Nạp coin vào tài khoản
   - Mua bài thi bằng coin
   - Lịch sử giao dịch
2. ✅ **Referral code system**
   - Tạo mã giới thiệu (Partner)
   - Validate và sử dụng mã (Student)
   - Thống kê sử dụng mã
3. ✅ **Partner center registration**
   - Form đăng ký đối tác
   - Workflow phê duyệt (Admin)
   - Tự động tạo mã giới thiệu
4. ✅ **Commission calculation**
   - Tính hoa hồng tự động
   - Dashboard hoa hồng (Partner)
   - Quản lý hoa hồng (Admin)

### **PHASE 3: ADVANCED FEATURES (Tháng 7-9)**

#### **Sprint 11-12: AI Integration**
1. ✅ Advanced AI grading
2. ✅ Personalized recommendations
3. ✅ Content optimization

#### **Sprint 13-14: Community Features**
1. ✅ Forum system
2. ✅ Study groups
3. ✅ Peer review

#### **Sprint 15-16: Mobile & Partner Portal**
1. ✅ Flutter mobile app
2. ✅ Offline mode
3. ✅ Push notifications
4. ✅ Partner Portal completion

### **PHASE 4: POLISH & LAUNCH (Tháng 10-12)**

#### **Sprint 17-18: Testing & QA**
1. ✅ Comprehensive testing
2. ✅ Performance optimization
3. ✅ Security audit
4. ✅ Bug fixes

#### **Sprint 19-20: Launch Preparation**
1. ✅ Production deployment
2. ✅ Monitoring setup
3. ✅ Support system
4. ✅ Marketing materials

---

## 👥 CHỨC NĂNG THEO VAI TRÒ

### 👨‍🎓 **HỌC VIÊN (Student)**

#### **Authentication & Profile**
- Đăng ký/Đăng nhập
- Xác thực email
- Quản lý profile

#### **Learning**
- Truy cập khóa học miễn phí ngay lập tức
- Xem video, làm quiz
- Tạo ghi chú
- Học offline

#### **Coin System (MỚI)**
- Nạp coin vào tài khoản
- Sử dụng mã giới thiệu
- Mua bài thi bằng coin
- Xem lịch sử giao dịch
- Quản lý ví coin

#### **Exam**
- Mua bài thi bằng coin
- Làm bài thi với timer
- Nhận kết quả AI ngay
- Xem feedback giáo viên

#### **Progress & Community**
- Dashboard học tập
- Theo dõi tiến độ
- Forum, study groups
- Hỗ trợ khách hàng

---

### 👨‍🏫 **GIÁO VIÊN (Teacher)**

#### **Authentication**
- Đăng ký với CV/chứng chỉ
- Chờ admin phê duyệt

#### **Content Creation**
- Quản lý ngân hàng đề thi
- Quản lý ngân hàng bài học
- Tạo cấu trúc đề thi tự động
- Quản lý bài viết nâng cao

#### **Grading**
- Chấm bài thi Writing/Speaking
- Sử dụng AI hỗ trợ
- Viết feedback chi tiết

#### **Earning**
- Nhận commission từ chấm bài
- Xem báo cáo thu nhập

---

### 👨‍💼 **QUẢN TRỊ VIÊN (Admin)**

#### **User Management**
- Phê duyệt giáo viên
- Phê duyệt trung tâm đối tác
- Khóa/mở khóa tài khoản
- Quản lý roles

#### **Content Management**
- Tạo khóa học miễn phí
- Tạo bài thi có thu phí
- Quản lý ngân hàng đề thi
- Quản lý ngân hàng bài học
- Quản lý bài viết nâng cao

#### **Partner Management (MỚI)**
- Review và phê duyệt đối tác
- Cấu hình hoa hồng theo tier
- Monitor hiệu suất đối tác
- Fraud detection

#### **Coin Management (MỚI)**
- Quản lý tỷ giá coin
- Quản lý giao dịch coin
- Xử lý refund
- Báo cáo tài chính

#### **System Management**
- Dashboard tổng quan
- Bảo mật hệ thống
- Monitoring performance
- Backup & recovery

---

### 💰 **NHÂN VIÊN KẾ TOÁN (Accountant)**

#### **Payment Management**
- Xem giao dịch coin
- Xử lý thanh toán thất bại
- Reconcile ngân hàng
- Refund coin

#### **Commission Management**
- Tính hoa hồng đối tác
- Thanh toán hoa hồng
- Báo cáo commission
- Quản lý thuế

#### **Financial Reports**
- Báo cáo doanh thu
- Báo cáo chi phí
- Báo cáo lợi nhuận
- Export Excel/PDF

---

### 🏢 **TRUNG TÂM ĐỐI TÁC (Partner) - MỚI**

#### **Registration**
- Đăng ký làm đối tác
- Upload giấy phép kinh doanh
- Upload logo
- Chờ admin phê duyệt
- Nhận mã giới thiệu riêng

#### **Referral Code Management**
- Tạo mã giới thiệu mới
- Thiết lập mức giảm giá
- Thiết lập thời hạn và số lần sử dụng
- Copy và chia sẻ mã
- Xem thống kê sử dụng

#### **Dashboard & Reports**
- Dashboard hoa hồng với KPIs
- Báo cáo hoa hồng chi tiết
- Lịch sử giao dịch
- Export báo cáo Excel/PDF

#### **Student Management**
- Xem danh sách học viên được giới thiệu
- Theo dõi hoạt động học viên
- Gửi thông báo cho học viên
- Hỗ trợ học viên

---

## 🔧 TECHNICAL STACK

### **Frontend**
- Blazor Server/WebAssembly (.NET 8)
- Flutter (Mobile)
- MudBlazor / Radzen UI

### **Backend**
- .NET Core 8 + ASP.NET Core Web API
- Microservices Architecture:
  - Core Service (User, Payment)
  - Content Service (Course, Exam)
  - Coin & Partner Service (MỚI)
  - Notification Service

### **Database**
- PostgreSQL (Users, Payments, Partners, Coins, Commissions)
- MongoDB (Courses, Exams, Learning Progress)
- Redis (Sessions, Cache, Real-time Data)

### **External Services**
- Payment Gateway (VNPay, MoMo, Banking)
- Email Service (SendGrid)
- AI Service (Auto Grading)

---

## 📊 DATABASE SCHEMA CHÍNH

### **PostgreSQL Tables**
1. `users` - Quản lý người dùng
2. `partner_centers` - Trung tâm đối tác
3. `referral_codes` - Mã giới thiệu
4. `coin_transactions` - Giao dịch coin
5. `commission_transactions` - Giao dịch hoa hồng
6. `payments` - Thanh toán
7. `enrollments` - Đăng ký khóa học

### **MongoDB Collections**
1. `courses` - Khóa học
2. `exams` - Bài thi
3. `learning_progress` - Tiến độ học tập
4. `coin_balance` - Số dư coin
5. `referral_usage` - Lịch sử sử dụng mã

---

## 🚀 NEXT STEPS

### **Immediate Actions (Week 1-2)**
1. ✅ Review và approve tài liệu này
2. ✅ Set up development environment
3. ✅ Create project structure
4. ✅ Database design và setup
5. ✅ Set up CI/CD pipeline

### **Sprint 1-2 (Week 3-6)**
1. ✅ Core authentication system
2. ✅ User management APIs
3. ✅ Basic UI framework
4. ✅ Partner Portal foundation

### **Sprint 3-4 (Week 7-10)**
1. ✅ Course management
2. ✅ Coin system foundation
3. ✅ Partner registration workflow
4. ✅ Payment integration

### **Sprint 5-6 (Week 11-14)**
1. ✅ Learning system
2. ✅ Exam system
3. ✅ Referral code system
4. ✅ Commission calculation

---

## ⚠️ RISKS & MITIGATION

### **Technical Risks**
1. **Coin System Security**
   - Mitigation: Security audit từ Sprint 2
   - Backup: Traditional payment system

2. **Partner Integration Complexity**
   - Mitigation: Partner Portal MVP trong Sprint 3
   - Backup: Manual partner management

3. **Performance với large user base**
   - Mitigation: Load testing từ Sprint 3
   - Monitoring continuous

### **Business Risks**
1. **Partner Onboarding Challenges**
   - Mitigation: Partner success program
   - Dedicated partner support

2. **Requirements Changes**
   - Mitigation: Regular stakeholder communication
   - Change control process

---

## 📈 SUCCESS METRICS

### **Sprint Metrics**
- Sprint Velocity
- Burndown chart
- Code quality metrics
- Partner system completion rate

### **Product Metrics**
- Feature completion rate
- User acceptance rate
- Partner onboarding success rate
- Coin transaction volume

---

## 📝 NOTES

- **Ưu tiên cao**: EPIC 8 (Partner System) và EPIC 9 (Coin System) - đây là tính năng mới và quan trọng cho mô hình B2B2C
- **MVP**: Cần hoàn thành EPIC 1, 2, 3, 8, 9 trước để có thể launch
- **Beta**: Thêm EPIC 4, 5, 6
- **Production**: Hoàn thiện EPIC 7 và tất cả features

---

**Tài liệu này sẽ được cập nhật thường xuyên theo tiến độ dự án.**


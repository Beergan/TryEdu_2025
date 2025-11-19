# HỆ THỐNG GIÁO DỤC TRỰC TUYẾN - USER STORIES CHI TIẾT

## MỤC LỤC

1. [Sơ đồ cây chức năng tổng quan](#sơ-đồ-cây-chức-năng-tổng-quan)
2. [Tổng quan hệ thống](#tổng-quan-hệ-thống)
3. [Kiến trúc và vai trò người dùng](#kiến-trúc-và-vai-trò-người-dùng)
4. [EPIC 1: Quản lý người dùng và xác thực](#epic-1-quản-lý-người-dùng-và-xác-thực)
5. [EPIC 2: Quản lý khóa học và bài thi](#epic-2-quản-lý-khóa-học-và-bài-thi)
6. [EPIC 3: Hệ thống học tập trực tuyến](#epic-3-hệ-thống-học-tập-trực-tuyến)
7. [EPIC 4: Hệ thống đánh giá và chấm điểm](#epic-4-hệ-thống-đánh-giá-và-chấm-điểm)
8. [EPIC 5: Quản lý tài chính và thanh toán](#epic-5-quản-lý-tài-chính-và-thanh-toán)
9. [EPIC 6: Hệ thống hỗ trợ và tương tác](#epic-6-hệ-thống-hỗ-trợ-và-tương-tác)
10. [EPIC 7: Quản trị, báo cáo và bảo mật](#epic-7-quản-trị-báo-cáo-và-bảo-mật)
11. [User Journey Maps](#user-journey-maps)
12. [Technical Specifications](#technical-specifications)
13. [Project Timeline](#project-timeline)
14. [Kế hoạch sản xuất với Team Scrum](#kế-hoạch-sản-xuất-với-team-scrum)

---

## SƠ ĐỒ CÂY CHỨC NĂNG TỔNG QUAN

### 🌳 Cây chức năng hệ thống

```
🏫 HỆ THỐNG GIÁO DỤC TRỰC TUYẾN
├── 👥 EPIC 1: QUẢN LÝ NGƯỜI DÙNG VÀ XÁC THỰC
│   ├── 📝 US1.1: Đăng ký tài khoản học viên
│   ├── 👨‍🏫 US1.2: Đăng ký tài khoản giáo viên  
│   ├── 🔐 US1.3: Đăng nhập hệ thống
│   └── ⚙️ US1.4: Quản lý tài khoản người dùng (Admin)
│
├── 📚 EPIC 2: QUẢN LÝ KHÓA HỌC VÀ BÀI THI
│   ├── ➕ US2.1: Tạo khóa học (Admin) - Miễn phí & Có thu phí
│   ├── 🎓 US2.2: Truy cập và mua khóa học (Student)
│   ├── 📝 US2.3: Tạo bài thi thử có thu phí (Admin)
│   ├── 💰 US2.4: Mua bài thi thử có thu phí (Student)
│   ├── 📊 US2.5: Quản lý khóa học và bài thi (Admin)
│   ├── 🗂️ US2.6: Quản lý ngân hàng đề thi (Teacher + Admin)
│   ├── 🏗️ US2.8: Tạo cấu trúc đề thi tự động (Teacher + Admin)
│   └── 📚 US2.7: Quản lý ngân hàng bài học (Teacher + Admin)
│
├── 🎯 EPIC 3: HỆ THỐNG HỌC TẬP TRỰC TUYẾN
│   ├── 📖 US3.1: Học khóa học miễn phí (Student)
│   ├── 🧪 US3.2: Làm bài thi thử có thu phí (Student)
│   └── 📈 US3.3: Quản lý tiến độ học tập (Student)
│
├── ✅ EPIC 4: HỆ THỐNG ĐÁNH GIÁ VÀ CHẤM ĐIỂM
│   ├── 👨‍🏫 US4.1: Chấm bài thi có thu phí (Teacher)
│   └── ⚙️ US4.2: Quản lý đánh giá (Admin)
│
├── 💳 EPIC 5: QUẢN LÝ TÀI CHÍNH VÀ THANH TOÁN
│   ├── 💰 US5.1: Quản lý thanh toán từ bài thi thử (Accountant)
│   └── 🎫 US5.2: Quản lý voucher và khuyến mại (Admin)
│
├── 🤝 EPIC 6: HỆ THỐNG HỖ TRỢ VÀ TƯƠNG TÁC
│   ├── 🆘 US6.1: Hỗ trợ khách hàng (Student)
│   ├── ⚙️ US6.2: Quản lý hỗ trợ (Admin)
│   └── 👥 US6.3: Tương tác cộng đồng (Student)
│
└── 🛡️ EPIC 7: QUẢN TRỊ, BÁO CÁO VÀ BẢO MẬT
    ├── 📊 US7.1: Dashboard quản trị (Admin)
    ├── 📝 US7.2: Quản lý nội dung (Admin)
    ├── 🔒 US7.3: Bảo mật hệ thống (Admin)
    ├── 📋 US7.4: Quản lý tuân thủ (Admin)
    └── 📰 US7.5: Quản lý bài viết nâng cao (Admin + Teacher)
```

### 🎯 Tóm tắt chức năng theo vai trò

#### 👨‍🎓 HỌC VIÊN (Student)
- **Đăng ký/Đăng nhập** tài khoản
- **Truy cập khóa học miễn phí** ngay lập tức (không cần thanh toán)
- **Mua khóa học có thu phí** - nội dung premium
- **Mua bài thi thử** có thu phí (nguồn thu chính của hệ thống)
- **Học tập** với video, ghi chú, offline mode
- **Làm bài thi** với timer và nhận kết quả
- **Theo dõi tiến độ** học tập và lịch sử đơn hàng
- **Tương tác cộng đồng** qua forum, study groups
- **Hỗ trợ khách hàng** qua ticket, chat, FAQ

#### 👨‍🏫 GIÁO VIÊN (Teacher)
- **Đăng ký** với upload CV/chứng chỉ
- **Chấm bài thi** Writing/Speaking
- **Sử dụng AI hỗ trợ** chấm điểm
- **Nhận commission** từ việc chấm bài
- **Quản lý ngân hàng đề thi** - tạo và quản lý câu hỏi
- **Tạo cấu trúc đề thi tự động** - sử dụng template và thuật toán thông minh
- **Quản lý ngân hàng bài học** - tạo nội dung học tập
- **Quản lý bài viết nâng cao** - đăng tải nội dung và thông báo

#### 👨‍💼 QUẢN TRỊ VIÊN (Admin)
- **Quản lý người dùng** (phê duyệt, khóa/mở khóa)
- **Tạo khóa học miễn phí** và bài thi có thu phí
- **Quản lý nội dung** và AI grading
- **Dashboard tổng quan** với báo cáo chi tiết
- **Bảo mật hệ thống** và tuân thủ
- **Quản lý voucher** và khuyến mại
- **Quản lý ngân hàng đề thi** - hệ thống hóa câu hỏi
- **Tạo cấu trúc đề thi tự động** - quản lý template và thuật toán
- **Quản lý ngân hàng bài học** - quản lý nội dung học tập
- **Quản lý bài viết nâng cao** - CMS cho nội dung

#### 💰 NHÂN VIÊN KẾ TOÁN (Accountant)
- **Quản lý thanh toán** từ bài thi thử
- **Báo cáo tài chính** theo thời gian
- **Quản lý commission** giáo viên
- **Xử lý refund** và reconcile ngân hàng

### 🚀 Các tính năng nổi bật

#### 🤖 AI Integration
- **AI Auto-grading** cho bài thi
- **AI hỗ trợ giáo viên** chấm điểm
- **Personalized recommendations**
- **Content optimization**

#### 📱 Cross-platform
- **Web Application** (Blazor)
- **Mobile App** (Flutter)
- **Responsive Design**
- **Offline Mode**

#### 💳 Payment & Financial
- **Multiple payment methods**
- **Voucher system**
- **Commission calculation**
- **Financial reporting**

#### 🔒 Security & Compliance
- **GDPR compliance**
- **Data encryption**
- **Audit logging**
- **Role-based access control**

#### 📊 Analytics & Reporting
- **Real-time dashboard**
- **Sales analytics by product**
- **Time-based reporting**
- **Performance metrics**

---

## TỔNG QUAN HỆ THỐNG

### Mô tả hệ thống
Hệ thống giáo dục trực tuyến cung cấp **các khóa học Tiếng Anh** (có cả miễn phí và có thu phí) và **bài thi thử có thu phí**. Học viên có thể truy cập khóa học miễn phí ngay lập tức, trong khi khóa học có thu phí và bài thi thử cần thanh toán. **Bài thi thử có thu phí** là nguồn thu chính của hệ thống. Các bài thi thử có thu phí sẽ do giáo viên thật đánh giá, ngay khi hoàn thành bài thi có thể được tự động đánh giá bởi trí tuệ nhân tạo.

### Mục tiêu kinh doanh
- **Cung cấp khóa học Tiếng Anh miễn phí** chất lượng cao để thu hút học viên
- **Tạo nguồn thu từ khóa học có thu phí** - nội dung premium
- **Tạo nguồn thu chính từ việc bán bài thi thử có thu phí** - đánh giá trình độ học viên
- Tự động hóa quy trình đánh giá và chấm điểm
- Tối ưu hóa trải nghiệm học tập trực tuyến
- Xây dựng cộng đồng học viên lớn mạnh thông qua nội dung miễn phí

---

## KIẾN TRÚC VÀ VAI TRÒ NGƯỜI DÙNG

### Các vai trò người dùng
1. **Học viên (Student)** - Người học khóa học miễn phí và mua bài thi thử
2. **Giáo viên (Teacher)** - Người chấm bài thi thử có thu phí
3. **Quản trị viên (Admin)** - Quản lý toàn bộ hệ thống, đăng tải khóa học miễn phí, quản lý kỹ thuật và bảo mật
4. **Nhân viên kế toán (Accountant)** - Quản lý tài chính từ việc bán bài thi thử

### Các ứng dụng
1. **Student App/Web** - Dành cho học viên
2. **Teacher Portal** - Dành cho giáo viên
3. **Admin Back Office** - Dành cho quản trị viên (bao gồm quản lý hệ thống và bảo mật)
4. **Accounting Portal** - Dành cho nhân viên kế toán

---

## EPIC 1: QUẢN LÝ NGƯỜI DÙNG VÀ XÁC THỰC

### US1.1: Đăng ký tài khoản học viên (Student App)

**Mô tả:** Là học viên, tôi muốn đăng ký tài khoản để có thể mua khóa học và thi thử Tiếng Anh

#### Kịch bản chính:

**1. Đăng ký thành công**
- Học viên truy cập trang đăng ký
- Nhập thông tin: Họ tên, email, số điện thoại, mật khẩu
- Xác nhận mật khẩu
- Chọn loại tài khoản (học viên)
- Nhấn "Đăng ký"
- Hệ thống gửi email xác thực
- Học viên nhận email và click link xác thực
- Tài khoản được kích hoạt thành công

**2. Đăng ký với email đã tồn tại**
- Học viên nhập email đã có trong hệ thống
- Hệ thống hiển thị thông báo lỗi
- Gợi ý đăng nhập hoặc quên mật khẩu

**3. Đăng ký với thông tin không hợp lệ**
- Học viên nhập email không đúng định dạng
- Hệ thống hiển thị validation error real-time
- Không cho phép submit form

#### Acceptance Criteria:
- [ ] Form validation real-time cho tất cả fields
- [ ] Email phải unique trong hệ thống
- [ ] Mật khẩu tối thiểu 8 ký tự, có chữ hoa, số, ký tự đặc biệt
- [ ] Gửi email xác thực trong vòng 30 giây
- [ ] Link xác thực có thời hạn 24 giờ
- [ ] Sau khi xác thực, redirect về trang đăng nhập
- [ ] Lưu thông tin đăng ký vào database
- [ ] Log tất cả hoạt động đăng ký

#### Test Scenarios:
- Đăng ký với email hợp lệ
- Đăng ký với email đã tồn tại
- Đăng ký với mật khẩu yếu
- Xác thực email thành công
- Xác thực email hết hạn
- Xác thực email không tồn tại

---

### US1.2: Đăng ký tài khoản giáo viên (Teacher Portal)

**Mô tả:** Là giáo viên, tôi muốn đăng ký để có thể tạo khóa học và chấm bài thi

#### Kịch bản chính:

**1. Đăng ký giáo viên thành công**
- Giáo viên truy cập trang đăng ký giáo viên
- Nhập thông tin cá nhân: Họ tên, email, phone, địa chỉ
- Upload CV/Resume (PDF, DOC)
- Upload chứng chỉ giảng dạy (IELTS, TESOL, etc.)
- Nhập kinh nghiệm giảng dạy
- Chọn chuyên môn (IELTS, TOEIC, General English)
- Nhập mức phí mong muốn
- Submit hồ sơ
- Hệ thống gửi email xác nhận đã nhận hồ sơ
- Admin review và phê duyệt
- Gửi email thông báo kết quả

**2. Đăng ký với hồ sơ không đầy đủ**
- Giáo viên submit mà thiếu CV hoặc chứng chỉ
- Hệ thống hiển thị warning
- Vẫn cho phép submit nhưng đánh dấu "chờ bổ sung"

**3. Admin từ chối hồ sơ**
- Admin review và từ chối với lý do cụ thể
- Gửi email thông báo từ chối
- Giáo viên có thể đăng ký lại sau 30 ngày

#### Acceptance Criteria:
- [ ] Upload file CV tối đa 5MB, định dạng PDF/DOC
- [ ] Upload chứng chỉ tối đa 2MB, định dạng PDF/JPG
- [ ] Validation tất cả fields bắt buộc
- [ ] Workflow phê duyệt với comments
- [ ] Email notification cho mọi trạng thái
- [ ] Dashboard admin để review hồ sơ
- [ ] Lưu trữ file an toàn với encryption
- [ ] Audit log cho tất cả hoạt động

#### Test Scenarios:
- Đăng ký với hồ sơ đầy đủ
- Đăng ký với file quá lớn
- Đăng ký với file không đúng định dạng
- Admin phê duyệt hồ sơ
- Admin từ chối hồ sơ
- Giáo viên đăng ký lại sau khi bị từ chối

---

### US1.3: Đăng nhập hệ thống (Tất cả apps)

**Mô tả:** Là người dùng, tôi muốn đăng nhập để truy cập vào hệ thống

#### Kịch bản chính:

**1. Đăng nhập thành công**
- Người dùng nhập email và mật khẩu
- Hệ thống xác thực thông tin
- Redirect theo role: Student App, Teacher Portal, Admin Back Office
- Lưu session và remember me option

**2. Đăng nhập với thông tin sai**
- Nhập sai email hoặc mật khẩu
- Hệ thống hiển thị thông báo lỗi
- Tăng số lần thử sai
- Khóa tài khoản sau 5 lần thử sai

**3. Đăng nhập với tài khoản bị khóa**
- Tài khoản bị admin khóa
- Hiển thị thông báo và liên hệ support
- Không cho phép đăng nhập

**4. Quên mật khẩu**
- Click "Quên mật khẩu"
- Nhập email
- Nhận email reset password
- Tạo mật khẩu mới

#### Acceptance Criteria:
- [ ] Xác thực email/password trong 2 giây
- [ ] Redirect đúng portal theo role
- [ ] Session timeout sau 8 giờ không hoạt động
- [ ] Remember me lưu 30 ngày
- [ ] Khóa tài khoản sau 5 lần thử sai
- [ ] Email reset password trong 1 phút
- [ ] Log tất cả hoạt động đăng nhập
- [ ] 2FA cho admin accounts

#### Test Scenarios:
- Đăng nhập với thông tin đúng
- Đăng nhập với thông tin sai
- Đăng nhập với tài khoản bị khóa
- Quên mật khẩu và reset thành công
- Session timeout
- Remember me functionality

---

### US1.4: Quản lý tài khoản người dùng (Admin Back Office)

**Mô tả:** Là admin, tôi muốn quản lý tất cả tài khoản trong hệ thống

#### Kịch bản chính:

**1. Xem danh sách người dùng**
- Admin đăng nhập vào back office
- Vào menu "Quản lý người dùng"
- Xem danh sách tất cả user với filter
- Search theo tên, email, role
- Xem thống kê đăng ký theo thời gian

**2. Quản lý tài khoản giáo viên**
- Xem danh sách giáo viên chờ phê duyệt
- Review hồ sơ chi tiết
- Phê duyệt hoặc từ chối với lý do
- Gửi email thông báo kết quả

**3. Khóa/mở khóa tài khoản**
- Tìm tài khoản cần khóa
- Click "Khóa tài khoản"
- Nhập lý do khóa
- Gửi email thông báo cho user
- Có thể mở khóa sau

#### Acceptance Criteria:
- [ ] Danh sách user load trong 3 giây
- [ ] Filter và search real-time
- [ ] Bulk actions cho nhiều user
- [ ] Email notification tự động
- [ ] Audit log cho mọi thay đổi
- [ ] Export danh sách Excel/PDF
- [ ] Role-based access control
- [ ] Data pagination

#### Test Scenarios:
- Xem danh sách user đầy đủ
- Filter user theo role
- Search user theo tên/email
- Phê duyệt giáo viên
- Khóa tài khoản user
- Export danh sách user

---

## EPIC 2: QUẢN LÝ KHÓA HỌC VÀ BÀI THI

> **Lưu ý quan trọng**: Hệ thống hỗ trợ **cả khóa học miễn phí và có thu phí**. Khóa học miễn phí để thu hút học viên, khóa học có thu phí tạo nguồn thu bổ sung. **Bài thi thử có thu phí** là nguồn thu chính của hệ thống.

### US2.1: Tạo khóa học (Admin Back Office)

**Mô tả:** Là admin, tôi muốn tạo khóa học Tiếng Anh với tùy chọn miễn phí hoặc có thu phí

#### Kịch bản chính:

**1. Tạo khóa học miễn phí**
- Admin click "Tạo khóa học mới"
- Nhập thông tin cơ bản: Tên, mô tả, level (A1-C2)
- Upload thumbnail (1200x630px)
- Chọn "Khóa học miễn phí"
- Tạo curriculum với các lesson
- Upload video cho từng lesson (MP4, tối đa 500MB)
- Upload tài liệu PDF cho lesson
- Tạo quiz cho lesson
- Preview khóa học
- Publish khóa học ngay lập tức

**2. Tạo khóa học có thu phí**
- Admin click "Tạo khóa học mới"
- Nhập thông tin cơ bản: Tên, mô tả, level (A1-C2)
- Upload thumbnail (1200x630px)
- Chọn "Khóa học có thu phí"
- Thiết lập giá bán (bắt buộc có phí)
- Tạo curriculum với các lesson
- Upload video cho từng lesson (MP4, tối đa 500MB)
- Upload tài liệu PDF cho lesson
- Tạo quiz cho lesson
- Preview khóa học
- Publish khóa học ngay lập tức

**3. Tạo khóa học với nội dung không đầy đủ**
- Thiếu video hoặc tài liệu cho lesson
- Hệ thống hiển thị warning
- Vẫn cho phép save draft

**4. Chỉnh sửa khóa học đã tạo**
- Admin edit khóa học đã publish
- Thêm lesson mới, cập nhật nội dung
- Có thể thay đổi từ miễn phí sang có phí (và ngược lại)
- Cập nhật giá bán nếu là khóa học có thu phí

#### Acceptance Criteria:
- [ ] Rich text editor cho mô tả khóa học
- [ ] Upload video với progress bar
- [ ] Compress video tự động
- [ ] Preview khóa học trước khi submit
- [ ] Version control cho khóa học
- [ ] Auto-save draft mỗi 30 giây
- [ ] Validation tất cả fields bắt buộc
- [ ] Thumbnail tự động generate từ video đầu tiên

#### Test Scenarios:
- Tạo khóa học hoàn chỉnh
- Tạo khóa học với file quá lớn
- Upload video không đúng định dạng
- Preview khóa học
- Edit khóa học đã tạo
- Auto-save draft

---

### US2.2: Truy cập và mua khóa học (Student App)

**Mô tả:** Là học viên, tôi muốn truy cập khóa học miễn phí và mua khóa học có thu phí để học tập

#### Kịch bản chính:

**1. Truy cập khóa học miễn phí**
- Học viên browse catalog khóa học
- Filter theo level, category, rating, loại (miễn phí/có phí)
- Xem preview khóa học (2-3 phút đầu)
- Đọc review từ học viên khác
- Click "Học ngay" (miễn phí)
- Khóa học ngay lập tức xuất hiện trong "Khóa học của tôi"
- Bắt đầu học ngay lập tức không cần thanh toán

**2. Mua khóa học có thu phí**
- Học viên browse catalog khóa học
- Filter theo level, category, rating, loại (miễn phí/có phí)
- Xem preview khóa học có thu phí (2-3 phút đầu)
- Đọc review từ học viên khác
- Click "Mua khóa học"
- Chọn phương thức thanh toán
- Thanh toán thành công
- Nhận email xác nhận
- Khóa học xuất hiện trong "Khóa học của tôi"

**3. Xem thông tin khóa học**
- Học viên xem chi tiết khóa học
- Xem curriculum và thời lượng
- Xem danh sách lesson
- Xem preview video
- Đọc mô tả chi tiết
- Xem giá bán (nếu là khóa học có thu phí)

**4. Đăng ký nhận thông báo**
- Học viên đăng ký nhận thông báo khóa học mới
- Nhận email khi có khóa học mới
- Nhận thông báo khi có lesson mới

**5. Chia sẻ khóa học**
- Học viên chia sẻ khóa học với bạn bè
- Share qua social media
- Copy link chia sẻ

#### Acceptance Criteria:
- [ ] Catalog load trong 3 giây
- [ ] Filter real-time không reload trang
- [ ] Preview video không tải toàn bộ
- [ ] Truy cập khóa học ngay lập tức
- [ ] Email notification cho khóa học mới
- [ ] Social sharing functionality
- [ ] Mobile responsive
- [ ] SEO friendly URLs

#### Test Scenarios:
- Truy cập khóa học miễn phí thành công
- Filter và search khóa học
- Đăng ký nhận thông báo
- Chia sẻ khóa học
- Xem preview video
- Browse catalog khóa học

---

### US2.3: Tạo bài thi thử có thu phí (Admin Back Office)

**Mô tả:** Là admin, tôi muốn tạo bài thi thử Tiếng Anh có thu phí để đánh giá trình độ học viên

#### Kịch bản chính:

**1. Tạo bài thi hoàn chỉnh**
- Admin click "Tạo bài thi mới"
- Nhập thông tin: Tên, mô tả, level (A1-C2), thời gian
- Thiết lập giá bán (bắt buộc có phí)
- Tạo phần Reading với 3-4 passages
- Tạo phần Listening với audio upload
- Tạo phần Writing với đề bài
- Tạo phần Speaking với câu hỏi
- Thiết lập thang điểm và đáp án
- Preview bài thi
- Publish bài thi ngay lập tức

**2. Tạo bài thi với AI auto-grading**
- Admin chọn "Sử dụng AI chấm điểm"
- Upload đáp án mẫu cho Writing/Speaking
- Thiết lập tiêu chí chấm điểm
- AI sẽ tự động chấm và đưa ra feedback

**3. Chỉnh sửa bài thi đã tạo**
- Admin edit bài thi đã publish
- Thay đổi câu hỏi, đáp án, giá bán
- Cập nhật ngay lập tức

#### Acceptance Criteria:
- [ ] Rich text editor cho câu hỏi
- [ ] Upload audio với progress bar
- [ ] Preview bài thi trước khi submit
- [ ] AI integration cho auto-grading
- [ ] Version control cho bài thi
- [ ] Auto-save draft mỗi 30 giây
- [ ] Validation tất cả fields bắt buộc
- [ ] Thang điểm linh hoạt

#### Test Scenarios:
- Tạo bài thi hoàn chỉnh
- Tạo bài thi với AI grading
- Upload audio không đúng định dạng
- Preview bài thi
- Edit bài thi đã tạo
- Auto-save draft

---

### US2.4: Mua bài thi thử có thu phí (Student App)

**Mô tả:** Là học viên, tôi muốn mua bài thi thử có thu phí để đánh giá trình độ Tiếng Anh

#### Kịch bản chính:

**1. Mua bài thi thành công**
- Học viên browse danh sách bài thi
- Filter theo level, giá, thời gian
- Xem preview bài thi (câu hỏi mẫu)
- Click "Mua ngay"
- Chọn phương thức thanh toán
- Thanh toán thành công
- Nhận email xác nhận
- Bài thi xuất hiện trong "Bài thi của tôi"

**2. Mua bài thi với voucher**
- Học viên có voucher giảm giá
- Nhập mã voucher
- Áp dụng discount
- Tiến hành thanh toán

**3. Thanh toán thất bại**
- Thanh toán bị lỗi
- Redirect về trang bài thi
- Hiển thị thông báo lỗi

#### Acceptance Criteria:
- [ ] Danh sách bài thi load trong 3 giây
- [ ] Filter real-time
- [ ] Preview câu hỏi mẫu
- [ ] Payment integration
- [ ] Email confirmation
- [ ] Voucher validation
- [ ] Mobile responsive

#### Test Scenarios:
- Mua bài thi thành công
- Mua với voucher
- Thanh toán thất bại
- Filter bài thi

---

### US2.5: Quản lý khóa học miễn phí và bài thi có thu phí (Admin Back Office)

**Mô tả:** Là admin, tôi muốn quản lý tất cả khóa học miễn phí và bài thi có thu phí trong hệ thống

#### Kịch bản chính:

**1. Quản lý khóa học miễn phí**
- Admin xem danh sách tất cả khóa học miễn phí
- Tạo, edit, xóa khóa học
- Quản lý nội dung và curriculum
- Xem thống kê số học viên tham gia

**2. Quản lý bài thi có thu phí**
- Admin xem danh sách tất cả bài thi có thu phí
- Tạo, edit, xóa bài thi
- Quản lý giá bán và nội dung
- Xem thống kê doanh thu từ bài thi

**3. Quản lý AI grading**
- Cấu hình AI grading settings
- Quản lý tiêu chí chấm điểm
- Xem thống kê chất lượng chấm điểm
- Fine-tune AI models

#### Acceptance Criteria:
- [ ] Dashboard tổng quan
- [ ] Filter và search
- [ ] Bulk actions
- [ ] Email notifications
- [ ] Audit log
- [ ] Export reports
- [ ] Role-based access

#### Test Scenarios:
- Tạo khóa học miễn phí mới
- Edit khóa học đã publish
- Tạo bài thi có thu phí mới
- Quản lý giá bán bài thi
- Xem thống kê doanh thu
- Cấu hình AI grading

---

### US2.6: Quản lý ngân hàng đề thi (Teacher Portal + Admin Back Office)

**Mô tả:** Là giáo viên/admin, tôi muốn quản lý ngân hàng câu hỏi để tạo đề thi một cách linh hoạt và có hệ thống

#### Kịch bản chính:

**1. Tạo câu hỏi trong ngân hàng**
- Giáo viên vào "Ngân hàng đề thi"
- Click "Thêm câu hỏi mới"
- Chọn loại câu hỏi (trắc nghiệm, tự luận, điền từ, matching)
- Nhập nội dung câu hỏi với rich text editor
- Upload hình ảnh/audio/video nếu cần
- Nhập đáp án và giải thích chi tiết
- Phân loại theo chủ đề, độ khó, level (A1-C2)
- Thiết lập thời gian làm bài cho câu hỏi
- Lưu vào ngân hàng với trạng thái draft/published

**2. Tạo đề thi từ ngân hàng**
- Chọn "Tạo đề thi từ ngân hàng"
- Thiết lập cấu trúc đề thi (số câu từng phần, thời gian)
- Filter câu hỏi theo chủ đề, độ khó, level
- Hệ thống tự động chọn câu hỏi hoặc cho phép chọn thủ công
- Preview đề thi với timer
- Thiết lập thang điểm và đáp án
- Lưu đề thi với tên và mô tả

**3. Quản lý ngân hàng câu hỏi**
- Xem danh sách tất cả câu hỏi với pagination
- Search theo nội dung, chủ đề, tác giả
- Filter theo loại câu hỏi, độ khó, trạng thái
- Edit, xóa, duplicate câu hỏi
- Import/export câu hỏi từ Excel/CSV
- Phân quyền truy cập (public, private, theo role)
- Quản lý version và lịch sử thay đổi

**4. Tạo cấu trúc đề thi tự động**
- Thiết lập template cấu trúc đề thi (IELTS, TOEIC, Cambridge, v.v.)
- Chọn loại đề thi và thời gian làm bài
- Thiết lập số câu hỏi cho từng phần (Reading, Listening, Writing, Speaking)
- Phân bổ câu hỏi theo chủ đề và độ khó tự động
- Hệ thống tự động chọn câu hỏi phù hợp từ ngân hàng
- Preview cấu trúc đề thi trước khi tạo
- Lưu template cấu trúc để tái sử dụng

**5. Phân bổ ma trận đề thi**
- Thiết lập ma trận đề thi theo từng danh mục
- Phân bổ số câu hỏi theo chủ đề và độ khó
- Tự động tạo đề thi theo ma trận đã thiết lập
- Kiểm tra tính cân bằng của đề thi
- Xuất báo cáo ma trận đề thi

#### Acceptance Criteria:
- [ ] Rich text editor cho câu hỏi với formatting
- [ ] Upload media files (hình ảnh, audio, video) tối đa 10MB
- [ ] Hỗ trợ 4+ loại câu hỏi khác nhau
- [ ] **Template cấu trúc đề thi có sẵn** (IELTS, TOEIC, Cambridge, v.v.)
- [ ] **Tạo cấu trúc đề thi tự động** với thuật toán thông minh
- [ ] **Auto-generate đề thi từ ngân hàng** theo cấu trúc đã chọn
- [ ] **Preview cấu trúc đề thi** trước khi tạo
- [ ] **Lưu template cấu trúc** để tái sử dụng
- [ ] Import/export Excel/CSV với validation
- [ ] Search và filter mạnh mẽ với multiple criteria
- [ ] Version control cho câu hỏi và đề thi
- [ ] Phân quyền granular (view, edit, delete, publish)
- [ ] Ma trận đề thi linh hoạt
- [ ] Preview đề thi với timer thực tế
- [ ] Mobile responsive cho teacher portal

#### Test Scenarios:
- Tạo câu hỏi với các loại khác nhau
- Upload file media quá lớn
- **Tạo cấu trúc đề thi từ template có sẵn**
- **Tạo cấu trúc đề thi tùy chỉnh**
- **Auto-generate đề thi từ cấu trúc đã chọn**
- Tạo đề thi thủ công từ câu hỏi đã chọn
- **Preview cấu trúc đề thi trước khi tạo**
- **Lưu và tái sử dụng template cấu trúc**
- Import/export câu hỏi
- Test phân quyền truy cập
- Thiết lập và sử dụng ma trận đề thi
- Preview đề thi với timer

---

### US2.8: Tạo cấu trúc đề thi tự động (Teacher Portal + Admin Back Office)

**Mô tả:** Là giáo viên/admin, tôi muốn tạo cấu trúc đề thi tự động từ template có sẵn để tiết kiệm thời gian và đảm bảo tính nhất quán

#### Kịch bản chính:

**1. Tạo đề thi từ template có sẵn**
- Giáo viên vào "Tạo đề thi tự động"
- Chọn template cấu trúc (IELTS Academic, IELTS General, TOEIC, Cambridge, v.v.)
- Hệ thống hiển thị cấu trúc mặc định của template
- Điều chỉnh số câu hỏi cho từng phần nếu cần
- Thiết lập thời gian làm bài tổng thể
- Preview cấu trúc đề thi trước khi tạo
- Click "Tạo đề thi tự động"

**2. Tạo cấu trúc đề thi tùy chỉnh**
- Giáo viên chọn "Tạo cấu trúc tùy chỉnh"
- Thiết lập các phần của đề thi (Reading, Listening, Writing, Speaking)
- Phân bổ số câu hỏi cho từng phần
- Thiết lập thời gian cho từng phần
- Chọn chủ đề và độ khó cho từng phần
- Lưu template cấu trúc để tái sử dụng
- Tạo đề thi từ cấu trúc đã thiết lập

**3. Auto-generate đề thi từ cấu trúc**
- Hệ thống tự động chọn câu hỏi từ ngân hàng theo cấu trúc
- Áp dụng thuật toán thông minh để đảm bảo tính cân bằng
- Kiểm tra trùng lặp câu hỏi
- Đảm bảo phân bổ đều theo chủ đề và độ khó
- Preview đề thi hoàn chỉnh
- Cho phép thay đổi câu hỏi thủ công nếu cần

**4. Quản lý template cấu trúc**
- Xem danh sách template có sẵn
- Tạo template mới từ cấu trúc tùy chỉnh
- Edit, xóa, duplicate template
- Share template với giáo viên khác
- Import/export template
- Phân loại template theo loại đề thi

#### Acceptance Criteria:
- [ ] **Template cấu trúc có sẵn** cho các loại đề thi phổ biến
- [ ] **Tạo cấu trúc đề thi tùy chỉnh** linh hoạt
- [ ] **Auto-generate đề thi** từ cấu trúc với thuật toán thông minh
- [ ] **Preview cấu trúc đề thi** trước khi tạo
- [ ] **Lưu template cấu trúc** để tái sử dụng
- [ ] **Kiểm tra tính cân bằng** của đề thi tự động
- [ ] **Thay đổi câu hỏi thủ công** nếu cần
- [ ] **Quản lý template** (tạo, edit, xóa, share)
- [ ] **Import/export template** cấu trúc
- [ ] **Phân loại template** theo loại đề thi
- [ ] **Mobile responsive** cho teacher portal

#### Test Scenarios:
- Tạo đề thi từ template IELTS Academic
- Tạo cấu trúc đề thi tùy chỉnh
- Auto-generate đề thi từ cấu trúc
- Preview cấu trúc đề thi
- Lưu và tái sử dụng template
- Kiểm tra tính cân bằng đề thi
- Thay đổi câu hỏi thủ công
- Quản lý template cấu trúc
- Import/export template

---

### US2.7: Quản lý ngân hàng bài học (Teacher Portal + Admin Back Office)

**Mô tả:** Là giáo viên/admin, tôi muốn quản lý ngân hàng nội dung bài học có cấu trúc để tạo khóa học một cách hiệu quả

#### Kịch bản chính:

**1. Tạo nội dung bài học**
- Giáo viên vào "Ngân hàng bài học"
- Click "Thêm nội dung mới"
- Chọn loại nội dung (video, text, audio, quiz, document, image)
- Upload hoặc nhập nội dung với rich text editor
- Phân loại theo chủ đề, level (A1-C2), kỹ năng (reading, writing, listening, speaking)
- Thiết lập metadata (thời lượng, độ khó, tags, keywords)
- Thiết lập prerequisites và learning objectives
- Lưu vào ngân hàng với trạng thái draft/published

**2. Tạo khóa học từ ngân hàng**
- Chọn "Tạo khóa học từ ngân hàng"
- Browse nội dung theo chủ đề, level, kỹ năng
- Drag & drop để sắp xếp thứ tự bài học
- Thiết lập cấu trúc khóa học (modules, lessons, topics)
- Thiết lập thời gian học và tiến độ
- Preview khóa học với timeline
- Thiết lập assessment và certification
- Publish khóa học

**3. Quản lý nội dung bài học**
- Xem danh sách tất cả nội dung với pagination
- Search theo tiêu đề, nội dung, tags
- Filter theo loại, chủ đề, level, kỹ năng, trạng thái
- Edit, xóa, duplicate nội dung
- Quản lý version và lịch sử thay đổi
- Import/export nội dung từ external sources
- Phân quyền truy cập và collaboration
- Analytics về usage và performance

**4. Quản lý cấu trúc khóa học**
- Tạo template khóa học theo chuẩn
- Thiết lập learning path cho từng level
- Quản lý dependencies giữa các bài học
- Thiết lập assessment milestones
- Tạo certificate templates
- Quản lý prerequisites và co-requisites

#### Acceptance Criteria:
- [ ] Hỗ trợ đa phương tiện (video, audio, image, document)
- [ ] Rich text editor với media embedding
- [ ] Phân loại nội dung chi tiết theo multiple dimensions
- [ ] Drag & drop interface cho course creation
- [ ] Version control và collaboration features
- [ ] Advanced search và filter với multiple criteria
- [ ] Import/export từ external sources
- [ ] Phân quyền truy cập granular
- [ ] Analytics và reporting
- [ ] Template system cho course structure
- [ ] Learning path management
- [ ] Mobile responsive

#### Test Scenarios:
- Tạo nội dung với các loại media khác nhau
- Tạo khóa học từ ngân hàng nội dung
- Test drag & drop interface
- Import nội dung từ external sources
- Test phân quyền và collaboration
- Tạo learning path phức tạp
- Test analytics và reporting

---

## EPIC 3: HỆ THỐNG HỌC TẬP TRỰC TUYẾN

### US3.1: Học khóa học (Student App)

**Mô tả:** Là học viên, tôi muốn học khóa học (cả miễn phí và có thu phí) một cách hiệu quả

#### Kịch bản chính:

**1. Học lesson mới**
- Học viên vào "Khóa học của tôi"
- Chọn khóa học muốn học (miễn phí hoặc đã mua)
- Xem curriculum và progress
- Click vào lesson chưa học
- Xem video với player có controls
- Download tài liệu PDF
- Làm quiz cuối lesson
- Đánh dấu lesson hoàn thành

**2. Học với ghi chú**
- Học viên tạo ghi chú trong khi xem video
- Lưu ghi chú theo timestamp
- Xem lại ghi chú khi cần
- Export ghi chú ra PDF

**3. Học offline**
- Download lesson để học offline
- Sync progress khi có internet
- Xem video đã download

#### Acceptance Criteria:
- [ ] Video player với controls đầy đủ
- [ ] Progress tracking real-time
- [ ] Note-taking system
- [ ] Offline mode
- [ ] Quiz integration
- [ ] Certificate generation
- [ ] Mobile app support
- [ ] Bandwidth optimization

#### Test Scenarios:
- Học lesson hoàn chỉnh
- Tạo và lưu ghi chú
- Học offline
- Làm quiz
- Nhận certificate

---

### US3.2: Làm bài thi thử có thu phí (Student App)

**Mô tả:** Là học viên, tôi muốn làm bài thi thử có thu phí để đánh giá trình độ

#### Kịch bản chính:

**1. Làm bài thi hoàn chỉnh**
- Học viên chọn bài thi đã mua (có thu phí)
- Xem hướng dẫn và thời gian
- Bắt đầu làm bài
- Làm từng phần: Reading, Listening, Writing, Speaking
- Submit bài thi
- Nhận kết quả ngay lập tức (AI) hoặc chờ giáo viên chấm

**2. Làm bài thi với timer**
- Hệ thống đếm ngược thời gian
- Cảnh báo khi còn 10 phút
- Tự động submit khi hết giờ
- Lưu draft tự động

**3. Xem kết quả chi tiết**
- Xem điểm từng phần
- Xem đáp án đúng/sai
- Nhận feedback từ AI/giáo viên
- Xem certificate (nếu đạt yêu cầu)

#### Acceptance Criteria:
- [ ] Timer countdown
- [ ] Auto-save progress
- [ ] Audio player cho Listening
- [ ] Text editor cho Writing
- [ ] Voice recording cho Speaking
- [ ] Instant AI grading
- [ ] Detailed feedback
- [ ] Certificate generation

#### Test Scenarios:
- Làm bài thi hoàn chỉnh
- Làm bài thi hết giờ
- Xem kết quả AI
- Nhận feedback giáo viên
- Download certificate

---

### US3.3: Quản lý tiến độ học tập (Student App)

**Mô tả:** Là học viên, tôi muốn theo dõi tiến độ học tập của mình

#### Kịch bản chính:

**1. Xem dashboard học tập**
- Học viên đăng nhập vào app
- Xem tổng quan tiến độ
- Xem khóa học đang học
- Xem lịch sử bài thi
- Xem achievements và badges

**2. Xem báo cáo chi tiết**
- Xem thống kê thời gian học
- Xem điểm số các bài thi
- Xem tiến độ từng khóa học
- Xem ghi chú đã tạo

**3. Xem lịch sử đơn hàng**
- Xem danh sách các bài thi đã mua
- Xem chi tiết từng giao dịch (ngày mua, giá, phương thức thanh toán)
- Xem trạng thái thanh toán và giao hàng
- Download hóa đơn điện tử
- Xem lịch sử sử dụng voucher

**4. Đặt mục tiêu học tập**
- Đặt mục tiêu thời gian học/ngày
- Đặt mục tiêu hoàn thành khóa học
- Nhận reminder khi chưa đạt mục tiêu
- Xem streak học tập

#### Acceptance Criteria:
- [ ] Dashboard tổng quan
- [ ] Progress visualization
- [ ] Goal setting
- [ ] Reminder system
- [ ] Achievement system
- [ ] Export reports
- [ ] Mobile notifications
- [ ] Order history với chi tiết giao dịch
- [ ] Invoice download functionality
- [ ] Voucher usage tracking

#### Test Scenarios:
- Xem dashboard
- Đặt mục tiêu
- Nhận reminder
- Xem achievements
- Export báo cáo
- Xem lịch sử đơn hàng
- Download hóa đơn
- Xem chi tiết giao dịch

---

## EPIC 4: HỆ THỐNG ĐÁNH GIÁ VÀ CHẤM ĐIỂM

### US4.1: Chấm bài thi có thu phí (Teacher Portal)

**Mô tả:** Là giáo viên, tôi muốn chấm bài thi có thu phí của học viên một cách hiệu quả

#### Kịch bản chính:

**1. Chấm bài thi Writing**
- Giáo viên xem danh sách bài thi chờ chấm
- Chọn bài thi cần chấm
- Xem câu trả lời của học viên
- Chấm điểm theo tiêu chí
- Viết feedback chi tiết
- Submit kết quả chấm

**2. Chấm bài thi Speaking**
- Nghe audio recording của học viên
- Chấm điểm pronunciation, fluency, grammar
- Viết feedback cụ thể
- Ghi âm feedback bằng giọng nói

**3. Chấm bài thi với AI hỗ trợ**
- AI đưa ra điểm số gợi ý
- Giáo viên review và điều chỉnh
- AI tạo feedback template
- Giáo viên customize feedback

#### Acceptance Criteria:
- [ ] Audio player cho Speaking
- [ ] Rich text editor cho feedback
- [ ] AI scoring suggestions
- [ ] Voice feedback recording
- [ ] Batch grading
- [ ] Quality control
- [ ] Turnaround time tracking

#### Test Scenarios:
- Chấm bài Writing
- Chấm bài Speaking
- Sử dụng AI hỗ trợ
- Batch grading
- Quality control

---

### US4.2: Quản lý đánh giá (Admin Back Office)

**Mô tả:** Là admin, tôi muốn quản lý hệ thống đánh giá và chấm điểm

#### Kịch bản chính:

**1. Quản lý AI grading**
- Cấu hình AI models
- Thiết lập tiêu chí chấm điểm
- Monitor AI accuracy
- Fine-tune AI parameters

**2. Quản lý giáo viên chấm bài**
- Phân công bài thi cho giáo viên
- Theo dõi tiến độ chấm bài
- Quản lý workload
- Đánh giá chất lượng chấm bài

**3. Quản lý chất lượng**
- Review kết quả chấm bài
- Xử lý khiếu nại từ học viên
- Calibration giữa các giáo viên
- Audit trail

#### Acceptance Criteria:
- [ ] AI configuration panel
- [ ] Teacher assignment system
- [ ] Quality monitoring
- [ ] Complaint handling
- [ ] Audit trail
- [ ] Performance metrics

#### Test Scenarios:
- Cấu hình AI
- Phân công giáo viên
- Review chất lượng
- Xử lý khiếu nại

---

## EPIC 5: QUẢN LÝ TÀI CHÍNH VÀ THANH TOÁN

### US5.1: Quản lý thanh toán từ bài thi thử (Accounting Portal)

**Mô tả:** Là nhân viên kế toán, tôi muốn quản lý tất cả giao dịch tài chính từ việc bán bài thi thử

#### Kịch bản chính:

**1. Xem báo cáo tài chính**
- Đăng nhập vào Accounting Portal
- Xem dashboard tài chính
- Xem doanh thu từ bài thi thử theo ngày/tháng/năm
- Xem chi phí và lợi nhuận
- Export báo cáo Excel/PDF

**2. Quản lý giao dịch bài thi**
- Xem danh sách giao dịch mua bài thi
- Filter theo trạng thái, phương thức
- Xử lý giao dịch thất bại
- Refund cho học viên
- Reconcile với ngân hàng

**3. Quản lý commission giáo viên**
- Tính commission cho giáo viên chấm bài thi
- Xem báo cáo commission
- Chuyển tiền cho giáo viên
- Quản lý thuế

#### Acceptance Criteria:
- [ ] Real-time financial dashboard
- [ ] Transaction management
- [ ] Refund processing
- [ ] Commission calculation
- [ ] Tax management
- [ ] Bank reconciliation
- [ ] Export reports
- [ ] Audit trail

#### Test Scenarios:
- Xem báo cáo tài chính
- Xử lý refund
- Tính commission
- Bank reconciliation
- Export reports

---

### US5.2: Quản lý voucher và khuyến mại cho bài thi thử (Admin Back Office)

**Mô tả:** Là admin, tôi muốn quản lý voucher và chương trình khuyến mại cho bài thi thử

#### Kịch bản chính:

**1. Tạo voucher cho bài thi thử**
- Admin tạo voucher code cho bài thi thử
- Thiết lập loại giảm giá (% hoặc số tiền)
- Thiết lập điều kiện sử dụng (áp dụng cho bài thi nào)
- Thiết lập thời hạn
- Publish voucher

**2. Quản lý chương trình khuyến mại**
- Tạo flash sale cho bài thi thử
- Thiết lập bundle deals (mua nhiều bài thi)
- Tạo referral program
- Quản lý loyalty points

**3. Theo dõi hiệu quả**
- Xem thống kê sử dụng voucher cho bài thi
- Phân tích conversion rate
- Đo lường ROI từ bài thi thử
- A/B test các chương trình

#### Acceptance Criteria:
- [ ] Voucher generation
- [ ] Campaign management
- [ ] Analytics dashboard
- [ ] A/B testing
- [ ] Email marketing integration
- [ ] Mobile push notifications

#### Test Scenarios:
- Tạo voucher cho bài thi thử
- Chạy flash sale cho bài thi
- Phân tích hiệu quả
- A/B test các chương trình

---

## EPIC 6: HỆ THỐNG HỖ TRỢ VÀ TƯƠNG TÁC

### US6.1: Hỗ trợ khách hàng (Student App)

**Mô tả:** Là học viên, tôi muốn được hỗ trợ khi gặp vấn đề

#### Kịch bản chính:

**1. Tạo ticket hỗ trợ**
- Học viên vào "Hỗ trợ"
- Chọn loại vấn đề
- Mô tả chi tiết vấn đề
- Upload file đính kèm
- Submit ticket
- Nhận email xác nhận

**2. Chat trực tiếp**
- Học viên click "Chat với support"
- Kết nối với agent
- Chat real-time
- Share screen nếu cần
- Nhận transcript chat

**3. Xem FAQ và hướng dẫn**
- Browse FAQ categories
- Search câu hỏi
- Xem video hướng dẫn
- Rate helpfulness

#### Acceptance Criteria:
- [ ] Ticket system
- [ ] Live chat
- [ ] FAQ system
- [ ] Video tutorials
- [ ] File upload
- [ ] Email notifications
- [ ] Mobile support

#### Test Scenarios:
- Tạo ticket
- Chat với support
- Xem FAQ
- Upload file

---

### US6.2: Quản lý hỗ trợ (Admin Back Office)

**Mô tả:** Là admin, tôi muốn quản lý hệ thống hỗ trợ khách hàng

#### Kịch bản chính:

**1. Quản lý tickets**
- Xem danh sách tickets
- Phân loại theo priority
- Assign cho agent
- Respond tickets
- Escalate khi cần
- Close tickets

**2. Quản lý live chat**
- Monitor chat sessions
- Assign chat cho agent
- View chat history
- Generate chat reports

**3. Quản lý knowledge base**
- Tạo/edit FAQ
- Upload video tutorials
- Organize content
- Track usage analytics

#### Acceptance Criteria:
- [ ] Ticket management
- [ ] Chat monitoring
- [ ] Knowledge base
- [ ] Agent dashboard
- [ ] Analytics
- [ ] Escalation rules

#### Test Scenarios:
- Quản lý tickets
- Monitor chat
- Tạo FAQ
- Xem analytics

---

### US6.3: Tương tác cộng đồng (Student App)

**Mô tả:** Là học viên, tôi muốn tương tác với cộng đồng học viên khác

#### Kịch bản chính:

**1. Tham gia forum**
- Học viên vào "Cộng đồng"
- Xem các topic discussion
- Tạo post mới
- Comment và like posts
- Follow users

**2. Study groups**
- Tạo study group
- Invite bạn bè
- Share materials
- Schedule study sessions
- Track group progress

**3. Peer review**
- Review bài viết của bạn
- Nhận feedback từ peers
- Improve writing skills
- Build network

#### Acceptance Criteria:
- [ ] Forum system
- [ ] Study groups
- [ ] Peer review
- [ ] Social features
- [ ] Moderation tools
- [ ] Mobile app

#### Test Scenarios:
- Tham gia forum
- Tạo study group
- Peer review
- Social interaction

---

## EPIC 7: QUẢN TRỊ, BÁO CÁO VÀ BẢO MẬT

### US7.1: Dashboard quản trị (Admin Back Office)

**Mô tả:** Là admin, tôi muốn có dashboard tổng quan về toàn bộ hệ thống

#### Kịch bản chính:

**1. Dashboard tổng quan**
- Xem KPIs chính
- Xem biểu đồ doanh thu
- Xem thống kê người dùng
- Xem performance metrics
- Customize dashboard

**1.1. Báo cáo bán hàng theo sản phẩm**
- Xem top bài thi bán chạy nhất
- Xem doanh thu từng bài thi cụ thể
- Phân tích hiệu suất từng sản phẩm
- So sánh doanh thu giữa các bài thi
- Xem tỷ lệ chuyển đổi từ xem → mua

**2. Báo cáo chi tiết**
- Generate báo cáo theo yêu cầu
- Schedule báo cáo tự động
- Export báo cáo
- Share báo cáo với team

**2.1. Báo cáo theo thời gian nâng cao**
- So sánh doanh thu giữa các kỳ (tuần, tháng, quý)
- Xu hướng bán hàng theo thời gian
- Phân tích theo mùa và ngày lễ
- Dự đoán doanh thu tương lai
- Báo cáo real-time và historical data

**3. Monitoring hệ thống**
- Monitor server performance
- Track error rates
- Monitor user activity
- Set up alerts

#### Acceptance Criteria:
- [ ] Real-time dashboard
- [ ] Customizable widgets
- [ ] Report generation
- [ ] Scheduled reports
- [ ] System monitoring
- [ ] Alert system
- [ ] Export options
- [ ] Product performance analytics
- [ ] Sales trend analysis
- [ ] Revenue forecasting
- [ ] Conversion rate tracking
- [ ] Comparative period analysis

#### Test Scenarios:
- Xem dashboard
- Generate báo cáo
- Monitor hệ thống
- Set up alerts
- Xem báo cáo bán hàng theo sản phẩm
- So sánh doanh thu giữa các kỳ
- Phân tích xu hướng bán hàng
- Export báo cáo chi tiết

---

### US7.2: Quản lý nội dung (Admin Back Office)

**Mô tả:** Là admin, tôi muốn quản lý tất cả nội dung trên hệ thống

#### Kịch bản chính:

**1. Quản lý khóa học**
- Review khóa học mới
- Edit thông tin khóa học
- Manage pricing
- Handle complaints

**2. Quản lý bài thi**
- Review bài thi mới
- Manage question bank
- Update answer keys
- Monitor cheating

**3. Quản lý nội dung marketing**
- Manage homepage content
- Create landing pages
- Manage blog posts
- SEO optimization

#### Acceptance Criteria:
- [ ] Content management
- [ ] Version control
- [ ] SEO tools
- [ ] Analytics
- [ ] A/B testing
- [ ] Mobile optimization

#### Test Scenarios:
- Quản lý khóa học
- Quản lý bài thi
- Tạo landing page
- SEO optimization

---

### US7.3: Bảo mật hệ thống (Admin Back Office)

**Mô tả:** Là admin, tôi muốn đảm bảo hệ thống an toàn và tuân thủ quy định

#### Kịch bản chính:

**1. Quản lý bảo mật**
- Monitor security logs
- Manage user permissions
- Set up 2FA
- Handle security incidents

**2. Data protection**
- Implement GDPR compliance
- Manage data retention
- Handle data requests
- Encrypt sensitive data

**3. System monitoring**
- Monitor system health
- Track performance
- Handle incidents
- Plan maintenance

#### Acceptance Criteria:
- [ ] Security monitoring
- [ ] Access control
- [ ] Data encryption
- [ ] GDPR compliance
- [ ] Incident response
- [ ] Audit logging
- [ ] Backup system

#### Test Scenarios:
- Monitor security
- Handle incidents
- GDPR compliance
- System maintenance

---

### US7.4: Quản lý tuân thủ (Admin Back Office)

**Mô tả:** Là admin, tôi muốn đảm bảo hệ thống tuân thủ các quy định pháp lý

#### Kịch bản chính:

**1. Privacy management**
- Manage privacy settings
- Handle data requests
- Update privacy policy
- Consent management

**2. Compliance reporting**
- Generate compliance reports
- Track audit requirements
- Handle regulatory requests
- Document procedures

**3. Risk management**
- Identify risks
- Assess impact
- Implement controls
- Monitor effectiveness

#### Acceptance Criteria:
- [ ] Privacy controls
- [ ] Compliance reporting
- [ ] Risk assessment
- [ ] Audit trail
- [ ] Documentation
- [ ] Training system

#### Test Scenarios:
- Privacy management
- Compliance reporting
- Risk assessment
- Audit preparation

---

### US7.5: Quản lý bài viết nâng cao (Admin Back Office + Teacher Portal)

**Mô tả:** Là admin/giáo viên, tôi muốn quản lý các bài viết với phân quyền chi tiết để đăng tải nội dung học tập và thông báo

#### Kịch bản chính:

**1. Tạo bài viết mới**
- Admin/giáo viên vào "Quản lý nội dung"
- Click "Tạo bài viết mới"
- Nhập tiêu đề, nội dung với rich text editor
- Chọn phân loại (bài học, thông báo, tin tức, hướng dẫn)
- Thiết lập phân quyền xem (public, private, theo role)
- Upload hình ảnh đính kèm (tối đa 5MB)
- Thiết lập SEO metadata (title, description, keywords)
- Preview bài viết trước khi publish
- Publish ngay hoặc lưu draft

**2. Quản lý bài viết**
- Xem danh sách tất cả bài viết với pagination
- Search theo tiêu đề, nội dung, tác giả
- Filter theo phân loại, tác giả, trạng thái, ngày tạo
- Edit, xóa, duplicate bài viết
- Thay đổi phân quyền và trạng thái
- Quản lý comments và interactions (nếu có)
- Export danh sách bài viết

**3. Phân quyền chi tiết**
- Thiết lập ai được xem bài viết (public, authenticated users, specific roles)
- Thiết lập ai được edit bài viết (tác giả, admin, specific roles)
- Thiết lập ai được xóa bài viết (admin only, tác giả + admin)
- Thiết lập ai được publish bài viết (admin, editor, tác giả)
- Audit log cho mọi thay đổi quyền hạn

**4. Quản lý nội dung và SEO**
- Tối ưu hóa SEO cho từng bài viết
- Quản lý tags và categories
- Thiết lập featured images
- Quản lý URL slugs
- Preview trên mobile và desktop
- Analytics về views và engagement

#### Acceptance Criteria:
- [ ] Rich text editor với formatting options (bold, italic, lists, links)
- [ ] File upload cho hình ảnh (tối đa 5MB, hỗ trợ JPG, PNG, GIF)
- [ ] Phân quyền granular (view, edit, delete, publish)
- [ ] Preview trước khi publish với responsive design
- [ ] Version control cho bài viết
- [ ] Search và filter functionality mạnh mẽ
- [ ] SEO optimization (meta tags, URL, sitemap)
- [ ] Mobile responsive design
- [ ] Audit trail cho mọi thay đổi
- [ ] Export functionality (PDF, Excel)
- [ ] Comments system (optional)
- [ ] Analytics integration

#### Test Scenarios:
- Tạo bài viết với phân quyền khác nhau
- Edit bài viết đã publish
- Test phân quyền xem bài viết theo role
- Upload file quá lớn
- Preview bài viết trên mobile/desktop
- Test SEO optimization
- Export danh sách bài viết
- Test audit trail functionality

---

## USER JOURNEY MAPS

### Journey 1: Học viên mới đăng ký và mua khóa học

**Touchpoints:**
1. **Discovery**: Tìm thấy website qua Google/Facebook ads
2. **Landing**: Truy cập homepage, xem thông tin
3. **Registration**: Đăng ký tài khoản, xác thực email
4. **Browse**: Tìm kiếm khóa học phù hợp
5. **Evaluation**: Xem preview, đọc reviews
6. **Purchase**: Thanh toán khóa học
7. **Learning**: Bắt đầu học, theo dõi progress
8. **Support**: Liên hệ hỗ trợ khi cần

**Pain Points:**
- Quá trình đăng ký phức tạp
- Không tìm thấy khóa học phù hợp
- Thanh toán gặp lỗi
- Không biết cách sử dụng hệ thống

**Opportunities:**
- Simplify registration process
- Improve search and recommendation
- Optimize payment flow
- Provide better onboarding

### Journey 2: Giáo viên tạo và bán khóa học

**Touchpoints:**
1. **Discovery**: Tìm hiểu về platform
2. **Registration**: Đăng ký làm giáo viên
3. **Approval**: Chờ admin phê duyệt
4. **Onboarding**: Học cách sử dụng platform
5. **Creation**: Tạo khóa học đầu tiên
6. **Review**: Chờ admin review
7. **Publishing**: Khóa học được publish
8. **Teaching**: Chấm bài, tương tác với học viên
9. **Earning**: Nhận commission

**Pain Points:**
- Quá trình phê duyệt lâu
- Không biết cách tạo nội dung hấp dẫn
- Khó quản lý nhiều khóa học
- Không nhận được feedback kịp thời

**Opportunities:**
- Streamline approval process
- Provide content creation tools
- Offer training and support
- Improve communication tools

### Journey 3: Admin quản lý hệ thống

**Touchpoints:**
1. **Login**: Đăng nhập admin portal
2. **Dashboard**: Xem tổng quan hệ thống
3. **Review**: Review nội dung mới
4. **Management**: Quản lý users, courses, payments
5. **Support**: Xử lý tickets hỗ trợ
6. **Reporting**: Tạo báo cáo
7. **Monitoring**: Monitor system performance

**Pain Points:**
- Quá nhiều thông tin cần xử lý
- Khó theo dõi tất cả hoạt động
- Thiếu công cụ phân tích
- Khó dự đoán vấn đề

**Opportunities:**
- Improve dashboard design
- Add predictive analytics
- Automate routine tasks
- Better reporting tools

---

## TECHNICAL SPECIFICATIONS

### Microservices Architecture Overview

**Frontend Layer:**
- **Web Application**: Blazor Server/WebAssembly với .NET 8
- **Mobile Application**: Flutter với Dart
- **API Gateway**: Ocelot hoặc YARP cho routing và load balancing
- **CDN**: CloudFlare cho static assets và caching

**Microservices Layer (Tối ưu hóa):**

### **Phase 1: MVP (3 Services)**
### **1. Core Service** 
- **Technology**: .NET Core 8 + ASP.NET Core Web API
- **Database**: PostgreSQL (users, payments, enrollments)
- **Message Queue**: RabbitMQ cho core events
- **Responsibilities**: 
  - User management (auth, profiles)
  - Payment processing
  - Course enrollments
- **Scaling**: Horizontal scaling với load balancer

### **2. Content Service**
- **Technology**: .NET Core 8 + ASP.NET Core Web API
- **Database**: MongoDB (courses, lessons, exams)
- **Message Queue**: RabbitMQ cho content events
- **Responsibilities**:
  - Course CRUD và content management
  - Learning progress tracking
  - Exam creation và submissions
- **Scaling**: Sharding theo course categories

### **3. Notification Service**
- **Technology**: .NET Core 8 + SignalR
- **Database**: Redis (real-time messaging)
- **Message Queue**: RabbitMQ cho notification events
- **Responsibilities**: 
  - Push notifications
  - Real-time updates
  - Email/SMS notifications
- **Scaling**: Redis Cluster

### **Phase 2: Scale Up (Tách thêm services khi cần)**
### **4. Payment Service** (Tách từ Core Service)
- Khi payment volume > 10,000 transactions/day
- **Database**: PostgreSQL (dedicated payment DB)
- **Responsibilities**: Payment processing, billing, refunds

### **5. AI Grading Service** (Tách từ Content Service)
- Khi exam volume > 1,000 exams/day
- **Technology**: .NET Core 8 + Python microservice
- **Database**: MongoDB (grading results, AI models)
- **Responsibilities**: Automated grading, feedback generation

### **Phase 3: Enterprise (Full Microservices)**
### **6. User Management Service** (Tách từ Core Service)
- Khi user base > 100,000 users
- **Database**: PostgreSQL (dedicated user DB)
- **Responsibilities**: Authentication, authorization, user profiles

### **7. Learning Analytics Service** (Tách từ Content Service)
- Khi cần advanced analytics
- **Database**: MongoDB (analytics data)
- **Responsibilities**: Learning analytics, progress reports

**Database Strategy:**

### **PostgreSQL (Transactional Data)**
```sql
-- User Management
CREATE TABLE users (
    id SERIAL PRIMARY KEY,
    email VARCHAR(255) UNIQUE NOT NULL,
    password_hash VARCHAR(255) NOT NULL,
    role VARCHAR(50) NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- Payment & Billing
CREATE TABLE payments (
    id SERIAL PRIMARY KEY,
    user_id INTEGER REFERENCES users(id),
    amount DECIMAL(10,2) NOT NULL,
    status VARCHAR(50) NOT NULL,
    payment_method VARCHAR(50),
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- Course Enrollments
CREATE TABLE enrollments (
    id SERIAL PRIMARY KEY,
    user_id INTEGER REFERENCES users(id),
    course_id VARCHAR(50) NOT NULL,
    enrolled_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    status VARCHAR(50) DEFAULT 'active'
);
```

### **MongoDB (Document Data)**
```javascript
// Course Content
{
  _id: ObjectId,
  title: "IELTS Preparation Course",
  description: "...",
  lessons: [
    {
      id: 1,
      title: "Reading Skills",
      videoUrl: "...",
      duration: 1800,
      quiz: {...}
    }
  ],
  metadata: {
    level: "B2",
    category: "IELTS",
    tags: ["reading", "writing"]
  }
}

// Learning Progress
{
  userId: 123,
  courseId: 456,
  progress: {
    completedLessons: [1, 2, 3],
    totalTime: 3600,
    lastAccessed: ISODate(),
    quizScores: [...]
  }
}

// Exam Submissions
{
  examId: 789,
  userId: 123,
  answers: {
    reading: [...],
    listening: [...],
    writing: "...",
    speaking: "audio_url"
  },
  submittedAt: ISODate(),
  status: "graded"
}
```

**Infrastructure & Scaling:**

### **Container Orchestration**
```yaml
# Kubernetes Deployment
apiVersion: apps/v1
kind: Deployment
metadata:
  name: course-service
spec:
  replicas: 5  # Auto-scaling từ 3-10 pods
  selector:
    matchLabels:
      app: course-service
  template:
    spec:
      containers:
      - name: course-service
        image: education/course-service:latest
        resources:
          requests:
            memory: "256Mi"
            cpu: "250m"
          limits:
            memory: "512Mi"
            cpu: "500m"
```

### **Auto-scaling Configuration**
```yaml
# Horizontal Pod Autoscaler
apiVersion: autoscaling/v2
kind: HorizontalPodAutoscaler
metadata:
  name: course-service-hpa
spec:
  scaleTargetRef:
    apiVersion: apps/v1
    kind: Deployment
    name: course-service
  minReplicas: 3
  maxReplicas: 20
  metrics:
  - type: Resource
    resource:
      name: cpu
      target:
        type: Utilization
        averageUtilization: 70
  - type: Resource
    resource:
      name: memory
      target:
        type: Utilization
        averageUtilization: 80
```

### **Database Scaling Strategy**

**PostgreSQL Scaling:**
- **Read Replicas**: 3 read replicas cho reporting
- **Connection Pooling**: 100 connections per service với PgBouncer
- **Partitioning**: Partition by date cho large tables
- **Indexing**: Optimized indexes cho frequent queries
- **Streaming Replication**: Asynchronous replication

**MongoDB Scaling:**
- **Sharding**: Shard by courseId và userId
- **Replica Sets**: 3-node replica sets cho high availability
- **Read Preferences**: Secondary reads cho analytics
- **Capped Collections**: Cho real-time data (notifications)

### **Load Balancing & Caching**
```csharp
// Redis Cluster Configuration
services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = "redis-cluster:6379,redis-cluster:6380,redis-cluster:6381";
    options.InstanceName = "EducationCache";
});

// Distributed Caching
services.AddScoped<ICacheService, RedisCacheService>();

// API Gateway với Load Balancing
services.AddOcelot()
    .AddConsul()
    .AddConfigStoredInConsul();
```

### **Performance & Scalability Targets**

**Concurrent Users:**
- **Target**: 100,000 concurrent users
- **Peak**: 200,000 concurrent users
- **Response Time**: < 200ms cho 95% requests
- **Availability**: 99.9% uptime

**Database Performance:**
- **PostgreSQL**: 15,000 TPS (Transactions Per Second)
- **MongoDB**: 50,000 OPS (Operations Per Second)
- **Redis**: 100,000 OPS
- **RabbitMQ**: 50,000 messages/second
- **Connection Pool**: 1,000 connections per service

**Scaling Triggers:**
- **CPU Usage**: > 70% → Scale up
- **Memory Usage**: > 80% → Scale up
- **Response Time**: > 500ms → Scale up
- **Queue Length**: > 100 items → Scale up

**Third-party Integrations:**
- **Payments**: VNPay, MoMo, Banking APIs (with retry policies)
- **File Storage**: Azure Blob Storage với CDN
- **Email**: SendGrid với rate limiting
- **SMS**: Twilio với queue management
- **AI Services**: Azure Cognitive Services với batch processing
- **Video Streaming**: Azure Media Services với adaptive streaming

### Microservices Communication

**Service-to-Service Communication:**
```csharp
// HTTP REST APIs với Circuit Breaker
services.AddHttpClient<ICourseService, CourseService>()
    .AddPolicyHandler(GetRetryPolicy())
    .AddPolicyHandler(GetCircuitBreakerPolicy());

// RabbitMQ Configuration
services.AddMassTransit(x =>
{
    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("rabbitmq://rabbitmq-cluster:5672", h =>
        {
            h.Username("admin");
            h.Password("password");
        });
        cfg.ConfigureEndpoints(context);
    });
});

// RabbitMQ Health Check
services.AddHealthChecks()
    .AddRabbitMQ("amqp://admin:password@rabbitmq-cluster:5672");
```

**Event-Driven Architecture:**
```csharp
// Domain Events
public class CourseEnrolledEvent
{
    public int UserId { get; set; }
    public int CourseId { get; set; }
    public DateTime EnrolledAt { get; set; }
}

// Event Handlers
public class CourseEnrolledHandler : IEventHandler<CourseEnrolledEvent>
{
    public async Task Handle(CourseEnrolledEvent @event)
    {
        // Update learning progress
        // Send welcome email
        // Update analytics
    }
}
```

### **High Availability & Disaster Recovery**

**Multi-Region Deployment:**
- **Primary Region**: Asia Pacific (Singapore)
- **Secondary Region**: Asia Pacific (Tokyo)
- **Database Replication**: Cross-region replication
- **Failover**: Automatic failover trong 30 giây

**Backup Strategy:**
- **PostgreSQL**: WAL archiving + pg_dump hàng ngày
- **MongoDB**: Point-in-time recovery với oplog
- **Redis**: RDB + AOF persistence
- **RabbitMQ**: Queue persistence + message durability
- **File Storage**: Geo-redundant storage

**Monitoring & Observability:**
```csharp
// Application Insights
services.AddApplicationInsightsTelemetry();

// Health Checks
services.AddHealthChecks()
    .AddNpgSql(postgresConnectionString)
    .AddMongoDb(mongoConnectionString)
    .AddRedis(redisConnectionString)
    .AddRabbitMQ(rabbitmqConnectionString);

// Distributed Tracing
services.AddOpenTelemetry()
    .WithTracing(builder => builder
        .AddAspNetCoreInstrumentation()
        .AddHttpClientInstrumentation()
        .AddSqlClientInstrumentation());
```

### API Design (.NET Core 8)

**RESTful APIs với ASP.NET Core Web API:**
```csharp
[ApiController]
[Route("api/[controller]")]
public class CoursesController : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CourseDto>>> GetCourses()
    
    [HttpPost]
    [Authorize(Roles = "Teacher")]
    public async Task<ActionResult<CourseDto>> CreateCourse(CreateCourseDto dto)
    
    [HttpGet("{id}")]
    public async Task<ActionResult<CourseDto>> GetCourse(int id)
    
    [HttpPut("{id}")]
    [Authorize(Roles = "Teacher")]
    public async Task<IActionResult> UpdateCourse(int id, UpdateCourseDto dto)
}
```

**Authentication & Authorization:**
- **JWT Bearer Tokens**: ASP.NET Core Identity + JWT
- **Refresh Tokens**: Long-term session management
- **Role-based Authorization**: [Authorize(Roles = "Admin,Teacher")]
- **Policy-based Authorization**: Custom authorization policies
- **Rate Limiting**: ASP.NET Core Rate Limiting middleware

**API Features:**
- **Swagger/OpenAPI**: Auto-generated API documentation
- **Model Validation**: Data Annotations + FluentValidation
- **Global Exception Handling**: Custom exception middleware
- **Response Caching**: Output caching cho static data
- **Compression**: Response compression middleware

### Security Requirements

**Data Protection:**
- HTTPS cho tất cả communications
- Encryption cho sensitive data
- GDPR compliance
- Data retention policies

**Authentication & Authorization:**
- Multi-factor authentication
- Password policies
- Session management
- Role-based permissions

**Infrastructure Security:**
- Firewall configuration
- Intrusion detection
- Regular security audits
- Backup và disaster recovery

### Performance Requirements

**Response Times:**
- **Web App Load**: < 2 seconds (Vue.js + Vite optimization)
- **API Responses**: < 300ms (.NET Core 8 performance)
- **Search Results**: < 500ms (Elasticsearch)
- **Video Streaming**: < 1 second (CDN + streaming optimization)
- **Mobile App**: < 1.5 seconds (Vue.js + Capacitor)

**Scalability:**
- **Concurrent Users**: 50,000+ users
- **Database**: PostgreSQL với connection pooling
- **Caching**: Redis cluster cho session và data caching
- **Auto-scaling**: Azure App Service hoặc AWS ECS
- **Load Balancing**: Application Gateway với health checks

**Availability:**
- **Uptime**: 99.95% SLA
- **Redundancy**: Multi-region deployment
- **Disaster Recovery**: Automated backup và restore
- **Monitoring**: Application Insights + custom dashboards
- **Alerting**: Real-time notifications cho critical issues

### Technology Stack Summary

**Frontend Stack:**
- Blazor Server/WebAssembly + C#
- MudBlazor / Radzen UI
- Built-in state management
- .NET CLI + Flutter CLI
- Flutter + Dart

**Backend Stack:**
- .NET Core 8 + ASP.NET Core Web API (Microservices)
- Entity Framework Core (PostgreSQL) + MongoDB Driver
- PostgreSQL + MongoDB + Redis Cluster + RabbitMQ
- SignalR (Real-time notifications)
- MassTransit + RabbitMQ (Message Queue)

**DevOps & Infrastructure:**
- **Containerization**: Docker + Kubernetes
- **Cloud Platform**: Azure (Primary) + AWS (Secondary)
- **CI/CD**: GitHub Actions + Azure DevOps
- **Monitoring**: Application Insights + Prometheus + Grafana
- **Service Mesh**: Istio cho microservices communication
- **API Gateway**: Ocelot + YARP với rate limiting
- **Message Queue**: RabbitMQ + Azure Service Bus
- **Caching**: Redis Cluster + Azure Cache for Redis

### Đánh giá độ khả dụng (Feasibility Assessment)

**Backend (.NET Core 8):**
✅ **Khả thi cao**
- Hiệu suất vượt trội: .NET Core 8 có performance tốt nhất trong các framework backend
- Đa nền tảng: Chạy được trên Windows, Linux, macOS
- Ecosystem mạnh: Entity Framework Core, SignalR, ASP.NET Identity
- Cộng đồng lớn: Microsoft support + open source community
- Tài liệu phong phú: Official docs + tutorials

**Frontend Web (Blazor):**
✅ **Khả thi cao**
- **Full-stack C#**: Cùng ngôn ngữ với backend, giảm context switching
- **Performance tốt**: Blazor Server real-time, Blazor WebAssembly client-side
- **Rich UI components**: MudBlazor, Radzen, Syncfusion
- **Hot reload**: Excellent development experience
- **Type safety**: Strong typing với C#
- **SEO friendly**: Server-side rendering support

**Mobile App (Flutter):**
✅ **Khả thi cao**
- **True native performance**: Compiled to native ARM code
- **Single codebase**: iOS + Android từ 1 codebase
- **Google backing**: Strong ecosystem và long-term support
- **Hot reload**: Fast development cycle
- **Rich UI**: Material Design 3, Cupertino widgets
- **Cross-platform**: Web, Desktop, Mobile từ 1 codebase

**Lợi ích của Blazor + Flutter:**

### **1. Code Sharing (60-70%)**
```csharp
// Shared models (C#)
public class Course
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
}

// Shared API client (C#)
public class CourseApiClient
{
    public async Task<List<Course>> GetCoursesAsync()
    {
        return await httpClient.GetFromJsonAsync<List<Course>>("/api/courses");
    }
    
    public async Task<Course> GetCourseAsync(int id)
    {
        return await httpClient.GetFromJsonAsync<Course>($"/api/courses/{id}");
    }
}

// Shared business logic (C#)
public static class CourseUtils
{
    public static string FormatPrice(decimal price)
    {
        return $"{price:N0} VNĐ";
    }
    
    public static double CalculateProgress(int completed, int total)
    {
        return total > 0 ? (double)completed / total * 100 : 0;
    }
}
```

### **2. Shared State Management**
```csharp
// Blazor: Built-in state management
@inject IJSRuntime JSRuntime
@inject HttpClient Http

// Flutter: Provider/Riverpod
class CourseProvider extends ChangeNotifier {
  List<Course> _courses = [];
  bool _loading = false;
  
  List<Course> get courses => _courses;
  bool get loading => _loading;
  
  Future<void> loadCourses() async {
    _loading = true;
    notifyListeners();
    
    _courses = await CourseApiClient().getCoursesAsync();
    _loading = false;
    notifyListeners();
  }
}
```

### **3. Shared Validation & Utilities**
```csharp
// Shared validation (C#)
public static class Validators
{
    public static bool IsValidEmail(string email)
    {
        return Regex.IsMatch(email, @"^[^\s@]+@[^\s@]+\.[^\s@]+$");
    }
    
    public static bool IsValidPhone(string phone)
    {
        return Regex.IsMatch(phone, @"^[0-9]{10,11}$");
    }
}

// Shared formatters (C#)
public static class Formatters
{
    public static string FormatCurrency(decimal amount)
    {
        return $"{amount:N0} VNĐ";
    }
    
    public static string FormatDate(DateTime date)
    {
        return date.ToString("dd/MM/yyyy", CultureInfo.GetCultureInfo("vi-VN"));
    }
}
```

### **4. Shared API Integration**
```csharp
// Shared HTTP client configuration
public class ApiClient
{
    private readonly HttpClient _httpClient;
    
    public ApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri("https://api.education.com/");
        _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
    }
    
    // Shared authentication
    public void SetAuthToken(string token)
    {
        _httpClient.DefaultRequestHeaders.Authorization = 
            new AuthenticationHeaderValue("Bearer", token);
    }
}
```

**Khuyến nghị:**
1. **Phase 1**: Web app với Blazor Server (faster development)
2. **Phase 2**: Mobile app với Flutter (native performance)
3. **Phase 3**: Migrate to Blazor WebAssembly (if needed)
4. **Shared Library**: Tạo .NET Standard library cho shared code

**Tổng kết độ khả dụng: 90%**
- Backend: 95% khả thi
- Web Frontend: 90% khả thi  
- Mobile Frontend: 95% khả thi
- **Code sharing: 60-70%** (tiết kiệm 50-60% thời gian development)

### **Framework Alternatives (Hiệu năng tương đương/better)**

**1. Svelte/SvelteKit** ⚡ **Hiệu năng cao nhất**
- **Ưu điểm:**
  - **Compile-time optimization**: Biên dịch thành vanilla JS, không cần runtime
  - **Bundle size nhỏ**: 10-20KB thay vì 100KB+ của React
  - **Performance**: Nhanh hơn React 2-3x trong benchmarks
  - **Developer experience**: Syntax đơn giản, ít boilerplate
  - **Mobile**: Svelte Native (tương tự React Native)

- **Nhược điểm:**
  - Ecosystem nhỏ hơn React
  - Ít developers có kinh nghiệm
  - Learning curve cho team

**2. Solid.js** 🚀 **Hiệu năng cao + React-like**
- **Ưu điểm:**
  - **Fine-grained reactivity**: Chỉ update phần cần thiết
  - **No Virtual DOM**: Direct DOM manipulation
  - **React-like API**: Dễ migrate từ React
  - **Bundle size**: ~7KB gzipped
  - **Performance**: Nhanh hơn React trong nhiều cases

- **Nhược điểm:**
  - Ecosystem còn non trẻ
  - Ít community support
  - Không có mobile framework tương đương

**3. Flutter** 📱 **Cross-platform native**
- **Ưu điểm:**
  - **True native performance**: Compiled to native code
  - **Single codebase**: Web + Mobile + Desktop
  - **Google backing**: Strong ecosystem và support
  - **Hot reload**: Excellent development experience
  - **UI consistency**: Material Design built-in

- **Nhược điểm:**
  - **Dart language**: Cần học ngôn ngữ mới
  - **Web performance**: Chưa tối ưu bằng JS frameworks
  - **Bundle size**: Lớn hơn web frameworks
  - **SEO**: Khó SEO hơn traditional web apps

**4. Vue.js + Quasar** 🎯 **Balanced choice**
- **Ưu điểm:**
  - **Code sharing**: Vue.js cho web + Quasar cho mobile
  - **Performance**: Tương đương React
  - **Learning curve**: Dễ học hơn React
  - **Ecosystem**: Mature và stable
  - **Mobile**: Quasar Framework cho cross-platform

- **Nhược điểm:**
  - **Code sharing**: Chỉ 50-60% (ít hơn React Native)
  - **Mobile performance**: Hybrid app, không native

**5. Preact** ⚡ **React-compatible lightweight**
- **Ưu điểm:**
  - **React compatibility**: Drop-in replacement cho React
  - **Bundle size**: Chỉ 3KB gzipped
  - **Performance**: Nhanh hơn React
  - **Migration**: Dễ migrate từ React
  - **Ecosystem**: Dùng được React ecosystem

- **Nhược điểm:**
  - **Mobile**: Không có mobile framework
  - **Features**: Một số React features bị thiếu

### **So sánh Performance (Benchmarks)**

| Framework | Bundle Size | Runtime Performance | Development Speed | Mobile Support |
|-----------|-------------|-------------------|------------------|----------------|
| **React + RN** | 100KB+ | ⭐⭐⭐⭐ | ⭐⭐⭐⭐⭐ | ⭐⭐⭐⭐⭐ |
| **Svelte** | 10-20KB | ⭐⭐⭐⭐⭐ | ⭐⭐⭐⭐ | ⭐⭐⭐ |
| **Solid.js** | 7KB | ⭐⭐⭐⭐⭐ | ⭐⭐⭐ | ⭐⭐ |
| **Flutter** | 200KB+ | ⭐⭐⭐⭐⭐ | ⭐⭐⭐⭐ | ⭐⭐⭐⭐⭐ |
| **Vue + Quasar** | 80KB | ⭐⭐⭐⭐ | ⭐⭐⭐⭐ | ⭐⭐⭐ |

### **Khuyến nghị cho hệ thống giáo dục:**

**Option 1: Blazor + Flutter** (Recommended - Full-stack C#)
- Web app: Blazor Server/WebAssembly
- Mobile: Flutter
- **Pros**: Full-stack C#, native mobile performance, strong typing
- **Cons**: Flutter learning curve, Blazor ecosystem smaller than React

**Option 2: Flutter Only** (Nếu ưu tiên single codebase)
- Web + Mobile: Flutter
- **Pros**: True native, single codebase, Google backing
- **Cons**: Web performance chưa tối ưu, SEO issues

**Option 3: React + React Native** (Nếu ưu tiên ecosystem)
- **Pros**: Largest ecosystem, most developers
- **Cons**: Bundle size lớn, performance không tối ưu nhất

**Kết luận**: Blazor + Flutter là lựa chọn tối ưu cho full-stack C# development với native mobile performance. Flutter alone cũng là option tốt nếu ưu tiên single codebase.

---

## PROJECT TIMELINE

### Phase 1: Foundation (Months 1-3)
**Week 1-4: Project Setup**
- Set up development environment
- Create project structure
- Set up CI/CD pipeline
- Database design và setup

**Week 5-8: Core Authentication**
- User registration/login
- Email verification
- Password reset
- Role-based access control

**Week 9-12: Basic Course Management**
- Course creation (teacher)
- Course browsing (student)
- Basic payment integration
- Admin approval workflow

### Phase 2: Core Features (Months 4-6)
**Week 13-16: Learning System**
- Video player implementation
- Progress tracking
- Note-taking system
- Quiz functionality

**Week 17-20: Exam System**
- Exam creation (teacher)
- Exam taking (student)
- Basic AI grading
- Result display

**Week 21-24: Payment & Financial**
- Complete payment integration
- Commission calculation
- Financial reporting
- Voucher system

### Phase 3: Advanced Features (Months 7-9)
**Week 25-28: AI Integration**
- Advanced AI grading
- Personalized recommendations
- Content optimization
- Performance analytics

**Week 29-32: Community Features**
- Forum system
- Study groups
- Peer review
- Social features

**Week 33-36: Mobile Apps**
- React Native development
- Mobile-specific features
- Offline mode
- Push notifications

### Phase 4: Polish & Launch (Months 10-12)
**Week 37-40: Testing & QA**
- Comprehensive testing
- Performance optimization
- Security audit
- Bug fixes

**Week 41-44: Launch Preparation**
- Production deployment
- Monitoring setup
- Support system
- Marketing materials

**Week 45-48: Launch & Post-Launch**
- Soft launch
- User feedback collection
- Bug fixes
- Feature improvements

### Key Milestones

**Month 3: MVP Ready**
- Basic course creation và purchase
- User authentication
- Admin panel

**Month 6: Beta Release**
- Complete learning system
- Exam functionality
- Payment integration

**Month 9: Feature Complete**
- All core features implemented
- Mobile apps ready
- AI integration complete

**Month 12: Production Launch**
- Full system deployed
- Marketing campaign
- User acquisition

### Resource Requirements

**Development Team:**
- 2 Frontend developers
- 2 Backend developers
- 1 Mobile developer
- 1 DevOps engineer
- 1 UI/UX designer
- 1 QA engineer
- 1 Project manager

**Infrastructure:**
- AWS hosting
- Database servers
- CDN services
- Monitoring tools
- Development tools


---

## CONCLUSION

Tài liệu này cung cấp một framework hoàn chỉnh cho việc phát triển hệ thống giáo dục trực tuyến. Với 7 EPICs chính, 25+ user stories chi tiết, và technical specifications đầy đủ, team development có thể bắt đầu implementation ngay lập tức.

**Key Success Factors:**
1. **User-Centric Design**: Tất cả features đều được thiết kế dựa trên nhu cầu thực tế của users
2. **Scalable Architecture**: Hệ thống có thể mở rộng để phục vụ hàng triệu users
3. **AI Integration**: Tận dụng AI để tự động hóa và cải thiện trải nghiệm
4. **Mobile-First**: Đảm bảo trải nghiệm tốt trên mọi thiết bị
5. **Security & Compliance**: Tuân thủ các quy định bảo mật và pháp lý

**Next Steps:**
1. Review và approve tài liệu này
2. Set up development team
3. Begin Phase 1 implementation
4. Regular review và adjustment
5. Continuous user feedback integration

Hệ thống này sẽ tạo ra một nền tảng giáo dục trực tuyến cạnh tranh, có thể mở rộng và tạo ra giá trị bền vững cho tất cả stakeholders.

---

## KẾ HOẠCH SẢN XUẤT VỚI TEAM SCRUM

### Team Structure & Roles

#### **Product Owner: Nguyên**
**Trách nhiệm:**
- Định nghĩa và ưu tiên hóa Product Backlog
- Đảm bảo team hiểu rõ requirements và acceptance criteria
- Đưa ra quyết định về features và scope
- Review và accept/reject các user stories hoàn thành
- Giao tiếp với stakeholders và thu thập feedback
- Đảm bảo ROI và business value

**Deliverables:**
- Product Backlog được ưu tiên hóa
- User Stories với acceptance criteria rõ ràng
- Sprint Goals và Definition of Done
- Product demos cho stakeholders

#### **System Architect: Phong**
**Trách nhiệm:**
- Thiết kế kiến trúc hệ thống tổng thể
- Đưa ra quyết định về technology stack
- Thiết kế database schema và API contracts
- Đảm bảo scalability, security và performance
- Code review và technical guidance
- Giải quyết các technical challenges phức tạp

**Deliverables:**
- System architecture diagrams
- Technical specifications
- Database design và API documentation
- Code review và technical standards
- Performance và security guidelines

#### **Backend Developer: Kiên**
**Trách nhiệm:**
- Phát triển .NET Core 8 APIs và microservices
- Implement business logic và data access layer
- Tích hợp với PostgreSQL, MongoDB, Redis
- Implement authentication, authorization
- API development và testing
- Database optimization và performance tuning

**Deliverables:**
- RESTful APIs hoàn chỉnh
- Microservices implementation
- Database migrations và scripts
- Unit tests và integration tests
- API documentation

#### **Frontend Developer: Cường**
**Trách nhiệm:**
- Phát triển Blazor Server/WebAssembly applications
- Implement responsive UI/UX designs
- State management và client-side logic
- Integration với backend APIs
- Mobile-responsive design
- Performance optimization

**Deliverables:**
- Blazor web applications
- Responsive UI components
- Client-side state management
- API integration
- Cross-browser compatibility

### Sprint Planning & Timeline

#### **Sprint 1-2: Foundation Setup (4 tuần)**
**Sprint Goal:** Thiết lập môi trường development và core infrastructure

**Sprint 1 (2 tuần):**
- **Phong:** System architecture design, technology stack setup
- **Kiên:** Database setup (PostgreSQL, MongoDB), basic API structure
- **Cường:** Project setup, UI framework configuration
- **Nguyên:** Product backlog refinement, user story creation

**Sprint 2 (2 tuần):**
- **Phong:** API contracts design, security framework setup
- **Kiên:** Authentication system, basic CRUD operations
- **Cường:** Login/register UI, basic navigation
- **Nguyên:** User acceptance testing, feedback collection

#### **Sprint 3-4: Core Features (4 tuần)**
**Sprint Goal:** Implement core user management và course browsing

**Sprint 3 (2 tuần):**
- **Phong:** Course management architecture, file upload system
- **Kiên:** User management APIs, course CRUD operations
- **Cường:** Course catalog UI, user dashboard
- **Nguyên:** User story validation, stakeholder demos

**Sprint 4 (2 tuần):**
- **Phong:** Payment integration architecture, security enhancements
- **Kiên:** Payment APIs, course enrollment system
- **Cường:** Payment UI, course enrollment flow
- **Nguyên:** Payment flow testing, business validation

#### **Sprint 5-6: Learning System (4 tuần)**
**Sprint Goal:** Implement learning platform và progress tracking

**Sprint 5 (2 tuần):**
- **Phong:** Video streaming architecture, progress tracking system
- **Kiên:** Learning progress APIs, video management
- **Cường:** Video player, progress tracking UI
- **Nguyên:** Learning experience testing, user feedback

**Sprint 6 (2 tuần):**
- **Phong:** Exam system architecture, AI integration planning
- **Kiên:** Exam APIs, quiz system implementation
- **Cường:** Exam interface, quiz components
- **Nguyên:** Exam flow validation, educational content review

#### **Sprint 7-8: Advanced Features (4 tuần)**
**Sprint Goal:** Implement AI grading và advanced analytics

**Sprint 7 (2 tuần):**
- **Phong:** AI integration architecture, analytics system design
- **Kiên:** AI grading APIs, analytics data collection
- **Cường:** Results dashboard, analytics visualization
- **Nguyên:** AI accuracy testing, performance validation

**Sprint 8 (2 tuần):**
- **Phong:** System optimization, security hardening
- **Kiên:** Performance optimization, security implementation
- **Cường:** UI/UX improvements, mobile optimization
- **Nguyên:** Final testing, production readiness review

### Scrum Ceremonies

#### **Daily Standups (15 phút, hàng ngày 9:00 AM)**
**Format:**
- Hôm qua đã làm gì?
- Hôm nay sẽ làm gì?
- Có gặp impediment nào không?

**Participants:** Toàn bộ team
**Location:** Online (Teams/Zoom)

#### **Sprint Planning (2 giờ, đầu mỗi sprint)**
**Agenda:**
- Review Product Backlog (Nguyên)
- Estimate user stories (Team)
- Commit to Sprint Goal (Team)
- Break down tasks (Team)

**Participants:** Toàn bộ team
**Deliverables:** Sprint Backlog, Sprint Goal

#### **Sprint Review (1 giờ, cuối mỗi sprint)**
**Agenda:**
- Demo completed features (Team)
- Stakeholder feedback (Nguyên)
- Product Backlog update (Nguyên)
- Next sprint planning (Team)

**Participants:** Team + Stakeholders
**Deliverables:** Updated Product Backlog

#### **Sprint Retrospective (1 giờ, cuối mỗi sprint)**
**Agenda:**
- What went well?
- What could be improved?
- Action items for next sprint

**Participants:** Development team only
**Deliverables:** Improvement action items

### Definition of Done

**Một user story được coi là "Done" khi:**
- [ ] Code được review và approve bởi System Architect
- [ ] Unit tests được viết và pass (coverage > 80%)
- [ ] Integration tests pass
- [ ] UI/UX được test trên multiple browsers
- [ ] Performance requirements được đáp ứng
- [ ] Security requirements được implement
- [ ] Documentation được cập nhật
- [ ] Product Owner đã review và accept
- [ ] Deploy được lên staging environment
- [ ] Stakeholder demo thành công

### Risk Management

#### **Technical Risks:**
- **AI Integration Complexity** (Phong + Kiên)
  - Mitigation: Proof of concept trong Sprint 1
  - Backup plan: Manual grading system

- **Performance với large user base** (Phong)
  - Mitigation: Load testing từ Sprint 3
  - Monitoring và optimization continuous

#### **Business Risks:**
- **Requirements Changes** (Nguyên)
  - Mitigation: Regular stakeholder communication
  - Change control process

- **Timeline Pressure** (Team)
  - Mitigation: Buffer time trong mỗi sprint
  - Scope adjustment nếu cần

### Communication Plan

#### **Internal Communication:**
- **Daily:** Standup meetings
- **Weekly:** Technical sync (Phong + Kiên + Cường)
- **Bi-weekly:** Sprint ceremonies
- **Monthly:** Stakeholder updates (Nguyên)

#### **Tools:**
- **Project Management:** Azure DevOps / Jira
- **Communication:** Microsoft Teams
- **Code Repository:** GitHub
- **Documentation:** Confluence / SharePoint
- **Design:** Figma / Adobe XD

### Success Metrics

#### **Sprint Metrics:**
- Sprint Velocity (story points completed)
- Burndown chart
- Team satisfaction score
- Code quality metrics

#### **Product Metrics:**
- Feature completion rate
- Bug count và resolution time
- User acceptance rate
- Performance benchmarks

#### **Team Metrics:**
- Individual productivity
- Knowledge sharing sessions
- Technical debt reduction
- Skill development progress

### Escalation Process

#### **Level 1: Team Level**
- Technical issues → Phong (System Architect)
- Requirements clarification → Nguyên (Product Owner)
- Timeline concerns → Team discussion

#### **Level 2: Management Level**
- Major scope changes → Product Owner + Stakeholders
- Resource constraints → Project Manager
- Technical blockers → CTO/Technical Lead

#### **Level 3: Executive Level**
- Budget overruns → CEO/CFO
- Strategic changes → Board/Stakeholders
- Major risks → Executive team

---

**Kế hoạch này đảm bảo team có thể deliver hệ thống giáo dục trực tuyến chất lượng cao trong 16 tuần với 8 sprints, mỗi sprint 2 tuần.**

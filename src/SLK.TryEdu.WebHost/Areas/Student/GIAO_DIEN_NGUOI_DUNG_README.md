# 🎓 Giao diện Người dùng - TryEdu

## 📋 Tổng quan

Đã tạo sẵn **5 trang giao diện người dùng** hoàn chỉnh cho hệ thống TryEdu:

1. ✅ **Dashboard** - Trang tổng quan
2. ✅ **Danh sách Trắc nghiệm** - Hiển thị tất cả bài trắc nghiệm
3. ✅ **Chi tiết Trắc nghiệm** - Làm bài trắc nghiệm với timer
4. ✅ **Danh sách Khóa học** - Browse và tìm kiếm khóa học
5. ✅ **Chi tiết Khóa học** - Xem chi tiết và đăng ký khóa học

---

## 🔗 Đường dẫn (Routes)

### 1. Dashboard
- **URL**: `/student/dashboard`
- **File**: `SLK.TryEdu.WebHost/Areas/Student/Pages/Dashboard.cshtml`
- **Chức năng**:
  - Hiển thị thống kê tổng quan (khóa học, chứng chỉ, thời gian học)
  - Danh sách khóa học đang học (với progress bar)
  - Hoạt động gần đây
  - Bài kiểm tra sắp tới
  - Chuỗi học tập (streak)
  - Thành tựu

### 2. Danh sách Trắc nghiệm
- **URL**: `/student/quizzes`
- **File**: `SLK.TryEdu.WebHost/Areas/Student/Pages/Quizzes.cshtml`
- **Chức năng**:
  - Grid hiển thị các bài trắc nghiệm
  - Tìm kiếm và filter (Dễ/Trung bình/Khó)
  - Hiển thị độ khó, số câu, thời gian
  - Trạng thái: Chưa làm / Đã hoàn thành
  - Pagination

### 3. Chi tiết Trắc nghiệm
- **URL**: `/student/quiz/{id}`
- **File**: `SLK.TryEdu.WebHost/Areas/Student/Pages/QuizDetail.cshtml`
- **Chức năng**:
  - Hiển thị câu hỏi và đáp án
  - Timer đếm ngược (30 phút)
  - Progress tracker (đã làm/chưa làm)
  - Navigation giữa các câu hỏi
  - Modal xác nhận nộp bài
  - Auto-save answers

### 4. Danh sách Khóa học
- **URL**: `/student/courses`
- **File**: `SLK.TryEdu.WebHost/Areas/Student/Pages/Courses.cshtml`
- **Chức năng**:
  - Hero section với search bar
  - Filter theo danh mục (Lập trình, Thiết kế, Kinh doanh...)
  - Hiển thị rating, giá, số học viên
  - Badges: Bestseller, New, Trending
  - Sort options (Mới nhất, Phổ biến, Giá...)
  - Pagination

### 5. Chi tiết Khóa học
- **URL**: `/student/course/{id}`
- **File**: `SLK.TryEdu.WebHost/Areas/Student/Pages/CourseDetail.cshtml`
- **Chức năng**:
  - Thông tin chi tiết khóa học
  - Curriculum (nội dung từng section)
  - Thông tin giảng viên
  - Reviews và ratings
  - Sidebar: Giá, CTA đăng ký, Features
  - Preview lessons
  - Certificate info

---

## 🎨 Thiết kế

### Theme Colors
- **Primary Gradient**: `linear-gradient(135deg, #667eea 0%, #764ba2 100%)`
- **Success**: `#48bb78`
- **Warning**: `#ed8936`
- **Danger**: `#f56565`
- **Info**: `#4299e1`

### Typography
- **Font Family**: `-apple-system, BlinkMacSystemFont, "Segoe UI", Roboto, "Helvetica Neue", Arial, sans-serif`
- **Headings**: Bold, size varies (h1-h6)
- **Body**: Regular, 14-16px

### Components
- **Border Radius**: 12px - 20px (modern rounded corners)
- **Shadows**: `0 4px 16px rgba(0,0,0,0.08)` (subtle elevation)
- **Transitions**: `all 0.3s ease` (smooth animations)
- **Hover Effects**: Transform translateY(-5px)

---

## 📦 Dependencies

Các file đã sử dụng:
- **Bootstrap**: `~/assets/bootstrap/4.5.3/css/bootstrap.min.css`
- **FontAwesome**: `~/assets/font-awesome/5.15.1/css/all.css`
- **jQuery**: `~/assets/jquery/jquery-3.5.1.min.js`

---

## 🚀 Cách sử dụng

### 1. Chạy project
```bash
cd SLK.TryEdu.WebHost
dotnet run
```

### 2. Truy cập các trang

- Dashboard: `https://localhost:5001/student/dashboard`
- Quizzes: `https://localhost:5001/student/quizzes`
- Quiz Detail: `https://localhost:5001/student/quiz/1`
- Courses: `https://localhost:5001/student/courses`
- Course Detail: `https://localhost:5001/student/course/1`

---

## 🔧 Tùy chỉnh

### Thay đổi màu sắc
Tìm và thay đổi gradient trong CSS:
```css
background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
```

### Thay đổi hình ảnh
Các URL hình ảnh sử dụng Unsplash placeholders:
```html
<img src="https://images.unsplash.com/photo-xxxxx?w=600" alt="...">
```
Thay thế bằng hình ảnh thực tế từ database.

### Kết nối Backend
Mỗi file `.cshtml.cs` đã có sẵn Model class:
- `QuizzesModel`
- `QuizDetailModel`
- `CoursesModel`
- `CourseDetailModel`
- `DashboardModel`

Thêm logic backend vào các method `OnGet()`, `OnPost()` trong các file này.

---

## 📝 TODO - Các tính năng cần bổ sung

### Backend Integration
- [ ] Kết nối database lấy danh sách khóa học, trắc nghiệm
- [ ] API endpoints cho quiz submission
- [ ] Authentication & Authorization
- [ ] Progress tracking (save user progress)
- [ ] Payment integration

### Frontend Enhancement
- [ ] Real-time quiz timer với localStorage
- [ ] AJAX submit quiz answers
- [ ] Lazy loading cho hình ảnh
- [ ] Responsive optimization cho mobile
- [ ] Dark mode toggle

### Features
- [ ] Video player cho lessons
- [ ] Comment system cho courses
- [ ] Wishlist functionality
- [ ] Course recommendations
- [ ] Achievement system
- [ ] Leaderboard

---

## 🎯 Best Practices

1. **Responsive Design**: Tất cả trang đã responsive với Bootstrap Grid
2. **SEO Friendly**: Sử dụng semantic HTML
3. **Performance**: Tối ưu hóa hình ảnh và CSS
4. **Accessibility**: ARIA labels và keyboard navigation
5. **Modern UI**: Gradient, shadows, transitions

---

## 📞 Hỗ trợ

Nếu cần hỗ trợ hoặc có câu hỏi, vui lòng liên hệ team phát triển.

---

**Phát triển bởi TryEdu Team** 🚀


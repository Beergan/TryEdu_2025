# LỘ TRÌNH PHÁT TRIỂN HỆ THỐNG V2.0 B2B2C
## Từ 27/11/2025 → 29/12/2025 (DEMO) → 26/01/2026 (OFFICIAL)

---

## 📊 TỔNG QUAN DỰ ÁN

### Timeline Tổng Thể
- **Ngày bắt đầu**: 27/11/2025 (Thứ 4)
- **Milestone 1 - DEMO**: 29/12/2025 (32 ngày làm việc)
- **Milestone 2 - OFFICIAL**: 26/01/2026 (60 ngày làm việc)

---

## ✅ CHECKLIST TỔNG HỢP - THEO DÕI TIẾN ĐỘ

### 🎯 **PHASE 1: DEMO (27/11 - 29/12)** - 32 ngày

#### 📌 **TUẦN 1-2: FOUNDATION & DATABASE (27/11 - 10/12)**

##### **Ngày 1-2 (27-28/11): Project Structure Setup**
**Phong (System Architect):**
- [ ] Review cấu trúc module hiện tại
- [ ] Thiết kế kiến trúc mở rộng cho V2.0
- [ ] Tạo solution structure cho ModuleCoin (Core, Main, Blazor)
- [ ] Tạo solution structure cho ModulePartner (Core, Main, Blazor)
- [ ] Tạo solution structure cho ModuleContent (Core, Main, Blazor)
- [ ] Tạo solution structure cho ModuleLearning (Core, Main, Blazor)
- [ ] Document architecture decisions

**Kiên (Backend Developer):**
- [ ] Clone repository và setup local environment
- [ ] Review EntityBase và MyServiceBase patterns
- [ ] Setup PostgreSQL local instance
- [ ] Setup MongoDB local instance
- [ ] Test connection strings và migrations

**Cường (Frontend Developer):**
- [ ] Review Blazor structure hiện tại
- [ ] Setup UI framework (MudBlazor hoặc Radzen)
- [ ] Tạo base layouts cho Partner Portal
- [ ] Setup shared components

**Nguyên (Product Owner):**
- [ ] Review PRD document
- [ ] Prioritize features cho DEMO
- [ ] Prepare user stories chi tiết
- [ ] Define acceptance criteria

---

##### **Ngày 3-5 (29/11 - 01/12): Database Schema Design**
**Kiên (Backend Developer):**
- [ ] Tạo EntityCoinTransaction.cs
- [ ] Tạo EntityCoinBalance.cs
- [ ] Tạo EntityPartnerCenter.cs
- [ ] Tạo EntityReferralCode.cs
- [ ] Tạo EntityCommissionTransaction.cs
- [ ] Tạo EntityCourse.cs
- [ ] Tạo EntityExam.cs
- [ ] Tạo EntityEnrollment.cs
- [ ] Tạo EntityExamSubmission.cs
- [ ] Tạo EntityUserRole.cs
- [ ] Update ModelBuilderExt.cs với RegisterV2Entities()
- [ ] Configure unique constraints và indexes

**Phong (System Architect):**
- [ ] Review tất cả entities
- [ ] Validate relationships và constraints
- [ ] Document database schema decisions
- [ ] Design indexes strategy

**Cường (Frontend Developer):**
- [ ] Tạo DTOs cho API responses
- [ ] Design UI wireframes cho Coin management
- [ ] Design UI wireframes cho Partner Portal

---

##### **Ngày 6-7 (02-03/12): Database Migrations & Testing**
**Kiên (Backend Developer):**
- [ ] Tạo EF Core migrations cho tất cả entities
- [ ] Test migrations trên local PostgreSQL
- [ ] Tạo SeedData.cs với initial data
- [ ] Seed default coin exchange rate
- [ ] Seed bronze tier commission rate
- [ ] Seed sample courses
- [ ] Seed sample exams
- [ ] Document migration process

---

##### **Ngày 8-10 (04-06/12): User Authentication Extension**
**Kiên (Backend Developer):**
- [ ] Tạo EntityUserRole.cs
- [ ] Tạo AuthService.cs với Register method
- [ ] Tạo AuthService.cs với Login method
- [ ] Implement HashPassword method
- [ ] Implement VerifyPassword method
- [ ] Implement GenerateJwtToken method
- [ ] Tạo RegisterDto.cs
- [ ] Tạo LoginDto.cs
- [ ] Tạo AuthResponseDto.cs
- [ ] Auto-create CoinBalance cho Student registration
- [ ] Update last login timestamp
- [ ] Teacher registration với upload CV/chứng chỉ (US1.2)
- [ ] Tạo TeacherRegistrationDto.cs với file upload fields
- [ ] Implement ForgotPassword method (US1.3)
- [ ] Implement ResetPassword method (US1.3)
- [ ] Implement EmailVerification method (US1.1)
- [ ] Implement SendVerificationEmail method (US1.1)
- [ ] Implement VerifyEmailToken method (US1.1)

**Cường (Frontend Developer) - Authentication UI:**
- [ ] Tạo Login UI component
- [ ] Tạo Register UI component
- [ ] Implement form validation
- [ ] Integrate với AuthService API
- [ ] Setup JWT token storage (localStorage)
- [ ] Implement authentication guard
- [ ] Remember me checkbox (US1.3)
- [ ] Forgot password link và flow (US1.3)
- [ ] Teacher registration form với CV upload (US1.2)
- [ ] Teacher registration form với chứng chỉ upload (US1.2)
- [ ] Forgot password page (US1.3)
- [ ] Reset password page (US1.3)
- [ ] Email verification page (US1.1)
- [ ] Resend verification email button (US1.1)

**Cường (Frontend Developer) - Student Profile & Navigation UI (US1.1):**
- [ ] **Student Navigation/Menu:**
  - [ ] Header với logo
  - [ ] Main navigation menu:
    - [ ] Home/Dashboard
    - [ ] Courses
    - [ ] Exams
    - [ ] My Learning
    - [ ] Coin Wallet
    - [ ] Help/Support
  - [ ] User menu dropdown:
    - [ ] User avatar
    - [ ] User name
    - [ ] Coin balance display
    - [ ] Profile link
    - [ ] Settings link
    - [ ] Logout button
  - [ ] Mobile responsive menu (hamburger)

- [ ] **Student Profile Page (US1.1):**
  - [ ] Profile header với avatar
  - [ ] Upload avatar button
  - [ ] Crop/resize avatar tool
  - [ ] User information section:
    - [ ] Full name (editable)
    - [ ] Email (read-only, với verify status)
    - [ ] Phone number (editable)
    - [ ] Date of birth (editable)
    - [ ] Gender (editable)
    - [ ] Address (editable)
  - [ ] English level selection (A1, A2, B1, B2, C1, C2)
  - [ ] Learning goals/interests (multi-select)
  - [ ] Save changes button
  - [ ] Change password section:
    - [ ] Current password input
    - [ ] New password input
    - [ ] Confirm new password input
    - [ ] Change password button
  - [ ] Account settings:
    - [ ] Email notifications toggle
    - [ ] SMS notifications toggle
    - [ ] Privacy settings
  - [ ] Delete account option (với confirmation)

- [ ] **Student Settings Page:**
  - [ ] Notification preferences
  - [ ] Privacy settings
  - [ ] Language preferences
  - [ ] Theme preferences (Light/Dark)
  - [ ] Save settings button

---

##### **Ngày 11-12 (07-08/12): Partner Registration Flow**
**Kiên (Backend Developer):**
- [ ] Tạo PartnerService.cs
- [ ] Implement RegisterPartner method
- [ ] Implement ApprovePartner method
- [ ] Implement RejectPartner method
- [ ] Implement GenerateDefaultCode method
- [ ] Tạo PartnerRegistrationDto.cs
- [ ] Email notification cho admin khi có đăng ký mới
- [ ] Email confirmation cho partner khi đăng ký
- [ ] Email approval cho partner khi được phê duyệt

**Cường (Frontend Developer):**
- [ ] Tạo Partner Registration form
- [ ] Implement file upload cho logo
- [ ] Implement file upload cho business license
- [ ] Tạo Admin approval interface
- [ ] Partner dashboard layout
- [ ] Partner profile page

---

##### **Ngày 13-14 (09-10/12): Testing & Bug Fixes Week 1-2**
**Toàn bộ team:**
- [ ] Test authentication flows (Student, Teacher, Admin, Partner)
- [ ] Test partner registration flow
- [ ] Test admin approval workflow
- [ ] Fix bugs discovered
- [ ] Code review session
- [ ] Update documentation
- [ ] Sprint 1 retrospective

---

#### 📌 **TUẦN 3: COIN SYSTEM & REFERRAL (11-17/12)**

##### **Ngày 15-17 (11-13/12): Coin Service Implementation**
**Kiên (Backend Developer):**
- [ ] Tạo CoinService.cs
- [ ] Implement PurchaseCoins method
- [ ] Implement GetBalance method
- [ ] Implement UseCoins method
- [ ] Implement ValidateReferralCode method
- [ ] Implement CalculateCommission method
- [ ] Tạo CoinPurchaseDto.cs
- [ ] Tạo CoinPurchaseResponseDto.cs
- [ ] Tạo CoinBalanceDto.cs
- [ ] Tạo UseCoinDto.cs
- [ ] Auto-update CoinBalance khi purchase
- [ ] Auto-update CoinBalance khi use
- [ ] Transaction logging đầy đủ

**Cường (Frontend Developer) - Student Coin UI (US9.1, US9.2):**
- [ ] **Student Dashboard/Homepage:**
  - [ ] Welcome section với user info
  - [ ] Quick stats (coin balance, enrolled courses, purchased exams)
  - [ ] Recent activities feed
  - [ ] Recommended courses
  - [ ] Recommended exams
  - [ ] Quick actions (Purchase coin, Browse courses, Browse exams)

- [ ] **Coin Purchase UI:**
  - [ ] Coin purchase page
  - [ ] Predefined amount buttons (50K, 100K, 200K, 500K, 1M VNĐ) (US9.1)
  - [ ] Custom amount input field (US9.1)
  - [ ] Coin balance display widget (header/sidebar)
  - [ ] Referral code input field với validation
  - [ ] Referral code info display (tên trung tâm, mức giảm giá)
  - [ ] Price calculation display (original → discounted → final)
  - [ ] Payment method selection (VNPay, MoMo, Banking) (US9.1)
  - [ ] Purchase confirmation dialog
  - [ ] Success/Error notifications
  - [ ] Redirect to transaction history sau khi mua thành công

- [ ] **Coin Wallet Management Page (US9.1):**
  - [ ] Current coin balance display (large, prominent)
  - [ ] Total earned coins
  - [ ] Total spent coins
  - [ ] Quick purchase button
  - [ ] Transaction history table với filters:
    - [ ] Filter by type (Purchase, Use, Refund)
    - [ ] Filter by date range
    - [ ] Search transactions
  - [ ] Transaction details modal
  - [ ] Export transaction history (Excel/PDF)

- [ ] **Transaction History Page:**
  - [ ] List of all transactions
  - [ ] Transaction type icons
  - [ ] Transaction date/time
  - [ ] Amount (coin)
  - [ ] Status (Success, Pending, Failed)
  - [ ] Description
  - [ ] View details button
  - [ ] Pagination
  - [ ] Export button

---

##### **Ngày 18-19 (14-15/12): Referral Code Management**
**Kiên (Backend Developer):**
- [ ] Tạo ReferralCodeService.cs
- [ ] Implement CreateCode method
- [ ] Implement GetPartnerCodes method
- [ ] Implement UpdateCode method
- [ ] Implement ToggleCodeStatus method
- [ ] Implement DeleteCode method
- [ ] Tạo CreateReferralCodeDto.cs
- [ ] Tạo ReferralCodeDto.cs
- [ ] Validate code uniqueness
- [ ] Check expiry date
- [ ] Check usage limits

**Cường (Frontend Developer):**
- [ ] Create referral code form
- [ ] Referral code list table
- [ ] Code statistics display (usage count, effectiveness)
- [ ] Toggle active/inactive button
- [ ] Edit code functionality
- [ ] Delete confirmation dialog
- [ ] Copy code to clipboard button

---

##### **Ngày 20-21 (16-17/12): Commission Dashboard**
**Kiên (Backend Developer):**
- [ ] Tạo CommissionService.cs
- [ ] Implement GetPartnerDashboard method
- [ ] Implement GetCommissionHistory method
- [ ] Implement GetCommissionSummary method
- [ ] Calculate total commission
- [ ] Calculate this month commission
- [ ] Count total students referred
- [ ] Count active students (last 30 days)
- [ ] Tạo PartnerDashboardDto.cs
- [ ] Tạo CommissionTransactionDto.cs
- [ ] Support date range filtering
- [ ] Auto-upgrade tier khi đạt điều kiện (US9.4)
- [ ] Implement CheckAndUpgradeTier method

**Cường (Frontend Developer):**
- [ ] Partner dashboard với KPI cards
- [ ] Total commission display
- [ ] This month commission display
- [ ] Students count display
- [ ] Commission history table
- [ ] Date range filter component
- [ ] Charts (commission over time)
- [ ] Top referral codes display (hiệu quả nhất) (US8.3)
- [ ] Filter theo loại giao dịch (nạp coin, mua bài thi) (US8.3)
- [ ] Payment schedule view (lịch thanh toán hoa hồng) (US8.3)
- [ ] Download commission invoice button (hóa đơn hoa hồng) (US8.3)
- [ ] Export commission report button

**Kiên (Backend Developer) - Partner Student Management (US8.4):**
- [ ] Implement GetReferredStudents method
- [ ] Implement FilterStudents method (status, search)
- [ ] Implement GetStudentDetails method
- [ ] Implement GetStudentActivityHistory method
- [ ] Implement SendNotificationToStudent method
- [ ] Tạo ReferredStudentDto.cs
- [ ] Privacy compliance checks

**Cường (Frontend Developer) - Partner Student Management UI (US8.4):**
- [ ] Referred students list page
- [ ] Student filter (active, inactive, premium)
- [ ] Student search (name, email, phone)
- [ ] Student detail view
- [ ] Student activity history timeline
- [ ] Send notification to student button

---

#### 📌 **TUẦN 4: CONTENT & EXAM SYSTEM (18-24/12)**

##### **Ngày 22-24 (18-20/12): Course Management**
**Kiên (Backend Developer):**
- [ ] Tạo CourseService.cs
- [ ] Implement CreateCourse method
- [ ] Implement GetCourses method (with filters)
- [ ] Implement GetCourseById method
- [ ] Implement UpdateCourse method
- [ ] Implement PublishCourse method
- [ ] Implement GenerateSlug method
- [ ] Tạo CreateCourseDto.cs
- [ ] Tạo CourseDto.cs
- [ ] Tạo UpdateCourseDto.cs
- [ ] Permission checking (CONTENT_CREATE)
- [ ] Support free/premium course types

**Kiên (Backend Developer) - Lesson Bank System (US2.7):**
- [ ] Tạo LessonService.cs
- [ ] Implement CreateLesson method (video, text, quiz)
- [ ] Implement GetLessons method (với filters)
- [ ] Implement UpdateLesson method
- [ ] Implement DeleteLesson method
- [ ] Implement UploadLessonVideo method
- [ ] Implement UploadLessonAttachment method
- [ ] Implement CreateLessonQuiz method
- [ ] Implement CategorizeLesson method
- [ ] Tạo LessonDto.cs, CreateLessonDto.cs

**Cường (Frontend Developer) - Admin/Teacher Course Management UI:**
- [ ] Course creation form (Admin/Teacher)
- [ ] Course list view với grid layout
- [ ] Course list view với list layout
- [ ] Course thumbnail upload
- [ ] Upload video, tài liệu cho course (US2.1)
- [ ] Quản lý bài học trong khóa học (US2.1)

**Cường (Frontend Developer) - Student Course UI (US2.2, US3.1):**
- [ ] **Student Course Catalog Page:**
  - [ ] Course grid/list view toggle
  - [ ] Filter courses:
    - [ ] Free/Premium toggle
    - [ ] Level filter (A1, A2, B1, B2, C1, C2)
    - [ ] Category filter
    - [ ] Price range filter
  - [ ] Search courses by name
  - [ ] Sort by (Popularity, Price, Newest, Rating)
  - [ ] Course cards với:
    - [ ] Course thumbnail
    - [ ] Course title
    - [ ] Course description (truncated)
    - [ ] Level badge
    - [ ] Price (Free hoặc coin amount)
    - [ ] Rating/Reviews count
    - [ ] Enrolled students count
    - [ ] View details button
  - [ ] Pagination

- [ ] **Student Course Detail Page:**
  - [ ] Course header với thumbnail
  - [ ] Course title và description
  - [ ] Course metadata (level, category, duration, lessons count)
  - [ ] Course curriculum preview (list of lessons)
  - [ ] Course instructor info
  - [ ] Course rating và reviews
  - [ ] Price display (Free hoặc coin amount)
  - [ ] Action buttons:
    - [ ] "Enroll Free" button (nếu free course)
    - [ ] "Purchase with Coin" button (nếu premium course)
    - [ ] "Continue Learning" button (nếu đã enroll)
  - [ ] Referral code input (nếu premium course)
  - [ ] Price calculation (original → discounted)
  - [ ] Course preview video (nếu có)
  - [ ] Related courses section

- [ ] **My Courses Page (Enrolled Courses):**
  - [ ] List of enrolled courses (free + purchased)
  - [ ] Course cards với:
    - [ ] Course thumbnail
    - [ ] Course title
    - [ ] Progress bar (X% completed)
    - [ ] Last accessed date
    - [ ] Continue learning button
  - [ ] Filter by status (In Progress, Completed, Not Started)
  - [ ] Sort by (Recent, Progress, Title)
  - [ ] Search my courses
  - [ ] Empty state (nếu chưa enroll course nào)

- [ ] **Course Learning Page (US3.1) - CHI TIẾT:**
  - [ ] **Course Layout:**
    - [ ] Sidebar với course curriculum:
      - [ ] List of lessons với status (completed, in-progress, locked)
      - [ ] Progress indicator cho mỗi lesson
      - [ ] Click to navigate to lesson
    - [ ] Main content area:
      - [ ] Lesson title
      - [ ] Lesson content
      - [ ] Video player (nếu có video)
      - [ ] Lesson text content
      - [ ] Lesson attachments (downloadable)
      - [ ] Previous/Next lesson buttons
      - [ ] Mark as complete button

  - [ ] **Video Player:**
    - [ ] Play/Pause controls
    - [ ] Volume control
    - [ ] Fullscreen mode
    - [ ] Playback speed control (0.5x, 1x, 1.25x, 1.5x, 2x)
    - [ ] Video progress bar
    - [ ] Video duration display
    - [ ] Auto-save progress (mỗi 10 giây)
    - [ ] Resume from last position

  - [ ] **Quiz Interface (sau mỗi bài):**
    - [ ] Quiz title và instructions
    - [ ] Questions list
    - [ ] Question types: MCQ, True/False, Fill-in-blank
    - [ ] Answer input fields
    - [ ] Submit quiz button
    - [ ] Quiz results display:
      - [ ] Score (X/Y correct)
      - [ ] Correct/Incorrect answers
      - [ ] Explanation cho mỗi answer
    - [ ] Retake quiz button (nếu được phép)

  - [ ] **Note-taking Interface (US3.1):**
    - [ ] Notes panel (có thể toggle show/hide)
    - [ ] Create new note button
    - [ ] Notes list với timestamps
    - [ ] Note editor (rich text)
    - [ ] Save note button
    - [ ] Delete note button
    - [ ] Search notes
    - [ ] Notes export (optional)

  - [ ] **Download Video for Offline (US3.1):**
    - [ ] Download button cho mỗi video
    - [ ] Download progress indicator
    - [ ] Downloaded videos list
    - [ ] Play offline button
    - [ ] Delete downloaded video button
    - [ ] Storage usage indicator

  - [ ] **Course Progress Tracking:**
    - [ ] Overall progress bar
    - [ ] Completed lessons count / Total lessons
    - [ ] Time spent learning
    - [ ] Last accessed timestamp
    - [ ] Course completion certificate (khi hoàn thành 100%)

**Kiên (Backend Developer) - Purchase Premium Course (US2.2):**
- [ ] Implement PurchaseCourse method
- [ ] Calculate price với referral code discount
- [ ] Integrate với CoinService.UseCoins()
- [ ] Create CourseEnrollment record
- [ ] Calculate commission cho partner
- [ ] Tạo PurchaseCourseDto.cs

**Cường (Frontend Developer) - Purchase Premium Course UI (US2.2):**
- [ ] Premium course purchase flow
- [ ] Referral code input during purchase
- [ ] Price calculation display (original → discounted)
- [ ] Purchase confirmation dialog
- [ ] My courses page (enrolled courses)
- [ ] Course preview page (US2.2) - xem trước khóa học trước khi mua

**Cường (Frontend Developer) - Lesson Bank UI (US2.7):**
- [ ] Lesson bank management page
- [ ] Create/Edit lesson form
- [ ] Video upload interface
- [ ] Attachment upload interface
- [ ] Quiz creation interface
- [ ] Lesson categorization UI
- [ ] Lesson list với filters

---

##### **Ngày 25-26 (21-22/12): Exam Purchase with Coin + Question Bank**
**Kiên (Backend Developer):**
- [ ] Tạo ExamService.cs
- [ ] Implement CreateExam method
- [ ] Implement GetExams method
- [ ] Implement PurchaseExam method
- [ ] Implement GetPurchasedExams method
- [ ] Calculate price với referral code discount
- [ ] Integrate với CoinService.UseCoins()
- [ ] Create ExamSubmission record
- [ ] Calculate commission cho partner
- [ ] Update referral code usage count
- [ ] Tạo PurchaseExamDto.cs
- [ ] Tạo ExamDto.cs
- [ ] Prevent duplicate purchase

**Kiên (Backend Developer) - Question Bank System (US2.6):**
- [ ] Tạo ExamQuestionService.cs
- [ ] Implement CreateQuestion method (MCQ, Essay, etc.)
- [ ] Implement GetQuestions method (với filters: level, topic, skill)
- [ ] Implement UpdateQuestion method
- [ ] Implement DeleteQuestion method
- [ ] Implement ImportQuestions method (Excel/CSV)
- [ ] Implement ExportQuestions method
- [ ] Implement ManageQuestionOptions method
- [ ] Tạo QuestionDto.cs, CreateQuestionDto.cs
- [ ] Support multiple question types (MCQ, True/False, Essay, Fill-in)

**Kiên (Backend Developer) - Exam Template System (US2.8):**
- [ ] Tạo ExamTemplateService.cs
- [ ] Implement CreateTemplate method
- [ ] Implement CreateTemplateSection method (Reading, Listening, Writing, Speaking)
- [ ] Implement AutoSelectQuestions method (thuật toán chọn câu hỏi)
- [ ] Implement GenerateExamFromTemplate method
- [ ] Implement SetDifficultyLevel method
- [ ] Implement SetQuestionCount method
- [ ] Tạo ExamTemplateDto.cs, TemplateSectionDto.cs

**Cường (Frontend Developer) - Exam Catalog & Purchase UI (US2.4):**
- [ ] Exam catalog page (danh sách bài thi)
  - [ ] Grid/List view toggle
  - [ ] Filter by level (A1, A2, B1, B2, C1, C2)
  - [ ] Filter by exam type (IELTS, TOEFL, etc.)
  - [ ] Search exams by name
  - [ ] Sort by price, popularity, date
  - [ ] Pagination
- [ ] Exam detail page
  - [ ] Exam information (title, description, duration, price)
  - [ ] Exam structure preview (Reading, Listening, Writing, Speaking)
  - [ ] Sample questions preview
  - [ ] Price display (coin amount)
  - [ ] Purchase button (nếu chưa mua)
  - [ ] Start exam button (nếu đã mua)
  - [ ] View result button (nếu đã làm)
- [ ] Exam purchase flow
  - [ ] Purchase dialog với exam details
  - [ ] Referral code input field
  - [ ] Price calculation display (original → discounted)
  - [ ] Coin balance check
  - [ ] Purchase confirmation dialog
  - [ ] Success notification
  - [ ] Redirect to "My Exams" sau khi mua
- [ ] My exams page (purchased exams)
  - [ ] List of purchased exams
  - [ ] Exam status (Not started, In progress, Completed)
  - [ ] Exam attempt button
  - [ ] View result button (nếu đã làm)
  - [ ] Filter by status

**Cường (Frontend Developer) - Question Bank UI (US2.6):**
- [ ] Question bank management page
- [ ] Create/Edit question form
- [ ] Question list với filters (level, topic, skill)
- [ ] Import questions from Excel/CSV
- [ ] Export questions to Excel/CSV
- [ ] Manage question options UI
- [ ] Question preview

**Cường (Frontend Developer) - Exam Template UI (US2.8):**
- [ ] Exam template creation form
- [ ] Template section configuration
- [ ] Auto-select questions interface
- [ ] Difficulty level selector
- [ ] Question count configuration
- [ ] Preview exam from template

---

##### **Ngày 27-28 (23-24/12): Learning System + Teacher Grading + Integration Testing**

**Kiên (Backend Developer) - Learning System (EPIC 3):**
- [ ] Tạo LearningService.cs
- [ ] Implement EnrollCourse method (US3.1)
- [ ] Implement GetEnrolledCourses method
- [ ] Implement TrackVideoProgress method (US3.1)
- [ ] Implement SubmitQuiz method (US3.1)
- [ ] Implement CreateNote method (US3.1)
- [ ] Implement GetNotes method
- [ ] Implement DownloadVideoForOffline method (US3.1)
- [ ] Implement StartExamAttempt method (US3.2)
- [ ] Implement SaveExamProgress method (US3.2 - auto-save)
- [ ] Implement SubmitExam method (US3.2)
- [ ] Implement GetExamResult method (US3.2)
- [ ] Implement GetLearningDashboard method (US3.3)
- [ ] Implement GetLearningHistory method (US3.3)
- [ ] Implement GetAchievements method (US3.3)
- [ ] Implement GetProgressReport method (US3.3)
- [ ] Tạo LearningDashboardDto.cs, ExamAttemptDto.cs

**Cường (Frontend Developer) - Student Learning Dashboard (US3.3):**
- [ ] **Learning Dashboard Page:**
  - [ ] **KPIs Section:**
    - [ ] Total courses enrolled
    - [ ] Total exams purchased
    - [ ] Total learning hours
    - [ ] Current streak (days)
    - [ ] Total coins spent
    - [ ] Total coins earned (nếu có)

  - [ ] **Learning Progress Section:**
    - [ ] Active courses với progress bars
    - [ ] Recent exam results
    - [ ] Learning streak calendar
    - [ ] Weekly learning hours chart

  - [ ] **Learning History Timeline:**
    - [ ] Chronological list of activities:
      - [ ] Course enrollments
      - [ ] Lesson completions
      - [ ] Exam purchases
      - [ ] Exam attempts
      - [ ] Achievements unlocked
    - [ ] Filter by activity type
    - [ ] Filter by date range
    - [ ] Load more button (pagination)

  - [ ] **Achievements Display:**
    - [ ] Achievements grid
    - [ ] Achievement cards với:
      - [ ] Achievement icon
      - [ ] Achievement name
      - [ ] Achievement description
      - [ ] Unlocked date (nếu đã unlock)
      - [ ] Progress indicator (nếu chưa unlock)
    - [ ] Filter by status (Unlocked, Locked)
    - [ ] Achievement categories

  - [ ] **Progress Report Page:**
    - [ ] Overall statistics
    - [ ] Course progress breakdown
    - [ ] Exam performance analysis
    - [ ] Learning time analysis (daily, weekly, monthly)
    - [ ] Strengths và weaknesses
    - [ ] Recommendations
    - [ ] Export report (PDF)

**Cường (Frontend Developer) - Exam Taking Interface (US3.2) - CHI TIẾT:**
- [ ] **Exam Start Page:**
  - [ ] Exam instructions display
  - [ ] Exam duration information
  - [ ] Sections overview (Reading, Listening, Writing, Speaking)
  - [ ] Start exam button
  - [ ] Warning dialog về timer countdown

- [ ] **Exam Taking Page - Main Layout:**
  - [ ] Header với timer countdown (countdown từ tổng thời gian)
  - [ ] Section navigation tabs (Reading, Listening, Writing, Speaking)
  - [ ] Current section indicator
  - [ ] Progress bar (số câu đã làm / tổng số câu)
  - [ ] Auto-save indicator (saving... / saved)
  - [ ] Question navigation sidebar (danh sách câu hỏi)
  - [ ] Submit exam button (disabled cho đến khi hoàn thành tất cả sections)

- [ ] **Reading Section UI:**
  - [ ] Reading passage display (scrollable)
  - [ ] Questions list (bên phải hoặc dưới passage)
  - [ ] Question types: MCQ, True/False, Fill-in-blank
  - [ ] Answer input fields (radio buttons, checkboxes, text input)
  - [ ] Mark for review checkbox
  - [ ] Previous/Next question buttons
  - [ ] Question number navigation

- [ ] **Listening Section UI:**
  - [ ] Audio player với controls (play, pause, volume, seek)
  - [ ] Audio transcript toggle (optional)
  - [ ] Questions list
  - [ ] Answer input fields
  - [ ] Play count indicator (số lần đã nghe)
  - [ ] Timer cho audio playback
  - [ ] Previous/Next question buttons

- [ ] **Writing Section UI:**
  - [ ] Writing prompt display
  - [ ] Word count requirement display
  - [ ] Rich text editor (hoặc textarea)
  - [ ] Word count counter (real-time)
  - [ ] Character count
  - [ ] Save draft button
  - [ ] Formatting toolbar (bold, italic, underline - optional)
  - [ ] Spell check indicator

- [ ] **Speaking Section UI:**
  - [ ] Speaking prompt display
  - [ ] Recording interface
  - [ ] Record button
  - [ ] Stop recording button
  - [ ] Playback recorded audio
  - [ ] Recording timer
  - [ ] Re-record button
  - [ ] Audio waveform visualization
  - [ ] Upload audio file option (backup)

- [ ] **Question Navigation Sidebar:**
  - [ ] List of all questions với status:
    - [ ] Not answered (gray)
    - [ ] Answered (green)
    - [ ] Marked for review (yellow)
    - [ ] Current question (highlighted)
  - [ ] Click to jump to question
  - [ ] Section grouping

- [ ] **Auto-save Functionality:**
  - [ ] Auto-save every 30 seconds
  - [ ] Visual indicator (saving... / saved / error)
  - [ ] Manual save button
  - [ ] Last saved timestamp
  - [ ] Warning khi rời trang (nếu có thay đổi chưa lưu)

- [ ] **Timer Functionality:**
  - [ ] Countdown timer (HH:MM:SS format)
  - [ ] Warning khi còn 10 phút (yellow)
  - [ ] Warning khi còn 5 phút (orange)
  - [ ] Warning khi còn 1 phút (red)
  - [ ] Auto-submit khi hết thời gian
  - [ ] Pause timer option (nếu được phép)

- [ ] **Submit Exam Flow:**
  - [ ] Submit button (chỉ enable khi đã làm tất cả sections)
  - [ ] Submit confirmation dialog:
    - [ ] Summary (số câu đã trả lời, số câu chưa trả lời)
    - [ ] Warning về không thể quay lại sau khi submit
    - [ ] Confirm/Cancel buttons
  - [ ] Final submission processing
  - [ ] Loading indicator
  - [ ] Success message
  - [ ] Redirect to exam result page

- [ ] **Exam Result Display Page (US3.2) - CHI TIẾT:**
  - [ ] **Result Header:**
    - [ ] Exam name và date taken
    - [ ] Overall score display (large, prominent)
    - [ ] Pass/Fail indicator với badge
    - [ ] Score out of total (e.g., 85/100)

  - [ ] **Section Scores Breakdown:**
    - [ ] Reading score với progress bar
    - [ ] Listening score với progress bar
    - [ ] Writing score với progress bar
    - [ ] Speaking score với progress bar
    - [ ] Click to expand section details

  - [ ] **AI Grading Results (Immediate):**
    - [ ] AI score breakdown
    - [ ] AI feedback summary
    - [ ] Strengths identified by AI
    - [ ] Areas for improvement
    - [ ] Estimated band score (nếu IELTS/TOEFL)

  - [ ] **Teacher Feedback Section (US4.1) - Khi đã được chấm:**
    - [ ] Teacher name và avatar
    - [ ] Grading date
    - [ ] **Writing Feedback:**
      - [ ] Writing score breakdown (Task Achievement, Coherence, Lexical Resource, Grammar)
      - [ ] Detailed feedback text
      - [ ] Highlighted strengths
      - [ ] Highlighted weaknesses
      - [ ] Suggestions for improvement
      - [ ] Sample corrections (nếu có)
    - [ ] **Speaking Feedback:**
      - [ ] Speaking score breakdown (Fluency, Pronunciation, Vocabulary, Grammar)
      - [ ] Detailed feedback text
      - [ ] Audio feedback (nếu teacher ghi âm)
      - [ ] Pronunciation tips
      - [ ] Vocabulary suggestions
    - [ ] **Overall Comments:**
      - [ ] General feedback
      - [ ] Recommendations
      - [ ] Next steps

  - [ ] **View Answers Section:**
    - [ ] Toggle button "View Correct Answers"
    - [ ] Reading answers với explanations
    - [ ] Listening answers với explanations
    - [ ] Your answers vs Correct answers comparison
    - [ ] Question-by-question breakdown

  - [ ] **Actions:**
    - [ ] Download result PDF button
    - [ ] Share result button (optional - social media)
    - [ ] Print result button
    - [ ] Retake exam button (nếu được phép)
    - [ ] View similar exams button
    - [ ] Book a consultation button (optional)

  - [ ] **Progress Tracking:**
    - [ ] Comparison với previous attempts (nếu có)
    - [ ] Score trend chart
    - [ ] Improvement areas highlighted

- [ ] **Responsive Design:**
  - [ ] Mobile-friendly exam interface
  - [ ] Touch-optimized controls
  - [ ] Collapsible sidebar trên mobile
  - [ ] Full-screen mode option

**Kiên (Backend Developer) - Teacher Grading System (EPIC 4 - US4.1):**
- [ ] Tạo GradingService.cs
- [ ] Implement GetPendingGradings method (danh sách bài thi cần chấm)
- [ ] Implement GetExamSubmission method
- [ ] Implement GradeWriting method
- [ ] Implement GradeSpeaking method
- [ ] Implement UseAIAssistance method (AI hỗ trợ chấm điểm)
- [ ] Implement SubmitGrading method với feedback
- [ ] Implement GetGradingHistory method
- [ ] Tạo GradingDto.cs, GradingFeedbackDto.cs

**Cường (Frontend Developer) - Teacher Grading UI (EPIC 4 - US4.1):**
- [ ] Teacher grading dashboard
- [ ] Pending gradings list
- [ ] Grading interface cho Writing
- [ ] Grading interface cho Speaking
- [ ] AI assistance panel (hiển thị gợi ý từ AI)
- [ ] Feedback editor (rich text)
- [ ] Score input và validation
- [ ] Submit grading button

**Kiên (Backend Developer) - Admin Coin Management (US9.5, US9.6):**
- [ ] Implement GetCoinTransactions method (với filters)
- [ ] Implement GetCoinTransactionSummary method
- [ ] Implement RefundCoin method
- [ ] Implement GetExchangeRates method
- [ ] Implement UpdateExchangeRate method
- [ ] Implement CreatePromotion method (bonus %)
- [ ] Implement SetSpecialRateForCenter method (tỷ giá đặc biệt cho từng trung tâm) (US9.6)
- [ ] Implement GetCoinReports method
- [ ] Tạo CoinTransactionDto.cs, ExchangeRateDto.cs

**Kiên (Backend Developer) - Accountant Payment Management (US5.1):**
- [ ] Tạo PaymentService.cs (cho Accountant)
- [ ] Implement GetFailedTransactions method (xem giao dịch thất bại)
- [ ] Implement RetryFailedTransaction method (thử lại thanh toán thất bại)
- [ ] Implement ReconcileBankTransactions method (reconcile ngân hàng - basic)
- [ ] Implement GetReconciliationReport method
- [ ] Implement ProcessRefundRequest method (xử lý yêu cầu refund)
- [ ] Implement GetRefundHistory method
- [ ] Tạo PaymentReconciliationDto.cs, RefundRequestDto.cs

**Kiên (Backend Developer) - Partner Commission Features (US8.3):**
- [ ] Implement GetTopReferralCodes method (top mã hiệu quả nhất)
- [ ] Implement GetPaymentSchedule method (lịch thanh toán hoa hồng)
- [ ] Implement GenerateCommissionInvoice method (tạo hóa đơn hoa hồng)
- [ ] Implement DownloadInvoice method (download hóa đơn)
- [ ] Tạo PaymentScheduleDto.cs, CommissionInvoiceDto.cs

**Kiên (Backend Developer) - Admin Partner Management (US8.5):**
- [ ] Implement GetPartnerCenters method (với filters)
- [ ] Implement ConfigureCommissionRate method (theo tier hoặc từng trung tâm)
- [ ] Implement GetPartnerPerformance method
- [ ] Implement FraudDetectionCheck method (basic)
- [ ] Implement GetPartnerReports method
- [ ] Tạo PartnerCenterDto.cs, CommissionConfigDto.cs

**Kiên (Backend Developer) - Admin Grading Management (US4.2):**
- [ ] Implement GetAllGradings method
- [ ] Implement GetGradingStatistics method
- [ ] Implement ReviewGradingQuality method
- [ ] Implement GetGradingReports method
- [ ] Tạo GradingStatisticsDto.cs

**Kiên (Backend Developer) - Admin User Management (US1.4):**
- [ ] Implement GetUsers method (với filters)
- [ ] Implement LockUser method
- [ ] Implement UnlockUser method
- [ ] Implement UpdateUserRole method
- [ ] Implement GetUserPermissions method
- [ ] Implement UpdateUserPermissions method
- [ ] Tạo UserManagementDto.cs, UserRoleDto.cs

**Kiên (Backend Developer) - Course Statistics (US2.5):**
- [ ] Implement GetCourseStatistics method
- [ ] Count enrolled students per course
- [ ] Calculate completion rate
- [ ] Tạo CourseStatisticsDto.cs

**Kiên (Backend Developer) - Content Approval System (US7.2):**
- [ ] Implement ApproveCourse method (phê duyệt khóa học)
- [ ] Implement RejectCourse method (từ chối với lý do)
- [ ] Implement ApproveExam method (phê duyệt bài thi)
- [ ] Implement RejectExam method (từ chối với lý do)
- [ ] Implement GetPendingApprovals method (danh sách nội dung chờ phê duyệt)
- [ ] Implement GetContentCategories method (quản lý categories)
- [ ] Implement CreateCategory method
- [ ] Implement UpdateCategory method
- [ ] Implement DeleteCategory method
- [ ] Tạo ContentApprovalDto.cs, CategoryDto.cs

**Kiên (Backend Developer) - Student View Feedback (US4.1):**
- [ ] Implement GetExamFeedback method (cho Student)
- [ ] Return teacher feedback và scores
- [ ] Tạo ExamFeedbackDto.cs

**Kiên (Backend Developer) - Teacher Earning (EPIC 4):**
- [ ] Implement GetTeacherEarnings method
- [ ] Calculate commission từ grading
- [ ] Implement GetTeacherEarningReport method
- [ ] Tạo TeacherEarningDto.cs

**Kiên (Backend Developer) - Admin Dashboard (US7.1):**
- [ ] Implement GetSystemDashboard method
- [ ] Calculate KPIs (total users, courses, exams, revenue)
- [ ] Get recent activities
- [ ] Get system statistics
- [ ] Implement GetAIAnalytics method (Analytics AI) (US7.1)
- [ ] Tạo SystemDashboardDto.cs, AIAnalyticsDto.cs

**Cường (Frontend Developer) - Admin Coin Management UI (US9.5, US9.6):**
- [ ] Coin transactions dashboard
- [ ] Transaction filters (status, method, center)
- [ ] Transaction search
- [ ] Refund coin dialog
- [ ] Exchange rate management page
- [ ] Create promotion form
- [ ] Set special exchange rate for center form (US9.6)
- [ ] Coin reports và analytics
- [ ] Export reports (Excel/PDF)

**Cường (Frontend Developer) - Admin Partner Management UI (US8.5):**
- [ ] Partner centers list page
- [ ] Configure commission rate dialog (theo tier hoặc từng trung tâm)
- [ ] Partner performance dashboard
- [ ] Fraud detection alerts
- [ ] Partner reports và analytics

**Cường (Frontend Developer) - Admin Grading Management UI (US4.2):**
- [ ] All gradings list page
- [ ] Grading statistics dashboard
- [ ] Grading quality review interface
- [ ] Grading reports và analytics

**Cường (Frontend Developer) - Admin User Management UI (US1.4):**
- [ ] Users list page với filters
- [ ] Lock/Unlock user buttons
- [ ] User role management interface
- [ ] User permissions management interface
- [ ] User detail view

**Cường (Frontend Developer) - Course Statistics UI (US2.5):**
- [ ] Course statistics display trong course detail
- [ ] Enrolled students count
- [ ] Completion rate chart

**Cường (Frontend Developer) - Student View Feedback UI (US4.1):**
- [ ] **My Exam Results Page:**
  - [ ] List of all exam attempts
  - [ ] Exam cards với:
    - [ ] Exam name
    - [ ] Date taken
    - [ ] Overall score
    - [ ] Status (Graded, Pending grading)
    - [ ] View result button
  - [ ] Filter by exam type
  - [ ] Filter by date range
  - [ ] Sort by (Date, Score, Status)

- [ ] **Exam Result Detail Page (đã có ở trên, nhưng cần link từ My Exam Results)**
  - [ ] Link từ My Exam Results page
  - [ ] Full result display với teacher feedback
  - [ ] All sections đã được mô tả ở trên

**Cường (Frontend Developer) - Teacher Earning UI (EPIC 4):**
- [ ] Teacher earning dashboard
- [ ] Earning history table
- [ ] Earning reports và charts

**Cường (Frontend Developer) - Admin Dashboard UI (US7.1):**
- [ ] System dashboard với KPI cards
- [ ] Total users, courses, exams, revenue
- [ ] Recent activities feed
- [ ] System statistics charts
- [ ] AI Analytics section (US7.1)
- [ ] Revenue reports (báo cáo doanh thu) (US7.1)
- [ ] User reports (báo cáo người dùng) (US7.1)

**Cường (Frontend Developer) - Accountant Payment Management UI (US5.1):**
- [ ] Failed transactions list page
- [ ] Retry failed transaction button
- [ ] Bank reconciliation interface (basic)
- [ ] Reconciliation report view
- [ ] Refund request processing page
- [ ] Refund history table
- [ ] Export reconciliation report (Excel/PDF)

**Cường (Frontend Developer) - Content Approval UI (US7.2):**
- [ ] Pending approvals list page
- [ ] Approve/Reject course dialog
- [ ] Approve/Reject exam dialog
- [ ] Rejection reason input field
- [ ] Content categories management page
- [ ] Create/Edit/Delete category forms
- [ ] Category tree view

**Toàn bộ team:**
- [ ] Test complete flow: Register → Login → Purchase Coin → Buy Exam
- [ ] Test với referral code: Coin purchase → Commission calculation
- [ ] Test với referral code: Exam purchase → Commission calculation
- [ ] Test partner dashboard updates real-time
- [ ] Test coin balance updates correctly
- [ ] Test learning flow: Enroll → Watch Video → Take Quiz → View Progress
- [ ] Test exam flow: Purchase → Start Exam → Auto-save → Submit → View Result
- [ ] Test permission system
- [ ] Test error handling
- [ ] Performance testing (response times)
- [ ] Security review (SQL injection, XSS)
- [ ] Fix critical bugs
- [ ] Code review session

---

#### 📌 **TUẦN 5: FINAL DEMO PREP (25-29/12)**

##### **Ngày 29-31 (25-27/12): UI/UX Polish + Support System**
**Cường (Frontend Developer):**
- [ ] Polish all UI components
- [ ] Add loading states cho tất cả API calls
- [ ] Add error handling và error messages
- [ ] Responsive design fixes (mobile, tablet)
- [ ] Cross-browser testing (Chrome, Firefox, Edge)
- [ ] Add success notifications
- [ ] Add empty states
- [ ] Add skeleton loaders
- [ ] Improve form validation messages
- [ ] Add tooltips và help text

**Kiên (Backend Developer) - Support System (US6.1):**
- [ ] Tạo SupportService.cs
- [ ] Implement GetFAQs method (FAQ list)
- [ ] Implement GetFAQCategories method
- [ ] Implement GetHelpVideos method (video hướng dẫn)
- [ ] Implement GetHelpVideoCategories method
- [ ] Implement SearchFAQs method
- [ ] Tạo FAQDto.cs, HelpVideoDto.cs
- [ ] Seed initial FAQ data (câu hỏi thường gặp về coin, exam, course)
- [ ] Seed initial help videos (hướng dẫn nạp coin, mua exam, sử dụng mã giới thiệu)

**Cường (Frontend Developer) - Support System UI (US6.1):**
- [ ] FAQ page với categories
- [ ] FAQ search functionality
- [ ] FAQ detail view
- [ ] Help videos page với categories
- [ ] Video player cho help videos
- [ ] Support menu trong navigation
- [ ] Quick help widget (có thể mở từ bất kỳ trang nào)

**Kiên (Backend Developer):**
- [ ] API documentation (Swagger/OpenAPI)
- [ ] Error handling improvements
- [ ] Logging enhancements (structured logging)
- [ ] Performance optimization (query optimization)
- [ ] Add API rate limiting
- [ ] Security headers configuration
- [ ] CORS configuration
- [ ] Health check endpoint
- [ ] Version endpoint

**Phong (System Architect):**
- [ ] Architecture review
- [ ] Security audit
- [ ] Performance review
- [ ] Code quality review
- [ ] Documentation review

---

##### **Ngày 32 (28/12): Demo Preparation**
**Toàn bộ team:**
- [ ] Prepare demo environment
- [ ] Seed demo data (users, courses, exams)
- [ ] Create demo accounts:
  - [ ] Student: student@demo.com / Demo123!
  - [ ] Teacher: teacher@demo.com / Demo123!
  - [ ] Admin: admin@demo.com / Demo123!
  - [ ] Partner: partner@demo.com / Demo123!
- [ ] Create sample referral codes
- [ ] Prepare demo script document
- [ ] Test demo flow end-to-end (3 lần)
- [ ] Deploy to demo environment
- [ ] Smoke testing on demo server
- [ ] Prepare presentation slides
- [ ] Record backup demo video (in case of issues)

**Demo Flow Checklist:**
- [ ] 1. Student registration → Login
- [ ] 2. Browse free courses
- [ ] 3. Purchase 500K VNĐ coins with referral code → Verify bonus
- [ ] 4. Browse exam catalog → Filter/Search exams
- [ ] 5. View exam detail page → Preview exam structure
- [ ] 6. Purchase exam with coin → Verify discount
- [ ] 7. Check coin balance updated
- [ ] 8. Go to "My Exams" page → See purchased exam
- [ ] 9. Start exam attempt → View exam instructions
- [ ] 10. Exam taking flow:
    - [ ] Reading section: Answer questions, navigate between questions
    - [ ] Listening section: Play audio, answer questions
    - [ ] Writing section: Type essay, check word count
    - [ ] Speaking section: Record audio (hoặc upload file)
    - [ ] Timer countdown working
    - [ ] Auto-save indicator showing
    - [ ] Question navigation sidebar working
    - [ ] Submit exam → Confirm submission
- [ ] 11. View exam result page → See AI grading results
- [ ] 12. Partner login → View dashboard
- [ ] 13. Verify commission from student transaction
- [ ] 14. View referral code statistics
- [ ] 15. Admin login → View system overview
- [ ] 16. Approve new partner registration
- [ ] 17. View transaction reports
- [ ] 18. Admin: Approve/reject course content (US7.2)
- [ ] 19. Admin: Manage content categories (US7.2)
- [ ] 20. Accountant: View failed transactions → Retry (US5.1)
- [ ] 21. Accountant: Process refund request (US5.1)
- [ ] 22. Student: View FAQ và help videos (US6.1)
- [ ] 23. Student: Search FAQs (US6.1)

---

##### **Ngày 33 (29/12): DEMO DAY 🎉**
**Morning:**
- [ ] 8:00 AM: Team arrives, final system check
- [ ] 8:30 AM: Run through demo script one last time
- [ ] 9:00 AM: Verify demo environment is up
- [ ] 9:30 AM: Setup presentation room

**Demo Session:**
- [ ] 10:00 AM: Welcome và introduction (Nguyên)
- [ ] 10:15 AM: System overview presentation (Phong)
- [ ] 10:30 AM: Live demo - Student flow (Cường)
- [ ] 10:45 AM: Live demo - Partner flow (Cường)
- [ ] 11:00 AM: Live demo - Admin flow (Kiên)
- [ ] 11:15 AM: Technical architecture overview (Phong)
- [ ] 11:30 AM: Q&A session
- [ ] 12:00 PM: Lunch break

**Afternoon:**
- [ ] 1:00 PM: Feedback collection session
- [ ] 2:00 PM: Sprint retrospective (team only)
  - [ ] What went well?
  - [ ] What could be improved?
  - [ ] Action items for Phase 2
- [ ] 3:00 PM: Planning session cho Phase 2
  - [ ] Review Phase 2 requirements
  - [ ] Prioritize features
  - [ ] Estimate timeline
- [ ] 4:00 PM: Team celebration 🎉

---

### 🎯 **FEATURE COMPLETION SUMMARY**

#### **Core Features (Must Have - P0)**
- [ ] **Authentication System**
  - [ ] Student registration/login
  - [ ] Teacher registration/login
  - [ ] Admin login
  - [ ] Partner registration/login
  - [ ] JWT token management
  - [ ] Password hashing
  - [ ] Email verification (basic)

- [ ] **Coin System**
  - [ ] Purchase coins với VNĐ
  - [ ] Coin balance tracking
  - [ ] Use coins for purchases
  - [ ] Transaction history
  - [ ] Exchange rate management

- [ ] **Referral Code System**
  - [ ] Create referral codes
  - [ ] Validate referral codes
  - [ ] Apply discount (percentage hoặc fixed coins)
  - [ ] Track code usage
  - [ ] Expiry date management
  - [ ] Usage limit management

- [ ] **Commission System**
  - [ ] Auto-calculate commission từ coin purchase
  - [ ] Auto-calculate commission từ exam purchase
  - [ ] Commission rate theo partner tier
  - [ ] Commission transaction logging
  - [ ] Commission dashboard

- [ ] **Partner Portal**
  - [ ] Partner registration form
  - [ ] Admin approval workflow
  - [ ] Partner dashboard với KPIs
  - [ ] Referral code management
  - [ ] Commission history
  - [ ] Student tracking

- [ ] **Course Management**
  - [ ] Create free courses
  - [ ] Create premium courses
  - [ ] Course catalog (public)
  - [ ] Course detail page
  - [ ] Course status (Draft/Published)
  - [ ] Upload video, tài liệu (US2.1)
  - [ ] Quản lý bài học trong khóa học (US2.1)

- [ ] **Lesson Bank System (US2.7)**
  - [ ] Tạo bài học với video, text, quiz
  - [ ] Quản lý tài liệu đính kèm
  - [ ] Phân loại bài học

- [ ] **Exam System**
  - [ ] Create exams với pricing
  - [ ] Exam catalog với filters và search
  - [ ] Exam detail page với preview
  - [ ] Purchase exam with coin
  - [ ] Apply referral code discount
  - [ ] Track purchased exams
  - [ ] My exams page
  - [ ] Exam taking interface (chi tiết):
    - [ ] Exam start page với instructions
    - [ ] Timer countdown
    - [ ] Section navigation (Reading, Listening, Writing, Speaking)
    - [ ] Question navigation sidebar
    - [ ] Reading section UI
    - [ ] Listening section UI với audio player
    - [ ] Writing section UI với rich text editor
    - [ ] Speaking section UI với recording
    - [ ] Auto-save functionality
    - [ ] Submit exam flow
    - [ ] Exam result display page

- [ ] **Question Bank System (US2.6)**
  - [ ] Tạo và quản lý câu hỏi
  - [ ] Phân loại câu hỏi theo level, topic
  - [ ] Import/Export câu hỏi
  - [ ] Quản lý đáp án

- [ ] **Exam Template System (US2.8)**
  - [ ] Sử dụng template để tạo đề thi
  - [ ] Thuật toán tự động chọn câu hỏi
  - [ ] Thiết lập độ khó, số lượng câu hỏi

- [ ] **Learning System (EPIC 3)**
  - [ ] Học khóa học: xem video, làm quiz, ghi chú, offline (US3.1)
  - [ ] Làm bài thi: timer, auto-save, submit, xem kết quả (US3.2)
  - [ ] Dashboard học tập: tiến độ, lịch sử, achievements (US3.3)

- [ ] **Admin Features**
  - [ ] Approve/reject partner registration
  - [ ] View system dashboard với KPIs (US7.1)
  - [ ] Manage courses
  - [ ] View course statistics - enrolled students (US2.5)
  - [ ] Manage exams
  - [ ] View transaction reports
  - [ ] Manage coin transactions (US9.5)
  - [ ] Manage coin exchange rates (US9.6)
  - [ ] View coin reports và analytics
  - [ ] Manage partner centers - configure commission (US8.5)
  - [ ] Monitor partner performance (US8.5)
  - [ ] Fraud detection alerts (US8.5)
  - [ ] Manage grading quality (US4.2)
  - [ ] View grading statistics (US4.2)
  - [ ] Manage users - lock/unlock accounts (US1.4)
  - [ ] Manage user roles và permissions (US1.4)
  - [ ] View users list (US1.4)
  - [ ] Approve/reject content (courses, exams) (US7.2)
  - [ ] Manage content categories (US7.2)

- [ ] **Teacher Features (EPIC 4)**
  - [ ] View pending gradings
  - [ ] Grade Writing và Speaking
  - [ ] Use AI assistance
  - [ ] Submit feedback
  - [ ] View earning dashboard
  - [ ] View earning reports
  - [ ] View commission từ chấm bài

- [ ] **Partner Features (US8.4)**
  - [ ] View referred students list
  - [ ] Filter và search students
  - [ ] View student activity history
  - [ ] Send notifications to students

- [ ] **Student Features (US2.2, US3.2, US4.1)**
  - [ ] Purchase premium courses với coin
  - [ ] View enrolled courses
  - [ ] Browse exam catalog
  - [ ] View exam details
  - [ ] Purchase exam with coin
  - [ ] My exams page
  - [ ] Start exam attempt
  - [ ] Exam taking interface (full flow):
    - [ ] Reading section
    - [ ] Listening section
    - [ ] Writing section
    - [ ] Speaking section
    - [ ] Timer và auto-save
    - [ ] Submit exam
  - [ ] View exam results với AI grading
  - [ ] View exam results với teacher feedback (US4.1)
  - [ ] View teacher scores và comments
  - [ ] FAQ và help videos (US6.1)
  - [ ] Search FAQs
  - [ ] Watch help videos

---

#### **Additional Features (Should Have - P1)**
- [ ] **Email Notifications**
  - [ ] Partner registration confirmation
  - [ ] Partner approval notification
  - [ ] Coin purchase confirmation
  - [ ] Exam purchase confirmation
  - [ ] Commission notification

- [ ] **Payment Gateway**
  - [ ] VNPay integration (test mode)
  - [ ] Payment callback handling
  - [ ] Payment status tracking

- [ ] **Reporting**
  - [ ] Partner commission report
  - [ ] Transaction summary report
  - [ ] Student activity report
  - [ ] Export to Excel/PDF

- [ ] **Course Enrollment**
  - [ ] Enroll in free courses
  - [ ] Track enrollment status
  - [ ] My courses page

- [ ] **Accountant Features (US5.1)**
  - [ ] View failed transactions
  - [ ] Retry failed transactions
  - [ ] Bank reconciliation (basic)
  - [ ] Process refund requests
  - [ ] View refund history
  - [ ] Export reconciliation reports

- [ ] **Support System (US6.1)**
  - [ ] FAQ system với categories
  - [ ] Help videos với categories
  - [ ] FAQ search functionality
  - [ ] Quick help widget

---

#### **Nice to Have Features (P2)**
- [ ] **Advanced UI**
  - [ ] Charts và visualizations
  - [ ] Real-time notifications
  - [ ] Advanced filters và search
  - [ ] Bulk operations

- [ ] **Mobile Responsive**
  - [ ] Mobile-friendly layouts
  - [ ] Touch-optimized interactions
  - [ ] Mobile navigation

- [ ] **Analytics**
  - [ ] Partner performance analytics
  - [ ] Student behavior analytics
  - [ ] Revenue analytics

---

### 📊 **PROGRESS TRACKING**

#### **Overall Progress**
- [ ] **Week 1-2**: Foundation & Database (0/62 tasks)
- [ ] **Week 3**: Coin System (0/30 tasks)
- [ ] **Week 4**: Content System (0/28 tasks)
- [ ] **Week 5**: Demo Prep + Support System (0/60 tasks)
- [ ] **TOTAL**: 0/180 tasks completed (0%)

#### **By Team Member**
- [ ] **Phong (Architect)**: 0/25 tasks
- [ ] **Kiên (Backend)**: 0/100 tasks (đã thêm: US5.1, US7.2, US6.1)
- [ ] **Cường (Frontend)**: 0/55 tasks (đã thêm: US5.1, US7.2, US6.1)
- [ ] **Nguyên (PO)**: 0/10 tasks

#### **By Module**
- [ ] **Authentication**: 0/15 tasks
- [ ] **Coin System**: 0/25 tasks
- [ ] **Partner System**: 0/30 tasks
- [ ] **Content System**: 0/25 tasks (đã thêm: US7.2 - Content Approval)
- [ ] **Exam System**: 0/15 tasks
- [ ] **Payment Management**: 0/10 tasks (mới: US5.1 - Accountant)
- [ ] **Support System**: 0/10 tasks (mới: US6.1 - FAQ & Help Videos)
- [ ] **UI/UX**: 0/30 tasks (đã thêm: US5.1, US7.2, US6.1 UI)
- [ ] **Testing**: 0/20 tasks
- [ ] **Demo**: 0/15 tasks

---

### 🚦 **DAILY STATUS TRACKING**

#### **Tuần 1 (27/11 - 03/12)**
```
[ ] Day 1 (27/11): ___ tasks completed
[ ] Day 2 (28/11): ___ tasks completed
[ ] Day 3 (29/11): ___ tasks completed
[ ] Day 4 (30/11): ___ tasks completed
[ ] Day 5 (01/12): ___ tasks completed
[ ] Day 6 (02/12): ___ tasks completed
[ ] Day 7 (03/12): ___ tasks completed
```

#### **Tuần 2 (04/12 - 10/12)**
```
[ ] Day 8 (04/12): ___ tasks completed
[ ] Day 9 (05/12): ___ tasks completed
[ ] Day 10 (06/12): ___ tasks completed
[ ] Day 11 (07/12): ___ tasks completed
[ ] Day 12 (08/12): ___ tasks completed
[ ] Day 13 (09/12): ___ tasks completed
[ ] Day 14 (10/12): ___ tasks completed
```

#### **Tuần 3 (11/12 - 17/12)**
```
[ ] Day 15 (11/12): ___ tasks completed
[ ] Day 16 (12/12): ___ tasks completed
[ ] Day 17 (13/12): ___ tasks completed
[ ] Day 18 (14/12): ___ tasks completed
[ ] Day 19 (15/12): ___ tasks completed
[ ] Day 20 (16/12): ___ tasks completed
[ ] Day 21 (17/12): ___ tasks completed
```

#### **Tuần 4 (18/12 - 24/12)**
```
[ ] Day 22 (18/12): ___ tasks completed
[ ] Day 23 (19/12): ___ tasks completed
[ ] Day 24 (20/12): ___ tasks completed
[ ] Day 25 (21/12): ___ tasks completed
[ ] Day 26 (22/12): ___ tasks completed
[ ] Day 27 (23/12): ___ tasks completed
[ ] Day 28 (24/12): ___ tasks completed
```

#### **Tuần 5 (25/12 - 29/12)**
```
[ ] Day 29 (25/12): ___ tasks completed
[ ] Day 30 (26/12): ___ tasks completed
[ ] Day 31 (27/12): ___ tasks completed
[ ] Day 32 (28/12): ___ tasks completed
[ ] Day 33 (29/12): DEMO DAY 🎉
```

---

### 🎯 **MILESTONE CHECKLIST**

#### **Milestone 1: Foundation Complete (10/12)**
- [ ] All entities created
- [ ] All migrations successful
- [ ] Authentication working
- [ ] Partner registration working
- [ ] Basic UI layouts ready

#### **Milestone 2: Coin System Complete (17/12)**
- [ ] Coin purchase working
- [ ] Referral code system working
- [ ] Commission calculation working
- [ ] Partner dashboard functional

#### **Milestone 3: Content System Complete (24/12)**
- [ ] Course management working
- [ ] Lesson bank system working (US2.7)
- [ ] Question bank system working (US2.6)
- [ ] Exam template system working (US2.8)
- [ ] Exam purchase with coin working
- [ ] Learning system working (EPIC 3)
- [ ] End-to-end flow tested
- [ ] Major bugs fixed

#### **Milestone 4: DEMO Ready (29/12)**
- [ ] All P0 features complete
- [ ] UI polished
- [ ] Demo environment stable
- [ ] Demo script prepared
- [ ] Presentation ready

---

### Phạm Vi Dự Án
Xây dựng hệ thống giáo dục trực tuyến B2B2C với 5 vai trò:
1. **Student** - Học viên học và thi
2. **Teacher** - Giáo viên chấm bài
3. **Admin** - Quản trị hệ thống
4. **Accountant** - Kế toán quản lý tài chính
5. **Partner Center** - Trung tâm đối tác (MỚI)

### Tech Stack Hiện Tại
- **Backend**: .NET Core 8 + ASP.NET Core Web API
- **Frontend**: Blazor Server/WebAssembly
- **Database**: PostgreSQL (transactional) + MongoDB (documents)
- **Cache**: Redis
- **Message Queue**: RabbitMQ
- **Architecture**: Module-based (Core, User, Employee, Management, Setting)

---

## 🎯 CẤU TRÚC MODULE HIỆN TẠI VÀ MỞ RỘNG

### Modules Đã Có (Cần Customize)
```
SLK.TryEdu.Abstract/          → Core abstractions, EntityBase
SLK.TryEdu.Base/              → MyServiceBase, IMyContext
SLK.TryEdu.Db/                → DbPostgresContext, Repositories
SLK.TryEdu.ModuleUser/        → User management (cần mở rộng cho Student)
SLK.TryEdu.ModuleUserCore/    → User entities & interfaces
SLK.TryEdu.ModuleEmployee/    → Employee management (Teacher)
SLK.TryEdu.ModuleManagement/  → Management (Admin)
SLK.TryEdu.ModuleSetting/     → System settings
```

### Modules Cần Tạo Mới (V2.0)
```
SLK.TryEdu.ModuleCoin/        → Coin system, transactions
SLK.TryEdu.ModuleCoinCore/    → Coin entities & interfaces
SLK.TryEdu.ModuleCoinBlazor/  → Coin management UI

SLK.TryEdu.ModulePartner/     → Partner center management
SLK.TryEdu.ModulePartnerCore/ → Partner entities & interfaces
SLK.TryEdu.ModulePartnerBlazor/ → Partner Portal UI

SLK.TryEdu.ModuleContent/     → Course & Exam management
SLK.TryEdu.ModuleContentCore/ → Content entities & interfaces
SLK.TryEdu.ModuleContentBlazor/ → Content management UI

SLK.TryEdu.ModuleLearning/    → Learning progress, exam taking
SLK.TryEdu.ModuleLearningCore/ → Learning entities & interfaces
SLK.TryEdu.ModuleLearningBlazor/ → Student learning UI
```

---

## 📋 PHASE 1: DEMO (27/11 - 29/12) - 32 NGÀY

### 🎯 Mục tiêu DEMO
Hoàn thành **MVP** với các chức năng cốt lõi:
- ✅ User authentication (Student, Teacher, Admin, Partner)
- ✅ Coin system (nạp coin, sử dụng coin)
- ✅ Course management (tạo khóa học miễn phí)
- ✅ Exam management (tạo bài thi có thu phí)
- ✅ Partner system (đăng ký, tạo mã giới thiệu)
- ✅ Commission calculation (tự động tính hoa hồng)

---

## TUẦN 1-2: FOUNDATION & DATABASE (27/11 - 10/12) - 14 NGÀY

### 🗓️ Tuần 1: Setup & Database Design (27/11 - 03/12)

#### Ngày 1-2 (27-28/11): Project Structure Setup
**Phong (System Architect):**
- [ ] Review cấu trúc module hiện tại
- [ ] Thiết kế kiến trúc mở rộng cho V2.0
- [ ] Tạo solution structure cho modules mới:
  - ModuleCoin (Core, Main, Blazor)
  - ModulePartner (Core, Main, Blazor)
  - ModuleContent (Core, Main, Blazor)
  - ModuleLearning (Core, Main, Blazor)
- [ ] Document architecture decisions

**Kiên (Backend Developer):**
- [ ] Clone repository và setup local environment
- [ ] Review EntityBase và MyServiceBase patterns
- [ ] Setup PostgreSQL local instance
- [ ] Setup MongoDB local instance
- [ ] Test connection strings và migrations

**Cường (Frontend Developer):**
- [ ] Review Blazor structure hiện tại
- [ ] Setup UI framework (MudBlazor hoặc Radzen)
- [ ] Tạo base layouts cho Partner Portal
- [ ] Setup shared components

**Nguyên (Product Owner):**
- [ ] Review PRD document
- [ ] Prioritize features cho DEMO
- [ ] Prepare user stories chi tiết
- [ ] Define acceptance criteria

---

#### Ngày 3-5 (29/11 - 01/12): Database Schema Design

**Kiên (Backend Developer) - Priority Task:**

##### 1. Tạo Entities cho Coin System
**File: `SLK.TryEdu.ModuleCoinCore/Entities/EntityCoinTransaction.cs`**
```csharp
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SLK.TryEdu.Abstract;

namespace SLK.TryEdu.ModuleCoinCore;

[Table("COIN_TRANSACTIONS")]
public class EntityCoinTransaction : EntityBase
{
    [Display(Name = "User ID")]
    [Required]
    public int UserId { get; set; }
    
    [Display(Name = "Số tiền (VNĐ)")]
    [Required]
    [Column(TypeName = "decimal(12,2)")]
    public decimal Amount { get; set; }
    
    [Display(Name = "Số coin nhận được")]
    [Required]
    public int CoinsReceived { get; set; }
    
    [Display(Name = "Tỷ giá quy đổi")]
    [Required]
    [Column(TypeName = "decimal(8,4)")]
    public decimal ExchangeRate { get; set; } = 1.0M;
    
    [Display(Name = "Phương thức thanh toán")]
    [MaxLength(50)]
    public string PaymentMethod { get; set; } // VNPay, MoMo, Banking
    
    [Display(Name = "Referral Code ID")]
    public int? ReferralCodeId { get; set; }
    
    [Display(Name = "Trạng thái")]
    [MaxLength(20)]
    public string Status { get; set; } = "Pending"; // Pending, Success, Failed
    
    [Display(Name = "Transaction Type")]
    [MaxLength(50)]
    public string TransactionType { get; set; } = "Purchase"; // Purchase, Usage, Refund
    
    [Display(Name = "Mô tả")]
    [MaxLength(500)]
    public string Description { get; set; }
    
    // Navigation properties
    [ForeignKey("UserId")]
    public virtual EntityUser User { get; set; }
    
    [ForeignKey("ReferralCodeId")]
    public virtual EntityReferralCode ReferralCode { get; set; }
}
```

**File: `SLK.TryEdu.ModuleCoinCore/Entities/EntityCoinBalance.cs`**
```csharp
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SLK.TryEdu.Abstract;

namespace SLK.TryEdu.ModuleCoinCore;

[Table("COIN_BALANCES")]
public class EntityCoinBalance : EntityBase
{
    [Display(Name = "User ID")]
    [Required]
    public int UserId { get; set; }
    
    [Display(Name = "Số coin khả dụng")]
    [Required]
    public int AvailableCoins { get; set; } = 0;
    
    [Display(Name = "Số coin đã sử dụng")]
    [Required]
    public int UsedCoins { get; set; } = 0;
    
    [Display(Name = "Tổng coin")]
    [Required]
    public int TotalCoins { get; set; } = 0;
    
    [Display(Name = "Lần cập nhật cuối")]
    public DateTime LastUpdated { get; set; } = DateTime.UtcNow;
    
    // Navigation property
    [ForeignKey("UserId")]
    public virtual EntityUser User { get; set; }
}
```

##### 2. Tạo Entities cho Partner System
**File: `SLK.TryEdu.ModulePartnerCore/Entities/EntityPartnerCenter.cs`**
```csharp
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SLK.TryEdu.Abstract;

namespace SLK.TryEdu.ModulePartnerCore;

[Table("PARTNER_CENTERS")]
public class EntityPartnerCenter : EntityBase
{
    [Display(Name = "Tên trung tâm")]
    [Required(ErrorMessage = "Tên trung tâm không được để trống!")]
    [MaxLength(255)]
    public string Name { get; set; }
    
    [Display(Name = "Người đại diện")]
    [MaxLength(255)]
    public string ContactPerson { get; set; }
    
    [Display(Name = "Email")]
    [Required(ErrorMessage = "Email không được để trống!")]
    [EmailAddress(ErrorMessage = "Địa chỉ email không hợp lệ!")]
    [MaxLength(255)]
    public string Email { get; set; }
    
    [Display(Name = "Số điện thoại")]
    [MaxLength(20)]
    public string Phone { get; set; }
    
    [Display(Name = "Địa chỉ")]
    [MaxLength(500)]
    public string Address { get; set; }
    
    [Display(Name = "Logo URL")]
    [MaxLength(500)]
    public string LogoUrl { get; set; }
    
    [Display(Name = "Giấy phép kinh doanh")]
    [MaxLength(500)]
    public string BusinessLicenseUrl { get; set; }
    
    [Display(Name = "Mô tả")]
    [MaxLength(2000)]
    public string Description { get; set; }
    
    [Display(Name = "Tỷ lệ hoa hồng")]
    [Column(TypeName = "decimal(5,2)")]
    public decimal CommissionRate { get; set; } = 5.00M;
    
    [Display(Name = "Tier")]
    [MaxLength(20)]
    public string Tier { get; set; } = "Bronze"; // Bronze, Silver, Gold, Platinum
    
    [Display(Name = "Trạng thái")]
    [MaxLength(20)]
    public string Status { get; set; } = "Pending"; // Pending, Active, Suspended, Rejected
    
    [Display(Name = "Ngày phê duyệt")]
    public DateTime? ApprovedAt { get; set; }
    
    [Display(Name = "Người phê duyệt")]
    public int? ApprovedBy { get; set; }
    
    [Display(Name = "Lý do từ chối")]
    [MaxLength(1000)]
    public string RejectionReason { get; set; }
}
```

**File: `SLK.TryEdu.ModulePartnerCore/Entities/EntityReferralCode.cs`**
```csharp
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SLK.TryEdu.Abstract;

namespace SLK.TryEdu.ModulePartnerCore;

[Table("REFERRAL_CODES")]
public class EntityReferralCode : EntityBase
{
    [Display(Name = "Partner Center ID")]
    [Required]
    public int PartnerCenterId { get; set; }
    
    [Display(Name = "Mã giới thiệu")]
    [Required(ErrorMessage = "Mã giới thiệu không được để trống!")]
    [MaxLength(20)]
    public string Code { get; set; }
    
    [Display(Name = "Tên mã")]
    [MaxLength(100)]
    public string Name { get; set; }
    
    [Display(Name = "Giảm giá (%)")]
    [Column(TypeName = "decimal(5,2)")]
    public decimal? DiscountPercentage { get; set; }
    
    [Display(Name = "Giảm giá (coin)")]
    public int? DiscountCoins { get; set; }
    
    [Display(Name = "Kích hoạt")]
    public bool IsActive { get; set; } = true;
    
    [Display(Name = "Ngày hết hạn")]
    public DateTime? ExpiryDate { get; set; }
    
    [Display(Name = "Số lần sử dụng")]
    public int UsageCount { get; set; } = 0;
    
    [Display(Name = "Số lần sử dụng tối đa")]
    public int? MaxUsage { get; set; }
    
    [Display(Name = "Áp dụng cho")]
    [MaxLength(50)]
    public string ApplicableFor { get; set; } = "All"; // All, CoinPurchase, ExamPurchase
    
    // Navigation property
    [ForeignKey("PartnerCenterId")]
    public virtual EntityPartnerCenter PartnerCenter { get; set; }
}
```

**File: `SLK.TryEdu.ModulePartnerCore/Entities/EntityCommissionTransaction.cs`**
```csharp
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SLK.TryEdu.Abstract;

namespace SLK.TryEdu.ModulePartnerCore;

[Table("COMMISSION_TRANSACTIONS")]
public class EntityCommissionTransaction : EntityBase
{
    [Display(Name = "Partner Center ID")]
    [Required]
    public int PartnerCenterId { get; set; }
    
    [Display(Name = "User ID")]
    [Required]
    public int UserId { get; set; }
    
    [Display(Name = "Referral Code ID")]
    public int? ReferralCodeId { get; set; }
    
    [Display(Name = "Số tiền giao dịch (VNĐ)")]
    [Required]
    [Column(TypeName = "decimal(12,2)")]
    public decimal TransactionAmount { get; set; }
    
    [Display(Name = "Số hoa hồng (VNĐ)")]
    [Required]
    [Column(TypeName = "decimal(12,2)")]
    public decimal CommissionAmount { get; set; }
    
    [Display(Name = "Tỷ lệ hoa hồng (%)")]
    [Required]
    [Column(TypeName = "decimal(5,2)")]
    public decimal CommissionRate { get; set; }
    
    [Display(Name = "Loại giao dịch")]
    [MaxLength(50)]
    public string TransactionType { get; set; } // CoinPurchase, ExamPurchase
    
    [Display(Name = "Trạng thái")]
    [MaxLength(20)]
    public string Status { get; set; } = "Pending"; // Pending, Paid, Cancelled
    
    [Display(Name = "Ngày thanh toán")]
    public DateTime? PaidAt { get; set; }
    
    // Navigation properties
    [ForeignKey("PartnerCenterId")]
    public virtual EntityPartnerCenter PartnerCenter { get; set; }
    
    [ForeignKey("UserId")]
    public virtual EntityUser User { get; set; }
    
    [ForeignKey("ReferralCodeId")]
    public virtual EntityReferralCode ReferralCode { get; set; }
}
```

##### 3. Tạo Entities cho Content System
**File: `SLK.TryEdu.ModuleContentCore/Entities/EntityCourse.cs`**
```csharp
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SLK.TryEdu.Abstract;

namespace SLK.TryEdu.ModuleContentCore;

[Table("COURSES")]
public class EntityCourse : EntityBase
{
    [Display(Name = "Tiêu đề")]
    [Required(ErrorMessage = "Tiêu đề không được để trống!")]
    [MaxLength(500)]
    public string Title { get; set; }
    
    [Display(Name = "Slug")]
    [MaxLength(500)]
    public string Slug { get; set; }
    
    [Display(Name = "Mô tả ngắn")]
    [MaxLength(1000)]
    public string Description { get; set; }
    
    [Display(Name = "Mô tả chi tiết")]
    [Column(TypeName = "text")]
    public string FullDescription { get; set; }
    
    [Display(Name = "Ảnh thumbnail")]
    [MaxLength(500)]
    public string ThumbnailUrl { get; set; }
    
    [Display(Name = "Level")]
    [MaxLength(50)]
    public string Level { get; set; } // A1, A2, B1, B2, C1, C2
    
    [Display(Name = "Category")]
    [MaxLength(100)]
    public string Category { get; set; } // IELTS, TOEFL, General English
    
    [Display(Name = "Loại khóa học")]
    [MaxLength(20)]
    public string CourseType { get; set; } = "Free"; // Free, Premium
    
    [Display(Name = "Giá (coin)")]
    public int? Price { get; set; }
    
    [Display(Name = "Thời lượng (phút)")]
    public int? Duration { get; set; }
    
    [Display(Name = "Số học viên")]
    public int StudentCount { get; set; } = 0;
    
    [Display(Name = "Rating trung bình")]
    [Column(TypeName = "decimal(3,2)")]
    public decimal? AverageRating { get; set; }
    
    [Display(Name = "Trạng thái")]
    [MaxLength(20)]
    public string Status { get; set; } = "Draft"; // Draft, Published, Archived
    
    [Display(Name = "Ngày xuất bản")]
    public DateTime? PublishedAt { get; set; }
    
    [Display(Name = "Tags")]
    [MaxLength(500)]
    public string Tags { get; set; } // JSON array or comma-separated
    
    [Display(Name = "MongoDB Course ID")]
    [MaxLength(50)]
    public string MongoDbCourseId { get; set; } // Reference to MongoDB document
}
```

**File: `SLK.TryEdu.ModuleContentCore/Entities/EntityExam.cs`**
```csharp
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SLK.TryEdu.Abstract;

namespace SLK.TryEdu.ModuleContentCore;

[Table("EXAMS")]
public class EntityExam : EntityBase
{
    [Display(Name = "Tiêu đề")]
    [Required(ErrorMessage = "Tiêu đề không được để trống!")]
    [MaxLength(500)]
    public string Title { get; set; }
    
    [Display(Name = "Slug")]
    [MaxLength(500)]
    public string Slug { get; set; }
    
    [Display(Name = "Mô tả")]
    [MaxLength(2000)]
    public string Description { get; set; }
    
    [Display(Name = "Loại bài thi")]
    [MaxLength(50)]
    public string ExamType { get; set; } // IELTS, TOEFL, Practice Test
    
    [Display(Name = "Level")]
    [MaxLength(50)]
    public string Level { get; set; }
    
    [Display(Name = "Giá (coin)")]
    [Required]
    public int Price { get; set; }
    
    [Display(Name = "Thời lượng (phút)")]
    [Required]
    public int Duration { get; set; }
    
    [Display(Name = "Số lượng câu hỏi")]
    public int? QuestionCount { get; set; }
    
    [Display(Name = "Điểm tối đa")]
    [Column(TypeName = "decimal(5,2)")]
    public decimal? MaxScore { get; set; }
    
    [Display(Name = "Passing Score")]
    [Column(TypeName = "decimal(5,2)")]
    public decimal? PassingScore { get; set; }
    
    [Display(Name = "Trạng thái")]
    [MaxLength(20)]
    public string Status { get; set; } = "Draft"; // Draft, Published, Archived
    
    [Display(Name = "Ngày xuất bản")]
    public DateTime? PublishedAt { get; set; }
    
    [Display(Name = "MongoDB Exam ID")]
    [MaxLength(50)]
    public string MongoDbExamId { get; set; } // Reference to MongoDB document with questions
    
    [Display(Name = "Có chấm tự động")]
    public bool HasAutoGrading { get; set; } = true;
    
    [Display(Name = "Cần chấm thủ công")]
    public bool RequiresManualGrading { get; set; } = true;
}
```

##### 4. Tạo Entities cho Learning System
**File: `SLK.TryEdu.ModuleLearningCore/Entities/EntityEnrollment.cs`**
```csharp
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SLK.TryEdu.Abstract;

namespace SLK.TryEdu.ModuleLearningCore;

[Table("ENROLLMENTS")]
public class EntityEnrollment : EntityBase
{
    [Display(Name = "User ID")]
    [Required]
    public int UserId { get; set; }
    
    [Display(Name = "Course ID")]
    [Required]
    public int CourseId { get; set; }
    
    [Display(Name = "Ngày đăng ký")]
    public DateTime EnrolledAt { get; set; } = DateTime.UtcNow;
    
    [Display(Name = "Tiến độ (%)")]
    [Column(TypeName = "decimal(5,2)")]
    public decimal Progress { get; set; } = 0;
    
    [Display(Name = "Trạng thái")]
    [MaxLength(20)]
    public string Status { get; set; } = "Active"; // Active, Completed, Suspended
    
    [Display(Name = "Ngày hoàn thành")]
    public DateTime? CompletedAt { get; set; }
    
    [Display(Name = "Lần truy cập cuối")]
    public DateTime? LastAccessedAt { get; set; }
    
    [Display(Name = "MongoDB Progress ID")]
    [MaxLength(50)]
    public string MongoDbProgressId { get; set; } // Reference to detailed progress in MongoDB
    
    // Navigation properties
    [ForeignKey("UserId")]
    public virtual EntityUser User { get; set; }
    
    [ForeignKey("CourseId")]
    public virtual EntityCourse Course { get; set; }
}
```

**File: `SLK.TryEdu.ModuleLearningCore/Entities/EntityExamSubmission.cs`**
```csharp
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SLK.TryEdu.Abstract;

namespace SLK.TryEdu.ModuleLearningCore;

[Table("EXAM_SUBMISSIONS")]
public class EntityExamSubmission : EntityBase
{
    [Display(Name = "User ID")]
    [Required]
    public int UserId { get; set; }
    
    [Display(Name = "Exam ID")]
    [Required]
    public int ExamId { get; set; }
    
    [Display(Name = "Ngày làm bài")]
    public DateTime SubmittedAt { get; set; } = DateTime.UtcNow;
    
    [Display(Name = "Thời gian làm bài (giây)")]
    public int TimeSpent { get; set; }
    
    [Display(Name = "Điểm số")]
    [Column(TypeName = "decimal(5,2)")]
    public decimal? Score { get; set; }
    
    [Display(Name = "Điểm AI")]
    [Column(TypeName = "decimal(5,2)")]
    public decimal? AIScore { get; set; }
    
    [Display(Name = "Điểm giáo viên")]
    [Column(TypeName = "decimal(5,2)")]
    public decimal? TeacherScore { get; set; }
    
    [Display(Name = "Trạng thái")]
    [MaxLength(20)]
    public string Status { get; set; } = "Submitted"; // Submitted, Grading, Graded
    
    [Display(Name = "Ngày chấm xong")]
    public DateTime? GradedAt { get; set; }
    
    [Display(Name = "Giáo viên chấm")]
    public int? GradedBy { get; set; }
    
    [Display(Name = "Feedback")]
    [Column(TypeName = "text")]
    public string Feedback { get; set; }
    
    [Display(Name = "MongoDB Submission ID")]
    [MaxLength(50)]
    public string MongoDbSubmissionId { get; set; } // Reference to detailed answers in MongoDB
    
    // Navigation properties
    [ForeignKey("UserId")]
    public virtual EntityUser User { get; set; }
    
    [ForeignKey("ExamId")]
    public virtual EntityExam Exam { get; set; }
    
    [ForeignKey("GradedBy")]
    public virtual EntityUser GradingTeacher { get; set; }
}
```

##### 5. Tạo DbContext Registration
**File: `SLK.TryEdu.Db/ModelBuilderExt.cs`** (Update existing)
```csharp
// Add to existing ModelBuilderExt.cs

public static class EntityRegisterV2
{
    public static void RegisterV2Entities(this ModelBuilder builder)
    {
        // Coin System
        builder.Entity<EntityCoinTransaction>();
        builder.Entity<EntityCoinBalance>();
        
        // Partner System
        builder.Entity<EntityPartnerCenter>();
        builder.Entity<EntityReferralCode>();
        builder.Entity<EntityCommissionTransaction>();
        
        // Content System
        builder.Entity<EntityCourse>();
        builder.Entity<EntityExam>();
        
        // Learning System
        builder.Entity<EntityEnrollment>();
        builder.Entity<EntityExamSubmission>();
        
        // Configure unique constraints
        builder.Entity<EntityReferralCode>()
            .HasIndex(r => r.Code)
            .IsUnique();
            
        builder.Entity<EntityPartnerCenter>()
            .HasIndex(p => p.Email)
            .IsUnique();
            
        builder.Entity<EntityCoinBalance>()
            .HasIndex(c => c.UserId)
            .IsUnique();
    }
}
```

**Phong (System Architect):**
- [ ] Review tất cả entities
- [ ] Validate relationships và constraints
- [ ] Document database schema decisions
- [ ] Design indexes strategy

**Cường (Frontend Developer):**
- [ ] Tạo DTOs cho API responses
- [ ] Design UI wireframes cho Coin management
- [ ] Design UI wireframes cho Partner Portal

---

#### Ngày 6-7 (02-03/12): Database Migrations & Testing

**Kiên (Backend Developer):**
- [ ] Tạo EF Core migrations cho tất cả entities
  ```bash
  cd src/SLK.TryEdu.Db
  dotnet ef migrations add InitialV2Entities
  ```
- [ ] Test migrations trên local PostgreSQL
- [ ] Seed initial data (admin user, default settings)
- [ ] Document migration process

**Test Data Seeds:**
```csharp
// File: SLK.TryEdu.Db/Migrations/SeedData.cs
public static class SeedDataV2
{
    public static void SeedInitialData(DbPostgresContext context)
    {
        // Seed default coin exchange rate
        // Seed bronze tier commission rate
        // Seed sample courses
        // Seed sample exams
    }
}
```

---

### 🗓️ Tuần 2: Core Authentication & User Management (04-10/12)

#### Ngày 8-10 (04-06/12): User Authentication Extension

**Kiên (Backend Developer) - Priority Task:**

##### 1. Extend User Entity với Roles
**File: `SLK.TryEdu.ModuleUserCore/Entities/EntityUserRole.cs`**
```csharp
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SLK.TryEdu.Abstract;

namespace SLK.TryEdu.ModuleUserCore;

[Table("USER_ROLES")]
public class EntityUserRole : EntityBase
{
    [Display(Name = "User ID")]
    [Required]
    public int UserId { get; set; }
    
    [Display(Name = "Role")]
    [Required]
    [MaxLength(50)]
    public string Role { get; set; } // Student, Teacher, Admin, Accountant, Partner
    
    [Display(Name = "Kích hoạt")]
    public bool IsActive { get; set; } = true;
    
    // Navigation property
    [ForeignKey("UserId")]
    public virtual EntityUser User { get; set; }
}
```

##### 2. Authentication Service
**File: `SLK.TryEdu.ModuleUser/Services/AuthService.cs`**
```csharp
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using SLK.TryEdu.Abstract;
using SLK.TryEdu.Base;
using SLK.TryEdu.ModuleUserCore;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace SLK.TryEdu.ModuleUser;

public class AuthService : MyServiceBase, IAuthService
{
    private readonly ILogger<AuthService> _log;

    public AuthService(IMyContext ctx, ILogger<AuthService> logger) : base(ctx)
    {
        _log = logger;
    }

    public async Task<ResultOf<AuthResponseDto>> Register(RegisterDto dto)
    {
        try
        {
            // Check if email exists
            var existingUser = await _ctx.Repo<EntityUser>()
                .Query(u => u.Email == dto.Email)
                .FirstOrDefaultAsync();
                
            if (existingUser != null)
                return ResultOf<AuthResponseDto>.Error("Email đã được sử dụng!");

            // Create user
            var user = new EntityUser
            {
                Email = dto.Email,
                PasswordHash = HashPassword(dto.Password),
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Phone = dto.Phone,
                IsActive = true,
                IsVerified = false
            };
            
            await _ctx.Repo<EntityUser>().Insert(user);

            // Create role
            var userRole = new EntityUserRole
            {
                UserId = user.Id,
                Role = dto.Role ?? "Student", // Default to Student
                IsActive = true
            };
            
            await _ctx.Repo<EntityUserRole>().Insert(userRole);

            // Create coin balance for students
            if (userRole.Role == "Student")
            {
                var coinBalance = new EntityCoinBalance
                {
                    UserId = user.Id,
                    AvailableCoins = 0,
                    UsedCoins = 0,
                    TotalCoins = 0
                };
                
                await _ctx.Repo<EntityCoinBalance>().Insert(coinBalance);
            }

            var response = new AuthResponseDto
            {
                UserId = user.Id,
                Email = user.Email,
                FullName = user.FullName,
                Role = userRole.Role,
                Token = GenerateJwtToken(user, userRole.Role)
            };

            return ResultOf<AuthResponseDto>.Ok(response);
        }
        catch (Exception ex)
        {
            _log.LogError($"Register error: {ex.Message}");
            return ResultOf<AuthResponseDto>.Error("Đã có lỗi xảy ra!");
        }
    }

    public async Task<ResultOf<AuthResponseDto>> Login(LoginDto dto)
    {
        try
        {
            var user = await _ctx.Repo<EntityUser>()
                .Query(u => u.Email == dto.Email)
                .FirstOrDefaultAsync();
                
            if (user == null)
                return ResultOf<AuthResponseDto>.Error("Email hoặc mật khẩu không đúng!");

            if (!VerifyPassword(dto.Password, user.PasswordHash))
                return ResultOf<AuthResponseDto>.Error("Email hoặc mật khẩu không đúng!");

            if (!user.IsActive)
                return ResultOf<AuthResponseDto>.Error("Tài khoản đã bị khóa!");

            // Get user role
            var userRole = await _ctx.Repo<EntityUserRole>()
                .Query(ur => ur.UserId == user.Id && ur.IsActive)
                .FirstOrDefaultAsync();
                
            if (userRole == null)
                return ResultOf<AuthResponseDto>.Error("Tài khoản chưa được gán quyền!");

            // Update last login
            user.LastLogin = DateTime.UtcNow;
            await _ctx.Repo<EntityUser>().Update(user);

            var response = new AuthResponseDto
            {
                UserId = user.Id,
                Email = user.Email,
                FullName = user.FullName,
                Role = userRole.Role,
                Token = GenerateJwtToken(user, userRole.Role)
            };

            return ResultOf<AuthResponseDto>.Ok(response);
        }
        catch (Exception ex)
        {
            _log.LogError($"Login error: {ex.Message}");
            return ResultOf<AuthResponseDto>.Error("Đã có lỗi xảy ra!");
        }
    }

    private string HashPassword(string password)
    {
        using var sha256 = SHA256.Create();
        var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
        return Convert.ToBase64String(hashedBytes);
    }

    private bool VerifyPassword(string password, string hash)
    {
        var passwordHash = HashPassword(password);
        return passwordHash == hash;
    }

    private string GenerateJwtToken(EntityUser user, string role)
    {
        // TODO: Implement JWT token generation
        // Use System.IdentityModel.Tokens.Jwt
        return "jwt_token_placeholder";
    }
}
```

##### 3. DTOs
**File: `SLK.TryEdu.ModuleUserCore/Models/RegisterDto.cs`**
```csharp
using System.ComponentModel.DataAnnotations;

namespace SLK.TryEdu.ModuleUserCore;

public class RegisterDto
{
    [Required(ErrorMessage = "Email không được để trống!")]
    [EmailAddress(ErrorMessage = "Địa chỉ email không hợp lệ!")]
    public string Email { get; set; }
    
    [Required(ErrorMessage = "Mật khẩu không được để trống!")]
    [MinLength(6, ErrorMessage = "Mật khẩu phải có ít nhất 6 ký tự!")]
    public string Password { get; set; }
    
    [Required(ErrorMessage = "Xác nhận mật khẩu không được để trống!")]
    [Compare("Password", ErrorMessage = "Mật khẩu xác nhận không khớp!")]
    public string ConfirmPassword { get; set; }
    
    [Required(ErrorMessage = "Tên không được để trống!")]
    public string FirstName { get; set; }
    
    [Required(ErrorMessage = "Họ không được để trống!")]
    public string LastName { get; set; }
    
    public string Phone { get; set; }
    
    public string Role { get; set; } = "Student";
}

public class LoginDto
{
    [Required(ErrorMessage = "Email không được để trống!")]
    [EmailAddress(ErrorMessage = "Địa chỉ email không hợp lệ!")]
    public string Email { get; set; }
    
    [Required(ErrorMessage = "Mật khẩu không được để trống!")]
    public string Password { get; set; }
}

public class AuthResponseDto
{
    public int UserId { get; set; }
    public string Email { get; set; }
    public string FullName { get; set; }
    public string Role { get; set; }
    public string Token { get; set; }
}
```

**Cường (Frontend Developer):**
- [ ] Tạo Login/Register UI components
- [ ] Implement form validation
- [ ] Integrate với AuthService API
- [ ] Setup JWT token storage (localStorage)

---

#### Ngày 11-12 (07-08/12): Partner Registration Flow

**Kiên (Backend Developer):**

**File: `SLK.TryEdu.ModulePartner/Services/PartnerService.cs`**
```csharp
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using SLK.TryEdu.Abstract;
using SLK.TryEdu.Base;
using SLK.TryEdu.ModulePartnerCore;
using Microsoft.EntityFrameworkCore;

namespace SLK.TryEdu.ModulePartner;

public class PartnerService : MyServiceBase, IPartnerService
{
    private readonly ILogger<PartnerService> _log;

    public PartnerService(IMyContext ctx, ILogger<PartnerService> logger) : base(ctx)
    {
        _log = logger;
    }

    public async Task<Result> RegisterPartner(PartnerRegistrationDto dto)
    {
        try
        {
            // Check if email exists
            var existingPartner = await _ctx.Repo<EntityPartnerCenter>()
                .Query(p => p.Email == dto.Email)
                .FirstOrDefaultAsync();
                
            if (existingPartner != null)
                return Result.Error("Email đã được sử dụng!");

            // Create partner center
            var partner = new EntityPartnerCenter
            {
                Name = dto.Name,
                ContactPerson = dto.ContactPerson,
                Email = dto.Email,
                Phone = dto.Phone,
                Address = dto.Address,
                LogoUrl = dto.LogoUrl,
                BusinessLicenseUrl = dto.BusinessLicenseUrl,
                Description = dto.Description,
                CommissionRate = 5.00M, // Default Bronze
                Tier = "Bronze",
                Status = "Pending"
            };
            
            await _ctx.Repo<EntityPartnerCenter>().Insert(partner);

            // TODO: Send email notification to admin
            // TODO: Send confirmation email to partner

            return Result.Ok("Đăng ký thành công! Vui lòng chờ admin phê duyệt.");
        }
        catch (Exception ex)
        {
            _log.LogError($"Register partner error: {ex.Message}");
            return Result.Error("Đã có lỗi xảy ra!");
        }
    }

    public async Task<Result> ApprovePartner(int partnerId, int adminUserId)
    {
        try
        {
            var partner = await _ctx.Repo<EntityPartnerCenter>()
                .Query(p => p.Id == partnerId)
                .FirstOrDefaultAsync();
                
            if (partner == null)
                return Result.Error("Không tìm thấy trung tâm!");

            partner.Status = "Active";
            partner.ApprovedAt = DateTime.UtcNow;
            partner.ApprovedBy = adminUserId;
            
            await _ctx.Repo<EntityPartnerCenter>().Update(partner);

            // Create default referral code
            var defaultCode = new EntityReferralCode
            {
                PartnerCenterId = partner.Id,
                Code = GenerateDefaultCode(partner.Name),
                Name = "Mã mặc định",
                DiscountPercentage = 10.00M,
                IsActive = true
            };
            
            await _ctx.Repo<EntityReferralCode>().Insert(defaultCode);

            // TODO: Send approval email with default code

            return Result.Ok("Phê duyệt thành công!");
        }
        catch (Exception ex)
        {
            _log.LogError($"Approve partner error: {ex.Message}");
            return Result.Error("Đã có lỗi xảy ra!");
        }
    }

    private string GenerateDefaultCode(string partnerName)
    {
        // Generate code from partner name + random string
        var prefix = string.Join("", partnerName.Split(' ')
            .Select(w => w.FirstOrDefault()))
            .ToUpper()
            .Substring(0, Math.Min(3, partnerName.Length));
            
        var random = Guid.NewGuid().ToString("N").Substring(0, 5).ToUpper();
        return $"{prefix}{random}";
    }
}
```

**Cường (Frontend Developer):**
- [ ] Tạo Partner Registration form
- [ ] Implement file upload (logo, business license)
- [ ] Tạo Admin approval interface
- [ ] Partner dashboard layout

---

#### Ngày 13-14 (09-10/12): Testing & Bug Fixes

**Toàn bộ team:**
- [ ] Test authentication flows
- [ ] Test partner registration
- [ ] Fix bugs
- [ ] Code review
- [ ] Update documentation

---

## TUẦN 3-4: COIN SYSTEM & PAYMENT (11-24/12) - 14 NGÀY

### 🗓️ Tuần 3: Coin Transaction System (11-17/12)

#### Ngày 15-17 (11-13/12): Coin Service Implementation

**Kiên (Backend Developer):**

**File: `SLK.TryEdu.ModuleCoin/Services/CoinService.cs`**
```csharp
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using SLK.TryEdu.Abstract;
using SLK.TryEdu.Base;
using SLK.TryEdu.ModuleCoinCore;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace SLK.TryEdu.ModuleCoin;

public class CoinService : MyServiceBase, ICoinService
{
    private readonly ILogger<CoinService> _log;
    private const decimal DEFAULT_EXCHANGE_RATE = 1.0M; // 1 VNĐ = 1 Coin

    public CoinService(IMyContext ctx, ILogger<CoinService> logger) : base(ctx)
    {
        _log = logger;
    }

    public async Task<ResultOf<CoinPurchaseResponseDto>> PurchaseCoins(CoinPurchaseDto dto)
    {
        try
        {
            // Validate referral code if provided
            EntityReferralCode referralCode = null;
            decimal bonusPercentage = 0;
            int bonusCoins = 0;
            
            if (!string.IsNullOrEmpty(dto.ReferralCode))
            {
                var codeValidation = await ValidateReferralCode(dto.ReferralCode, "CoinPurchase");
                if (!codeValidation.IsSuccess)
                    return ResultOf<CoinPurchaseResponseDto>.Error(codeValidation.Message);
                    
                referralCode = codeValidation.Data;
                bonusPercentage = referralCode.DiscountPercentage ?? 0;
                bonusCoins = referralCode.DiscountCoins ?? 0;
            }

            // Calculate coins
            int baseCoins = (int)(dto.Amount * DEFAULT_EXCHANGE_RATE);
            int bonusFromPercentage = (int)(baseCoins * bonusPercentage / 100);
            int totalCoins = baseCoins + bonusFromPercentage + bonusCoins;

            // Create transaction
            var transaction = new EntityCoinTransaction
            {
                UserId = dto.UserId,
                Amount = dto.Amount,
                CoinsReceived = totalCoins,
                ExchangeRate = DEFAULT_EXCHANGE_RATE,
                PaymentMethod = dto.PaymentMethod,
                ReferralCodeId = referralCode?.Id,
                Status = "Pending",
                TransactionType = "Purchase",
                Description = $"Nạp {dto.Amount:N0} VNĐ, nhận {totalCoins} coin"
            };
            
            await _ctx.Repo<EntityCoinTransaction>().Insert(transaction);

            // TODO: Integrate with payment gateway (VNPay, MoMo)
            // For now, assume payment success
            transaction.Status = "Success";
            await _ctx.Repo<EntityCoinTransaction>().Update(transaction);

            // Update coin balance
            var balance = await _ctx.Repo<EntityCoinBalance>()
                .Query(b => b.UserId == dto.UserId)
                .FirstOrDefaultAsync();
                
            if (balance == null)
            {
                balance = new EntityCoinBalance
                {
                    UserId = dto.UserId,
                    AvailableCoins = totalCoins,
                    UsedCoins = 0,
                    TotalCoins = totalCoins
                };
                await _ctx.Repo<EntityCoinBalance>().Insert(balance);
            }
            else
            {
                balance.AvailableCoins += totalCoins;
                balance.TotalCoins += totalCoins;
                balance.LastUpdated = DateTime.UtcNow;
                await _ctx.Repo<EntityCoinBalance>().Update(balance);
            }

            // Calculate commission if referral code used
            if (referralCode != null)
            {
                await CalculateCommission(
                    referralCode.PartnerCenterId,
                    dto.UserId,
                    referralCode.Id,
                    dto.Amount,
                    "CoinPurchase"
                );
                
                // Update referral code usage
                referralCode.UsageCount++;
                await _ctx.Repo<EntityReferralCode>().Update(referralCode);
            }

            var response = new CoinPurchaseResponseDto
            {
                TransactionId = transaction.Id,
                Amount = dto.Amount,
                BaseCoins = baseCoins,
                BonusCoins = bonusFromPercentage + bonusCoins,
                TotalCoins = totalCoins,
                NewBalance = balance.AvailableCoins
            };

            return ResultOf<CoinPurchaseResponseDto>.Ok(response);
        }
        catch (Exception ex)
        {
            _log.LogError($"Purchase coins error: {ex.Message}");
            return ResultOf<CoinPurchaseResponseDto>.Error("Đã có lỗi xảy ra!");
        }
    }

    public async Task<ResultOf<CoinBalanceDto>> GetBalance(int userId)
    {
        try
        {
            var balance = await _ctx.Repo<EntityCoinBalance>()
                .Query(b => b.UserId == userId)
                .FirstOrDefaultAsync();
                
            if (balance == null)
            {
                return ResultOf<CoinBalanceDto>.Ok(new CoinBalanceDto
                {
                    AvailableCoins = 0,
                    UsedCoins = 0,
                    TotalCoins = 0
                });
            }

            var dto = new CoinBalanceDto
            {
                AvailableCoins = balance.AvailableCoins,
                UsedCoins = balance.UsedCoins,
                TotalCoins = balance.TotalCoins,
                LastUpdated = balance.LastUpdated
            };

            return ResultOf<CoinBalanceDto>.Ok(dto);
        }
        catch (Exception ex)
        {
            _log.LogError($"Get balance error: {ex.Message}");
            return ResultOf<CoinBalanceDto>.Error("Đã có lỗi xảy ra!");
        }
    }

    public async Task<Result> UseCoins(UseCoinDto dto)
    {
        try
        {
            var balance = await _ctx.Repo<EntityCoinBalance>()
                .Query(b => b.UserId == dto.UserId)
                .FirstOrDefaultAsync();
                
            if (balance == null || balance.AvailableCoins < dto.CoinsToUse)
                return Result.Error("Số coin không đủ!");

            // Create transaction
            var transaction = new EntityCoinTransaction
            {
                UserId = dto.UserId,
                Amount = 0,
                CoinsReceived = -dto.CoinsToUse,
                ExchangeRate = 0,
                TransactionType = "Usage",
                Status = "Success",
                Description = dto.Description
            };
            
            await _ctx.Repo<EntityCoinTransaction>().Insert(transaction);

            // Update balance
            balance.AvailableCoins -= dto.CoinsToUse;
            balance.UsedCoins += dto.CoinsToUse;
            balance.LastUpdated = DateTime.UtcNow;
            await _ctx.Repo<EntityCoinBalance>().Update(balance);

            return Result.Ok();
        }
        catch (Exception ex)
        {
            _log.LogError($"Use coins error: {ex.Message}");
            return Result.Error("Đã có lỗi xảy ra!");
        }
    }

    private async Task<ResultOf<EntityReferralCode>> ValidateReferralCode(
        string code, 
        string applicableFor)
    {
        var referralCode = await _ctx.Repo<EntityReferralCode>()
            .Query(r => r.Code == code && r.IsActive)
            .Include(r => r.PartnerCenter)
            .FirstOrDefaultAsync();
            
        if (referralCode == null)
            return ResultOf<EntityReferralCode>.Error("Mã giới thiệu không tồn tại!");
            
        if (referralCode.PartnerCenter.Status != "Active")
            return ResultOf<EntityReferralCode>.Error("Trung tâm đã bị tạm ngưng!");
            
        if (referralCode.ExpiryDate.HasValue && referralCode.ExpiryDate < DateTime.UtcNow)
            return ResultOf<EntityReferralCode>.Error("Mã giới thiệu đã hết hạn!");
            
        if (referralCode.MaxUsage.HasValue && referralCode.UsageCount >= referralCode.MaxUsage)
            return ResultOf<EntityReferralCode>.Error("Mã giới thiệu đã hết lượt sử dụng!");
            
        if (referralCode.ApplicableFor != "All" && referralCode.ApplicableFor != applicableFor)
            return ResultOf<EntityReferralCode>.Error("Mã giới thiệu không áp dụng cho loại giao dịch này!");
            
        return ResultOf<EntityReferralCode>.Ok(referralCode);
    }

    private async Task CalculateCommission(
        int partnerCenterId,
        int userId,
        int referralCodeId,
        decimal transactionAmount,
        string transactionType)
    {
        try
        {
            var partner = await _ctx.Repo<EntityPartnerCenter>()
                .Query(p => p.Id == partnerCenterId)
                .FirstOrDefaultAsync();
                
            if (partner == null) return;

            var commissionRate = partner.CommissionRate;
            var commissionAmount = transactionAmount * commissionRate / 100;

            var commission = new EntityCommissionTransaction
            {
                PartnerCenterId = partnerCenterId,
                UserId = userId,
                ReferralCodeId = referralCodeId,
                TransactionAmount = transactionAmount,
                CommissionAmount = commissionAmount,
                CommissionRate = commissionRate,
                TransactionType = transactionType,
                Status = "Pending"
            };
            
            await _ctx.Repo<EntityCommissionTransaction>().Insert(commission);
            
            _log.LogInformation($"Commission calculated: {commissionAmount:N0} VNĐ for partner {partnerCenterId}");
        }
        catch (Exception ex)
        {
            _log.LogError($"Calculate commission error: {ex.Message}");
        }
    }
}
```

**Cường (Frontend Developer):**
- [ ] Coin purchase UI
- [ ] Coin balance display widget
- [ ] Transaction history table
- [ ] Referral code input field

---

#### Ngày 18-19 (14-15/12): Referral Code Management

**Kiên (Backend Developer):**

**File: `SLK.TryEdu.ModulePartner/Services/ReferralCodeService.cs`**
```csharp
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using SLK.TryEdu.Abstract;
using SLK.TryEdu.Base;
using SLK.TryEdu.ModulePartnerCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace SLK.TryEdu.ModulePartner;

public class ReferralCodeService : MyServiceBase, IReferralCodeService
{
    private readonly ILogger<ReferralCodeService> _log;

    public ReferralCodeService(IMyContext ctx, ILogger<ReferralCodeService> logger) : base(ctx)
    {
        _log = logger;
    }

    public async Task<ResultOf<ReferralCodeDto>> CreateCode(CreateReferralCodeDto dto)
    {
        try
        {
            // Check if code already exists
            var existingCode = await _ctx.Repo<EntityReferralCode>()
                .Query(r => r.Code == dto.Code)
                .FirstOrDefaultAsync();
                
            if (existingCode != null)
                return ResultOf<ReferralCodeDto>.Error("Mã giới thiệu đã tồn tại!");

            // Verify partner exists and is active
            var partner = await _ctx.Repo<EntityPartnerCenter>()
                .Query(p => p.Id == dto.PartnerCenterId && p.Status == "Active")
                .FirstOrDefaultAsync();
                
            if (partner == null)
                return ResultOf<ReferralCodeDto>.Error("Trung tâm không tồn tại hoặc chưa được kích hoạt!");

            var referralCode = new EntityReferralCode
            {
                PartnerCenterId = dto.PartnerCenterId,
                Code = dto.Code.ToUpper(),
                Name = dto.Name,
                DiscountPercentage = dto.DiscountPercentage,
                DiscountCoins = dto.DiscountCoins,
                IsActive = true,
                ExpiryDate = dto.ExpiryDate,
                MaxUsage = dto.MaxUsage,
                ApplicableFor = dto.ApplicableFor ?? "All",
                UsageCount = 0
            };
            
            await _ctx.Repo<EntityReferralCode>().Insert(referralCode);

            var response = new ReferralCodeDto
            {
                Id = referralCode.Id,
                Code = referralCode.Code,
                Name = referralCode.Name,
                DiscountPercentage = referralCode.DiscountPercentage,
                DiscountCoins = referralCode.DiscountCoins,
                IsActive = referralCode.IsActive,
                ExpiryDate = referralCode.ExpiryDate,
                UsageCount = referralCode.UsageCount,
                MaxUsage = referralCode.MaxUsage,
                ApplicableFor = referralCode.ApplicableFor
            };

            return ResultOf<ReferralCodeDto>.Ok(response);
        }
        catch (Exception ex)
        {
            _log.LogError($"Create referral code error: {ex.Message}");
            return ResultOf<ReferralCodeDto>.Error("Đã có lỗi xảy ra!");
        }
    }

    public async Task<ResultsOf<ReferralCodeDto>> GetPartnerCodes(int partnerCenterId)
    {
        try
        {
            var codes = await _ctx.Repo<EntityReferralCode>()
                .Query(r => r.PartnerCenterId == partnerCenterId)
                .OrderByDescending(r => r.DateCreated)
                .ToListAsync();

            var dtos = codes.Select(r => new ReferralCodeDto
            {
                Id = r.Id,
                Code = r.Code,
                Name = r.Name,
                DiscountPercentage = r.DiscountPercentage,
                DiscountCoins = r.DiscountCoins,
                IsActive = r.IsActive,
                ExpiryDate = r.ExpiryDate,
                UsageCount = r.UsageCount,
                MaxUsage = r.MaxUsage,
                ApplicableFor = r.ApplicableFor,
                DateCreated = r.DateCreated
            }).ToList();

            return ResultsOf<ReferralCodeDto>.Ok(dtos);
        }
        catch (Exception ex)
        {
            _log.LogError($"Get partner codes error: {ex.Message}");
            return ResultsOf<ReferralCodeDto>.Error("Đã có lỗi xảy ra!");
        }
    }

    public async Task<Result> ToggleCodeStatus(int codeId, bool isActive)
    {
        try
        {
            var code = await _ctx.Repo<EntityReferralCode>()
                .Query(r => r.Id == codeId)
                .FirstOrDefaultAsync();
                
            if (code == null)
                return Result.Error("Mã giới thiệu không tồn tại!");

            code.IsActive = isActive;
            await _ctx.Repo<EntityReferralCode>().Update(code);

            return Result.Ok();
        }
        catch (Exception ex)
        {
            _log.LogError($"Toggle code status error: {ex.Message}");
            return Result.Error("Đã có lỗi xảy ra!");
        }
    }
}
```

**Cường (Frontend Developer):**
- [ ] Create referral code form
- [ ] Referral code list table
- [ ] Code statistics display
- [ ] Toggle active/inactive button

---

#### Ngày 20-21 (16-17/12): Commission Dashboard

**Kiên (Backend Developer):**

**File: `SLK.TryEdu.ModulePartner/Services/CommissionService.cs`**
```csharp
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using SLK.TryEdu.Abstract;
using SLK.TryEdu.Base;
using SLK.TryEdu.ModulePartnerCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace SLK.TryEdu.ModulePartner;

public class CommissionService : MyServiceBase, ICommissionService
{
    private readonly ILogger<CommissionService> _log;

    public CommissionService(IMyContext ctx, ILogger<CommissionService> logger) : base(ctx)
    {
        _log = logger;
    }

    public async Task<ResultOf<PartnerDashboardDto>> GetPartnerDashboard(int partnerCenterId)
    {
        try
        {
            var partner = await _ctx.Repo<EntityPartnerCenter>()
                .Query(p => p.Id == partnerCenterId)
                .FirstOrDefaultAsync();
                
            if (partner == null)
                return ResultOf<PartnerDashboardDto>.Error("Trung tâm không tồn tại!");

            // Total commission
            var totalCommission = await _ctx.Repo<EntityCommissionTransaction>()
                .Query(c => c.PartnerCenterId == partnerCenterId)
                .SumAsync(c => (decimal?)c.CommissionAmount) ?? 0;

            // This month commission
            var firstDayOfMonth = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, 1);
            var thisMonthCommission = await _ctx.Repo<EntityCommissionTransaction>()
                .Query(c => c.PartnerCenterId == partnerCenterId && c.DateCreated >= firstDayOfMonth)
                .SumAsync(c => (decimal?)c.CommissionAmount) ?? 0;

            // Total students referred
            var totalStudents = await _ctx.Repo<EntityCommissionTransaction>()
                .Query(c => c.PartnerCenterId == partnerCenterId)
                .Select(c => c.UserId)
                .Distinct()
                .CountAsync();

            // Active students (students with transactions in last 30 days)
            var thirtyDaysAgo = DateTime.UtcNow.AddDays(-30);
            var activeStudents = await _ctx.Repo<EntityCommissionTransaction>()
                .Query(c => c.PartnerCenterId == partnerCenterId && c.DateCreated >= thirtyDaysAgo)
                .Select(c => c.UserId)
                .Distinct()
                .CountAsync();

            var dashboard = new PartnerDashboardDto
            {
                PartnerName = partner.Name,
                Tier = partner.Tier,
                CommissionRate = partner.CommissionRate,
                TotalCommission = totalCommission,
                ThisMonthCommission = thisMonthCommission,
                TotalStudents = totalStudents,
                ActiveStudents = activeStudents,
                Status = partner.Status
            };

            return ResultOf<PartnerDashboardDto>.Ok(dashboard);
        }
        catch (Exception ex)
        {
            _log.LogError($"Get partner dashboard error: {ex.Message}");
            return ResultOf<PartnerDashboardDto>.Error("Đã có lỗi xảy ra!");
        }
    }

    public async Task<ResultsOf<CommissionTransactionDto>> GetCommissionHistory(
        int partnerCenterId, 
        DateTime? fromDate = null, 
        DateTime? toDate = null)
    {
        try
        {
            var query = _ctx.Repo<EntityCommissionTransaction>()
                .Query(c => c.PartnerCenterId == partnerCenterId);

            if (fromDate.HasValue)
                query = query.Where(c => c.DateCreated >= fromDate);

            if (toDate.HasValue)
                query = query.Where(c => c.DateCreated <= toDate);

            var commissions = await query
                .OrderByDescending(c => c.DateCreated)
                .Include(c => c.User)
                .Include(c => c.ReferralCode)
                .ToListAsync();

            var dtos = commissions.Select(c => new CommissionTransactionDto
            {
                Id = c.Id,
                StudentName = $"{c.User.LastName} {c.User.FirstName}",
                ReferralCode = c.ReferralCode?.Code,
                TransactionAmount = c.TransactionAmount,
                CommissionAmount = c.CommissionAmount,
                CommissionRate = c.CommissionRate,
                TransactionType = c.TransactionType,
                Status = c.Status,
                DateCreated = c.DateCreated,
                PaidAt = c.PaidAt
            }).ToList();

            return ResultsOf<CommissionTransactionDto>.Ok(dtos);
        }
        catch (Exception ex)
        {
            _log.LogError($"Get commission history error: {ex.Message}");
            return ResultsOf<CommissionTransactionDto>.Error("Đã có lỗi xảy ra!");
        }
    }
}
```

**Cường (Frontend Developer):**
- [ ] Partner dashboard with KPIs
- [ ] Commission history table
- [ ] Date range filter
- [ ] Charts (commission over time)

---

### 🗓️ Tuần 4: Content & Exam System (18-24/12)

#### Ngày 22-24 (18-20/12): Course Management + Lesson Bank

**Kiên (Backend Developer):**

**File: `SLK.TryEdu.ModuleContent/Services/CourseService.cs`**
```csharp
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using SLK.TryEdu.Abstract;
using SLK.TryEdu.Base;
using SLK.TryEdu.ModuleContentCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace SLK.TryEdu.ModuleContent;

public class CourseService : MyServiceBase, ICourseService
{
    private readonly ILogger<CourseService> _log;

    public CourseService(IMyContext ctx, ILogger<CourseService> logger) : base(ctx)
    {
        _log = logger;
    }

    public async Task<ResultOf<CourseDto>> CreateCourse(CreateCourseDto dto)
    {
        // Check permission
        if (!_ctx.CheckPermission(PERMISSION.CONTENT_CREATE))
            return ResultOf<CourseDto>.Error("Bạn không có quyền tạo khóa học!");

        try
        {
            var course = new EntityCourse
            {
                Title = dto.Title,
                Slug = GenerateSlug(dto.Title),
                Description = dto.Description,
                FullDescription = dto.FullDescription,
                ThumbnailUrl = dto.ThumbnailUrl,
                Level = dto.Level,
                Category = dto.Category,
                CourseType = dto.CourseType,
                Price = dto.Price,
                Duration = dto.Duration,
                Status = "Draft",
                Tags = dto.Tags,
                StudentCount = 0
            };
            
            await _ctx.Repo<EntityCourse>().Insert(course);

            // TODO: Create MongoDB document for detailed course content

            var response = new CourseDto
            {
                Id = course.Id,
                Guid = course.Guid,
                Title = course.Title,
                Slug = course.Slug,
                Description = course.Description,
                ThumbnailUrl = course.ThumbnailUrl,
                Level = course.Level,
                Category = course.Category,
                CourseType = course.CourseType,
                Price = course.Price,
                Duration = course.Duration,
                Status = course.Status
            };

            return ResultOf<CourseDto>.Ok(response);
        }
        catch (Exception ex)
        {
            _log.LogError($"Create course error: {ex.Message}");
            return ResultOf<CourseDto>.Error("Đã có lỗi xảy ra!");
        }
    }

    public async Task<ResultsOf<CourseDto>> GetCourses(string courseType = null)
    {
        try
        {
            var query = _ctx.Repo<EntityCourse>()
                .Query(c => c.Status == "Published");

            if (!string.IsNullOrEmpty(courseType))
                query = query.Where(c => c.CourseType == courseType);

            var courses = await query
                .OrderByDescending(c => c.DateCreated)
                .ToListAsync();

            var dtos = courses.Select(c => new CourseDto
            {
                Id = c.Id,
                Guid = c.Guid,
                Title = c.Title,
                Slug = c.Slug,
                Description = c.Description,
                ThumbnailUrl = c.ThumbnailUrl,
                Level = c.Level,
                Category = c.Category,
                CourseType = c.CourseType,
                Price = c.Price,
                Duration = c.Duration,
                StudentCount = c.StudentCount,
                AverageRating = c.AverageRating,
                Status = c.Status
            }).ToList();

            return ResultsOf<CourseDto>.Ok(dtos);
        }
        catch (Exception ex)
        {
            _log.LogError($"Get courses error: {ex.Message}");
            return ResultsOf<CourseDto>.Error("Đã có lỗi xảy ra!");
        }
    }

    private string GenerateSlug(string title)
    {
        // Simple slug generation
        return title.ToLower()
            .Replace(" ", "-")
            .Replace(".", "")
            .Replace(",", "");
    }
}
```

**Cường (Frontend Developer):**
- [ ] Course creation form
- [ ] Course list view (grid/list)
- [ ] Course detail page
- [ ] Student course catalog

---

#### Ngày 25-26 (21-22/12): Exam Purchase with Coin

**Kiên (Backend Developer):**

**File: `SLK.TryEdu.ModuleContent/Services/ExamService.cs`**
```csharp
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using SLK.TryEdu.Abstract;
using SLK.TryEdu.Base;
using SLK.TryEdu.ModuleContentCore;
using SLK.TryEdu.ModuleCoinCore;
using SLK.TryEdu.ModuleLearningCore;
using Microsoft.EntityFrameworkCore;

namespace SLK.TryEdu.ModuleContent;

public class ExamService : MyServiceBase, IExamService
{
    private readonly ILogger<ExamService> _log;
    private readonly ICoinService _coinService;

    public ExamService(
        IMyContext ctx, 
        ILogger<ExamService> logger,
        ICoinService coinService) : base(ctx)
    {
        _log = logger;
        _coinService = coinService;
    }

    public async Task<Result> PurchaseExam(PurchaseExamDto dto)
    {
        try
        {
            // Get exam
            var exam = await _ctx.Repo<EntityExam>()
                .Query(e => e.Id == dto.ExamId && e.Status == "Published")
                .FirstOrDefaultAsync();
                
            if (exam == null)
                return Result.Error("Bài thi không tồn tại!");

            // Check if already purchased
            var existing = await _ctx.Repo<EntityExamSubmission>()
                .Query(s => s.UserId == dto.UserId && s.ExamId == dto.ExamId)
                .AnyAsync();
                
            if (existing)
                return Result.Error("Bạn đã mua bài thi này rồi!");

            // Calculate price with referral code discount
            int finalPrice = exam.Price;
            EntityReferralCode referralCode = null;
            
            if (!string.IsNullOrEmpty(dto.ReferralCode))
            {
                referralCode = await _ctx.Repo<EntityReferralCode>()
                    .Query(r => r.Code == dto.ReferralCode && r.IsActive)
                    .Include(r => r.PartnerCenter)
                    .FirstOrDefaultAsync();
                    
                if (referralCode != null && referralCode.PartnerCenter.Status == "Active")
                {
                    if (referralCode.DiscountPercentage.HasValue)
                    {
                        var discount = (int)(exam.Price * referralCode.DiscountPercentage.Value / 100);
                        finalPrice = exam.Price - discount;
                    }
                    else if (referralCode.DiscountCoins.HasValue)
                    {
                        finalPrice = Math.Max(0, exam.Price - referralCode.DiscountCoins.Value);
                    }
                }
            }

            // Deduct coins
            var useResult = await _coinService.UseCoins(new UseCoinDto
            {
                UserId = dto.UserId,
                CoinsToUse = finalPrice,
                Description = $"Mua bài thi: {exam.Title}"
            });
            
            if (!useResult.IsSuccess)
                return useResult;

            // Create enrollment/purchase record
            var submission = new EntityExamSubmission
            {
                UserId = dto.UserId,
                ExamId = dto.ExamId,
                Status = "Purchased", // Not yet submitted
                SubmittedAt = DateTime.UtcNow
            };
            
            await _ctx.Repo<EntityExamSubmission>().Insert(submission);

            // Calculate commission if referral code used
            if (referralCode != null)
            {
                var commissionAmount = finalPrice * referralCode.PartnerCenter.CommissionRate / 100;
                
                var commission = new EntityCommissionTransaction
                {
                    PartnerCenterId = referralCode.PartnerCenterId,
                    UserId = dto.UserId,
                    ReferralCodeId = referralCode.Id,
                    TransactionAmount = finalPrice,
                    CommissionAmount = commissionAmount,
                    CommissionRate = referralCode.PartnerCenter.CommissionRate,
                    TransactionType = "ExamPurchase",
                    Status = "Pending"
                };
                
                await _ctx.Repo<EntityCommissionTransaction>().Insert(commission);
                
                // Update referral code usage
                referralCode.UsageCount++;
                await _ctx.Repo<EntityReferralCode>().Update(referralCode);
            }

            return Result.Ok("Mua bài thi thành công!");
        }
        catch (Exception ex)
        {
            _log.LogError($"Purchase exam error: {ex.Message}");
            return Result.Error("Đã có lỗi xảy ra!");
        }
    }
}
```

**Cường (Frontend Developer):**
- [ ] Exam list view
- [ ] Exam purchase flow
- [ ] Referral code input during purchase
- [ ] My exams page

---

#### Ngày 27-28 (23-24/12): Testing & Integration

**Toàn bộ team:**
- [ ] Integration testing (coin → exam purchase → commission)
- [ ] Bug fixes
- [ ] Performance testing
- [ ] Security review
- [ ] Documentation update

---

## TUẦN 5: FINAL DEMO PREP (25-29/12) - 5 NGÀY

### Ngày 29-31 (25-27/12): UI/UX Polish

**Cường (Frontend Developer):**
- [ ] Polish all UI components
- [ ] Add loading states
- [ ] Add error handling
- [ ] Responsive design fixes
- [ ] Cross-browser testing

**Kiên (Backend Developer):**
- [ ] API documentation (Swagger)
- [ ] Error handling improvements
- [ ] Logging enhancements
- [ ] Performance optimization

---

### Ngày 32 (28/12): Demo Preparation

**Toàn bộ team:**
- [ ] Prepare demo data
- [ ] Prepare demo script
- [ ] Test demo flow end-to-end
- [ ] Deploy to demo environment
- [ ] Smoke testing

**Demo Flow:**
1. Student registration → Login
2. View free courses → Enroll → Watch video → Take quiz (EPIC 3)
3. Purchase coins with referral code
4. Purchase exam with coin
5. Start exam → Auto-save progress → Submit → View result (EPIC 3)
6. View learning dashboard với progress (EPIC 3)
7. View coin balance
8. Partner login → View dashboard
9. View commission from student transaction
10. Admin login → View system overview → Manage coin transactions → Manage exchange rates
11. Admin: Create question bank → Create exam template → Generate exam (US2.6, US2.8)
12. Teacher: Create lesson bank → Add to course (US2.7)
13. Teacher: View pending gradings → Grade Writing/Speaking → Submit feedback (EPIC 4)
14. Partner: View referred students → View student activity → Send notification (US8.4)
15. Student: Purchase premium course với coin (US2.2)

---

### Ngày 33 (29/12): DEMO DAY 🎉

**Agenda:**
- 9:00 AM: Final system check
- 10:00 AM: Demo presentation
- 11:00 AM: Q&A
- 12:00 PM: Feedback collection
- 2:00 PM: Sprint retrospective
- 3:00 PM: Planning cho Phase 2

---

## 📊 PHASE 2: OFFICIAL RELEASE (30/12 - 26/01) - 28 NGÀY

### Objectives
- Advanced features implementation
- AI integration
- Mobile app (Flutter)
- Performance optimization
- Security hardening
- Production deployment

*(Chi tiết sẽ được cập nhật sau DEMO)*

---

## 🎯 ACCEPTANCE CRITERIA CHO DEMO

### Must Have (P0)
- [x] User registration/login (Student, Teacher, Admin, Partner)
- [x] Coin purchase system
- [x] Referral code system
- [x] Commission calculation
- [x] Course browsing (free courses)
- [x] Course enrollment và learning (EPIC 3 - US3.1)
- [x] Exam purchase with coin
- [x] Exam catalog với filters và search
- [x] Exam detail page với preview
- [x] My exams page
- [x] Exam taking interface với timer và auto-save (EPIC 3 - US3.2):
  - [x] Exam start page với instructions
  - [x] Timer countdown
  - [x] Section navigation (Reading, Listening, Writing, Speaking)
  - [x] Question navigation sidebar
  - [x] Reading section UI
  - [x] Listening section UI với audio player
  - [x] Writing section UI với rich text editor
  - [x] Speaking section UI với recording
  - [x] Auto-save functionality
  - [x] Submit exam flow
  - [x] Exam result display page
- [x] Learning dashboard với progress tracking (EPIC 3 - US3.3)
- [x] Question bank management (EPIC 2 - US2.6)
- [x] Lesson bank management (EPIC 2 - US2.7)
- [x] Exam template system (EPIC 2 - US2.8)
- [x] Purchase premium courses với coin (US2.2)
- [x] Teacher grading system - cơ bản (EPIC 4 - US4.1)
- [x] Partner dashboard
- [x] Partner student management (US8.4)
- [x] Admin coin management (US9.5, US9.6)
- [x] Admin approval workflow
- [x] User profile với avatar upload (US1.1)
- [x] Remember me và Forgot password (US1.3)
- [x] Teacher registration với CV/chứng chỉ upload (US1.2)
- [x] Course preview trước khi mua (US2.2)
- [x] Auto-upgrade partner tier (US9.4)
- [x] Admin partner management - configure commission (US8.5)
- [x] Admin grading management - statistics (US4.2)
- [x] Email verification system (US1.1)
- [x] Admin user management - lock/unlock, roles, permissions (US1.4)
- [x] Course statistics - enrolled students count (US2.5)
- [x] Student view teacher feedback (US4.1)
- [x] Teacher earning dashboard và reports (EPIC 4)
- [x] Admin system dashboard với KPIs (US7.1)
- [x] Predefined coin purchase amounts (50K, 100K, 200K, 500K, 1M) (US9.1)
- [x] Coin wallet management (US9.1)
- [x] Top referral codes display (US8.3)
- [x] Payment schedule view (US8.3)
- [x] Download commission invoice (US8.3)
- [x] Special exchange rate for centers (US9.6)
- [x] AI Analytics trong admin dashboard (US7.1)
- [x] Accountant payment management - refund coin, failed transactions (US5.1)
- [x] Content approval system - approve/reject courses, exams (US7.2)
- [x] Content categories management (US7.2)
- [x] Support system - FAQ và help videos (US6.1)

### Should Have (P1)
- [ ] Email notifications
- [ ] Payment gateway integration (VNPay test)
- [ ] Course enrollment tracking
- [ ] Basic reporting
- [ ] Bank reconciliation (basic) (US5.1)
- [ ] FAQ search functionality (US6.1)

### Nice to Have (P2)
- [ ] Charts và visualizations
- [ ] Mobile responsive (basic)
- [ ] Export reports

---

## 📈 DAILY TRACKING

### Daily Standup Format
**Time**: 9:00 AM daily
**Duration**: 15 minutes

**Questions:**
1. What did you complete yesterday?
2. What will you work on today?
3. Any blockers?
4. Coin system progress?
5. Partner system progress?

---

## 🚨 RISKS & MITIGATION

### Technical Risks

#### Risk 1: Payment Gateway Integration Delay
- **Impact**: High
- **Probability**: Medium
- **Mitigation**: Start with mock payment, integrate real gateway in Phase 2

#### Risk 2: MongoDB Setup Complexity
- **Impact**: Medium
- **Probability**: Low
- **Mitigation**: Use PostgreSQL JSONB as fallback

#### Risk 3: Performance Issues
- **Impact**: Medium
- **Probability**: Medium
- **Mitigation**: Implement caching from Day 1, Redis setup early

### Schedule Risks

#### Risk 1: Feature Creep
- **Impact**: High
- **Probability**: High
- **Mitigation**: Strict scope control, prioritize P0 features only

#### Risk 2: Unexpected Bugs
- **Impact**: Medium
- **Probability**: High
- **Mitigation**: Buffer time in Week 5, daily testing

---

## 📚 DOCUMENTATION REQUIREMENTS

### Technical Documentation
- [ ] API documentation (Swagger)
- [ ] Database schema documentation
- [ ] Deployment guide
- [ ] Environment setup guide

### User Documentation
- [ ] Student user guide
- [ ] Partner portal guide
- [ ] Admin manual

---

## 🔧 DEVELOPMENT STANDARDS

### Code Standards
- Follow C# coding conventions
- Use async/await for all I/O operations
- Implement proper error handling with try-catch
- Log all errors with meaningful messages
- Use dependency injection

### Git Workflow
```
main → development → feature/[feature-name]
```

### Commit Message Format
```
[Module] Brief description

- Detailed point 1
- Detailed point 2

Refs: #issue-number
```

### Code Review Process
1. Create PR từ feature branch → development
2. Phong (Architect) review architecture
3. Peer review (Kiên ↔ Cường)
4. Merge sau khi có 2 approvals

---

## 🎯 SUCCESS METRICS FOR DEMO

### Technical Metrics
- [ ] All P0 features working
- [ ] < 5 critical bugs
- [ ] API response time < 500ms
- [ ] Zero security vulnerabilities

### Business Metrics
- [ ] Demo flow completes end-to-end
- [ ] Stakeholder approval
- [ ] Clear feedback for Phase 2

---

## 📞 COMMUNICATION PLAN

### Daily
- 9:00 AM: Standup
- EOD: Progress update in Teams

### Weekly
- Monday: Sprint planning
- Friday: Sprint review + retrospective

### Ad-hoc
- Blocker: Immediate escalation to Phong
- Questions: Teams chat

---

## 🛠️ TOOLS & RESOURCES

### Development Tools
- IDE: Visual Studio 2022 / VS Code
- Database: PostgreSQL 15 + pgAdmin
- API Testing: Postman / Swagger
- Version Control: Git + GitHub

### Project Management
- Azure DevOps / Jira
- Teams for communication
- Confluence for documentation

---

## 📝 NOTES

### Important Reminders
1. **Database First**: All entities must inherit from `EntityBase`
2. **Service Pattern**: All services must inherit from `MyServiceBase`
3. **Return Types**: Use `Result`, `ResultOf<T>`, `ResultsOf<T>`
4. **Permissions**: Check permissions using `_ctx.CheckPermission()`
5. **Audit**: DbContext auto-handles audit logging
6. **UTC**: All DateTime must be UTC

### Common Pitfalls to Avoid
- ❌ Don't use `var` without clear type
- ❌ Don't forget async/await
- ❌ Don't skip validation
- ❌ Don't hardcode connection strings
- ❌ Don't commit secrets to Git

---

## ✅ DEFINITION OF DONE

A feature is "Done" when:
- [x] Code written and committed
- [x] Unit tests written (optional for MVP)
- [x] Code reviewed and approved
- [x] Tested on local environment
- [x] Documentation updated
- [x] Deployed to development environment
- [x] Smoke tested by team
- [x] Demo prepared (if user-facing)

---

## 🎉 CONCLUSION

Lộ trình này được thiết kế để team có thể:
1. ✅ **Hoàn thành DEMO vào 29/12/2025**
2. ✅ **Xây dựng foundation vững chắc cho Phase 2**
3. ✅ **Maintain code quality cao**
4. ✅ **Work efficiently với Scrum framework**

**Next Steps:**
1. Team review tài liệu này
2. Setup development environment (Day 1-2)
3. Start Sprint 1 (Day 3)

**Questions?** Contact Phong (System Architect) hoặc Nguyên (Product Owner)

---

*Document Version: 1.0*  
*Last Updated: 27/11/2025*  
*Next Review: 10/12/2025*


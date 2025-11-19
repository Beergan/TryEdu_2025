# DATABASE SCHEMA POSTGRESQL - HỆ THỐNG THI THỬ ĐA NGÔN NGỮ

## 🎯 Mô hình kinh doanh:
- **Khách hàng chính**: Các trung tâm giáo dục/thi thử
- **Sản phẩm**: Giải pháp thi thử đa ngôn ngữ (SaaS)
- **Tính năng đặc biệt**: Cấu trúc đề thi và câu hỏi tùy biến, hệ thống chấm điểm hỗn hợp (tự động + AI + examiner)
- **Hỗ trợ**: Examinee (người luyện thi) và Examiner (người đánh giá)

## 📚 Thuật ngữ chính:
- **question_bank**: Ngân hàng câu hỏi
- **exam_category**: Danh mục đề thử
- **exam_template**: Cấu trúc đề thi
- **exam_package**: Bộ đề thi (PostgreSQL + MongoDB)
- **exam_attempt**: Bài thi (PostgreSQL + MongoDB)
- **examinee**: Người luyện thi (không nhất thiết là student)
- **examiner**: Người đánh giá (không nhất thiết là teacher)
- **purchase_order**: Đơn mua
- **payment_transaction**: Giao dịch thanh toán (1 đơn mua có thể nhiều giao dịch)

## 📊 Cấu trúc Database PostgreSQL:

### **1. USER MANAGEMENT (Quản lý người dùng)**

```sql
-- Bảng chính chứa thông tin cơ bản
CREATE TABLE users (
    id SERIAL PRIMARY KEY, -- ID người dùng
    email VARCHAR(255) UNIQUE NOT NULL, -- Email đăng nhập
    password_hash VARCHAR(255) NOT NULL, -- Mật khẩu đã mã hóa
    first_name VARCHAR(100) NOT NULL, -- Tên
    last_name VARCHAR(100) NOT NULL, -- Họ
    phone VARCHAR(20), -- Số điện thoại
    address TEXT, -- Địa chỉ
    country VARCHAR(100), -- Quốc gia
    city VARCHAR(100), -- Thành phố
    role VARCHAR(20) NOT NULL CHECK (role IN ('examinee', 'examiner', 'admin', 'accountant', 'center_admin')), -- Vai trò
    is_active BOOLEAN DEFAULT true, -- Trạng thái hoạt động
    is_verified BOOLEAN DEFAULT false, -- Đã xác thực email
    email_verified_at TIMESTAMP, -- Thời gian xác thực email
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP, -- Ngày tạo
    updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP, -- Ngày cập nhật
    last_login TIMESTAMP -- Lần đăng nhập cuối
);
```

### **2. CENTER MANAGEMENT (Quản lý trung tâm)**

```sql
-- Thông tin trung tâm (khách hàng chính)
CREATE TABLE centers (
    id SERIAL PRIMARY KEY, -- ID trung tâm
    center_code VARCHAR(20) UNIQUE NOT NULL, -- Mã trung tâm
    center_name VARCHAR(255) NOT NULL, -- Tên trung tâm
    center_type VARCHAR(50) NOT NULL, -- Loại trung tâm: 'language_center', 'test_center', 'university'
    contact_person VARCHAR(255), -- Người liên hệ
    email VARCHAR(255) UNIQUE NOT NULL, -- Email trung tâm
    phone VARCHAR(20), -- Số điện thoại
    address TEXT, -- Địa chỉ
    country VARCHAR(100), -- Quốc gia
    city VARCHAR(100), -- Thành phố
    website VARCHAR(255), -- Website
    logo_url TEXT, -- URL logo
    status VARCHAR(20) DEFAULT 'active' CHECK (status IN ('active', 'suspended', 'inactive')), -- Trạng thái
    subscription_plan VARCHAR(50) DEFAULT 'basic', -- Gói dịch vụ: 'basic', 'premium', 'enterprise'
    subscription_start DATE, -- Ngày bắt đầu gói
    subscription_end DATE, -- Ngày kết thúc gói
    max_students INTEGER DEFAULT 100, -- Số học viên tối đa
    max_exams INTEGER DEFAULT 50, -- Số bài thi tối đa
    max_teachers INTEGER DEFAULT 10, -- Số giáo viên tối đa
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP, -- Ngày tạo
    updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP -- Ngày cập nhật
);

-- Người dùng của trung tâm
CREATE TABLE center_users (
    id SERIAL PRIMARY KEY, -- ID người dùng trung tâm
    center_id INTEGER REFERENCES centers(id) ON DELETE CASCADE, -- ID trung tâm
    user_id INTEGER REFERENCES users(id) ON DELETE CASCADE, -- ID người dùng
    role VARCHAR(20) NOT NULL CHECK (role IN ('admin', 'examiner', 'staff', 'examinee')), -- Vai trò trong trung tâm
    permissions JSONB, -- Quyền hạn linh hoạt theo trung tâm
    is_active BOOLEAN DEFAULT true, -- Trạng thái hoạt động
    joined_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP, -- Ngày tham gia
    UNIQUE(center_id, user_id) -- Mỗi người chỉ thuộc 1 trung tâm
);
```

### **3. MULTI-LANGUAGE SUPPORT (Hỗ trợ đa ngôn ngữ)**

```sql
-- Danh sách ngôn ngữ hỗ trợ
CREATE TABLE languages (
    id SERIAL PRIMARY KEY, -- ID ngôn ngữ
    language_code VARCHAR(10) UNIQUE NOT NULL, -- Mã ngôn ngữ: 'en', 'ko', 'zh', 'ja'
    language_name VARCHAR(100) NOT NULL, -- Tên ngôn ngữ: 'English', 'Korean', 'Chinese', 'Japanese'
    native_name VARCHAR(100) NOT NULL, -- Tên bản địa: 'English', '한국어', '中文', '日本語'
    is_active BOOLEAN DEFAULT true, -- Trạng thái hoạt động
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP -- Ngày tạo
);

-- Insert supported languages
INSERT INTO languages (language_code, language_name, native_name) VALUES
('en', 'English', 'English'),
('ko', 'Korean', '한국어'),
('zh', 'Chinese', '中文'),
('ja', 'Japanese', '日本語');

-- Danh mục đề thử
CREATE TABLE exam_categories (
    id SERIAL PRIMARY KEY, -- ID danh mục
    category_code VARCHAR(50) UNIQUE NOT NULL, -- Mã danh mục
    category_name VARCHAR(255) NOT NULL, -- Tên danh mục
    description TEXT, -- Mô tả
    language_id INTEGER REFERENCES languages(id), -- ID ngôn ngữ
    is_standard BOOLEAN DEFAULT false, -- Danh mục chuẩn như IELTS, TOEIC
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP -- Ngày tạo
);

-- Insert standard exam categories
INSERT INTO exam_categories (category_code, category_name, description, language_id, is_standard) VALUES
-- English exams
('ielts', 'IELTS', 'International English Language Testing System', 1, true),
('toeic', 'TOEIC', 'Test of English for International Communication', 1, true),
('toefl', 'TOEFL', 'Test of English as a Foreign Language', 1, true),
('cambridge', 'Cambridge', 'Cambridge English Exams', 1, true),
-- Korean exams
('topik', 'TOPIK', 'Test of Proficiency in Korean', 2, true),
('klpt', 'KLPT', 'Korean Language Proficiency Test', 2, true),
-- Chinese exams
('hsk', 'HSK', 'Hanyu Shuiping Kaoshi', 3, true),
('tocfl', 'TOCFL', 'Test of Chinese as a Foreign Language', 3, true),
-- Japanese exams
('jlpt', 'JLPT', 'Japanese Language Proficiency Test', 4, true),
('jtest', 'J-TEST', 'J-TEST Practical Japanese Test', 4, true);
```

### **4. FLEXIBLE EXAM STRUCTURE (Cấu trúc đề thi tùy biến)**

```sql
-- Bộ đề thi (exam_package) - PostgreSQL + MongoDB
CREATE TABLE exam_packages (
    id SERIAL PRIMARY KEY, -- ID bộ đề thi
    center_id INTEGER REFERENCES centers(id) ON DELETE CASCADE, -- ID trung tâm
    package_code VARCHAR(50) NOT NULL, -- Mã bộ đề thi
    package_name VARCHAR(255) NOT NULL, -- Tên bộ đề thi
    description TEXT, -- Mô tả bộ đề thi
    language_id INTEGER REFERENCES languages(id), -- ID ngôn ngữ
    category_id INTEGER REFERENCES exam_categories(id), -- ID danh mục
    level VARCHAR(10) CHECK (level IN ('A1', 'A2', 'B1', 'B2', 'C1', 'C2', 'N1', 'N2', 'N3', 'N4', 'N5')), -- Cấp độ
    duration_minutes INTEGER NOT NULL, -- Thời gian làm bài (phút)
    total_questions INTEGER DEFAULT 0, -- Tổng số câu hỏi
    passing_score INTEGER NOT NULL, -- Điểm đậu
    max_attempts INTEGER DEFAULT 1, -- Số lần làm tối đa
    is_published BOOLEAN DEFAULT false, -- Đã xuất bản
    is_public BOOLEAN DEFAULT false, -- Bộ đề thi công khai (có thể dùng bởi trung tâm khác)
    use_ai_grading BOOLEAN DEFAULT false, -- Sử dụng AI chấm điểm
    created_by INTEGER REFERENCES center_users(id), -- ID người tạo
    approved_by INTEGER REFERENCES center_users(id), -- ID người duyệt
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP, -- Ngày tạo
    published_at TIMESTAMP, -- Ngày xuất bản
    total_attempts INTEGER DEFAULT 0, -- Tổng số lần làm
    average_score DECIMAL(5,2) DEFAULT 0, -- Điểm trung bình
    
    -- JSONB columns for flexible exam structure
    exam_structure JSONB, -- Cấu trúc chi tiết bộ đề thi (tùy biến)
    sections JSONB, -- Các phần thi (Reading, Listening, Writing, Speaking)
    questions JSONB, -- Câu hỏi chi tiết (tùy biến)
    grading_criteria JSONB, -- Tiêu chí chấm điểm
    ai_config JSONB, -- Cấu hình AI chấm điểm
    instructions JSONB, -- Hướng dẫn thi (multi-language)
    
    -- MongoDB reference for detailed exam data
    mongodb_exam_id VARCHAR(50), -- ID trong MongoDB cho dữ liệu chi tiết
    
    UNIQUE(center_id, package_code) -- Mỗi trung tâm có mã bộ đề thi riêng
);

-- Template cấu trúc đề thi (tùy biến)
CREATE TABLE exam_templates (
    id SERIAL PRIMARY KEY, -- ID template
    center_id INTEGER REFERENCES centers(id) ON DELETE CASCADE, -- ID trung tâm
    template_code VARCHAR(50) NOT NULL, -- Mã template
    template_name VARCHAR(255) NOT NULL, -- Tên template
    language_id INTEGER REFERENCES languages(id), -- ID ngôn ngữ
    category_id INTEGER REFERENCES exam_categories(id), -- ID danh mục
    level VARCHAR(10) CHECK (level IN ('A1', 'A2', 'B1', 'B2', 'C1', 'C2', 'N1', 'N2', 'N3', 'N4', 'N5')), -- Cấp độ
    duration_minutes INTEGER NOT NULL, -- Thời gian làm bài (phút)
    total_questions INTEGER NOT NULL, -- Tổng số câu hỏi
    
    -- JSONB columns for flexible template structure
    structure_config JSONB, -- Cấu trúc template (tùy biến)
    section_templates JSONB, -- Template cho từng phần
    question_distribution JSONB, -- Phân bổ câu hỏi theo độ khó
    grading_criteria JSONB, -- Tiêu chí chấm điểm
    
    -- Sharing settings
    is_public BOOLEAN DEFAULT false, -- Template công khai
    is_shared BOOLEAN DEFAULT false, -- Đã chia sẻ
    shared_with_centers INTEGER[], -- Mảng ID trung tâm được chia sẻ
    
    created_by INTEGER REFERENCES center_users(id), -- ID người tạo
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP, -- Ngày tạo
    updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP, -- Ngày cập nhật
    
    UNIQUE(center_id, template_code) -- Mỗi trung tâm có mã template riêng
);
```

### **5. FLEXIBLE QUESTION BANK (Ngân hàng câu hỏi tùy biến)**

```sql
-- Ngân hàng câu hỏi (cấu trúc tùy biến)
CREATE TABLE question_bank (
    id SERIAL PRIMARY KEY, -- ID câu hỏi
    center_id INTEGER REFERENCES centers(id) ON DELETE CASCADE, -- ID trung tâm
    question_code VARCHAR(50), -- Mã câu hỏi
    question_text TEXT NOT NULL, -- Nội dung câu hỏi
    question_type VARCHAR(50) NOT NULL, -- Loại câu hỏi: 'multiple_choice', 'true_false', 'fill_blank', 'essay', 'speaking'
    language_id INTEGER REFERENCES languages(id), -- ID ngôn ngữ
    category_id INTEGER REFERENCES exam_categories(id), -- ID danh mục
    level VARCHAR(10) CHECK (level IN ('A1', 'A2', 'B1', 'B2', 'C1', 'C2', 'N1', 'N2', 'N3', 'N4', 'N5')), -- Cấp độ
    difficulty_level INTEGER CHECK (difficulty_level BETWEEN 1 AND 5), -- Mức độ khó (1-5)
    
    -- JSONB columns for flexible question structure
    question_config JSONB, -- Cấu hình linh hoạt cho các loại câu hỏi
    options JSONB, -- Tùy chọn câu trả lời (tùy biến)
    correct_answer TEXT, -- Đáp án đúng
    explanation TEXT, -- Giải thích
    tags JSONB, -- Mảng các thẻ tag
    media_files JSONB, -- File media: Audio, video, images
    
    -- AI Grading Configuration
    ai_grading_config JSONB, -- Cấu hình AI chấm điểm cho câu hỏi
    ai_model VARCHAR(100), -- AI model sử dụng
    confidence_threshold DECIMAL(3,2) DEFAULT 0.8, -- Ngưỡng tin cậy AI
    
    -- Sharing and permissions
    is_public BOOLEAN DEFAULT false, -- Có thể dùng bởi trung tâm khác
    is_shared BOOLEAN DEFAULT false, -- Đã chia sẻ với trung tâm khác
    shared_with_centers INTEGER[], -- Mảng ID trung tâm được chia sẻ
    
    created_by INTEGER REFERENCES center_users(id), -- ID người tạo
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP, -- Ngày tạo
    updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP, -- Ngày cập nhật
    
    UNIQUE(center_id, question_code) -- Mỗi trung tâm có mã câu hỏi riêng
);
```

### **6. EXAMINEE MANAGEMENT (Quản lý người luyện thi - cả ngoài và của trung tâm)**

```sql
-- Bảng chính chứa thông tin người luyện thi
CREATE TABLE examinees (
    id SERIAL PRIMARY KEY, -- ID người luyện thi
    user_id INTEGER REFERENCES users(id) ON DELETE CASCADE, -- ID người dùng
    examinee_code VARCHAR(50) UNIQUE, -- Mã người luyện thi
    examinee_type VARCHAR(20) DEFAULT 'external' CHECK (examinee_type IN ('external', 'center')), -- Loại người luyện thi: 'external' (ngoài), 'center' (của trung tâm)
    center_id INTEGER REFERENCES centers(id) ON DELETE SET NULL, -- ID trung tâm (NULL cho người luyện thi ngoài)
    enrollment_date DATE DEFAULT CURRENT_DATE, -- Ngày đăng ký
    status VARCHAR(20) DEFAULT 'active' CHECK (status IN ('active', 'inactive', 'suspended', 'graduated')), -- Trạng thái
    level VARCHAR(10) CHECK (level IN ('A1', 'A2', 'B1', 'B2', 'C1', 'C2', 'N1', 'N2', 'N3', 'N4', 'N5')), -- Cấp độ
    total_exams INTEGER DEFAULT 0, -- Tổng số bài thi đã làm
    total_spent DECIMAL(12,2) DEFAULT 0, -- Tổng số tiền đã chi
    notes TEXT, -- Ghi chú
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP, -- Ngày tạo
    updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP -- Ngày cập nhật
);

-- Thông tin bổ sung cho người luyện thi của trung tâm
CREATE TABLE center_examinees (
    id SERIAL PRIMARY KEY, -- ID người luyện thi trung tâm
    examinee_id INTEGER REFERENCES examinees(id) ON DELETE CASCADE, -- ID người luyện thi
    center_id INTEGER REFERENCES centers(id) ON DELETE CASCADE, -- ID trung tâm
    center_examinee_code VARCHAR(50) NOT NULL, -- Mã người luyện thi trong trung tâm
    enrollment_date DATE DEFAULT CURRENT_DATE, -- Ngày đăng ký
    status VARCHAR(20) DEFAULT 'active' CHECK (status IN ('active', 'inactive', 'suspended', 'graduated')), -- Trạng thái
    level VARCHAR(10) CHECK (level IN ('A1', 'A2', 'B1', 'B2', 'C1', 'C2', 'N1', 'N2', 'N3', 'N4', 'N5')), -- Cấp độ
    notes TEXT, -- Ghi chú
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP, -- Ngày tạo
    
    UNIQUE(center_id, examinee_id), -- Mỗi người luyện thi chỉ thuộc 1 trung tâm
    UNIQUE(center_id, center_examinee_code) -- Mỗi trung tâm có mã người luyện thi riêng
);
```

### **7. EXAM ATTEMPTS & AI GRADING (Lần làm bài thi và chấm điểm AI)**

```sql
-- Lần làm bài thi (hỗ trợ cả người luyện thi ngoài và của trung tâm) - PostgreSQL + MongoDB
CREATE TABLE exam_attempts (
    id SERIAL PRIMARY KEY, -- ID lần làm bài
    center_id INTEGER REFERENCES centers(id) ON DELETE CASCADE, -- ID trung tâm (NULL cho người luyện thi ngoài)
    exam_package_id INTEGER REFERENCES exam_packages(id) ON DELETE CASCADE, -- ID bộ đề thi
    examinee_id INTEGER REFERENCES examinees(id) ON DELETE CASCADE, -- ID người luyện thi
    center_examinee_id INTEGER REFERENCES center_examinees(id) ON DELETE CASCADE, -- ID người luyện thi trung tâm (NULL cho người luyện thi ngoài)
    purchased_attempt_id INTEGER REFERENCES purchased_exam_attempts(id) ON DELETE SET NULL, -- ID lượt thi đã mua (NULL cho trung tâm)
    attempt_number INTEGER DEFAULT 1, -- Số lần làm bài
    score INTEGER DEFAULT 0, -- Điểm tổng
    total_questions INTEGER DEFAULT 0, -- Tổng số câu hỏi
    correct_answers INTEGER DEFAULT 0, -- Số câu trả lời đúng
    status VARCHAR(20) DEFAULT 'in_progress' CHECK (status IN ('in_progress', 'submitted', 'graded', 'cancelled')), -- Trạng thái
    started_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP, -- Thời gian bắt đầu
    submitted_at TIMESTAMP, -- Thời gian nộp bài
    graded_by INTEGER REFERENCES center_users(id), -- ID người chấm (NULL cho người luyện thi ngoài)
    graded_at TIMESTAMP, -- Thời gian chấm bài
    
    -- JSONB columns for detailed data
    answers JSONB, -- Câu trả lời chi tiết (JSON)
    essay_responses JSONB, -- Bài essay (JSON)
    speaking_recordings JSONB, -- Ghi âm speaking (JSON)
    ai_analysis JSONB, -- Phân tích AI (JSON)
    examiner_feedback JSONB, -- Feedback từ người đánh giá (JSON)
    detailed_scores JSONB, -- Điểm chi tiết từng phần (JSON)
    
    -- System Auto Grading (for multiple choice, fill blank, etc.)
    system_auto_grading_used BOOLEAN DEFAULT true, -- Hệ thống tự động chấm trắc nghiệm
    system_auto_grading_score DECIMAL(5,2) DEFAULT 0, -- Điểm hệ thống chấm
    
    -- AI Grading (only for essay, writing, speaking) - Examinee choice
    ai_grading_used BOOLEAN DEFAULT false, -- AI chấm tự luận (người luyện thi chọn)
    ai_grading_score DECIMAL(5,2) DEFAULT 0, -- Điểm AI chấm
    ai_confidence_score DECIMAL(3,2), -- Độ tin cậy của AI (0-1)
    examinee_chose_ai BOOLEAN DEFAULT false, -- Người luyện thi đã chọn AI chấm tự luận
    
    -- Examiner Grading (only for essay, writing, speaking)
    examiner_grading_required BOOLEAN DEFAULT false, -- Cần người đánh giá chấm tự luận
    examiner_grading_completed BOOLEAN DEFAULT false, -- Người đánh giá đã chấm xong tự luận
    examiner_grading_requested BOOLEAN DEFAULT false, -- Đã gửi vào danh sách chấm thi
    
    -- Coin System Integration
    coin_cost DECIMAL(10,2) DEFAULT 0, -- Số coin đã chi cho lượt thi này
    coin_transaction_id INTEGER REFERENCES coin_transactions(id) ON DELETE SET NULL, -- ID giao dịch coin (nếu có)
    
    -- MongoDB reference for detailed attempt data
    mongodb_attempt_id VARCHAR(50), -- ID trong MongoDB cho dữ liệu chi tiết
    
    -- Constraint: Either center_examinee_id (for center examinees) or center_id IS NULL (for external examinees)
    CONSTRAINT check_examinee_type CHECK (
        (center_examinee_id IS NOT NULL AND center_id IS NOT NULL) OR 
        (center_examinee_id IS NULL AND center_id IS NULL)
    ),
    
    UNIQUE(exam_package_id, examinee_id, attempt_number) -- Mỗi người luyện thi chỉ làm 1 lần/bộ đề thi
);

-- Kết quả chấm tự động (cho tất cả loại câu hỏi)
CREATE TABLE auto_grading_results (
    id SERIAL PRIMARY KEY, -- ID kết quả chấm
    exam_attempt_id INTEGER REFERENCES exam_attempts(id) ON DELETE CASCADE, -- ID lần làm bài
    question_id INTEGER REFERENCES question_bank(id) ON DELETE CASCADE, -- ID câu hỏi
    question_type VARCHAR(50) NOT NULL, -- Loại câu hỏi: 'multiple_choice', 'true_false', 'fill_blank', 'essay', 'speaking', 'writing'
    
    -- Grading Results
    auto_score DECIMAL(5,2) NOT NULL, -- Điểm chấm
    max_score DECIMAL(5,2) NOT NULL, -- Điểm tối đa
    is_correct BOOLEAN, -- Đúng/sai (cho trắc nghiệm)
    
    -- Detailed Results
    student_answer TEXT, -- Câu trả lời của học viên
    correct_answer TEXT, -- Đáp án đúng
    explanation TEXT, -- Giải thích
    
    -- Processing Info
    processing_time INTEGER, -- Thời gian xử lý (ms)
    grading_method VARCHAR(50) NOT NULL, -- Phương pháp chấm: 'system_auto', 'ai', 'rule_based'
    confidence_score DECIMAL(3,2), -- Độ tin cậy (chỉ cho AI, 0-1)
    
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP -- Ngày tạo
);

-- Phân tích AI chi tiết (chỉ cho tự luận)
CREATE TABLE ai_analysis (
    id SERIAL PRIMARY KEY, -- ID phân tích AI
    exam_attempt_id INTEGER REFERENCES exam_attempts(id) ON DELETE CASCADE, -- ID lần làm bài
    question_id INTEGER REFERENCES question_bank(id) ON DELETE CASCADE, -- ID câu hỏi
    analysis_type VARCHAR(50) NOT NULL, -- Loại phân tích: 'essay', 'speaking', 'writing' (chỉ tự luận)
    
    -- AI Analysis Results
    ai_score DECIMAL(5,2), -- Điểm AI chấm
    confidence_score DECIMAL(3,2) CHECK (confidence_score BETWEEN 0 AND 1), -- Độ tin cậy (0-1)
    ai_feedback TEXT, -- Feedback từ AI
    ai_explanation TEXT, -- Giải thích của AI
    
    -- Detailed Analysis
    analysis_details JSONB, -- Chi tiết phân tích (JSON)
    keywords_found JSONB, -- Từ khóa tìm thấy (JSON)
    grammar_analysis JSONB, -- Phân tích ngữ pháp (JSON)
    content_analysis JSONB, -- Phân tích nội dung (JSON)
    
    -- AI Model Information
    ai_model VARCHAR(100), -- Model AI sử dụng
    model_version VARCHAR(50), -- Version của model
    processing_time INTEGER, -- Thời gian xử lý (ms)
    
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP -- Ngày tạo
);
```

### **7. GRADING SYSTEM (Hệ thống chấm điểm hỗn hợp)**

```sql
-- Danh sách chấm thi (chỉ cho người đánh giá chấm tự luận)
CREATE TABLE grading_queue (
    id SERIAL PRIMARY KEY, -- ID danh sách chấm
    exam_attempt_id INTEGER REFERENCES exam_attempts(id) ON DELETE CASCADE, -- ID lần làm bài
    question_id INTEGER REFERENCES question_bank(id) ON DELETE CASCADE, -- ID câu hỏi
    examinee_id INTEGER REFERENCES examinees(id) ON DELETE CASCADE, -- ID người luyện thi
    center_id INTEGER REFERENCES centers(id) ON DELETE CASCADE, -- ID trung tâm
    
    -- Grading Information (chỉ tự luận)
    question_type VARCHAR(50) NOT NULL CHECK (question_type IN ('essay', 'speaking', 'writing')), -- Loại câu hỏi (chỉ tự luận)
    question_text TEXT NOT NULL, -- Nội dung câu hỏi
    examinee_answer JSONB, -- Câu trả lời của người luyện thi (essay text, speaking audio, writing text)
    grading_criteria JSONB, -- Tiêu chí chấm điểm (JSON)
    
    -- Status Management
    status VARCHAR(20) DEFAULT 'pending' CHECK (status IN ('pending', 'assigned', 'in_progress', 'completed', 'cancelled')), -- Trạng thái
    priority VARCHAR(10) DEFAULT 'normal' CHECK (priority IN ('low', 'normal', 'high', 'urgent')), -- Độ ưu tiên
    
    -- Assignment
    assigned_to INTEGER REFERENCES center_users(id), -- ID người đánh giá được giao
    assigned_at TIMESTAMP, -- Thời gian giao việc
    started_at TIMESTAMP, -- Thời gian bắt đầu chấm
    completed_at TIMESTAMP, -- Thời gian hoàn thành
    
    -- Grading Results
    examiner_score DECIMAL(5,2), -- Điểm người đánh giá chấm
    examiner_feedback TEXT, -- Feedback từ người đánh giá
    grading_notes TEXT, -- Ghi chú chấm điểm
    
    -- Commission Information
    commission_amount DECIMAL(10,2) DEFAULT 0, -- Số tiền hoa hồng
    commission_rate DECIMAL(5,2) DEFAULT 0, -- Tỷ lệ hoa hồng (%)
    commission_paid BOOLEAN DEFAULT false, -- Đã thanh toán hoa hồng chưa
    commission_paid_at TIMESTAMP, -- Thời gian thanh toán hoa hồng
    
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP, -- Ngày tạo
    updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP -- Ngày cập nhật
);

-- Hoa hồng người đánh giá (từ việc chấm thi)
CREATE TABLE examiner_commissions (
    id SERIAL PRIMARY KEY, -- ID hoa hồng
    examiner_id INTEGER REFERENCES center_users(id) ON DELETE CASCADE, -- ID người đánh giá
    grading_queue_id INTEGER REFERENCES grading_queue(id) ON DELETE CASCADE, -- ID danh sách chấm
    exam_attempt_id INTEGER REFERENCES exam_attempts(id) ON DELETE CASCADE, -- ID lần làm bài
    
    -- Commission Details
    commission_amount DECIMAL(10,2) NOT NULL, -- Số tiền hoa hồng
    commission_rate DECIMAL(5,2) NOT NULL, -- Tỷ lệ hoa hồng (%)
    question_type VARCHAR(50) NOT NULL, -- Loại câu hỏi được chấm
    
    -- Status
    status VARCHAR(20) DEFAULT 'pending' CHECK (status IN ('pending', 'approved', 'paid', 'cancelled')), -- Trạng thái
    approved_by INTEGER REFERENCES center_users(id), -- ID người duyệt
    approved_at TIMESTAMP, -- Thời gian duyệt
    paid_at TIMESTAMP, -- Thời gian thanh toán
    
    -- Notes
    notes TEXT, -- Ghi chú
    
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP -- Ngày tạo
);

-- Cấu hình hoa hồng cho người đánh giá
CREATE TABLE commission_config (
    id SERIAL PRIMARY KEY, -- ID cấu hình
    center_id INTEGER REFERENCES centers(id) ON DELETE CASCADE, -- ID trung tâm
    question_type VARCHAR(50) NOT NULL, -- Loại câu hỏi: 'essay', 'speaking', 'writing'
    commission_rate DECIMAL(5,2) NOT NULL, -- Tỷ lệ hoa hồng (%)
    base_amount DECIMAL(10,2) DEFAULT 0, -- Số tiền cơ bản
    is_active BOOLEAN DEFAULT true, -- Trạng thái hoạt động
    created_by INTEGER REFERENCES center_users(id), -- ID người tạo
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP, -- Ngày tạo
    updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP, -- Ngày cập nhật
    
    UNIQUE(center_id, question_type) -- Mỗi trung tâm có cấu hình riêng cho từng loại câu hỏi
);
```

### **8. COIN-BASED PAYMENT SYSTEM (Hệ thống thanh toán bằng coin)**

```sql
-- Tài khoản coin của người dùng
CREATE TABLE coin_accounts (
    id SERIAL PRIMARY KEY, -- ID tài khoản coin
    account_type VARCHAR(20) NOT NULL CHECK (account_type IN ('center', 'examinee')), -- Loại tài khoản
    center_id INTEGER REFERENCES centers(id) ON DELETE CASCADE, -- ID trung tâm (NULL cho người luyện thi ngoài)
    examinee_id INTEGER REFERENCES examinees(id) ON DELETE CASCADE, -- ID người luyện thi (NULL cho trung tâm)
    current_balance DECIMAL(12,2) DEFAULT 0, -- Số coin hiện tại
    total_earned DECIMAL(12,2) DEFAULT 0, -- Tổng coin đã nạp
    total_spent DECIMAL(12,2) DEFAULT 0, -- Tổng coin đã chi
    status VARCHAR(20) DEFAULT 'active' CHECK (status IN ('active', 'suspended', 'closed')), -- Trạng thái tài khoản
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP, -- Ngày tạo
    updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP, -- Ngày cập nhật
    
    -- Constraint: Either center_id or examinee_id must be set
    CONSTRAINT check_coin_account_type CHECK (
        (account_type = 'center' AND center_id IS NOT NULL AND examinee_id IS NULL) OR
        (account_type = 'examinee' AND examinee_id IS NOT NULL AND center_id IS NULL)
    ),
    
    UNIQUE(center_id, examinee_id) -- Mỗi người/trung tâm chỉ có 1 tài khoản coin
);

-- Giao dịch nạp tiền (recharge transactions)
CREATE TABLE recharge_transactions (
    id SERIAL PRIMARY KEY, -- ID giao dịch nạp tiền
    coin_account_id INTEGER REFERENCES coin_accounts(id) ON DELETE CASCADE, -- ID tài khoản coin
    transaction_code VARCHAR(50) UNIQUE NOT NULL, -- Mã giao dịch
    amount DECIMAL(12,2) NOT NULL, -- Số tiền nạp (VND/USD)
    currency VARCHAR(3) DEFAULT 'VND', -- Loại tiền tệ
    coin_received DECIMAL(12,2) NOT NULL, -- Số coin nhận được
    exchange_rate DECIMAL(10,4) NOT NULL, -- Tỷ giá: 1 coin = ? VND/USD
    payment_method VARCHAR(50) NOT NULL, -- Phương thức thanh toán: 'credit_card', 'bank_transfer', 'momo', 'zalopay'
    payment_gateway VARCHAR(50), -- Cổng thanh toán: 'vnpay', 'momo', 'zalopay', 'stripe'
    status VARCHAR(20) DEFAULT 'pending' CHECK (status IN ('pending', 'processing', 'completed', 'failed', 'cancelled', 'refunded')), -- Trạng thái
    gateway_transaction_id VARCHAR(100), -- ID giao dịch từ cổng thanh toán
    gateway_response JSONB, -- Phản hồi từ cổng thanh toán (JSON)
    failure_reason TEXT, -- Lý do thất bại
    processed_at TIMESTAMP, -- Thời gian xử lý
    completed_at TIMESTAMP, -- Thời gian hoàn thành
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP -- Ngày tạo
);

-- Lịch sử giao dịch coin (coin transactions)
CREATE TABLE coin_transactions (
    id SERIAL PRIMARY KEY, -- ID giao dịch coin
    coin_account_id INTEGER REFERENCES coin_accounts(id) ON DELETE CASCADE, -- ID tài khoản coin
    transaction_type VARCHAR(20) NOT NULL CHECK (transaction_type IN ('recharge', 'purchase', 'refund', 'bonus', 'penalty')), -- Loại giao dịch
    transaction_code VARCHAR(50) UNIQUE NOT NULL, -- Mã giao dịch
    amount DECIMAL(12,2) NOT NULL, -- Số coin (dương = cộng, âm = trừ)
    balance_before DECIMAL(12,2) NOT NULL, -- Số dư trước giao dịch
    balance_after DECIMAL(12,2) NOT NULL, -- Số dư sau giao dịch
    description TEXT, -- Mô tả giao dịch
    reference_id INTEGER, -- ID tham chiếu (recharge_transaction_id, exam_attempt_id, etc.)
    reference_type VARCHAR(50), -- Loại tham chiếu: 'recharge', 'exam_attempt', 'refund'
    status VARCHAR(20) DEFAULT 'completed' CHECK (status IN ('pending', 'completed', 'cancelled')), -- Trạng thái
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP -- Ngày tạo
);

-- Bảng giá coin (coin pricing)
CREATE TABLE coin_pricing (
    id SERIAL PRIMARY KEY, -- ID bảng giá
    currency VARCHAR(3) NOT NULL, -- Loại tiền tệ: 'VND', 'USD'
    coin_amount DECIMAL(12,2) NOT NULL, -- Số coin
    price DECIMAL(12,2) NOT NULL, -- Giá tiền
    bonus_coin DECIMAL(12,2) DEFAULT 0, -- Coin thưởng (khuyến mãi)
    is_active BOOLEAN DEFAULT true, -- Trạng thái hoạt động
    valid_from TIMESTAMP DEFAULT CURRENT_TIMESTAMP, -- Có hiệu lực từ
    valid_to TIMESTAMP, -- Có hiệu lực đến (NULL = vô thời hạn)
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP -- Ngày tạo
);

-- Insert default coin pricing (VND)
INSERT INTO coin_pricing (currency, coin_amount, price, bonus_coin) VALUES
('VND', 100, 10000, 0),      -- 100 coin = 10,000 VND
('VND', 500, 45000, 50),     -- 500 coin = 45,000 VND (thưởng 50 coin)
('VND', 1000, 85000, 150),   -- 1000 coin = 85,000 VND (thưởng 150 coin)
('VND', 2000, 160000, 400),  -- 2000 coin = 160,000 VND (thưởng 400 coin)
('VND', 5000, 375000, 1250), -- 5000 coin = 375,000 VND (thưởng 1250 coin)
('VND', 10000, 700000, 3000); -- 10000 coin = 700,000 VND (thưởng 3000 coin)

-- Bảng giá lượt thi (exam attempt pricing)
CREATE TABLE exam_attempt_pricing (
    id SERIAL PRIMARY KEY, -- ID bảng giá lượt thi
    exam_package_id INTEGER REFERENCES exam_packages(id) ON DELETE CASCADE, -- ID bộ đề thi
    center_id INTEGER REFERENCES centers(id) ON DELETE CASCADE, -- ID trung tâm (NULL = giá chung)
    coin_cost DECIMAL(10,2) NOT NULL, -- Số coin cần để làm 1 lượt thi
    is_active BOOLEAN DEFAULT true, -- Trạng thái hoạt động
    valid_from TIMESTAMP DEFAULT CURRENT_TIMESTAMP, -- Có hiệu lực từ
    valid_to TIMESTAMP, -- Có hiệu lực đến (NULL = vô thời hạn)
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP -- Ngày tạo
);

-- Lượt thi đã mua (purchased exam attempts)
CREATE TABLE purchased_exam_attempts (
    id SERIAL PRIMARY KEY, -- ID lượt thi đã mua
    coin_account_id INTEGER REFERENCES coin_accounts(id) ON DELETE CASCADE, -- ID tài khoản coin
    exam_package_id INTEGER REFERENCES exam_packages(id) ON DELETE CASCADE, -- ID bộ đề thi
    coin_transaction_id INTEGER REFERENCES coin_transactions(id) ON DELETE CASCADE, -- ID giao dịch coin
    attempts_purchased INTEGER NOT NULL, -- Số lượt thi đã mua
    attempts_used INTEGER DEFAULT 0, -- Số lượt thi đã sử dụng
    attempts_remaining INTEGER GENERATED ALWAYS AS (attempts_purchased - attempts_used) STORED, -- Số lượt thi còn lại
    coin_cost_per_attempt DECIMAL(10,2) NOT NULL, -- Số coin mỗi lượt thi
    total_coin_cost DECIMAL(12,2) NOT NULL, -- Tổng số coin đã chi
    status VARCHAR(20) DEFAULT 'active' CHECK (status IN ('active', 'expired', 'cancelled')), -- Trạng thái
    expires_at TIMESTAMP, -- Hết hạn (NULL = không hết hạn)
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP -- Ngày tạo
);
```

### **9. SUBSCRIPTION & BILLING (Gói dịch vụ và thanh toán)**

```sql
-- Gói dịch vụ
CREATE TABLE subscription_plans (
    id SERIAL PRIMARY KEY, -- ID gói dịch vụ
    plan_code VARCHAR(50) UNIQUE NOT NULL, -- Mã gói dịch vụ
    plan_name VARCHAR(255) NOT NULL, -- Tên gói dịch vụ
    description TEXT, -- Mô tả
    price_monthly DECIMAL(10,2) NOT NULL, -- Giá hàng tháng
    price_yearly DECIMAL(10,2) NOT NULL, -- Giá hàng năm
    max_centers INTEGER DEFAULT 1, -- Số trung tâm tối đa
    max_students INTEGER DEFAULT 100, -- Số học viên tối đa
    max_exams INTEGER DEFAULT 50, -- Số bài thi tối đa
    max_teachers INTEGER DEFAULT 10, -- Số giáo viên tối đa
    max_storage_gb INTEGER DEFAULT 10, -- Dung lượng lưu trữ tối đa (GB)
    features JSONB, -- Các tính năng có sẵn (JSON)
    is_active BOOLEAN DEFAULT true, -- Trạng thái hoạt động
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP -- Ngày tạo
);

-- Insert subscription plans
INSERT INTO subscription_plans (plan_code, plan_name, description, price_monthly, price_yearly, max_students, max_exams, max_teachers, features) VALUES
('basic', 'Basic Plan', 'Basic features for small centers', 99.00, 990.00, 100, 50, 5, '{"ai_grading": false, "custom_branding": false, "api_access": false}'),
('premium', 'Premium Plan', 'Advanced features for growing centers', 199.00, 1990.00, 500, 200, 20, '{"ai_grading": true, "custom_branding": true, "api_access": true}'),
('enterprise', 'Enterprise Plan', 'Full features for large organizations', 499.00, 4990.00, 2000, 1000, 100, '{"ai_grading": true, "custom_branding": true, "api_access": true, "white_label": true}');

-- Gói dịch vụ của trung tâm
CREATE TABLE center_subscriptions (
    id SERIAL PRIMARY KEY, -- ID gói dịch vụ trung tâm
    center_id INTEGER REFERENCES centers(id) ON DELETE CASCADE, -- ID trung tâm
    plan_id INTEGER REFERENCES subscription_plans(id), -- ID gói dịch vụ
    status VARCHAR(20) DEFAULT 'active' CHECK (status IN ('active', 'suspended', 'cancelled', 'expired')), -- Trạng thái
    start_date DATE NOT NULL, -- Ngày bắt đầu
    end_date DATE NOT NULL, -- Ngày kết thúc
    auto_renew BOOLEAN DEFAULT true, -- Tự động gia hạn
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP -- Ngày tạo
);
```

### **10. REPORTING & ANALYTICS (Báo cáo và phân tích)**

```sql
-- Báo cáo của trung tâm
CREATE TABLE center_reports (
    id SERIAL PRIMARY KEY, -- ID báo cáo
    center_id INTEGER REFERENCES centers(id) ON DELETE CASCADE, -- ID trung tâm
    report_type VARCHAR(50) NOT NULL, -- Loại báo cáo: 'exam_performance', 'student_progress', 'revenue', 'ai_accuracy'
    report_name VARCHAR(255) NOT NULL, -- Tên báo cáo
    report_data JSONB, -- Dữ liệu báo cáo linh hoạt (JSON)
    period_start DATE, -- Ngày bắt đầu kỳ báo cáo
    period_end DATE, -- Ngày kết thúc kỳ báo cáo
    generated_by INTEGER REFERENCES center_users(id), -- ID người tạo báo cáo
    generated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP -- Thời gian tạo báo cáo
);

-- Thống kê bài thi
CREATE TABLE exam_statistics (
    id SERIAL PRIMARY KEY, -- ID thống kê
    center_id INTEGER REFERENCES centers(id) ON DELETE CASCADE, -- ID trung tâm
    exam_id INTEGER REFERENCES exams(id) ON DELETE CASCADE, -- ID bài thi
    language_id INTEGER REFERENCES languages(id), -- ID ngôn ngữ
    category_id INTEGER REFERENCES exam_categories(id), -- ID danh mục
    total_attempts INTEGER DEFAULT 0, -- Tổng số lần làm
    average_score DECIMAL(5,2) DEFAULT 0, -- Điểm trung bình
    pass_rate DECIMAL(5,2) DEFAULT 0, -- Tỷ lệ đậu (%)
    completion_rate DECIMAL(5,2) DEFAULT 0, -- Tỷ lệ hoàn thành (%)
    average_time_minutes DECIMAL(8,2) DEFAULT 0, -- Thời gian làm trung bình (phút)
    
    -- AI Grading Statistics
    ai_grading_usage_rate DECIMAL(5,2) DEFAULT 0, -- Tỷ lệ sử dụng AI chấm (%)
    ai_accuracy_rate DECIMAL(5,2) DEFAULT 0, -- Độ chính xác của AI (%)
    ai_processing_time_avg DECIMAL(8,2) DEFAULT 0, -- Thời gian xử lý AI trung bình (giây)
    
    statistics_date DATE DEFAULT CURRENT_DATE, -- Ngày thống kê
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP, -- Ngày tạo
    
    UNIQUE(center_id, exam_id, statistics_date) -- Mỗi trung tâm, bài thi, ngày chỉ có 1 bản ghi thống kê
);
```

### **11. INDEXES FOR PERFORMANCE (Indexes cho hiệu suất)**

```sql
-- User management indexes
CREATE INDEX idx_users_email ON users(email);
CREATE INDEX idx_users_role ON users(role);
CREATE INDEX idx_users_created_at ON users(created_at);

-- Center management indexes
CREATE INDEX idx_centers_status ON centers(status);
CREATE INDEX idx_centers_subscription_plan ON centers(subscription_plan);
CREATE INDEX idx_center_users_center_id ON center_users(center_id);

-- Exam management indexes
CREATE INDEX idx_exams_center_id ON exams(center_id);
CREATE INDEX idx_exams_language_id ON exams(language_id);
CREATE INDEX idx_exams_category_id ON exams(category_id);
CREATE INDEX idx_exams_is_published ON exams(is_published);
CREATE INDEX idx_exams_use_ai_grading ON exams(use_ai_grading);

-- Question bank indexes
CREATE INDEX idx_question_bank_center_id ON question_bank(center_id);
CREATE INDEX idx_question_bank_language_id ON question_bank(language_id);
CREATE INDEX idx_question_bank_question_type ON question_bank(question_type);
CREATE INDEX idx_question_bank_difficulty_level ON question_bank(difficulty_level);

-- Examinee management indexes
CREATE INDEX idx_examinees_examinee_type ON examinees(examinee_type);
CREATE INDEX idx_examinees_center_id ON examinees(center_id);
CREATE INDEX idx_center_examinees_center_id ON center_examinees(center_id);

-- Exam attempts indexes
CREATE INDEX idx_exam_attempts_examinee_id ON exam_attempts(examinee_id);
CREATE INDEX idx_exam_attempts_exam_package_id ON exam_attempts(exam_package_id);
CREATE INDEX idx_exam_attempts_status ON exam_attempts(status);
CREATE INDEX idx_exam_attempts_ai_grading_used ON exam_attempts(ai_grading_used);

-- Purchase & Payment indexes
CREATE INDEX idx_purchase_orders_buyer_type ON purchase_orders(buyer_type);
CREATE INDEX idx_purchase_orders_center_id ON purchase_orders(center_id);
CREATE INDEX idx_purchase_orders_examinee_id ON purchase_orders(examinee_id);
CREATE INDEX idx_purchase_orders_status ON purchase_orders(status);
CREATE INDEX idx_payment_transactions_purchase_order_id ON payment_transactions(purchase_order_id);
CREATE INDEX idx_payment_transactions_status ON payment_transactions(status);

-- AI analysis indexes
CREATE INDEX idx_ai_analysis_exam_attempt_id ON ai_analysis(exam_attempt_id);
CREATE INDEX idx_ai_analysis_analysis_type ON ai_analysis(analysis_type);
CREATE INDEX idx_ai_analysis_ai_model ON ai_analysis(ai_model);

-- JSONB indexes for flexible queries
CREATE INDEX idx_exams_structure_gin ON exams USING GIN (exam_structure);
CREATE INDEX idx_exams_sections_gin ON exams USING GIN (sections);
CREATE INDEX idx_exams_questions_gin ON exams USING GIN (questions);
CREATE INDEX idx_exams_ai_config_gin ON exams USING GIN (ai_config);

CREATE INDEX idx_question_bank_config_gin ON question_bank USING GIN (question_config);
CREATE INDEX idx_question_bank_options_gin ON question_bank USING GIN (options);
CREATE INDEX idx_question_bank_tags_gin ON question_bank USING GIN (tags);
CREATE INDEX idx_question_bank_ai_grading_config_gin ON question_bank USING GIN (ai_grading_config);

CREATE INDEX idx_exam_attempts_answers_gin ON exam_attempts USING GIN (answers);
CREATE INDEX idx_exam_attempts_essay_gin ON exam_attempts USING GIN (essay_responses);
CREATE INDEX idx_exam_attempts_speaking_gin ON exam_attempts USING GIN (speaking_recordings);
CREATE INDEX idx_exam_attempts_ai_analysis_gin ON exam_attempts USING GIN (ai_analysis);

CREATE INDEX idx_ai_analysis_details_gin ON ai_analysis USING GIN (analysis_details);
CREATE INDEX idx_ai_analysis_keywords_gin ON ai_analysis USING GIN (keywords_found);
CREATE INDEX idx_ai_analysis_grammar_gin ON ai_analysis USING GIN (grammar_analysis);
CREATE INDEX idx_ai_analysis_content_gin ON ai_analysis USING GIN (content_analysis);
```

### **12. FUNCTIONS FOR BUSINESS LOGIC (Functions cho logic nghiệp vụ)**

```sql
-- Function to calculate exam progress
CREATE OR REPLACE FUNCTION calculate_exam_progress(p_student_id INTEGER, p_exam_id INTEGER)
RETURNS DECIMAL(5,2) AS $$
DECLARE
    total_questions INTEGER;
    answered_questions INTEGER;
    progress DECIMAL(5,2);
BEGIN
    -- Get total questions in exam
    SELECT total_questions INTO total_questions
    FROM exams
    WHERE id = p_exam_id;
    
    -- Get answered questions
    SELECT COUNT(*) INTO answered_questions
    FROM exam_attempts ea
    WHERE ea.student_id = p_student_id 
    AND ea.exam_id = p_exam_id 
    AND ea.answers IS NOT NULL;
    
    -- Calculate progress percentage
    IF total_questions > 0 THEN
        progress := (answered_questions::DECIMAL / total_questions::DECIMAL) * 100;
    ELSE
        progress := 0;
    END IF;
    
    RETURN progress;
END;
$$ LANGUAGE plpgsql;

-- Function to check if examinee can access exam package (coin-based)
CREATE OR REPLACE FUNCTION can_access_exam_package(p_examinee_id INTEGER, p_exam_package_id INTEGER)
RETURNS BOOLEAN AS $$
DECLARE
    exam_center_id INTEGER;
    examinee_center_id INTEGER;
    examinee_type VARCHAR(20);
    has_attempts BOOLEAN;
    coin_balance DECIMAL(12,2);
    coin_cost DECIMAL(10,2);
BEGIN
    -- Get exam package center
    SELECT center_id INTO exam_center_id
    FROM exam_packages
    WHERE id = p_exam_package_id;
    
    -- Get examinee info
    SELECT center_id, examinee_type INTO examinee_center_id, examinee_type
    FROM examinees
    WHERE id = p_examinee_id;
    
    -- If examinee is from the same center, allow access
    IF examinee_center_id = exam_center_id THEN
        RETURN true;
    END IF;
    
    -- If examinee is external, check coin balance and purchased attempts
    IF examinee_type = 'external' THEN
        -- Check if examinee has purchased attempts remaining
        SELECT EXISTS(
            SELECT 1 FROM purchased_exam_attempts pea
            JOIN coin_accounts ca ON pea.coin_account_id = ca.id
            WHERE ca.examinee_id = p_examinee_id 
            AND pea.exam_package_id = p_exam_package_id
            AND pea.attempts_remaining > 0
            AND pea.status = 'active'
            AND (pea.expires_at IS NULL OR pea.expires_at > CURRENT_TIMESTAMP)
        ) INTO has_attempts;
        
        IF has_attempts THEN
            RETURN true;
        END IF;
        
        -- Check if examinee has enough coins to buy a new attempt
        SELECT ca.current_balance INTO coin_balance
        FROM coin_accounts ca
        WHERE ca.examinee_id = p_examinee_id;
        
        SELECT eap.coin_cost INTO coin_cost
        FROM exam_attempt_pricing eap
        WHERE eap.exam_package_id = p_exam_package_id
        AND eap.is_active = true
        AND (eap.valid_to IS NULL OR eap.valid_to > CURRENT_TIMESTAMP)
        ORDER BY eap.valid_from DESC
        LIMIT 1;
        
        -- If no specific pricing found, use default pricing
        IF coin_cost IS NULL THEN
            SELECT eap.coin_cost INTO coin_cost
            FROM exam_attempt_pricing eap
            WHERE eap.exam_package_id = p_exam_package_id
            AND eap.center_id IS NULL
            AND eap.is_active = true
            ORDER BY eap.valid_from DESC
            LIMIT 1;
        END IF;
        
        -- If still no pricing found, deny access
        IF coin_cost IS NULL THEN
            RETURN false;
        END IF;
        
        -- Check if examinee has enough coins
        RETURN (coin_balance >= coin_cost);
    END IF;
    
    RETURN false;
END;
$$ LANGUAGE plpgsql;

-- Function to process mixed grading (system auto + AI + examiner)
CREATE OR REPLACE FUNCTION process_mixed_grading(p_exam_attempt_id INTEGER, p_examinee_chose_ai BOOLEAN DEFAULT false)
RETURNS INTEGER AS $$
DECLARE
    question_record RECORD;
    total_system_score DECIMAL(5,2) := 0;
    total_ai_score DECIMAL(5,2) := 0;
    total_questions INTEGER := 0;
    essay_questions INTEGER := 0;
    ai_questions INTEGER := 0;
BEGIN
    -- Process all questions in the exam package
    FOR question_record IN 
        SELECT qb.id, qb.question_type, qb.correct_answer, qb.question_text,
               ea.answers, ea.essay_responses, ea.speaking_recordings
        FROM question_bank qb
        JOIN exam_packages ep ON qb.id = ANY(ep.questions->'question_ids')
        JOIN exam_attempts ea ON ep.id = ea.exam_package_id
        WHERE ea.id = p_exam_attempt_id
    LOOP
        total_questions := total_questions + 1;
        
        -- System auto grade for objective questions
        IF question_record.question_type IN ('multiple_choice', 'true_false', 'fill_blank') THEN
            INSERT INTO auto_grading_results (
                exam_attempt_id, question_id, question_type,
                auto_score, max_score, is_correct,
                student_answer, correct_answer, explanation,
                grading_method
            ) VALUES (
                p_exam_attempt_id, question_record.id, question_record.question_type,
                CASE 
                    WHEN question_record.question_type = 'multiple_choice' THEN
                        CASE WHEN (ea.answers->question_record.id::text) = question_record.correct_answer THEN 1.0 ELSE 0.0 END
                    WHEN question_record.question_type = 'true_false' THEN
                        CASE WHEN (ea.answers->question_record.id::text) = question_record.correct_answer THEN 1.0 ELSE 0.0 END
                    WHEN question_record.question_type = 'fill_blank' THEN
                        CASE WHEN LOWER(TRIM(ea.answers->question_record.id::text)) = LOWER(TRIM(question_record.correct_answer)) THEN 1.0 ELSE 0.0 END
                END,
                1.0, -- max score
                (ea.answers->question_record.id::text) = question_record.correct_answer,
                ea.answers->question_record.id::text,
                question_record.correct_answer,
                'Auto-graded by system',
                'system_auto'
            );
            
            total_system_score := total_system_score + 1.0;
            
        -- AI grade for essay questions (if examinee chose AI)
        ELSIF question_record.question_type IN ('essay', 'speaking', 'writing') AND p_examinee_chose_ai THEN
            -- AI grading for essay questions
            INSERT INTO auto_grading_results (
                exam_attempt_id, question_id, question_type,
                auto_score, max_score, is_correct,
                student_answer, correct_answer, explanation,
                grading_method, confidence_score
            ) VALUES (
                p_exam_attempt_id, question_record.id, question_record.question_type,
                8.5, -- AI score (example)
                10.0, -- max score
                NULL, -- Not applicable for essay
                CASE 
                    WHEN question_record.question_type = 'essay' THEN question_record.essay_responses->>question_record.id::text
                    WHEN question_record.question_type = 'speaking' THEN question_record.speaking_recordings->>question_record.id::text
                    WHEN question_record.question_type = 'writing' THEN question_record.essay_responses->>question_record.id::text
                END,
                question_record.correct_answer,
                'AI-graded essay with detailed feedback',
                'ai',
                0.85 -- AI confidence score
            );
            
            total_ai_score := total_ai_score + 8.5;
            ai_questions := ai_questions + 1;
            
        -- Examiner grade for essay questions (if examinee chose examiner)
        ELSIF question_record.question_type IN ('essay', 'speaking', 'writing') AND NOT p_examinee_chose_ai THEN
            -- Add to grading queue for examiner grading
            essay_questions := essay_questions + 1;
            
            INSERT INTO grading_queue (
                exam_attempt_id, question_id, examinee_id, center_id,
                question_type, question_text, examinee_answer, grading_criteria
            ) VALUES (
                p_exam_attempt_id, question_record.id, 
                (SELECT examinee_id FROM exam_attempts WHERE id = p_exam_attempt_id),
                (SELECT center_id FROM exam_attempts WHERE id = p_exam_attempt_id),
                question_record.question_type, question_record.question_text,
                CASE 
                    WHEN question_record.question_type = 'essay' THEN question_record.essay_responses
                    WHEN question_record.question_type = 'speaking' THEN question_record.speaking_recordings
                    WHEN question_record.question_type = 'writing' THEN question_record.essay_responses
                END,
                '{}'::JSONB -- Will be filled from question bank
            );
        END IF;
    END LOOP;
    
    -- Update exam attempt with grading results
    UPDATE exam_attempts 
    SET system_auto_grading_used = true,
        system_auto_grading_score = total_system_score,
        ai_grading_used = (ai_questions > 0),
        ai_grading_score = total_ai_score,
        examinee_chose_ai = p_examinee_chose_ai,
        examiner_grading_required = (essay_questions > 0),
        examiner_grading_requested = (essay_questions > 0)
    WHERE id = p_exam_attempt_id;
    
    RETURN total_questions;
END;
$$ LANGUAGE plpgsql;

-- Function to assign grading to examiner
CREATE OR REPLACE FUNCTION assign_grading_to_examiner(p_queue_id INTEGER, p_examiner_id INTEGER)
RETURNS BOOLEAN AS $$
BEGIN
    UPDATE grading_queue 
    SET assigned_to = p_examiner_id, 
        assigned_at = CURRENT_TIMESTAMP,
        status = 'assigned'
    WHERE id = p_queue_id AND status = 'pending';
    
    RETURN FOUND;
END;
$$ LANGUAGE plpgsql;

-- Function to complete grading and create commission
CREATE OR REPLACE FUNCTION complete_grading(p_queue_id INTEGER, p_examiner_score DECIMAL, p_examiner_feedback TEXT)
RETURNS INTEGER AS $$
DECLARE
    commission_id INTEGER;
    queue_info RECORD;
BEGIN
    -- Get queue info
    SELECT * INTO queue_info FROM grading_queue WHERE id = p_queue_id;
    
    -- Update grading queue
    UPDATE grading_queue 
    SET examiner_score = p_examiner_score,
        examiner_feedback = p_examiner_feedback,
        completed_at = CURRENT_TIMESTAMP,
        status = 'completed'
    WHERE id = p_queue_id;
    
    -- Create commission record
    INSERT INTO examiner_commissions (
        examiner_id, grading_queue_id, exam_attempt_id,
        commission_amount, commission_rate, question_type
    ) VALUES (
        queue_info.assigned_to, p_queue_id, queue_info.exam_attempt_id,
        queue_info.commission_amount, queue_info.commission_rate, queue_info.question_type
    ) RETURNING id INTO commission_id;
    
    -- Update exam attempt
    UPDATE exam_attempts 
    SET examiner_grading_completed = true,
        examiner_feedback = COALESCE(examiner_feedback, '{}'::JSONB) || 
        jsonb_build_object(queue_info.question_type, p_examiner_feedback)
    WHERE id = queue_info.exam_attempt_id;
    
    RETURN commission_id;
END;
$$ LANGUAGE plpgsql;

-- Function for examinee to choose grading method for essay questions
CREATE OR REPLACE FUNCTION examinee_choose_grading_method(p_exam_attempt_id INTEGER, p_choose_ai BOOLEAN)
RETURNS BOOLEAN AS $$
DECLARE
    attempt_info RECORD;
    has_essay_questions BOOLEAN := false;
BEGIN
    -- Get exam attempt info
    SELECT * INTO attempt_info FROM exam_attempts WHERE id = p_exam_attempt_id;
    
    -- Check if exam package has essay questions
    SELECT EXISTS(
        SELECT 1 FROM question_bank qb
        JOIN exam_packages ep ON qb.id = ANY(ep.questions->'question_ids')
        WHERE ep.id = attempt_info.exam_package_id
        AND qb.question_type IN ('essay', 'speaking', 'writing')
    ) INTO has_essay_questions;
    
    -- If no essay questions, return false
    IF NOT has_essay_questions THEN
        RETURN false;
    END IF;
    
    -- Update examinee choice
    UPDATE exam_attempts 
    SET examinee_chose_ai = p_choose_ai,
        ai_grading_used = p_choose_ai,
        examiner_grading_required = NOT p_choose_ai,
        examiner_grading_requested = NOT p_choose_ai
    WHERE id = p_exam_attempt_id;
    
    -- If examinee chose examiner, add essay questions to grading queue
    IF NOT p_choose_ai THEN
        INSERT INTO grading_queue (
            exam_attempt_id, question_id, examinee_id, center_id,
            question_type, question_text, examinee_answer, grading_criteria
        )
        SELECT 
            p_exam_attempt_id, qb.id, attempt_info.examinee_id, attempt_info.center_id,
            qb.question_type, qb.question_text,
            CASE 
                WHEN qb.question_type = 'essay' THEN attempt_info.essay_responses
                WHEN qb.question_type = 'speaking' THEN attempt_info.speaking_recordings
                WHEN qb.question_type = 'writing' THEN attempt_info.essay_responses
            END,
            '{}'::JSONB
        FROM question_bank qb
        JOIN exam_packages ep ON qb.id = ANY(ep.questions->'question_ids')
        WHERE ep.id = attempt_info.exam_package_id
        AND qb.question_type IN ('essay', 'speaking', 'writing');
    END IF;
    
    RETURN true;
END;
$$ LANGUAGE plpgsql;

-- Function to create coin account for new user
CREATE OR REPLACE FUNCTION create_coin_account(p_account_type VARCHAR, p_center_id INTEGER, p_examinee_id INTEGER)
RETURNS INTEGER AS $$
DECLARE
    account_id INTEGER;
BEGIN
    INSERT INTO coin_accounts (account_type, center_id, examinee_id)
    VALUES (p_account_type, p_center_id, p_examinee_id)
    RETURNING id INTO account_id;
    
    RETURN account_id;
END;
$$ LANGUAGE plpgsql;

-- Function to process coin recharge
CREATE OR REPLACE FUNCTION process_coin_recharge(p_coin_account_id INTEGER, p_amount DECIMAL, p_currency VARCHAR, p_payment_method VARCHAR, p_gateway_transaction_id VARCHAR)
RETURNS INTEGER AS $$
DECLARE
    recharge_id INTEGER;
    coin_received DECIMAL(12,2);
    exchange_rate DECIMAL(10,4);
    bonus_coin DECIMAL(12,2);
    current_balance DECIMAL(12,2);
    new_balance DECIMAL(12,2);
    transaction_id INTEGER;
BEGIN
    -- Get exchange rate and bonus coin from pricing
    SELECT cp.coin_amount, cp.price, cp.bonus_coin
    INTO coin_received, exchange_rate, bonus_coin
    FROM coin_pricing cp
    WHERE cp.currency = p_currency
    AND cp.price = p_amount
    AND cp.is_active = true
    AND (cp.valid_to IS NULL OR cp.valid_to > CURRENT_TIMESTAMP)
    ORDER BY cp.valid_from DESC
    LIMIT 1;
    
    -- If no exact match, calculate based on rate
    IF coin_received IS NULL THEN
        SELECT cp.coin_amount / cp.price * p_amount, cp.price / cp.coin_amount
        INTO coin_received, exchange_rate
        FROM coin_pricing cp
        WHERE cp.currency = p_currency
        AND cp.is_active = true
        AND (cp.valid_to IS NULL OR cp.valid_to > CURRENT_TIMESTAMP)
        ORDER BY cp.valid_from DESC
        LIMIT 1;
        
        bonus_coin := 0;
    END IF;
    
    -- Add bonus coin
    coin_received := coin_received + COALESCE(bonus_coin, 0);
    
    -- Create recharge transaction
    INSERT INTO recharge_transactions (
        coin_account_id, transaction_code, amount, currency, coin_received, 
        exchange_rate, payment_method, payment_gateway, gateway_transaction_id, status
    ) VALUES (
        p_coin_account_id, 'RCH_' || EXTRACT(EPOCH FROM NOW())::BIGINT, p_amount, p_currency, 
        coin_received, exchange_rate, p_payment_method, 'auto', p_gateway_transaction_id, 'completed'
    ) RETURNING id INTO recharge_id;
    
    -- Get current balance
    SELECT current_balance INTO current_balance
    FROM coin_accounts
    WHERE id = p_coin_account_id;
    
    new_balance := current_balance + coin_received;
    
    -- Update coin account
    UPDATE coin_accounts 
    SET current_balance = new_balance,
        total_earned = total_earned + coin_received,
        updated_at = CURRENT_TIMESTAMP
    WHERE id = p_coin_account_id;
    
    -- Create coin transaction record
    INSERT INTO coin_transactions (
        coin_account_id, transaction_type, transaction_code, amount, 
        balance_before, balance_after, description, reference_id, reference_type
    ) VALUES (
        p_coin_account_id, 'recharge', 'CT_' || EXTRACT(EPOCH FROM NOW())::BIGINT, 
        coin_received, current_balance, new_balance, 
        'Recharge ' || p_amount || ' ' || p_currency || ' for ' || coin_received || ' coins',
        recharge_id, 'recharge'
    ) RETURNING id INTO transaction_id;
    
    RETURN recharge_id;
END;
$$ LANGUAGE plpgsql;

-- Function to purchase exam attempts with coins
CREATE OR REPLACE FUNCTION purchase_exam_attempts(p_coin_account_id INTEGER, p_exam_package_id INTEGER, p_attempts INTEGER)
RETURNS INTEGER AS $$
DECLARE
    coin_cost DECIMAL(10,2);
    total_cost DECIMAL(12,2);
    current_balance DECIMAL(12,2);
    new_balance DECIMAL(12,2);
    transaction_id INTEGER;
    purchase_id INTEGER;
BEGIN
    -- Get coin cost per attempt
    SELECT eap.coin_cost INTO coin_cost
    FROM exam_attempt_pricing eap
    WHERE eap.exam_package_id = p_exam_package_id
    AND eap.is_active = true
    AND (eap.valid_to IS NULL OR eap.valid_to > CURRENT_TIMESTAMP)
    ORDER BY eap.valid_from DESC
    LIMIT 1;
    
    -- If no specific pricing found, use default pricing
    IF coin_cost IS NULL THEN
        SELECT eap.coin_cost INTO coin_cost
        FROM exam_attempt_pricing eap
        WHERE eap.exam_package_id = p_exam_package_id
        AND eap.center_id IS NULL
        AND eap.is_active = true
        ORDER BY eap.valid_from DESC
        LIMIT 1;
    END IF;
    
    -- If still no pricing found, return error
    IF coin_cost IS NULL THEN
        RETURN -1;
    END IF;
    
    total_cost := coin_cost * p_attempts;
    
    -- Get current balance
    SELECT current_balance INTO current_balance
    FROM coin_accounts
    WHERE id = p_coin_account_id;
    
    -- Check if enough coins
    IF current_balance < total_cost THEN
        RETURN -2; -- Insufficient coins
    END IF;
    
    new_balance := current_balance - total_cost;
    
    -- Update coin account
    UPDATE coin_accounts 
    SET current_balance = new_balance,
        total_spent = total_spent + total_cost,
        updated_at = CURRENT_TIMESTAMP
    WHERE id = p_coin_account_id;
    
    -- Create coin transaction record
    INSERT INTO coin_transactions (
        coin_account_id, transaction_type, transaction_code, amount, 
        balance_before, balance_after, description, reference_type
    ) VALUES (
        p_coin_account_id, 'purchase', 'CT_' || EXTRACT(EPOCH FROM NOW())::BIGINT, 
        -total_cost, current_balance, new_balance, 
        'Purchase ' || p_attempts || ' exam attempts for ' || total_cost || ' coins',
        'exam_attempt'
    ) RETURNING id INTO transaction_id;
    
    -- Create purchased exam attempts record
    INSERT INTO purchased_exam_attempts (
        coin_account_id, exam_package_id, coin_transaction_id, attempts_purchased,
        coin_cost_per_attempt, total_coin_cost
    ) VALUES (
        p_coin_account_id, p_exam_package_id, transaction_id, p_attempts,
        coin_cost, total_cost
    ) RETURNING id INTO purchase_id;
    
    RETURN purchase_id;
END;
$$ LANGUAGE plpgsql;

-- Function to use a purchased exam attempt
CREATE OR REPLACE FUNCTION use_exam_attempt(p_coin_account_id INTEGER, p_exam_package_id INTEGER)
RETURNS INTEGER AS $$
DECLARE
    purchase_id INTEGER;
    attempts_remaining INTEGER;
BEGIN
    -- Find available purchased attempt
    SELECT pea.id, pea.attempts_remaining
    INTO purchase_id, attempts_remaining
    FROM purchased_exam_attempts pea
    WHERE pea.coin_account_id = p_coin_account_id
    AND pea.exam_package_id = p_exam_package_id
    AND pea.attempts_remaining > 0
    AND pea.status = 'active'
    AND (pea.expires_at IS NULL OR pea.expires_at > CURRENT_TIMESTAMP)
    ORDER BY pea.created_at ASC
    LIMIT 1;
    
    -- If no available attempts, return error
    IF purchase_id IS NULL THEN
        RETURN -1; -- No available attempts
    END IF;
    
    -- Update attempts used
    UPDATE purchased_exam_attempts 
    SET attempts_used = attempts_used + 1,
        updated_at = CURRENT_TIMESTAMP
    WHERE id = purchase_id;
    
    RETURN purchase_id;
END;
$$ LANGUAGE plpgsql;
```

### **13. VIEWS FOR COMMON QUERIES (Views cho queries phổ biến)**

```sql
-- View for exam statistics with AI grading info
CREATE VIEW exam_statistics_with_ai AS
SELECT 
    e.id,
    e.title,
    e.language_id,
    l.language_name,
    e.category_id,
    ec.category_name,
    e.total_attempts,
    e.average_score,
    e.use_ai_grading,
    COUNT(ea.id) as total_attempts_count,
    AVG(ea.score) as avg_score,
    COUNT(CASE WHEN ea.ai_grading_used = true THEN 1 END) as ai_graded_count,
    AVG(CASE WHEN ea.ai_grading_used = true THEN ea.ai_confidence_score END) as avg_ai_confidence
FROM exams e
LEFT JOIN languages l ON e.language_id = l.id
LEFT JOIN exam_categories ec ON e.category_id = ec.id
LEFT JOIN exam_attempts ea ON e.id = ea.exam_id
GROUP BY e.id, e.title, e.language_id, l.language_name, e.category_id, ec.category_name, e.total_attempts, e.average_score, e.use_ai_grading;

-- View for student progress with AI grading
CREATE VIEW student_progress_with_ai AS
SELECT 
    s.id as student_id,
    s.student_code,
    s.student_type,
    s.center_id,
    c.center_name,
    COUNT(ea.id) as total_exam_attempts,
    AVG(ea.score) as average_score,
    COUNT(CASE WHEN ea.ai_grading_used = true THEN 1 END) as ai_graded_attempts,
    AVG(CASE WHEN ea.ai_grading_used = true THEN ea.ai_confidence_score END) as avg_ai_confidence
FROM students s
LEFT JOIN centers c ON s.center_id = c.id
LEFT JOIN exam_attempts ea ON s.id = ea.student_id
GROUP BY s.id, s.student_code, s.student_type, s.center_id, c.center_name;

-- View for mixed grading results summary
CREATE VIEW mixed_grading_summary AS
SELECT 
    ea.id as exam_attempt_id,
    e.title as exam_title,
    CONCAT(u.first_name, ' ', u.last_name) as student_name,
    ea.system_auto_grading_score,
    ea.ai_grading_score,
    ea.score as total_score,
    ea.system_auto_grading_used,
    ea.ai_grading_used,
    ea.teacher_grading_required,
    ea.teacher_grading_completed,
    COUNT(CASE WHEN agr.grading_method = 'system_auto' THEN 1 END) as system_auto_questions,
    COUNT(CASE WHEN agr.grading_method = 'ai' THEN 1 END) as ai_graded_questions,
    COUNT(CASE WHEN gq.status = 'completed' THEN 1 END) as teacher_graded_questions,
    COUNT(CASE WHEN agr.is_correct = true THEN 1 END) as correct_answers,
    ROUND(
        (COUNT(CASE WHEN agr.is_correct = true THEN 1 END)::DECIMAL / COUNT(agr.id)::DECIMAL) * 100, 2
    ) as system_accuracy_rate,
    AVG(CASE WHEN agr.grading_method = 'ai' THEN agr.confidence_score END) as avg_ai_confidence
FROM exam_attempts ea
JOIN exams e ON ea.exam_id = e.id
JOIN students s ON ea.student_id = s.id
JOIN users u ON s.user_id = u.id
LEFT JOIN auto_grading_results agr ON ea.id = agr.exam_attempt_id
LEFT JOIN grading_queue gq ON ea.id = gq.exam_attempt_id
GROUP BY ea.id, e.title, u.first_name, u.last_name, ea.system_auto_grading_score, ea.ai_grading_score, ea.score, ea.system_auto_grading_used, ea.ai_grading_used, ea.teacher_grading_required, ea.teacher_grading_completed;

-- View for comprehensive grading results (system + AI + teacher)
CREATE VIEW comprehensive_grading_results AS
SELECT 
    ea.id as exam_attempt_id,
    e.title as exam_title,
    CONCAT(u.first_name, ' ', u.last_name) as student_name,
    ea.system_auto_grading_score,
    ea.ai_grading_score,
    ea.score as total_score,
    ea.system_auto_grading_used,
    ea.ai_grading_used,
    ea.teacher_grading_completed,
    COUNT(CASE WHEN agr.grading_method = 'system_auto' THEN 1 END) as system_auto_questions,
    COUNT(CASE WHEN agr.grading_method = 'ai' THEN 1 END) as ai_graded_questions,
    COUNT(CASE WHEN gq.status = 'completed' THEN 1 END) as teacher_graded_questions,
    COUNT(CASE WHEN agr.is_correct = true THEN 1 END) as system_correct_answers,
    AVG(gq.teacher_score) as avg_teacher_score,
    AVG(CASE WHEN agr.grading_method = 'ai' THEN agr.confidence_score END) as avg_ai_confidence
FROM exam_attempts ea
JOIN exams e ON ea.exam_id = e.id
JOIN students s ON ea.student_id = s.id
JOIN users u ON s.user_id = u.id
LEFT JOIN auto_grading_results agr ON ea.id = agr.exam_attempt_id
LEFT JOIN grading_queue gq ON ea.id = gq.exam_attempt_id AND gq.status = 'completed'
GROUP BY ea.id, e.title, u.first_name, u.last_name, ea.system_auto_grading_score, ea.ai_grading_score, ea.score, ea.system_auto_grading_used, ea.ai_grading_used, ea.teacher_grading_completed;

-- View for grading queue status
CREATE VIEW grading_queue_status AS
SELECT 
    gq.id as queue_id,
    c.center_name,
    CONCAT(u.first_name, ' ', u.last_name) as student_name,
    gq.question_type,
    gq.status,
    gq.priority,
    gq.created_at,
    gq.assigned_at,
    gq.completed_at,
    gq.commission_amount,
    CASE 
        WHEN gq.assigned_to IS NOT NULL THEN CONCAT(teacher_u.first_name, ' ', teacher_u.last_name)
        ELSE 'Unassigned'
    END as assigned_teacher
FROM grading_queue gq
JOIN centers c ON gq.center_id = c.id
JOIN students s ON gq.student_id = s.id
JOIN users u ON s.user_id = u.id
LEFT JOIN center_users cu ON gq.assigned_to = cu.id
LEFT JOIN users teacher_u ON cu.user_id = teacher_u.id;

-- View for teacher commission summary
CREATE VIEW teacher_commission_summary AS
SELECT 
    cu.id as teacher_id,
    CONCAT(u.first_name, ' ', u.last_name) as teacher_name,
    c.center_name,
    COUNT(tc.id) as total_commissions,
    SUM(tc.commission_amount) as total_commission_amount,
    COUNT(CASE WHEN tc.status = 'paid' THEN 1 END) as paid_commissions,
    SUM(CASE WHEN tc.status = 'paid' THEN tc.commission_amount ELSE 0 END) as paid_amount,
    COUNT(CASE WHEN tc.status = 'pending' THEN 1 END) as pending_commissions,
    SUM(CASE WHEN tc.status = 'pending' THEN tc.commission_amount ELSE 0 END) as pending_amount
FROM teacher_commissions tc
JOIN center_users cu ON tc.teacher_id = cu.id
JOIN users u ON cu.user_id = u.id
JOIN centers c ON cu.center_id = c.id
GROUP BY cu.id, u.first_name, u.last_name, c.center_name;
```

## 🎯 **Đặc điểm nổi bật của Database PostgreSQL:**

### **1. Flexible Exam Structure (Cấu trúc đề thi tùy biến)**
- **JSONB columns**: `exam_structure`, `sections`, `questions` cho cấu trúc linh hoạt
- **Template system**: `exam_templates` với cấu trúc tùy biến
- **Multi-language support**: Hỗ trợ 4 ngôn ngữ (Anh, Hàn, Trung, Nhật)

### **2. Mixed Grading System (Hệ thống chấm điểm hỗn hợp)**
- **System auto grading**: Hệ thống tự động chấm trắc nghiệm, đúng/sai, điền từ (không dùng AI)
- **AI grading**: AI chỉ chấm tự luận (essay, writing, speaking) - người luyện thi chọn
- **Examiner grading**: Người đánh giá chấm tự luận (nếu người luyện thi chọn người đánh giá)
- **Examinee choice**: Người luyện thi chọn AI hoặc người đánh giá cho phần tự luận
- **Grading queue**: Danh sách chấm thi cho người đánh giá
- **Commission system**: Hệ thống hoa hồng cho người đánh giá (tính theo từng bài)
- **Performance tracking**: Thống kê hiệu suất cả ba phương pháp

### **3. Dual Examinee System (Hệ thống người luyện thi kép)**
- **External examinees**: Người luyện thi ngoài, thanh toán trực tiếp
- **Center examinees**: Người luyện thi của trung tâm, được quản lý
- **Flexible access**: Cùng một người có thể vừa là người luyện thi ngoài vừa của trung tâm

### **4. Multi-tenant Architecture**
- **Center isolation**: Mỗi trung tâm có dữ liệu riêng biệt
- **Shared resources**: Template và câu hỏi có thể chia sẻ
- **Flexible permissions**: Quyền hạn linh hoạt theo trung tâm

### **5. Performance Optimization**
- **Comprehensive indexing**: 30+ indexes cho performance
- **JSONB GIN indexes**: Cho flexible queries
- **Views**: Pre-computed statistics
- **Functions**: Business logic trong database

Database này đáp ứng đầy đủ yêu cầu từ file user stories với khả năng tùy biến cao cho cấu trúc đề thi và hỗ trợ AI chấm điểm tự luận! 🎉

## 🔄 **Hướng đi phát triển (Coin-Based System):**

### **Phase 1: Core System + Coin (Giai đoạn 1)**
- Triển khai PostgreSQL với các bảng cơ bản
- Xây dựng hệ thống coin: nạp tiền → coin → mua lượt thi
- Phát triển API cho quản lý người dùng, trung tâm, ngân hàng câu hỏi
- Tích hợp cổng thanh toán VNPay, MoMo, ZaloPay cho nạp coin

### **Phase 2: Hybrid Database + Exam System (Giai đoạn 2)**
- Tích hợp MongoDB cho dữ liệu chi tiết exam_package và exam_attempt
- Xây dựng hệ thống đồng bộ dữ liệu PostgreSQL ↔ MongoDB
- Phát triển API cho quản lý bộ đề thi và bài thi
- Triển khai hệ thống chấm điểm tự động (không AI)

### **Phase 3: AI Integration (Giai đoạn 3)**
- Tích hợp AI cho chấm điểm tự luận (essay, writing, speaking)
- Xây dựng hệ thống lựa chọn chấm điểm (AI vs Examiner)
- Phát triển hệ thống hoa hồng cho người đánh giá
- Tối ưu hóa trải nghiệm người dùng với coin system

### **Phase 4: Advanced Features (Giai đoạn 4)**
- Xây dựng hệ thống báo cáo và phân tích chi tiết
- Phát triển tính năng khuyến mãi coin (bonus, discount)
- Tích hợp thêm cổng thanh toán quốc tế (Stripe, PayPal)
- Tối ưu hóa performance và scaling

## 💰 **Mô hình kinh doanh Coin-Based:**

### **Luồng giao dịch:**
1. **Nạp tiền** → Nhận coin (có thể có bonus)
2. **Mua lượt thi** → Chi coin để mua lượt thi cho bộ đề thi cụ thể
3. **Làm bài thi** → Sử dụng lượt thi đã mua
4. **Chấm điểm** → Hệ thống tự động + AI + Examiner (tùy chọn)

### **Ưu điểm:**
- **Linh hoạt**: Người dùng có thể mua nhiều lượt thi cùng lúc
- **Tiết kiệm**: Có thể có khuyến mãi khi nạp coin
- **Dễ quản lý**: Tài khoản coin tập trung, dễ theo dõi
- **Mở rộng**: Dễ dàng thêm các sản phẩm khác (subscription, premium features)

### **Bảng giá mẫu:**
- **100 coin = 10,000 VND** (không bonus)
- **500 coin = 45,000 VND** (thưởng 50 coin)
- **1000 coin = 85,000 VND** (thưởng 150 coin)
- **2000 coin = 160,000 VND** (thưởng 400 coin)
- **5000 coin = 375,000 VND** (thưởng 1250 coin)
- **10000 coin = 700,000 VND** (thưởng 3000 coin)

### **Giá lượt thi mẫu:**
- **IELTS Practice Test**: 50 coin/lượt
- **TOEIC Practice Test**: 30 coin/lượt
- **TOPIK Practice Test**: 40 coin/lượt
- **Custom Exam Package**: 20-100 coin/lượt (tùy độ phức tạp)

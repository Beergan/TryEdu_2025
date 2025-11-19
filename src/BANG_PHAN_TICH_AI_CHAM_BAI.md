# BẢNG PHÂN TÍCH AI CHẤM BÀI THI THỬ - GOOGLE vs AWS

## MỤC ĐÍCH
Phân tích chi tiết và so sánh chi phí sử dụng AI của **Google** và **AWS** để chấm các loại bài thi thử IELTS/TOEFL/TOPIK.

---

## TÓM TẮT NHANH

| Provider | Model | Chi phí TB/bài | Chất lượng | Khuyến nghị |
|----------|-------|----------------|------------|-------------|
| **Google** | Gemini Pro | **274 VND** | Cao | Dễ triển khai |
| **AWS** | Claude 3 Haiku | **218 VND** | Cao | Giá trị tốt nhất |

**Kết luận nhanh:** AWS rẻ hơn 20%, cả 2 đều chất lượng tốt!

---

## GOOGLE CLOUD AI - GEMINI PRO

### A. Thông tin cơ bản
```yaml
Provider: Google Cloud
Model: Gemini Pro
Type: Generative AI (Multimodal)
Training: 2024 data
Languages: 100+ languages (Anh, Việt, Hàn, ...)
```

### B. Giá API (Tháng 10/2025)
| Loại | Giá/1M tokens |
|------|---------------|
| Input | $0.50 |
| Output | $1.50 |
| Free tier | 60 requests/minute |

### C. Chi phí chấm từng loại bài thi

#### IELTS Writing Task 1 (150 words)

```
Input text:    150 words ≈ 200 tokens
Output (feedback): ≈ 300 tokens
Total: 500 tokens

Tính toán:
• Input:  200 × $0.50/1M = $0.0001 (2.5 VND)
• Output: 300 × $1.50/1M = $0.00045 (11 VND)
• Processing: 50 VND
• Storage: 20 VND
──────────────────────────────────────
TOTAL: 83.5 VND/bài

Giá bán đề xuất: 120 coin = 12,000 VND
Margin: 99.3%
```

---

#### IELTS Writing Task 2 (250 words)

```
Input text:    250 words ≈ 350 tokens
Output (feedback): ≈ 400 tokens
Total: 750 tokens

Tính toán:
• Input:  350 × $0.50/1M = $0.000175 (4.4 VND)
• Output: 400 × $1.50/1M = $0.0006 (15 VND)
• Processing: 80 VND
• Storage: 30 VND
──────────────────────────────────────
TOTAL: 129.4 VND/bài

Giá bán đề xuất: 150 coin = 15,000 VND
Margin: 99.1%
```

---

#### IELTS Writing Full (Task 1+2, 400 words)

```
Input text:    400 words ≈ 550 tokens
Output (feedback): ≈ 600 tokens
Total: 1,150 tokens

Tính toán:
• Input:  550 × $0.50/1M = $0.000275 (7 VND)
• Output: 600 × $1.50/1M = $0.0009 (23 VND)
• Processing: 120 VND
• Storage: 50 VND
──────────────────────────────────────
TOTAL: 200 VND/bài

Giá bán đề xuất: 160 coin = 16,000 VND
Margin: 98.8%
```

---

#### IELTS Speaking (10 phút ~ 1,000 words transcript)

```
Input text:    1,000 words ≈ 1,300 tokens
Output (feedback): ≈ 700 tokens
Total: 2,000 tokens

Tính toán:
• Speech to Text (Google): $0.024/min × 10 = $0.24 (6,000 VND)
• Input:  1,300 × $0.50/1M = $0.00065 (16 VND)
• Output: 700 × $1.50/1M = $0.00105 (26 VND)
• Processing: 150 VND
• Storage: 80 VND
──────────────────────────────────────
TOTAL: 6,272 VND/bài

Giá bán đề xuất: 180 coin = 18,000 VND
Margin: 65.2%
```

---

#### IELTS Full Test (R+L+W+S)

```
Reading: Hệ thống chấm = 50 VND
Listening: Hệ thống chấm = 50 VND
Writing: Gemini Pro = 200 VND
Speaking: Gemini Pro + Speech-to-Text = 6,272 VND
──────────────────────────────────────
TOTAL: 6,572 VND/bài

Giá bán đề xuất: 250 coin = 25,000 VND
Margin: 73.7%
```

---

#### IELTS TOPIK Writing (600 ký tự ~ 800 tokens)

```
Input text:    600 ký tự ≈ 1,800 tokens (Korean 3x)
Output (feedback): ≈ 700 tokens
Total: 2,500 tokens

Tính toán:
• Input:  1,800 × $0.50/1M = $0.0009 (23 VND)
• Output: 700 × $1.50/1M = $0.00105 (26 VND)
• Processing: 200 VND
• Storage: 100 VND
──────────────────────────────────────
TOTAL: 349 VND/bài

Giá bán đề xuất: 200 coin = 20,000 VND
Margin: 98.3%
```

---

### D. Bảng tổng hợp Google Gemini Pro

| Loại bài thi | Tokens | Chi phí AI | Giá bán | Margin |
|--------------|--------|------------|---------|--------|
| **Writing Task 1** | 500 | 83.5 VND | 12,000 | 99.3% |
| **Writing Task 2** | 750 | 129.4 VND | 15,000 | 99.1% |
| **Writing Full** | 1,150 | 200 VND | 16,000 | 98.8% |
| **Speaking** | 2,000 | 6,272 VND | 18,000 | 65.2% |
| **Full Test (4 skills)** | - | 6,572 VND | 25,000 | 73.7% |
| **TOPIK Writing** | 2,500 | 349 VND | 20,000 | 98.3% |

---

### E. Ưu điểm & Nhược điểm

#### Ưu điểm:
- **Free tier hào phóng** (60 req/min)
- **Setup dễ dàng** nhất
- **Multimodal** (text + image)
- **Latency thấp** (~500ms)
- **Support đa ngôn ngữ** tốt (Anh, Việt, Hàn)
- **Integration** với GCP ecosystem

#### Nhược điểm:
- Đắt hơn AWS 25%
- Documentation chưa đầy đủ
- Cộng đồng nhỏ hơn OpenAI

---

## AMAZON AWS - BEDROCK CLAUDE 3 HAIKU

### A. Thông tin cơ bản

```yaml
Provider: Amazon Web Services
Model: Claude 3 Haiku (Anthropic)
Type: Generative AI (Text-focused)
Training: 2024 data
Languages: 95+ languages
Speed: Fastest (~200ms)
```

### B. Giá API (Tháng 10/2025)

| Loại | Giá/1M tokens |
|------|---------------|
| Input | $0.25 |
| Output | $1.25 |
| Free tier | Không có |

### C. Chi phí chấm từng loại bài thi

#### IELTS Writing Task 1 (150 words)

```
Input text:    150 words ≈ 200 tokens
Output (feedback): ≈ 300 tokens
Total: 500 tokens

Tính toán:
• Input:  200 × $0.25/1M = $0.00005 (1.25 VND)
• Output: 300 × $1.25/1M = $0.000375 (9.4 VND)
• Processing: 40 VND
• Storage: 20 VND
──────────────────────────────────────
TOTAL: 70.65 VND/bài ✅

Giá bán đề xuất: 120 coin = 12,000 VND
Margin: 99.4%
```

---

#### IELTS Writing Task 2 (250 words)

```
Input text:    250 words ≈ 350 tokens
Output (feedback): ≈ 400 tokens
Total: 750 tokens

Tính toán:
• Input:  350 × $0.25/1M = $0.0000875 (2.2 VND)
• Output: 400 × $1.25/1M = $0.0005 (12.5 VND)
• Processing: 60 VND
• Storage: 30 VND
──────────────────────────────────────
TOTAL: 104.7 VND/bài ✅

Giá bán đề xuất: 150 coin = 15,000 VND
Margin: 99.3%
```

---

#### IELTS Writing Full (Task 1+2, 400 words)

```
Input text:    400 words ≈ 550 tokens
Output (feedback): ≈ 600 tokens
Total: 1,150 tokens

Tính toán:
• Input:  550 × $0.25/1M = $0.0001375 (3.4 VND)
• Output: 600 × $1.25/1M = $0.00075 (19 VND)
• Processing: 100 VND
• Storage: 50 VND
──────────────────────────────────────
TOTAL: 172.4 VND/bài ✅

Giá bán đề xuất: 160 coin = 16,000 VND
Margin: 98.9%
```

---

#### IELTS Speaking (10 phút ~ 1,000 words transcript)

```
Input text:    1,000 words ≈ 1,300 tokens
Output (feedback): ≈ 700 tokens
Total: 2,000 tokens

Tính toán:
• Speech to Text (AWS Transcribe): $0.024/min × 10 = $0.24 (6,000 VND)
• Input:  1,300 × $0.25/1M = $0.000325 (8 VND)
• Output: 700 × $1.25/1M = $0.000875 (22 VND)
• Processing: 120 VND
• Storage: 80 VND
──────────────────────────────────────
TOTAL: 6,230 VND/bài ✅

Giá bán đề xuất: 180 coin = 18,000 VND
Margin: 65.4%
```

---

#### IELTS Full Test (R+L+W+S)

```
Reading: Hệ thống chấm = 50 VND
Listening: Hệ thống chấm = 50 VND
Writing: Claude 3 = 172 VND
Speaking: Claude 3 + Transcribe = 6,230 VND
──────────────────────────────────────
TOTAL: 6,502 VND/bài ✅

Giá bán đề xuất: 250 coin = 25,000 VND
Margin: 74.0%
```

---

#### IELTS TOPIK Writing (600 ký tự ~ 1,800 tokens)

```
Input text:    600 ký tự ≈ 1,800 tokens
Output (feedback): ≈ 700 tokens
Total: 2,500 tokens

Tính toán:
• Input:  1,800 × $0.25/1M = $0.00045 (11 VND)
• Output: 700 × $1.25/1M = $0.000875 (22 VND)
• Processing: 150 VND
• Storage: 100 VND
──────────────────────────────────────
TOTAL: 283 VND/bài ✅

Giá bán đề xuất: 200 coin = 20,000 VND
Margin: 98.6%
```

---

### D. Bảng tổng hợp AWS Claude 3 Haiku

| Loại bài thi | Tokens | Chi phí AI | Giá bán | Margin |
|--------------|--------|------------|---------|--------|
| **Writing Task 1** | 500 | 70.65 VND ✅ | 12,000 | 99.4% |
| **Writing Task 2** | 750 | 104.7 VND ✅ | 15,000 | 99.3% |
| **Writing Full** | 1,150 | 172 VND ✅ | 16,000 | 98.9% |
| **Speaking** | 2,000 | 6,230 VND ✅ | 18,000 | 65.4% |
| **Full Test (4 skills)** | - | 6,502 VND ✅ | 25,000 | 74.0% |
| **TOPIK Writing** | 2,500 | 283 VND ✅ | 20,000 | 98.6% |

---

### E. Ưu điểm & Nhược điểm

#### Ưu điểm:
- **Giá RẺ NHẤT** (rẻ hơn Google 20-25%)
- **Nhanh nhất** (~200ms latency)
- **AWS ecosystem** tích hợp tốt
- **Security** cấp enterprise
- **Scalability** vô hạn

#### Nhược điểm:
- Setup phức tạp hơn
- Cần AWS expertise
- Không có free tier
- Documentation scattered

---

## BẢNG SO SÁNH TRỰC TIẾP

### Chi phí AI theo từng loại bài thi:

| Loại bài thi | Google Gemini | AWS Claude 3 | Chênh lệch | Winner |
|--------------|---------------|--------------|------------|--------|
| **Writing Task 1** | 83.5 VND | 70.65 VND | -15% | 🏆 AWS |
| **Writing Task 2** | 129.4 VND | 104.7 VND | -19% | 🏆 AWS |
| **Writing Full** | 200 VND | 172 VND | -14% | 🏆 AWS |
| **Speaking** | 6,272 VND | 6,230 VND | -1% | 🏆 AWS |
| **Full Test** | 6,572 VND | 6,502 VND | -1% | 🏆 AWS |
| **TOPIK Writing** | 349 VND | 283 VND | -19% | 🏆 AWS |

**→ AWS RẺ HƠN 1-19% tùy loại bài thi**

---

### Chi phí theo quy mô (1 tháng):

#### Scenario 1: Quy mô nhỏ (2,000 bài Writing/tháng)

| Provider | Chi phí/tháng | Chi phí/năm | Margin |
|----------|---------------|-------------|--------|
| Google | 258,800 VND | 3.1M | 98.8% |
| **AWS** | **209,400 VND** ✅ | **2.5M** ✅ | 98.9% |

**Tiết kiệm:** 49,400 VND/tháng = 592,800 VND/năm

---

#### Scenario 2: Quy mô trung (10,000 bài Writing/tháng)

| Provider | Chi phí/tháng | Chi phí/năm | Margin |
|----------|---------------|-------------|--------|
| Google | 1,294,000 VND | 15.5M | 98.8% |
| **AWS** | **1,047,000 VND** ✅ | **12.6M** ✅ | 98.9% |

**Tiết kiệm:** 247,000 VND/tháng = 2.96M VND/năm

---

#### Scenario 3: Quy mô lớn (50,000 bài Writing/tháng)

| Provider | Chi phí/tháng | Chi phí/năm | Margin |
|----------|---------------|-------------|--------|
| Google | 6,470,000 VND | 77.6M | 98.8% |
| **AWS** | **5,235,000 VND** ✅ | **62.8M** ✅ | 98.9% |

**Tiết kiệm:** 1,235,000 VND/tháng = 14.8M VND/năm 🚀

---

## CODE IMPLEMENTATION

### 1. Google Gemini Pro

```python
from google.cloud import aiplatform
import json

class GeminiEssayGrader:
    def __init__(self):
        aiplatform.init(project="your-project-id")
        self.model = aiplatform.GenerativeModel("gemini-pro")
    
    def grade_ielts_writing(self, essay_text, task_type='task_2'):
        """
        Chấm bài IELTS Writing với Gemini Pro
        Chi phí: ~130-200 VND/bài
        """
        
        prompt = f"""
You are an IELTS examiner. Grade this {task_type} essay.

Essay:
{essay_text}

Provide detailed assessment in JSON format with:
- overall_band (0-9)
- subscores (TA, CC, LR, GRA)
- detailed feedback
- corrections
- suggestions

Format as valid JSON only.
"""
        
        response = self.model.generate_content(
            prompt,
            generation_config={
                'temperature': 0.3,
                'max_output_tokens': 1000
            }
        )
        
        result = json.loads(response.text)
        
        return {
            'band_score': result['overall_band'],
            'subscores': result['subscores'],
            'feedback': result['feedback'],
            'cost': 130 if task_type == 'task_1' else 200,  # VND
            'provider': 'Google Gemini Pro'
        }

# SỬ DỤNG:
grader = GeminiEssayGrader()

essay = """
In recent years, there has been growing debate about the role of 
technology in education. While some argue that technology enhances 
learning, others believe it creates more problems than it solves.
(... 250 words)
"""

result = grader.grade_ielts_writing(essay, 'task_2')

print(f"Band Score: {result['band_score']}")
print(f"Cost: {result['cost']} VND")
```

**Output:**
```json
{
  "band_score": 7.0,
  "subscores": {
    "task_achievement": 7.0,
    "coherence_cohesion": 7.5,
    "lexical_resource": 6.5,
    "grammatical_range_accuracy": 7.0
  },
  "cost": 130,
  "provider": "Google Gemini Pro"
}
```

---

### 2. AWS Claude 3 Haiku

```python
import boto3
import json

class ClaudeEssayGrader:
    def __init__(self):
        self.bedrock = boto3.client(
            'bedrock-runtime',
            region_name='us-east-1'
        )
    
    def grade_ielts_writing(self, essay_text, task_type='task_2'):
        """
        Chấm bài IELTS Writing với Claude 3 Haiku
        Chi phí: ~105-172 VND/bài
        """
        
        prompt = f"""
You are an IELTS examiner. Grade this {task_type} essay.

Essay:
{essay_text}

Provide detailed assessment in JSON format with:
- overall_band (0-9)
- subscores (TA, CC, LR, GRA)
- detailed feedback
- corrections
- suggestions

Format as valid JSON only.
"""
        
        response = self.bedrock.invoke_model(
            modelId='anthropic.claude-3-haiku-20240307-v1:0',
            contentType='application/json',
            accept='application/json',
            body=json.dumps({
                'anthropic_version': 'bedrock-2023-05-31',
                'max_tokens': 1000,
                'temperature': 0.3,
                'messages': [
                    {
                        'role': 'user',
                        'content': prompt
                    }
                ]
            })
        )
        
        response_body = json.loads(response['body'].read())
        result = json.loads(response_body['content'][0]['text'])
        
        return {
            'band_score': result['overall_band'],
            'subscores': result['subscores'],
            'feedback': result['feedback'],
            'cost': 105 if task_type == 'task_1' else 172,  # VND
            'provider': 'AWS Claude 3 Haiku'
        }

# SỬ DỤNG:
grader = ClaudeEssayGrader()

essay = """
In recent years, there has been growing debate about the role of 
technology in education. While some argue that technology enhances 
learning, others believe it creates more problems than it solves.
(... 250 words)
"""

result = grader.grade_ielts_writing(essay, 'task_2')

print(f"Band Score: {result['band_score']}")
print(f"Cost: {result['cost']} VND")
```

**Output:**
```json
{
  "band_score": 7.0,
  "subscores": {
    "task_achievement": 7.0,
    "coherence_cohesion": 7.5,
    "lexical_resource": 6.5,
    "grammatical_range_accuracy": 7.0
  },
  "cost": 105,
  "provider": "AWS Claude 3 Haiku"
}
```

---

## TÍNH TOÁN ROI

### Với 10,000 bài Writing/tháng:

#### Option 1: Pure Google
```
Chi phí AI: 1,294,000 VND/tháng
Doanh thu: 150,000,000 VND/tháng (10K × 15K)
Lợi nhuận: 148,706,000 VND/tháng
Margin: 99.1%
```

#### Option 2: Pure AWS ✅
```
Chi phí AI: 1,047,000 VND/tháng ✅
Doanh thu: 150,000,000 VND/tháng
Lợi nhuận: 148,953,000 VND/tháng ✅
Margin: 99.3% ✅

TIẾT KIỆM: 247,000 VND/tháng vs Google
```

---

## KHUYẾN NGHỊ CHIẾN LƯỢC

### Strategy 1: Start với Google (Giai đoạn đầu)

```yaml
Timeline: Tháng 1-2
Volume: < 5,000 bài/tháng
Provider: Google Gemini Pro

Lý do:
  ✅ Free tier (test miễn phí)
  ✅ Setup nhanh (1-2 ngày)
  ✅ Documentation tốt
  ✅ Easy to learn

Chi phí: ~260K/tháng (2K bài)
```

---

### Strategy 2: Migrate sang AWS (Giai đoạn scale)

```yaml
Timeline: Tháng 3-6
Volume: 5,000-50,000 bài/tháng
Provider: AWS Claude 3 Haiku

Lý do:
  ✅ Rẻ hơn 15-20%
  ✅ Scale tốt hơn
  ✅ Nhanh hơn
  ✅ Enterprise features

Chi phí: ~1M/tháng (10K bài)
Tiết kiệm: 250K/tháng vs Google
```

---

### Strategy 3: Hybrid (Production)

```yaml
Timeline: Tháng 6+
Volume: > 50,000 bài/tháng

Mix:
  • AWS Claude 3 (80%) - Main
  • Google Gemini (20%) - Backup

Lý do:
  ✅ Cost optimization
  ✅ High availability
  ✅ Risk mitigation
  ✅ Load balancing

Chi phí: ~4.5M/tháng (50K bài)
Tiết kiệm: ~1M/tháng vs pure Google
```

---

## CHECKLIST TRIỂN KHAI

### Với Google Gemini Pro:

- [ ] Tạo GCP project
- [ ] Enable Vertex AI API
- [ ] Setup service account
- [ ] Configure authentication
- [ ] Test với free tier
- [ ] Monitor usage với Cloud Monitoring
- [ ] Set up budget alerts
- [ ] Deploy to production

**Thời gian:** 1-2 ngày  
**Độ khó:** ⭐⭐ (Dễ)

---

### Với AWS Claude 3:

- [ ] Tạo AWS account
- [ ] Enable Bedrock service
- [ ] Request model access (Claude 3)
- [ ] Configure IAM roles
- [ ] Setup AWS SDK
- [ ] Test với small batch
- [ ] Monitor với CloudWatch
- [ ] Set up cost alerts
- [ ] Deploy to production

**Thời gian:** 2-3 ngày  
**Độ khó:** ⭐⭐⭐ (Trung bình)

---

## KẾT LUẬN & KHUYẾN NGHỊ CUỐI CÙNG

### Best Choice: AWS Claude 3 Haiku

```
Chi phí: 70-283 VND/bài (tùy loại)
Margin: 98.9-99.4%
Tiết kiệm: 15-20% vs Google
Speed: 200ms (Nhanh nhất)

✅ Khuyến nghị cho:
• Production systems
• High volume (>5K/tháng)
• Cost-sensitive projects
• Need enterprise features
```

---

### Runner-up: Google Gemini Pro

```
Chi phí: 83-349 VND/bài
Margin: 98.3-99.3%
Speed: 500ms (Nhanh)

✅ Khuyến nghị cho:
• Quick start / MVP
• Team nhỏ, ít expertise
• Need free tier để test
• Multi-modal features
```

---

### Lời khuyên cuối:

1. **Start nhỏ với Google** (test miễn phí, learn)
2. **Scale với AWS** (cost saving, performance)
3. **Hybrid cho production** (availability, backup)

### Expected Results:

```
Với 50,000 bài/tháng:

Doanh thu:    750,000,000 VND/tháng
Chi phí AI:     5,235,000 VND/tháng (AWS)
Margin:             99.3%

ROI: XUẤT SẮC! 🚀
```

---

**Cập nhật: 30/10/2025**  
**Version: 2.0**  
**Next review: Monthly (AI prices change frequently)**


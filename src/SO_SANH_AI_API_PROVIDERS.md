# SO SÁNH CHI PHÍ API AI - GOOGLE vs AMAZON vs OPENAI

## 🎯 MỤC ĐÍCH
So sánh chi phí sử dụng các nền tảng AI để chấm bài tự luận (Writing/Speaking 300 từ):
- **OpenAI** (GPT-4, GPT-3.5)
- **Google Cloud** (Gemini, Vertex AI)
- **Amazon AWS** (Bedrock, Comprehend)

---

## 💰 BẢNG GIÁ API (Tháng 10/2025)

### **1. OpenAI API**

| Model | Input (per 1M tokens) | Output (per 1M tokens) | Use Case |
|-------|----------------------|------------------------|----------|
| **GPT-4 Turbo** | $10.00 | $30.00 | Best quality |
| **GPT-4** | $30.00 | $60.00 | Premium quality |
| **GPT-3.5 Turbo** | $0.50 | $1.50 | Good balance |
| **GPT-3.5 Turbo 16K** | $3.00 | $4.00 | Long context |

### **2. Google Cloud AI**

| Model | Input (per 1M tokens) | Output (per 1M tokens) | Use Case |
|-------|----------------------|------------------------|----------|
| **Gemini Pro** | $0.50 | $1.50 | Best value ⭐ |
| **Gemini Pro Vision** | $0.25 | $1.25 | Multimodal |
| **PaLM 2 Text** | $0.50 | $1.50 | Text only |
| **Chirp (Speech)** | $0.006/min | - | Speech recognition |

**🎁 Free tier:** 60 requests/minute miễn phí!

### **3. Amazon AWS Bedrock**

| Model | Input (per 1M tokens) | Output (per 1M tokens) | Use Case |
|-------|----------------------|------------------------|----------|
| **Claude 3 Sonnet** | $3.00 | $15.00 | Best for writing |
| **Claude 3 Haiku** | $0.25 | $1.25 | Fastest & cheapest ⭐ |
| **Titan Text Express** | $0.20 | $0.60 | AWS native |
| **Jurassic-2 Ultra** | $15.00 | $15.00 | Premium |

**📊 Additional AWS Services:**
- **Amazon Comprehend**: $0.0001 per unit (sentiment, entities)
- **Amazon Transcribe**: $0.024/minute (speech to text)

---

## 📝 TÍNH TOÁN CHI PHÍ CHO BÀI TỰ LUẬN 300 TỪ

### **Giả định:**
- Input: 300 words ≈ 400 tokens
- Output (feedback): ≈ 500 tokens
- Total processing: 900 tokens per essay

---

### **SCENARIO 1: Tiếng Anh (300 words)**

#### **A. OpenAI GPT-4 Turbo**
```
Input:  400 tokens × $10/1M  = $0.004 (100 VND)
Output: 500 tokens × $30/1M  = $0.015 (375 VND)
Grammar API (Grammarly):      = $0.010 (250 VND)
Scoring calculation:          = $0.005 (125 VND)
──────────────────────────────────────────────
TOTAL per essay:              = $0.034 (850 VND)

Additional costs:
• Server processing:            100 VND
• Storage:                      50 VND
──────────────────────────────────────────────
TOTAL COST:                     1,000 VND/bài
Margin: 93.3% (với giá 15K)
```

#### **B. Google Gemini Pro** ⭐ KHUYẾN NGHỊ
```
Input:  400 tokens × $0.5/1M = $0.0002 (5 VND)
Output: 500 tokens × $1.5/1M = $0.00075 (19 VND)
Grammar API (Language Tool):  = $0.002 (50 VND)
Scoring calculation:          = $0.002 (50 VND)
──────────────────────────────────────────────
TOTAL per essay:              = $0.00495 (124 VND)

Additional costs:
• Server processing:            100 VND
• Storage:                      50 VND
──────────────────────────────────────────────
TOTAL COST:                     274 VND/bài ✅
Margin: 98.2% (với giá 15K)
```

**→ Google RẺ HƠN OpenAI 73%!**

#### **C. AWS Claude 3 Haiku**
```
Input:  400 tokens × $0.25/1M = $0.0001 (2.5 VND)
Output: 500 tokens × $1.25/1M = $0.000625 (16 VND)
Amazon Comprehend (sentiment): = $0.0001 (2.5 VND)
Scoring calculation:           = $0.002 (50 VND)
──────────────────────────────────────────────
TOTAL per essay:               = $0.002725 (68 VND)

Additional costs:
• Server processing:            100 VND
• Storage:                      50 VND
──────────────────────────────────────────────
TOTAL COST:                     218 VND/bài ✅✅
Margin: 98.5% (với giá 15K)
```

**→ AWS RẺ NHẤT! (78% rẻ hơn OpenAI)**

---

### **SCENARIO 2: Tiếng Hàn (300 ký tự ≈ 900 tokens)**

#### **A. OpenAI GPT-4 Turbo**
```
Input:  900 tokens × $10/1M  = $0.009 (225 VND)
Output: 600 tokens × $30/1M  = $0.018 (450 VND)
Korean Grammar API:           = $0.015 (375 VND)
Scoring calculation:          = $0.008 (200 VND)
──────────────────────────────────────────────
TOTAL per essay:              = $0.050 (1,250 VND)

Additional costs:
• Server processing:            150 VND
• Storage:                      100 VND
──────────────────────────────────────────────
TOTAL COST:                     1,500 VND/bài
Margin: 89.3% (với giá 14K)
```

#### **B. Google Gemini Pro (Multilingual)**
```
Input:  900 tokens × $0.5/1M = $0.00045 (11 VND)
Output: 600 tokens × $1.5/1M = $0.0009 (23 VND)
Korean Grammar API:           = $0.005 (125 VND)
Scoring calculation:          = $0.003 (75 VND)
──────────────────────────────────────────────
TOTAL per essay:              = $0.00935 (234 VND)

Additional costs:
• Server processing:            150 VND
• Storage:                      100 VND
──────────────────────────────────────────────
TOTAL COST:                     484 VND/bài ✅
Margin: 96.5% (với giá 14K)
```

**→ Google RẺ HƠN OpenAI 68%!**

#### **C. AWS Claude 3 Haiku**
```
Input:  900 tokens × $0.25/1M = $0.000225 (5.6 VND)
Output: 600 tokens × $1.25/1M = $0.00075 (19 VND)
Amazon Comprehend:            = $0.0002 (5 VND)
Scoring calculation:          = $0.003 (75 VND)
──────────────────────────────────────────────
TOTAL per essay:              = $0.004 (100 VND)

Additional costs:
• Server processing:            150 VND
• Storage:                      100 VND
──────────────────────────────────────────────
TOTAL COST:                     350 VND/bài ✅✅
Margin: 97.5% (với giá 14K)
```

**→ AWS RẺ NHẤT cho tiếng Hàn! (77% rẻ hơn OpenAI)**

---

## 📊 BẢNG SO SÁNH TỔNG HỢP

### **Tiếng Anh (300 words):**

| Provider | Model | Chi phí/bài | So với OpenAI | Margin (giá 15K) | Recommendation |
|----------|-------|-------------|---------------|------------------|----------------|
| **OpenAI** | GPT-4 Turbo | 1,000 VND | Base | 93.3% | Good |
| **Google** | Gemini Pro | 274 VND | -73% ⭐ | 98.2% | Better |
| **AWS** | Claude Haiku | 218 VND | -78% ⭐⭐ | 98.5% | **Best** |

### **Tiếng Hàn (300 ký tự):**

| Provider | Model | Chi phí/bài | So với OpenAI | Margin (giá 14K) | Recommendation |
|----------|-------|-------------|---------------|------------------|----------------|
| **OpenAI** | GPT-4 Turbo | 1,500 VND | Base | 89.3% | Good |
| **Google** | Gemini Pro | 484 VND | -68% ⭐ | 96.5% | Better |
| **AWS** | Claude Haiku | 350 VND | -77% ⭐⭐ | 97.5% | **Best** |

---

## 🎯 PHÂN TÍCH CHI TIẾT TỪNG PLATFORM

### **1. OpenAI (GPT-4 Turbo, GPT-3.5)**

#### **Ưu điểm:**
- ✅ Chất lượng tốt nhất (GPT-4)
- ✅ API ổn định, documentation tốt
- ✅ Cộng đồng lớn, nhiều resources
- ✅ Fine-tuning dễ dàng
- ✅ Support tiếng Việt, Hàn tốt

#### **Nhược điểm:**
- ❌ **Giá đắt nhất** (10-30x so với Google/AWS)
- ❌ Rate limits nghiêm ngặt
- ❌ Không có free tier
- ❌ Latency cao (1-3s)

#### **Chi phí ước tính:**
```
1,000 bài thi/tháng:
• Tiếng Anh: 1,000,000 VND
• Tiếng Hàn: 1,500,000 VND
```

#### **Use case:**
- Premium tier (học viên sẵn sàng trả giá cao)
- Complex essays (>500 words)
- When quality is critical

---

### **2. Google Cloud AI (Gemini Pro)** ⭐ KHUYẾN NGHỊ

#### **Ưu điểm:**
- ✅ **Giá rẻ** (73% rẻ hơn OpenAI)
- ✅ **Free tier hào phóng** (60 requests/minute)
- ✅ Latency thấp (~500ms)
- ✅ Multimodal (text + image)
- ✅ Support multilingual tốt
- ✅ Integration với GCP ecosystem
- ✅ Auto-scaling tốt

#### **Nhược điểm:**
- ❌ Chất lượng hơi kém GPT-4 (nhưng vẫn tốt)
- ❌ Documentation chưa đầy đủ bằng OpenAI
- ❌ Cộng đồng nhỏ hơn

#### **Chi phí ước tính:**
```
1,000 bài thi/tháng:
• Tiếng Anh: 274,000 VND ✅
• Tiếng Hàn: 484,000 VND ✅

10,000 bài thi/tháng:
• Tiếng Anh: 2,740,000 VND ✅
• Tiếng Hàn: 4,840,000 VND ✅
```

#### **Use case:**
- **Main product** - Standard tier
- High volume grading (>1,000 essays/day)
- Multilingual support
- Budget-conscious projects

#### **Technical Setup:**
```python
# Google Vertex AI - Gemini Pro
from google.cloud import aiplatform

def grade_essay_gemini(essay_text):
    model = aiplatform.GenerativeModel("gemini-pro")
    
    prompt = f"""
    Grade this essay and provide feedback:
    Essay: {essay_text}
    
    Provide:
    1. Band score (0-9)
    2. Grammar feedback
    3. Content feedback
    4. Suggestions for improvement
    """
    
    response = model.generate_content(prompt)
    
    # Cost: ~274 VND per essay
    return response.text
```

---

### **3. Amazon AWS (Bedrock - Claude 3)** ⭐⭐ RẺ NHẤT

#### **Ưu điểm:**
- ✅ **Giá RẺ NHẤT** (78% rẻ hơn OpenAI)
- ✅ **Claude 3 Haiku cực nhanh** (~200ms)
- ✅ Integration với AWS ecosystem tốt
- ✅ Security & compliance tốt
- ✅ Nhiều model lựa chọn (Claude, Titan, Jurassic)
- ✅ Amazon Comprehend rẻ ($0.0001/unit)
- ✅ Auto-scaling AWS Lambda

#### **Nhược điểm:**
- ❌ Setup phức tạp hơn
- ❌ Cần AWS expertise
- ❌ Documentation scattered
- ❌ Region limitations (chưa có VN)

#### **Chi phí ước tính:**
```
1,000 bài thi/tháng:
• Tiếng Anh: 218,000 VND ✅✅
• Tiếng Hàn: 350,000 VND ✅✅

10,000 bài thi/tháng:
• Tiếng Anh: 2,180,000 VND ✅✅
• Tiếng Hàn: 3,500,000 VND ✅✅
```

#### **Use case:**
- **High volume** (>10,000 essays/day)
- **Cost optimization** priority
- Already using AWS infrastructure
- Need enterprise features

#### **Technical Setup:**
```python
# AWS Bedrock - Claude 3 Haiku
import boto3

def grade_essay_claude(essay_text):
    bedrock = boto3.client('bedrock-runtime')
    
    prompt = f"""
    Grade this essay and provide feedback:
    {essay_text}
    
    Provide band score and detailed feedback.
    """
    
    response = bedrock.invoke_model(
        modelId='anthropic.claude-3-haiku-20240307-v1:0',
        body={
            'prompt': prompt,
            'max_tokens': 500
        }
    )
    
    # Cost: ~218 VND per essay
    return response['completion']
```

---

## 💡 CHIẾN LƯỢC ĐA PROVIDER (HYBRID APPROACH)

### **Architecture đề xuất:**

```
┌─────────────────────────────────────────────────┐
│         LOAD BALANCER & ROUTER                  │
├─────────────────────────────────────────────────┤
│                                                 │
│  ┌──────────────┐  ┌──────────────┐            │
│  │   AWS        │  │   Google     │            │
│  │   Claude     │  │   Gemini     │            │
│  │   Haiku      │  │   Pro        │            │
│  │              │  │              │            │
│  │  70% volume  │  │  30% volume  │            │
│  │  218 VND/bài │  │  274 VND/bài │            │
│  └──────────────┘  └──────────────┘            │
│                                                 │
│  ┌──────────────────────────────┐              │
│  │   OpenAI GPT-4               │              │
│  │   (Fallback + Premium)       │              │
│  │   < 5% volume                │              │
│  │   1,000 VND/bài              │              │
│  └──────────────────────────────┘              │
│                                                 │
└─────────────────────────────────────────────────┘
```

### **Quy tắc routing:**

```python
class AIProviderRouter:
    def route_essay(self, essay, user_tier):
        # Premium users → OpenAI GPT-4
        if user_tier == 'premium':
            return self.grade_with_openai(essay)
        
        # Complex/long essays → Google Gemini
        if len(essay.split()) > 500:
            return self.grade_with_gemini(essay)
        
        # Standard essays → AWS Claude (cheapest)
        return self.grade_with_claude(essay)
    
    def handle_failure(self, provider, essay):
        # Fallback chain
        if provider == 'aws':
            return self.grade_with_gemini(essay)
        elif provider == 'google':
            return self.grade_with_openai(essay)
```

### **Lợi ích:**
1. ✅ **Redundancy** - Backup nếu một provider down
2. ✅ **Cost optimization** - Route đến provider rẻ nhất
3. ✅ **Load balancing** - Phân tải đều
4. ✅ **Quality tiers** - Match provider với user tier

---

## 💰 SO SÁNH CHI PHÍ THEO QUY MÔ

### **Scenario 1: Quy mô nhỏ (500 học viên)**
**2,000 bài thi/tháng**

| Provider | Chi phí/tháng | Chi phí/năm | Margin (giá TB 15K) |
|----------|---------------|-------------|---------------------|
| OpenAI | 2,000,000 VND | 24M | 93.3% |
| Google | 548,000 VND | 6.6M | 98.2% |
| **AWS** | **436,000 VND** ✅ | **5.2M** ✅ | **98.5%** |

**Tiết kiệm:** AWS rẻ hơn OpenAI **1.56M/tháng** (18.7M/năm)

---

### **Scenario 2: Quy mô trung (3,000 học viên)**
**15,000 bài thi/tháng**

| Provider | Chi phí/tháng | Chi phí/năm | Margin |
|----------|---------------|-------------|--------|
| OpenAI | 15,000,000 VND | 180M | 93.3% |
| Google | 4,110,000 VND | 49.3M | 98.2% |
| **AWS** | **3,270,000 VND** ✅ | **39.2M** ✅ | **98.5%** |

**Tiết kiệm:** AWS rẻ hơn OpenAI **11.73M/tháng** (140.8M/năm) 🚀

---

### **Scenario 3: Quy mô lớn (15,000 học viên)**
**90,000 bài thi/tháng**

| Provider | Chi phí/tháng | Chi phí/năm | Margin |
|----------|---------------|-------------|--------|
| OpenAI | 90,000,000 VND | 1.08 tỷ | 93.3% |
| Google | 24,660,000 VND | 295.9M | 98.2% |
| **AWS** | **19,620,000 VND** ✅ | **235.4M** ✅ | **98.5%** |

**Tiết kiệm:** AWS rẻ hơn OpenAI **70.38M/tháng** (844.6M/năm) 🚀🚀

---

## 🎯 KHUYẾN NGHỊ CUỐI CÙNG

### **✅ Strategy A: Pure AWS (BEST for Cost)** ⭐⭐⭐

```yaml
Main provider: AWS Claude 3 Haiku (90%)
Backup: Google Gemini Pro (10%)

Pros:
  - Giá rẻ nhất (218-350 VND/bài)
  - Margin cao nhất (98.5%)
  - Tiết kiệm 70-78% vs OpenAI

Cons:
  - Setup phức tạp
  - Cần AWS expertise

Best for: 
  - Startup với budget eo hẹp
  - High volume (>10K essays/month)
```

### **✅ Strategy B: Pure Google (BEST for Balance)** ⭐⭐

```yaml
Main provider: Google Gemini Pro (100%)

Pros:
  - Giá rẻ (274-484 VND/bài)
  - Setup dễ dàng
  - Free tier hào phóng
  - Multimodal capabilities

Cons:
  - Đắt hơn AWS 25%

Best for:
  - Team nhỏ, dev ít experience
  - Cần deploy nhanh
  - Đa ngôn ngữ
```

### **✅ Strategy C: Hybrid (BEST for Production)** ⭐⭐⭐

```yaml
Main: AWS Claude Haiku (70%)
Secondary: Google Gemini (25%)
Premium: OpenAI GPT-4 (5%)

Pros:
  - Cost-effective
  - High availability
  - Quality tiering
  - Risk mitigation

Cons:
  - Complex architecture
  - Need DevOps

Best for:
  - Production system
  - Scale > 5K users
  - Enterprise requirements
```

---

## 📋 IMPLEMENTATION ROADMAP

### **Phase 1: MVP (Tháng 1-2)**
```
✅ Start với Google Gemini Pro
   - Dễ setup
   - Free tier
   - Documentation tốt
   
Cost: ~274 VND/bài
Expected volume: 2,000 bài/tháng
Monthly cost: 548K VND
```

### **Phase 2: Optimization (Tháng 3-6)**
```
✅ Migrate main traffic sang AWS Claude
✅ Giữ Google làm backup
   
Cost: ~218 VND/bài (AWS) + 274 VND/bài (Google backup)
Expected volume: 15,000 bài/tháng
Monthly cost: 3.27M VND (AWS 70%) + 1.23M = 4.5M VND
```

### **Phase 3: Scale (Tháng 7+)**
```
✅ Hybrid model hoàn chỉnh
✅ Add OpenAI cho Premium tier
   
Cost: Mixed
Expected volume: 90,000 bài/tháng
Monthly cost: ~20M VND
Save: 70M/tháng vs pure OpenAI
```

---

## 🔧 TECHNICAL COMPARISON

| Feature | OpenAI | Google | AWS |
|---------|--------|--------|-----|
| **Latency** | 1-3s | 500ms | 200ms ⭐ |
| **Max tokens** | 128K | 32K | 200K ⭐ |
| **Rate limits** | Strict | Generous | Very high ⭐ |
| **Free tier** | ❌ | ✅ 60 req/min | ❌ |
| **SLA** | 99.9% | 99.9% | 99.95% ⭐ |
| **Support** | Good | Good | Enterprise ⭐ |
| **Monitoring** | Basic | Good | Excellent ⭐ |

---

## ✅ KẾT LUẬN

### **Top 3 Recommendations:**

1. **🥇 AWS Claude 3 Haiku** (RẺ NHẤT)
   - Chi phí: 218-350 VND/bài
   - Tiết kiệm: 78% vs OpenAI
   - Best for: High volume, cost-sensitive

2. **🥈 Google Gemini Pro** (CÂN BẰNG)
   - Chi phí: 274-484 VND/bài
   - Tiết kiệm: 73% vs OpenAI
   - Best for: Quick start, easy setup

3. **🥉 OpenAI GPT-4 Turbo** (CHẤT LƯỢNG)
   - Chi phí: 1,000-1,500 VND/bài
   - Best for: Premium tier, complex essays

### **💡 Final Recommendation:**

```
Start: Google Gemini Pro (easy setup)
Scale: Migrate to AWS Claude (cost saving)
Premium: Add OpenAI GPT-4 (quality)
```

**Expected total savings: 70-80% vs pure OpenAI approach!**

---

**Version:** 1.0  
**Last Updated:** 30/10/2025  
**Next Review:** Check pricing monthly (AI prices change frequently)


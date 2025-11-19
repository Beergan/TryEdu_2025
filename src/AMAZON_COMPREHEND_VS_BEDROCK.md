# AMAZON COMPREHEND vs BEDROCK - CHẤM BÀI LUẬN VĂN

## ⚠️ QUAN TRỌNG: Amazon Comprehend ≠ Chấm bài luận

### **Amazon Comprehend là gì?**

Amazon Comprehend là dịch vụ **NLP cơ bản** (Natural Language Processing) để phân tích text, **KHÔNG phải** để chấm bài và đưa feedback:

```
Amazon Comprehend CÓ THỂ:
✅ Trích xuất từ khóa (Key Phrase Extraction)
✅ Phân tích cảm xúc (Sentiment Analysis)
✅ Nhận dạng thực thể (Entity Recognition)
✅ Phát hiện ngôn ngữ (Language Detection)
✅ Phân tích cú pháp (Syntax Analysis)

Amazon Comprehend KHÔNG THỂ:
❌ Chấm điểm bài luận
❌ Đưa feedback chi tiết
❌ Đánh giá grammar phức tạp
❌ Đánh giá coherence, cohesion
❌ Tạo suggestions cải thiện
```

---

## 🔍 PHÂN TÍCH CHI TIẾT

### **1. Amazon Comprehend (Từ hình ảnh của bạn)**

#### **Tính năng & Giá:**

```
┌─────────────────────────────────────────────────┐
│ AMAZON COMPREHEND - NLP CƠ BẢN                  │
├─────────────────────────────────────────────────┤
│ Giá (theo đơn vị = 100 ký tự):                 │
│                                                 │
│ • Trích xuất từ khóa:     $0.0001 USD          │
│ • Phân tích cảm xúc:      $0.0001 USD          │
│ • Nhận dạng thực thể:     $0.0001 USD          │
│ • Phát hiện ngôn ngữ:     $0.0001 USD          │
│ • Phân tích cú pháp:      $0.00005 USD         │
│                                                 │
│ → CỰC RẺ: ~2.5 VND/bài (300 từ)               │
└─────────────────────────────────────────────────┘
```

#### **Ví dụ sử dụng Comprehend cho bài 300 từ:**

```python
import boto3

comprehend = boto3.client('comprehend')

essay = """
My hometown is a small village in the countryside. 
It has beautiful mountains and rivers. 
People are very friendly and helpful.
(... 300 words total)
"""

# Chỉ có thể làm những việc CƠ BẢN:
sentiment = comprehend.detect_sentiment(
    Text=essay, 
    LanguageCode='en'
)
# → Result: "POSITIVE" (sentiment = tích cực)
# ❌ KHÔNG có band score, KHÔNG có feedback!

entities = comprehend.detect_entities(
    Text=essay,
    LanguageCode='en'
)
# → Result: ["hometown", "village", "countryside", "mountains"]
# ❌ KHÔNG đánh giá được vocabulary range!

key_phrases = comprehend.detect_key_phrases(
    Text=essay,
    LanguageCode='en'
)
# → Result: ["small village", "beautiful mountains"]
# ❌ KHÔNG đánh giá được coherence!
```

#### **Kết luận về Comprehend:**
```
Chi phí: 2.5 VND/bài (CỰC RẺ!)
Nhưng: KHÔNG THỂ dùng để chấm bài luận ❌

Lý do:
• Chỉ là NLP tools cơ bản
• Không có AI generative
• Không cho band score
• Không có feedback
• Không đánh giá grammar
```

---

## ✅ GIẢI PHÁP ĐÚNG: Amazon Bedrock

### **Amazon Bedrock là gì?**

Amazon Bedrock là nền tảng **Generative AI** với nhiều models mạnh mẽ:
- **Claude 3** (Anthropic) - Best for writing
- **Titan** (AWS) - Good balance
- **Jurassic-2** (AI21) - Premium

### **2. Amazon Bedrock - Claude 3 Haiku** ⭐ KHUYẾN NGHỊ

```
┌─────────────────────────────────────────────────┐
│ AMAZON BEDROCK - CLAUDE 3 HAIKU                 │
├─────────────────────────────────────────────────┤
│ Giá (per 1M tokens):                            │
│ • Input:   $0.25                                │
│ • Output:  $1.25                                │
│                                                 │
│ Cho bài 300 từ (900 tokens):                   │
│ • Input:  0.0004 tokens × $0.25 = $0.0001      │
│ • Output: 0.0005 tokens × $1.25 = $0.000625    │
│                                                 │
│ → 218 VND/bài ✅                                │
│ → CÓ ĐẦY ĐỦ: Score + Feedback + Suggestions    │
└─────────────────────────────────────────────────┘
```

#### **Ví dụ sử dụng Bedrock Claude 3:**

```python
import boto3
import json

bedrock = boto3.client('bedrock-runtime')

essay = """
My hometown is a small village in the countryside. 
It has beautiful mountains and rivers. 
People are very friendly and helpful.
(... 300 words total)
"""

# Prompt chi tiết để chấm bài
prompt = f"""
You are an IELTS examiner. Grade this essay and provide detailed feedback.

Essay: {essay}

Provide:
1. Overall Band Score (0-9)
2. Task Achievement score
3. Coherence and Cohesion score
4. Lexical Resource score
5. Grammatical Range and Accuracy score
6. Detailed feedback for each criterion
7. Specific suggestions for improvement
8. Example corrections

Format as JSON.
"""

response = bedrock.invoke_model(
    modelId='anthropic.claude-3-haiku-20240307-v1:0',
    body=json.dumps({
        'anthropic_version': 'bedrock-2023-05-31',
        'max_tokens': 1000,
        'messages': [
            {
                'role': 'user',
                'content': prompt
            }
        ]
    })
)

result = json.loads(response['body'].read())

# ✅ KẾT QUẢ ĐẦY ĐỦ:
print(result)
"""
{
  "overall_band": 6.5,
  "task_achievement": 6.0,
  "coherence_cohesion": 7.0,
  "lexical_resource": 6.5,
  "grammar": 6.5,
  "feedback": {
    "strengths": [
      "Clear topic sentences",
      "Good use of descriptive language"
    ],
    "weaknesses": [
      "Limited vocabulary range",
      "Some grammatical errors in complex sentences"
    ],
    "suggestions": [
      "Use more advanced vocabulary (e.g., 'picturesque' instead of 'beautiful')",
      "Vary sentence structures more"
    ]
  },
  "corrections": [
    {
      "original": "People are very friendly",
      "corrected": "The locals are exceptionally welcoming",
      "explanation": "More sophisticated vocabulary"
    }
  ]
}
"""
```

---

## 📊 SO SÁNH COMPREHEND vs BEDROCK

| Tiêu chí | Amazon Comprehend | Amazon Bedrock (Claude 3) |
|----------|-------------------|---------------------------|
| **Mục đích** | NLP cơ bản | Generative AI chấm bài |
| **Chi phí** | 2.5 VND/bài | 218 VND/bài |
| **Chấm điểm** | ❌ Không | ✅ Band score chi tiết |
| **Feedback** | ❌ Không | ✅ Feedback đầy đủ |
| **Grammar check** | ❌ Cơ bản | ✅ Chi tiết |
| **Suggestions** | ❌ Không | ✅ Có |
| **Coherence** | ❌ Không | ✅ Có |
| **Vocabulary** | ❌ Chỉ list từ | ✅ Đánh giá range |
| | | |
| **KẾT LUẬN** | ❌ Không phù hợp | ✅ RẤT PHÙ HỢP |

---

## 💡 TẠI SAO COMPREHEND KHÔNG PHÙ HỢP?

### **1. Comprehend chỉ phân tích, không đánh giá:**

```
Bài viết: "My hometown is beautiful. It has mountains."

Comprehend output:
{
  "sentiment": "POSITIVE",
  "entities": ["hometown", "mountains"],
  "key_phrases": ["My hometown", "beautiful", "mountains"]
}

❌ Không có:
• Band score
• Grammar feedback
• Coherence assessment
• Vocabulary evaluation
• Improvement suggestions
```

### **2. Comprehend thiếu context hiểu biết:**

```
Bài viết có lỗi grammar: "People is very friendly"

Comprehend:
• Detect entities: ["People"]
• ❌ KHÔNG phát hiện lỗi "is" → "are"

Bedrock Claude 3:
• ✅ Phát hiện lỗi
• ✅ Giải thích: "Subject-verb agreement error"
• ✅ Correction: "People are very friendly"
```

### **3. Comprehend không hiểu IELTS criteria:**

```
IELTS cần đánh giá:
• Task Achievement
• Coherence & Cohesion
• Lexical Resource
• Grammatical Range & Accuracy

Comprehend: ❌ Không có khái niệm này
Bedrock: ✅ Được training với IELTS criteria
```

---

## 🎯 HYBRID APPROACH: Kết hợp cả 2

### **Option: Dùng Comprehend làm preprocessing, Bedrock làm main grading**

```python
class HybridEssayGrader:
    def __init__(self):
        self.comprehend = boto3.client('comprehend')
        self.bedrock = boto3.client('bedrock-runtime')
    
    def grade_essay(self, essay_text):
        # Step 1: Comprehend phân tích cơ bản (RẺ - 2.5 VND)
        basic_analysis = self.comprehend_analysis(essay_text)
        
        # Nếu bài viết quá ngắn hoặc quá đơn giản → từ chối luôn
        if basic_analysis['word_count'] < 150:
            return {
                'score': 0,
                'error': 'Essay too short (minimum 150 words)'
            }
        
        # Step 2: Bedrock chấm chi tiết (218 VND)
        detailed_grading = self.bedrock_grading(essay_text)
        
        return detailed_grading
    
    def comprehend_analysis(self, text):
        # Phân tích cơ bản để filter
        sentiment = self.comprehend.detect_sentiment(
            Text=text,
            LanguageCode='en'
        )
        
        entities = self.comprehend.detect_entities(
            Text=text,
            LanguageCode='en'
        )
        
        return {
            'word_count': len(text.split()),
            'sentiment': sentiment['Sentiment'],
            'entity_count': len(entities['Entities']),
            'cost': 2.5  # VND
        }
    
    def bedrock_grading(self, text):
        # Chấm chi tiết với Claude 3
        response = self.bedrock.invoke_model(
            modelId='anthropic.claude-3-haiku-20240307-v1:0',
            body={...}  # Full grading prompt
        )
        
        return {
            'band_score': 6.5,
            'detailed_feedback': {...},
            'cost': 218  # VND
        }
```

**Chi phí:** 2.5 + 218 = **220.5 VND/bài** (chênh lệch không đáng kể)

**Kết luận:** Không cần thiết! Comprehend không giúp ích nhiều.

---

## ✅ KHUYẾN NGHỊ CUỐI CÙNG

### **🎯 Dùng Amazon Bedrock - Claude 3 Haiku**

```yaml
Model: Claude 3 Haiku
Provider: Amazon Bedrock
Chi phí: 218 VND/bài

Tại sao:
  ✅ Giá RẺ (78% rẻ hơn OpenAI)
  ✅ Chất lượng TỐT (đủ cho IELTS/TOEFL)
  ✅ Nhanh (~200ms)
  ✅ Đầy đủ tính năng chấm bài
  ✅ AWS ecosystem integration

Không dùng:
  ❌ Amazon Comprehend (không phù hợp chấm bài)
```

---

## 💰 BẢNG GIÁ TỔNG HỢP AWS

### **1. Amazon Comprehend** (NLP cơ bản)

| Tính năng | Giá/đơn vị | Giá/300 từ | Phù hợp? |
|-----------|------------|------------|----------|
| Sentiment Analysis | $0.0001 | 2.5 VND | ❌ |
| Entity Recognition | $0.0001 | 2.5 VND | ❌ |
| Key Phrase | $0.0001 | 2.5 VND | ❌ |
| Syntax Analysis | $0.00005 | 1.25 VND | ❌ |

**Tổng:** ~10 VND/bài (nếu dùng tất cả features)
**Kết luận:** RẺ nhưng KHÔNG THỂ chấm bài ❌

---

### **2. Amazon Bedrock** (Generative AI)

| Model | Input | Output | Giá/300 từ | Phù hợp? |
|-------|-------|--------|------------|----------|
| **Claude 3 Haiku** | $0.25/1M | $1.25/1M | **218 VND** | ✅✅ **BEST** |
| Claude 3 Sonnet | $3.00/1M | $15.00/1M | 2,700 VND | ✅ Premium |
| Titan Text Express | $0.20/1M | $0.60/1M | 120 VND | ✅ Budget |
| Jurassic-2 Ultra | $15.00/1M | $15.00/1M | 4,500 VND | ✅ High-end |

**Khuyến nghị:** Claude 3 Haiku - Balance tốt nhất!

---

### **3. Amazon Transcribe** (Speech to Text)

| Tính năng | Giá | Use case |
|-----------|-----|----------|
| Standard | $0.024/phút | Speaking test |
| Medical | $0.048/phút | Medical essays |

**Cho IELTS Speaking (10-15 phút):**
- Chi phí: 10 × $0.024 = $0.24 = **6,000 VND**
- Kết hợp với Claude 3: 6,000 + 218 = **6,218 VND/bài**

---

## 🔧 CODE IMPLEMENTATION

### **❌ SAI: Dùng Comprehend để chấm bài**

```python
# CÁCH NÀY KHÔNG HOẠT ĐỘNG!
import boto3

comprehend = boto3.client('comprehend')

essay = "My hometown is beautiful..."

# Chỉ được phân tích cơ bản
sentiment = comprehend.detect_sentiment(Text=essay, LanguageCode='en')
print(sentiment)  
# → {'Sentiment': 'POSITIVE', 'Score': 0.95}
# ❌ Không có band score, không có feedback!

entities = comprehend.detect_entities(Text=essay, LanguageCode='en')
print(entities)
# → ['hometown', 'mountains', 'rivers']
# ❌ Không đánh giá được vocabulary!

# KẾT LUẬN: KHÔNG THỂ DÙNG ĐỂ CHẤM BÀI!
```

---

### **✅ ĐÚNG: Dùng Bedrock Claude 3**

```python
import boto3
import json

class AWSEssayGrader:
    def __init__(self):
        self.bedrock = boto3.client(
            'bedrock-runtime',
            region_name='us-east-1'
        )
    
    def grade_ielts_essay(self, essay_text, task_type='writing_task_2'):
        """
        Chấm bài IELTS Writing
        Chi phí: ~218 VND/bài
        """
        
        prompt = self._build_ielts_prompt(essay_text, task_type)
        
        response = self.bedrock.invoke_model(
            modelId='anthropic.claude-3-haiku-20240307-v1:0',
            contentType='application/json',
            accept='application/json',
            body=json.dumps({
                'anthropic_version': 'bedrock-2023-05-31',
                'max_tokens': 1500,
                'temperature': 0.3,  # Consistent grading
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
            'overall_band': result['overall_band'],
            'subscores': result['subscores'],
            'feedback': result['feedback'],
            'corrections': result['corrections'],
            'cost': 218  # VND
        }
    
    def _build_ielts_prompt(self, essay, task_type):
        return f"""
You are an experienced IELTS examiner. Grade this essay according to official IELTS criteria.

Essay:
{essay}

Provide your assessment in JSON format:
{{
    "overall_band": 6.5,
    "subscores": {{
        "task_achievement": 6.0,
        "coherence_cohesion": 7.0,
        "lexical_resource": 6.5,
        "grammatical_range_accuracy": 6.5
    }},
    "feedback": {{
        "strengths": ["point 1", "point 2"],
        "weaknesses": ["point 1", "point 2"],
        "task_response_analysis": "...",
        "coherence_analysis": "...",
        "vocabulary_analysis": "...",
        "grammar_analysis": "..."
    }},
    "corrections": [
        {{
            "line": 3,
            "error": "People is friendly",
            "correction": "People are friendly",
            "explanation": "Subject-verb agreement"
        }}
    ],
    "suggestions": [
        "Use more varied linking words",
        "Develop paragraphs more fully"
    ]
}}
"""

# SỬ DỤNG:
grader = AWSEssayGrader()

essay = """
Some people believe that universities should provide students with 
practical skills needed for employment. Others think the true function 
of a university should be to give access to knowledge for its own sake.
Discuss both views and give your opinion.

In recent years, there has been debate about the purpose of higher 
education. While some argue that universities should focus on practical 
skills for the workplace, I believe they should balance both practical 
training and theoretical knowledge.
(... continue for 250-300 words)
"""

result = grader.grade_ielts_essay(essay)

print(f"Band Score: {result['overall_band']}")
print(f"Cost: {result['cost']} VND")
print(f"\nFeedback:\n{json.dumps(result['feedback'], indent=2)}")
```

**Output:**
```json
{
  "overall_band": 6.5,
  "subscores": {
    "task_achievement": 6.0,
    "coherence_cohesion": 7.0,
    "lexical_resource": 6.5,
    "grammatical_range_accuracy": 6.5
  },
  "feedback": {
    "strengths": [
      "Clear position stated in introduction",
      "Good paragraph organization",
      "Appropriate use of linking words"
    ],
    "weaknesses": [
      "Limited range of vocabulary",
      "Some ideas need further development",
      "Minor grammatical errors in complex sentences"
    ]
  },
  "cost": 218
}
```

---

## 📊 KẾT LUẬN

### **TÓM TẮT:**

| Service | Chi phí | Chấm bài được? | Khuyến nghị |
|---------|---------|----------------|-------------|
| **Amazon Comprehend** | 2.5 VND | ❌ KHÔNG | ❌ Không dùng |
| **Amazon Bedrock (Claude 3)** | 218 VND | ✅ CÓ | ✅✅ **DÙNG CÁI NÀY** |
| Amazon Transcribe | 6,000 VND | - | ✅ Cho Speaking |

### **KHUYẾN NGHỊ:**

```
✅ DÙNG: Amazon Bedrock - Claude 3 Haiku
   • Chi phí: 218 VND/bài
   • Chất lượng: Tốt
   • Đầy đủ tính năng chấm bài

❌ KHÔNG DÙNG: Amazon Comprehend
   • Không phù hợp chấm bài
   • Chỉ là NLP tools cơ bản
   • Thiếu features cần thiết
```

### **WORKFLOW ĐỀ XUẤT:**

```
1. Writing Essay:
   ├─ Text input → Bedrock Claude 3 → Full grading
   └─ Cost: 218 VND/bài

2. Speaking Test:
   ├─ Audio → Transcribe (6,000 VND)
   ├─ Text → Bedrock Claude 3 (218 VND)
   └─ Total: 6,218 VND/bài

3. Reading/Listening (Trắc nghiệm):
   ├─ Hệ thống chấm tự động
   └─ Cost: 50 VND/bài
```

---

**Cập nhật: 30/10/2025**
**Version: 1.0**

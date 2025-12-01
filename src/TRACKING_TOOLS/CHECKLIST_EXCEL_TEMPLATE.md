# 📊 EXCEL CHECKLIST TEMPLATE - CÓ THỂ TÍCH CHỌN

## 🎯 MỤC ĐÍCH
File này hướng dẫn tạo Excel với **checkbox thực sự** có thể tích được, tự động tính progress!

---

## 📋 PHƯƠNG ÁN 1: EXCEL VỚI CHECKBOX (KHUYẾN NGHỊ)

### Bước 1: Tạo File Excel Mới
1. Mở Excel
2. Save as: `TryEdu_Checklist.xlsx`

### Bước 2: Enable Developer Tab
```
File → Options → Customize Ribbon
☑ Check "Developer"
Click OK
```

### Bước 3: Tạo Cấu Trúc Bảng

**Sheet 1: WEEK 1 - FOUNDATION**

| A | B | C | D | E | F | G | H |
|---|---|---|---|---|---|---|---|
| **✓** | **Task ID** | **Task Name** | **Module** | **Assigned** | **Hours** | **Status** | **Progress** |
| ☐ | T001 | Review cấu trúc module | Foundation | Phong | 4 | Not Started | 0% |
| ☐ | T002 | Thiết kế kiến trúc V2.0 | Foundation | Phong | 8 | Not Started | 0% |

### Bước 4: Insert Checkbox

**Cách A: Form Control Checkbox (Đơn giản)**
```
1. Developer → Insert → Form Controls → Checkbox ☑
2. Click vào cell A2
3. Right-click checkbox → Format Control
4. Cell link: Chọn cell bên cạnh (ví dụ: I2)
5. Click OK
6. Copy checkbox xuống các rows khác
```

**Cách B: ActiveX Checkbox (Nâng cao)**
```
1. Developer → Insert → ActiveX Controls → Checkbox
2. Properties → LinkedCell: I2
3. Properties → Caption: (để trống)
4. Copy xuống các rows
```

### Bước 5: Công Thức Tự Động

**Cell H2 (Status tự động):**
```excel
=IF(I2=TRUE,"✅ Completed","⏳ Not Started")
```

**Cell H3 (Progress %):**
```excel
=IF(I2=TRUE,"100%","0%")
```

**Cell B1 (Tổng Progress):**
```excel
=COUNTIF(I:I,TRUE)/COUNTA(I:I)*100&"%"
```

**Cell C1 (Tasks Completed):**
```excel
=COUNTIF(I:I,TRUE)&" / "&COUNTA(I:I)
```

---

## 📋 PHƯƠNG ÁN 2: DROPDOWN CHECKLIST (DỄ HƠN)

### Bước 1: Tạo Dropdown List

**Cell A2:**
```
Data → Data Validation → List
Source: ☐,✅
```

### Bước 2: Conditional Formatting

**Select column A:**
```
Home → Conditional Formatting → New Rule
Format cells that contain: ✅
Format: Fill = Green, Font = Bold
```

### Bước 3: Công Thức

**Cell H2 (Status):**
```excel
=IF(A2="✅","Completed","Not Started")
```

**Progress Summary:**
```excel
=COUNTIF(A:A,"✅")/COUNTA(A:A)*100&"%"
```

---

## 📊 TEMPLATE EXCEL HOÀN CHỈNH

### Sheet Structure:

```
Sheet 1: DASHBOARD
Sheet 2: WEEK 1 - Foundation (49 tasks)
Sheet 3: WEEK 2 - Auth & Partner (42 tasks)
Sheet 4: WEEK 3 - Coin & Referral (56 tasks)
Sheet 5: WEEK 4 - Content & Exam (55 tasks)
Sheet 6: WEEK 5 - Polish & Demo (54 tasks)
Sheet 7: SUMMARY
```

---

## 📊 SHEET 1: DASHBOARD

### Layout:

```
┌─────────────────────────────────────────────────────────┐
│  🎯 TRYEDU V2.0 - PROJECT DASHBOARD                     │
│  Demo Date: 29/12/2025                                  │
├─────────────────────────────────────────────────────────┤
│                                                          │
│  📊 OVERALL PROGRESS                                    │
│  ████████████░░░░░░░░ 65% (166/256 tasks)              │
│                                                          │
│  ⏱️ TIME REMAINING: 15 days                             │
│  🎯 ON TRACK                                            │
│                                                          │
├─────────────────────────────────────────────────────────┤
│  WEEKLY PROGRESS:                                       │
│  ✅ Week 1: ████████████████████ 100% (49/49)          │
│  ✅ Week 2: ████████████████████ 100% (42/42)          │
│  🟡 Week 3: ████████████░░░░░░░░  65% (36/56)          │
│  ⏳ Week 4: ░░░░░░░░░░░░░░░░░░░░   0% (0/55)           │
│  ⏳ Week 5: ░░░░░░░░░░░░░░░░░░░░   0% (0/54)           │
├─────────────────────────────────────────────────────────┤
│  TEAM PROGRESS:                                         │
│  Phong:  ████████████░░░░░░░░ 60% (27/45)              │
│  Kiên:   ████████████░░░░░░░░ 65% (85/130)             │
│  Cường:  ████████████░░░░░░░░ 67% (50/75)              │
│  Nguyên: ████████████████████ 100% (6/6)               │
└─────────────────────────────────────────────────────────┘
```

### Công Thức Dashboard:

**Overall Progress (Cell B3):**
```excel
=COUNTIF('WEEK 1'!A:A,"✅")+COUNTIF('WEEK 2'!A:A,"✅")+COUNTIF('WEEK 3'!A:A,"✅")+COUNTIF('WEEK 4'!A:A,"✅")+COUNTIF('WEEK 5'!A:A,"✅")
```

**Progress Bar (Cell B4):**
```excel
=REPT("█",INT(B3/256*20))&REPT("░",20-INT(B3/256*20))&" "&TEXT(B3/256,"0%")
```

**Week 1 Progress (Cell B7):**
```excel
=COUNTIF('WEEK 1'!A:A,"✅")&"/"&COUNTA('WEEK 1'!A:A)-1
```

**Status Indicator (Cell B8):**
```excel
=IF(B3/256>=0.8,"🟢 ON TRACK",IF(B3/256>=0.6,"🟡 AT RISK","🔴 BEHIND"))
```

---

## 📊 SHEET 2-6: WEEKLY CHECKLISTS

### Column Structure:

| A | B | C | D | E | F | G | H | I |
|---|---|---|---|---|---|---|---|---|
| **✓** | **ID** | **Task Name** | **Module** | **Owner** | **Est.** | **Actual** | **Status** | **Notes** |
| ☐ | T001 | Review cấu trúc | Foundation | Phong | 4h | | ⏳ | |
| ☐ | T002 | Thiết kế V2.0 | Foundation | Phong | 8h | | ⏳ | |

### Công Thức Cho Mỗi Sheet:

**Cell G2 (Auto Status):**
```excel
=IF(A2="✅","✅ Done",IF(F2>E2,"⚠️ Over",IF(F2>0,"🔄 In Progress","⏳ Not Started")))
```

**Header Progress (Cell A1):**
```excel
="WEEK 1: "&COUNTIF(A:A,"✅")&"/"&COUNTA(A:A)-1&" ("&TEXT(COUNTIF(A:A,"✅")/(COUNTA(A:A)-1),"0%")&")"
```

**Conditional Formatting:**
```
Row with ✅ in column A: Green background
Cell F > E (Actual > Estimated): Red font
Cell G contains "Done": Bold green
```

---

## 📊 SHEET 7: SUMMARY

### Module Summary Table:

| Module | Total Tasks | Completed | Progress | Status |
|--------|-------------|-----------|----------|--------|
| Foundation | 21 | 21 | 100% | ✅ |
| Database | 20 | 20 | 100% | ✅ |
| Authentication | 17 | 15 | 88% | 🟡 |
| Coin System | 20 | 12 | 60% | 🟡 |
| ... | ... | ... | ... | ... |

### Công Thức:

**Completed Count (Cell C2):**
```excel
=COUNTIFS('WEEK 1'!D:D,"Foundation",'WEEK 1'!A:A,"✅")+COUNTIFS('WEEK 2'!D:D,"Foundation",'WEEK 2'!A:A,"✅")
```

**Progress % (Cell D2):**
```excel
=TEXT(C2/B2,"0%")
```

**Status (Cell E2):**
```excel
=IF(C2/B2=1,"✅",IF(C2/B2>=0.8,"🟢",IF(C2/B2>=0.5,"🟡","🔴")))
```

---

## 🎨 FORMATTING TIPS

### Color Scheme:
```
✅ Completed: #D4EDDA (Light Green)
🔄 In Progress: #FFF3CD (Light Yellow)
⏳ Not Started: #F8F9FA (Light Gray)
🔴 Blocked: #F8D7DA (Light Red)
⚠️ Over Budget: #FFE5B4 (Peach)
```

### Fonts:
```
Headers: Calibri Bold 14pt
Tasks: Calibri 11pt
Status: Segoe UI Emoji 10pt
```

### Borders:
```
Header Row: Thick bottom border
Every 5 rows: Thin gray border
Module sections: Medium border
```

---

## 📥 IMPORT DATA TỪ CSV

### Bước 1: Mở CSV
```
File → Open → TASK_TRACKING_IMPORT.csv
```

### Bước 2: Text to Columns
```
Data → Text to Columns
Delimited → Comma
Finish
```

### Bước 3: Add Checkbox Column
```
Insert column A
Add header: ✓
Insert checkboxes using Developer tab
```

### Bước 4: Link Checkboxes
```
For each checkbox:
Right-click → Format Control
Cell link: Column J (hidden)
```

---

## 🔧 ADVANCED FEATURES

### Feature 1: Auto Email Alert
```vba
Private Sub Worksheet_Change(ByVal Target As Range)
    If Target.Column = 1 Then ' Column A
        If Target.Value = "✅" Then
            ' Send email notification
            Call SendCompletionEmail(Target.Row)
        End If
    End If
End Sub
```

### Feature 2: Progress Chart
```
Insert → Chart → Bar Chart
Data Range: Summary!B2:D17
Chart Title: "Module Progress"
```

### Feature 3: Burndown Chart
```
X-axis: Dates (27/11 to 29/12)
Y-axis: Remaining tasks
Series 1: Ideal (linear decrease)
Series 2: Actual (from daily counts)
```

### Feature 4: Gantt Chart
```
Use Conditional Formatting:
=AND($F2<=G$1, $G2>=G$1)
Format: Fill color based on status
```

---

## 💾 SAVE & BACKUP

### Auto-Save Settings:
```
File → Options → Save
☑ Save AutoRecover every 5 minutes
☑ Keep the last 10 autosaved versions
```

### Backup Strategy:
```
Daily: Save as TryEdu_Checklist_YYYYMMDD.xlsx
Weekly: Upload to Google Drive
Before Demo: Create backup copy
```

---

## 📱 MOBILE ACCESS

### Option 1: Excel Mobile App
```
Install Excel app on phone
Open from OneDrive/Google Drive
Can view and tick checkboxes
```

### Option 2: Google Sheets
```
File → Save As → Google Sheets
Share with team
Real-time collaboration
```

---

## 🎯 DAILY WORKFLOW

### Morning (9:00 AM):
1. Open Excel
2. Review today's tasks
3. Update yesterday's checkboxes
4. Check Dashboard progress

### During Day:
1. Tick ✅ when complete
2. Update Actual Hours
3. Add notes if needed

### Evening (6:00 PM):
1. Final checkbox updates
2. Review progress
3. Plan tomorrow
4. Save & backup

---

## 📊 SAMPLE DATA - WEEK 1

Copy this into Excel:

```
✓	Task ID	Task Name	Module	Assigned To	Est. Hours	Actual Hours	Status	Notes
☐	T001	Review cấu trúc module hiện tại	Foundation	Phong	4	0	⏳ Not Started	
☐	T002	Thiết kế kiến trúc mở rộng V2.0	Foundation	Phong	8	0	⏳ Not Started	
☐	T003	Tạo ModuleCoin structure	Foundation	Phong	2	0	⏳ Not Started	
☐	T004	Tạo ModulePartner structure	Foundation	Phong	2	0	⏳ Not Started	
☐	T005	Tạo ModuleContent structure	Foundation	Phong	2	0	⏳ Not Started	
☐	T006	Tạo ModuleLearning structure	Foundation	Phong	2	0	⏳ Not Started	
☐	T007	Document architecture decisions	Foundation	Phong	2	0	⏳ Not Started	
☐	T008	Clone repository và setup local	Foundation	Kiên	1	0	⏳ Not Started	
☐	T009	Review EntityBase pattern	Foundation	Kiên	2	0	⏳ Not Started	
☐	T010	Review MyServiceBase pattern	Foundation	Kiên	2	0	⏳ Not Started	
```

---

## 🎥 VIDEO TUTORIAL (Recommended)

### Tạo Video Hướng Dẫn:
1. Record screen while setting up
2. Show how to insert checkbox
3. Demonstrate linking cells
4. Show formula setup
5. Demo daily workflow

### YouTube Search:
```
"Excel checkbox tutorial"
"Excel project tracking with checkboxes"
"Excel task list with progress bar"
```

---

## 🆘 TROUBLESHOOTING

### Problem 1: Checkbox không link được
**Solution:**
```
1. Right-click checkbox
2. Format Control
3. Cell link: Select cell
4. Make sure cell is not protected
```

### Problem 2: Formula không tính đúng
**Solution:**
```
1. Check cell references
2. Make sure using correct sheet names
3. Verify checkbox linked cells
4. Use F9 to debug formula
```

### Problem 3: Checkbox biến mất khi copy
**Solution:**
```
1. Select cell with checkbox
2. Ctrl+C
3. Right-click destination
4. Paste Special → All
```

### Problem 4: File quá chậm
**Solution:**
```
1. Limit conditional formatting
2. Use manual calculation
3. Remove unused checkboxes
4. Save as .xlsb (binary)
```

---

## 📞 SUPPORT

### Excel Help:
- F1 in Excel
- https://support.microsoft.com/excel

### Community:
- r/excel on Reddit
- Stack Overflow [excel] tag

### Team Support:
- Phong (Excel expert)
- Daily standup Q&A

---

## ✅ CHECKLIST SETUP COMPLETE

Sau khi setup xong, bạn sẽ có:

- [ ] Excel file với 256 checkboxes
- [ ] Dashboard tự động cập nhật
- [ ] 6 sheets (Dashboard + 5 weeks + Summary)
- [ ] Progress bars tự động
- [ ] Conditional formatting
- [ ] Backup strategy
- [ ] Mobile access setup
- [ ] Team shared access

---

## 🎉 READY TO USE!

**File Name:** `TryEdu_V2_Checklist.xlsx`

**Location:** `C:\SLK\TryEdu_2025\tracking\`

**Shared:** OneDrive / Google Drive

**Team Access:** Edit permissions for all

**Start Date:** 27/11/2025

**Demo Date:** 29/12/2025

**LET'S BUILD! 🚀**

---

*Template created: 28/11/2025*  
*Version: 1.0*  
*Author: AI Assistant*  
*For: TryEdu V2.0 Project*


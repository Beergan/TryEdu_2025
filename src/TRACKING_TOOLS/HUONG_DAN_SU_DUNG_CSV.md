# 📊 HƯỚNG DẪN SỬ DỤNG CSV - CHECKBOX & GANTT CHART

## 🎯 TỔNG QUAN

Bạn có **2 file CSV** để sử dụng:

1. **TASK_CHECKLIST_WITH_CHECKBOX.csv** - Checklist với checkbox để tích chọn
2. **GANTT_CHART_DATA.csv** - Dữ liệu cho Gantt chart

---

## 📋 FILE 1: TASK_CHECKLIST_WITH_CHECKBOX.csv

### Mục đích:
✅ Checklist với checkbox để tích chọn khi hoàn thành task

### Cấu trúc:
```
✓ | Task ID | Task Name | Module | Assigned To | Priority | Status | Start Date | End Date | ...
☐ | T001    | Review... | ...    | Phong       | P0       | ...    | 27/11/2025 | ...      | ...
```

### Cách sử dụng trong Excel:

#### Bước 1: Mở file CSV
```
1. Mở Excel
2. File → Open → Chọn TASK_CHECKLIST_WITH_CHECKBOX.csv
3. Excel sẽ tự động import
```

#### Bước 2: Setup Dropdown Checkbox
```
1. Select column A (từ A2 trở xuống - 256 tasks)
2. Ribbon → Data tab → Data Validation
3. Settings:
   - Allow: List
   - Source: ☐,✅
4. Click OK
```

#### Bước 3: Sử dụng
```
- Click vào cell trong column A
- Chọn ☐ (chưa làm) hoặc ✅ (đã hoàn thành)
- Progress tự động cập nhật
```

#### Bước 4: Thêm Progress Formula (Optional)
```
Cell Z1 (hoặc bất kỳ cell nào):
=COUNTIF(A:A,"✅")&"/"&COUNTA(A:A)-1&" ("&TEXT(COUNTIF(A:A,"✅")/(COUNTA(A:A)-1),"0%")&")"

Kết quả: "50/256 (19.5%)"
```

#### Bước 5: Conditional Formatting (Optional)
```
1. Select rows 2:257 (tất cả tasks)
2. Home → Conditional Formatting → New Rule
3. "Use a formula to determine which cells to format"
4. Formula: =$A2="✅"
5. Format: Fill = Light Green (#D4EDDA)
6. Click OK
```

### Kết quả:
```
✓   | Task ID | Task Name                    | Status
----|---------|------------------------------|------------
✅  | T001    | Review cấu trúc module       | ✅ Completed
☐   | T002    | Thiết kế kiến trúc V2.0      | ⏳ Not Started
☐   | T003    | Tạo ModuleCoin structure     | ⏳ Not Started

Progress: 1/256 (0.4%)
```

---

## 📊 FILE 2: GANTT_CHART_DATA.csv

### Mục đích:
📅 Dữ liệu để tạo Gantt chart xem timeline và dependencies

### Cấu trúc:
```
Task ID | Task Name | Start Date | End Date | Duration | Dependencies | Assigned To | Module | ...
T001    | Review... | 27/11/2025 | 27/11/2025 | 1      | -           | Phong       | ...    | ...
```

### Cách sử dụng trong Excel:

#### Phương án 1: Excel Gantt Chart (Đơn giản)

##### Bước 1: Mở file CSV
```
1. Mở Excel
2. File → Open → Chọn GANTT_CHART_DATA.csv
```

##### Bước 2: Tạo Timeline Columns
```
1. Row 1: Tạo header từ 27/11/2025 đến 29/12/2025 (33 ngày)
2. Format dates: Right-click → Format Cells → Date
```

##### Bước 3: Tạo Gantt Bars
```
1. Cell B2 (task T001, date 27/11):
   Formula: =AND($C2<=B$1, $D2>=B$1)
   
2. Copy formula xuống và sang phải
3. Conditional Formatting:
   - TRUE → Fill color (Blue/Green)
   - FALSE → No fill
```

##### Bước 4: Format
```
1. Adjust column widths
2. Freeze panes (View → Freeze Panes)
3. Add gridlines
```

#### Phương án 2: Microsoft Project (Chuyên nghiệp)

##### Bước 1: Import vào MS Project
```
1. Mở Microsoft Project
2. File → Open → Chọn GANTT_CHART_DATA.csv
3. Import Wizard sẽ hiện lên
```

##### Bước 2: Map Columns
```
Map các columns:
- Task ID → ID
- Task Name → Name
- Start Date → Start
- End Date → Finish
- Duration → Duration
- Dependencies → Predecessors
- Assigned To → Resource Names
```

##### Bước 3: Xem Gantt Chart
```
1. View → Gantt Chart
2. Gantt chart sẽ tự động hiển thị
3. Dependencies sẽ tự động link
```

#### Phương án 3: Google Sheets (Miễn phí)

##### Bước 1: Upload CSV
```
1. Mở Google Sheets
2. File → Import → Upload
3. Chọn GANTT_CHART_DATA.csv
```

##### Bước 2: Tạo Gantt Chart
```
1. Insert → Chart
2. Chart type: Timeline
3. Data range: Select task data
4. X-axis: Start Date, End Date
5. Y-axis: Task Name
```

#### Phương án 4: Online Tools

##### Option A: TeamGantt
```
1. Truy cập: https://www.teamgantt.com
2. Import → CSV
3. Upload GANTT_CHART_DATA.csv
4. Auto-generate Gantt chart
```

##### Option B: Smartsheet
```
1. Truy cập: https://www.smartsheet.com
2. Import → CSV
3. Upload file
4. View as Gantt chart
```

##### Option C: GanttProject (Free Desktop)
```
1. Download: http://www.ganttproject.biz
2. File → Import → CSV
3. Map columns
4. View Gantt chart
```

---

## 🎨 TẠO GANTT CHART TRONG EXCEL (CHI TIẾT)

### Bước 1: Prepare Data
```
1. Mở GANTT_CHART_DATA.csv
2. Insert column B (sau Task ID)
3. Column B header: "Days"
4. Cell B2: =D2-C2+1 (Duration calculation)
5. Copy xuống
```

### Bước 2: Create Timeline
```
1. Row 1: Dates từ 27/11/2025 đến 29/12/2025
2. Format: Short Date (DD/MM/YYYY)
3. Column width: 3
```

### Bước 3: Create Gantt Bars
```
1. Cell E2 (first date column, first task):
   Formula: =IF(AND($C2<=E$1, $D2>=E$1), "█", "")
   
2. Copy formula to all cells
3. Font: Courier New (monospace)
```

### Bước 4: Conditional Formatting
```
1. Select all date cells (E2:AK257)
2. Home → Conditional Formatting → New Rule
3. "Format only cells that contain"
4. Cell Value = "█"
5. Format: Fill = Blue, Font = Blue
6. Click OK
```

### Bước 5: Add Milestones
```
1. Insert rows for milestones
2. Format milestones differently (Red color)
3. Add milestone markers: ◆
```

### Kết quả:
```
Task Name              | 27/11 | 28/11 | 29/11 | 30/11 | ...
----------------------|-------|-------|-------|-------|----
Review cấu trúc       |  █    |       |       |       | ...
Thiết kế V2.0         |  █    |  █    |       |       | ...
Tạo ModuleCoin        |  █    |  █    |       |       | ...
```

---

## 📱 SỬ DỤNG TRÊN MOBILE

### Excel Mobile App:
```
1. Upload CSV to OneDrive/Google Drive
2. Open Excel app
3. Open file
4. Can view và edit checkbox
```

### Google Sheets Mobile:
```
1. Upload CSV to Google Drive
2. Open Google Sheets app
3. Open file
4. Can view Gantt chart
```

---

## 🔧 TIPS & TRICKS

### Tip 1: Auto Progress Update
```
Thêm formula vào Status column:
=IF(A2="✅","✅ Completed","⏳ Not Started")
```

### Tip 2: Filter Completed Tasks
```
1. Data → Filter
2. Column A → Uncheck ✅
3. Chỉ hiện tasks chưa làm
```

### Tip 3: Sort by Status
```
1. Select all data
2. Data → Sort
3. Sort by: Column A (✓)
4. Order: A to Z (✅ trước ☐)
```

### Tip 4: Group by Module
```
1. Data → Subtotal
2. At each change in: Module
3. Use function: Count
4. Add subtotal to: Task ID
```

### Tip 5: Color Code by Priority
```
Conditional Formatting:
- P0 → Red background
- P1 → Yellow background
- P2 → Green background
```

### Tip 6: Gantt Chart Critical Path
```
1. Highlight tasks with many dependencies
2. Use red color for critical path
3. Add arrows showing dependencies
```

---

## 📊 DASHBOARD TỔNG HỢP

### Tạo Dashboard Sheet:

```
Cell A1: "🎯 TRYEDU V2.0 - PROJECT DASHBOARD"
Cell A3: "📊 OVERALL PROGRESS"
Cell B4: =COUNTIF(Sheet1!A:A,"✅")&"/"&COUNTA(Sheet1!A:A)-1
Cell B5: =TEXT(COUNTIF(Sheet1!A:A,"✅")/(COUNTA(Sheet1!A:A)-1),"0%")

Cell A7: "⏱️ TIME REMAINING"
Cell B8: =DAYS("29/12/2025",TODAY())&" days"

Cell A10: "🎯 STATUS"
Cell B11: =IF(COUNTIF(Sheet1!A:A,"✅")/(COUNTA(Sheet1!A:A)-1)>=0.8,"🟢 ON TRACK",IF(COUNTIF(Sheet1!A:A,"✅")/(COUNTA(Sheet1!A:A)-1)>=0.5,"🟡 AT RISK","🔴 BEHIND"))
```

---

## 🆘 TROUBLESHOOTING

### ❌ CSV không mở được trong Excel
**✅ Solution:**
```
1. Right-click CSV file
2. Open with → Excel
3. Hoặc: Data → Get Data → From File → CSV
```

### ❌ Dates không format đúng
**✅ Solution:**
```
1. Select date columns
2. Data → Text to Columns
3. Delimited → Next
4. Date format: DMY
5. Finish
```

### ❌ Dependencies không hiển thị trong Gantt
**✅ Solution:**
```
1. Check format: "T001" hoặc "T001,T002"
2. MS Project: Predecessors column format
3. Excel: Manual linking
```

### ❌ Checkbox dropdown không hoạt động
**✅ Solution:**
```
1. Check Data Validation settings
2. Source must be: ☐,✅ (exact symbols)
3. Re-apply validation
```

### ❌ Gantt chart quá dài
**✅ Solution:**
```
1. Filter by Week (W1, W2, ...)
2. Group by Module
3. Use zoom in Excel
```

---

## 📞 SUPPORT

### Cần giúp?
```
1. Đọc lại hướng dẫn
2. Xem video tutorial Excel Gantt
3. Hỏi Phong (Excel expert)
4. Google: "Excel Gantt chart tutorial"
```

### Useful Links:
```
Excel Gantt: https://support.microsoft.com/excel
MS Project: https://support.microsoft.com/project
Google Sheets: https://support.google.com/sheets
TeamGantt: https://www.teamgantt.com/help
```

---

## ✅ CHECKLIST SETUP

Sau khi setup xong:

- [ ] CSV checklist đã mở trong Excel
- [ ] Dropdown checkbox đã setup (☐,✅)
- [ ] Progress formula đã thêm
- [ ] Conditional formatting đã apply
- [ ] Gantt chart data đã import
- [ ] Gantt chart đã tạo (Excel/MS Project/Online)
- [ ] Dependencies đã link
- [ ] Dashboard đã tạo
- [ ] File đã save
- [ ] Team đã share access

---

## 🎉 READY TO USE!

**Bây giờ bạn có:**
✅ CSV checklist với checkbox  
✅ CSV Gantt chart data  
✅ Hướng dẫn chi tiết  
✅ Multiple options (Excel/MS Project/Online)  

**Bắt đầu track progress và xem timeline! 🚀**

---

*Hướng dẫn tạo: 28/11/2025*  
*Version: 1.0*  
*For: TryEdu V2.0 Project*


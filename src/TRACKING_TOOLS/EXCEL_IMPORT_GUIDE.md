# 📊 HƯỚNG DẪN IMPORT VÀO EXCEL/GOOGLE SHEETS

## 🎯 File CSV Đã Tạo

✅ **TASK_TRACKING_IMPORT.csv** - 255 tasks đầy đủ với tất cả thông tin

---

## 📥 CÁCH IMPORT VÀO EXCEL

### Bước 1: Mở Excel
1. Mở Microsoft Excel
2. File → New → Blank Workbook

### Bước 2: Import CSV
1. Data → Get Data → From File → From Text/CSV
2. Chọn file `TASK_TRACKING_IMPORT.csv`
3. Click "Import"
4. Chọn delimiter: **Comma**
5. Click "Load"

### Bước 3: Format Columns
```
Column A (Task ID): Text
Column B (Task Name): Text
Column C (Module): Text
Column D (Assigned To): Text
Column E (Priority): Text
Column F (Status): Text
Column G (Start Date): Date (dd/mm/yyyy)
Column H (End Date): Date (dd/mm/yyyy)
Column I (Estimated Hours): Number
Column J (Actual Hours): Number
Column K (Progress %): Percentage
Column L (Dependencies): Text
Column M (Notes): Text
Column N (Week): Text
```

### Bước 4: Thêm Formulas

#### Cell O1: "Completion Rate"
```excel
=COUNTIF(F:F,"Completed")/COUNTA(A:A)-1
```

#### Cell P1: "Tasks Completed"
```excel
=COUNTIF(F:F,"Completed")
```

#### Cell Q1: "Tasks In Progress"
```excel
=COUNTIF(F:F,"In Progress")
```

#### Cell R1: "Tasks Not Started"
```excel
=COUNTIF(F:F,"Not Started")
```

#### Cell S1: "Total Hours Planned"
```excel
=SUM(I:I)
```

#### Cell T1: "Total Hours Actual"
```excel
=SUM(J:J)
```

#### Cell U1: "Variance Hours"
```excel
=T1-S1
```

### Bước 5: Conditional Formatting

#### Status Column (F):
1. Select column F
2. Home → Conditional Formatting → New Rule
3. Format cells that contain:
   - **"Completed"** → Green fill (#00FF00)
   - **"In Progress"** → Yellow fill (#FFFF00)
   - **"Blocked"** → Red fill (#FF0000)
   - **"Not Started"** → Gray fill (#CCCCCC)

#### Priority Column (E):
1. Select column E
2. Conditional Formatting:
   - **"P0"** → Red text (#FF0000), Bold
   - **"P1"** → Orange text (#FFA500)
   - **"P2"** → Blue text (#0000FF)

#### Progress % Column (K):
1. Select column K
2. Conditional Formatting → Color Scales:
   - 0% → Red
   - 50% → Yellow
   - 100% → Green

### Bước 6: Create Pivot Tables

#### Pivot 1: Tasks by Module
```
Rows: Module
Values: Count of Task ID
```

#### Pivot 2: Tasks by Assigned To
```
Rows: Assigned To
Values: Count of Task ID, Sum of Estimated Hours
```

#### Pivot 3: Tasks by Week
```
Rows: Week
Columns: Status
Values: Count of Task ID
```

#### Pivot 4: Tasks by Priority
```
Rows: Priority
Columns: Status
Values: Count of Task ID
```

---

## 📥 CÁCH IMPORT VÀO GOOGLE SHEETS

### Bước 1: Tạo Google Sheet Mới
1. Vào https://sheets.google.com
2. Click "Blank" để tạo sheet mới
3. Đặt tên: "TryEdu V2.0 - Task Tracking"

### Bước 2: Import CSV
1. File → Import
2. Upload → Chọn `TASK_TRACKING_IMPORT.csv`
3. Import location: **Replace current sheet**
4. Separator type: **Comma**
5. Convert text to numbers: **Yes**
6. Click "Import data"

### Bước 3: Format Columns (Tương tự Excel)
1. Select column G-H (dates)
2. Format → Number → Date

### Bước 4: Thêm Google Sheets Formulas

#### Cell O1: "Completion Rate"
```
=COUNTIF(F:F,"Completed")/(COUNTA(A:A)-1)
```

#### Cell P1: "Tasks Completed"
```
=COUNTIF(F:F,"Completed")
```

#### Auto-update Progress %:
```
Cell K2: =IF(F2="Completed",100%,IF(F2="In Progress",50%,0%))
```
Drag down to all rows

### Bước 5: Create Dashboard Sheet

#### Tạo Sheet "Dashboard":
1. Click "+" ở bottom
2. Rename to "Dashboard"

#### Add KPIs:
```
A1: Overall Progress
B1: =AVERAGE('Sheet1'!K:K)

A2: Tasks Completed
B2: =COUNTIF('Sheet1'!F:F,"Completed")

A3: Tasks Remaining
B3: =255-B2

A4: Completion Rate
B4: =B2/255

A5: Total Hours Planned
B5: =SUM('Sheet1'!I:I)

A6: Total Hours Actual
B6: =SUM('Sheet1'!J:J)

A7: Variance
B7: =B6-B5
```

---

## 📊 TẠO CHARTS

### Chart 1: Burndown Chart

**Data Range:**
- X-axis: Days (1-33)
- Y-axis: Tasks Remaining

**Formula for Tasks Remaining:**
```
Day 1: =255
Day 2: =255-COUNTIFS('Sheet1'!H:H,"<=TODAY()")
...
```

**Chart Type:** Line Chart
- Line 1: Ideal (straight line from 255 to 0)
- Line 2: Actual (calculated from completed tasks)

### Chart 2: Tasks by Module (Pie Chart)

**Data:**
```
Module          | Count
----------------|------
Foundation      | =COUNTIF('Sheet1'!C:C,"Foundation")
Database        | =COUNTIF('Sheet1'!C:C,"Database")
Authentication  | =COUNTIF('Sheet1'!C:C,"Authentication")
Partner         | =COUNTIF('Sheet1'!C:C,"Partner")
Coin            | =COUNTIF('Sheet1'!C:C,"Coin")
Referral        | =COUNTIF('Sheet1'!C:C,"Referral")
Commission      | =COUNTIF('Sheet1'!C:C,"Commission")
Content         | =COUNTIF('Sheet1'!C:C,"Content")
Exam            | =COUNTIF('Sheet1'!C:C,"Exam")
Testing         | =COUNTIF('Sheet1'!C:C,"Testing")
UI/UX           | =COUNTIF('Sheet1'!C:C,"UI/UX")
Backend         | =COUNTIF('Sheet1'!C:C,"Backend")
Review          | =COUNTIF('Sheet1'!C:C,"Review")
Demo            | =COUNTIF('Sheet1'!C:C,"Demo")
```

### Chart 3: Team Workload (Stacked Bar)

**Data:**
```
Team Member | Not Started | In Progress | Completed
------------|-------------|-------------|----------
Phong       | =COUNTIFS(D:D,"Phong",F:F,"Not Started")
Kiên        | =COUNTIFS(D:D,"Kiên",F:F,"Not Started")
Cường       | =COUNTIFS(D:D,"Cường",F:F,"Not Started")
Nguyên      | =COUNTIFS(D:D,"Nguyên",F:F,"Not Started")
All         | =COUNTIFS(D:D,"All",F:F,"Not Started")
```

### Chart 4: Weekly Progress (Column Chart)

**Data:**
```
Week | Planned | Completed
-----|---------|----------
W1   | =COUNTIF('Sheet1'!N:N,"W1")
W2   | =COUNTIF('Sheet1'!N:N,"W2")
W3   | =COUNTIF('Sheet1'!N:N,"W3")
W4   | =COUNTIF('Sheet1'!N:N,"W4")
W5   | =COUNTIF('Sheet1'!N:N,"W5")
```

---

## 🎨 STYLING TIPS

### Header Row:
- Background: Dark Blue (#1F4E78)
- Text: White
- Bold
- Font Size: 12pt

### Freeze Panes:
- Freeze row 1 (header)
- View → Freeze → 1 row

### Auto-filter:
- Select header row
- Data → Filter

### Column Widths:
```
A (Task ID): 60px
B (Task Name): 300px
C (Module): 100px
D (Assigned To): 100px
E (Priority): 60px
F (Status): 100px
G-H (Dates): 100px
I-J (Hours): 80px
K (Progress): 80px
L (Dependencies): 150px
M (Notes): 200px
N (Week): 60px
```

---

## 📱 MOBILE ACCESS

### Google Sheets App:
1. Install Google Sheets app
2. Open your sheet
3. Enable offline access
4. Update on-the-go

### Excel Mobile:
1. Install Excel app
2. Save to OneDrive
3. Open from OneDrive
4. Edit anywhere

---

## 🔄 DAILY UPDATE WORKFLOW

### Morning (9:00 AM):
```
1. Open tracking sheet
2. Find your tasks for today
3. Update Status: "Not Started" → "In Progress"
4. Note any blockers in Notes column
```

### Evening (5:00 PM):
```
1. Update completed tasks: "In Progress" → "Completed"
2. Update Actual Hours spent
3. Update Progress % if partially done
4. Add notes about tomorrow's plan
```

### Formula to auto-calculate Progress:
```excel
=IF(F2="Completed",100%,
  IF(F2="In Progress",50%,
    IF(F2="Blocked",25%,0%)))
```

---

## 📊 ADVANCED FEATURES

### 1. Automatic Email Alerts (Google Sheets)

**Setup:**
1. Tools → Script editor
2. Paste this code:

```javascript
function sendDailyUpdate() {
  var sheet = SpreadsheetApp.getActiveSheet();
  var data = sheet.getDataRange().getValues();
  
  var completed = 0;
  var inProgress = 0;
  var blocked = 0;
  
  for (var i = 1; i < data.length; i++) {
    if (data[i][5] == "Completed") completed++;
    if (data[i][5] == "In Progress") inProgress++;
    if (data[i][5] == "Blocked") blocked++;
  }
  
  var message = "Daily Update:\n" +
                "Completed: " + completed + "\n" +
                "In Progress: " + inProgress + "\n" +
                "Blocked: " + blocked;
  
  MailApp.sendEmail("team@example.com", "Daily Task Update", message);
}
```

3. Set trigger: Run daily at 6:00 PM

### 2. Conditional Formatting for Overdue Tasks

**Formula:**
```
=AND(H2<TODAY(), F2<>"Completed")
```
**Format:** Red background

### 3. Progress Bar in Cell

**Custom format for Progress %:**
```
[>=0.75][Green]"█████ "0%;
[>=0.5][Yellow]"███░░ "0%;
[>=0.25][Orange]"██░░░ "0%;
[Red]"█░░░░ "0%
```

---

## 💾 BACKUP STRATEGY

### Daily Backup:
```
File → Download → Excel (.xlsx)
Save as: TaskTracking_YYYYMMDD.xlsx
```

### Weekly Archive:
```
Create folder: Archives/Week1/
Save snapshot every Friday
```

### Version Control:
```
File → Version history → See version history
Name versions: "Week 1 Complete", "Week 2 Complete"
```

---

## 🎯 QUICK FILTERS

### Filter 1: My Tasks Today
```
Column D (Assigned To) = Your Name
Column F (Status) = "In Progress" OR "Not Started"
Column G (Start Date) <= TODAY()
```

### Filter 2: Overdue Tasks
```
Column H (End Date) < TODAY()
Column F (Status) <> "Completed"
```

### Filter 3: Blocked Tasks
```
Column F (Status) = "Blocked"
```

### Filter 4: This Week Tasks
```
Column N (Week) = Current Week (W1, W2, etc.)
```

---

## 📈 REPORTING

### Weekly Report Template:

```
WEEK [X] SUMMARY
================

Tasks Planned: [COUNT]
Tasks Completed: [COUNT]
Completion Rate: [%]

By Module:
- Foundation: [X/Y]
- Authentication: [X/Y]
- Coin System: [X/Y]
...

By Team Member:
- Phong: [X/Y] tasks, [H] hours
- Kiên: [X/Y] tasks, [H] hours
- Cường: [X/Y] tasks, [H] hours
- Nguyên: [X/Y] tasks, [H] hours

Blockers:
- [List any blocked tasks]

Next Week Plan:
- [Key tasks for next week]
```

---

## 🚀 PRO TIPS

1. **Use Named Ranges:**
   ```
   TaskList = A2:N256
   StatusColumn = F2:F256
   ```

2. **Data Validation for Status:**
   ```
   Data → Data Validation
   List: Not Started, In Progress, Blocked, Completed
   ```

3. **Protect Headers:**
   ```
   Select row 1
   Format → Protect sheet
   ```

4. **Share with Team:**
   ```
   Share button → Add team emails
   Set permissions: Can edit
   ```

5. **Comments for Collaboration:**
   ```
   Right-click cell → Insert comment
   Tag team members: @name
   ```

---

## ✅ VERIFICATION CHECKLIST

After import, verify:
- [ ] All 255 tasks imported
- [ ] Dates formatted correctly
- [ ] Formulas calculating properly
- [ ] Conditional formatting applied
- [ ] Charts displaying correctly
- [ ] Filters working
- [ ] Team can access and edit
- [ ] Mobile access working

---

## 🆘 TROUBLESHOOTING

### Problem: CSV not importing correctly
**Solution:** 
- Check file encoding (UTF-8)
- Verify delimiter is comma
- Remove any special characters

### Problem: Dates showing as text
**Solution:**
- Select date columns
- Format → Number → Date
- Use format: dd/mm/yyyy

### Problem: Formulas not calculating
**Solution:**
- Check cell references
- Ensure no circular references
- Recalculate: Ctrl+Alt+F9 (Excel)

### Problem: Conditional formatting not applying
**Solution:**
- Clear existing formatting
- Reapply rules one by one
- Check range is correct

---

## 📞 SUPPORT

Need help?
- Excel issues: Check Microsoft Support
- Google Sheets: Check Google Help Center
- Formula help: ExcelJet.net
- Team questions: Contact project manager

---

*Import Guide created: 27/11/2025*  
*Last updated: 27/11/2025*  
*File: TASK_TRACKING_IMPORT.csv (255 tasks)*


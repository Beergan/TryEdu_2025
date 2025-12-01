# 📊 PROJECT TRACKING SPREADSHEET
## Hướng dẫn tạo Google Sheets / Excel Template

---

## 🎯 SHEET 1: TASK TRACKING

### Columns Setup:
```
A: Task ID (T001, T002, ...)
B: Task Name
C: Module (Authentication, Coin, Partner, Content, Exam, UI/UX, Testing, Demo)
D: Assigned To (Phong, Kiên, Cường, Nguyên)
E: Priority (P0, P1, P2)
F: Status (Not Started, In Progress, Blocked, Completed)
G: Start Date
H: End Date
I: Estimated Hours
J: Actual Hours
K: Progress % (0-100%)
L: Dependencies (Task IDs)
M: Notes/Blockers
N: Week Number (W1, W2, W3, W4, W5)
```

### Sample Data:

| Task ID | Task Name | Module | Assigned To | Priority | Status | Start Date | End Date | Est Hours | Actual Hours | Progress % | Dependencies | Notes | Week |
|---------|-----------|--------|-------------|----------|--------|------------|----------|-----------|--------------|------------|--------------|-------|------|
| T001 | Review cấu trúc module | Foundation | Phong | P0 | Not Started | 27/11/2025 | 27/11/2025 | 4 | 0 | 0% | - | - | W1 |
| T002 | Setup PostgreSQL | Foundation | Kiên | P0 | Not Started | 27/11/2025 | 27/11/2025 | 2 | 0 | 0% | - | - | W1 |
| T003 | Setup UI framework | Foundation | Cường | P0 | Not Started | 27/11/2025 | 27/11/2025 | 3 | 0 | 0% | - | - | W1 |
| T004 | Tạo EntityCoinTransaction | Database | Kiên | P0 | Not Started | 29/11/2025 | 29/11/2025 | 2 | 0 | 0% | T002 | - | W1 |
| T005 | Tạo EntityPartnerCenter | Database | Kiên | P0 | Not Started | 29/11/2025 | 29/11/2025 | 2 | 0 | 0% | T002 | - | W1 |

### Formulas:

**Cell P2 (Overall Progress):**
```excel
=AVERAGE(K:K)
```

**Cell Q2 (Tasks Completed):**
```excel
=COUNTIF(F:F,"Completed")
```

**Cell R2 (Tasks In Progress):**
```excel
=COUNTIF(F:F,"In Progress")
```

**Cell S2 (Tasks Blocked):**
```excel
=COUNTIF(F:F,"Blocked")
```

**Cell T2 (Total Tasks):**
```excel
=COUNTA(A:A)-1
```

**Cell U2 (Completion Rate %):**
```excel
=Q2/T2*100
```

---

## 🎯 SHEET 2: DAILY STANDUP LOG

### Columns Setup:
```
A: Date
B: Team Member
C: Tasks Completed Yesterday
D: Tasks Planned Today
E: Blockers
F: Hours Worked
G: Burndown (Tasks Remaining)
```

### Sample Data:

| Date | Team Member | Completed Yesterday | Planned Today | Blockers | Hours Worked | Tasks Remaining |
|------|-------------|---------------------|---------------|----------|--------------|-----------------|
| 27/11/2025 | Phong | - | T001, T010 | None | 0 | 165 |
| 27/11/2025 | Kiên | - | T002, T004 | None | 0 | 165 |
| 27/11/2025 | Cường | - | T003, T015 | None | 0 | 165 |
| 27/11/2025 | Nguyên | - | T007, T008 | None | 0 | 165 |

---

## 🎯 SHEET 3: SPRINT SUMMARY

### Columns Setup:
```
A: Sprint/Week
B: Start Date
C: End Date
D: Planned Tasks
E: Completed Tasks
F: Completion Rate %
G: Total Hours Planned
H: Total Hours Actual
I: Variance Hours
J: Key Achievements
K: Issues/Blockers
L: Action Items
```

### Sample Data:

| Sprint | Start Date | End Date | Planned | Completed | Rate % | Hrs Planned | Hrs Actual | Variance | Achievements | Issues | Actions |
|--------|------------|----------|---------|-----------|--------|-------------|------------|----------|--------------|--------|---------|
| Week 1 | 27/11/2025 | 03/12/2025 | 20 | 0 | 0% | 160 | 0 | 0 | - | - | - |
| Week 2 | 04/12/2025 | 10/12/2025 | 25 | 0 | 0% | 200 | 0 | 0 | - | - | - |
| Week 3 | 11/12/2025 | 17/12/2025 | 30 | 0 | 0% | 240 | 0 | 0 | - | - | - |
| Week 4 | 18/12/2025 | 24/12/2025 | 28 | 0 | 0% | 224 | 0 | 0 | - | - | - |
| Week 5 | 25/12/2025 | 29/12/2025 | 45 | 0 | 0% | 360 | 0 | 0 | - | - | - |

---

## 🎯 SHEET 4: TEAM CAPACITY

### Columns Setup:
```
A: Team Member
B: Role
C: Weekly Capacity (Hours)
D: Week 1 Allocated
E: Week 2 Allocated
F: Week 3 Allocated
G: Week 4 Allocated
H: Week 5 Allocated
I: Total Allocated
J: Remaining Capacity
K: Utilization %
```

### Sample Data:

| Team Member | Role | Weekly Cap | W1 | W2 | W3 | W4 | W5 | Total | Remaining | Util % |
|-------------|------|------------|----|----|----|----|-------|-------|-----------|--------|
| Phong | Architect | 40 | 32 | 35 | 30 | 28 | 25 | 150 | 50 | 75% |
| Kiên | Backend | 40 | 40 | 40 | 40 | 40 | 38 | 198 | 2 | 99% |
| Cường | Frontend | 40 | 38 | 40 | 40 | 38 | 35 | 191 | 9 | 96% |
| Nguyên | PO | 20 | 10 | 12 | 15 | 10 | 8 | 55 | 45 | 55% |

---

## 🎯 SHEET 5: MODULE PROGRESS

### Columns Setup:
```
A: Module Name
B: Total Tasks
C: Completed Tasks
D: In Progress
E: Blocked
F: Not Started
G: Progress %
H: Owner
I: Start Date
J: Target Date
K: Status
L: Risk Level
```

### Sample Data:

| Module | Total | Completed | In Progress | Blocked | Not Started | Progress % | Owner | Start | Target | Status | Risk |
|--------|-------|-----------|-------------|---------|-------------|------------|-------|-------|--------|--------|------|
| Authentication | 15 | 0 | 0 | 0 | 15 | 0% | Kiên | 27/11 | 06/12 | Not Started | Low |
| Coin System | 25 | 0 | 0 | 0 | 25 | 0% | Kiên | 11/12 | 17/12 | Not Started | Medium |
| Partner System | 30 | 0 | 0 | 0 | 30 | 0% | Kiên | 07/12 | 17/12 | Not Started | Medium |
| Content System | 20 | 0 | 0 | 0 | 20 | 0% | Kiên | 18/12 | 22/12 | Not Started | Low |
| Exam System | 15 | 0 | 0 | 0 | 15 | 0% | Kiên | 21/12 | 24/12 | Not Started | Low |
| UI/UX | 25 | 0 | 0 | 0 | 25 | 0% | Cường | 27/11 | 27/12 | Not Started | Low |
| Testing | 20 | 0 | 0 | 0 | 20 | 0% | All | 09/12 | 28/12 | Not Started | High |
| Demo | 15 | 0 | 0 | 0 | 15 | 0% | All | 25/12 | 29/12 | Not Started | High |

---

## 🎯 SHEET 6: MILESTONE TRACKING

### Columns Setup:
```
A: Milestone
B: Target Date
C: Actual Date
D: Status
E: Completion %
F: Dependencies Met
G: Deliverables
H: Sign-off
I: Notes
```

### Sample Data:

| Milestone | Target Date | Actual Date | Status | Complete % | Dependencies | Deliverables | Sign-off | Notes |
|-----------|-------------|-------------|--------|------------|--------------|--------------|----------|-------|
| Foundation Complete | 10/12/2025 | - | Pending | 0% | All W1-W2 tasks | Entities, Migrations, Auth | Phong | - |
| Coin System Complete | 17/12/2025 | - | Pending | 0% | Foundation | Coin APIs, Referral, Commission | Phong | - |
| Content Complete | 24/12/2025 | - | Pending | 0% | Coin System | Course, Exam APIs | Phong | - |
| DEMO Ready | 29/12/2025 | - | Pending | 0% | All above | Working system, Demo | Nguyên | - |

---

## 🎯 SHEET 7: BUG TRACKING

### Columns Setup:
```
A: Bug ID
B: Date Reported
C: Reported By
D: Module
E: Severity (Critical, High, Medium, Low)
F: Description
G: Steps to Reproduce
H: Assigned To
I: Status (Open, In Progress, Fixed, Closed)
J: Date Fixed
K: Resolution Notes
```

### Sample Data:

| Bug ID | Date | Reporter | Module | Severity | Description | Steps | Assigned | Status | Fixed Date | Resolution |
|--------|------|----------|--------|----------|-------------|-------|----------|--------|------------|------------|
| B001 | - | - | - | - | - | - | - | - | - | - |

---

## 🎯 SHEET 8: RISK REGISTER

### Columns Setup:
```
A: Risk ID
B: Risk Description
C: Category (Technical, Schedule, Resource, External)
D: Probability (High, Medium, Low)
E: Impact (High, Medium, Low)
F: Risk Score (P*I)
G: Mitigation Strategy
H: Owner
I: Status (Active, Mitigated, Closed)
J: Review Date
```

### Sample Data:

| Risk ID | Description | Category | Probability | Impact | Score | Mitigation | Owner | Status | Review |
|---------|-------------|----------|-------------|--------|-------|------------|-------|--------|--------|
| R001 | Payment Gateway Integration Delay | Technical | Medium | High | 6 | Use mock payment first | Kiên | Active | 10/12 |
| R002 | Feature Creep | Schedule | High | High | 9 | Strict scope control | Nguyên | Active | Weekly |
| R003 | MongoDB Setup Issues | Technical | Low | Medium | 2 | PostgreSQL JSONB fallback | Phong | Active | 05/12 |
| R004 | Performance Issues | Technical | Medium | Medium | 4 | Early caching implementation | Kiên | Active | 15/12 |

---

## 📊 DASHBOARD (SHEET 9)

### KPIs to Display:

**Overall Progress:**
```
=AVERAGE('Task Tracking'!K:K)
```

**Tasks Completed Today:**
```
=COUNTIFS('Task Tracking'!F:F,"Completed",'Task Tracking'!H:H,TODAY())
```

**Tasks Behind Schedule:**
```
=COUNTIFS('Task Tracking'!H:H,"<"&TODAY(),'Task Tracking'!F:F,"<>Completed")
```

**Team Utilization:**
```
=AVERAGE('Team Capacity'!K:K)
```

**Critical Bugs Open:**
```
=COUNTIFS('Bug Tracking'!E:E,"Critical",'Bug Tracking'!I:I,"Open")
```

**High Risks Active:**
```
=COUNTIFS('Risk Register'!D:D,"High",'Risk Register'!I:I,"Active")
```

### Charts to Create:

1. **Burndown Chart**: Tasks Remaining vs Days
2. **Progress by Module**: Bar chart
3. **Team Workload**: Stacked bar chart
4. **Task Status Distribution**: Pie chart
5. **Bug Severity Distribution**: Pie chart
6. **Risk Heat Map**: Scatter plot (Probability vs Impact)

---

## 🎨 CONDITIONAL FORMATTING

### Task Status Colors:
- **Completed**: Green background (#00FF00)
- **In Progress**: Yellow background (#FFFF00)
- **Blocked**: Red background (#FF0000)
- **Not Started**: Gray background (#CCCCCC)

### Priority Colors:
- **P0**: Red text (#FF0000)
- **P1**: Orange text (#FFA500)
- **P2**: Blue text (#0000FF)

### Progress % Colors:
- **0-25%**: Red
- **26-50%**: Orange
- **51-75%**: Yellow
- **76-100%**: Green

---

## 📥 DOWNLOAD TEMPLATE

### Google Sheets:
```
File → Make a copy
Share with team members
Set edit permissions
```

### Excel:
```
Save as .xlsx format
Enable macros if needed
Share via OneDrive/SharePoint
```

---

## 🔄 DAILY UPDATE PROCESS

### Morning (9:00 AM):
1. Update yesterday's completed tasks
2. Log actual hours worked
3. Update task status
4. Add any blockers

### Evening (5:00 PM):
1. Update progress %
2. Log today's actual hours
3. Update burndown chart
4. Flag any risks

### Weekly (Friday):
1. Complete sprint summary
2. Update milestone status
3. Review risk register
4. Export reports for stakeholders

---

## 📧 AUTOMATED REPORTS

### Daily Email (Auto-send):
- Tasks completed today
- Current blockers
- Critical bugs
- Team standup summary

### Weekly Email (Auto-send):
- Sprint progress
- Milestone status
- Risk updates
- Next week plan

---

## 💡 PRO TIPS

1. **Use Data Validation**: Dropdown lists for Status, Priority, Module
2. **Protect Headers**: Lock row 1 to prevent accidental changes
3. **Version Control**: Save weekly snapshots
4. **Real-time Collaboration**: Use Google Sheets for team updates
5. **Auto-backup**: Enable auto-save and version history
6. **Mobile Access**: Install Google Sheets app for on-the-go updates
7. **Integration**: Connect with Jira/Azure DevOps if available

---

## 🎯 SUCCESS METRICS TO TRACK

1. **Velocity**: Tasks completed per day/week
2. **Accuracy**: Estimated vs Actual hours
3. **Quality**: Bug count per module
4. **Efficiency**: Rework percentage
5. **Risk**: Active high risks count
6. **Team Health**: Utilization % and burnout indicators

---

*Template created: 27/11/2025*  
*Last updated: 27/11/2025*


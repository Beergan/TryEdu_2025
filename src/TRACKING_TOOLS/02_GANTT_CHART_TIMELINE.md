# 📅 GANTT CHART TIMELINE
## Project Schedule: 27/11/2025 - 29/12/2025 (33 days)

---

## 🎯 OVERVIEW

**Project Duration**: 33 working days  
**Demo Date**: 29/12/2025  
**Official Release**: 26/01/2026

---

## 📊 GANTT CHART (Text Format)

```
Legend:
█ = Completed
▓ = In Progress
░ = Planned
▢ = Not Started
! = Critical Path
* = Milestone
```

### Week 1: 27/11 - 03/12 (7 days)

```
Task                                    27  28  29  30  01  02  03
========================================================================
PROJECT SETUP                           !   !
├─ Review Architecture (Phong)          ▢   ▢
├─ Setup Environment (Kiên)             ▢   ▢
└─ Setup UI Framework (Cường)           ▢   ▢

DATABASE DESIGN                                 !   !   !
├─ Create Entities (Kiên)                       ▢   ▢   ▢
├─ Review Entities (Phong)                      ▢   ▢   ▢
└─ Design Wireframes (Cường)                    ▢   ▢   ▢

MIGRATIONS & SEEDS                                      !   !
├─ EF Migrations (Kiên)                                 ▢   ▢
├─ Test Migrations (Kiên)                               ▢   ▢
└─ Seed Data (Kiên)                                     ▢   ▢

* MILESTONE 1: Foundation Setup (03/12)                     *
```

### Week 2: 04/12 - 10/12 (7 days)

```
Task                                    04  05  06  07  08  09  10
========================================================================
AUTHENTICATION                          !   !   !
├─ User Entities (Kiên)                 ▢   ▢
├─ Auth Service (Kiên)                      ▢   ▢
├─ Login UI (Cường)                     ▢   ▢
└─ Register UI (Cường)                      ▢   ▢

PARTNER REGISTRATION                                !   !
├─ Partner Service (Kiên)                           ▢   ▢
├─ Partner UI (Cường)                               ▢   ▢
└─ Admin Approval (Kiên+Cường)                      ▢   ▢

TESTING WEEK 1-2                                        !   !
├─ Auth Flow Testing                                    ▢   ▢
├─ Partner Flow Testing                                 ▢   ▢
└─ Bug Fixes                                            ▢   ▢

* MILESTONE 2: Auth & Partner Setup (10/12)                 *
```

### Week 3: 11/12 - 17/12 (7 days)

```
Task                                    11  12  13  14  15  16  17
========================================================================
COIN SYSTEM                             !   !   !
├─ Coin Service (Kiên)                  ▢   ▢   ▢
├─ Coin Purchase UI (Cường)             ▢   ▢   ▢
└─ Balance Display (Cường)              ▢   ▢   ▢

REFERRAL CODE SYSTEM                            !   !
├─ Referral Service (Kiên)                      ▢   ▢
├─ Code Management UI (Cường)                   ▢   ▢
└─ Code Validation (Kiên)                       ▢   ▢

COMMISSION SYSTEM                                       !   !
├─ Commission Service (Kiên)                            ▢   ▢
├─ Dashboard (Cường)                                    ▢   ▢
└─ Reports (Kiên+Cường)                                 ▢   ▢

AI FOUNDATIONS (NGÂN HÀNG ĐỀ)                                 ▢
└─ Define Question Model (Phong+Kiên)                         ▢   ▢

* MILESTONE 3: Coin & Commission Complete (17/12)           *
```

### Week 4: 18/12 - 24/12 (7 days)

```
Task                                    18  19  20  21  22  23  24
========================================================================
COURSE MANAGEMENT                       !   !   !
├─ Course Service (Kiên)                ▢   ▢   ▢
├─ Course UI (Cường)                    ▢   ▢   ▢
└─ Course Catalog (Cường)               ▢   ▢   ▢

EXAM SYSTEM                                     !   !
├─ Exam Service (Kiên)                          ▢   ▢
├─ Exam Purchase (Kiên)                         ▢   ▢
└─ Exam UI (Cường)                              ▢   ▢

EXAM QUESTION BANK                          !   !   !
├─ Template & Section Entities (Kiên)       ▢   ▢
├─ Question Bank & Options (Kiên)           ▢   ▢
└─ Question Builder UI (Cường)                 ▢   ▢

INTEGRATION TESTING                                     !   !
├─ End-to-End Testing                                   ▢   ▢
├─ Performance Testing                                  ▢   ▢
└─ Security Review                                      ▢   ▢

* MILESTONE 4: Content System Complete (24/12)              *
```

### Week 5: 25/12 - 29/12 (5 days)

```
Task                                    25  26  27  28  29
============================================================
UI/UX POLISH                            !   !   !
├─ Component Polish (Cường)             ▢   ▢   ▢
├─ Error Handling (Cường)               ▢   ▢   ▢
└─ Responsive Design (Cường)            ▢   ▢   ▢

BACKEND OPTIMIZATION                    !   !   !
├─ API Documentation (Kiên)             ▢   ▢   ▢
├─ Performance Tuning (Kiên)            ▢   ▢   ▢
└─ Security Hardening (Kiên)            ▢   ▢   ▢

AI GRADING PREP                                   !   !
├─ Scoring Schema Snapshot (Phong+Kiên)           ▢   ▢
└─ Teacher Feedback Workflow (Cường)              ▢   ▢

DEMO PREPARATION                                !   !
├─ Demo Environment (All)                       ▢   ▢
├─ Demo Data (All)                              ▢   ▢
├─ Demo Script (All)                            ▢   ▢
└─ Presentation (Nguyên)                        ▢   ▢

* MILESTONE 5: DEMO READY (29/12) 🎉                  *
```

---

## 🎯 CRITICAL PATH ANALYSIS

### Critical Path Tasks (Cannot be delayed):
1. **27-28/11**: Project Setup → 2 days
2. **29/11-01/12**: Database Design → 3 days
3. **02-03/12**: Migrations → 2 days
4. **04-06/12**: Authentication → 3 days
5. **11-13/12**: Coin System → 3 days
6. **18-20/12**: Course Management → 3 days
7. **25-27/12**: UI/UX Polish → 3 days
8. **28/12**: Demo Prep → 1 day
9. **29/12**: DEMO DAY → 1 day

**Total Critical Path**: 21 days (out of 33 days)  
**Buffer**: 12 days (36% buffer)

---

## 📊 DETAILED GANTT (Visual Format)

### Generate this chart in:
- Microsoft Project
- Excel with Gantt chart template
- Google Sheets with timeline add-on
- Online tools: TeamGantt, GanttPRO, Monday.com

### Gantt Chart Data (CSV format):

```csv
Task Name,Start Date,End Date,Duration,Assignee,Predecessor,Status
Project Setup,27/11/2025,28/11/2025,2,Phong,-,Not Started
Review Architecture,27/11/2025,28/11/2025,2,Phong,-,Not Started
Setup Environment,27/11/2025,28/11/2025,2,Kiên,-,Not Started
Setup UI Framework,27/11/2025,28/11/2025,2,Cường,-,Not Started
Database Design,29/11/2025,01/12/2025,3,Kiên,1,Not Started
Create Entities,29/11/2025,01/12/2025,3,Kiên,1,Not Started
Review Entities,29/11/2025,01/12/2025,3,Phong,5,Not Started
Design Wireframes,29/11/2025,01/12/2025,3,Cường,5,Not Started
Migrations & Seeds,02/12/2025,03/12/2025,2,Kiên,4,Not Started
EF Migrations,02/12/2025,03/12/2025,2,Kiên,4,Not Started
Test Migrations,02/12/2025,03/12/2025,2,Kiên,9,Not Started
Seed Data,02/12/2025,03/12/2025,2,Kiên,9,Not Started
Authentication,04/12/2025,06/12/2025,3,Kiên,8,Not Started
User Entities,04/12/2025,05/12/2025,2,Kiên,8,Not Started
Auth Service,05/12/2025,06/12/2025,2,Kiên,13,Not Started
Login UI,04/12/2025,05/12/2025,2,Cường,8,Not Started
Register UI,05/12/2025,06/12/2025,2,Cường,15,Not Started
Partner Registration,07/12/2025,08/12/2025,2,Kiên,12,Not Started
Partner Service,07/12/2025,08/12/2025,2,Kiên,12,Not Started
Partner UI,07/12/2025,08/12/2025,2,Cường,12,Not Started
Admin Approval,07/12/2025,08/12/2025,2,Kiên+Cường,12,Not Started
Testing Week 1-2,09/12/2025,10/12/2025,2,All,17,Not Started
Coin System,11/12/2025,13/12/2025,3,Kiên,21,Not Started
Coin Service,11/12/2025,13/12/2025,3,Kiên,21,Not Started
Coin Purchase UI,11/12/2025,13/12/2025,3,Cường,21,Not Started
Balance Display,11/12/2025,13/12/2025,3,Cường,21,Not Started
Referral Code System,14/12/2025,15/12/2025,2,Kiên,22,Not Started
Referral Service,14/12/2025,15/12/2025,2,Kiên,22,Not Started
Code Management UI,14/12/2025,15/12/2025,2,Cường,22,Not Started
Code Validation,14/12/2025,15/12/2025,2,Kiên,22,Not Started
Define Question Model,15/12/2025,17/12/2025,3,Phong+Kiên,22,Not Started
Commission System,16/12/2025,17/12/2025,2,Kiên,26,Not Started
Commission Service,16/12/2025,17/12/2025,2,Kiên,26,Not Started
Dashboard,16/12/2025,17/12/2025,2,Cường,26,Not Started
Reports,16/12/2025,17/12/2025,2,Kiên+Cường,26,Not Started
Course Management,18/12/2025,20/12/2025,3,Kiên,30,Not Started
Course Service,18/12/2025,20/12/2025,3,Kiên,30,Not Started
Course UI,18/12/2025,20/12/2025,3,Cường,30,Not Started
Course Catalog,18/12/2025,20/12/2025,3,Cường,30,Not Started
Exam System,21/12/2025,22/12/2025,2,Kiên,34,Not Started
Exam Service,21/12/2025,22/12/2025,2,Kiên,34,Not Started
Exam Purchase,21/12/2025,22/12/2025,2,Kiên,34,Not Started
Exam UI,21/12/2025,22/12/2025,2,Cường,34,Not Started
Template & Section Entities,21/12/2025,22/12/2025,2,Kiên,34,Not Started
Question Bank & Options,22/12/2025,23/12/2025,2,Kiên,58,Not Started
Question Builder UI,22/12/2025,24/12/2025,3,Cường,58,Not Started
Integration Testing,23/12/2025,24/12/2025,2,All,38,Not Started
End-to-End Testing,23/12/2025,24/12/2025,2,All,38,Not Started
Performance Testing,23/12/2025,24/12/2025,2,All,38,Not Started
Security Review,23/12/2025,24/12/2025,2,All,38,Not Started
UI/UX Polish,25/12/2025,27/12/2025,3,Cường,42,Not Started
Component Polish,25/12/2025,27/12/2025,3,Cường,42,Not Started
Error Handling,25/12/2025,27/12/2025,3,Cường,42,Not Started
Responsive Design,25/12/2025,27/12/2025,3,Cường,42,Not Started
Backend Optimization,25/12/2025,27/12/2025,3,Kiên,42,Not Started
API Documentation,25/12/2025,27/12/2025,3,Kiên,42,Not Started
Performance Tuning,25/12/2025,27/12/2025,3,Kiên,42,Not Started
Security Hardening,25/12/2025,27/12/2025,3,Kiên,42,Not Started
Scoring Schema Snapshot,25/12/2025,26/12/2025,2,Phong+Kiên,46,Not Started
Teacher Feedback Workflow,26/12/2025,27/12/2025,2,Cường,84,Not Started
Demo Preparation,28/12/2025,28/12/2025,1,All,46,Not Started
Demo Environment,28/12/2025,28/12/2025,1,All,46,Not Started
Demo Data,28/12/2025,28/12/2025,1,All,46,Not Started
Demo Script,28/12/2025,28/12/2025,1,All,46,Not Started
Presentation,28/12/2025,28/12/2025,1,Nguyên,46,Not Started
DEMO DAY,29/12/2025,29/12/2025,1,All,50,Not Started
```

---

## 📊 RESOURCE ALLOCATION CHART

```
Week 1 (27/11-03/12):
Phong   ████████░░░░░░░░░░░░ (40%)
Kiên    ████████████████████ (100%)
Cường   ████████████░░░░░░░░ (60%)
Nguyên  ████░░░░░░░░░░░░░░░░ (20%)

Week 2 (04/12-10/12):
Phong   ████████░░░░░░░░░░░░ (40%)
Kiên    ████████████████████ (100%)
Cường   ████████████████████ (100%)
Nguyên  ██████░░░░░░░░░░░░░░ (30%)

Week 3 (11/12-17/12):
Phong   ██████░░░░░░░░░░░░░░ (30%)
Kiên    ████████████████████ (100%)
Cường   ████████████████████ (100%)
Nguyên  ████████░░░░░░░░░░░░ (40%)

Week 4 (18/12-24/12):
Phong   ██████░░░░░░░░░░░░░░ (30%)
Kiên    ████████████████████ (100%)
Cường   ████████████████░░░░ (80%)
Nguyên  ██████░░░░░░░░░░░░░░ (30%)

Week 5 (25/12-29/12):
Phong   ████████████░░░░░░░░ (60%)
Kiên    ████████████████░░░░ (80%)
Cường   ████████████████████ (100%)
Nguyên  ████████████░░░░░░░░ (60%)
```

---

## 🎯 MILESTONE DEPENDENCIES

```
Milestone 1: Foundation (03/12)
    ↓
    ├─ Required for: Authentication
    ├─ Required for: Partner System
    └─ Required for: All other modules

Milestone 2: Auth & Partner (10/12)
    ↓
    ├─ Required for: Coin System
    └─ Required for: User flows

Milestone 3: Coin & Commission (17/12)
    ↓
    ├─ Required for: Exam Purchase
    └─ Required for: Revenue tracking

Milestone 4: Content System (24/12)
    ↓
    └─ Required for: Complete demo flow

Milestone 5: DEMO READY (29/12)
    ↓
    └─ Final deliverable
```

---

## ⚠️ RISK TIMELINE

```
Week 1-2: HIGH RISK
- Environment setup issues
- Database design changes
- Team onboarding delays
→ Mitigation: Daily check-ins, pair programming

Week 3: MEDIUM RISK
- Payment gateway integration
- Coin calculation logic
→ Mitigation: Mock payment, extensive testing

Week 4: MEDIUM RISK
- Performance issues
- Integration challenges
→ Mitigation: Load testing, continuous integration

Week 5: HIGH RISK
- Last-minute bugs
- Demo environment issues
- Presentation preparation
→ Mitigation: Buffer time, backup plans
```

---

## 📅 CALENDAR VIEW

### November 2025
```
Mo Tu We Th Fr Sa Su
                1  2
 3  4  5  6  7  8  9
10 11 12 13 14 15 16
17 18 19 20 21 22 23
24 25 26 [27][28]29 30
         ██
         W1 Starts
```

### December 2025
```
Mo Tu We Th Fr Sa Su
 1 [2] 3 [4] 5  6  7
 █  █     ██
 8  9[10]11[12]13 14
       *   ██
      M2   W3
15[16]17[18]19 20 21
   ██  *  ██
   W3  M3 W4
22[23]24[25]26 27 28
   ██  *  ██  ██ [28]
   W4  M4 W5  W5  DP
[29]30 31
 🎉
DEMO
```

---

## 🔄 WEEKLY REVIEW SCHEDULE

**Every Friday 4:00 PM:**
- Sprint review
- Update Gantt chart
- Adjust timeline if needed
- Plan next week
- Risk review

---

## 📊 EXPORT OPTIONS

### Microsoft Project (.mpp):
- Professional Gantt charts
- Resource leveling
- Critical path analysis
- Cost tracking

### Excel (.xlsx):
- Simple Gantt with conditional formatting
- Easy sharing and updates
- Formula-based calculations

### Google Sheets:
- Real-time collaboration
- Timeline add-ons
- Auto-sync with team

### Online Tools:
- **TeamGantt**: Free for small teams
- **GanttProject**: Open source
- **ProjectLibre**: MS Project alternative
- **Monday.com**: Visual project management

---

## 💡 PRO TIPS

1. **Update Daily**: Keep the Gantt chart current
2. **Color Code**: Use colors for different modules
3. **Show Dependencies**: Visualize task relationships
4. **Track Slippage**: Monitor delays immediately
5. **Buffer Tasks**: Add buffer for high-risk items
6. **Communicate**: Share updates with stakeholders
7. **Version Control**: Save weekly snapshots

---

*Gantt Chart created: 27/11/2025*  
*Last updated: 27/11/2025*


# 🚨 RISK TRACKING CHECKLIST
## Comprehensive Risk Management for Project V2.0

---

## 🎯 RISK ASSESSMENT FRAMEWORK

### Risk Scoring:
- **Probability**: Low (1), Medium (2), High (3)
- **Impact**: Low (1), Medium (2), High (3)
- **Risk Score**: Probability × Impact (1-9)

### Risk Levels:
- **1-3**: 🟢 Low Risk (Monitor)
- **4-6**: 🟡 Medium Risk (Manage Actively)
- **7-9**: 🔴 High Risk (Immediate Action)

---

## 📋 TECHNICAL RISKS

### 🔴 R001: Payment Gateway Integration Delay

**Category**: Technical  
**Probability**: Medium (2)  
**Impact**: High (3)  
**Risk Score**: 6  
**Status**: Active

**Description:**
VNPay hoặc MoMo API integration có thể gặp delays do:
- API documentation không đầy đủ
- Test environment setup phức tạp
- Callback handling issues
- Security certificate problems

**Impact If Occurs:**
- Demo không có real payment
- Coin purchase flow incomplete
- Partner commission tracking delayed

**Mitigation Strategy:**
- [ ] Start với mock payment service (Week 1)
- [ ] Contact VNPay support team early
- [ ] Prepare sandbox environment by Day 5
- [ ] Create fallback manual payment flow
- [ ] Test callbacks extensively

**Contingency Plan:**
- Use mock payment for demo
- Show payment flow với test data
- Integrate real gateway in Phase 2

**Owner**: Kiên  
**Review Date**: 10/12/2025  
**Next Check**: 03/12/2025

**Monitoring:**
```
[ ] Day 3: Contact payment gateway support
[ ] Day 5: Sandbox environment ready
[ ] Day 10: Test integration complete
[ ] Day 15: Fallback plan tested
[ ] Day 20: Real integration complete
```

---

### 🟡 R002: MongoDB Setup Complexity

**Category**: Technical  
**Probability**: Low (1)  
**Impact**: Medium (2)  
**Risk Score**: 2  
**Status**: Active

**Description:**
MongoDB setup cho course/exam content có thể phức tạp do:
- Schema design cho nested documents
- Indexing strategy
- Connection pooling
- Backup/restore procedures

**Impact If Occurs:**
- Course content storage delayed
- Exam data retrieval slow
- Search functionality limited

**Mitigation Strategy:**
- [ ] Use PostgreSQL JSONB columns as alternative
- [ ] Start với simple MongoDB schema
- [ ] Test connection từ Day 2
- [ ] Document collections sớm
- [ ] Setup MongoDB Atlas cloud instance

**Contingency Plan:**
- Store all data trong PostgreSQL JSONB
- Migrate to MongoDB sau demo if needed

**Owner**: Phong, Kiên  
**Review Date**: 05/12/2025  
**Next Check**: 30/11/2025

**Monitoring:**
```
[ ] Day 2: MongoDB local setup complete
[ ] Day 4: Test queries working
[ ] Day 7: Schema finalized
[ ] Day 10: Performance tested
```

---

### 🟡 R003: Performance Issues with Large Data

**Category**: Technical  
**Probability**: Medium (2)  
**Impact**: Medium (2)  
**Risk Score**: 4  
**Status**: Active

**Description:**
System performance có thể chậm khi:
- Nhiều concurrent users
- Large exam submissions
- Complex commission calculations
- Heavy dashboard queries

**Impact If Occurs:**
- Slow page loads (>3 seconds)
- API timeouts
- Poor user experience
- Demo performance issues

**Mitigation Strategy:**
- [ ] Implement Redis caching từ Day 5
- [ ] Database query optimization
- [ ] Add indexes on frequently queried fields
- [ ] Use pagination cho large lists
- [ ] Load testing từ Week 3

**Contingency Plan:**
- Limit concurrent demo users
- Pre-cache demo data
- Simplify complex queries

**Owner**: Kiên, Phong  
**Review Date**: 15/12/2025  
**Next Check**: 05/12/2025

**Monitoring:**
```
[ ] Day 5: Redis caching implemented
[ ] Day 10: Query optimization done
[ ] Day 15: Load testing (50 users)
[ ] Day 20: Load testing (100 users)
[ ] Day 25: Performance tuning complete
```

---

### 🟢 R004: Entity Framework Migrations Issues

**Category**: Technical  
**Probability**: Low (1)  
**Impact**: Medium (2)  
**Risk Score**: 2  
**Status**: Active

**Description:**
EF Core migrations có thể fail do:
- Foreign key constraint conflicts
- Data type mismatches
- Seeding data errors
- Migration rollback issues

**Impact If Occurs:**
- Database schema incomplete
- Development delayed
- Data loss risk

**Mitigation Strategy:**
- [ ] Test migrations trên clean database daily
- [ ] Backup database before migrations
- [ ] Version control migration files
- [ ] Document migration steps
- [ ] Create rollback scripts

**Contingency Plan:**
- Manual SQL scripts for critical tables
- Fresh database setup if needed

**Owner**: Kiên  
**Review Date**: 05/12/2025  
**Next Check**: 02/12/2025

**Monitoring:**
```
[ ] Day 5: Initial migrations successful
[ ] Day 7: Seed data working
[ ] Day 10: All entities migrated
[ ] Day 15: No migration issues
```

---

### 🟢 R005: AI Grading Service Integration

**Category**: Technical  
**Probability**: Low (1)  
**Impact**: Low (1)  
**Risk Score**: 1  
**Status**: Active

**Description:**
AI grading service integration deferred to Phase 2, nhưng cần prepare:
- API structure for future integration
- Mock AI grading for demo
- Scoring algorithm design

**Impact If Occurs:**
- Manual grading only for demo
- Teacher workload higher
- Demo shows manual process

**Mitigation Strategy:**
- [ ] Design AI service interface early
- [ ] Create mock AI responses
- [ ] Show future roadmap trong demo
- [ ] Focus on manual grading flow

**Contingency Plan:**
- Demo chỉ show manual grading
- AI integration là Phase 2 feature

**Owner**: Phong  
**Review Date**: Phase 2  
**Next Check**: 20/12/2025

---

## 📅 SCHEDULE RISKS

### 🔴 R006: Feature Creep

**Category**: Schedule  
**Probability**: High (3)  
**Impact**: High (3)  
**Risk Score**: 9  
**Status**: Active

**Description:**
Stakeholders hoặc team add thêm features ngoài scope:
- "Can we add this small feature?"
- "Just one more thing..."
- UI/UX enhancements requests
- Additional reporting requirements

**Impact If Occurs:**
- Missed demo deadline (29/12)
- Core features incomplete
- Team burnout
- Technical debt increase

**Mitigation Strategy:**
- [ ] Strict scope freeze after Day 3
- [ ] Document all P0 features clearly
- [ ] Change request process (requires PO approval)
- [ ] Feature backlog for Phase 2
- [ ] Weekly scope review

**Contingency Plan:**
- Push non-P0 features to Phase 2
- Reduce P1/P2 feature scope
- Focus only on demo-critical features

**Owner**: Nguyên (PO)  
**Review Date**: Weekly  
**Next Check**: Daily

**Monitoring:**
```
[ ] Day 3: Scope locked and documented
[ ] Weekly: Review change requests
[ ] Daily: Track scope additions
[ ] Day 25: Final scope validation
```

---

### 🟡 R007: Unexpected Bugs & Issues

**Category**: Schedule  
**Probability**: High (3)  
**Impact**: Medium (2)  
**Risk Score**: 6  
**Status**: Active

**Description:**
Critical bugs discovered late trong development:
- Integration issues
- Data corruption
- Security vulnerabilities
- Browser compatibility issues

**Impact If Occurs:**
- Last-minute bug fixing
- Demo day issues
- Reduced testing time
- Quality concerns

**Mitigation Strategy:**
- [ ] Daily code reviews
- [ ] Continuous integration testing
- [ ] Bug triage meetings (Tue/Thu)
- [ ] Reserve buffer time (Week 5)
- [ ] Smoke testing daily

**Contingency Plan:**
- Focus on P0 bug fixes only
- Accept minor bugs for demo
- Document known issues
- Fix post-demo in Phase 2

**Owner**: All  
**Review Date**: Bi-weekly  
**Next Check**: Daily standup

**Monitoring:**
```
[ ] Daily: Log all bugs
[ ] Day 10: Critical bugs = 0
[ ] Day 20: High bugs < 5
[ ] Day 28: All P0 bugs fixed
```

---

### 🟡 R008: Key Person Unavailability

**Category**: Resource  
**Probability**: Medium (2)  
**Impact**: High (3)  
**Risk Score**: 6  
**Status**: Active

**Description:**
Team member sick, emergency, hoặc unavailable:
- Kiên (Backend lead)
- Cường (Frontend lead)
- Phong (Architect)

**Impact If Occurs:**
- Development blocked
- Knowledge gaps
- Schedule delays
- Quality issues

**Mitigation Strategy:**
- [ ] Cross-training sessions (Week 1)
- [ ] Document all code decisions
- [ ] Code reviews for knowledge sharing
- [ ] Backup person for each role
- [ ] Daily standups for visibility

**Contingency Plan:**
- Phong can help with backend
- Redistribute tasks to team
- Reduce scope if needed

**Owner**: Nguyên  
**Review Date**: Weekly  
**Next Check**: Daily

**Monitoring:**
```
[ ] Day 3: Cross-training complete
[ ] Day 7: Documentation up-to-date
[ ] Daily: Team availability check
[ ] Day 20: Backup plan tested
```

---

### 🟢 R009: Testing Time Shortage

**Category**: Schedule  
**Probability**: Medium (2)  
**Impact**: Low (1)  
**Risk Score**: 2  
**Status**: Active

**Description:**
Không đủ time cho thorough testing:
- Integration testing
- Performance testing
- Security testing
- User acceptance testing

**Impact If Occurs:**
- Bugs discovered during demo
- Poor user experience
- Security vulnerabilities
- Performance issues

**Mitigation Strategy:**
- [ ] Test continuously, not just at end
- [ ] Automated testing where possible
- [ ] Daily smoke testing
- [ ] Week 5 dedicated to testing
- [ ] Early UAT with stakeholders

**Contingency Plan:**
- Focus on critical path testing
- Accept minor issues for demo
- Document known issues

**Owner**: All  
**Review Date**: Weekly  
**Next Check**: Day 10, 20

**Monitoring:**
```
[ ] Day 7: Test strategy defined
[ ] Day 14: First integration test
[ ] Day 21: Performance test done
[ ] Day 28: Full regression test
```

---

## 👥 RESOURCE RISKS

### 🟡 R010: Team Overload & Burnout

**Category**: Resource  
**Probability**: Medium (2)  
**Impact**: Medium (2)  
**Risk Score**: 4  
**Status**: Active

**Description:**
Team working too hard, risking burnout:
- Long hours consistently
- Weekend work
- High stress levels
- No breaks

**Impact If Occurs:**
- Decreased productivity
- Quality issues
- Sick days
- Mistakes increase

**Mitigation Strategy:**
- [ ] Monitor work hours daily
- [ ] Encourage breaks
- [ ] No weekend work unless critical
- [ ] Team morale check-ins
- [ ] Celebrate small wins

**Contingency Plan:**
- Reduce scope if team overloaded
- Bring in additional help if budget allows
- Extend deadline if necessary

**Owner**: Nguyên, Phong  
**Review Date**: Weekly  
**Next Check**: Daily

**Monitoring:**
```
[ ] Daily: Check work hours (<9 hrs/day)
[ ] Weekly: Team morale survey
[ ] Day 15: Burnout assessment
[ ] Day 25: Final push support
```

---

### 🟢 R011: Skill Gaps

**Category**: Resource  
**Probability**: Low (1)  
**Impact**: Medium (2)  
**Risk Score**: 2  
**Status**: Active

**Description:**
Team lacks specific technical skills:
- Advanced .NET Core features
- Blazor best practices
- PostgreSQL optimization
- MongoDB queries
- Redis caching

**Impact If Occurs:**
- Suboptimal implementations
- Performance issues
- Technical debt
- Longer development time

**Mitigation Strategy:**
- [ ] Identify skill gaps early (Day 1)
- [ ] Online training resources
- [ ] Pair programming
- [ ] Code review for learning
- [ ] Phong provides guidance

**Contingency Plan:**
- Simplify implementations
- Use known technologies
- Defer advanced features to Phase 2

**Owner**: Phong  
**Review Date**: 05/12/2025  
**Next Check**: Weekly

**Monitoring:**
```
[ ] Day 1: Skill gap assessment
[ ] Day 5: Training materials shared
[ ] Day 10: Knowledge sharing session
[ ] Day 20: Skills improved check
```

---

## 💼 BUSINESS RISKS

### 🟡 R012: Stakeholder Expectation Mismatch

**Category**: Business  
**Probability**: Medium (2)  
**Impact**: High (3)  
**Risk Score**: 6  
**Status**: Active

**Description:**
Stakeholders expect more than what's deliverable:
- More features than MVP
- Production-ready quality
- Full AI integration
- Mobile app

**Impact If Occurs:**
- Demo disappointment
- Scope pressure
- Budget concerns
- Timeline conflicts

**Mitigation Strategy:**
- [ ] Clear MVP definition (Day 1)
- [ ] Weekly stakeholder updates
- [ ] Demo scope document signed-off
- [ ] Manage expectations early
- [ ] Show Phase 2 roadmap

**Contingency Plan:**
- Re-align expectations before demo
- Focus on business value delivered
- Show roadmap for additional features

**Owner**: Nguyên  
**Review Date**: Weekly  
**Next Check**: Day 3, 10, 20

**Monitoring:**
```
[ ] Day 3: MVP scope approved by stakeholders
[ ] Day 10: First stakeholder demo
[ ] Day 20: Expectation checkpoint
[ ] Day 28: Final alignment meeting
```

---

### 🟢 R013: Budget Overrun

**Category**: Business  
**Probability**: Low (1)  
**Impact**: Medium (2)  
**Risk Score**: 2  
**Status**: Active

**Description:**
Project costs exceed budget:
- Cloud infrastructure costs
- Third-party API costs
- Additional resources needed
- Extended timeline

**Impact If Occurs:**
- Project pause
- Scope reduction
- Resource constraints

**Mitigation Strategy:**
- [ ] Track costs weekly
- [ ] Use free tiers where possible
- [ ] Optimize cloud resources
- [ ] Budget review meetings

**Contingency Plan:**
- Reduce infrastructure scope
- Use cheaper alternatives
- Defer costly features

**Owner**: Nguyên  
**Review Date**: Weekly  
**Next Check**: Day 10

**Monitoring:**
```
[ ] Day 7: Budget baseline set
[ ] Day 14: Cost tracking review
[ ] Day 21: Budget forecast
[ ] Day 28: Final budget check
```

---

## 🌍 EXTERNAL RISKS

### 🟢 R014: Third-Party Service Downtime

**Category**: External  
**Probability**: Low (1)  
**Impact**: Medium (2)  
**Risk Score**: 2  
**Status**: Active

**Description:**
External services unavailable:
- Payment gateway down
- Email service down
- Cloud provider issues
- CDN problems

**Impact If Occurs:**
- Development blocked
- Testing delayed
- Demo issues

**Mitigation Strategy:**
- [ ] Monitor service status pages
- [ ] Have backup accounts
- [ ] Local fallbacks for development
- [ ] Test with mock services

**Contingency Plan:**
- Use mock services
- Reschedule demo if critical
- Have offline demo option

**Owner**: Kiên  
**Review Date**: As needed  
**Next Check**: Weekly

---

### 🟢 R015: Holiday Season Impact

**Category**: External  
**Probability**: Medium (2)  
**Impact**: Low (1)  
**Risk Score**: 2  
**Status**: Active

**Description:**
Demo date (29/12) is during holiday season:
- Team may want time off
- Stakeholders may be unavailable
- Reduced support availability
- Lower energy levels

**Impact If Occurs:**
- Attendance issues
- Demo reschedule
- Delayed feedback

**Mitigation Strategy:**
- [ ] Confirm team availability early
- [ ] Finish core work before 24/12
- [ ] Buffer time in Week 5
- [ ] Flexible demo date (28-30/12)

**Contingency Plan:**
- Move demo to first week of Jan
- Virtual demo option
- Record demo video

**Owner**: Nguyên  
**Review Date**: 15/12/2025  
**Next Check**: 10/12/2025

---

## 📊 RISK DASHBOARD

### Current Risk Summary:

| Risk Level | Count | Percentage |
|------------|-------|------------|
| 🔴 High (7-9) | 2 | 13% |
| 🟡 Medium (4-6) | 7 | 47% |
| 🟢 Low (1-3) | 6 | 40% |
| **Total** | **15** | **100%** |

### Risks by Category:

| Category | Count |
|----------|-------|
| Technical | 5 |
| Schedule | 4 |
| Resource | 2 |
| Business | 2 |
| External | 2 |

### Active Risks Requiring Immediate Attention:

- [ ] 🔴 R001: Payment Gateway Integration (Review: 03/12)
- [ ] 🔴 R006: Feature Creep (Review: Daily)

---

## 🔄 RISK REVIEW SCHEDULE

### Daily (9:15 AM - After Standup):
- Quick risk check
- New risks identified?
- Critical risks status
- Immediate actions needed

### Weekly (Friday 3:00 PM):
- Full risk register review
- Update risk scores
- Review mitigation progress
- Close resolved risks
- Add new risks

### Ad-hoc:
- When new risk identified
- When risk becomes critical
- When mitigation fails

---

## 📝 RISK LOG TEMPLATE

### New Risk Entry:

```markdown
### 🟡 R0XX: [Risk Title]

**Category**: [Technical/Schedule/Resource/Business/External]
**Probability**: [Low/Medium/High] (1-3)
**Impact**: [Low/Medium/High] (1-3)
**Risk Score**: [1-9]
**Status**: [Active/Mitigated/Closed]

**Description:**
[Detailed description of the risk]

**Impact If Occurs:**
- [Impact 1]
- [Impact 2]

**Mitigation Strategy:**
- [ ] [Action 1]
- [ ] [Action 2]

**Contingency Plan:**
[What to do if risk occurs]

**Owner**: [Name]
**Review Date**: [Date]
**Next Check**: [Date]

**Monitoring:**
```
[ ] [Checkpoint 1]
[ ] [Checkpoint 2]
```
```

---

## 🎯 RISK ESCALATION PROCESS

### Level 1: Team Level (Risk Score 1-3)
- **Action**: Team manages
- **Report**: Weekly standup
- **Owner**: Individual team member

### Level 2: PM Level (Risk Score 4-6)
- **Action**: PM involvement
- **Report**: Weekly to stakeholders
- **Owner**: Nguyên/Phong

### Level 3: Executive Level (Risk Score 7-9)
- **Action**: Immediate escalation
- **Report**: Immediately
- **Owner**: Nguyên + Management

---

## ✅ RISK MITIGATION CHECKLIST

### Week 1 (27/11 - 03/12):
- [ ] Identify all potential risks
- [ ] Score and prioritize risks
- [ ] Assign risk owners
- [ ] Document mitigation strategies
- [ ] Setup risk tracking process

### Week 2 (04/12 - 10/12):
- [ ] Review risk register
- [ ] Update risk scores
- [ ] Check mitigation progress
- [ ] Add new risks if any

### Week 3 (11/12 - 17/12):
- [ ] Mid-project risk review
- [ ] Re-assess probability/impact
- [ ] Close resolved risks
- [ ] Escalate high risks

### Week 4 (18/12 - 24/12):
- [ ] Final risk assessment
- [ ] Ensure contingency plans ready
- [ ] Demo-specific risk check

### Week 5 (25/12 - 29/12):
- [ ] Daily risk monitoring
- [ ] Quick mitigation actions
- [ ] Demo day risk management

---

## 💡 RISK MANAGEMENT BEST PRACTICES

1. **Be Proactive**: Identify risks early
2. **Be Honest**: Don't hide risks
3. **Be Specific**: Detailed mitigation plans
4. **Be Prepared**: Have contingency plans
5. **Communicate**: Keep stakeholders informed
6. **Monitor**: Regular risk reviews
7. **Learn**: Document lessons learned

---

## 📞 EMERGENCY CONTACTS

### Risk Escalation:
- **Technical Issues**: Phong (System Architect)
- **Schedule Issues**: Nguyên (Product Owner)
- **Resource Issues**: Nguyên (Product Owner)
- **Business Issues**: Management Team

---

*Risk Register created: 27/11/2025*  
*Last updated: 27/11/2025*  
*Next review: Weekly Fridays*


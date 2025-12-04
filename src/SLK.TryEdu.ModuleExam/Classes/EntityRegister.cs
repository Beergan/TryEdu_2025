using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SLK.TryEdu.Abstract;
using SLK.TryEdu.Base; 
using SLK.TryEdu.ModuleExamCore;

namespace SLK.TryEdu.ModuleExam;   

public class EntityRegister : IEntityRegister
{
    public void RegisterEntities(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<EntityExam>().HasAlternateKey(k => k.Guid);
        modelBuilder.Entity<EntityExamAttemptQuestion>().HasAlternateKey(k => k.Guid);
        modelBuilder.Entity<EntityExamQuestion>().HasAlternateKey(k => k.Guid);
        modelBuilder.Entity<EntityExamSubmission>().HasAlternateKey(k => k.Guid);
        modelBuilder.Entity<EntityExamTemplate>().HasAlternateKey(k => k.Guid);
        modelBuilder.Entity<EntityExamTemplateQuestion>().HasAlternateKey(k => k.Guid);
        modelBuilder.Entity<EntityExamTemplateSection>().HasAlternateKey(k => k.Guid);
        modelBuilder.Entity<EntityQuestionOption>().HasAlternateKey(k => k.Guid);

    }
    public void Seed(IDbContext db)
    {
        
    }
}
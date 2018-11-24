using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeBank.Entities.EntityConfigurations
{
    public class CandidateConfiguration : EntityTypeConfiguration<Candidate>
    {
        public CandidateConfiguration()
        {
            Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(255);

            Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(255);

            Property(c => c.Phone)
                .IsRequired()
                .HasMaxLength(14);

            HasRequired(c => c.Gender)
                .WithMany()
                .HasForeignKey(c => c.GenderId);

            HasRequired(c => c.PrimaryCategory)
                .WithMany()
                .HasForeignKey(c => c.PrimaryCategoryId);

            HasMany(c => c.SubCategories)
                .WithMany(s => s.Candidates)
                .Map(m =>
                {
                    m.ToTable("CandidateSubCategories");
                    m.MapLeftKey("CandidateId");
                    m.MapRightKey("SubCategoryId");                    
                });

            HasOptional(c => c.EducationLevel)
                .WithMany()
                .HasForeignKey(c => c.EducationLevelId);

            HasOptional(c => c.Subject)
                .WithMany()
                .HasForeignKey(c => c.SubjectId);

            HasOptional(c => c.Institute)
                .WithMany()
                .HasForeignKey(c => c.InstituteId);

            HasOptional(c => c.JobLevel)
                .WithMany()
                .HasForeignKey(c => c.JobLevelId);

            HasOptional(c => c.OriginalResume)
                .WithRequired(or => or.Candidate);
        }
    }
}

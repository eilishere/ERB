using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeBank.Entities.EntityConfigurations
{
    public class CandidateSubCategoryConfiguration : EntityTypeConfiguration<CandidateSubCategory>
    {
        public CandidateSubCategoryConfiguration()
        {
            HasRequired(c => c.Candidate)
                .WithMany(c => c.CandidateSubCategories)
                .HasForeignKey(c => c.CandidateId)
                .WillCascadeOnDelete(false);

        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeBank.Entities.EntityConfigurations
{
    public class JobLevelConfiguration : EntityTypeConfiguration<JobLevel>
    {
        public JobLevelConfiguration()
        {
            Property(j => j.Name)
                .IsRequired()
                .HasMaxLength(255);
        }        
    }
}

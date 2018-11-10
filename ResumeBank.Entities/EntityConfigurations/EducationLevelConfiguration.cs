using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeBank.Entities.EntityConfigurations
{
    public class EducationLevelConfiguration : EntityTypeConfiguration<EducationLevel>
    {
        public EducationLevelConfiguration()
        {
            Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(255);
        }
    }
}

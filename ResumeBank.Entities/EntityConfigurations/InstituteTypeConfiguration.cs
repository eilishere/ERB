using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeBank.Entities.EntityConfigurations
{
    public class InstituteTypeConfiguration : EntityTypeConfiguration<InstituteType>
    {
        public InstituteTypeConfiguration()
        {
            Property(i => i.Name)
                .IsRequired()
                .HasMaxLength(255);            
        }
    }
}

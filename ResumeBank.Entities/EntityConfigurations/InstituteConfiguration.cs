using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeBank.Entities.EntityConfigurations
{
    public class InstituteConfiguration : EntityTypeConfiguration<Institute>
    {
        public InstituteConfiguration()
        {
            Property(i => i.Name)
                .IsRequired()
                .HasMaxLength(255);

            HasRequired(it => it.InstituteType)
                .WithMany()
                .HasForeignKey(it => it.InstituteTypeId);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeBank.Entities.EntityConfigurations
{
    public class AttachmentConfiguration : EntityTypeConfiguration<Attachment>
    {
        public AttachmentConfiguration()
        {
            Property(a => a.OriginalName)
                .IsRequired()
                .HasMaxLength(255);            
        }
    }
}

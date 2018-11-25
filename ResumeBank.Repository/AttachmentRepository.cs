using ResumeBank.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeBank.Repository
{
    public class AttachmentRepository : Repository<Attachment>
    {
        private RBDbContext _context;

        public AttachmentRepository(RBDbContext context)
            : base(context)
        {
            _context = context;
        }
    }
}

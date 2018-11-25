using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeBank.Repository
{
    public class AttachmentUnitOfWork : IDisposable
    {
        private RBDbContext _context;
        private AttachmentRepository _attachmentRepository;

        public AttachmentUnitOfWork(RBDbContext context)
        {
            _context = context;
            _attachmentRepository = new AttachmentRepository(_context);
        }

        public AttachmentRepository AttachmentRepository
        {
            get
            {
                return _attachmentRepository;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeBank.Repository
{
    public class SubjectUnitOfWork : IDisposable
    {
        private RBDbContext _context;
        private SubjectRepository _subjectRepository;

        public SubjectUnitOfWork(RBDbContext context)
        {
            _context = context;
            _subjectRepository = new SubjectRepository(_context);
        }

        public SubjectRepository SubjectRepository
        {
            get
            {
                return _subjectRepository;
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

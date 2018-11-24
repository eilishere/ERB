using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeBank.Repository
{
    public class CandidateUnitOfWork : IDisposable
    {
        private RBDbContext _context;
        private CandidateRepository _candidateRepository;

        public CandidateUnitOfWork(RBDbContext context)
        {
            _context = context;
            _candidateRepository = new CandidateRepository(_context);
        }

        public CandidateRepository CandidateRepository
        {
            get
            {
                return _candidateRepository;
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

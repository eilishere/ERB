using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeBank.Repository
{
    public class CandidateSubCategoryUnitOfWork : IDisposable
    {
        private RBDbContext _context;
        private CandidateSubCategoryRepository _candidateSubCategoryRepository;

        public CandidateSubCategoryUnitOfWork(RBDbContext context)
        {
            _context = context;
            _candidateSubCategoryRepository = new CandidateSubCategoryRepository(_context);
        }

        public CandidateSubCategoryRepository CandidateSubCategoryRepository
        {
            get
            {
                return _candidateSubCategoryRepository;
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

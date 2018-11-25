using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeBank.Repository
{
    public class EducationLevelUnitOfWork : IDisposable
    {
        private RBDbContext _context;
        private EducationLevelRepository _educationLevelRepository;

        public EducationLevelUnitOfWork(RBDbContext context)
        {
            _context = context;
            _educationLevelRepository = new EducationLevelRepository(_context);
        }

        public EducationLevelRepository EducationLevelRepository
        {
            get
            {
                return _educationLevelRepository;
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

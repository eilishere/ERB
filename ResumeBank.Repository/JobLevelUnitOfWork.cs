using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeBank.Repository
{
     public class JobLevelUnitOfWork : IDisposable
    {
        private RBDbContext _context;
        private JobLevelRepository _jobLevelRepository;

        public JobLevelUnitOfWork(RBDbContext context)
        {
            _context = context;
            _jobLevelRepository = new JobLevelRepository(_context);
        }

        public JobLevelRepository JobLevelRepository
        {
            get
            {
                return _jobLevelRepository;
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

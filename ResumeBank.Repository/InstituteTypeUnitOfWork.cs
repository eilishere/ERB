using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeBank.Repository
{
    public class InstituteTypeUnitOfWork : IDisposable
    {
        private RBDbContext _context;
        private InstituteTypeRepository _instituteTypeRepository;

        public InstituteTypeUnitOfWork(RBDbContext context)
        {
            _context = context;
            _instituteTypeRepository = new InstituteTypeRepository(_context);
        }

        public InstituteTypeRepository InstituteTypeRepository
        {
            get
            {
                return _instituteTypeRepository;
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

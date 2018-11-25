using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeBank.Repository
{
    public class InstituteUnitOfWork : IDisposable
    {
        private RBDbContext _context;
        private InstituteRepository _instituteRepository;

        public InstituteUnitOfWork(RBDbContext context)
        {
            _context = context;
            _instituteRepository = new InstituteRepository(_context);
        }

        public InstituteRepository InstituteRepository
        {
            get
            {
                return _instituteRepository;
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

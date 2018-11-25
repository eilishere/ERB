using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeBank.Repository
{
    public class GenderUnitOfWork : IDisposable
    {
        private RBDbContext _context;
        private GenderRepository _genderRepository;

        public GenderUnitOfWork(RBDbContext context)
        {
            _context = context;
            _genderRepository = new GenderRepository(_context);
        }

        public GenderRepository GenderRepository
        {
            get
            {
                return _genderRepository;
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

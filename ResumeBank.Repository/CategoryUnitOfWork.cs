using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeBank.Repository
{
    public class CategoryUnitOfWork : IDisposable
    {
        private RBDbContext _context;
        private CategoryRepository _categoryRepository; 

        public CategoryUnitOfWork(RBDbContext context)
        {
            _context = context;
            _categoryRepository = new CategoryRepository(_context);
        }

        public CategoryRepository CategoryRepository
        {
            get
            {
                return _categoryRepository;
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

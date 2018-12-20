using ResumeBank.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeBank.Repository
{
    public class CategoryRepository : Repository<Category>
    {
        private RBDbContext _context;

        public CategoryRepository(RBDbContext context)
            :base(context)
        {
            _context = context;
        }

        public IEnumerable<Category> GetAllSubCategories(int id)
        {
            return _context.Categories.Where(c => c.Status == 1 && c.ParentId == id).ToList();
        }
    }
}

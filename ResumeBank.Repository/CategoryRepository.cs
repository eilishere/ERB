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
    }
}

using ResumeBank.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeBank.Repository
{
    public class GenderRepository : Repository<Gender>
    {
        private RBDbContext _context;

        public GenderRepository(RBDbContext context)
            : base(context)
        {
            _context = context;
        }
    }
}

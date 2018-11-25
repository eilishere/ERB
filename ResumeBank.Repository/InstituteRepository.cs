using ResumeBank.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeBank.Repository
{
    public class InstituteRepository : Repository<Institute>
    {
        private RBDbContext _context;

        public InstituteRepository(RBDbContext context)
            : base(context)
        {
            _context = context;
        }
    }
}

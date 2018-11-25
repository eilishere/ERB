using ResumeBank.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeBank.Repository
{
    public class InstituteTypeRepository : Repository<InstituteType>
    {
        private RBDbContext _context;

        public InstituteTypeRepository(RBDbContext context)
            : base(context)
        {
            _context = context;
        }
    }
}

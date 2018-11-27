using ResumeBank.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeBank.Repository
{
    public class SubjectRepository : Repository<Subject>
    {
        private RBDbContext _context;

        public SubjectRepository(RBDbContext context)
            : base(context)
        {
            _context = context;
        }
    }
}

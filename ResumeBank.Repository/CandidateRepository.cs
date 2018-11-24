using ResumeBank.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeBank.Repository
{
    public class CandidateRepository : Repository<Candidate>
    {
        private RBDbContext _context;

        public CandidateRepository(RBDbContext context)
            : base(context)
        {
            _context = context;
        }
    }
}

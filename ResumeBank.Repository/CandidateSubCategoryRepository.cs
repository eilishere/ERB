using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResumeBank.Entities;

namespace ResumeBank.Repository
{
    public class CandidateSubCategoryRepository : Repository<CandidateSubCategory>
    {
        private RBDbContext _context;
        public CandidateSubCategoryRepository(RBDbContext context) : base(context)
        {
            _context = context;
        }
    }
}

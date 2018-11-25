using ResumeBank.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeBank.Repository
{

    public class EducationLevelRepository : Repository<EducationLevel>
    {
        private RBDbContext _context;

        public EducationLevelRepository(RBDbContext context)
            : base(context)
        {
            _context = context;
        }
    }
}

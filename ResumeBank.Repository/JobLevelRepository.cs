using ResumeBank.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeBank.Repository
{
    public class JobLevelRepository: Repository<JobLevel>
    {
        private RBDbContext _context;

        public JobLevelRepository(RBDbContext context)
            : base(context)
        {
            _context = context;
        }
    }
}

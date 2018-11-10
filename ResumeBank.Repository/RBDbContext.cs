using ResumeBank.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeBank.Repository
{
    public class RBDbContext : DbContext 
    {
        public DbSet<Candidate> Candidates { get; set; }

        public RBDbContext()
            : base("ERBDbConnection")
        {

        }
    }
}

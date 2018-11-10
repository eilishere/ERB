using ResumeBank.Entities;
using ResumeBank.Entities.EntityConfigurations;
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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CategoryConfiguration());
            modelBuilder.Configurations.Add(new EducationLevelConfiguration());
            modelBuilder.Configurations.Add(new InstituteConfiguration());
            modelBuilder.Configurations.Add(new InstituteTypeConfiguration());
            modelBuilder.Configurations.Add(new CandidateConfiguration());
            modelBuilder.Configurations.Add(new SubjectConfiguration());

        }
    }
}

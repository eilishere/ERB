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
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<EducationLevel> EducationLevels { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<InstituteType> InstituteTypes { get; set; }
        public DbSet<Institute> Institutes { get; set; }
        public DbSet<JobLevel> JobLevels { get; set; }
        public DbSet<Subject> Subjects { get; set; }


        public RBDbContext()
            : base("ERBDbConnection")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AttachmentConfiguration());
            modelBuilder.Configurations.Add(new CategoryConfiguration());
            modelBuilder.Configurations.Add(new EducationLevelConfiguration());
            modelBuilder.Configurations.Add(new InstituteConfiguration());
            modelBuilder.Configurations.Add(new InstituteTypeConfiguration());
            modelBuilder.Configurations.Add(new JobLevelConfiguration());
            modelBuilder.Configurations.Add(new CandidateConfiguration());
            modelBuilder.Configurations.Add(new SubjectConfiguration());

        }
    }
}

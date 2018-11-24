using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeBank.Entities
{
    public class Candidate : Entity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public double? CurrentSalary { get; set; }
        public double? ExpectedSalary { get; set; }
        public double? TotalExperience { get; set; }
        public string Keywords { get; set; }
        public string Training { get; set; }

        public int GenderId { get; set; }
        public Gender Gender { get; set; }

        public int PrimaryCategoryId { get; set; }
        public virtual Category PrimaryCategory { get; set; }

        public virtual ICollection<Category> SubCategories { get; set; }

        public int? EducationLevelId { get; set; }
        public virtual EducationLevel EducationLevel { get; set; }

        public int? SubjectId { get; set; }
        public virtual Subject Subject { get; set; }

        public int? InstituteId { get; set; }
        public virtual Institute Institute { get; set; }

        public int? JobLevelId { get; set; }
        public virtual JobLevel JobLevel { get; set; }

        public int? OriginalResumeId { get; set; }
        public virtual Attachment OriginalResume { get; set; }

        public int? ModifiedResumeId { get; set; }
        public virtual Attachment ModifiedResume { get; set; }        
    }
}

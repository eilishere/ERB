using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeBank.Entities
{
    public class Candidate : Entity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        public string Address { get; set; }
        [Display(Name = "Date Of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DateOfBirth { get; set; }
        [Display(Name = "Current Salary")]
        public double? CurrentSalary { get; set; }
        [Display(Name = "Expected Salary")]
        public double? ExpectedSalary { get; set; }
        [Display(Name = "Total Experience")]
        public double? TotalExperience { get; set; }
        public string Keywords { get; set; }
        public string Training { get; set; }

        [Required]
        [Display(Name = "Gender")]
        public int GenderId { get; set; }
        public Gender Gender { get; set; }

        [Required]
        [Display(Name = "Category")]
        public int PrimaryCategoryId { get; set; }
        public virtual Category PrimaryCategory { get; set; }

        [Display(Name = "Sub-Category")]
        public virtual ICollection<CandidateSubCategory> CandidateSubCategories { get; set; }

        [Required]
        [Display(Name = "Education Level")]
        public int? EducationLevelId { get; set; }
        public virtual EducationLevel EducationLevel { get; set; }

        [Required]
        [Display(Name = "Subject")]
        public int? SubjectId { get; set; }
        public virtual Subject Subject { get; set; }

        [Required]
        [Display(Name = "Institute")]
        public int? InstituteId { get; set; }
        public virtual Institute Institute { get; set; }

        [Required]
        [Display(Name = "Job Level")]
        public int? JobLevelId { get; set; }
        public virtual JobLevel JobLevel { get; set; }

        public int? OriginalResumeId { get; set; }
        public virtual Attachment OriginalResume { get; set; }

        public int? ModifiedResumeId { get; set; }
        public virtual Attachment ModifiedResume { get; set; }      
    }
}

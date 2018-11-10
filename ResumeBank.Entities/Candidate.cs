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
        public double CurrentSalary { get; set; }
        public double ExpectedSalary { get; set; }
        public string MyProperty { get; set; }

        public virtual Category PrimaryCategory { get; set; }
        public virtual List<Category> SubCategories { get; set; }
        public virtual EducationLevel EducationLevel { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual Institute Institute { get; set; }
        public virtual Attachment OriginalResume { get; set; }
        public virtual Attachment ModifiedResume { get; set; }        
    }
}

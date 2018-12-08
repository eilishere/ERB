using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeBank.Entities
{
    public class CandidateSubCategory : Entity
    {
        public int CandidateId { get; set; }
        public virtual Candidate Candidate { get; set; }
        public int SubCategoryId { get; set; }
        public virtual Category SubCategory { get; set; }
    }
}

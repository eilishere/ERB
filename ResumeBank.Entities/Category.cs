using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeBank.Entities
{
    public class Category : Entity
    {
        [Required]
        public string Name { get; set; }

        [Display(Name = "Parent Category")]
        public int? ParentId { get; set; }
        public virtual Category ParentCategory { get; set; }
    }
}

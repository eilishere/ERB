using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeBank.Entities
{
    public class Category : Entity
    {
        public string Name { get; set; }
        public virtual Category ParentCategory { get; set; }
    }
}

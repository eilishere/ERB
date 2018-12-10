using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeBank.Entities
{
    public class Attachment : Entity
    {
        public string Caption { get; set; }
        public string Url { get; set; }
        public string OriginalName { get; set; }
        public string CurrentName { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeBank.Entities
{
    public class Entity
    {
        public int Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public byte Status { get; set; }
        
        public Entity()
        {
            CreatedAt = DateTime.Now;
            Status = 1;
        }
    }
}

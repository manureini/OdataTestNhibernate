using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdataTestNhibernate.Models
{
    public class School
    {
        public virtual Guid Id { get; set; }

        public virtual string Name { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}

using System;

namespace OdataTestNhibernate.Models
{
    public class Student
    {
        public virtual Guid Id { get; set; }

        public virtual string Name { get; set; }

        public virtual School School { get; set; }
    }
}

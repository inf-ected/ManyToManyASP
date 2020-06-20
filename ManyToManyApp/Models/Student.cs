using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManyToManyApp.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        //virtual !!! без него пришлось бы делать инклуды при вызове 
        // имменно оно и делает промежуцточную таблицу многие ко многим
        public virtual ICollection<Course> Courses { get; set; }
        public Student()
        {
            Courses = new List<Course>();
        }
    }
}
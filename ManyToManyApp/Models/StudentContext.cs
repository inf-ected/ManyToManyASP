using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ManyToManyApp.Models
{
    public class StudentContext : DbContext

    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Corses { get; set; }
    }


    public class CourseDbInitilizer : DropCreateDatabaseAlways<StudentContext>
    {
        protected override void Seed(StudentContext context)
        {
            Student s1 = new Student { Id = 1, Name = "Ivan", Surname = "Ivanov" };
            Student s2 = new Student { Id = 2, Name = "Petr", Surname = "Petrov" };
            Student s3 = new Student { Id = 3, Name = "Sidor", Surname = "Sidorov" };
            Student s4 = new Student { Id = 4, Name = "Chak", Surname = "Noris" };
            Student s5 = new Student { Id = 5, Name = "Bruse", Surname = "Lee" };

            context.Students.AddRange(new Student[] { s1, s2, s3, s4, s5 });

            Course c1 = new Course
            {
                Id = 1,
                Name = "Operation Systems",
                Students = new List<Student> { s1, s2, s3 }
            };

            Course c2 = new Course
            {
                Id = 2,
                Name = "Algorithm and Data Strucrture",
                Students = new List<Student> { s2, s4 }
            };
            Course c3 = new Course
            {
                Id = 3,
                Name = "HTML and CSS",
                Students = new List<Student> { s1, s5, s3 }
            };

            context.Corses.AddRange(new Course[] {c1,c2,c3 });

            context.SaveChanges();
            //base.Seed(context);
        }
    }

}
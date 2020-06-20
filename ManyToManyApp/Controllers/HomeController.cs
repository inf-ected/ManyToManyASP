using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ManyToManyApp.Models;
using System.Data.Entity;
namespace ManyToManyApp.Controllers
{
    public class HomeController : Controller
    {
        StudentContext db = new StudentContext();

        public ActionResult Index()
        {
            return View(db.Students.ToList());
        }
        public ActionResult Details(int id = 0)
        {
            Student student = db.Students.Find(id);
            // если бы мы не использовали virtual в моделях у навигационных своиств
            // using system.data. entity = для инклуда
            // Student stud = db.Students.Include(s=>s.Courses).FirstOrDefault(s=>s.Id==id);
            if (student == null)
                return HttpNotFound();
            return View(student);
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Courses = db.Corses.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Create(Student s, int[] selectedCourses)
        {
            if (selectedCourses != null)
                foreach (Course c in db.Corses.Where(co => selectedCourses.Contains(co.Id)))
                    s.Courses.Add(c);
            db.Students.Add(s);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Edit(int id)
        {
            Student s = db.Students.Find(id);
            if (s == null)
                return HttpNotFound();
            ViewBag.Courses = db.Corses.ToList();
            return View(s);
        }
        [HttpPost]
        public ActionResult Edit(Student s, int[] selectedCourses)
        {
            Student studToEdit = db.Students.Find(s.Id);
            studToEdit.Name = s.Name;
            studToEdit.Surname = s.Surname;
            studToEdit.Courses.Clear();
            if (selectedCourses != null)
            {
                //получаем выбранные курсы
                foreach (Course c in db.Corses.Where(co => selectedCourses.Contains(co.Id)))
                { studToEdit.Courses.Add(c); }
            }
            db.Entry(studToEdit).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
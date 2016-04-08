using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ViewsAndSession.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        [HttpGet]
        public ActionResult Index()
        {
            List<Student> studentList;
            studentList = (List<Student>)Session["students"] ?? new List<Student>();
            return View(studentList);
        }
        //Get: Student
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        //Post: Student
        [HttpPost]
        public ActionResult Create(Student newStudent)
        {
            if (ModelState.IsValid)
            {
                var studentList = (List<Student>)Session["students"];

                if (studentList == null)
                {
                    newStudent.Id = 1;
                    studentList = new List<Student>();
                }
                else
                {
                    var idToAdd = studentList.Max().Id;
                    newStudent.Id = 1 + idToAdd;
                }

                studentList.Add(newStudent);

                Session["students"] = studentList;
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
        //Get: Student
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            var studentList = (List<Student>)Session["students"];
            var student = new Student();
            if (studentList == null)
            {
                return HttpNotFound();
            }
            foreach (var s in studentList)
            {
                if (s.Id == id)
                {
                    student = s;
                }
            }
            if (student == null)
            {
                return RedirectToAction("Index");
            }

            return View(student);
        }
        //Put: Student
        [HttpPost]
        public ActionResult Edit(Student newStudent)
        {
            var studentList = (List<Student>)Session["students"];
            bool doesExist = false;
            if (studentList == null)
            {
                return Content("Nothing in the list");
            }
            studentList.Remove(studentList.First(m => m.Id == newStudent.Id));
            studentList.Add(newStudent);

            

            Session["students"] = studentList;
            return RedirectToAction("Index");

        }
    }
}
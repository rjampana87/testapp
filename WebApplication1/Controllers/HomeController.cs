using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

using ClassLibrary2;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string name="")
        {
            var students = new List<Student>()
            {
                new Student() { Id = 1, Name = "ABC" },
                new Student() { Id=2, Name = "XYZ" },
                new Student() { Id = 3, Name = "abc" }

            };

            return View(students);
        }

        public ActionResult Index3(string name = "")
        {
            Class1 data = new Class1();
            var st = data.getStudent();

            return View(st);
            //return View(students);
        }
        public ActionResult Index2(string name = "")
        {
            Class1 data = new Class1();
            var st = data.getStudent();

            return View(st);
            //return View(students);
        }

        public ActionResult Details(int id = 0)
        {
            Class1 data = new Class1();
            var st = data.getStudentById(id);


            return View(st);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            ViewBag.AboutMethod = "This is About method.";
            Session["Temp"] = "This is session";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
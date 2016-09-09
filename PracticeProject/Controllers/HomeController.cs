using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PracticeProject.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        PracticeEntities pe = new PracticeEntities();
        public ActionResult Index()
        {
            ViewBag.m = pe.my_table.ToList();
            return View();
        }
        public ActionResult Details(int id)
        {
            my_table my = pe.my_table.Find(id);
            return View(my);
        }


        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Add(my_table m)
        {
            pe.Entry(m).State = System.Data.EntityState.Added;
            pe.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            my_table my = pe.my_table.Find(id);
            return View(my);
        }

        [HttpPost]
        public ActionResult Edit(my_table m)
        {
            pe.Entry(m).State = System.Data.EntityState.Modified;
            pe.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Delete(int id)
        {
            my_table my = pe.my_table.Find(id);
            return View(my);
        }


        [HttpPost]
        public ActionResult Delete(my_table m)
        {
            pe.Entry(m).State = System.Data.EntityState.Deleted;
            pe.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
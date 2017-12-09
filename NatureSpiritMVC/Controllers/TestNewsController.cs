using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NatureSpiritMVC.Controllers
{
    public class TestNewsController : Controller
    {
        // GET: TestNews
        public ActionResult Index()
        {
            return View();
        }

        // GET: TestNews/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TestNews/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TestNews/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: TestNews/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TestNews/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: TestNews/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TestNews/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

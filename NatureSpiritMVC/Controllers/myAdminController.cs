using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NatureSpiritData.Models;

namespace NatureSpiritMVC.Controllers
{
    public class myAdminController : Controller
    {
        baseContext dbContext = new baseContext();
        // GET: myAdmin
        public ActionResult Index()
        {
            return View();
        }

        // GET: myAdmin/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: myAdmin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: myAdmin/Create
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

        // GET: myAdmin/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: myAdmin/Edit/5
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

        // GET: myAdmin/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: myAdmin/Delete/5
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

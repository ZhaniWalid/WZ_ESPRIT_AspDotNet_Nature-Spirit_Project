using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NatureSpiritData.Models;
using NatureSpiritServices.Interfaces;

namespace NatureSpiritMVC.Controllers
{
    public class NewsAdminController : Controller
    {

        INewsServices newsServices;

        public NewsAdminController(INewsServices newsServices)
        {
            this.newsServices = newsServices;
        } 

        // GET: NewsAdmin
        public ActionResult Index()
        {
           // var listeNews = newsServices.getAllNewsAdmin();
            return View();
        }

        // GET: NewsAdmin/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: NewsAdmin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NewsAdmin/Create
        [HttpPost]
        public ActionResult Create(news n)
        {
            if(ModelState.IsValid) 
            {
               // newsServices.addNewsAdmin(n);
                return RedirectToAction("Index");   
            }else {
                return View();
            }
        }

        // GET: NewsAdmin/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: NewsAdmin/Edit/5
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

        // GET: NewsAdmin/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: NewsAdmin/Delete/5
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

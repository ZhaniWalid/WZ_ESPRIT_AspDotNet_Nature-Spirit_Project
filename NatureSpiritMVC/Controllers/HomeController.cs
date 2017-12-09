using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NatureSpiritData.Models;
using NatureSpiritServices.Interfaces;

namespace NatureSpiritMVC.Controllers
{
    public class HomeController : Controller
    {
        /*INewsServices newsServices;
        public HomeController(INewsServices newsServices)
        {
            this.newsServices = newsServices;
        }*/

        public ActionResult Index()
        { 
            return View();
        }

        public ActionResult IndexAdmin()
        {
            return View();
        }

        public ActionResult News()
        {
            return View();
        }

        public ActionResult NewsAdmin()
        {
            return View();
        }


        /*// GET: NewsAdmin/Create
        public ActionResult Create()
        {
            return View();
        }


        // POST: NewsAdmin/Create
        [HttpPost]
        public ActionResult Create(news n)
        {
            if (ModelState.IsValid)
            {
                newsServices.addNewsAdmin(n);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
        */

        public ActionResult ProductsAdmin()
        {
            return View();
        }

        public ActionResult ProductsMember()
        {
            return View();
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
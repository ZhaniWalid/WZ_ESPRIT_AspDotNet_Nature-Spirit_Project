using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NatureSpiritData.Models;

namespace NatureSpiritMVC.Controllers
{
    public class AdminController : Controller
    {

        baseContext db_context;
        public AdminController()
        {
            db_context = new baseContext();
        }
        // GET: Admin
        public ActionResult Index()
        {
            var liste_news_admin = db_context.news.ToList();
            return View(liste_news_admin);
        }

        // GET: Admin/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            // news n = new news();  
            //n.admin_id_Member = 1;   
           // var select = new SelectList(db_context.members, "id_Member", "First_Name");
            return View();  
            //return View();                                    
        } 

        // POST: Admin/Create
        [HttpPost] 
        public ActionResult Create(FormCollection collection)
        {
            //id_admin = context.members.Find().id_Member;
            //id_admin = 1;  
            //context.members.Where(a => a.id_Member == id_admin);
            /* n.admin_id_Member = id_admin;
             db_context.news.Add(n);
             db_context.SaveChanges();*/

            
            return RedirectToAction("Index");
        }

        // GET: Admin/Edit/5
        public ActionResult Edit(int id) 
        {
            return View();
        }

        // POST: Admin/Edit/5
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

        // GET: Admin/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Delete/5
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

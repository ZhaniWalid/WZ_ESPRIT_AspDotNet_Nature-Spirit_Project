using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NatureSpiritData.Models;

namespace NatureSpiritMVC.Controllers.AdminDashboard
{
    public class AdminNewsController : Controller
    {

        baseContext bd_context;

        public AdminNewsController()
        {
            bd_context = new baseContext();  
        }
        // GET: AdminNews
        public ActionResult Index()
        {
            var list_news = bd_context.news.ToList();
            return View(list_news);
        }

        //Recherche
        [HttpPost]
        public ActionResult Index(string searchString)
        {
            IEnumerable<news> list_news = bd_context.news;
            if (!String.IsNullOrEmpty(searchString))
            {
                list_news = list_news.Where(m => m.description.Contains(searchString));
            }
            return View(list_news);    
        }
          
        // GET: AdminNews/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AdminNews/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminNews/Create
        [HttpPost]
        public ActionResult Create(news n)
        {
            try
            {
                if(ModelState.IsValid) 
                {
                    bd_context.news.Add(n);
                    bd_context.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminNews/Edit/5
        public ActionResult Edit(int? id_news)   
        {
               
            //int id = n.idNews;
            news n = bd_context.news.Find(id_news);
          
            /*news x = new news();
                 
            x.description = n.description;
            x.picture = n.picture;
            x.admin_id_Member = n.admin_id_Member;
            x.topic_idTopic = n.topic_idTopic;*/

            /*n.description = bd_context.news.Select( x => x.description).First();
            n.picture = bd_context.news.Select(x => x.picture).First();
            n.admin_id_Member = bd_context.news.Select(x => x.admin_id_Member).First();
            n.topic_idTopic = bd_context.news.Select(x => x.topic_idTopic).First();*/

            /*news n = new news()
            {
                description = x.description,
                picture = x.picture,
                admin_id_Member = x.admin_id_Member,
                topic_idTopic = x.topic_idTopic
            };*/
                  
            return View(n);  


            /*news n = new news
            {
                description = bd_context.news.Select(x => x.description).SingleOrDefault(),       
                picture = bd_context.news.Select(x => x.picture).SingleOrDefault(),
                admin_id_Member = bd_context.news.Select(x => x.admin_id_Member).SingleOrDefault(),
                topic_idTopic = bd_context.news.Select(x => x.topic_idTopic).SingleOrDefault()           
            };*/


        }

        // POST: AdminNews/Edit/5     
        [HttpPost]
        public ActionResult Edit([Bind(Include = "idNews,description,picture,admin_id_Member,topic_idTopic")] news model_news)
        {  

            news n = bd_context.news.Where(x => x.idNews == model_news.idNews).SingleOrDefault();
            try
            {
                if(n!=null)
                {                      
                    bd_context.Entry(n).CurrentValues.SetValues(model_news);
                    bd_context.SaveChanges();
                }
                return RedirectToAction("Index","AdminNews");                     
            }  
            catch
            {
                return View(model_news);
            }
        }

        // GET: AdminNews/Delete/5
        public ActionResult Delete(string id_news = null)
        {

            news n = bd_context.news.Find(id_news);
            return View(n);
               
        }
                  
        // POST: AdminNews/Delete/5
        //[HttpPost]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]  
        public ActionResult Delete(int? id_news)
        {
            news n = new news(); 
            n = bd_context.news.Find(id_news); 
            bd_context.news.Remove(n);
            bd_context.SaveChanges();   

            return RedirectToAction("Index", "AdminNews");
        }
    }
}

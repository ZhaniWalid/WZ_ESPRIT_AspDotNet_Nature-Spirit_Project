using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc; 
using NatureSpiritData.Infrastructure;
using NatureSpiritData.Models;
using NatureSpiritMVC.Models;
using NatureSpiritServices.Implements;

namespace NatureSpiritMVC.Controllers.AdminTest
{
    public class MyAdminNewsController : Controller
    {
        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork ut = new UnitOfWork(dbf);

        NewsServices ns = null;
        public MyAdminNewsController()
        {
            ns = new NewsServices();  
        }


        // Method for Uploading Images
        // [AcceptVerbs(HttpVerbs.Post)]
        public void UploadImage()

        {

            foreach (string file in Request.Files)

            {
                // code for saving the image file to a physical location.  
                var postedFile = Request.Files[file];
                var path = Path.Combine(Server.MapPath("~/Content/Uploads"),Path.GetFileName(postedFile.FileName));
                postedFile.SaveAs(path);

                // prepare a relative path to be stored in the database and used to display later on.
                path = Url.Content(Path.Combine("~/Content/Uploads", Path.GetFileName(postedFile.FileName)));

                //postedFile.SaveAs(Server.MapPath(@Url.RouteUrl("~/Content/Uploads/")+Path.GetFileName(postedFile.FileName)));                                                

            }      
            

          /*  if (picture.ContentLength > 0)
            {

                // code for saving the image file to a physical location.
                var fileName = Path.GetFileName(picture.FileName);
                var path = Path.Combine(Server.MapPath("~/Content/Uploads"), fileName);
                picture.SaveAs(path);

                // prepare a relative path to be stored in the database and used to display later on.
                path = Url.Content(Path.Combine("~/Content/Uploads", fileName));
                // save to db

               // return RedirectToAction("Index");

            }*/
        }

         // GET: MyAdminNews
        public ActionResult Index()
        {

            var les_news = ns.DisplayAdminNewsByTopic();
            List<NewsModels> ls = new List<NewsModels>();   
            foreach(var item in les_news)
            {
                ls.Add  
                (   
                   new NewsModels
                   {
                       idNews = item.idNews,
                       title = item.title,
                       description = item.description,
                       picture = item.picture,
                       admin_id_Member = item.admin_id_Member,
                       topic_idTopic = item.topic_idTopic,
                       topic = item.topic     
                   }
                 );
            }
            return View(ls);
        }

        //Recherche
        [HttpPost]
        public ActionResult Index(string searchString)
        {
            var list_news = ns.getAllNews();
            List<NewsModels> ls = new List<NewsModels>();

            foreach (var item in list_news)
            {
                ls.Add
                (
                   new NewsModels
                   { 
                       idNews = item.idNews,
                       title = item.title,
                       description = item.description,
                       picture = item.picture,
                       admin_id_Member = item.admin_id_Member,
                       topic_idTopic = item.topic_idTopic,
                       topic = item.topic
                   }
                 );
            }
           
            if (!String.IsNullOrEmpty(searchString))
            {
                ls = ls.Where(m => m.title.ToLower().Contains(searchString)).ToList();   
            } 
            return View(ls);  
        }       

        // GET: MyAdminNews/Details/5
        public ActionResult Details(int id)
        {
           
            var detailsNews = ns.getNewsById(id);
            NewsModels item = new NewsModels();

            item.idNews = detailsNews.idNews;
            item.title = detailsNews.title;
            item.description = detailsNews.description;
                        
            item.topic = detailsNews.topic;
              
            return View(item); 
           
        }

        // GET: MyAdminNews/Create
        public ActionResult Create()
        {
            var n = new NewsModels();
            n.admin_id_Member = 1;
            n.topic_idTopic = 1;
            return View(n);   
        }

        // POST: MyAdminNews/Create
        [HttpPost]
        public ActionResult Create(NewsModels nm)
        {
           if (ModelState.IsValid) 
           {
                 
                    //UploadImage();
                    news n = new news   
                    {
                        title = nm.title,
                        description = nm.description,
                        picture = nm.picture,
                        admin_id_Member = nm.admin_id_Member,
                        topic_idTopic = nm.topic_idTopic
                    };
                    UploadImage();
                    ns.Add(n);
                    ns.Commit();
                
           }
                
            return RedirectToAction("Index");
        }

        // GET: MyAdminNews/Edit/5
        public ActionResult Edit(int id)
        {
            var detailsNews = ns.getNewsById(id);
            NewsModels item = new NewsModels();

            item.idNews = detailsNews.idNews;
            item.title = detailsNews.title;
            item.description = detailsNews.description;
            item.picture = detailsNews.picture;
            item.admin_id_Member = detailsNews.admin_id_Member;   
            item.topic_idTopic = detailsNews.topic_idTopic;

            return View(item); 
        }   

        // POST: MyAdminNews/Edit/5
        [HttpPost]
        public ActionResult Edit(NewsModels nm)
        {
            if (ModelState.IsValid)
            { 
                var n = ns.getNewsById(nm.idNews);
                   
                n.idNews = nm.idNews;
                n.title = nm.title;
                n.description = nm.description;
                n.picture = nm.picture;
                n.admin_id_Member = nm.admin_id_Member;
                n.topic_idTopic = nm.topic_idTopic;
                  
                ns.Update(n);
                ns.Commit();
            }
                                         
            return RedirectToAction("Index");
        }

        // GET: MyAdminNews/Delete/5
        /*   public ActionResult Delete(int id)
           {
               var detailsNews = ns.getNewsById(id);
               NewsModels item = new NewsModels();       

               item.idNews = detailsNews.idNews;
               item.title = detailsNews.title;
               item.description = detailsNews.description;
               item.picture = detailsNews.picture;
               item.admin_id_Member = detailsNews.admin_id_Member;
               item.topic_idTopic = detailsNews.topic_idTopic;

               return View(item);
           }
   */
        // POST: MyAdminNews/Delete/5
        /*   [HttpPost]
           public ActionResult Delete(NewsModels nm)
           {
               // news x = null;
               Console.WriteLine("hani l fou9");

               if (ModelState.IsValid)
               {

                   var n = ns.getNewsById(nm.idNews); 

                    //news item = new news();


                   //n.idNews = nm.idNews;  
                   /*n.idNews = nm.idNews;     
                   n.title = nm.title;
                   n.description = nm.description;      
                   n.picture = nm.picture;
                   n.admin_id_Member = nm.admin_id_Member;
                   n.topic_idTopic = nm.topic_idTopic;



                  // ns.deleteNewsById(n.idNews); 

                   ns.Delete(n);                                      
                   ns.Commit();
               }

               return RedirectToAction("Index");
           }
           */
        //////////////////////


        // GET: AdminSeaAward/Delete/5
        public ActionResult Delete(int id)
        {
            news n = ns.getNewsById(id);

            NewsModels model = new NewsModels
            {
                idNews = n.idNews,
                title = n.title,
                description = n.description,
                picture = n.picture,
                video = n.video,
                like = n.like,
                comment = n.comment,
                admin_id_Member = 1,
                topic_idTopic = 1
                              
            };
            return View(model);
        }

        // POST: AdminSeaAward/Delete/5
        [HttpPost]
        public ActionResult Delete(int id,NewsModels model)
        {
            ns.DeleteNewsById(id);
            return RedirectToAction("Index");
        }


    }
}

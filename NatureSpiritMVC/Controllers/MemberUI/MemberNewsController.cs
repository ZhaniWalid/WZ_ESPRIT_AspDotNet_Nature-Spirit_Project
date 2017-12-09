using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NatureSpiritData.Infrastructure;
using NatureSpiritData.Models;
using NatureSpiritMVC.Models;
using NatureSpiritServices.Implements;

namespace NatureSpiritMVC.Controllers.MemberUI
{
    public class MemberNewsController : Controller
    {

     //   private static IDatabaseFactory dbf = new DatabaseFactory();
      //  private static IUnitOfWork ut = new UnitOfWork(dbf);
        public static int id_M = 4;
        NewsServices ns = null;
        MemberNewsServices mns = null;
        public MemberNewsController()
        {
            ns = new NewsServices();
            mns = new MemberNewsServices();
        }

        // GET: MemberNews
        public ActionResult Index()
        {

            var les_news = ns.DisplayAdminNewsByTopic();
             List<NewsModels> ls = new List<NewsModels>();
             foreach (var item in les_news)
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
             

            /*var les_news_members = mns.getAllNewsMember();
            List<MemberNewsModels> ls = new List<MemberNewsModels>();
            foreach (var item in les_news_members)
            {
                ls.Add
                (
                   new MemberNewsModels
                   {
                       Id_News = item.news.idNews,
                       Id_Member = id_M,
                       Comment = item.Comment,
                       date_Of_Comment = item.date_Of_Comment,
                       
                   }
                 );
            }*/

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
              

           /* var les_news_members = mns.getAllNewsMember();
            List<MemberNewsModels> ls = new List<MemberNewsModels>();
            foreach (var item in les_news_members)
            {
                ls.Add
                (
                   new MemberNewsModels
                   {
                       Id_News = item.Id_News,
                       Id_Member = id_M,
                       Comment = item.Comment,
                       date_Of_Comment = item.date_Of_Comment
                   }
                 );
            }

            if (!String.IsNullOrEmpty(searchString))
            {
                ls = ls.Where(m => m.news.title.ToLower().Contains(searchString)).ToList();
            }
            */
            return View(ls);
        }

  
        // GET: MemberNews/Create
        public ActionResult Create(int id)
        {
           // var mnm = new MemberNewsModels();
            //mnm.Id_Member = id_M;

            var detailsMemberNews = ns.getNewsById(id);
            // NewsModels item = new NewsModels();
            MemberNewsModels item = new MemberNewsModels();

            item.Id_News = detailsMemberNews.idNews;
            item.Id_Member = id_M;
            item.date_Of_Comment = new DateTime().ToLocalTime();
            item.Comment = detailsMemberNews.comment;
            item.title_selected_news = detailsMemberNews.title;
            item.description_selected_news = detailsMemberNews.description;

            return View(item);
        }

        // POST: MemberNews/Create
        [HttpPost]
        public ActionResult Create(MemberNewsModels mnm)
        {

            if (ModelState.IsValid)
            {

                //UploadImage();
                membernew mn = new membernew
                {
                    Id_News = mnm.Id_News,
                    Id_Member = id_M,
                    Comment = mnm.Comment,
                    date_Of_Comment = new DateTime().ToLocalTime(),
                    like_dislike = mnm.like_dislike,
                    State_News = 0,
                    title_selected_news = mnm.title_selected_news,
                    description_selected_news = mnm.description_selected_news
                };
                mns.addMemberNewsById(mn);
                //ns.Add(n);
                //ns.Commit();

            }

            return RedirectToAction("Index");
        }


        // CommentNewsByMember
        // POST
        // GET: MemberNews/Details/5
        public ActionResult Details(int id)
        {

            var detailsNews = ns.getNewsById(id);
            NewsModels item = new NewsModels();



            item.idNews = detailsNews.idNews;
            item.title = detailsNews.title;
            item.description = detailsNews.description;
            item.picture = detailsNews.picture;
            item.comment = detailsNews.comment;
            item.like = detailsNews.like;

            item.topic = detailsNews.topic;

            // CommentNewsByMember(item);

            return View(item);

        }

 
        //GET
        public ActionResult CommentNewsByMember()
        {
           /* var detailsNews = ns.getNewsById(id);
            NewsModels item = new NewsModels();

            item.idNews = detailsNews.idNews;
            item.title = detailsNews.title;
            item.description = detailsNews.description;
            item.picture = detailsNews.picture;
            item.admin_id_Member = detailsNews.admin_id_Member;
            item.topic_idTopic = detailsNews.topic_idTopic;
            */
            return View();
        }
        // CommentNewsByMember
        // POST
        [HttpPost]
        public ActionResult CommentNewsByMember(news n)
        {
            /*commentValue = null;
            //var nm = new NewsModels();
            //nm.member.id_Member = 1;
            //nm.topic_idTopic = 1;
            
            if(ModelState.IsValid)
            {
                //UploadImage();      
                var n = ns.getNewsById(nm.idNews);

                //  title = nm.title,
                // description = nm.description,
                // picture = nm.picture,
                n.idNews = nm.idNews;
                n.comment = commentValue;
                n.admin_id_Member = nm.admin_id_Member;
                n.topic_idTopic = nm.topic_idTopic;
                
                ns.Update(n);
                ns.Commit();
            }
           // return View();
           return RedirectToAction("Index");*/
            ns.UpdateNewsById(n.idNews);
            return RedirectToAction("Index");


        }

        // GET: MemberNews/Edit/5
        public ActionResult EditNewsByMember(int id)
        {
             var detailsMemberNews = ns.getNewsById(id);
           // NewsModels item = new NewsModels();
             MemberNewsModels item = new MemberNewsModels();

             item.Id_News = detailsMemberNews.idNews;
             item.Id_Member = id_M; 
             item.date_Of_Comment = new DateTime().Date;
             item.Comment = detailsMemberNews.comment;
            
            /*item.news.idNews = detailsMemberNews.Id_News;
            item.news.member.id_Member = detailsMemberNews.Id_Member;
            item.date_Of_Comment = new DateTime().Date;
            item.Comment = detailsMemberNews.Comment;
            */
            //item.idNews = detailsNews.idNews;
            /*item.news.title = detailsMemberNews.news.title;
            item.news.description = detailsMemberNews.news.description;
            item.news.picture = detailsMemberNews.news.picture;
            item.news.admin_id_Member = detailsMemberNews.news.admin_id_Member;
            item.news.topic_idTopic = detailsMemberNews.news.topic_idTopic;*/
          //  item.member.id_Member = 2;
            
            return View(item);
        }

        // POST: MemberNews/Edit/5
        [HttpPost]
        public ActionResult EditNewsByMember(MemberNewsModels nm)
        {
            if (ModelState.IsValid)
            {
                var x = mns.getMemberNewsById(nm.Id_News,id_M);
                //var x = ns.getNewsById(nm.Id_News);
                /* n.Id_News = nm.Id_News;
                 n.Id_Member = id_M;
                 n.date_Of_Comment = new DateTime().Date;
                 n.Comment = nm.Comment;
                 */
                //n.Comment = Request.Form["commentId"];

                /*n.idNews = nm.idNews;
                n.title = nm.title;
                n.description = nm.description;
                n.picture = nm.picture;
                n.admin_id_Member = nm.admin_id_Member;
                n.topic_idTopic = nm.topic_idTopic;
                */

                 membernew n = new membernew
                 {
                     Id_News = x.Id_News,
                     Id_Member = id_M,
                     date_Of_Comment = new DateTime().Date,
                     Comment = x.Comment
                 };


                /*  x.Id_News = nm.Id_News;
                  x.Id_Member = id_M;
                  x.date_Of_Comment = new DateTime().Date;
                  x.Comment = nm.Comment;
                  */
                mns.addMemberNewsById(n);
               // mns.Add(n);
            //    mns.Commit();
            }

            return RedirectToAction("Index");
        }

        // GET: MemberNews/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MemberNews/Delete/5
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

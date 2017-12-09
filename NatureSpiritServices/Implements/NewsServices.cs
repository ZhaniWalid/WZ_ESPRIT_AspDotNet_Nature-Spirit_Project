using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NatureSpiritData.Infrastructure;
using NatureSpiritData.Models;
using NatureSpiritServices.Interfaces;
using  ServicePattern;

namespace NatureSpiritServices.Implements
{
    public class NewsServices : Service<news>,INewsServices
    {
       
        public static DatabaseFactory dbFactory = new DatabaseFactory();
        public static UnitOfWork uow = new UnitOfWork(dbFactory);

        public static baseContext db_Context = new baseContext();

        public NewsServices() : base(uow) 
        {
        }

        public List<news> DisplayAdminNewsByTopic()
        {
            List<news> list = uow.getRepository<news>().GetAll().ToList();            
            return list;
        }

        public List<news> getAllNews()
        {
            List<news> list = uow.getRepository<news>().GetAll().ToList();
            return list; 
        }
         
        public news getNewsById(int id)
        {
            news n = uow.getRepository<news>().Get(c => c.idNews == id); 
            return n;
        }
                       
        public void updateNews(news n)
        {
            uow.getRepository<news>().Update(n);        
        }

        public void deleteNewsById(int id)
        {
            
            /*var n = db_Context.news.Find(id);
            db_Context.news.Remove(n);
            db_Context.SaveChanges();        

            return n;*/
            if(id==0) 
            {
                Console.WriteLine("Id is null , impossible delete");
            }else{
                uow.getRepository<news>().Delete(n => n.idNews == id);
                uow.Commit();
            }
                              
      
        }


        public void DeleteNewsById(int id) 
        {
            news n = uow.getRepository<news>().GetById(id);
            uow.getRepository<news>().Delete(n);
            uow.Commit();
        }

        public void UpdateNewsById(int id)
        {
            news n = uow.getRepository<news>().GetById(id);
            uow.getRepository<news>().Update(n);
            uow.Commit();
        }

        /*public void Deletetopic(int id)
        {
            utfw.getRepository<topic>().Delete(utfw.getRepository<topic>().GetById(id));
            utfw.Commit();
        }
        public void DelettopicById(int id)
        {
            topic t = utfw.getRepository<topic>().GetById(id);
            utfw.getRepository<topic>().Delete(t);
            utfw.Commit();
        }*/

    }

   

}


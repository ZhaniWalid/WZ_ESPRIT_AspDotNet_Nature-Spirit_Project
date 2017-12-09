using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NatureSpiritData.Infrastructure;
using NatureSpiritData.Models;
using NatureSpiritData.Repositories.Interfaces;

namespace NatureSpiritData.Repositories
{
    public static class NewsRepository
    {
        public static int id_admin = 1;
        public static int id_topic = 0;

        public static void AssignNewsToAdmin(this IRepositoryBaseAsync<news> repo, int idAdmin,int idTopic)
        {
            idAdmin = id_admin;
            idTopic = id_topic; 
                
            DatabaseFactory dbf = new DatabaseFactory();
            member admin = dbf.DataContext.members.FirstOrDefault(x => x.id_Member == idAdmin);
            topic topics = dbf.DataContext.topics.FirstOrDefault(x => x.idTopic == idTopic);
            //news n = dbf.DataContext.news.FirstOrDefault(x => x.idNews == id_news);
            news n = new news();
            n.member.news.Add(n);
            n.topic.news.Add(n);
            dbf.DataContext.news.Add(n);
            //dbf.DataContext.news.Include("members").FirstOrDefault(x => x.idNews == id_news);
            // news n = dbf.DataContext.news.FirstOrDefault(x => x.idNews == id_news);
            //dbf.DataContext.members.Include("news").FirstOrDefault(x => x.id_Member == idAdmin).news.Add(n);
           // User emp = dbf.DataContext.Users.FirstOrDefault(x => x.Id == idMem);
            //dbf.DataContext.CollocationGroups.Include("users").FirstOrDefault(x => x.CollocationGroupId == idGroup).users.Add(emp);
            dbf.DataContext.SaveChanges();            
        }
         
         /*public NewsRepository(IDatabaseFactory dbFactory):base(dbFactory)
         { 

         }*/


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NatureSpiritData.Infrastructure;
using NatureSpiritData.Models;
using ServicePattern;

namespace NatureSpiritServices.Implements
{
    public class MemberNewsServices : Service<membernew>
    {
        public static DatabaseFactory dbFactory = new DatabaseFactory();
        public static UnitOfWork uow = new UnitOfWork(dbFactory);

        public static baseContext db_Context = new baseContext();

        public MemberNewsServices() : base(uow)
        {
          
        }

        public membernew getMemberNewsById(int id_N,int id_M)
        {

            membernew n = uow.getRepository<membernew>().Get(x => x.Id_News == id_N);
                      n = uow.getRepository<membernew>().Get(x => x.Id_Member == id_M);
            return n;
        }


        public membernew getNewsById(int id)
        {
            membernew n = uow.getRepository<membernew>().Get(c => c.news.idNews == id);
            return n;
        }

        public void UpdateNewsByMemberId(int id_N,int id_M)
        {
            membernew n = getMemberNewsById(id_N, id_M);
            uow.getRepository<membernew>().Update(n);
            uow.Commit();
        }

        public void addMemberNewsById(membernew mn) 
        {
           // membernew n = getMemberNewsById(id_N, id_M);
            uow.getRepository<membernew>().Add(mn);
            uow.Commit();
        }

        public List<membernew> getAllNewsMember()
        {
            List<membernew> list = uow.getRepository<membernew>().GetAll().ToList();
            return list;
        }

    }
}

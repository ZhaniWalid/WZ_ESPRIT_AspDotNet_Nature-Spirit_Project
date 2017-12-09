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
    public class ProductServices : Service<product>
    {
        public static DatabaseFactory dbFactory = new DatabaseFactory();
        public static UnitOfWork uow = new UnitOfWork(dbFactory);

        public static baseContext db_Context = new baseContext();

        public ProductServices() : base(uow)
        {

        }

        public List<product> getAllProducts()
        {    
            List<product> list = uow.getRepository<product>().GetAll().OrderByDescending(p => p.Type_Product).ToList();
            return list;
        }

    }
}

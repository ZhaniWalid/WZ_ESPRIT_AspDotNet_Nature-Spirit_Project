using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NatureSpiritData.Models;
using NatureSpiritData.Repositories;
using NatureSpiritData.Repositories.Interfaces;

namespace NatureSpiritData.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
       
         private baseContext dataContext;
             
        IDatabaseFactory dbFactory;
        public UnitOfWork(IDatabaseFactory dbFactory)
        {
            this.dbFactory = dbFactory;
            dataContext = dbFactory.DataContext;
        }

        public INewsRepository NewsRepository
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void Commit()
        {
            dataContext.SaveChanges();
        }
        
        public void Dispose()
        {
            dataContext.Dispose();
        }
        public IRepositoryBase<T> getRepository<T>() where T : class  
        {
            IRepositoryBase<T> repo = new RepositoryBase<T>(dbFactory);
            return repo;
        }

        // Added By Me , My Repositories Decalaration : Get  

        // private INewsRepository newsRepository;

       /* public INewsRepository NewsRepository
        {
           get { return newsRepository = new NewsRepository(dbFactory); }  
        }*/

    }
}

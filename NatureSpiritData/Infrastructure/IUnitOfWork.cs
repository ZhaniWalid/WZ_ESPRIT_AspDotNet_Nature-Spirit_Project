using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NatureSpiritData.Repositories.Interfaces;

namespace NatureSpiritData.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        IRepositoryBase<T> getRepository<T>() where T : class; 
        
        void Commit();

        // Added By Me , My Repositories Decalaration : "InterfaceName NameOfClassImplementsHisInterface"

        INewsRepository NewsRepository { get; }

    }

}

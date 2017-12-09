using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NatureSpiritData.Models;

namespace NatureSpiritData.Infrastructure
{
    public class DatabaseFactory : Disposable, IDatabaseFactory
    {
        private baseContext dataContext;
        public baseContext DataContext { get { return dataContext; } }

        public DatabaseFactory()
        {
            dataContext = new baseContext();
        }
        protected override void DisposeCore()
        {
            if (DataContext != null)
                DataContext.Dispose();
        }
    }

}

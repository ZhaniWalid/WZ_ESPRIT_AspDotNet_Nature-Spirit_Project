using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NatureSpiritData.Models;

namespace NatureSpiritData.Infrastructure
{
    public interface IDatabaseFactory : IDisposable
    {
        baseContext DataContext { get; }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NatureSpiritData.Infrastructure;
using NatureSpiritData.Models;

namespace NatureSpiritData.Repositories.Interfaces
{
    public interface INewsRepository
    {
        void AssignNewsToAdmin(IRepositoryBaseAsync<news> repo, int idAdmin);
    }
}

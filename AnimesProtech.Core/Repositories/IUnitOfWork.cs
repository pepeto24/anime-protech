using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimesProtech.Core.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        void BeginWork();

        void Commit();

        void Rollback();
    }
}

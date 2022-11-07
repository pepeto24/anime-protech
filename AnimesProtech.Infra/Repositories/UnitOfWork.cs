using AnimesProtech.Core.Repositories;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimesProtech.Infra.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        BaseContext mContext;
        IDbContextTransaction mCurrentTransaction;

        public UnitOfWork(BaseContext mContext)
        {
            this.mContext = mContext;
            mCurrentTransaction = null;
        }

        public void BeginWork()
        {
            mCurrentTransaction = mContext.Database.BeginTransaction();
        }

        public void Commit()
        {
            mCurrentTransaction.Commit();
        }

        public void Rollback()
        {
            mCurrentTransaction.Rollback();
        }

        public void Dispose()
        {
            EndWork();
        }

        private void EndWork()
        {
            mCurrentTransaction?.Dispose();
            mCurrentTransaction = null;
        }
    }
}

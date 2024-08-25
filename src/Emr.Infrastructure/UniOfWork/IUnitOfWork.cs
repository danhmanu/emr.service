using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emr.Infrastructure.UniOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        void BeginTransaction();
        void Commit();
        void Rollback();
        Task<IDbContextTransaction> BeginTransactionAsync();
        Task CommitTransactionAsync(IDbContextTransaction transaction);
        Task<int> SaveChangesAsync();
        void RollbackTransaction();
    }
}

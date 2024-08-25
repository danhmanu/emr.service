using Emr.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;

namespace Emr.Infrastructure.UniOfWork
{
    public class UnitOfWork_Context(EmrContext emrContext) : IUnitOfWork
    {
        public IDbContextTransaction GetCurrentTransaction() => _transaction;

        private readonly EmrContext _context = emrContext;
        private IDbContextTransaction _transaction;

        public void BeginTransaction()
        {
            _transaction = _context.Database.BeginTransaction();
        }

        public void Commit()
        {
            try
            {
                _context.SaveChanges();
                _transaction?.Commit();
            }
            catch
            {
                Rollback();
                throw;
            }
        }

        public void Rollback()
        {
            _transaction?.Rollback();
        }

        public void Dispose()
        {
            _transaction?.Dispose();
            _context?.Dispose();
        }

        #region async
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            if (_transaction != null) return null;

            _transaction = await _context.Database.BeginTransactionAsync(IsolationLevel.ReadCommitted);

            return _transaction;
        }

        public async Task CommitTransactionAsync(IDbContextTransaction transaction)
        {
            if (transaction == null) throw new ArgumentNullException(nameof(transaction));
            if (transaction != _transaction) throw new InvalidOperationException($"Transaction {transaction.TransactionId} is not current");

            try
            {
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch
            {
                RollbackTransaction();
                throw;
            }
            finally
            {
                if (_transaction != null)
                {
                    _transaction.Dispose();
                    _transaction = null;
                }
            }
        }

        public void RollbackTransaction()
        {
            try
            {
                _transaction?.Rollback();
            }
            finally
            {
                if (_transaction != null)
                {
                    _transaction.Dispose();
                    _transaction = null;
                }
            }
        }

        #endregion end async
    }
}

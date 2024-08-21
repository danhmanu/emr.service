using Emr.Infrastructure.Context;

namespace Emr.Infrastructure.UniOfWork
{
    internal class UnitOfWork_Context : IUnitOfWork, IDisposable
    {
        private readonly EmrContext context;
        public UnitOfWork_Context()
        {
            if (context == null)
                context = new EmrContext();
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}

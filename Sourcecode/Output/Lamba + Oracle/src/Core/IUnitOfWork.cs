using System;

namespace Gimme.Core
{
    public interface IUnitOfWork : IDisposable
    {
        void Start();
        void Complete();
    }
}

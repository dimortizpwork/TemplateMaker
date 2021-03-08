using System;

namespace InviteToKill
{
    public interface IUnitOfWork : IDisposable
    {
        void Start();
        void Complete();
    }
}

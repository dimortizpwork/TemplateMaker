using System;

namespace {{SolutionName}}
{
    public interface IUnitOfWork : IDisposable
    {
        void Start();
        void Complete();
    }
}

using System;

namespace Dorado.Services
{
    public interface IService : IDisposable
    {
        Int32 CurrentAccountId { get; set; }
    }
}
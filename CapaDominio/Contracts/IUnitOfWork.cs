using CapaDominio.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapaDominio.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        ICreditoRepository CreditoRepository { get;  }
        int Commit();
    }
}

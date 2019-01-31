using Models.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public interface IUnitOfWork : IDisposable
    {
        IClienteRepository Clientes { get; }

        int Complete();
    }
}

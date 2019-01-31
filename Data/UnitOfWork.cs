using Data.Repositorio;
using Models;
using Models.Repositorio;

namespace Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyContext _context;

        public IClienteRepository Clientes { get; private set; }
        
        public UnitOfWork(MyContext context)
        {
            _context = context;

            Clientes = new ClienteRepository(_context);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
            
        }
        
    }
}

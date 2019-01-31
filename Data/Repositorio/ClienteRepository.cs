using Models;
using Models.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositorio
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(MyContext context)
            : base(context)
        {
        }

        public MyContext MyContext
        {
            get { return Context as MyContext; }
        }
        

    }
}

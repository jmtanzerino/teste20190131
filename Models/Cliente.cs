using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Cliente
    {
        public int ClienteId { get; set; }

        public string Nome { get; set; }

        public DateTime DtNasc { get; set; }

        public string Email { get; set; }

        public Cliente()
        {

        }
    }
}

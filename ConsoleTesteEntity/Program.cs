using Data;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace ConsoleTesteEntity
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var unitOfWork = new UnitOfWork(new MyContext()))
            {
                var clientes1 = unitOfWork.Clientes.GetAll();

                var cliente = clientes1.First();

                Console.ReadKey();
                
            }
        }
    }
}

using Data;
using Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiService.Controllers
{
    public class ClienteController : ApiController
    {
        public IEnumerable<Cliente> Get()
        {
            try
            {
                using (var unitOfWork = new UnitOfWork(new MyContext()))
                {
                    var clientes = unitOfWork.Clientes.GetAll();

                    return clientes;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Cliente Get(int id)
        {
            try
            {
                using (var unitOfWork = new UnitOfWork(new MyContext()))
                {
                    var cliente = unitOfWork.Clientes.Get(id);

                    return cliente;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Post([FromBody]Object value)
        {
            try
            {
                Cliente cliente = new Cliente();

                var jsonString = value.ToString();

                var format = "dd/MM/yyyy";
                var dateTimeConverter = new IsoDateTimeConverter { DateTimeFormat = format };

                cliente = JsonConvert.DeserializeObject<Cliente>(jsonString, dateTimeConverter);

                using (var unitOfWork = new UnitOfWork(new MyContext()))
                {
                    unitOfWork.Clientes.Add(cliente);

                    unitOfWork.Complete();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Put(int id, [FromBody]Object value)
        {
            try
            {
                using (var unitOfWork = new UnitOfWork(new MyContext()))
                {
                    var cliente = unitOfWork.Clientes.Get(id);

                    if (cliente != null && value != null)
                    {
                        var jsonString = value.ToString();

                        var newCliente = new Cliente();

                        var format = "dd/MM/yyyy";
                        var dateTimeConverter = new IsoDateTimeConverter { DateTimeFormat = format };

                        newCliente = JsonConvert.DeserializeObject<Cliente>(jsonString, dateTimeConverter);

                        cliente.Nome = newCliente.Nome;
                        cliente.DtNasc = newCliente.DtNasc;
                        cliente.Email = newCliente.Email;

                        unitOfWork.Clientes.Edit(cliente);

                        unitOfWork.Complete();
                    }
                    
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public HttpResponseMessage Delete(int id)
        {
            try
            {
                using (var unitOfWork = new UnitOfWork(new MyContext()))
                {
                    var cliente = unitOfWork.Clientes.Get(id);

                    unitOfWork.Clientes.Remove(cliente);

                    if (unitOfWork.Complete() > 1)
                    {
                        return new HttpResponseMessage(HttpStatusCode.OK);
                    }
                    else
                    {
                        return new HttpResponseMessage(HttpStatusCode.NotModified);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}

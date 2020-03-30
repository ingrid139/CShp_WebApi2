using LojaServices.Api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaServices.Services
{
    public class ClienteService
    {
        private LojaContext _context;

        public ClienteService(LojaContext contexto)
        {
            _context = contexto;
        }

        public Cliente ProcurarPorId(int clienteId)
        {
            //utilzar metodo Find
            return _context.Clientes.Find(clienteId);
        }

        public IList<Cliente> ProcurarPorNome(string nome)
        {
            //utilizar método Where
            return _context.Clientes.Where(x => x.Nome == nome).ToList();
        }

        public Cliente Salvar(Cliente cliente)
        {
            //verificar se é adicionar ou alterar
            var estado = cliente.Id == 0 ? EntityState.Added : EntityState.Modified;
            
            //setar estado do entity
            _context.Entry(cliente).State = estado;

            //persistir os dados
            _context.SaveChanges();

            //retornar o objeto
            return cliente;
        }
    }
}

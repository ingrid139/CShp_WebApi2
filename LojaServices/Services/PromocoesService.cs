using LojaServices.Api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaServices.Services
{
    public class PromocoesService
    {
        private LojaContext _context;

        public PromocoesService(LojaContext contexto)
        {
            _context = contexto;
        }

        public Promocao ProcurarPorId(int promocaoId)
        {
            //utilzar metodo Find
            return _context.Promocoes.Find(promocaoId);
        }

        public Promocao ProdutosPromocao()
        {
            return _context.Promocoes
                            .Include(p => p.Produtos)
                            .ThenInclude(pp => pp.Produto)
                            .FirstOrDefault();
        }

        public Promocao Salvar(Promocao produto)
        {
            //verificar se é adicionar ou alterar
            var estado = produto.Id == 0 ? EntityState.Added : EntityState.Modified;

            //setar estado do entity
            _context.Entry(produto).State = estado;

            //persistir os dados
            _context.SaveChanges();

            //retornar o objeto
            return produto;
        }
    }
}

using LojaServices.Api.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Loja.Test
{
    public class ProdutoIdComparer : IEqualityComparer<Produto>
    {
        public bool Equals(Produto x, Produto y)
        {
            return x.Id == y.Id;
        }

        public int GetHashCode(Produto obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}

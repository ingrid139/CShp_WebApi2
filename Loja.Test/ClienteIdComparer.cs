using LojaServices.Api.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Loja.Test
{
    public class ClienteIdComparer : IEqualityComparer<Cliente>
    {
        public bool Equals(Cliente x, Cliente y)
        {
            return x.Id == y.Id;
        }

        public int GetHashCode(Cliente obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}

using LojaServices.Api.Models;
using LojaServices.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Loja.Test
{
    public class EnderecoServiceTest
    {
        private LojaContext _contexto;

        public EnderecoServiceTest()
        {
            var options = new DbContextOptionsBuilder<LojaContext>();
            options.UseSqlServer("Server=localhost,1433;Database=LojaServicesTestes;User Id =sa;Password=Ing@2020;Trusted_Connection=False;");

            _contexto = new LojaContext(options.Options);
        }

        [Fact]
        public void Devera_Add_Novo_Endereco()
        {
            //definir entradas
            var fakeEnd = new Endereco()
            {
                Id = 0,
                Logradouro = "Rua Duzentos",
                Numero = 500,
                Cidade = "São Paulo",
                Bairro = "Treze"
            };

            var atual = new Endereco();

            //metodo de teste
            var service = new EnderecoService(_contexto);
            atual = service.Salvar(fakeEnd);

            //Assert
            Assert.NotEqual(0,fakeEnd.Id);
        }

        [Fact]
        public void Devera_Alterar__Endereco()
        {
            //definir entradas
            var fakeEnd = new Endereco()
            {
                Id = 2,
                Logradouro = "Rua Um",
                Numero = 130,
                Cidade = "São Paulo",
                Bairro = "Teste"
            };

            var atual = new Endereco();

            //metodo de teste
            var service = new EnderecoService(_contexto);
            atual = service.Salvar(fakeEnd);

            //Assert
            Assert.NotEqual(0, fakeEnd.Id);
        }


    }
}

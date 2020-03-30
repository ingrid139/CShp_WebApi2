using LojaServices.Api.Models;
using LojaServices.Services;
using Microsoft.EntityFrameworkCore;
using System;
using Xunit;

namespace Loja.Test
{
    public class ClienteServiceTest
    {

        private LojaContext _contexto;
        private EnderecoService _enderecoService;
        private ClienteService _clienteService;

        public ClienteServiceTest()
        {
            var options = new DbContextOptionsBuilder<LojaContext>();
            options.UseSqlServer("Server=localhost,1433;Database=LojaServicesTestes;User Id =sa;Password=Ing@2020;Trusted_Connection=False;");

            _contexto = new LojaContext(options.Options);
            _enderecoService = new EnderecoService(_contexto);
            _clienteService = new ClienteService(_contexto);
        }

        [Fact]
        public void Devera_Add_Novo_Cliente()
        {
            //definir entradas
            var endereco = _enderecoService.ProcurarPorId(2);
            var fakeCliente = new Cliente()
            {
                Id = 0,
                Nome = "Ingrid",
                EnderecoId = endereco.Id
            };

            //metodo de teste
            var atual = _clienteService.Salvar(fakeCliente);

            //Assert
            Assert.NotEqual(0, fakeCliente.Id);
        }

        [Fact]
        public void Devera_retornar_Cliente()
        {
            //definir entradas
            var endereco = _enderecoService.ProcurarPorId(2);
            var clienteEsperado = new Cliente()
            {
                Id = 1,
                Nome = "Ingrid",
                EnderecoId = endereco.Id
            };

            //metodo de teste
            var atual = _clienteService.ProcurarPorId(clienteEsperado.Id);

            //Assert 
            //comparação de referencia de objetos
            Assert.Equal(clienteEsperado, atual, new ClienteIdComparer());
        }

    }
}

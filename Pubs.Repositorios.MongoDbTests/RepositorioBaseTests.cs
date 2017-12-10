using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pubs.Dominio;
using System;

namespace Pubs.Repositorios.MongoDb.Tests
{
    [TestClass()]
    public class RepositorioBaseTests
    {
        PublicacaoRepositorio _repositorio = new PublicacaoRepositorio();

        [TestMethod()]
        public void InserirTest()
        {
            var publicacao = new Publicacao();

            publicacao.Autor = new Autor { Nome = "Fulano" };
            publicacao.Texto = "Conteúdo";
            publicacao.Titulo = "Título";
            publicacao.Comentarios.Add(new Comentario
            {
                Autor = new Autor { Nome = "Siclano" },
                Texto = "Comentário"
            });

            _repositorio.Inserir(publicacao);
        }

        [TestMethod]
        public void SelecionarTodosTeste()
        {
            var publicacoes = _repositorio.Selecionar();

            foreach (var publicacao in publicacoes)
            {
                Console.WriteLine(publicacao.Id);
            }
        }

        [TestMethod]
        public void SelecionarPorIdTeste()
        {
            /*
                Test Name:	SelecionarTodosTeste
                Test Outcome:	Passed
                Result StandardOutput:	c737c60b-f39c-4efa-857b-efc0b64471fd             
             */

            var publicacao = _repositorio.Selecionar(new Guid("c737c60b-f39c-4efa-857b-efc0b64471fd"));

            Assert.IsNotNull(publicacao);
        }

        [TestMethod]
        public void AtualizarTeste()
        {
            var publicacao = _repositorio.Selecionar(new Guid("c737c60b-f39c-4efa-857b-efc0b64471fd"));

            publicacao.Autor.Nome = "Vítor";

            _repositorio.Atualizar(publicacao);

            publicacao = _repositorio.Selecionar(new Guid("c737c60b-f39c-4efa-857b-efc0b64471fd"));

            Assert.AreEqual(publicacao.Autor.Nome, "Vítor");
        }

        [TestMethod]
        public void ExcluirTeste()
        {
            _repositorio.Excluir(new Guid("c737c60b-f39c-4efa-857b-efc0b64471fd"));

            var publicacao = _repositorio.Selecionar(new Guid("c737c60b-f39c-4efa-857b-efc0b64471fd"));

            Assert.IsNull(publicacao);
        }
    }
}
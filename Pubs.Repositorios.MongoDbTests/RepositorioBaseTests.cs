using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pubs.Dominio;
using Pubs.Repositorios.MongoDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                Autor = new Autor{Nome = "Siclano"},
                Texto = "Comentário"
            });

            _repositorio.Inserir(publicacao);
        }
    }
}
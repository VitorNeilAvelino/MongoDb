using System;
using System.Collections.Generic;

namespace Pubs.Dominio
{
    public class Publicacao : EntidadeBase
    {
        public Publicacao()
        {
            Comentarios = new List<Comentario>();
            DataPublicacao = DateTime.Now;
        }

        public Autor Autor { get; set; }
        public List<Comentario> Comentarios { get; protected set; }

        public string Titulo { get; set; }
        public string Texto { get; set; }
        public DateTime DataPublicacao { get; set; }
    }
}
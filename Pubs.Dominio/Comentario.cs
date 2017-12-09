using System;

namespace Pubs.Dominio
{
    public class Comentario : EntidadeBase
    {
        public Comentario()
        {
            DataPublicacao = DateTime.Now;
        }

        public Autor Autor { get; set; }
        public string Texto { get; set; }
        public DateTime DataPublicacao { get; set; }
    }
}
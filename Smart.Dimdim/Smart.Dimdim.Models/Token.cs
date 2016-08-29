using Smart.Dimdim.Models.Base;
using System;

namespace Smart.Dimdim.Models
{
    public class Token : Entidade
    {
        public string Valor { get; set; }
        public DateTime Validade { get; set; }
        public string Nome { get; set; }

        public Usuario Usuario { get; private set; }

        public Token()
        {

        }
        public Token(Usuario usuario)
        {
            Usuario = usuario;

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Smart.Dimdim.Api.Models
{
    public class Categoria:Entidade
    {
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        
        public char Transacao { get; set; }
        public string Descricao { get; set; }
        public string Cor { get; set; }

    }
}
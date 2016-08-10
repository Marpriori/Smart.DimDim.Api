using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Smart.Dimdim.Api.Models.Base;

namespace Smart.Dimdim.Api.Models
{
    public class Categoria:EntidadeUsuario
    {
        
        public char Transacao { get; set; }
        public string Descricao { get; set; }
        public string Cor { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Smart.Dimdim.Models.Base;

namespace Smart.Dimdim.Models
{
    public class Categoria:EntidadeUsuario
    {
        
        public char Transacao { get; set; }
        public string Descricao { get; set; }
        public string Cor { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Smart.Dimdim.Api.Models
{
    
    [Table("USUARIO")]
    public class Usuario:Entidade
    {
        public string Nome { get; set; }
        
        public string Email { get; set; }
        
        public string Apelido { get; set; }
        
        public string Senha { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Smart.Dimdim.Api.Models
{
    [Table("USUARIO")]
    public class Usuario : Entidade
    {
        [Column("NOME")]
        public string Nome { get; set; }
        [Column("EMAIL")]
        public string Email { get; set; }
        [Column("APELIDO")]
        public string Apelido { get; set; }
        [Column("SENHA")]
        public string Senha { get; set; }

    }
}
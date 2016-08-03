using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Smart.Dimdim.Api.Models
{
    [Table("CONTA")]
    public class Conta: Entidade
    {
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public string Titulo { get; set; }
        public decimal SaldoAtual { get; set; }
        public string Tipo { get; set; }
        public string Observacao { get; set; }
        public string Cor { get; set; }

    }
}
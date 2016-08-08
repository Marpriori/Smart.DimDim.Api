using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Smart.Dimdim.Api.Models
{
    [Table("CARTAO")]
    public class Cartao: Entidade
    {
        public int UsuarioId { get;set;}
        public Usuario Usuario { get; set; }
        public string Descricao { get; set; }
        public decimal Limite { get; set; }
        public int DiaFechamento { get; set; }
        public int DiaPagamento { get; set; }
        public int ContaId { get; set; }
        public Conta Conta { get; set; }
        public int BandeiraId { get; set; }
        public CartaoBandeira Bandeira { get; set; }
    }
}
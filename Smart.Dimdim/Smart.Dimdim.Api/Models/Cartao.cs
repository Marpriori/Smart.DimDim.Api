using System.ComponentModel.DataAnnotations.Schema;
using Smart.Dimdim.Api.Models.Base;

namespace Smart.Dimdim.Api.Models
{
    [Table("CARTAO")]
    public class Cartao : EntidadeUsuario
    {
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
using System;
using System.ComponentModel.DataAnnotations.Schema;
using Smart.Dimdim.Models.Base;

namespace Smart.Dimdim.Models
{
    [Table("CARTAO_FATURA")]
    public class CartaoFatura:Entidade
    {
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public int CartaoId { get; set; }
        public Cartao Cartao { get; set; }
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }
    }
}
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Smart.Dimdim.Api.Models
{
    [Table("CARTAO_MOVIMENTO")]
    public class CartaoMovimento:Entidade
    {
        public int OwnerId { get; set; }
        public CartaoMovimento Owner { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public int FaturaId { get; set; }
        public CartaoFatura Fatura { get; set; }
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }
        public bool Efetivado { get; set; }
        public int Parcela { get; set; }
        public int TotalParcela { get; set; }
        public string Observacao { get; set; }
    }
}
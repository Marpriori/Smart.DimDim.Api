using Smart.Dimdim.Api.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Smart.Dimdim.Api.Models
{
    public enum TipoContaMovimento {
        Receita = 'R',
        Despesa = 'D'
    }

    [Table("CONTA_MOVIMENTO")]
    public class ContaMovimento:EntidadeUsuario
    {
        public int OwnerId {get;set;}
        public ContaMovimento Owner { get; set; }

        public int ContaId { get; set; }
        public Conta Conta { get; set; }
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
        public TipoContaMovimento Tipo { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }
        public bool Efetivado { get; set; }


    }
}
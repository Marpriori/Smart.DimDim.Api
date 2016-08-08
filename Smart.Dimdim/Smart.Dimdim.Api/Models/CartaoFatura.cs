﻿using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Smart.Dimdim.Api.Models
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
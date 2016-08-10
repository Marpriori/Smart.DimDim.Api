
using System.ComponentModel.DataAnnotations.Schema;

using Smart.Dimdim.Api.Models.Interface;
using Smart.Dimdim.Api.Models.Base;

namespace Smart.Dimdim.Api.Models
{

    [Table("CONTA")]
    public class Conta : EntidadeUsuario
    {

        public string Titulo { get; set; }
        public decimal SaldoAtual { get; set; }
        public int TipoId { get; set; }
        public ContaTipo Tipo { get; set; }
        public string Observacao { get; set; }
        public string Cor { get; set; }

    }
}
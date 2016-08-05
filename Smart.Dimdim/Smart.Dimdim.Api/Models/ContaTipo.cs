using System.ComponentModel.DataAnnotations.Schema;

namespace Smart.Dimdim.Api.Models
{
    [Table("CONTA_TIPO")]
    public class ContaTipo: Entidade
    {
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public string Descricao { get; set; }
        public string Observacao { get; set; }
        public string Cor { get; set; }
    }
}
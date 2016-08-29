using Smart.Dimdim.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Smart.Dimdim.Models
{
    [Table("CONTA_TIPO")]
    public class ContaTipo: EntidadeUsuario
    {
        public string Descricao { get; set; }
        public string Observacao { get; set; }
        public string Cor { get; set; }
    }
}
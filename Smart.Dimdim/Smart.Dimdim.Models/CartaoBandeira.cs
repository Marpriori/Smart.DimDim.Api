
using System.ComponentModel.DataAnnotations.Schema;
using Smart.Dimdim.Models.Base;

namespace Smart.Dimdim.Models
{
    [Table("CARTAO_BANDEIRA")]
    public class CartaoBandeira: Entidade
    {
        public string Descricao { get; set; }
        public string Logotipo { get; set; }
    }
}
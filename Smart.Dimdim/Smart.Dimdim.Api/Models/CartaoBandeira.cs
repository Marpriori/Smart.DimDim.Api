
using System.ComponentModel.DataAnnotations.Schema;
namespace Smart.Dimdim.Api.Models
{
    [Table("CARTAO_BANDEIRA")]
    public class CartaoBandeira: Entidade
    {
        public string Descricao { get; set; }
        public string Logotipo { get; set; }
    }
}
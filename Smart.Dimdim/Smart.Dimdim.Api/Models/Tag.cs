using System.ComponentModel.DataAnnotations.Schema;

namespace Smart.Dimdim.Api.Models
{
    [Table("TAG")]
    public class Tag:Entidade
    {
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public string Descricao { get; set; }

    }
}
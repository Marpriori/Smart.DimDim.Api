using Smart.Dimdim.Api.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Smart.Dimdim.Api.Models
{
    [Table("TAG")]
    public class Tag:EntidadeUsuario
    {
        
        public string Descricao { get; set; }

    }
}
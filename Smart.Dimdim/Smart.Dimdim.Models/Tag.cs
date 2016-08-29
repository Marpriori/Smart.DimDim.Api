using Smart.Dimdim.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Smart.Dimdim.Models
{
    [Table("TAG")]
    public class Tag:EntidadeUsuario
    {
        
        public string Descricao { get; set; }

    }
}
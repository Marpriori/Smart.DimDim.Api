using System.ComponentModel.DataAnnotations;

namespace Smart.Dimdim.Api.Models
{
    public abstract class Entidade
    {
        [Key]
        public int Id { get; set; }
    }
}
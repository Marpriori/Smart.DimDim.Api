
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace Smart.Dimdim.Models
{
    public class Login
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Senha { get; set; }
    }
}

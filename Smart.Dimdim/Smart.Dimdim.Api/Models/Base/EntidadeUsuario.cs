using Smart.Dimdim.Api.Models.Interface;

namespace Smart.Dimdim.Api.Models.Base
{
    public class EntidadeUsuario: Entidade, IPorUsuarioModel
    {
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}
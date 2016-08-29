using Smart.Dimdim.Models.Interface;

namespace Smart.Dimdim.Models.Base
{
    public class EntidadeUsuario: Entidade, IPorUsuarioModel
    {
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}
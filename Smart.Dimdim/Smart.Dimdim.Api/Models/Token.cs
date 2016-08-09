using Smart.Dimdim.Api.Database;
using System;
using System.Net;
using System.Text;
using System.Web;

namespace Smart.Dimdim.Api.Models
{
    public class Token : Entidade
    {
        public string Valor { get; set; }
        public DateTime Validade { get; set; }
        public string Nome { get; set; }

        public Usuario Usuario { get; private set; }

        public Token()
        {

        }
        public Token(Usuario usuario)
        {

            Bind(usuario);

        }

        private void Bind(Usuario usuario)
        {
            Id = 1;
            Nome = usuario.Nome;
            Validade = DateTime.Now;
            Valor = GenerateToken(usuario);
        }

        public string GenerateToken(Usuario usuario)
        {
            return Convert.ToBase64String(
                Encoding.UTF8.GetBytes(
                string.Format("{0}:{1}", usuario.Email, usuario.Senha)));
        }

        public Token Login(string email, string senha)
        {
            if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(senha))
                throw new HttpException(HttpStatusCode.Unauthorized, "E-mail e senha obrigatórios.");

            var db = new SmartDimdimContext();
            Usuario = db.Usuarios.FirstOrDefault(
                u => u.Email == email &&
                     u.Senha == Usuario.Crypto(senha));

            if (Usuario == null)
                throw new HttpException(HttpStatusCode.Unauthorized, "Usuário não encontrado.");

            HttpContext.Current.User = new GenericPrincipal(new ApiIdentity(Usuario), new string[] { });

            Bind(usuario);


            this;
        }
    }
}
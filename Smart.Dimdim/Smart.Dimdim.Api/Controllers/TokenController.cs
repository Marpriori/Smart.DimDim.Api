using Smart.Dimdim.Api.App_Start;
using Smart.Dimdim.Api.Controllers.Base;
using Smart.Dimdim.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Security.Principal;
using System.Text;
using System.Web;
using System.Web.Http;

namespace Smart.Dimdim.Api.Controllers
{
    /// <summary>
    /// api/Token
    /// </summary>
    public class TokenController : ApiBaseController
    {
        [BasicAuthApiFilter]
        public IEnumerable<Token> Get()
        {
            var identidade = HttpContext.Current.User.Identity as ApiIdentity;
            if (identidade == null) throw new HttpApiException(HttpStatusCode.Unauthorized, "Usuário não identificado. Fazer login.");

            var usuario = identidade.Usuario;


            return new List<Token>() { new Token(usuario) };
        }

        // POST: api/Token
        public IHttpActionResult Post([FromBody]Login login)
        {
            
            login.Senha = Usuario.Crypto(login.Senha);
            var token =Login(login.Email,login.Senha);

            return Ok(token);
        }

        private Token Bind(Usuario usuario)
        {
            var token = new Token(usuario);
            token.Id = 1;
            token.Nome = usuario.Nome;
            token.Validade = DateTime.Now.AddMinutes(60);
            token.Valor = GenerateToken(usuario);
            return token;
        }

        public string GenerateToken(Usuario usuario)
        {
            return Convert.ToBase64String(
                Encoding.UTF8.GetBytes(
                string.Format("{0}:{1}", usuario.Email, usuario.Senha)));
        }

        public Token Login(string email, string senha)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(senha))
                throw new HttpApiException(HttpStatusCode.Unauthorized, "E-mail e senha obrigatórios.");

           var usuario = db.Usuarios.FirstOrDefault(
                u => u.Email == email &&
                     u.Senha == senha);

           if (usuario == null)
                throw new HttpApiException(HttpStatusCode.Unauthorized, "Usuário não encontrado.");

           HttpContext.Current.User = new GenericPrincipal(new ApiIdentity(usuario), new string[] { });

           return Bind(usuario);

        }
    }

}

using Smart.Dimdim.Api.App_Start;
using Smart.Dimdim.Api.Controllers.Base;
using Smart.Dimdim.Api.Models;
using System.Collections.Generic;
using System.Net;
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
            var token = new Token();
            login.Senha = Usuario.Crypto(login.Senha);
            token.Login(login.Email,login.Senha);

            return Ok(token);
        }
    }

    public class Login
    {
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}

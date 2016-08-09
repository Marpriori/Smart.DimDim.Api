using Smart.Dimdim.Api.App_Start;
using Smart.Dimdim.Api.Controllers.Base;
using Smart.Dimdim.Api.Models;
using System.Collections.Generic;
using System.Net;
using System.Web;
using System.Web.Http;

namespace Smart.Dimdim.Api.Controllers
{
    public class TokenController : ApiBaseController
    {
        // GET: api/Token
        public IEnumerable<Token> Get()
        {
            var identidade = HttpContext.Current.User.Identity as ApiIdentity;
            if (identidade == null) throw new HttpResponseException(HttpStatusCode.Unauthorized);

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

        // PUT: api/Token/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Token/5
        public void Delete(int id)
        {
        }
    }

    public class Login
    {
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}

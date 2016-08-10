using Smart.Dimdim.Api.Database;
using Smart.Dimdim.Api.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.OData;
using Smart.Dimdim.Api.App_Start;
using Smart.Dimdim.Api.Controllers.Base;

namespace Smart.Dimdim.Api.Controllers
{
    public class ContasController : ODataBaseController
    {

        // GET odata/contas
        [Queryable]
        public IQueryable<Conta> GetContas()
        {
            return db.Contas.Where(conta => conta.UsuarioId == UsuarioLogado.Id);
        }

        // GET odata/contas(5)
        [Queryable]
        public SingleResult<Conta> GetConta([FromODataUri] int key)
        {
            return SingleResult.Create(
                db.Contas.Where(
                conta =>
                    conta.UsuarioId == UsuarioLogado.Id &&
                    conta.Id == key));
        }

        // PUT odata/contas(5)
        public IHttpActionResult Put([FromODataUri] int key, Conta conta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (key != conta.Id)
            {
                return BadRequest();
            }
            conta.UsuarioId = UsuarioLogado.Id;
            db.Entry(conta).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContaExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(conta);
        }

        // POST odata/contas
        public IHttpActionResult Post(Conta conta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            conta.UsuarioId = UsuarioLogado.Id;
            db.Contas.Add(conta);
            db.SaveChanges();

            return Created(conta);
        }

        // PATCH odata/contas(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<Conta> patch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Conta conta = db.Contas.Find(key);
            if (conta == null)
            {
                return NotFound();
            }

            patch.Patch(conta);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContaExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(conta);
        }

        // DELETE odata/contas(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            Conta conta = db.Contas.Find(key);
            if (conta == null || conta.UsuarioId != UsuarioLogado.Id)
            {
                return NotFound();
            }

            db.Contas.Remove(conta);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        private bool ContaExists(int key)
        {
            return db.Contas.Any(e => e.Id == key);
        }


    }
}

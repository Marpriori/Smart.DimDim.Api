using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using Smart.Dimdim.Api.Models;
using Smart.Dimdim.Api.Database;

namespace Smart.Dimdim.Api.Controllers
{

    public class ContasController : ODataController
    {
        private SmartDimdimContext db = new SmartDimdimContext();

        // GET odata/contas
        [Queryable]
        public IQueryable<Conta> Getcontas()
        {
            return db.Contas;
        }

        // GET odata/contas(5)
        [Queryable]
        public SingleResult<Conta> GetConta([FromODataUri] int key)
        {
            return SingleResult.Create(db.Contas.Where(conta => conta.Id == key));
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
            if (conta == null)
            {
                return NotFound();
            }

            db.Contas.Remove(conta);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ContaExists(int key)
        {
            return db.Contas.Count(e => e.Id == key) > 0;
        }
    }
}

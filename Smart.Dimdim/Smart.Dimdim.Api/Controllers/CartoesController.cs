﻿using Smart.Dimdim.Api.Database;
using Smart.Dimdim.Api.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;

namespace Smart.Dimdim.Api.Controllers
{

    public class CartoesController : ODataController
    {
        private SmartDimdimContext db = new SmartDimdimContext();

        // GET odata/Cartoes
        [Queryable]
        public IQueryable<Cartao> GetCartoes()
        {
            return db.Cartaos;
        }

        // GET odata/Cartoes(5)
        [Queryable]
        public SingleResult<Cartao> GetCartao([FromODataUri] int key)
        {
            return SingleResult.Create(db.Cartaos.Where(cartao => cartao.Id == key));
        }

        // PUT odata/Cartoes(5)
        public IHttpActionResult Put([FromODataUri] int key, Cartao cartao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (key != cartao.Id)
            {
                return BadRequest();
            }

            db.Entry(cartao).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CartaoExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(cartao);
        }

        // POST odata/Cartoes
        public IHttpActionResult Post(Cartao cartao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Cartaos.Add(cartao);
            db.SaveChanges();

            return Created(cartao);
        }

        // PATCH odata/Cartoes(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<Cartao> patch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Cartao cartao = db.Cartaos.Find(key);
            if (cartao == null)
            {
                return NotFound();
            }

            patch.Patch(cartao);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CartaoExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(cartao);
        }

        // DELETE odata/Cartoes(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            Cartao cartao = db.Cartaos.Find(key);
            if (cartao == null)
            {
                return NotFound();
            }

            db.Cartaos.Remove(cartao);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET odata/Cartoes(5)/Conta
        [Queryable]
        public SingleResult<Conta> GetConta([FromODataUri] int key)
        {
            return SingleResult.Create(db.Cartaos.Where(m => m.Id == key).Select(m => m.Conta));
        }

        // GET odata/Cartoes(5)/Usuario
        [Queryable]
        public SingleResult<Usuario> GetUsuario([FromODataUri] int key)
        {
            return SingleResult.Create(db.Cartaos.Where(m => m.Id == key).Select(m => m.Usuario));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CartaoExists(int key)
        {
            return db.Cartaos.Count(e => e.Id == key) > 0;
        }
    }
}

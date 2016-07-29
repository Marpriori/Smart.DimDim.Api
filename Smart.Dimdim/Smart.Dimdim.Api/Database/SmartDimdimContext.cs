using Smart.Dimdim.Api.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Smart.Dimdim.Api.Database
{
    internal class SmartDimdimContext: DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
using Smart.Dimdim.Api.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Smart.Dimdim.Api.Database
{
    public class SmartDimdimContext:DbContext
    {
        public SmartDimdimContext()
            : base("name=SmartDimdimContext")
        {
        }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
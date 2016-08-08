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
        public DbSet<Conta> Contas { get; set; }

        public System.Data.Entity.DbSet<Smart.Dimdim.Api.Models.Cartao> Cartaos { get; set; }

        public System.Data.Entity.DbSet<Smart.Dimdim.Api.Models.Categoria> Categorias { get; set; }

        public System.Data.Entity.DbSet<Smart.Dimdim.Api.Models.ContaMovimento> ContaMovimentoes { get; set; }

        public System.Data.Entity.DbSet<Smart.Dimdim.Api.Models.ContaTipo> ContaTipoes { get; set; }

        public System.Data.Entity.DbSet<Smart.Dimdim.Api.Models.Tag> Tags { get; set; }

        public System.Data.Entity.DbSet<Smart.Dimdim.Api.Models.CartaoBandeira> CartaoBandeiras { get; set; }

        public System.Data.Entity.DbSet<Smart.Dimdim.Api.Models.CartaoFatura> CartaoFaturas { get; set; }

        public System.Data.Entity.DbSet<Smart.Dimdim.Api.Models.CartaoMovimento> CartaoMovimentoes { get; set; }
    }
}
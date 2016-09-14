using Smart.Dimdim.Models;
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
        public System.Data.Entity.DbSet<Smart.Dimdim.Models.Usuario> Usuarios { get; set; }
        public System.Data.Entity.DbSet<Smart.Dimdim.Models.Conta> Contas { get; set; }

        public System.Data.Entity.DbSet<Smart.Dimdim.Models.Cartao> Cartaos { get; set; }

        public System.Data.Entity.DbSet<Smart.Dimdim.Models.Categoria> Categorias { get; set; }

        public System.Data.Entity.DbSet<Smart.Dimdim.Models.ContaMovimento> ContaMovimentoes { get; set; }

        public System.Data.Entity.DbSet<Smart.Dimdim.Models.ContaTipo> ContaTipoes { get; set; }

        public System.Data.Entity.DbSet<Smart.Dimdim.Models.Tag> Tags { get; set; }

        public System.Data.Entity.DbSet<Smart.Dimdim.Models.CartaoBandeira> CartaoBandeiras { get; set; }

        public System.Data.Entity.DbSet<Smart.Dimdim.Models.CartaoFatura> CartaoFaturas { get; set; }

        public System.Data.Entity.DbSet<Smart.Dimdim.Models.CartaoMovimento> CartaoMovimentoes { get; set; }
    }
}
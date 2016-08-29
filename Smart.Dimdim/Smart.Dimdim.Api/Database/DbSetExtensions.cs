using Smart.Dimdim.Models.Base;
using System.Data.Entity;
using System.Linq;

namespace Smart.Dimdim.Api.Database
{
    public static class DbSetExtensions
    {
        public static IQueryable<T> WhereUsuario<T>(this DbSet<T> dataSet, int usuarioId) where T : EntidadeUsuario
        {
            return dataSet.Where(registro => registro.UsuarioId == usuarioId);
        }
    }
}
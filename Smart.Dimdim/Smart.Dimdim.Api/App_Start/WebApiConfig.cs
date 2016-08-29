using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.OData.Builder;
using Microsoft.Data.Edm;
using Smart.Dimdim.Models;

namespace Smart.Dimdim.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            config.Routes.MapODataRoute("SmartDimDimOData", "OData", GenerateEdmModel());
        }

        private static IEdmModel GenerateEdmModel()
        {
            var builder = new ODataConventionModelBuilder();
            builder.EntitySet<Cartao>("Cartoes");
            builder.EntitySet<CartaoBandeira>("CartaoBandeiras");
            builder.EntitySet<CartaoFatura>("CartaoFaturas");
            builder.EntitySet<CartaoMovimento>("CartaoMovimentos");
            builder.EntitySet<Categoria>("Categorias");
            builder.EntitySet<Conta>("Contas");
            builder.EntitySet<ContaMovimento>("ContaMovimentos");
            builder.EntitySet<ContaTipo>("ContaTipos");
            builder.EntitySet<Tag>("Tags");
            builder.EntitySet<Usuario>("Usuarios");
            
            return builder.GetEdmModel();
        }
    }
}

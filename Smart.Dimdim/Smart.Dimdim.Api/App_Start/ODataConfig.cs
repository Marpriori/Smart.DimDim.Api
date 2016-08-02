using Microsoft.Data.Edm;
using Smart.Dimdim.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.OData.Builder;

namespace Smart.Dimdim.Api.App_Start
{
    public class ODataConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapODataRoute("elearningOData", "OData", GenerateEdmModel());
        }

        private static IEdmModel GenerateEdmModel()
        {
            var builder = new ODataConventionModelBuilder();
            builder.EntitySet<Usuario>("Usuarios");
            
            return builder.GetEdmModel();
        }
    }
}
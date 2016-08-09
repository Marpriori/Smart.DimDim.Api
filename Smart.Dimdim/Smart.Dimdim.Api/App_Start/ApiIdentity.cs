using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Principal;
using Smart.Dimdim.Api.Models;

namespace Smart.Dimdim.Api.App_Start
{
    public class ApiIdentity : IIdentity
    {
        public Usuario Usuario { get; private set; }

        public ApiIdentity(Usuario usuario)
        {
            if (usuario == null)
                throw new ArgumentNullException("usuario");

            this.Usuario = usuario;
        }

        public string Name
        {
            get { return this.Usuario.Nome; }
        }

        public string AuthenticationType
        {
            get { return "Basic"; }
        }

        public bool IsAuthenticated
        {
            get { return true; }
        }
    }
}
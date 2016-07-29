using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Smart.Dimdim.Api.Models
{
    public class Entidade
    {
        [Column("ID")]
        public int Id { get; set; }
    }
}
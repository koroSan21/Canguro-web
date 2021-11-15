using Canguro.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CanguroWeb.Models
{
    public class CiudadModel{

        public Ciudad Ciudad { get; set; }

        public List<Estado> Estados { get; set; }
    }
}
using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiConsultaClima.Models
{
    public class Humidade
    {
        [DeserializeAs(Name = "min")]
        public string Min { get; set; }

        [DeserializeAs(Name = "max")]
        public string Max { get; set; }

    }
}
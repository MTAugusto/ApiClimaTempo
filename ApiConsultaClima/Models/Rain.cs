using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiConsultaClima.Models
{
    public class Rain
    {
        [DeserializeAs(Name = "probability")]
        public string Probability { get; set; }

        [DeserializeAs(Name = "precipitation")]
        public string Precipitation { get; set; }

    }
}
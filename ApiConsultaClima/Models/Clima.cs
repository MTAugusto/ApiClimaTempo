using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiConsultaClima.Models
{
    public class Clima
    {

        [DeserializeAs(Name = "id")]
        public string ID { get; set; }

        [DeserializeAs(Name = "name")]
        public string Name { get; set; }

        [DeserializeAs(Name = "state")]
        public string State { get; set; }

        [DeserializeAs(Name = "country")]
        public string Country { get; set; }

        [DeserializeAs(Name = "data")]
        public List<Dados> Data { get; set; }        
    }
}
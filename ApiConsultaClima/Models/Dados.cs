using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiConsultaClima.Models
{
    public class Dados
    {

        [DeserializeAs(Name = "date")]
        public string Date { get; set; }

        [DeserializeAs(Name = "date_br")]
        public string Date_br { get; set; }

        [DeserializeAs(Name = "humidity")]
        public Humidade Humidity { get; set; }

        [DeserializeAs(Name = "rain")]
        public Rain Rain { get; set; }

    }
}
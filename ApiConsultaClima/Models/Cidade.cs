using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace ApiConsultaClima.Models
{
    public class Cidade
    {
        [DeserializeAs(Name = "id")]
        public String Idclimatempo { get; set; }

       

    }
}
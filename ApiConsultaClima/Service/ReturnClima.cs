using ApiConsultaClima.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiConsultaClima.Service
{
    public class ReturnClima : IApi
    {

        public string BaseUrl
        {
            get { return "http://apiadvisor.climatempo.com.br/api/v1"; }
        }

        public List<Clima> GetClima(string searchQuery, string apiKey)
        {
                      
            string buscaClima = string.Format("/forecast/locale/" + searchQuery + "/days/15?token=" + apiKey);
            var clima = new RestClient(BaseUrl + buscaClima);
            var responseclima = clima.Execute<List<Clima>>(new RestRequest());

            if (responseclima != null)
            {

                return responseclima.Data;
            }
            //criar execção.
            return null;
        }



    }
}
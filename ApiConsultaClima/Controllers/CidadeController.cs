using ApiConsultaClima.Constants;
using ApiConsultaClima.Models;
using ApiConsultaClima.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RestSharp;
using Newtonsoft.Json.Linq;

namespace ApiConsultaClima.Controllers
{
    
    public class CidadeController : ApiController
    {
        
        [Route("api/buscacidade/cidade")]
        [HttpGet]
        public List<Clima> GetClima(String name, String state)
        {            

                SearchCidade apicity = new SearchCidade();
                var resultcidade = apicity.GetCidades(name,state);

            if (resultcidade == null)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format("Não foi possivel localizar a cidade " + name)),
                    ReasonPhrase = "Cidade Não localizada."
                };
                throw new HttpResponseException(resp);
            }
            if (resultcidade == "500")
            {
                var resp = new HttpResponseMessage(HttpStatusCode.ServiceUnavailable)
                {
                    Content = new StringContent(string.Format("O Serviço esta indisponivel no momento")),
                    ReasonPhrase = "Serviço indisponivel"
                };
                throw new HttpResponseException(resp);
            }
            else
            {
                ReturnClima clima = new ReturnClima();
                var resultclima = clima.GetClima(resultcidade, Constants.RequestConstants.ClimaTempoAdvisorkey);
                return resultclima;
            }

        }
    }
}

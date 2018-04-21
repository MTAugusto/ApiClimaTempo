using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace ApiConsultaClima
{
    public class HttpInstance
    {
        private static HttpClient httpClientIntance;

        private HttpInstance() { }

        public static HttpClient GetHttpClientInstance()
        {
            if (httpClientIntance == null)
            {
                httpClientIntance = new HttpClient();
                httpClientIntance.DefaultRequestHeaders.ConnectionClose = false;
            }

            return httpClientIntance;
        }

    }
}
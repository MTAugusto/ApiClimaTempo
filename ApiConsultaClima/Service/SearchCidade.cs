using ApiConsultaClima.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace ApiConsultaClima.Service
{
    internal class SearchCidade : IApi
    {

        public string BaseUrl
        {
            get { return "http://apiadvisor.climatempo.com.br/api/v1"; }
        }

        public String GetCidades(string name, string state)
        {

            List<Cidade> lscidade = new List<Cidade>();

            try
            {
                // criando conexão com banco de dados.
                using (SqlConnection connection = new SqlConnection(Constants.Connection.ConnectionString))
                {
                    //abrindo nova conexão.
                    connection.Open();

                    //Criando query a ser executada no banco.
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "select * from cidades where nome like '%" + name + "'and estados_idestados =" + state;
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            //Grava resultado na classe cidades.
                            Cidade cidade = new Cidade()
                            {
                                Idclimatempo = reader["idclimatempo"] == DBNull.Value ? string.Empty : reader["idclimatempo"].ToString()
                            };

                            lscidade.Add(cidade);
                        }
                    }
                    connection.Close();
                }
                if (lscidade.Count > 0 || lscidade.Count < 2)
                {
                    //lista unico resultado retornado da string.
                    return lscidade.Single().Idclimatempo;
                }
                else
                {
                    return null;
                }

            }
            catch
            {
                var buscacidade = String.Format("/locale/city?name="+name+"&state="+state+"&token="+Constants.RequestConstants.ClimaTempoAdvisorkey);                
                var requestcidade = new RestClient(BaseUrl + buscacidade);               
                var responsecidade = requestcidade.Execute<List<Cidade>>(new RestRequest(Method.GET));              

                if (responsecidade.Data.Count == 0)
                {
                    return null;
                }
                if (responsecidade.Data.Count >= 1 )
                {
                    return responsecidade.Data[0].Idclimatempo;
                }
                                        
                return "500";
            }

        }
    }
}
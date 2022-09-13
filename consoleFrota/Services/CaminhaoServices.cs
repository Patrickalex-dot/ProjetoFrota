using consoleFrota.Dto_s;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;

namespace consoleFrota.Services
{
    public class CaminhaoServices
    {
        public List<CaminhaoDto> BuscarTodos()
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response;

            try
            {
                response = httpClient.GetAsync("https://localhost:44378/Caminhao/BuscarTodos").Result;
                response.EnsureSuccessStatusCode();

                var resultado = response.Content.ReadAsStringAsync().Result;

                if(response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    Console.WriteLine(resultado);
                    return new List<CaminhaoDto>();
                }
                var objetoDesserelizado = JsonConvert.DeserializeObject <List<CaminhaoDto>>(resultado);

                return objetoDesserelizado;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex.Message);
                return new List<CaminhaoDto>(); 
            }
        }
        public void Salvar (Caminhao caminhao)
        {

        }
    }
}

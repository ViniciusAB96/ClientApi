using System;
using System.Net.Http;

namespace ClientApi
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:54777/");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            System.Net.Http.HttpResponseMessage response = client.GetAsync("api/usuario/ConsultarUsuarios").Result;

            if (response.IsSuccessStatusCode)
            {
                Uri usuarioUri = response.Headers.Location;
                var usuarios = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(usuarios.ToString());
            }
            else
            {
                Console.WriteLine("Erro de Comunicação !!! Deu ruim !!!");
            }
            System.Console.ReadLine();


        }
    }
}

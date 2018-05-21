using System;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Headers;
using System.Net.Http;
using Newtonsoft.Json;
using CrossCutting.Authentication;

namespace ConsoleAppCloseFriends
{
    class Program
    {
        static string _urlAPIBase;

        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                 .SetBasePath(System.IO.Directory.GetCurrentDirectory())
                 .AddJsonFile($"appsettings.json");
            var config = builder.Build();

            _urlAPIBase = config.GetSection("API_Access:UrlAPI").Value;

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage respToken = client.PostAsync(
                    _urlAPIBase + "authentication", new StringContent(
                        JsonConvert.SerializeObject(new
                        {
                            UserID = config.GetSection("API_Access:UserID").Value,
                            AccessKey = config.GetSection("API_Access:AccessKey").Value
                        }), System.Text.Encoding.UTF8, "application/json")).Result;

                string content = respToken.Content.ReadAsStringAsync().Result;

                Console.WriteLine(content);

                if (respToken.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    Token token = JsonConvert.DeserializeObject<Token>(content);
                    if (token.Authenticated)
                    {
                        client.DefaultRequestHeaders.Authorization =
                            new AuthenticationHeaderValue("Bearer", token.AccessToken);

                        CloseFriends(client, 2, 1);
                        CloseFriends(client, 10, 20);
                        CloseFriends(client, 30, 1);
                        CloseFriends(client, 4, 1);
                        CloseFriends(client, 7, 12);
                        CloseFriends(client, 2, 11);
                    }
                }
            }

            Console.WriteLine("\nFim!");
            Console.ReadKey();
        }

        private static void CloseFriends(HttpClient client, int X, int Y)
        {
            HttpResponseMessage response = client.GetAsync(
                $"{_urlAPIBase}closefriends/getfriends/{X}/{Y}").Result;

            Console.WriteLine();
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                Console.WriteLine(response.Content.ReadAsStringAsync().Result);
            else
                Console.WriteLine("Token expirou!");

            Console.WriteLine("\nAperte [Enter] para próxima requisição.");
            Console.ReadKey();
        }
    }
}

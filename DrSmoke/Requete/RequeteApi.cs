using DrSmoke.Models;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DrSmoke.Requete
{
   
    class RequeteApi
    {
        public int count = 0;
        public List<Models.Magasin> Magasin { get; private set; }
        private readonly HttpClient _client;
        private readonly JsonSerializerOptions _serializerOptions;
        protected string urlMagasin = "http://localhost:3000/DrSmokeApi";

        public RequeteApi()
        {
            _client = new HttpClient();
            _serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }

        public async Task<bool> ConnexionUser(Connexion connexion)
        {
            Uri uri = new Uri($"{urlMagasin}/connexion");
            try
            {
                string json = JsonSerializer.Serialize<Models.Connexion>(connexion, _serializerOptions);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _client.PostAsync(uri, content);
                string responseContent = await response.Content.ReadAsStringAsync();
                var apiResponse = JsonSerializer.Deserialize<Models.ReponseAPI>(responseContent);
                if (response.IsSuccessStatusCode)
                {
                    await SecureStorage.Default.SetAsync("oauth_token", apiResponse.Token);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Une erreur est survenue: {ex.ToString}");
            }
        }
        public async Task<string> InscriptionUser(Inscription inscription) 
        {
            Uri uri = new Uri($"{urlMagasin}/inscription");
            try
            {
                string json = JsonSerializer.Serialize<Models.Inscription>(inscription, _serializerOptions);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _client.PostAsync(uri, content);
                string responseContent = await response.Content.ReadAsStringAsync();
                var apiResponse = JsonSerializer.Deserialize<Models.ReponseAPI>(responseContent);
                if (response.IsSuccessStatusCode)
                {
                    return apiResponse.Message;
                }
                else
                {
                    return apiResponse.Message; 
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Une erreur est survenue: {ex.ToString}");
            }
        }

        public async Task<List<Models.Magasin>> RefreshDataAsync()
        {
            Magasin = new List<Models.Magasin>();

            Uri uri = new Uri($"{urlMagasin}/magasin");
            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Magasin = JsonSerializer.Deserialize<List<Models.Magasin>>(content, _serializerOptions);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return Magasin;
        }

        public async Task<List<T>> MagasinAndProduct()
        {
            Uri uri = new Uri($"{urlMagasin}/uuidMagasin");
        }

    }
}

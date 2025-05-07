using System.Net.Http;
using System.Net.Http.Json;
using WebApp.Models;

namespace WebApp.Services
{
    public class ApiService
    {
        private readonly HttpClient _http;
        private readonly string _apiBaseUrl;

        public ApiService(HttpClient http, IConfiguration config)
        {
            _http = http;
            _apiBaseUrl = config["ApiBaseUrl"] ?? throw new Exception("ApiBaseUrl no configurado");
        }

        public async Task<List<Region>> GetRegionesAsync()
        {
            var response = await _http.GetAsync($"{_apiBaseUrl}/api/region");
            response.EnsureSuccessStatusCode();

            var regiones = await response.Content.ReadFromJsonAsync<List<Region>>();
            return regiones ?? throw new Exception("No se pudieron obtener las regiones.");
        }

        public async Task<List<Comuna>> GetComunasByRegion(int id)
        {
            var response = await _http.GetAsync($"{_apiBaseUrl}/api/region/{id}/comuna");
            response.EnsureSuccessStatusCode();

            var comunas = await response.Content.ReadFromJsonAsync<List<Comuna>>();
            return comunas ?? throw new Exception("No se pudieron obtener las comunas.");
        }
    }

}

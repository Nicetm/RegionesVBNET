using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApiService _api;
        private readonly ITokenService _tokenService;

        public HomeController(ApiService api, ITokenService tokenService)
        {
            _api = api;
            _tokenService = tokenService;
        }

        public async Task<IActionResult> Index()
        {
            var regiones = await _api.GetRegionesAsync();

            foreach (var region in regiones)
            {
                region.Token = GenerateToken(region.IdRegion);
            }

            return View(regiones);
        }

        [HttpGet]
        public async Task<IActionResult> Comunas(string t)
        {
            if (string.IsNullOrEmpty(t) || !_tokenService.ValidateToken(t, out int regionId))
                return RedirectToAction("Index");

            var comunas = await _api.GetComunasByRegion(regionId);
            var viewModel = new List<Comuna>();

            foreach (var comuna in comunas)
            {
                string superficie = "", poblacion = "", densidad = "";

                try
                {
                    if (!string.IsNullOrEmpty(comuna.InformacionAdicional))
                    {
                        var xml = System.Xml.Linq.XElement.Parse(comuna.InformacionAdicional);
                        superficie = xml.Element("Superficie")?.Value ?? "N/A";
                        var poblacionElem = xml.Element("Poblacion");
                        poblacion = poblacionElem?.Value ?? "N/A";
                        densidad = poblacionElem?.Attribute("Densidad")?.Value ?? "N/A";
                    }
                }
                catch
                {
                    superficie = poblacion = densidad = "Formato inválido";
                }

                viewModel.Add(new Comuna
                {
                    Nombre = comuna.Nombre ?? "Sin nombre",
                    Superficie = superficie,
                    Poblacion = poblacion,
                    Densidad = densidad
                });
            }

            return View("Comunas", viewModel);
        }

        public string GenerateToken(int regionId)
        {
            return _tokenService.GenerateToken(regionId);
        }
    }
}

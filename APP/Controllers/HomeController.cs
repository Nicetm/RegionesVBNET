using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.Controllers
{
    /// <summary>
    /// Controlador principal del sitio web, encargado de mostrar la lista de regiones y las comunas asociadas a cada una.
    /// </summary>
    public class HomeController : Controller
    {
        private readonly ApiService _api;

        /// <summary>
        /// Constructor que recibe el servicio para consumir la API externa.
        /// </summary>
        /// <param name="api">Servicio HTTP para acceder a la API de regiones y comunas.</param>
        public HomeController(ApiService api)
        {
            _api = api;
        }

        /// <summary>
        /// Acción que carga la vista inicial con el listado de regiones.
        /// </summary>
        /// <returns>Vista con la lista de regiones.</returns>
        public async Task<IActionResult> Index()
        {
            var regiones = await _api.GetRegionesAsync();
            return View(regiones);
        }

        /// <summary>
        /// Acción que muestra la lista de comunas asociadas a una región, transformando el XML a campos legibles.
        /// </summary>
        /// <param name="id">Id de la región seleccionada.</param>
        /// <returns>Vista con la lista de comunas y sus datos procesados.</returns>
        public async Task<IActionResult> Comunas(int id)
        {
            var comunas = await _api.GetComunasByRegion(id);
            var viewModel = new List<Comuna>();

            foreach (var comuna in comunas)
            {
                string superficie = "", poblacion = "", densidad = "";

                try
                {
                    if (!string.IsNullOrEmpty(comuna.InformacionAdicional))
                    {
                        // Se intenta parsear el XML contenido en InformacionAdicional
                        var xml = System.Xml.Linq.XElement.Parse(comuna.InformacionAdicional);
                        superficie = xml.Element("Superficie")?.Value ?? "N/A";

                        var poblacionElem = xml.Element("Poblacion");
                        poblacion = poblacionElem?.Value ?? "N/A";
                        densidad = poblacionElem?.Attribute("Densidad")?.Value ?? "N/A";
                    }
                }
                catch
                {
                    // Si el XML está mal formado, se informa que el formato es inválido
                    superficie = poblacion = densidad = "Formato inválido";
                }

                // Se construye el modelo de comuna con datos procesados
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
    }
}

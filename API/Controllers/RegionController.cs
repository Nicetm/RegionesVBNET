using DAL.Interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/region")]
    public class RegionController : ControllerBase
    {
        private readonly IRegionRepository _regionRepo;
        private readonly IComunaRepository _comunaRepo;

        // Constructor que inyecta los repositorios de región y comuna
        public RegionController(IRegionRepository regionRepo, IComunaRepository comunaRepo)
        {
            _regionRepo = regionRepo;
            _comunaRepo = comunaRepo;
        }

        /// <summary>
        /// Obtiene todas las regiones registradas en la base de datos.
        /// </summary>
        /// <returns>Listado de regiones</returns>
        [HttpGet]
        public IActionResult GetAll() => Ok(_regionRepo.GetAll());

        /// <summary>
        /// Obtiene una región específica por su ID.
        /// </summary>
        /// <param name="id">ID de la región</param>
        /// <returns>Región encontrada o null</returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id) => Ok(_regionRepo.GetById(id));

        /// <summary>
        /// Lista todas las comunas asociadas a una región específica.
        /// </summary>
        /// <param name="id">ID de la región</param>
        /// <returns>Listado de comunas</returns>
        [HttpGet("{id}/comuna")]
        public IActionResult GetComunasByRegion(int id) => Ok(_comunaRepo.GetByRegion(id));

        /// <summary>
        /// Obtiene una comuna específica dentro de una región.
        /// </summary>
        /// <param name="idRegion">ID de la región</param>
        /// <param name="idComuna">ID de la comuna</param>
        /// <returns>Comuna encontrada</returns>
        [HttpGet("{idRegion}/comuna/{idComuna}")]
        public IActionResult GetComuna(int idRegion, int idComuna) =>
            Ok(_comunaRepo.GetById(idRegion, idComuna));

        /// <summary>
        /// Guarda o actualiza una comuna en una región (MERGE).
        /// </summary>
        /// <param name="idRegion">ID de la región a la que pertenece</param>
        /// <param name="comuna">Objeto comuna con sus datos</param>
        /// <returns>Estado OK</returns>
        [HttpPost("{idRegion}/comuna")]
        public IActionResult SaveComuna(int idRegion, [FromBody] Comuna comuna)
        {
            _comunaRepo.Merge(comuna, idRegion);
            return Ok(new { status = "OK" });
        }
    }
}

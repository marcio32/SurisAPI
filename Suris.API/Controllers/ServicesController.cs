using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Suris.API.Controllers
{
    /// <summary>
    /// Controlador para gestionar los servicios disponibles.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly IServiceRepository _serviceRepository;

        /// <summary>
        /// Constructor del controlador de servicios.
        /// </summary>
        /// <param name="serviceRepository">Repositorio de servicios.</param>
        public ServicesController(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        /// <summary>
        /// Obtiene un listado de todos los servicios disponibles.
        /// </summary>
        /// <returns>Lista de servicios.</returns>
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Service>>> GetAllServices()
        {
            var services = await _serviceRepository.GetAllAsync();
            return Ok(services);
        }
    }
}

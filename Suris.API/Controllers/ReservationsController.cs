using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Suris.API.Controllers
{
    /// <summary>
    /// Controlador para gestionar las reservas de servicios.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ReservationsController : ControllerBase
    {
        private readonly IReservationService _reservationService;

        /// <summary>
        /// Constructor del controlador de reservas.
        /// </summary>
        /// <param name="reservationService">Servicio para gestionar reservas.</param>
        public ReservationsController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        /// <summary>
        /// Obtiene la lista de todas las reservas generadas.
        /// </summary>
        /// <returns>Lista de reservas.</returns>
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetReservations()
        {
            return Ok(await _reservationService.GetReservationsAsync());
        }

        /// <summary>
        /// Crea una nueva reserva si es válida.
        /// </summary>
        /// <param name="reservationDto">Datos de la reserva.</param>
        /// <returns>Resultado de la operación.</returns>
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateReservation([FromBody] ReservationRequestDto reservationDto)
        {
            if (reservationDto == null)
            {
                return BadRequest(new { message = "Los datos de la reserva son requeridos." });
            }

            try
            {
                var reservation = new Reservation
                {
                    ClientName = reservationDto.ClientName,
                    DateReservation = reservationDto.DateReservation,
                    ServiceId = reservationDto.ServiceId
                };

                var success = await _reservationService.CreateReservationAsync(reservation);
                if (success)
                {
                    return Ok(new { message = "Reserva creada exitosamente." });
                }

                return BadRequest(new { message = "No se pudo crear la reserva." });
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error interno del servidor.", details = ex.Message });
            }
        }
    }
}

using Application.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _reservationRepository;

        public ReservationService(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public async Task<IEnumerable<Reservation>> GetReservationsAsync()
        {
            return await _reservationRepository.GetAllAsync();
        }

        public async Task<bool> CreateReservationAsync(Reservation reservation)
        {
            if (await _reservationRepository.ExistsAsync(reservation.DateReservation))
                throw new InvalidOperationException("Ya existe una reserva para ese día y horario.");

            if (await _reservationRepository.ClientHasReservationAsync(reservation.ClientName, reservation.DateReservation.Date))
                throw new InvalidOperationException("El cliente ya tiene una reserva en ese día.");

            await _reservationRepository.AddAsync(reservation);
            return true;
        }
    }
}

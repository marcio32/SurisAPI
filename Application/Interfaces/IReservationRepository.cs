using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IReservationRepository
    {
        Task<IEnumerable<Reservation>> GetAllAsync();
        Task<Reservation?> GetByIdAsync(int id);
        Task<bool> ExistsAsync(DateTime dateReservation);
        Task<bool> ClientHasReservationAsync(string clientName, DateTime dateReservation);
        Task AddAsync(Reservation reservation);
    }
}

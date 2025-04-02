using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Infrastructure.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly ApplicationDbContext _context;

        public ReservationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Reservation>> GetAllAsync()
        {
            return await _context.Reservations.Include(r => r.Service).ToListAsync();
        }

        public async Task<Reservation?> GetByIdAsync(int id)
        {
            return await _context.Reservations.FindAsync(id);
        }

        public async Task<bool> ExistsAsync(DateTime dateReservation)
        {
            return await _context.Reservations.AnyAsync(r => r.DateReservation == dateReservation);
        }

        public async Task<bool> ClientHasReservationAsync(string clientName, DateTime dateReservation)
        {
            return await _context.Reservations.AnyAsync(r => r.ClientName == clientName && r.DateReservation.Date == dateReservation);
        }

        public async Task AddAsync(Reservation reservation)
        {
            _context.Reservations.Add(reservation);
            await _context.SaveChangesAsync();
        }
    }
}

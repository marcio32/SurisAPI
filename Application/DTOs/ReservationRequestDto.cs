using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class ReservationRequestDto
    {
        [Required]
        public string ClientName { get; set; } = string.Empty;

        [Required]
        public DateTime DateReservation { get; set; }

        [Required]
        public int ServiceId { get; set; }
    }
}

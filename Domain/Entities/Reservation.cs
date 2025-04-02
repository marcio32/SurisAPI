using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Reservation
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string ClientName { get; set; } = string.Empty;

        [Required]
        public DateTime DateReservation { get; set; } 

        [Required]
        public int ServiceId { get; set; }
        [ForeignKey("ServiceId")]
        public Service? Service { get; set; }
    }
}

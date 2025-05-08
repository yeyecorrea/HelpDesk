using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk.Domain.Entities
{
    public class HistorialTicket
    {
        public int Id { get; set; }
        public DateTime FechaCambio { get; set; } = DateTime.UtcNow;
        public string? Descripcion { get; set; }
        public string Accion { get; set; } // "Creación", "Asignación", "Cambio de Estado", etc.
        public string? Detalles { get; set; } // JSON o texto con los cambios específicos


        // Relacion con el Ticket
        public int TicketId { get; set; }
        public Ticket Ticket { get; set; }

        // Relacion con el Usuario
        public string UsuarioId { get; set; }
        public ApplicationUser Usuario { get; set; }
    }
}

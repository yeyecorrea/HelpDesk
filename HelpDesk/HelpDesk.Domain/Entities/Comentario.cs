using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk.Domain.Entities
{
    public class Comentario
    {
        public int Id { get; set; }
        public string Contenido { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
        public bool EsInterno { get; set; } = false; // Solo visible para soporte/admin

        // Realcion con el Usuario
        public string UsuarioId { get; set; }
        public ApplicationUser Usuario { get; set; }

        // Relacion con el Ticket
        public int TicketId { get; set; }
        public Ticket Ticket { get; set; }
    }
}

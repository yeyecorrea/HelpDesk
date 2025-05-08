using Microsoft.AspNetCore.Identity;

namespace HelpDesk.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string NombreCompleto { get; set; }
        public string? Departamento { get; set; }

        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;

        // Relaciones
        public ICollection<Ticket> TicketsCreados { get; set; }
        public ICollection<Ticket> TicketsAsignados { get; set; }

        public ICollection<Comentario> Comentarios { get; set; }
        public ICollection<HistorialTicket> Historiales { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk.Domain.Entities
{
    public class Prioridad
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public int Nivel { get; set; }
        public string? Descripcion { get; set; }

        // Relacion con Ticket
        public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
        
    }
}

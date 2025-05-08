using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk.Domain.Entities
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
        public DateTime? FechaResolucion { get; set; } = DateTime.UtcNow;

        // Relacion con Cliente
        public int ClienteId { get; set; }
        //public ApplicationUser Cliente { get; set; }

        //Relacion con TecnicoAsignado
        public int? TecnicoAsignadoId { get; set; }
        //public ApplicationUser? TecnicoAsignado { get; set; }


        // Relacion con Categoria
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }

        // Relacion con Estado
        public int EstadoId { get; set; }
        public Estado Estado { get; set; }

        // Relacion con Prioridad
        public int PrioridadId { get; set; }
        public Prioridad Prioridad { get; set; }
    }
}

namespace HelpDesk.Domain.Entities
{
    public class Estado
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string? Descripcion { get; set; }

        // Relacion con Ticket
        public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();

    }
}

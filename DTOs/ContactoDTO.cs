namespace BackAgendaDeContactos.DTOs
{
    public class ContactoDTO
    {
        public int IdContacto { get; set; }

        public string? NombreCompleto { get; set; }

        public int? Telefono { get; set; }

        public string? NombreGrupo { get; set; }

        public string? FechaCreacion { get; set; }
    }
}

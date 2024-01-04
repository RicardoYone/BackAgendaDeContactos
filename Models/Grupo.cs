using System;
using System.Collections.Generic;

namespace BackAgendaDeContactos.Models;

public partial class Grupo
{
    public int IdGrupo { get; set; }

    public string? Nombre { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual ICollection<Contacto> Contactos { get; set; } = new List<Contacto>();
}

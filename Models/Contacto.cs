using System;
using System.Collections.Generic;

namespace BackAgendaDeContactos.Models;

public partial class Contacto
{
    public int IdContacto { get; set; }

    public string? NombreCompleto { get; set; }

    public int? Telefono { get; set; }

    public int? IdGrupo { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual Grupo? IdGrupoNavigation { get; set; }
}

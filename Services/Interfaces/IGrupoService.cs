using BackAgendaDeContactos.Models;

namespace BackAgendaDeContactos.Services.Interfaces
{
    public interface IGrupoService
    {
        Task<List<Grupo>> GetList();
    }
}

using BackAgendaDeContactos.Models;

namespace BackAgendaDeContactos.Services.Interfaces
{
    public interface IContactoService
    {
        Task<List<Contacto>> GetList();
        Task<Contacto> Get(int IdContacto);
        Task<Contacto> Add(Contacto modelo);
        Task<bool> Update(Contacto modelo);
        Task<bool> Delete(Contacto modelo);
    }
}

using Microsoft.EntityFrameworkCore;
using BackAgendaDeContactos.Models;
using BackAgendaDeContactos.Services.Interfaces;

namespace BackAgendaDeContactos.Services.Clases
{
    public class ContactoService : IContactoService
    {
        private AgendaDeContactosContext _dbContext;

        public ContactoService(AgendaDeContactosContext dbContex)
        {
            _dbContext = dbContex;
        }

        public async Task<List<Contacto>> GetList()
        {
            try
            {
                List<Contacto> lista = new List<Contacto>();
                lista = await _dbContext.Contactos.Include(dpt=>dpt.IdGrupoNavigation).ToListAsync();

                return lista;
;
            }catch (Exception ex) { throw ex; }
        }

        public async Task<Contacto> Get(int IdContacto)
        {
            try
            {
                Contacto? encontrado = new Contacto();

                encontrado = await _dbContext.Contactos.Include(dpt => dpt.IdGrupoNavigation)
                    .Where(e => e.IdContacto == IdContacto).FirstOrDefaultAsync();

                return encontrado;

            }
            catch (Exception ex) { throw ex; }
        }

        public async Task<Contacto> Add(Contacto modelo)
        {
            try
            {
                _dbContext.Contactos.Add(modelo);
                await _dbContext.SaveChangesAsync();

                return modelo;

            }
            catch (Exception ex) { throw ex; }
        }

        public async Task<bool> Update(Contacto modelo)
        {
            try
            {
                _dbContext.Contactos.Update(modelo);
                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception ex) { throw ex; }
        }

        public async Task<bool> Delete(Contacto modelo)
        {
            try
            {
                _dbContext.Contactos.Remove(modelo);
                await _dbContext.SaveChangesAsync();

                return true;

            }
            catch (Exception ex) { throw ex; }
        }
    }
}

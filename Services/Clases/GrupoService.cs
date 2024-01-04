using Microsoft.EntityFrameworkCore;
using BackAgendaDeContactos.Models;
using BackAgendaDeContactos.Services.Interfaces;
using System.ComponentModel;

namespace BackAgendaDeContactos.Services.Clases
{
    public class GrupoService : IGrupoService
    {
        private AgendaDeContactosContext _dbContext;

        public GrupoService(AgendaDeContactosContext dbContex)
        {
            _dbContext = dbContex;
        }

        public async Task<List<Grupo>> GetList()
        {
            try
            {
                List<Grupo> lista = new List<Grupo>();
                lista = await _dbContext.Grupos.ToListAsync();

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

using AutoMapper;
using BackAgendaDeContactos.DTOs;
using BackAgendaDeContactos.Models;
using BackAgendaDeContactos.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;

namespace BackAgendaDeContactos.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GrupoController : ControllerBase
    {
        private readonly AgendaDeContactosContext _context;
        private readonly IMapper _mapper;
        private readonly IContactoService _contactoService;
        private readonly IGrupoService _grupoService;

        public GrupoController(
            IMapper mapper,
            AgendaDeContactosContext context,
            IContactoService contactoService,
            IGrupoService grupoService
            )
        {
            _context = context;
            _mapper = mapper;
            _contactoService = contactoService;
            _grupoService = grupoService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listarGrupo = await _grupoService.GetList();
                var listarGrupoDTO = _mapper.Map<List<GrupoDTO>>(listarGrupo);

               return Ok(listarGrupoDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}

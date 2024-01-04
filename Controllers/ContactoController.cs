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
    public class ContactoController : ControllerBase
    {
        private readonly AgendaDeContactosContext _context;
        private readonly IMapper _mapper;
        private readonly IContactoService _contactoService;
        private readonly IGrupoService _grupoService;

        public ContactoController(
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
                var listaContacto = await _contactoService.GetList();
                var listaContactoDTO = _mapper.Map<List<ContactoDTO>>(listaContacto);

                return Ok(listaContactoDTO);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(ContactoDTO modelo)
        {
            try
            {
                var _contacto = _mapper.Map<Contacto>(modelo);
                var _contactoCreado = await _contactoService.Add(_contacto);

                return Ok(_mapper.Map<ContactoDTO>(_contactoCreado));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int idContacto, ContactoDTO modelo)
        {
            try
            {
                var _encontrado = await _contactoService.Get(idContacto);

                if (_encontrado == null) { return BadRequest(); }

                var _contacto = _mapper.Map<Contacto>(modelo);

                _encontrado.NombreCompleto = _contacto.NombreCompleto;
                _encontrado.Telefono = _contacto.Telefono;
                _encontrado.FechaCreacion = _contacto.FechaCreacion;
                _encontrado.IdGrupo = _contacto.IdGrupo;

                var respuesta = await _contactoService.Update(_encontrado);

                return Ok(_mapper.Map<ContactoDTO>(_encontrado));
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult>Delete(int idContacto)
        {
            try
            {
                var _encontrado = await _contactoService.Get(idContacto);

                if (_encontrado == null) { return BadRequest(); }

                var respuesta = await _contactoService.Delete(_encontrado);

                return Ok();

            }
            catch (Exception ex) { return BadRequest(); }
        }


    }
}
using AutoMapper;
using BackAgendaDeContactos.DTOs;
using BackAgendaDeContactos.Models;
using System.Globalization;

namespace BackAgendaDeContactos.Profiles
{
    public class ContactoProfile : Profile
    {
        public ContactoProfile()
        {
            CreateMap<Contacto, ContactoDTO>()
                .ForMember(
                destino => destino.NombreGrupo,
                opt => opt.MapFrom(
                    origen => origen.IdGrupoNavigation.Nombre
                    ));

            CreateMap<ContactoDTO, Contacto>()
                .ForMember(
                destino => destino.IdGrupoNavigation,
                opt => opt.Ignore()
                    );
        }
    }
}

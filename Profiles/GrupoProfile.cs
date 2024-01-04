using AutoMapper;
using BackAgendaDeContactos.DTOs;
using BackAgendaDeContactos.Models;
using System.Globalization;

namespace BackAgendaDeContactos.Profiles
{
    public class GrupoProfile : Profile
    {
        public GrupoProfile() 
        {
            CreateMap<Grupo, GrupoDTO>().ReverseMap();
        }
    }
}

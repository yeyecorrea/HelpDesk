using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HelpDesk.Domain.Entities;
using HelpDesk.Shared.Dtos;
using Microsoft.AspNetCore.Identity;

namespace HelpDesk.Business.Mapping
{
    public class AdminProfile : Profile
    {
        public AdminProfile()
        {
            // Mapeo de RegisterDto a ApplicationUser
            CreateMap<RegisterDto, ApplicationUser>()
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.NormalizedEmail, opt => opt.MapFrom(src => src.Email.ToUpper()))
            .ForMember(dest => dest.NormalizedUserName, opt => opt.MapFrom(src => src.Email.ToUpper()))
            .ForMember(dest => dest.NombreCompleto, opt => opt.MapFrom(src => src.NombreCompleto)) // Mapeo faltante
            .ForMember(dest => dest.Departamento, opt => opt.MapFrom(src => src.Departamento))    // Mapeo faltante
            .ForMember(dest => dest.FechaRegistro, opt => opt.MapFrom(src => DateTime.UtcNow))
            .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => HashPassword(src.PassWord))) // Hashear aquí
            .ForMember(dest => dest.TicketsCreados, opt => opt.Ignore())
            .ForMember(dest => dest.TicketsAsignados, opt => opt.Ignore())
            .ForMember(dest => dest.Comentarios, opt => opt.Ignore())
            .ForMember(dest => dest.Historiales, opt => opt.Ignore());


            // Mapeo de LoginDto a ApplicationUser
            CreateMap<LoginDto, ApplicationUser>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));

        }

        // Método auxiliar para hashear la contraseña
        private string HashPassword(string password)
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            return hasher.HashPassword(null, password); // El primer parámetro puede ser null
        }
    }
}

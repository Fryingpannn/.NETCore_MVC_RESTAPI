using AutoMapper;
using Commander.Dtos;
using Commander.Models;

namespace Commander.Profiles
{
    //map our Command object to our CommandReadDto
    //inherit base class Profile from AutoMapper namespace
    class CommandsProfile : Profile
    {
        public CommandsProfile()
        {
            //automapper: maps from X & to Y
            CreateMap<Command,CommandReadDto>();
        }
    }
}
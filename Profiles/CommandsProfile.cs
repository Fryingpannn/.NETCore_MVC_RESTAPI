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
            //Source -> Target
            //automapper: maps from X & to Y
            CreateMap<Command,CommandReadDto>();

            //mapping the created dto to an actual command obj
            CreateMap<CommandCreateDto, Command>();
        }
    }
}
using AutoMapper;
using Commander.Dtos;
using Commander.Models;

namespace Commander.Profiles
{
    //map our Command model to our Dtos
    //inherit base class Profile from AutoMapper namespace
    class CommandsProfile : Profile
    {
        
        public CommandsProfile()
        {
            //<Source -> Target>

            //automapper: maps from Command & to ReadDto
            CreateMap<Command,CommandReadDto>();

            //mapping the created dto to an actual command obj
            CreateMap<CommandCreateDto, Command>();

            //mapping for PUT
            CreateMap<CommandUpdateDto, Command>();

            //mapping for PATCH
            CreateMap<Command, CommandUpdateDto>();
        }
    }
}